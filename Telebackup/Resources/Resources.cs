using System;
using System.Windows.Media.Imaging;

namespace Telebackup
{
    class Resources
    {
        static BitmapImage _UserImg, _ChatImg;
        public static BitmapImage UserImg
        {
            get
            {
                if (_UserImg == null)
                    _UserImg = new BitmapImage(new Uri(@"../Resources/user.png", UriKind.Relative));
                return _UserImg;
            }
        }
        public static BitmapImage ChatImg
        {
            get
            {
                if (_ChatImg == null)
                    _ChatImg = new BitmapImage(new Uri(@"../Resources/chat.png", UriKind.Relative));
                return _ChatImg;
            }
        }
    }
}
