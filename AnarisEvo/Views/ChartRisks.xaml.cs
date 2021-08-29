using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnarisEvo.Views
{
    /// <summary>
    /// Interaction logic for ChartRisks.xaml
    /// </summary>
    public partial class ChartRisks : Window
    {
        public ChartRisks()
        {
            ChartRisksViewModel context = new ChartRisksViewModel();
            context.DiplayImageAction = new Action<int, int>(DisplayImage);
            context.GetImageSize = new Func<KeyValuePair<int, int>>(GetImageSize);
            DataContext = context;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog())
            {
                dialog.InitialDirectory = "C:";
                dialog.Title = "Zapisz obraz jako";
                dialog.FileName = "";
                dialog.Filter = "Bitmap Pliki|*.bmp| Wszystkie Pliki|*.*";

                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    txt_ImagePath.Text = dialog.FileName;
                    //txt_ImagePath.Text = @"C:\Users\Primus\Desktop\Anaris\testzapisu.bmp";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)img_PieChart.ActualWidth * 2, (int)img_PieChart.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
            //renderBitmap.Render(img_PieChart);

            //// Create a file stream for saving image
            //using (FileStream outStream = new FileStream(txt_ImagePath.Text, FileMode.Create))
            //{
            //    // Use png encoder for our data
            //    PngBitmapEncoder encoder = new PngBitmapEncoder();
            //    // push the rendered bitmap to it
            //    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            //    // save the data to the stream
            //    encoder.Save(outStream);
            //}
        }

        private void DisplayImage(int sort, int riskIndex)
        {
            int height = (int)MainGrid.ActualHeight;
            int width = (int)this.gridColImg.ActualWidth;

            byte[] imgArray = Services.Service.Instance.LoadTornadoChartImage(sort, riskIndex, width, height);

            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            Grid.SetRow(img, 0);
            Grid.SetRowSpan(img, 3);
            Grid.SetColumn(img, 1);

            //Bitmap img;
            using (MemoryStream str = new MemoryStream(imgArray))
            {
                img.Source = BitmapFrame.Create(str, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }

            MainGrid.Children.Add(img);

        }

        private KeyValuePair<int, int> GetImageSize()
        {
            var size = new KeyValuePair<int, int>((int)MainGrid.ActualHeight, (int)this.gridColImg.ActualWidth);
            return size;
        }
    }
}
