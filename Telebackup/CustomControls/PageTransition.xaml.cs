/* How to use:
 * 1. Add <Transitions:PageTransition ... /> to your XAML
 * 2. When you want to show a new page (another UserControl), call PageTransition.ShowPage(UserControl)
 * 3. All done!
 * * * * * * * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace Transitions
{
    #region Enums and converters

    public enum PageTransitionType
    {
        Fade,
        Slide,
        SlideAndFade,
        Grow,
        GrowAndFade,
        Flip,
        FlipAndFade,
        Spin,
        SpinAndFade
    }

    public class CenterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { return (double)value / 2; }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { return (double)value * 2; }
    }

    #endregion

    public partial class PageTransition : UserControl
    {
        Stack<UserControl> pages = new Stack<UserControl>();

        public UserControl CurrentPage;

        public readonly DependencyProperty TransitionTypeProperty =
            DependencyProperty.Register("TransitionType", typeof(PageTransitionType),
            typeof(PageTransition), new PropertyMetadata(PageTransitionType.SlideAndFade));

        public PageTransitionType TransitionType
        {
            get { return (PageTransitionType)GetValue(TransitionTypeProperty); }
            set { SetValue(TransitionTypeProperty, value); }
        }

        public PageTransition()
        {
            InitializeComponent();
        }

        public void ShowPage(UserControl newPage)
        {
            pages.Push(newPage);

            Task.Factory.StartNew(() => ShowNewPage());
        }

        void ShowNewPage()
        {
            Dispatcher.Invoke(() => {
                if (contentPresenter.Content != null)
                {
                    var oldPage = (UserControl)contentPresenter.Content;

                    if (oldPage != null) // TODO redundant check?
                    {
                        oldPage.Loaded -= page_Loaded;
                        UnloadPage(oldPage);
                    }
                }
                else
                {
                    ShowNextPage();
                }
            });
        }

        void ShowNextPage()
        {
            var newPage = pages.Pop();

            newPage.Loaded += page_Loaded;

            contentPresenter.Content = newPage;
        }

        void UnloadPage(UserControl page)
        {
            var hidePage =
                ((Storyboard)(Resources[TransitionType.ToString() + "Out"])).Clone();

            hidePage.Completed += hidePage_Completed;

            hidePage.Begin(contentPresenter);
        }

        void page_Loaded(object sender, RoutedEventArgs e)
        {
            var showNewPage =
                ((Storyboard)(Resources[TransitionType.ToString() + "In"])).Clone();

            showNewPage.Begin(contentPresenter);

            CurrentPage = (UserControl)sender;
        }

        void hidePage_Completed(object sender, EventArgs e)
        {
            contentPresenter.Content = null;

            ShowNextPage();
        }
    }
}