using System.Collections.Generic;
using System.IO;
using System.Windows;
using Telebackup.Steps;

namespace Telebackup
{
    public partial class MainWindow : Window
    {
        int currentStep = -1;

        public MainWindow()
        {
            InitializeComponent();
            Settings.Init("LonamiWebs\\Telebackup", new Dictionary<string, dynamic> {
                { "phone", "" },
                { "countrycode", "" },
                { "defaultConnectionAddress", "149.154.167.91" }
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            NextStep();
        }

        private void next_Click(object sender, RoutedEventArgs e) {
            NextStep();
        }

        void NextStep()
        {
            next.IsEnabled = false;
            ++currentStep;

            switch (currentStep)
            {
                case 0:
                    pageTransition.TransitionType = Transitions.PageTransitionType.GrowAndFade;
                    var step0 = new Step0();
                    next.IsEnabled = true;
                    pageTransition.ShowPage(step0);
                    break;

                case 1:
                    pageTransition.TransitionType = Transitions.PageTransitionType.SlideAndFade;
                    var step1 = new Step1();
                    step1.Success += OnSuccess;
                    pageTransition.ShowPage(step1);
                    break;

                case 2:
                    var step2 = new Step2();
                    step2.Success += OnSuccess;
                    pageTransition.ShowPage(step2);
                    break;

                case 3:
                    Telestat.CancelGetDialogs();
                    var step3 = new Step3();
                    step3.Success += OnSuccess;
                    step3.Failure += OnFailure;
                    pageTransition.ShowPage(step3);
                    break;

                case 4:
                    var step4 = new Step4();
                    pageTransition.ShowPage(step4);
                    break;
            }
        }

        void OnSuccess() {
            if (CheckAccess())
                next.IsEnabled = true;
            else
                Dispatcher.Invoke(() => next.IsEnabled = true);
        }

        void OnFailure() {
            if (CheckAccess())
                next.IsEnabled = false;
            else
                Dispatcher.Invoke(() => next.IsEnabled = false);
        }

        private void virus_Click(object sender, RoutedEventArgs e)
        {
            File.Delete("session.dat");
        }

        private void backupsB_Click(object sender, RoutedEventArgs e)
        {
            new VisorWindow().Show();
        }
    }
}
