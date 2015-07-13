using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Drawing;
using XnaFan.ImageComparison;
namespace ImageComparisonWpfGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ImageComparisonWpfViewModel();
        }

        public ICommand AddImageCommand { set; get; }


        private void BtnOpenImage1_Click(object sender, RoutedEventArgs e)
        {

           
            BitmapImage img = GetImage();
            // Process open file dialog box results
            if (img != null)
            {
                // Open document
                ((ImageComparisonWpfViewModel)DataContext).AddImage1.Execute(img);
            }
        }

        BitmapImage GetImage()
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "Open Image"; // Default file name
            //dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Images |*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                return new BitmapImage(new Uri(dlg.FileName));
            }
            return null;
        }

        private void btnOpenImage2_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img = GetImage();
            // Process open file dialog box results
            if (img != null)
            {
                // Open document
                ((ImageComparisonWpfViewModel)DataContext).AddImage2.Execute(img);
            }
        }
        

        private void imgDifference_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            try
            {


                    
                    BitmapImage img = new BitmapImage(new Uri(textBox1.Text));
                    // Process open file dialog box results
                    if (img != null)
                    {
                        // Open document
                        ((ImageComparisonWpfViewModel)DataContext).AddImage1.Execute(img);
                    

                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
 
            }

        }

        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                    BitmapImage img = new BitmapImage(new Uri(textBox2.Text));
                    // Process open file dialog box results
                    if (img != null)
                    {
                        // Open document
                        ((ImageComparisonWpfViewModel)DataContext).AddImage2.Execute(img);
                    }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}
