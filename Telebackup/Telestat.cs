using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TLSharp.Core;
using TLSharp.Core.MTProto;
using TLSharp.Core.Utils;

namespace Telebackup
{
    // This class is the intermediate for the client and the downloader session
    static class Telestat
    {
        static TelegramClient client;
        
        static string loginHash;
        static User loggedUser;

        static int loggedUserId;

        static string phoneNumber;

        public static void SetPhoneNumber(string countryCode, string phoneNumber)
        { Telestat.phoneNumber = countryCode + phoneNumber; }

        public static LC ContactToBackup;
        public static Conversation Conversation;

        public delegate void VoidDelegate();
        public delegate void ContactDelegate(List<LC> contacts);
        public delegate void ContactUpdateDelegate(KeyValuePair<int, BitmapImage> id_img);

        public static event VoidDelegate CodeRequired;
        public static event VoidDelegate LoginFailed;
        public static event VoidDelegate LoginSuccess;

        public static event ContactDelegate ContactListReceived;
        public static event ContactUpdateDelegate ContactUpdated;
        public static event VoidDelegate ContactsReceived;
        
        public static async Task Login()
        {
            if (client == null)
                client = new TelegramClient();

            if (!await client.Connect())
            {
                CodeRequired();
                loginHash = await client.SendCodeRequest(phoneNumber);
            }
            else
            {
                loggedUserId = ((UserConstructor)client.loggedUser).id;
                OnLoginSuccess();
            }
        }

        static string loginCode;

        public static async Task LoginCode(string code)
        {
            loginCode = code;
            loggedUser = await client.MakeAuth(phoneNumber, loginHash, code);

            if (loggedUser == null)
            {
                MessageBox.Show("Could not login. Invalid code.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                loggedUserId = ((UserConstructor)loggedUser).id;
                OnLoginSuccess();
            }
        }

        static void OnLoginSuccess()
        {
            client.AddLogged();

            if (LoginSuccess != null)
                LoginSuccess();
        }

        public static async Task Logout()
        {
            await client.Logout();
            File.Delete("session.dat");
        }

        static bool dialogs_cancelled;
        public static async Task GetDialogs()
        {
            dialogs_cancelled = false;
            await client.GetDialogs(0, 0, 0);

            var lcs = new List<LC>(client.LCs.Count);
            foreach (var ilc in client.LCs)
                lcs.Add(ilc.Value);

            ContactListReceived(lcs);

            await Task.Factory.StartNew(() =>
            {
                foreach (var lc in client.LCs)
                {
                    if (dialogs_cancelled) break;

                    var pp = lc.Value.GetSmallProfilePhoto().Result;
                    if (pp != null && ContactUpdated != null) ContactUpdated(new KeyValuePair<int, BitmapImage>(lc.Value.ID, pp));

                    Thread.Sleep(500);
                }
            });

            if (ContactsReceived != null) ContactsReceived();
        }

        public static void CancelGetDialogs()
        {
            dialogs_cancelled = true;
        }

        public static async Task<LC> GetContact(int userid)
        { return await client.GetContact(userid); }

        public static async Task<LC> GetContact(Peer user)
        { return (await client.GetContacts(user)).FirstOrDefault(); }

        public static async Task<List<Msg>> GetMessages(int offset)
        {
            var msgs = await client.GetHistory(ContactToBackup, 0, offset, 100, 0, 0);

            var result = new List<Msg>(msgs.Count);

            for (int i = 0; i < msgs.Count; i++)
            {
                if (msgs[i] is MessageConstructor)
                {
                    result.Add(await Msg.BuildMessage((MessageConstructor)msgs[i]));
                }
                else if (msgs[i] is MessageServiceConstructor) // Contact left or something
                {
                    var m = (MessageServiceConstructor)msgs[i];

                    // Maybe i can take who made the action with m.from_id

                    result.Add(new Msg(m.id, m.date,
                        await GetActionString(m.from_id.HasValue ? m.from_id.Value : 0, m.action)));
                }
                else //if (msgs[i] is MessageEmptyConstructor)
                {
                    // Poop!
                }
            }

            return result;
        }

        public static int TotalMessages { get { return client.latestMsgTotalCount; } }

        public static async Task<BitmapImage> DownloadImage(InputFileLocation ifl)
        { return Utils.LoadImage(await client.Download(ifl)); }

        public static async Task<byte[]> Download(InputFileLocation ifl)
        { return await client.Download(ifl); }

        static async Task<string> GetActionString(int sender, MessageAction action)
        {
            var s = await client.GetContact(sender);

            if (action is MessageActionChatAddUserConstructor)
            {
                // Add user
                var a = (MessageActionChatAddUserConstructor)action;
                var user = await client.GetContact(a.user_id);

                return s.FullName + " added " + user.FullName;
            }
            else if (action is MessageActionChatCreateConstructor)
            {
                // Chat create
                var a = (MessageActionChatCreateConstructor)action;
                return s.FullName + " created group «" + a.title + "»";
            }
            else if (action is MessageActionChatDeletePhotoConstructor)
            {
                // Delete photo
                var a = (MessageActionChatDeletePhotoConstructor)action;
                return s.FullName + " removed group photo";
            }
            else if (action is MessageActionChatDeleteUserConstructor)
            {
                // Delete user
                var a = (MessageActionChatDeleteUserConstructor)action;
                var user = await client.GetContact(a.user_id);

                return user.ID == s.ID ?
                    user.FullName + " left the group" :
                    s.FullName + " removed " + user.FullName;
            }
            else if (action is MessageActionChatEditPhotoConstructor)
            {
                // Edit photo
                var a = (MessageActionChatEditPhotoConstructor)action;
                return s.FullName + " updated group photo"; // TODO send photo
            }
            else if (action is MessageActionChatEditTitleConstructor)
            {
                // Edit title
                var a = (MessageActionChatEditTitleConstructor)action;
                return s.FullName + " changed group name to «" + a.title + "»";
            }

            return "";
        }

        public static async Task<BigCard> GetBigCard()
        {
            return await BigCard.GetBigCard(ContactToBackup);
        }
    }
}
