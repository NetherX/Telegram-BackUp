using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Telebackup
{
    /// <summary>
    /// Interaction logic for VisorWindow.xaml
    /// </summary>
    public partial class VisorWindow : Window
    {
        class Fact
        {
            public string Count { get; set; }
            public int Sent { get; set; }
            public int Received { get; set; }
            public int Total { get; set; }

            public Fact(string name, int sent, int received)
            {
                Count = name;
                Sent = sent;
                Received = received;
                Total = Sent + Received;
            }
        }

        Conversation conversation;

        public VisorWindow()
        {
            InitializeComponent();

            chats.BeginInit();
            foreach (var chat in Conversation.ListChats())
                chats.Items.Add(chat);
            chats.EndInit();
        }

        async void chats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Fade "Loading..." in
            const int fadeDuration = 200;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(fadeDuration));
            DoubleAnimation anim = new DoubleAnimation(1, duration);
            loadingG.Visibility = Visibility.Visible;
            loadingG.BeginAnimation(OpacityProperty, anim);
            
            conversation = Conversation.LoadChat((string)chats.SelectedItem);
            await conversation.Load();

            infoControl.IsEnabled = false;
            infoControl.Visibility = Visibility.Visible;

            await infoControl.LoadInformation(conversation);

            infoControl.IsEnabled = true;

            Task.Factory.StartNew(() => System.Threading.Thread.Sleep(1000)).Wait(); // it's cool :( i wanna keep it

            // Fade "Loading..." out
            anim = new DoubleAnimation(0, duration);
            loadingG.BeginAnimation(OpacityProperty, anim);
            Task.Factory.StartNew(() => System.Threading.Thread.Sleep(fadeDuration)).Wait(); // it's cool :( i wanna keep it
            loadingG.Visibility = Visibility.Hidden;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var delta = -e.Delta;
            if (delta < 0)
            {
                if (scrollViewer.HorizontalOffset + delta > 0)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + delta);
                else
                    scrollViewer.ScrollToLeftEnd();
            }
            else
            {
                if (scrollViewer.HorizontalOffset + delta < scrollViewer.ExtentWidth)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + delta);
                else
                    scrollViewer.ScrollToRightEnd();
            }

        }
    }
}
