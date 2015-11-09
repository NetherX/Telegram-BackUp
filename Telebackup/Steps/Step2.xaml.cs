using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TLSharp.Core.Utils;

namespace Telebackup.Steps
{
    public partial class Step2 : UserControl
    {
        #region Events

        public delegate void VoidDelegate();
        public event VoidDelegate Success;

        void start()
        {
            Telestat.ContactListReceived += Telestat_ContactListReceived;
            Telestat.ContactUpdated += Telestat_ContactUpdated;
            Telestat.ContactsReceived += end;
        }

        void end()
        {
            Telestat.ContactListReceived -= Telestat_ContactListReceived;
            Telestat.ContactUpdated -= Telestat_ContactUpdated;
            Telestat.ContactsReceived -= end;
        }

        #endregion

        #region Constructor and loading

        public Step2()
        {
            InitializeComponent();
        }

        async void step2_Loaded(object sender, RoutedEventArgs e)
        {
            start();
            await Telestat.GetDialogs();
        }

        #endregion

        #region Update contacts list

        private void Telestat_ContactListReceived(List<LC> contacts)
        {
            Dispatcher.Invoke(() => {
                cardsPanel.BeginInit();
                foreach (var contact in contacts)
                {
                    if (string.IsNullOrEmpty(contact.FirstName) && string.IsNullOrEmpty(contact.LastName))
                        continue; // Ignore

                    var card = new Card(contact);
                    card.BackupRequest += Card_BackupRequest;
                    cardsPanel.Children.Add(card);
                }
                cardsPanel.EndInit();
            });
        }

        private void Telestat_ContactUpdated(KeyValuePair<int, BitmapImage> id_img)
        {
            Dispatcher.Invoke(() => {
                foreach (Card card in cardsPanel.Children)
                {
                    if (card.id == id_img.Key)
                    {
                        card.image = id_img.Value;
                        break;
                    }
                }
            });
        }

        #endregion

        #region Contact selected

        private void Card_BackupRequest(LC contact)
        {
            end();
            Telestat.ContactToBackup = contact;
            Success();

            foreach (Card card in cardsPanel.Children)
                card.Opacity = card.id == contact.ID ? 1 : 0.3;
        }

        #endregion
    }
}
