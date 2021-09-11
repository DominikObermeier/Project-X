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
using System.Security;
using System.Security.Cryptography;

namespace Project_X
{
    /// <summary>
    /// Interaktionslogik für Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
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

            if (Reg_PasswordRepTextBox.Text == Reg_PasswordInputTextBox.Text && Reg_PasswordInputTextBox.Text != "" && Reg_PasswordInputTextBox.Text.Length >= 8)
            {
                Properties.Settings.Default.username = Reg_UserNameTextBox.Text;
                Properties.Settings.Default.email = Reg_EmailTextBox.Text;
                Properties.Settings.Default.password = Reg_PasswordInputTextBox.Text;
                Properties.Settings.Default.Save();

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
