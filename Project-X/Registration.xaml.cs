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
            LoggingIn objAnmelden = new LoggingIn();
            this.Visibility = Visibility.Hidden; // Hides current window
            objAnmelden.Show();
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
