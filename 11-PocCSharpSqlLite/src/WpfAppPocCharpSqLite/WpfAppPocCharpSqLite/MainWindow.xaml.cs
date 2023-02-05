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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Docnet.Core.Converters;
using Docnet.Core.Models;
using System.Drawing;
using System.Drawing.Imaging;

using Docnet.Core;
using System.IO;
using System.Runtime.InteropServices;

namespace WpfAppPocCharpSqLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImageToShow.Source = new BitmapImage(new Uri(@"D:\Temp\DentsdeMidi5.png"));
            //ImageToShow.Source = new BitmapImage(new Uri(@"DentsdeMidi5.png", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "d:\\users";
            dlg.Filter = "Image files (*.png)|*.png|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                ImageToShow.Source = bitmap;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "e:\\";
                dlg.Filter = "Image files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == true)
                {
                    string selectedFileName = dlg.FileName;
                    var docReader = DocLib.Instance.GetDocReader(
                       selectedFileName,
                       new PageDimensions(1080 / 4, 1920 / 4));
                    var pageReader = docReader.GetPageReader(0);

                    var rawBytes = pageReader.GetImage();

                    int width = pageReader.GetPageWidth();
                    int height = pageReader.GetPageHeight();
                    Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    AddBytes(bmp, rawBytes);

                    var stream = new MemoryStream();

                    bmp.Save(stream, ImageFormat.Png);

                    File.WriteAllBytes("D:\\Temp\\output_image_4.png", stream.ToArray());

                    //Bitmap bmp;
                    //using (MemoryStream ms = new MemoryStream(rawBytes))
                    //{
                    //    bmp = new Bitmap(ms);
                    //}
                    var bitmapImage = new BitmapImage();
                    //using (MemoryStream memory = new MemoryStream())
                    //{
                    //    bmp.Save(memory, ImageFormat.Png);
                    //    memory.Position = 0;


                    //    bitmapImage.BeginInit();
                    //    bitmapImage.StreamSource = memory;
                    //    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    //    bitmapImage.EndInit();
                    //    bitmapImage.Freeze();

                    //}

                    //                   using (System.IO.MemoryStream ms = new System.IO.MemoryStream(rawBytes))
                    //                   {
                    ////                       BitmapImage image = new BitmapImage();
                    //                       bitmapImage.BeginInit();
                    //                       bitmapImage.CacheOption= BitmapCacheOption.OnLoad;
                    //                       bitmapImage.StreamSource = ms;
                    //                       bitmapImage.EndInit();
                    //                   }
                    //                   //                       BitmapImage bitmap = new BitmapImage(bmp); ;
                    //                   //                   bitmap.BeginInit();
                    //                   //                   bitmap.UriSource = new Uri(selectedFileName);
                    //                   //                   bitmap.EndInit();
                    //                   ImageToShow.Source = bitmapImage;

                    //ImageToShow.Source = new BitmapImage(new Uri(@"D:\ccp_wrks\Poc\11-PocCSharpSqlLite\src\WpfAppPocCharpSqLite\Deploy\output_image_4.png"));
                    ImageToShow.Source = new BitmapImage(new Uri(@"D:\Temp\output_image_4.png"));
                }

            }
        }
        private static void AddBytes(Bitmap bmp, byte[] rawBytes)
        {
            var rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);

            var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
            var pNative = bmpData.Scan0;

            Marshal.Copy(rawBytes, 0, pNative, rawBytes.Length);
            bmp.UnlockBits(bmpData);
        }

    }
}
