using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TLSharp.Core;
using TLSharp.Core.Utils;

namespace Telebackup
{
    public class Conversation
    {
        #region Static and consts variables

        public static string ConversationsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "LonamiWebs\\Telebackup");

        const char MessagesSeparator = (char)3;
        const string Extension = ".tgchat";

        #endregion

        #region Variables

        public readonly string Title;
        Dictionary<int, Msg> Messages;

        readonly string convPath;

        #endregion

        #region Constructor

        public Conversation(int id, string title)
        {
            Title = title;
            Messages = new Dictionary<int, Msg>();

            convPath = Path.Combine(ConversationsPath, id.ToString() + Extension);
        }

        #endregion

        #region Messages management

        public IEnumerable<Msg> GetMessages()
        {
            var msgs = Messages.ToList();
            msgs.Sort((kvp1, kvp2) => kvp1.Key.CompareTo(kvp2.Key));

            foreach (var msg in msgs)
                yield return msg.Value;
        }

        public IEnumerable<Msg> GetMessagesNoOrder()
        {
            foreach (var msg in Messages)
                yield return msg.Value;
        }

        public int GetMessagesCount() { return Messages.Count; }

        public int AddMessages(List<Msg> msgs)
        {
            int added = 0;

            foreach (var msg in msgs)
                if (!Messages.ContainsKey(msg.ID))
                {
                    Messages.Add(msg.ID, msg);
                    ++added;
                }

            return added;
        }

        public int GetMinID()
        { return FindMinMax().Key; }

        KeyValuePair<int, int> FindMinMax()
        {
            if (Messages.Count == 0) return new KeyValuePair<int, int>(0, 0);

            int min = int.MaxValue;
            int max = 0;

            foreach (var msg in Messages)
            {
                if (msg.Key < min)
                    min = msg.Key;
                if (msg.Key > max)
                    max = msg.Key;
            }

            return new KeyValuePair<int, int>(min, max);
        }

        #endregion

        #region Load and save

        public delegate void LoadDelegate(float percentage);
        public event LoadDelegate LoadProgress;
        void OnLoad(int current, int max)
        { if (LoadProgress != null) LoadProgress(100f * current/max); }

        public async Task Load()
        {
            if (!Directory.Exists(ConversationsPath) || !File.Exists(convPath))
                return;

            await Task.Factory.StartNew(() =>
            {
                var spls = File.ReadAllText(convPath, Encoding.UTF8).Split(MessagesSeparator);
                for (int i = 1; i < spls.Length; i++) // Skip 1 which is information
                {
                    if (i % 100 == 0) OnLoad(i, spls.Length);

                    var msg = Msg.FromString(spls[i]);

                    if (!Messages.ContainsKey(msg.ID))
                        Messages.Add(msg.ID, msg);
                }
            });
        }

        public static Conversation LoadChat(string name)
        {
            if (!Directory.Exists(ConversationsPath))
                return null;
            
            foreach (var file in Directory.GetFiles(ConversationsPath, "*" + Extension))
                if (GetName(file) == name)
                    return new Conversation(int.Parse(Path.GetFileNameWithoutExtension(file)), name);

            return null;
        }

        public async Task Save()
        {
            if (Messages.Count == 0) return;

            await Task.Factory.StartNew(() =>
            {
                if (!Directory.Exists(ConversationsPath))
                    Directory.CreateDirectory(ConversationsPath);

                var sb = new StringBuilder();
                sb.Append(Title);
                sb.Append(MessagesSeparator);

                var msgs = GetMessages(); // sort them out!
                foreach (var msg in msgs)
                {
                    sb.Append(msg.Parse());
                    sb.Append(MessagesSeparator);
                }
                --sb.Length;

                File.WriteAllText(convPath, sb.ToString(), Encoding.UTF8);
            });
        }

        // Messages to append
        public void Save(List<Msg> msgs)
        {
            if (Messages.Count == 0) return;

            if (!Directory.Exists(ConversationsPath))
                Directory.CreateDirectory(ConversationsPath);

            var sb = new StringBuilder();
            if (!File.Exists(convPath)) // First time, append title
                sb.Append(Title);

            foreach (var msg in msgs)
            {
                sb.Append(MessagesSeparator);
                sb.Append(msg.Parse());
            }

            File.AppendAllText(convPath, sb.ToString(), Encoding.UTF8);
        }

        #endregion

        #region Listing

        public static IEnumerable<string> ListChats()
        {
            if (Directory.Exists(ConversationsPath))
                foreach (var file in Directory.GetFiles(ConversationsPath, "*" + Extension))
                    yield return GetName(file);
        }

        static string GetName(string file)
        { return File.ReadAllText(file).Split(MessagesSeparator)[0]; }

        #endregion

        #region Export

        public void ExportTXT(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            File.WriteAllText(path, GenerateText(GetMessages().ToList()), Encoding.UTF8);
        }

        public void ExportHTML(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            File.WriteAllText(path, HTMLExporter.GenerateHTML(Title, GetMessages().ToList()), Encoding.UTF8);
        }

        public void ExportHTMLDifferentFiles(string path)
        {
            var dayMessages = new Dictionary<DateTime, List<Msg>>();
            var msgs = GetMessages();

            foreach (var msg in msgs)
            {
                var date = new DateTime(msg.Date.Year, msg.Date.Month, msg.Date.Day);
                if (!dayMessages.ContainsKey(date))
                    dayMessages.Add(date, new List<Msg>());

                dayMessages[date].Add(msg);
            }

            var name = Path.GetFileNameWithoutExtension(path);
            var dir = Path.Combine(Path.GetDirectoryName(path), name);
            var ext = Path.GetExtension(path);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            foreach (var dayMsg in dayMessages)
            {
                File.WriteAllText(Path.Combine(dir, name + "_" + dayMsg.Key.ToString("yyyy.MM.dd")
                    + ext), HTMLExporter.GenerateHTML(Title, dayMsg.Value), Encoding.UTF8);
            }
        }

        #endregion

        #region Text exporter

        string GenerateText(List<Msg> Messages)
        {
            var sb = new StringBuilder();

            sb.AppendLine(Title);
            sb.AppendLine();
            foreach (var msg in Messages)
            {
                sb.AppendLine(msg.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        #endregion
    }
}
