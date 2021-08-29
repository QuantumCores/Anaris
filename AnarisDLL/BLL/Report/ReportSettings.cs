using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AnarisDLL.BLL.Report
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

            ImageBorderColor = new RColor();
            TableBorderColor = new RColor();
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

        public void Clone(ReportSettings toClone)
        {
            this.ChapterFont.Color.R = toClone.ChapterFont.Color.R;
            this.ChapterFont.Color.G = toClone.ChapterFont.Color.G;
            this.ChapterFont.Color.B = toClone.ChapterFont.Color.B;

            this.ChapterFont.Face = toClone.ChapterFont.Face;
            this.ChapterFont.Size = toClone.ChapterFont.Size;
            this.ChapterFont.Style = toClone.ChapterFont.Style;

            this.ChapterWord = toClone.ChapterWord;
            this.ImageBorderColor.R = toClone.ImageBorderColor.R;
            this.ImageBorderColor.G = toClone.ImageBorderColor.G;
            this.ImageBorderColor.B = toClone.ImageBorderColor.B;

            this.ImageBorderWidth = toClone.ImageBorderWidth;
            this.ImageCaptionWord = toClone.ImageCaptionWord;
            this.ImageMarginBottom = toClone.ImageMarginBottom;
            this.ImageMarginTop = toClone.ImageMarginTop;
            this.ImgPath = toClone.ImgPath;
            this.IsTwoSidePrint = toClone.IsTwoSidePrint;
            this.MarginBottom = toClone.MarginBottom;
            this.MarginRight = toClone.MarginRight;
            this.MarginsLeft = toClone.MarginsLeft;
            this.MarginTop = toClone.MarginTop;
            this.PageSize = toClone.PageSize;


            this.ReportDate = toClone.ReportDate;
            this.ReportPath = toClone.ReportPath;
            this.ReportTitle = toClone.ReportTitle;
            this.SectionWord = toClone.SectionWord;

            this.SubSectionWord = toClone.SubSectionWord;
            this.TableBorderColor.R = toClone.TableBorderColor.R;
            this.TableBorderColor.G = toClone.TableBorderColor.G;
            this.TableBorderColor.B = toClone.TableBorderColor.B;


            this.TableBorderWidth = toClone.TableBorderWidth;
            this.TableCaptionWord = toClone.TableCaptionWord;
            this.TableMarginBottom = toClone.TableMarginBottom;
            this.TableMarginTop = toClone.TableMarginTop;

            this.TitleFont.Color.R = toClone.TitleFont.Color.R;
            this.TitleFont.Color.G = toClone.TitleFont.Color.G;
            this.TitleFont.Color.B = toClone.TitleFont.Color.B;

            this.TitleFont.Face = toClone.TitleFont.Face;
            this.TitleFont.Size = toClone.TitleFont.Size;
            this.TitleFont.Style = toClone.TitleFont.Style;

            this.RegularFont.Color.R = toClone.RegularFont.Color.R;
            this.RegularFont.Color.G = toClone.RegularFont.Color.G;
            this.RegularFont.Color.B = toClone.RegularFont.Color.B;

            this.RegularFont.Face = toClone.RegularFont.Face;
            this.RegularFont.Size = toClone.RegularFont.Size;
            this.RegularFont.Style = toClone.RegularFont.Style;

            this.SectionFont.Color.R = toClone.SectionFont.Color.R;
            this.SectionFont.Color.G = toClone.SectionFont.Color.G;
            this.SectionFont.Color.B = toClone.SectionFont.Color.B;

            this.SectionFont.Face = toClone.SectionFont.Face;
            this.SectionFont.Size = toClone.SectionFont.Size;
            this.SectionFont.Style = toClone.SectionFont.Style;

            this.SubSectionFont.Color.R = toClone.SubSectionFont.Color.R;
            this.SubSectionFont.Color.G = toClone.SubSectionFont.Color.G;
            this.SubSectionFont.Color.B = toClone.SubSectionFont.Color.B;

            this.SubSectionFont.Face = toClone.SubSectionFont.Face;
            this.SubSectionFont.Size = toClone.SubSectionFont.Size;
            this.SubSectionFont.Style = toClone.SubSectionFont.Style;
        }


    }
}
