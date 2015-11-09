using System.Threading.Tasks;
using System.Windows.Controls;
using TLSharp.Core;
using TLSharp.Core.Utils;

namespace Telebackup
{
    /// <summary>
    /// Interaction logic for BigCard.xaml
    /// </summary>
    public partial class BigCard : UserControl
    {
        public LC Contact;

        public BigCard()
        {
            InitializeComponent();
        }

        BigCard(LC contact) : this()
        {
            Contact = contact;
            nameTB.Text = contact.FullName;
        }

        async Task LoadImage()
        {
            profileI.Source = await Contact.GetSmallProfilePhoto();;
        }

        public static async Task<BigCard> GetBigCard(LC contact)
        {
            var bigCard = new BigCard(contact);
            await bigCard.LoadImage();

            return bigCard;
        }
    }
}
