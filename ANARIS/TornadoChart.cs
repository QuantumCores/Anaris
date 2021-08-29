using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ANARIS
{
    public partial class TornadoChart : Form, ANS_View
    {
        private ANS_Controller _controller;

        public TornadoChart(List<string> BaseRisks)
        {
            InitializeComponent();
            dataCmb.Items.Add("Wszystko");
            dataCmb.Items.Add("Raport");

            dataCmb.Items.AddRange(BaseRisks.ToArray());
            dataCmb.SelectedIndex = 0;

            sortCmb.Items.Add("Całkowite ryzyko");
            sortCmb.Items.Add("Składowa A");
            sortCmb.Items.Add("Składowa B");
            sortCmb.Items.Add("Składowa C");
            sortCmb.SelectedIndex = 0;
            chart1.Titles.Clear();
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        public byte[] GenerateImageAsByteArray()
        {
            _controller.LoadTornadoChart(chart1, sortCmb.SelectedIndex, -1);

            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            _controller.LoadTornadoChart(chart1, sortCmb.SelectedIndex, dataCmb.SelectedIndex - 2);

        }

        private void copyImgBtn_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Bmp);
                Bitmap bm = new Bitmap(ms);
                Clipboard.SetImage(bm);
            }
        }

        private void TornadoChart_Resize(object sender, EventArgs e)
        {
            //Size nowy = new Size();

            chart1.Size = new Size(this.Width - dataGBox.Width - 5, chart1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.ShowHideTornadoChart();
        }
    }


}
