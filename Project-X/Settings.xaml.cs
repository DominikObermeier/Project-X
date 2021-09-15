using System;
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
        bool saved = false;

        SolidColorBrush colorBackground;
        SolidColorBrush colorText;
        SolidColorBrush colorBackground2ndLayer;
        bool image_ofd_window_status = false;
        public Settings()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (saved == false)
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

            saved = true;
        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
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
            Settings_Textbox_Username.Text = Properties.Settings.Default.username;
            Settings_Textbox_Email.Text = Properties.Settings.Default.email;
            Uri image_path = new Uri(Properties.Settings.Default.profileImage);
            Settings_ProfileImage.Source = new BitmapImage(image_path);
        }

        private void Settings_EditImage_Button_Click(object sender, RoutedEventArgs e)
        {
            if (image_ofd_window_status == false) {
                Image_ofd image_Ofd = new Image_ofd();
                image_Ofd.Show();
                image_ofd_window_status = true;
            }
        }
    }
}
