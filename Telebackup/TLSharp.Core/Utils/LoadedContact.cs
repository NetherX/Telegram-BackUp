using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Telebackup;
using TLSharp.Core.MTProto;

namespace TLSharp.Core.Utils
{
    public class LC // Loaded contact/chat
    {
        public enum PeerType { Self, User, Channel, Chat };

        public string FullName
        { get {
            return string.IsNullOrEmpty(LastName) ? FirstName : FirstName + " " + LastName;
        } }

        public string Username;

        public int ID;
        public long AccessHash;
        public bool Self { get { return Type == PeerType.Self; } }

        public string FirstName;
        public string LastName;
        public string Phone;

        public PeerType Type;

        BitmapImage LargeImage;
        BitmapImage SmallImage;

        InputFileLocation ifl_small;
        InputFileLocation ifl_large;

        public InputPeer InputPeer
        { get {
            switch (Type)
            {
                case PeerType.Self:
                    return new InputPeerSelfConstructor();
                case PeerType.User:
                    return new InputPeerUserConstructor(ID, AccessHash);
                case PeerType.Chat:
                    return new InputPeerChatConstructor(ID);
                case PeerType.Channel:
                    return new InputPeerChannelConstructor(ID, AccessHash);
            }
        return null; } }

        // TODO WHEN IS IT SELF?
        public LC(int id, string firstName, string lastName, ChatPhoto photo)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Type = PeerType.Chat;

            if (photo != null) LoadIfl(photo);
        }

        public LC(User user, bool selfUser = false)
        {
            if (user is UserConstructor)
            {
                var u = (UserConstructor)user;
                
                ID = u.id;
                if (u.access_hash.HasValue) AccessHash = u.access_hash.Value;
                Username = u.username;

                Type = selfUser ? PeerType.Self : PeerType.User;

                FirstName = u.first_name;
                LastName = u.last_name;
                Phone = u.phone;

                LoadIfl(u.photo);
            }
        }

        public LC(Chat chat)
        {
            if (chat is ChatConstructor)
            {
                var c = (ChatConstructor)chat;

                ID = c.id;

                FirstName = c.title;
                LastName = string.Empty;

                AccessHash = 0;
                Username = string.Empty;

                Type = PeerType.Chat;

                Phone = string.Empty;

                LoadIfl(c.photo);
            }
        }

        void LoadIfl(UserProfilePhoto photo)
        {
            if (photo is UserProfilePhotoConstructor)
            {
                var flbig = (FileLocationConstructor)((UserProfilePhotoConstructor)photo).photo_big;
                var flsmall = (FileLocationConstructor)((UserProfilePhotoConstructor)photo).photo_small;

                ifl_large = new InputFileLocationConstructor(flbig.volume_id, flbig.local_id, flbig.secret);
                ifl_small = new InputFileLocationConstructor(flsmall.volume_id, flsmall.local_id, flsmall.secret);
            }
        }

        void LoadIfl(ChatPhoto photo)
        {
            if (photo is ChatPhotoConstructor)
            {
                var flbig = (FileLocationConstructor)((ChatPhotoConstructor)photo).photo_big;
                var flsmall = (FileLocationConstructor)((ChatPhotoConstructor)photo).photo_small;

                ifl_large = new InputFileLocationConstructor(flbig.volume_id, flbig.local_id, flbig.secret);
                ifl_small = new InputFileLocationConstructor(flsmall.volume_id, flsmall.local_id, flsmall.secret);
            }
        }

        public async Task<BitmapImage> GetLargeProfilePhoto()
        {
            try
            {
                if (LargeImage == null)
                    LargeImage = await Telestat.DownloadImage(ifl_large);
            } catch (InvalidOperationException) { } // File migrate

            return LargeImage;
        }

        public async Task<BitmapImage> GetSmallProfilePhoto()
        {
            try
            {
                if (SmallImage == null)
                    SmallImage = await Telestat.DownloadImage(ifl_small);
            } catch (InvalidOperationException) { } // File migrate
            
            return SmallImage;
        }
    }
}
