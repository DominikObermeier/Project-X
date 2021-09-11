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
    /// 
    public partial class Image_ofd : Window
    {
        public string image_name = "";
        public static string cdirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        public string path_profile_images = cdirectory + @"\Data\Profile_Images";
        public Image_ofd()
        {
            InitializeComponent();
        }

        private void Click_LoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Select Profile Image";
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                Uri image_path = new Uri(ofd.FileName);
                image_name = image_path.Segments.Last();
                ProfileImage_Image.Source = new BitmapImage(image_path);

                DirectoryInfo di = new DirectoryInfo(path_profile_images);
                FileInfo[] fi = di.GetFiles();

                foreach (FileInfo fiTemp in fi)
                {
                    if (!File.Exists(di + @"\" + image_name))
                    {
                        File.Copy(ofd.FileName, di + @"\" + image_name);
                        MessageBox.Show("Image has been downloaded successfully.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Image couldn't be downloaded!");
                        return;
                    }
                }
            }
        }

        private void Click_SaveImage(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Properties.Settings.Default.profileImage = path_profile_images + @"\" + image_name;
            Properties.Settings.Default.Save();
        }


        private void Click_DeleteImage(object sender, RoutedEventArgs e)
        {
            // C:\Users\Dominik\source\repos\Project-X\Project-X\Icon_Images\noimagefound.png
            // MessageBox.Show(cdirectory);
            Uri image_deletepath = new Uri(cdirectory + path_profile_images + @"\" + "noimagefound.png");
            ProfileImage_Image.Source = new BitmapImage(image_deletepath);

            if (image_name.Contains("noimagefound.png") == false)
            {
                File.Delete(path_profile_images + @"\" + image_name);
            }
        }
    }
}
