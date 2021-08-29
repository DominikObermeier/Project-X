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

        public LoggingIn()
        {
            InitializeComponent();
        }

        public bool angemeldet = false;
        public bool getAnmeldeStatus()
        {
            return angemeldet;
        }
        public void setAnmeldeStatus(bool newAnmeldeStatus)
        {
            angemeldet = newAnmeldeStatus;
        }
        private void Click_LogIn(object sender, RoutedEventArgs e)
        {
            string line;
            int counter = 1;
            string cdirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
            StreamReader file = new StreamReader(cdirectory + @"\Data\Account_Data\Account_Data.txt");

            while ((line = file.ReadLine()) != null)
            {

                if (counter == 3)
                {
                    if (LogIn_EmailTextBox.Text == line)
                    {
                        goto EmailSucceeded;
                    }
                    else if (LogIn_EmailTextBox.Text == "" || LogIn_EmailTextBox.Text != line)
                    {
                        MessageBox.Show("Die Email Adresse wurde falsch eingegeben!");
                        return;
                    }
                }

                EmailSucceeded:
                if (counter == 4)
                {
                    if (LogIn_PasswordTextBox.Password == line)
                    {
                        setAnmeldeStatus(true);
                        MainMenu objMainMenu = new MainMenu();
                        this.Visibility = Visibility.Hidden; // Hides current window
                        objMainMenu.Show();
                    }

                    else if (LogIn_PasswordTextBox.Password == "" || LogIn_PasswordTextBox.Password != line)
                    {
                        MessageBox.Show("Das Passwort wurde falsch eingegeben!");
                        return;
                    }
                }
                counter++;
            }
            file.Close();
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
