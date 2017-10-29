using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace WojtekApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] files = GetImages();
        public string nazwa = "";
        public Queue k = new Queue(3);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLosuj_Click(object sender, RoutedEventArgs e)
        {
            
            
            do nazwa = GetImage(); while ( k.Contains(nazwa));

            if (k.Count == 3)
            {
                k.Dequeue();
            }
            k.Enqueue(nazwa);

            var bit = new BitmapImage(new Uri(nazwa));
            Image.Source = bit;
            Nazwa.Content = "";
        }

        private void BtnNazwa_Click(object sender, RoutedEventArgs e)
        {
            Nazwa.Content = Path.GetFileNameWithoutExtension(nazwa);
        }

        private static string[] GetImages()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowDialog();
                var files = Directory.GetFiles(fbd.SelectedPath, "*.*");
                if (files != null)
                {
                    fbd.Dispose();
                }             
                return files;
            }
        }


        private static string GetImage()
        {
            var rand = new Random();
            var file = files[rand.Next(files.Length)];
            return file;
        }

        
    }
}