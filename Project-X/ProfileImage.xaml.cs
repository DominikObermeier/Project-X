﻿using System;
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

        public string image_name = "noimagefound.png";
        string cdirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        public Image_ofd()
        {
            InitializeComponent();
        }

        private void Click_LoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Select Image To Show";
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                Uri image_path = new Uri(ofd.FileName);
                string fileName_image = image_path.Segments.Last();
                ProfileImage_Image.Source = new BitmapImage(image_path);
                image_name = fileName_image;

                DirectoryInfo di = new DirectoryInfo(cdirectory + @"\Data\Profile_Images");
                FileInfo[] fi = di.GetFiles();

                foreach (FileInfo fiTemp in fi)
                {
                    if (!File.Exists(di + @"\" + fileName_image))
                    {
                        File.Copy(ofd.FileName, di + @"\" + fileName_image);
                        MessageBox.Show("Bild wurde erfolgreich heruntergeladen.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Dieses Bild wurde bereits heruntergeladen!");
                        return;
                    }
                }
            }
        }

        private void Click_SaveImage(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            File.WriteAllText(cdirectory + @"\Data\Account_Data\Account_Data.txt", String.Empty);
            File.AppendAllText(cdirectory + @"\Data\Account_Data\Account_Data.txt", cdirectory + @"\Data\Profile_Images\" + image_name + Environment.NewLine);
        }


        private void Click_DeleteImage(object sender, RoutedEventArgs e)
        {
            // C:\Users\Dominik\source\repos\Project-X\Project-X\Icon_Images\noimagefound.png
            string cdirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
            // MessageBox.Show(cdirectory);
            Uri image_deletepath = new Uri(cdirectory + @"\Data\Profile_Images\noimagefound.png");
            ProfileImage_Image.Source = new BitmapImage(image_deletepath);

            if (image_name.Contains("noimagefound.png") == false)
            {
                File.Delete(cdirectory + @"\Data\Profile_Images\" + image_name);
            }
        }
    }
}
