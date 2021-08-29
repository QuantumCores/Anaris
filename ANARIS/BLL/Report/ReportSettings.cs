using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ANARIS.BLL.Report
{
    [Serializable]
    public class ReportSettings
    {

        public ReportSettings()
        {
            TitleFont = new RFont();
            ChapterFont = new RFont();
            SectionFont = new RFont();
            SubSectionFont = new RFont();
            RegularFont = new RFont();
        }

        //geSubSectionFontnral setings
        public string ReportTitle { get; set; }
        public string ReportPath { get; set; }
        public string ImgPath { get; set; }
        public DateTime ReportDate { get; set; }


        //pageSettings
        public string PageSize { get; set; }
        public float MarginsLeft { get; set; }
        public float MarginTop { get; set; }
        public float MarginRight { get; set; }
        public float MarginBottom { get; set; }
        public int IsTwoSidePrint { get; set; }

        //Fonts
        public RFont TitleFont { get; set; }
        public RFont ChapterFont { get; set; }
        public RFont SectionFont { get; set; }
        public RFont SubSectionFont { get; set; }
        public RFont RegularFont { get; set; }

        public string ChapterWord { get; set; }
        public string SectionWord { get; set; }
        public string SubSectionWord { get; set; }

        //Table settings
        public string TableCaptionWord { get; set; }
        public int TableMarginTop { get; set; }
        public int TableMarginBottom { get; set; }
        public int TableBorderWidth { get; set; }
        public RColor TableBorderColor { get; set; }

        //image
        public string ImageCaptionWord { get; set; }
        public int ImageMarginTop { get; set; }
        public int ImageMarginBottom { get; set; }
        public int ImageBorderWidth { get; set; }
        public RColor ImageBorderColor { get; set; }
        

        public void SetFont(Font f, RFont rf)
        {
            rf.Size = f.Size;
            rf.Face = f.Familyname;
            rf.Color.R = f.Color.R;
            rf.Color.G = f.Color.G;
            rf.Color.B = f.Color.B;
            rf.Style = f.Style;
        }




    }
}
