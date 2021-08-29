using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Report
{
    public static class ReportFonts
    {
        public static Font Title;
        public static Font ChapterTitle;
        public static Font SectionTitle;
        public static Font SubSectionTitle;
        public static Font Regular;
        public static Font RegularBold;


        public static void LoadFonts(ReportSettings rs)
        {
            
            BaseFont bft = BaseFont.CreateFont(GetFontName(rs.TitleFont), BaseFont.CP1257, false);
            rs.TitleFont.Size = (rs.TitleFont.Size == 0) ? 12 : rs.TitleFont.Size;
            Title = new Font(bft, rs.TitleFont.Size, rs.TitleFont.Style, new BaseColor(rs.TitleFont.Color.R, rs.TitleFont.Color.G, rs.TitleFont.Color.B));

            BaseFont bfc = BaseFont.CreateFont(GetFontName(rs.ChapterFont), BaseFont.CP1257, false);
            rs.ChapterFont.Size = (rs.ChapterFont.Size == 0) ? 12 : rs.ChapterFont.Size;
            ChapterTitle = new Font(bfc, rs.ChapterFont.Size, rs.ChapterFont.Style, new BaseColor(rs.ChapterFont.Color.R, rs.ChapterFont.Color.G, rs.ChapterFont.Color.B));

            BaseFont bfs = BaseFont.CreateFont(GetFontName(rs.SectionFont), BaseFont.CP1257, false);
            rs.SectionFont.Size = (rs.SectionFont.Size == 0) ? 12 : rs.SectionFont.Size;
            SectionTitle = new Font(bfs, rs.SectionFont.Size, rs.SectionFont.Style, new BaseColor(rs.SectionFont.Color.R, rs.SectionFont.Color.G, rs.SectionFont.Color.B));

            BaseFont bfss = BaseFont.CreateFont(GetFontName(rs.SubSectionFont), BaseFont.CP1257, false);
            rs.SubSectionFont.Size = (rs.SubSectionFont.Size == 0) ? 12 : rs.SubSectionFont.Size;
            SubSectionTitle = new Font(bfss, rs.SubSectionFont.Size, rs.SubSectionFont.Style, new BaseColor(rs.SubSectionFont.Color.R, rs.SubSectionFont.Color.G, rs.SubSectionFont.Color.B));

            BaseFont bfr = BaseFont.CreateFont(GetFontName(rs.RegularFont), BaseFont.CP1257, false);
            rs.RegularFont.Size = (rs.RegularFont.Size == 0) ? 12 : rs.RegularFont.Size;
            Regular = new Font(bfr, rs.RegularFont.Size, rs.RegularFont.Style, new BaseColor(rs.RegularFont.Color.R, rs.RegularFont.Color.G, rs.RegularFont.Color.B));

            RegularBold = new Font(bfr, rs.RegularFont.Size, Font.BOLD, new BaseColor(rs.RegularFont.Color.R, rs.RegularFont.Color.G, rs.RegularFont.Color.B));
        }

        private static string GetFontName(RFont font)
        {
            
            switch (font.Face)
            {
                case "Times":
                    return "Times-Roman";
                case "Courier":
                    return "Courier";
                case "Helvetica":
                    return "Helvetica";
                case "Symbol":
                    return "Symbol";
                default:
                    font.Face = "Times";
                    return "Times-Roman";
            }

        }
    }
}
