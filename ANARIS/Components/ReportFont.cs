using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANARIS.BLL.Report;
using System.Drawing.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ANARIS.Components
{
    public partial class ReportFont : UserControl
    {
        [Description("Text value of the control"), Category("Data")]
        private string _MainText {get;set;}
        
        public string MainText
        {
            get
            {
                return this._MainText;
            }
            set
            {
                _MainText = value;
                this.lbl_FontFor.Text = _MainText;
            }
        }

        public ReportFont()
        {
            InitializeComponent();

            //InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            //FontFamily[] fontFamilies = installedFontCollection.Families;
            //string[] fontNames = installedFontCollection.Families.Select(ff => ff.Name).ToArray();
            string[] fontNames = FontFactory.RegisteredFonts.ToArray();

            cmbFontFace.Items.AddRange(new string[] { "Times New  Roman", "Courier", "Helvetica", "Symbol" });
        }


        public Font Save()
        {
            int style = 0;
            if (cbBold.Checked && cbItalic.Checked)
            {
                style = 3;
            }
            else if (cbBold.Checked)
            {
                style = 1;
            }
            else if (cbItalic.Checked)
            {
                style = 2;
            }

            BaseFont bf = BaseFont.CreateFont(GetFontName(cmbFontFace.SelectedIndex), BaseFont.CP1257, false);
            return new Font(bf, (int)nudSize.Value, style, new BaseColor((int)nud_R.Value, (int)nud_G.Value, (int)nud_B.Value));

        }

        private string GetFontName(int SelectedItem)
        {
            switch (SelectedItem)
            {
                case 0:
                    return "Times-Roman";
                case 1:
                    return "Courier";
                case 2:
                    return "Helvetica";
                case 3:
                    return "Symbol";
                default:
                    return "Times-Roman";
            }

        }

        public void LoadFont(RFont rf)
        {
            cmbFontFace.SelectedIndex = GetFontIndex(rf.Face);
            nudSize.Value = (decimal)rf.Size;
            nud_R.Value = rf.Color.R;
            nud_G.Value = rf.Color.G;
            nud_B.Value = rf.Color.B;
            cbBold.Checked = (rf.Style == 1 || rf.Style == 3) ? true: false;
            cbItalic.Checked = (rf.Style == 2 || rf.Style == 3) ? true : false;
        }

        private int GetFontIndex(string name)
        {
            int i = 0;
            foreach (string item in cmbFontFace.Items)
            {
                if (item.ToString().Contains(name))
                {
                    return i;
                }
                i++;
            }

            return i;
        }


    }
}
