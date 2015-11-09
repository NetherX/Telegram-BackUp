using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Telebackup.Steps
{
    public partial class Step4 : UserControl
    {
        #region Variables

        readonly SaveFileDialog textSfd = new SaveFileDialog()
        {
            Title = "Export as text",
            Filter = "Plain text file|*.txt"
        };

        readonly SaveFileDialog htmlSfd = new SaveFileDialog()
        {
            Title = "Export as HTML",
            Filter = "HTML file|*.html"
        };

        #endregion

        #region Constructor and loading

        public Step4()
        {
            InitializeComponent();
        }

        async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await Telestat.Conversation.Save();

            cardGrid.Children.Add(await Telestat.GetBigCard());
            await LoadInformation();
        }

        #endregion

        #region Useless facts

        async Task LoadInformation()
        {
            await Task.Factory.StartNew(() =>
            {
                var msgs = Telestat.Conversation.GetMessagesNoOrder();

                var dayCount = new Dictionary<DateTime, int>();
                var mostDay = new KeyValuePair<DateTime, int>(new DateTime(1900, 1, 1), 0);
                var msgsSent = 0;
                var msgsTotal = 0;
                long charCount = 0;
                foreach (var msg in msgs)
                {
                    if (msg.Self) ++msgsSent;
                    ++msgsTotal;

                    var dt = new DateTime(msg.Date.Year, msg.Date.Month, msg.Date.Day);
                    if (!dayCount.ContainsKey(dt))
                        dayCount.Add(dt, 0);
                    ++dayCount[dt];

                    charCount += msg.Content.Length;
                }
                foreach (var dc in dayCount)
                    if (dc.Value > mostDay.Value)
                        mostDay = dc;

                Dispatcher.Invoke(() => {
                    sentTotalTB.Text = msgsSent.ToString("n0") + "/" + msgsTotal.ToString("n0");
                    mostDayTB.Text = mostDay.Key.ToShortDateString() + " (" + mostDay.Value.ToString("n0") + ")";
                    charactersTB.Text = charCount.ToString("n0");
                });
            });
        }

        #endregion

        #region Export buttons

        private void exportTextB_Click(object sender, RoutedEventArgs e)
        {
            var result = textSfd.ShowDialog();
            if (result.HasValue && result.Value)
                using (new WaitCursor())
                {
                    DisableAll();
                    Telestat.Conversation.ExportTXT(textSfd.FileName);
                    EnableAll();
                }
        }

        private void exportHtmlB_Click(object sender, RoutedEventArgs e)
        {
            var result = htmlSfd.ShowDialog();
            if (result.HasValue && result.Value)
                using (new WaitCursor())
                {
                    DisableAll();
                    Telestat.Conversation.ExportHTML(htmlSfd.FileName);
                    EnableAll();
                }
        }

        private void exportHtmlDifferentB_Click(object sender, RoutedEventArgs e)
        {
            var result = htmlSfd.ShowDialog();
            if (result.HasValue && result.Value)
                using (new WaitCursor())
                {
                    DisableAll();
                    Telestat.Conversation.ExportHTMLDifferentFiles(htmlSfd.FileName);
                    EnableAll();
                }
        }

        void DisableAll() {
            logoutB.IsEnabled = exportHtmlB.IsEnabled = exportHtmlDifferentB.IsEnabled =
                exportTextB.IsEnabled = false;
        }
        void EnableAll() {
            logoutB.IsEnabled = exportHtmlB.IsEnabled = exportHtmlDifferentB.IsEnabled =
                exportTextB.IsEnabled = true;

            MessageBox.Show("Export finished successfully", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region Exit

        async void logoutB_Click(object sender, RoutedEventArgs e)
        {
            await Telestat.Logout();
            Application.Current.Shutdown();
        }

        #endregion
    }
}
