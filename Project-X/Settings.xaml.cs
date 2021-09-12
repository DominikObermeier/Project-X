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
        bool designDefault = false;
        bool designDarkMode = false;


        SolidColorBrush colorBackground;
        SolidColorBrush colorText;
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
                    "Data App",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    // If user doesn't want to close, cancel closure
                    e.Cancel = true;
                }
            }
        }

        private void Design_Default_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            designDefault = true;
        }

        private void Design_Default_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            designDefault = false;
        }
        private void Design_DarkMode_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            designDarkMode = true;
        }
        private void Design_DarkMode_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            designDarkMode = false;
        }

        private void Settings_SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save Design Settings
            if (designDefault == true)
            {
                colorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E5E5E5"));

                Application.Current.Resources["BackgroundColor"] = colorBackground;

                colorText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

                Application.Current.Resources["ForegroundColor"] = colorText;
            } else if (designDarkMode == true)
            {
                colorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF212121"));

                Application.Current.Resources["BackgroundColor"] = colorBackground;

                colorText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));

                Application.Current.Resources["ForegroundColor"] = colorText;
            }

            saved = true;
        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["BackgroundColor"].ToString() == "#E5E5E5")
            {
                designDefault = true;
            }else if (Application.Current.Resources["BackgroundColor"].ToString() == "#FF212121")
            {
                designDarkMode = true;
            }
            if (designDarkMode == true)
            {
                Design_DarkMode_RadioButton.IsChecked = true;
            }else if (designDefault == true)
            {
                Design_Default_RadioButton.IsChecked = true;
            }
        }
    }
}
