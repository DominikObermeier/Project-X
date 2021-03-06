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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        bool designModeSaved = true;
        bool passwordSaved = true;
        bool emailSaved = true;
        bool usernameSaved = true;
        private System.Threading.Timer timer;
        SolidColorBrush colorBackground;
        SolidColorBrush colorText;
        SolidColorBrush colorBackground2ndLayer;
        bool pwEyeEnabled = false;

        public static string cdirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        public string path_window_icons = cdirectory + @"\Data\Window_Icons";
        public string path_profile_images = cdirectory + @"\Data\Profile_Images";
        public Settings()
        {
            InitializeComponent();
            Properties.Settings.Default.profileImageSetStatus = false;
            Properties.Settings.Default.Save();
            timer = new System.Threading.Timer(OnTimerEllapsed, new object(), 0, 100);
        }

        private void OnTimerEllapsed(object state)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                if (SettingsWindow.Visibility == Visibility.Visible)
                {
                    try
                    {
                        this.Dispatcher.Invoke(new Action(RefreshContent));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }

            }
        }
        private void RefreshContent()
        {
            this.Settings_ProfileImage.Source = new BitmapImage(new Uri(Properties.Settings.Default.profileImage));
            this.Settings_Label_ShowUsername.Text = Properties.Settings.Default.username;
            this.Settings_Label_ShowEmail.Text = Properties.Settings.Default.email;
        }

        private void SettingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!designModeSaved || !usernameSaved || !emailSaved || !passwordSaved)
            {
                string msg = "Settings haven't been saved yet. Close without saving?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Settings alert",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) ;

                if (result == MessageBoxResult.No)
                {
                    // If user doesn't want to close, cancel closure
                    e.Cancel = true;
                }
            }
        }

        private void Settings_QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Design_Default_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.designMode = "Default";
            Properties.Settings.Default.Save();
        }
        private void Design_DarkMode_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.designMode = "DarkMode";
            Properties.Settings.Default.Save();
        }

        private void Settings_SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save Design Settings
            if (Properties.Settings.Default.designMode == "Default")
            {
                colorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE5E5E5"));

                Application.Current.Resources["BackgroundColor"] = colorBackground;

                colorBackground2ndLayer = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCECECE"));

                Application.Current.Resources["Background2ndLayerColor"] = colorBackground2ndLayer;

            colorText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));

                Application.Current.Resources["ForegroundColor"] = colorText;

            }
            else if (Properties.Settings.Default.designMode == "DarkMode")
            {
                colorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF212121"));

                Application.Current.Resources["BackgroundColor"] = colorBackground;

                colorBackground2ndLayer = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF373737"));

                Application.Current.Resources["Background2ndLayerColor"] = colorBackground2ndLayer;

                colorText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));

                Application.Current.Resources["ForegroundColor"] = colorText;
            }

            designModeSaved = true;
        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Detect Design Mode
                if (Application.Current.Resources["BackgroundColor"].ToString() == "#FFE5E5E5")
                {
                    Design_Default_RadioButton.IsChecked = true;
                }
                else if (Application.Current.Resources["BackgroundColor"].ToString() == "#FF212121")
                {
                    Design_DarkMode_RadioButton.IsChecked = true;
                }

                // Load profile data
                Settings_Label_ShowUsername.Text = Properties.Settings.Default.username;
                Settings_Label_ShowEmail.Text = Properties.Settings.Default.email;
                Settings_PBox_ShowPassword.Password = Properties.Settings.Default.password;
                Settings_Label_ShowPassword.Text = Properties.Settings.Default.password;

                Uri image_path = new Uri(Properties.Settings.Default.profileImage);
                Settings_ProfileImage.Source = new BitmapImage(image_path);
            }catch(Exception esss)
            {
                MessageBox.Show(esss.Message);
            }
        }

        private void Settings_EditImage_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.profileImageSetStatus == false) {
                ProfileImageSettings profileImageSettings = new ProfileImageSettings();
                profileImageSettings.Show();
            }
        }

        private void Settings_EyeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!pwEyeEnabled) 
            {
                Settings_PBox_ShowPassword.Visibility = Visibility.Hidden;
                Settings_Label_ShowPassword.Visibility = Visibility.Visible;
                Uri eyeImage_path = new Uri(path_window_icons + @"\3325118_eye_off_icon.png");
                Settings_EyeButton_Image.Source = new BitmapImage(eyeImage_path);
                pwEyeEnabled = true;
            }else if (pwEyeEnabled)
            {
                Settings_PBox_ShowPassword.Visibility = Visibility.Visible;
                Settings_Label_ShowPassword.Visibility = Visibility.Hidden;
                Uri eyeImage_path = new Uri(path_window_icons + @"\226579_eye_icon.png");
                Settings_EyeButton_Image.Source = new BitmapImage(eyeImage_path);
                pwEyeEnabled = false;
            }
        }

        private void SettingsWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.settingsWindowStatus = false;
            Properties.Settings.Default.Save();
        }

        private void Settings_Profile_ChangeEmailButton_Click(object sender, RoutedEventArgs e)
        {
            Settings_TBox_Email.Text = Properties.Settings.Default.email;
            Settings_Label_ShowEmail.Visibility = Visibility.Hidden;
            Settings_TBox_Email.Visibility = Visibility.Visible;
            Settings_Profile_ChangeEmailButton.Visibility = Visibility.Hidden;
            Settings_Profile_SaveEmailButton.Visibility = Visibility.Visible;
            emailSaved = false;
        }

        private void Settings_Profile_ChangeUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            Settings_TBox_Username.Text = Properties.Settings.Default.username;
            Settings_Label_ShowUsername.Visibility = Visibility.Hidden;
            Settings_TBox_Username.Visibility = Visibility.Visible;
            Settings_Profile_ChangeUsernameButton.Visibility = Visibility.Hidden;
            Settings_Profile_SaveUsernameButton.Visibility = Visibility.Visible;
            usernameSaved = false;
        }

        private void Settings_Profile_ChangePWButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Settings_Profile_SaveEmail_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.email = Settings_TBox_Email.Text;
            Properties.Settings.Default.Save();
            Settings_Label_ShowEmail.Visibility = Visibility.Visible;
            Settings_TBox_Email.Visibility = Visibility.Hidden;
            Settings_Profile_ChangeEmailButton.Visibility = Visibility.Visible;
            Settings_Profile_SaveEmailButton.Visibility = Visibility.Hidden;
            emailSaved = true;
        }

        private void Settings_Profile_SaveUsername_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.username = Settings_TBox_Username.Text;
            Properties.Settings.Default.Save();
            Settings_Label_ShowUsername.Visibility = Visibility.Visible;
            Settings_TBox_Username.Visibility = Visibility.Hidden;
            Settings_Profile_ChangeUsernameButton.Visibility = Visibility.Visible;
            Settings_Profile_SaveUsernameButton.Visibility = Visibility.Hidden;
            usernameSaved = true;
        }

        private void Settings_Profile_SavePWButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
