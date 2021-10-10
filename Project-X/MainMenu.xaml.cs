using Microsoft.Win32;
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
    /// Interaktionslogik für MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            Properties.Settings.Default.settingsWindowStatus = false;
            Properties.Settings.Default.regWindowStatus = false;
            Properties.Settings.Default.mainMenuStatus = true;
            Properties.Settings.Default.Save();
        }
        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void File_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Select Profile Image";
            ofd.ShowDialog();
        }

        private void Extras_Settings_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.settingsWindowStatus == false) {
                Settings settingsWindow = new Settings();
                settingsWindow.Show();
                Properties.Settings.Default.settingsWindowStatus = true;
                Properties.Settings.Default.Save();
            }
        }
    }
}
