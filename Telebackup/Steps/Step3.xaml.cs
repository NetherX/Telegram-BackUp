using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TLSharp.Core;

namespace Telebackup.Steps
{
    public partial class Step3 : UserControl
    {
        #region Events

        public delegate void VoidDelegate();
        public event VoidDelegate Success;
        public event VoidDelegate Failure;

        #endregion

        #region Variables and properties

        bool backuping;
        int totalDownloaded;
        int offset;

        #endregion

        #region Constructor and loading

        public Step3()
        {
            InitializeComponent();
        }

        async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Telestat.Conversation = new Conversation(Telestat.ContactToBackup.ID,
                Telestat.ContactToBackup.FullName); // TODO check if group, if it is NOT, "Chat with", else, group title on html

            cardGrid.Children.Add(await Telestat.GetBigCard());

            Telestat.Conversation.LoadProgress += Conversation_LoadProgress;
            await Telestat.Conversation.Load();
            Telestat.Conversation.LoadProgress -= Conversation_LoadProgress;

            backupB.Content = "Begin backup!";
            backupB.IsEnabled = true;
        }

        private void Conversation_LoadProgress(float percentage) {
            Dispatcher.Invoke(() =>
            backupB.Content = "Loading... " + percentage.ToString("0.00") + "%");
        }

        #endregion

        #region Backup button

        async void backupB_Click(object sender, RoutedEventArgs e)
        {
            if (backuping)
            {
                Success();
                backuping = false;
                backupB.Content = "Continue backup";
            }
            else
            {
                Failure();
                backuping = true;
                backupB.Content = "Pause backup";
                await BeginBackup();
            }
        }

        #endregion

        #region Backup process
        
        async Task BeginBackup()
        {
            await Task.Factory.StartNew(() =>
            {
                while (backuping)
                {
                    var msgs = Telestat.GetMessages(offset).Result; // Downloaded
                    var addedCount = Telestat.Conversation.AddMessages(msgs);
                    
                    totalDownloaded += msgs.Count;
                    offset += msgs.Count;

                    Telestat.Conversation.Save(msgs);

                    var percentage = GetPercentage(Telestat.Conversation.GetMessagesCount(), Telestat.TotalMessages);

                    Dispatcher.Invoke(() =>
                    {
                        messageTB.Content = "Retrieving messages... " +
                        percentage.ToString("0.00") + "%";
                        percentagePB.Value = (int)(percentage * 100f); // * 100 because maximum value is 10000 (more precission)
                    });
                    
                    if (addedCount == 0) // we retrieved the first messages, get back where we left it
                        offset = Telestat.Conversation.GetMessagesCount(); 

                    if (msgs.Count == 0)
                    {
                        Success();

                        Dispatcher.Invoke(() => {
                            backupB.IsEnabled = false;
                            messageTB.Content = "Messages retrieved: " + totalDownloaded;
                        });

                        MessageBox.Show("You successfully generated a backup of " +
                            Telestat.ContactToBackup.FullName, "Success", MessageBoxButton.OK,
                            MessageBoxImage.Information);

                        break;
                    }

                    if (totalDownloaded % 10000 == 0)
                    {
                        Dispatcher.Invoke(() => messageTB.Content = "10 seconds pause to prevent «flood wait»...");
                        Thread.Sleep(10000);
                    }
                    else if (totalDownloaded % 1000 == 0)
                        Thread.Sleep(5000);
                    else
                        Thread.Sleep(1000);
                }
            });
        }

        static float GetPercentage(int current, int total)
        {
            var percentage = (float)current / (float)total * 100f;
            if (percentage > 100f) // clamp
                percentage = 100f;

            return percentage;
        }

        #endregion
    }
}
