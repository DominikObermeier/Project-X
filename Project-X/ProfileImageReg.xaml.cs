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
            try
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
                        if (!File.Exists(path_profile_images + @"\" + image_name))
                        {
                            File.Copy(ofd.FileName, path_profile_images + @"\" + image_name);
                            MessageBox.Show("Image has been downloaded successfully.");
                            return;
                        }
                        else if (File.Exists(path_profile_images + @"\" + image_name))
                        {
                            MessageBox.Show("Image has already been downloaded!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong during download! Please try again.");
                            return;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
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
            Uri image_deletepath = new Uri(path_profile_images + @"\" + "noimagefound.png");
            ProfileImage_Image.Source = new BitmapImage(image_deletepath);

            if (image_name.Contains("noimagefound.png") == false)
            {
                File.Delete(path_profile_images + @"\" + image_name);
            }
        }

        private void ProfileImage_window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri image_path = new Uri(Properties.Settings.Default.profileImage);
                ProfileImage_Image.Source = new BitmapImage(image_path);
            }catch (Exception jdd)
            {
                MessageBox.Show(jdd.Message);
            }
        }
    }
}
