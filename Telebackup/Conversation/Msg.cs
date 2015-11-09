using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLSharp.Core;
using TLSharp.Core.MTProto;
using TLSharp.Core.Utils;

namespace Telebackup
{
    public class Msg
    {
        const char SeparatorChar = (char)1;

        public readonly int ID;
        public readonly string Sender;
        public readonly string Content;
        public readonly DateTime Date;
        public readonly long UnixDate;

        public readonly bool Self;
        public readonly string Action;

        // Flag variables
        public readonly string Forwarded;
        public bool IsForwarded { get { return !string.IsNullOrEmpty(Forwarded); } }

        public readonly int ReplyTo;
        public bool IsReply { get { return ReplyTo > -1; } }


        public bool HasMedia { get { return !string.IsNullOrEmpty(MediaType); } }
        public string MediaType;
        public InputFileLocation MediaLocation;
        public string MediaName;

        public readonly bool Empty;

        public Msg()
        {
            Empty = true;
        }

        public Msg(int id, long date, string action)
        {
            Empty = false;

            ID = id;
            Sender = "";
            Content = "";
            UnixDate = date;
            Date = Utils.FromUnixTime(date);

            Self = false;
            Forwarded = "";
            Action = action;
        }

        public static async Task<Msg> BuildMessage(MessageConstructor msg)
        {
            var id = msg.id;

            LC s = msg.from_id.HasValue ? await Telestat.GetContact(msg.from_id.Value) : null;
            var sender = s != null ? s.FullName : string.Empty;

            var content = msg.message;

            var forwarded = string.Empty;
            if (msg.fwd_from_id != null)
            {
                var contact = await Telestat.GetContact(msg.fwd_from_id);
                forwarded = contact == null ? "Unknown" : contact.FullName;
            }

            var replyTo = msg.reply_to_msg_id.HasValue ?
                msg.reply_to_msg_id.Value : -1;

            var date = msg.date;

            var mediaType = "";
            var mediaName = "";
            InputFileLocation mediaIfl = null;


            if (msg.media is MessageMediaEmptyConstructor)
            {
                var m = (MessageMediaEmptyConstructor)msg.media;
            }
            else if (msg.media is MessageMediaPhotoConstructor)
            {
                var m = (MessageMediaPhotoConstructor)msg.media;
                content = m.caption;
                if (m.photo is PhotoConstructor)
                {
                    var p = (PhotoConstructor)m.photo;
                    //                                       Should be largest
                    var loc = ((PhotoSizeConstructor)p.sizes[p.sizes.Count - 1]).location;
                    if (loc is FileLocationConstructor)
                    {
                        var l = (FileLocationConstructor)loc;
                        mediaType = "photo";
                        mediaName = l.local_id + ".jpg";
                        mediaIfl = new InputFileLocationConstructor(l.volume_id, l.local_id, l.secret);
                    }
                }
            }
            else if (msg.media is MessageMediaVideoConstructor)
            {
                var m = (MessageMediaVideoConstructor)msg.media;
                content = m.caption;
                if (m.video is VideoConstructor)
                {
                    var v = (VideoConstructor)m.video;
                    mediaType = "video";
                    mediaName = v.id + ".mp4"; // i guess, may not be mp4
                    mediaIfl = new InputVideoFileLocationConstructor(v.id, v.access_hash);
                }
            }
            else if (msg.media is MessageMediaGeoConstructor)
            {
                var m = (MessageMediaGeoConstructor)msg.media;
                // TODO implement
            }
            else if (msg.media is MessageMediaContactConstructor)
            {
                var m = (MessageMediaContactConstructor)msg.media;
                // TODO implement
            }
            else if (msg.media is MessageMediaUnsupportedConstructor)
            {
                var m = (MessageMediaUnsupportedConstructor)msg.media;
                // TODO implement
            }
            else if (msg.media is MessageMediaDocumentConstructor)
            {
                var m = (MessageMediaDocumentConstructor)msg.media;
                if (m.document is DocumentConstructor)
                {
                    var d = (DocumentConstructor)m.document;
                    mediaType = "document";

                    foreach (var atr in d.attributes)
                        if (atr is DocumentAttributeFilenameConstructor)
                        {
                            var a = (DocumentAttributeFilenameConstructor)atr;
                            mediaName = d.id.ToString() + "_" + a.file_name;
                            break;
                        }
                    if (string.IsNullOrEmpty(mediaName))
                        mediaName = d.id.ToString();
                    
                    mediaIfl = new InputDocumentFileLocationConstructor(d.id, d.access_hash);
                }
            }
            else if (msg.media is MessageMediaAudioConstructor)
            {
                var m = (MessageMediaAudioConstructor)msg.media;
                if (m.audio is AudioConstructor)
                {
                    var a = (AudioConstructor)m.audio;
                    mediaType = "audio";

                    var spl = a.mime_type.Split('/');
                    if (spl.Length > 1) mediaName = a.id.ToString() + "." + spl[1];
                    else mediaName = a.id.ToString() + ".mp3"; // TODO it probs isn't mp3, but well!

                    mediaIfl = new InputAudioFileLocationConstructor(a.id, a.access_hash);
                }
            }
            else if (msg.media is MessageMediaWebPageConstructor)
            {
                var m = (MessageMediaWebPageConstructor)msg.media;
                // TODO implement
            }
            else if (msg.media is MessageMediaVenueConstructor)
            {
                var m = (MessageMediaVenueConstructor)msg.media;
                // TODO implement
            }

            var self = s != null ? s.Self : false;

            return new Msg(
                id, sender, content, date, self,
                string.Empty, forwarded, replyTo,
                mediaType, mediaName, mediaIfl);
        }

        public Msg(int id, string sender, string content, long date, bool self,
            string action = "", string forwarded = "", int replyTo = -1,
            string mediaType = "", string mediaName = "", InputFileLocation mediaIfl = null)
        {
            Empty = false;

            ID = id;
            Sender = sender;
            Content = content;
            UnixDate = date;
            Date = Utils.FromUnixTime(date);

            Self = self;
            Forwarded = forwarded;
            ReplyTo = replyTo;
            Action = "";

            MediaType = mediaType;
            MediaLocation = mediaIfl;
            MediaName = mediaName;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Action)) // TODO LOl not working!
                return "*** " + Action + " ***";

            var sb = new StringBuilder();

            sb.Append(Sender);
            sb.Append(" [");
            sb.Append(Date.ToString("dd.MM.yy HH:mm:ss"));
            sb.Append("]");
            sb.Append(Environment.NewLine);
            sb.Append(Content);

            return sb.ToString();
        }

        public string Parse()
        {
            var sb = new StringBuilder();

            sb.Append(ID.ToString());
            sb.Append(SeparatorChar);

            sb.Append(Sender);
            sb.Append(SeparatorChar);

            sb.Append(Content);
            sb.Append(SeparatorChar);

            sb.Append(UnixDate.ToString());
            sb.Append(SeparatorChar);

            sb.Append(Self.ToString());
            sb.Append(SeparatorChar);

            sb.Append(Action);
            sb.Append(SeparatorChar);

            sb.Append(Forwarded);
            sb.Append(SeparatorChar);

            sb.Append(ReplyTo.ToString());
            sb.Append(SeparatorChar);

            sb.Append(MediaType);
            sb.Append(SeparatorChar);

            sb.Append(MediaName);
            sb.Append(SeparatorChar);

            sb.Append(IFLToString(MediaLocation));

            return sb.ToString();
        }

        public static InputFileLocation IFLFromString(string type, string str)
        {
            var spl = str.Split(':');
            switch (type)
            {
                case "photo":
                    return spl.Length != 3 ? null :
                        new InputFileLocationConstructor(long.Parse(spl[0]), int.Parse(spl[1]), long.Parse(spl[2]));
                case "video":
                    return spl.Length != 2 ? null :
                        new InputVideoFileLocationConstructor(long.Parse(spl[0]), long.Parse(spl[1]));
                case "document":
                    return spl.Length != 2 ? null :
                        new InputDocumentFileLocationConstructor(long.Parse(spl[0]), long.Parse(spl[1]));
                case "audio":
                    return spl.Length != 2 ? null :
                        new InputAudioFileLocationConstructor(long.Parse(spl[0]), long.Parse(spl[1]));
            }
            return null;
        }

        public static string IFLToString(InputFileLocation ifl)
        {
            if (ifl is InputFileLocationConstructor)
            { // photo
                var i = (InputFileLocationConstructor)ifl;
                return i.volume_id + ":" + i.local_id + ":" + i.secret;
            }
            if (ifl is InputVideoFileLocationConstructor)
            { // video
                var i = (InputVideoFileLocationConstructor)ifl;
                return i.id + ":" + i.access_hash;
            }
            if (ifl is InputDocumentFileLocationConstructor)
            { // document
                var i = (InputDocumentFileLocationConstructor)ifl;
                return i.id + ":" + i.access_hash;
            }
            if (ifl is InputAudioFileLocationConstructor)
            { // audio
                var i = (InputAudioFileLocationConstructor)ifl;
                return i.id + ":" + i.access_hash;
            }

            return string.Empty;
        }

        public static Msg FromString(string str)
        {
            var spl = str.Split(SeparatorChar);

            return new Msg(
                int.Parse(spl[0]), spl[1], spl[2], long.Parse(spl[3]), bool.Parse(spl[4]),
                spl[5], spl[6], int.Parse(spl[7]),
                spl[8], spl[9], IFLFromString(spl[8], spl[10]));
        }
    }
}
