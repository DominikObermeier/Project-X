using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_X
{
    /// <summary>
    /// Interaktionslogik für LoggingIn.xaml
    /// </summary>
    /// 
    public partial class LoggingIn : Window
    {
        SolidColorBrush colorBackground;
        SolidColorBrush colorText;
        public LoggingIn()
        {
            InitializeComponent();

            // Load Design
            if (Properties.Settings.Default.designMode == "Default")
            {
                colorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE5E5E5"));

                Application.Current.Resources["BackgroundColor"] = colorBackground;

                colorText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));

                Application.Current.Resources["ForegroundColor"] = colorText;
            }
            else if (Properties.Settings.Default.designMode == "DarkMode")
            {
                colorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF212121"));

                Application.Current.Resources["BackgroundColor"] = colorBackground;

                colorText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));

                Application.Current.Resources["ForegroundColor"] = colorText;
            }
        }

        public bool loggedIn = false;
        public bool getLogInStatus()
        {
            return loggedIn;
        }
        public void setLogInStatus(bool newLogInStatus)
        {
            loggedIn = newLogInStatus;
        }
        private void Click_LogIn(object sender, RoutedEventArgs e)
        {
            // read from settings.default

            if (LogIn_EmailTextBox.Text == Properties.Settings.Default.email)
            {
                goto EmailSucceeded;
            }
            else if (LogIn_EmailTextBox.Text == "" || LogIn_EmailTextBox.Text != Properties.Settings.Default.email)
            {
                MessageBox.Show("The email address is wrong!");
                return;
            }

        EmailSucceeded:

            if (LogIn_PasswordTextBox.Password == Properties.Settings.Default.password)
            {
                setLogInStatus(true);
                MainMenu objMainMenu = new MainMenu();
                this.Visibility = Visibility.Hidden; // Hides current window
                objMainMenu.Show();
            }

            else if (LogIn_PasswordTextBox.Password == "" || LogIn_PasswordTextBox.Password != Properties.Settings.Default.password)
            {
                MessageBox.Show("The password is wrong!");
                return;
            }
        }
        private void Click_Register(object sender, RoutedEventArgs e)
        {
            Registration objRegistration = new Registration();
            this.Visibility = Visibility.Hidden; // Hides current window
            objRegistration.Show();
        }

        private void LoggingIn1_Unloaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
