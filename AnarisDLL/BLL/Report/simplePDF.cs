using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using AnarisDLL.BLL.Helpers;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Value;

namespace AnarisDLL.BLL.Report
{
    public class simplePDF
    {
        public Paragraph p = new Paragraph();
        public Phrase f = new Phrase();

        public void addCell(PdfPTable tab, Phrase f, int align, int colspan, int padding)
        {
            PdfPCell cell = new PdfPCell(f);
            cell.HorizontalAlignment = align;
            cell.Colspan = colspan;
            cell.PaddingTop = padding;
            cell.Border = 0;
            tab.AddCell(cell);
        }

        public void AddText(Font Font, string text)
        {
            if (f == null)
            {
                f = new Phrase();
            }
            Chunk c = new Chunk(text, Font);
            f.Add(c);
        }

        public void AddContentToDocument(Document tmpdoc)
        {
            if (p != null)
            {
                if (f != null)
                {
                    p.Add(f);
                    f = new Phrase();
                }
                tmpdoc.Add(p);
                p = new Paragraph();
            }
            else
            {
                if (f != null)
                {
                    tmpdoc.Add(f);
                    f = new Phrase();
                    p = new Paragraph();
                }

            }
        }

        public void AddVerticalSpace(int stop)
        {
            for (int i = 0; i < stop; i++)
            {
                f.Add(new Chunk("\n\r", F("Times")));
            }
        }

        public Font F(string Name)
        {
            BaseFont bf;
            Font font = new Font();

            switch (Name)
            {
                case "Times":
                    bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, false);
                    font = new iTextSharp.text.Font(bf, 12, 0, new BaseColor(12, 12, 12));
                    break;
                case "Helvetica":
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, false);
                    font = new iTextSharp.text.Font(bf, 12, 0, new BaseColor(12, 12, 12));
                    break;
                case "Courier":
                    bf = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
                    font = new iTextSharp.text.Font(bf, 12, 0, new BaseColor(12, 12, 12));
                    break;
            }

            return font;
            //iTextSharp.text.Font chap_title = new iTextSharp.text.Font(bfTimes, 16, Font.BOLD, new BaseColor(12, 12, 12));
        }
    }
}
