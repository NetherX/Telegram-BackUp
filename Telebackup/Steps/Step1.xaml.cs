using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Telebackup.Steps
{
    public partial class Step1 : UserControl
    {
        #region Events

        public delegate void VoidDelegate();
        public event VoidDelegate Success;

        void start()
        {
            Telestat.CodeRequired += EnableCode;
            Telestat.LoginFailed += EnableCode;
            Telestat.LoginSuccess += Telestat_LoginSuccess;
        }

        void end()
        {
            Telestat.CodeRequired -= EnableCode;
            Telestat.LoginFailed -= EnableCode;
            Telestat.LoginSuccess -= Telestat_LoginSuccess;
        }

        #endregion

        #region Constructor

        bool loaded;
        public Step1()
        {
            InitializeComponent();

            countryCodeCB.BeginInit();
            countryNameCB.BeginInit();
            foreach (var kvp in CountryCodes.Codes)
            {
                countryCodeCB.Items.Add(kvp.Key);
                countryNameCB.Items.Add(kvp.Value);
            }
            countryCodeCB.EndInit();
            countryNameCB.EndInit();

            phoneTB.Text = Settings.GetValue<string>("phone");
            countryCodeCB.Text = Settings.GetValue<string>("countrycode");

            start();

            loaded = true;
        }

        #endregion

        #region User input

        private void countryNameCB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CountryCodes.Codes.ContainsValue(countryNameCB.Text))
                countryCodeCB.Text = CountryCodes.Codes.First(kvp => kvp.Value == countryNameCB.Text).Key;
            CheckLoginEnabled();
        }

        private void countryCodeCB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CountryCodes.Codes.ContainsKey(countryCodeCB.Text))
                countryNameCB.Text = CountryCodes.Codes[countryCodeCB.Text];
            CheckLoginEnabled();
        }

        private void codeCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                phoneTB.Focus();
            }
        }

        private void phoneCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckLoginEnabled();

            if (loaded)
                File.Delete("session.dat");
        }

        private void phoneCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (loginB.IsEnabled)
                    loginB_Click(null, null);

            e.Handled = !Utils.IsNumeric(e.Key);
        }

        // If first step is successful
        bool loggedIn;
        async void loginB_Click(object sender, RoutedEventArgs e)
        {
            if (codeTB.IsEnabled)
            {
                loginB.Content = "Logging in...";
                loginB.IsEnabled = codeTB.IsEnabled = false;
                await Telestat.LoginCode(codeTB.Text);
            }
            else
            {
                loginB.Content = "Logging in...";
                loginB.IsEnabled = countryCodeCB.IsEnabled =
                    countryNameCB.IsEnabled = phoneTB.IsEnabled = false;
                
                Telestat.SetPhoneNumber(countryCodeCB.Text, phoneTB.Text);

                Timer timer = null;
                timer = new Timer((obj) =>
                {
                    if (!loggedIn)
                    {
                        File.Delete("session.dat");

                        Dispatcher.Invoke(() => {
                            loginB.Content = "Login";
                            loginB.IsEnabled = true;
                        });
                    }
                    timer.Dispose();
                },
                null, 5000, Timeout.Infinite);

                await Telestat.Login();
            }
        }

        void EnableCode()
        {
            loginB.Content = "Continue login";
            loggedIn = true;
            codeTB.IsEnabled = true;
        }
        
        #endregion

        #region Validation

        void CheckLoginEnabled()
        {
            loginB.IsEnabled = countryCodeCB.Text.Length > 0 && phoneTB.Text.Length > 0 && 
                (codeTB.IsEnabled ? codeTB.Text.Length == 5 : true);
        }

        void Telestat_LoginSuccess()
        {
            end();
            loggedIn = true;
            loginB.Content = "Logged in";
            loginB.IsEnabled = false;
            Settings.SetValue<string>("phone", phoneTB.Text);
            Settings.SetValue<string>("countrycode", countryCodeCB.Text);
            Success();
        }

        #endregion
    }
}
