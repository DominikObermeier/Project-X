using System;
using System.IO;
using Microsoft.Win32;
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
    /// Interaction logic for Image_ofd.xaml
    /// </summary>
    public partial class Image_ofd : Window
    {
        public Image_ofd()
        {
            InitializeComponent();
        }

        private void Click_LoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.Title = "Select Image To Show";
            Uri image_path = new Uri(ofd.FileName);
            ProfileImage_Image.Source = new BitmapImage(image_path);
        }

        private void Click_SaveImage(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }


        private void Click_DeleteImage(object sender, RoutedEventArgs e)
        {
            // C:\Users\Dominik\source\repos\Project-X\Project-X\Icon_Images\noimagefound.png
            string cdirectory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
            // MessageBox.Show(cdirectory);
            Uri image_deletepath = new Uri(cdirectory + @"\Icon_Images\noimagefound.png");
            ProfileImage_Image.Source = new BitmapImage(image_deletepath);
        }
    }
}
