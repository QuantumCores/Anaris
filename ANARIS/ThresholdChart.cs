using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class ThresholdChart : Form, ANS_View
    {
        ANS_Controller _controller;
        int Margin_Top = 70;
        int Margin_Bottom = 30;
        int Margin_Left = 10;
        int Margin_Right = 10;
        int Horizontal_Space = 30;
        int Vertical_Space = 10;
        int MyWidth = 0;
        int MyHeight = 0;

        public ThresholdChart(List<string> BaseRisks)
        {
            InitializeComponent();
            dataCmb.Items.Add("Wszystko");
            dataCmb.Items.AddRange(BaseRisks.ToArray());
            dataCmb.SelectedIndex = 0;


            this.Size = new System.Drawing.Size(1050, 500);// 600;

            MyWidth = (int)((this.Size.Width - 15 - Margin_Left - Margin_Right - Vertical_Space) / 2.0);
            MyHeight = (int)((this.Size.Height - 15 - Margin_Top - Margin_Bottom - Horizontal_Space) / 2.0);
            actNowLst.Width = actLastLst.Width = reasNowLst.Width = reasLastLst.Width = MyWidth;
            actNowLst.Height = actLastLst.Height = reasNowLst.Height = reasLastLst.Height = MyHeight;

            //actNowLst.Columns[0].Width = actLastLst.Columns[0].Width = reasNowLst.Columns[0].Width = reasLastLst.Columns[0].Width = Width - actNowLst.Columns[1].Width - actNowLst.Columns[2].Width;
            actNowLst.Columns[0].Width = MyWidth - actNowLst.Columns[1].Width - actNowLst.Columns[2].Width;

            actNowLst.Location = new Point(Margin_Left, Margin_Top);
            actLastLst.Location = new Point(Margin_Left, Margin_Top + Horizontal_Space + MyHeight);
            reasNowLst.Location = new Point(Margin_Left + MyWidth + Vertical_Space, Margin_Top);
            reasLastLst.Location = new Point(Margin_Left + MyWidth + Vertical_Space, Margin_Top + Horizontal_Space + MyHeight);


        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        private void ThresholdChart_Resize(object sender, EventArgs e)
        {
            /*actLastLst.Location = new Point(actLastLst.Location.X, (int)(this.Height / 2.0));
            actNowLst.Height = (int)(-actNowLst.Location.Y + actLastLst.Location.Y - 30);
            actLastLst.Height = actNowLst.Height;
            actNowLst.Width = (int)( -actNowLst.Location.X + reasNowLst.Location.X - 15);*/

            MyWidth = (int)((this.Size.Width - 15 - Margin_Left - Margin_Right - Vertical_Space) / 2.0);
            MyHeight = (int)((this.Size.Height - 15 - Margin_Top - Margin_Bottom - Horizontal_Space) / 2.0);


            actNowLst.Location = new Point(Margin_Left, Margin_Top);
            actLastLst.Location = new Point(Margin_Left, Margin_Top + Horizontal_Space + MyHeight);
            reasNowLst.Location = new Point(Margin_Left + MyWidth + Vertical_Space, Margin_Top);
            reasLastLst.Location = new Point(Margin_Left + MyWidth + Vertical_Space, Margin_Top + Horizontal_Space + MyHeight);

            actNowLbl.Location = new Point(Margin_Left, Margin_Top - 15);
            actLastLbl.Location = new Point(Margin_Left, Margin_Top + Horizontal_Space + MyHeight - 15);
            reasNowLbl.Location = new Point(Margin_Left + MyWidth + Vertical_Space, Margin_Top - 15);
            reasLastLbl.Location = new Point(Margin_Left + MyWidth + Vertical_Space, Margin_Top + Horizontal_Space + MyHeight - 15);

            //Console.WriteLine("parent W: " + this.Size.Width + ", width: " + Width);

            actNowLst.Width = actLastLst.Width = reasNowLst.Width = reasLastLst.Width = MyWidth;
            actNowLst.Height = actLastLst.Height = reasNowLst.Height = reasLastLst.Height = MyHeight;

            actNowLst.Columns[0].Width = MyWidth - actNowLst.Columns[1].Width - actNowLst.Columns[2].Width;
            actLastLst.Columns[0].Width = MyWidth - actLastLst.Columns[1].Width - actLastLst.Columns[2].Width;
            reasNowLst.Columns[0].Width = MyWidth - reasNowLst.Columns[1].Width - reasNowLst.Columns[2].Width;
            reasLastLst.Columns[0].Width = MyWidth - reasLastLst.Columns[1].Width - reasLastLst.Columns[2].Width;

            button1.Location = new Point(this.Size.Width - 10 - button1.Size.Width - this.Margin_Right, 3);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.ShowHideThresholdChart();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            _controller.LoadThresholdChart(double.Parse(wrTxt.Text), double.Parse(uwrTxt.Text), dataCmb.SelectedIndex - 1, actNowLst, actLastLst, reasNowLst, reasLastLst);

        }
    }
}
