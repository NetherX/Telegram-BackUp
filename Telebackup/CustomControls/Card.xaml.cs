using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TLSharp.Core.Utils;

namespace Telebackup
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        LC contact;

        public int id { get { return contact.ID; } }

        public string name {
            get { return nameTB.Text; }
            set { nameTB.Text = value; }
        }

        public BitmapImage image {
            get { return (BitmapImage)profileI.Source; }
            set { profileI.Source = value; }
        }

        public delegate void BackupDelegate(LC contact);
        public event BackupDelegate BackupRequest;

        public Card()
        {
            InitializeComponent();
        }

        public Card(LC contact) : this()
        {
            this.contact = contact;
            nameTB.Text = contact.FullName;

            profileI.Source = contact.Type == LC.PeerType.Chat ?
                Telebackup.Resources.ChatImg : Telebackup.Resources.UserImg;

        }

        private void backupB_Click(object sender, System.Windows.RoutedEventArgs e)
        { BackupRequest(contact); }
    }
}
