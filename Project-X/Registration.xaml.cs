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
using System.Windows.Shapes;

namespace Project_X
{
    /// <summary>
    /// Interaktionslogik für Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        string userName;
        string email;
        string password;

        public Registration()
        {
            InitializeComponent();
        }

        private void Click_Abbrechen(object sender, RoutedEventArgs e)
        {
            LoggingIn objAnmelden = new LoggingIn();
            this.Visibility = Visibility.Hidden; // Hides current window
            objAnmelden.Show();
        }

        private void Click_Register(object sender, RoutedEventArgs e)
        {

            if (Reg_PasswordRepTextBox.Text == Reg_PasswordInputTextBox.Text && Reg_PasswordInputTextBox.Text != "")
            {
                userName = Reg_UserNameTextBox.Text;
                email = Reg_EmailTextBox.Text;
                password = Reg_PasswordRepTextBox.Text;

                //using (File = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Data\Account_Data\Account_Data.txt"))
                string cpath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString()).ToString()).ToString();
                if (File.ReadAllText(cpath + @"\Data\Account_Data\Account_Data.txt") == "") 
                {
                    File.WriteAllText(cpath + @"\Data\Account_Data\Account_Data.txt", "");
                }
                File.AppendAllText(cpath + @"\Data\Account_Data\Account_Data.txt", userName + Environment.NewLine);
                File.AppendAllText(cpath + @"\Data\Account_Data\Account_Data.txt", email + Environment.NewLine);
                File.AppendAllText(cpath + @"\Data\Account_Data\Account_Data.txt", password + Environment.NewLine);

                LoggingIn objAnmelden = new LoggingIn();
                this.Visibility = Visibility.Hidden; // Hides current window
                objAnmelden.Show();
            }
            else if (Reg_UserNameTextBox.Text == "")
            {
                MessageBox.Show("Bitte gebe einen Benutzernamen ein!");
            }
            else if (Reg_EmailTextBox.Text == "")
            {
                MessageBox.Show("Bitte gebe deine Email-Adresse ein!");
            }
            else if (Reg_PasswordInputTextBox.Text == "")
            {
                MessageBox.Show("Bitte gebe ein Passwort ein!");
            }
            else if (Reg_PasswordInputTextBox.Text.Length < 8)
            {
                MessageBox.Show("Das Passwort muss mindestens aus 8 Zeichen bestehen!");
            }
            else if (Reg_PasswordRepTextBox.Text != Reg_PasswordInputTextBox.Text)
            {
                MessageBox.Show("Die Passwörter stimmen nicht überein!");
            }
        }

        private void Registration1_Unloaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Click_ProfileImage(object sender, RoutedEventArgs e)
        {
            Image_ofd image_ofd = new Image_ofd();
            image_ofd.Show();
        }
    }
}
