using AnarisDLL.BLL;
using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ValuePie.xaml
    /// </summary>
    public partial class ValuePie : Window
    {
        public ValuePie()
        {
            ValuePieViewModel viewModel = new ValuePieViewModel();
            viewModel.DrawPieChart = new ValuePieViewModel.RenderPieChart(RenderPieChart);
            DataContext = viewModel;
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
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)img_PieChart.ActualWidth * 2, (int)img_PieChart.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
            renderBitmap.Render(img_PieChart);

            // Create a file stream for saving image
            using (FileStream outStream = new FileStream(txt_ImagePath.Text, FileMode.Create))
            {
                // Use png encoder for our data
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                // push the rendered bitmap to it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                // save the data to the stream
                encoder.Save(outStream);
            }
        }

        public byte[] RenderPieChart()
        {
            img_PieChart.UpdateLayout();
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)img_PieChart.ActualWidth * 2, (int)img_PieChart.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);

            renderBitmap.Render(img_PieChart);
            byte[] bit = new byte[1];

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(stream);
                bit = stream.ToArray();
                stream.Close();
            }

            return bit;
        }
    }
}
