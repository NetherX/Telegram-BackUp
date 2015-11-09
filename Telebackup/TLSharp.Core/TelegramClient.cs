using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TLSharp.Core.Auth;
using TLSharp.Core.MTProto;
using TLSharp.Core.Network;
using TLSharp.Core.Utils;

namespace TLSharp.Core
{
    public class TelegramClient
    {
        #region Variables and properties

        MtProtoSender _sender;
        TcpTransport _transport;
        Session _session;

        public User loggedUser { get { return _session.User; } }

        string sessionUserId = "session";

        public Dictionary<int, LC> LCs
            = new Dictionary<int, LC>();
        
        public int latestMsgTotalCount = 0;

        #endregion

        #region Constructor

        public TelegramClient()
        {
            var store = new FileSessionStore();

            _transport = new TcpTransport();
            _session = Session.TryLoadOrCreateNew(store, sessionUserId);
        }

        #endregion

        #region Connect

        public async Task<bool> Connect()
        {
            if (_session.AuthKey == null)
            {
                var result = await Authenticator.DoAuthentication(_transport);
                _session.AuthKey = result.AuthKey;
                _session.TimeOffset = result.TimeOffset;
            }

            _sender = new MtProtoSender(_transport, _session);

            var request = new InitConnectionRequest(Values.ApiID);

            await _sender.Send(request);
            await _sender.Recieve(request);

            return IsUserAuthorized();
        }

        #endregion

        #region Authorization

        public bool IsUserAuthorized() {
            return _session.User != null;
        }

        public async Task<string> SendCodeRequest(string phoneNumber)
        {
            retry:
            var request = new Auth_SendCodeRequest(phoneNumber, 5, // 5 = app code
                Values.ApiID, Values.ApiHash, "en");
            await _sender.Send(request);
            await _sender.Recieve(request);

            var result = (Auth_sentAppCodeConstructor)request.result;

            if (result == null) goto retry; // we probs had a phone migrate error!
            
            return result.phone_code_hash;
        }

        public async Task<User> MakeAuth(string phoneNumber, string phoneHash, string code)
        {
            var request = new Auth_SignInRequest(phoneNumber, phoneHash, code);
            await _sender.Send(request);
            await _sender.Recieve(request);

            var result = (Auth_authorizationConstructor)request.result;
            _session.SessionExpires = 0; //result.SessionExpires;
            _session.User = result.user;

            _session.Save();

            return result.user;
        }

        #endregion

        #region Logout

        public async Task<bool> Logout()
        {
            var request = new Auth_LogOutRequest();
            await _sender.Send(request);
            await _sender.Recieve(request);

            File.Delete("session.dat");

            return request.result;
        }

        #endregion
        
        #region Dialogs and LCs management

        // Loads users and chats (conversations)
        public async Task GetDialogs(int offset, int max_id, int limit)
        {
            var request = new Messages_GetDialogsRequest(offset, limit);
            await _sender.Send(request);
            await _sender.Recieve(request);

            List<User> users = null;
            List<Chat> chats = null;
            if (request.result is Messages_dialogsConstructor)
            {
                var result = (Messages_dialogsConstructor)request.result;
                users = result.users;
                chats = result.chats;
            }
            else if (request.result is Messages_dialogsSliceConstructor)
            {
                var result = (Messages_dialogsSliceConstructor)request.result;
                users = result.users;
                chats = result.chats;
            }

            AddContacts(users.ToArray());
            AddContacts(chats.ToArray());

        }

        #endregion

        #region Downloading messages

        public async Task<List<Message>> GetHistory(LC lc, int offset_id, int add_offset,
            int limit, int max_id, int min_id)
        {
            var request = new Messages_GetHistoryRequest(lc.InputPeer,
                offset_id, add_offset, limit, max_id, min_id);

            await _sender.Send(request);
            await _sender.Recieve(request);

            List<User> users = null;
            List<Message> messages = null;
            if (request.result is Messages_messagesConstructor)
            {
                var result = (Messages_messagesConstructor)request.result;
                users = result.users;
                messages = result.messages;

                latestMsgTotalCount = result.messages.Count;
            }
            else if (request.result is Messages_messagesSliceConstructor)
            {
                var result = (Messages_messagesSliceConstructor)request.result;
                users = result.users;
                messages = result.messages;

                latestMsgTotalCount = result.count;
            }
            AddContacts(users.ToArray());

            return messages;
        }

        #endregion

        #region Download files

        object dlLock = new object();
        public async Task<byte[]> Download(InputFileLocation ifl)
        {
            if (ifl == null) return new byte[0];

            var bytes = new List<byte>();

            await Task.Factory.StartNew(() =>
            {
                lock (dlLock)
                {
                    const int kilobyte = 1024;
                    const int chunkSize = 512;

                    int i = 0;
                    while (true)
                    {
                        var request = new Upload_GetFileRequest(
                            ifl, i * kilobyte * chunkSize, kilobyte * chunkSize);

                        var stask = _sender.Send(request);
                        stask.Wait();

                        var rtask = _sender.Recieve(request);
                        rtask.Wait();

                        var result = (Upload_fileConstructor)request.result;

                        if (result == null) {
                            bytes.Clear(); // file migrate probably
                            break;
                        }
                        bytes.AddRange(result.bytes);

                        if (result.bytes.Length < kilobyte * chunkSize) break;

                        ++i;
                    }
                }
            });
            return bytes.ToArray();
        }

        #endregion

        #region LCs management

        #region Add

        public void AddLogged()
        {
            var lc = new LC(loggedUser, true);
            if (!LCs.ContainsKey(lc.ID))
                LCs.Add(lc.ID, lc);
        }

        void AddContacts(params User[] users)
        {
            foreach (var u in users)
            {
                var lc = new LC(u);
                if (!LCs.ContainsKey(lc.ID))
                    LCs.Add(lc.ID, lc);
            }
        }

        void AddContacts(params Chat[] chats)
        {
            foreach (var c in chats)
            {
                var lc = new LC(c);
                if (!LCs.ContainsKey(lc.ID))
                    LCs.Add(lc.ID, lc);
            }
        }

        #endregion

        #region Retrieve
        
        public async Task<List<LC>> GetContacts(params Peer[] peers)
        {
            var id_type = new Dictionary<int, LC.PeerType>();

            foreach (var peer in peers)
            { 
                if (peer is PeerUserConstructor)
                    id_type.Add(((PeerUserConstructor)peer).user_id, LC.PeerType.User);
                else if (peer is PeerChatConstructor)
                    id_type.Add(((PeerChatConstructor)peer).chat_id, LC.PeerType.Chat);
                else if (peer is PeerChannelConstructor)
                    id_type.Add(((PeerChannelConstructor)peer).channel_id, LC.PeerType.Channel);
            }

            return await GetContacts(id_type);
        }

        public async Task<LC> GetContact(int userid)
        {
            return (await GetContacts(
                new Dictionary<int, LC.PeerType> { { userid, LC.PeerType.User } }))
                .FirstOrDefault();
        }
        public async Task<List<LC>> GetContacts(Dictionary<int, LC.PeerType> id_type)
        {
            var lcs = new List<LC>(id_type.Count);

            var users = new List<InputUser>();
            var channels = new List<InputChannel>();
            var chats = new List<int>();

            foreach (var it in id_type)
            {
                if (LCs.ContainsKey(it.Key))
                {
                    lcs.Add(LCs[it.Key]);
                    continue;
                }

                switch (it.Value)
                {
                    // Self user
                    case LC.PeerType.Self:
                        users.Add(new InputUserSelfConstructor());
                        break;

                    // User
                    case LC.PeerType.User:
                        users.Add(new InputUserConstructor(it.Key, 0));
                        break;

                    // Chat
                    case LC.PeerType.Chat:
                        chats.Add(it.Key);
                        break;

                    // Channel
                    case LC.PeerType.Channel:
                        channels.Add(new InputChannelConstructor(it.Key, 0));
                        break;
                }
            }

            if (users.Count > 0)
            {
                var request = new Users_GetUsersRequest(users);

                await _sender.Send(request);
                await _sender.Recieve(request);

                foreach (var user in request.result)
                {
                    var lc = new LC(user);
                    LCs.Add(lc.ID, lc);
                    lcs.Add(lc);
                }
            }

            if (chats.Count > 0)
            {
                var request = new Messages_GetChatsRequest(chats);

                await _sender.Send(request);
                await _sender.Recieve(request);
                
                var result = (Messages_chatsConstructor)request.result;

                foreach (var chat in result.chats)
                {
                    var lc = new LC(chat);
                    LCs.Add(lc.ID, lc);
                    lcs.Add(lc);
                }
            }

            if (channels.Count > 0)
            {
                var request = new Channels_GetChannelsRequest(channels);

                await _sender.Send(request);
                await _sender.Recieve(request);

                var result = (Messages_chatsConstructor)request.result;

                if (result != null && result.chats != null) // we may get CHANNEL_INVALID
                {
                    foreach (var chat in result.chats)
                    {
                        var lc = new LC(chat);
                        LCs.Add(lc.ID, lc);
                        lcs.Add(lc);
                    }
                }
                else
                    lcs.Capacity -= channels.Count; // remove capacity
            }

            return lcs;
        }

        public async Task<List<LC>> GetContacts(params string[] phoneNumbers)
        {
            var lcs = new List<LC>(phoneNumbers.Length);

            var phones = new List<InputContact>();

            foreach (var phone in phoneNumbers)
            {
                var contact = LCs.FirstOrDefault(c => c.Value.Phone == phone).Value;

                if (contact != null)
                {
                    lcs.Add(contact);
                    continue;
                }

                phones.Add(new InputPhoneContactConstructor(0, phone, string.Empty, string.Empty));
            }

            if (phones.Count > 0)
            {
                var request = new Contacts_ImportContactsRequest(phones, true);
                await _sender.Send(request);
                await _sender.Recieve(request);

                var result = (Contacts_importedContactsConstructor)request.result;
                foreach (var user in result.users)
                {
                    var lc = new LC(user);
                    LCs.Add(lc.ID, lc);
                    lcs.Add(lc);
                }
            }

            return lcs;
        }

        #endregion

        #endregion
    }
}
