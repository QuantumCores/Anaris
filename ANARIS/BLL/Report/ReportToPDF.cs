using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ANARIS.BLL.Helpers;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace ANARIS.BLL.Report
{
    public class ReportToPDF
    {



        public static void CreateReport(ProjectToSave save, ReportSettings _rs)
        {
            string path = @"ReportTest.xml";
            ARTemplate art = new ARTemplate(path);
            rs = _rs;

            XmlNode factorChapter = art.LoadTemplate_FactorChapter();

            XmlNode reportNode = art.ReportTemplate.GetElementsByTagName(ReportEnums.REPORT)[0];
            XmlNode reportFormatNode = art.ReportTemplate.GetElementsByTagName(ReportEnums.REPORTFORMAT)[0];
            XmlNodeList reportChapters = reportNode.ChildNodes;
            XmlNodeList reportChaptersTemplates = reportFormatNode.ChildNodes;


            List<XmlNode> childList = factorChapter.ChildNodesAsList();
            List<XmlNodeX> XmlNodes = XmlNodeX.NodesWithIndexes(factorChapter);

            ReportEnums enums = new ReportEnums();
            List<string> lst = enums.Variables;
            List<string> Variables = enums.Variables;
            List<string> Chapters = enums.Chapters;

            rs.ChapterWord = "Rozdział {0} - ";
            rs.ImgPath = @"IMG";
            rs.ImageCaptionWord = "Rycina:";

            //Preprocess the XMl  to find all chapters, subchapters and subsubchapter to insert them into table of context
            //if teo sided then title, table of context, and aknowledgeents are printed one per sheet and we can add attribute the node with text with number
            // so we  don't have to do it later :D


            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sample.pdf");

            doc = new Document(PageSize.A4);

            //Create a standard .Net FileStream for the file, setting various flags
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            //Create a new PDF document setting the size to A4
            //using (Document doc = new Document(PageSize.A4))                
            //Bind the PDF document to the FileStream using an iTextSharp PdfWriter
            using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
            {
                w.AddViewerPreference(PdfName.DUPLEX, PdfName.DUPLEXFLIPLONGEDGE); //nie wime czy to działa
                doc.Open();
                chapterCount = 0;

                foreach (XmlNode node in reportChapters)
                {
                    //string methodPath = ReportEnums.GetVariablePath(node.Name.ToUpper().Insert(0, "M_"));
                    string name = node.Name.Remove(0, 3);
                    XmlNode chapter = art.ReportTemplate.GetElementsByTagName(name)[0];
                    if (chapter.Name == ReportEnums.C_TITLEPAGE || chapter.Name == ReportEnums.C_TABLEOFCONTENT)
                    {
                        chapterNumber = false;
                    }
                    else
                    {
                        chapterCount++;
                        chapterNumber = true; //wstawiy settings.printchap;
                    }
                    Chapter chapteri = new Chapter();

                    Phrase p = new Phrase();
                    doc.Add(new Paragraph(5, "\u00a0"));
                    PrintChapterToPDFFile(save, doc, ReportToPDF.F("Times"), enums, chapter);
                    //add whats left
                    AddContentToDocument();
                    doc.NewPage();

                }

                doc.AddTitle("alleluje");
                doc.Close();
            }
            doc.Dispose();
        }

        private static ReportSettings rs;
        private static Document doc;
        private static bool isParagraph = false;
        private static Paragraph p = new Paragraph();
        private static Phrase f = new Phrase();
        private static int chapterCount = 0;
        private static int subChapterCount = 0;
        private static int subSubChapterCount = 0;
        private static bool chapterNumber = false;
        private static bool isUnderlined = false;
        private static bool isSubchapter = false;
        private static bool isSubSubchapter = false;

        private static int AutoTableLoopCount = 0;
        public static bool RowIsFinished = false;
        public static bool AutoHasStrated = false;
        //clearing p and f means that the formating is set to default?

        private static void PrintChapterToPDFFile(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode chapter)
        {

            foreach (XmlNode node in chapter.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Text)
                {
                    AddText(doc, Font, node.InnerText);
                }
                else if (node.NodeType == XmlNodeType.Element)
                {
                    //przerobić tutaj na typeOf invoke
                    if (enums.Regions.Contains(node.Name.ToUpper()))
                    {
                        if (node.Name == ReportEnums.X_P)
                        {
                            AddParagraph(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_CENTER)
                        {
                            AddCenteredContent(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_CHAPTERTITLE)
                        {
                            AddChapterTitle(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_SUBCHAPTERTITLE)
                        {
                            isSubchapter = true;
                            AddChapterTitle(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_SUBSUBCHAPTERTITLE)
                        {
                            isSubSubchapter = true;
                            AddChapterTitle(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_TITLE)
                        {
                            AddTitle(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_BR)
                        {
                            if (f == null)
                            {
                                f = new Phrase();
                            }
                            f.Add(new Chunk("\n\r"));
                        }
                        else if (node.Name == ReportEnums.X_SP)
                        {
                            if (f == null)
                            {
                                f = new Phrase();
                            }
                            f.Add(new Chunk(" "));
                        }
                        else if (node.Name == ReportEnums.X_VD)
                        {
                            AddVerticalSpace(node);
                        }
                        else if (node.Name == ReportEnums.X_B)
                        {
                            ChangeFontToBold(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_I)
                        {
                            ChangeFontToItalic(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_U)
                        {
                            isUnderlined = true;
                            PrintChapterToPDFFile(save, doc, Font, enums, node);
                            isUnderlined = false;
                        }
                        else if (node.Name == ReportEnums.X_IMG)
                        {
                            AddImage(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_TABLE)
                        {
                            AddTable(save, doc, Font, enums, node);
                        }
                        else if (node.Name == ReportEnums.X_PL)
                        {
                            AddPlainList(save, doc, Font, enums, node);
                        }
                    }
                    else if (enums.Variables.Contains(node.Name.ToUpper()))
                    {
                        AddText(doc, Font, node.InsertVariable(save));
                    }
                    else if (enums.Lists.Contains(node.Name.ToUpper()))
                    {
                        AutoHasStrated = true;
                        ((XmlElement)node).SetAttribute("arg", AutoTableLoopCount.ToString());
                        AddText(doc, Font, node.InsertListVariable(save));
                    }
                }

                //PrintChapterToPDFFile(doc, Fonts, enums, node, p);
            }

        }

        private static void AddText(Document doc, Font Font, string text)
        {
            if (f == null)
            {
                f = new Phrase();
            }
            if (isParagraph)
            {
                text = Regex.Replace(text, @"(\r|\n)", "");
            }

            Chunk c = new Chunk(text, Font);
            if (isUnderlined)
            {
                c.SetUnderline(0.5f, -1f);
            }
            f.Add(c);

        }

        /// <summary>
        /// Adds paragraph. It's a text block so it consumes and clears the p and f and previous formating, 
        /// </summary>
        /// <param name="save"></param>
        /// <param name="doc"></param>
        /// <param name="Font"></param>
        /// <param name="enums"></param>
        /// <param name="node"></param>
        private static void AddParagraph(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode node)
        {
            AddContentToDocument();
            isParagraph = true;
            p = new Paragraph(new Phrase("\n"));
            p.Alignment = Element.ALIGN_JUSTIFIED;
            f = new Phrase();

            PrintChapterToPDFFile(save, doc, Font, enums, node);

            p.Add(f);
            p.Add("\n");
            doc.Add(p);
            isParagraph = false;
            f = null;
            p = null;
        }

        /// <summary>
        /// Adds text as a chapter title. It's a text block so it consumes and clears the p and f and previous formating
        /// </summary>
        /// <param name="save"></param>
        /// <param name="doc"></param>
        /// <param name="Font"></param>
        /// <param name="enums"></param>
        /// <param name="node"></param>
        private static void AddChapterTitle(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode node)
        {
            if (f != null)
            {
                doc.Add(f);
            }
            isParagraph = true;
            p = new Paragraph(new Phrase("\n"));
            p.Alignment = Element.ALIGN_LEFT;
            Font titleFont = new Font();
            if (isSubSubchapter)
            {
                subSubChapterCount++;
                titleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 15, Font.BOLD, BaseColor.BLACK);
                string subsubchap = chapterCount + "." + subChapterCount + "." + subSubChapterCount + "  ";
                f = new Phrase(subsubchap, titleFont);
            }
            else if (isSubchapter)
            {
                subChapterCount++;
                titleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 18, Font.BOLD, BaseColor.BLACK);
                string subchap = chapterCount + "." + subChapterCount + "  ";
                f = new Phrase(subchap, titleFont);
            }
            else
            {
                titleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 21, Font.BOLD, BaseColor.BLACK);
                string chap = (chapterNumber) ? string.Format(rs.ChapterWord, chapterCount) : " ";
                f = new Phrase(chap, titleFont);
            }


            PrintChapterToPDFFile(save, doc, titleFont, enums, node);

            isSubSubchapter = false;
            isSubchapter = false;

            p.Add(f);
            p.Add("\n");
            doc.Add(p);
            isParagraph = false;
            f = null;
            p = null;
        }

        /// <summary>
        /// Adds text a sa title. It's not a text block.
        /// </summary>
        /// <param name="save"></param>
        /// <param name="doc"></param>
        /// <param name="Font"></param>
        /// <param name="enums"></param>
        /// <param name="node"></param>
        private static void AddTitle(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode node)
        {
            Font titleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22, Font.BOLD, BaseColor.BLACK);
            PrintChapterToPDFFile(save, doc, titleFont, enums, node);
        }


        private static void ChangeFontToBold(ProjectToSave save, Document doc, Font font, ReportEnums enums, XmlNode node)
        {
            Font boldFont = new Font();
            if (font.IsItalic())
            {
                boldFont = FontFactory.GetFont(font.BaseFont.PostscriptFontName, BaseFont.CP1257, font.Size, Font.BOLDITALIC, font.Color);
            }
            else
            {
                boldFont = FontFactory.GetFont(font.BaseFont.PostscriptFontName, BaseFont.CP1257, font.Size, Font.BOLD, font.Color);
            }

            PrintChapterToPDFFile(save, doc, boldFont, enums, node);
        }

        private static void ChangeFontToItalic(ProjectToSave save, Document doc, Font font, ReportEnums enums, XmlNode node)
        {
            Font italicFont = new Font();
            if (font.IsBold())
            {
                italicFont = FontFactory.GetFont(font.BaseFont.PostscriptFontName, BaseFont.CP1257, font.Size, Font.BOLDITALIC, font.Color);
            }
            else
            {
                italicFont = FontFactory.GetFont(font.BaseFont.PostscriptFontName, BaseFont.CP1257, font.Size, Font.ITALIC, font.Color);
            }

            PrintChapterToPDFFile(save, doc, italicFont, enums, node);
        }



        /// <summary>
        /// Adds centered conetent. It's a text block so it consumes and clears the p and f and previous formating
        /// </summary>
        /// <param name="save"></param>
        /// <param name="doc"></param>
        /// <param name="Font"></param>
        /// <param name="enums"></param>
        /// <param name="node"></param>
        private static void AddCenteredContent(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode node)
        {
            AddContentToDocument();
            if (!isParagraph)
            {
                p.Alignment = Element.ALIGN_CENTER;
            }
            PrintChapterToPDFFile(save, doc, Font, enums, node);
            AddContentToDocument();
        }

        private static void AddVerticalSpace(XmlNode node)
        {
            int stop = int.Parse(node.Attributes["arg"].Value);
            if (f == null)
            {
                f = new Phrase();
            }

            for (int i = 0; i < stop; i++)
            {
                f.Add(new Chunk("\n\r", F("Times")));
            }
        }

        private static void AddImage(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode node)
        {
            string path = node.Attributes["src"].Value;

            Image jpg = Image.GetInstance(Path.Combine(rs.ImgPath, path));
            jpg.ScalePercent(50f);

            float width = (node.Attributes["width"] != null) ? float.Parse(node.Attributes["width"].Value) : 100;
            jpg.ScaleAbsoluteWidth(jpg.Width * width / 100.0f);
            float height = (node.Attributes["height"] != null) ? float.Parse(node.Attributes["width"].Value) : 100;
            jpg.ScaleAbsoluteHeight(jpg.Height * height / 100.0f);


            if (node.Attributes["align"] != null)
            {
                if (node.Attributes["align"].Value == "center")
                {
                    jpg.Alignment = Image.ALIGN_CENTER;
                }
                else if (node.Attributes["align"].Value == "wrap")
                {
                    jpg.Alignment = Image.TEXTWRAP;
                }
                else if (node.Attributes["align"].Value == "left")
                {
                    jpg.Alignment = Image.ALIGN_LEFT;
                }
                else if (node.Attributes["align"].Value == "right")
                {
                    jpg.Alignment = Image.ALIGN_LEFT;
                }
                else
                {
                    jpg.Alignment = Image.ALIGN_JUSTIFIED;
                }
            }

            if (!string.IsNullOrWhiteSpace(node.InnerText))
            {
                PdfPTable table = new PdfPTable(1);
                table.DefaultCell.Border = Rectangle.NO_BORDER;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 20f;
                f = new Phrase(rs.ImageCaptionWord + " ");
                PrintChapterToPDFFile(save, doc, Font, enums, node);
                PdfPCell image = new PdfPCell();
                image.AddElement(jpg);
                //PdfPCell image = new PdfPCell();
                image.AddElement(f);
                image.Border = Rectangle.NO_BORDER;
                table.AddCell(image);
                doc.Add(table);
                f = new Phrase();

            }
            else
            {
                doc.Add(jpg);
            }
        }


        private static void AddTable(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode node)
        {
            AddContentToDocument();
            PdfPTable table = new PdfPTable(int.Parse(node.Attributes["columns"].Value));
            table.SplitLate = false;
            table.SplitRows = true;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 20f;

            int listCount = 1;

            if (node.Attributes["width"] != null)
            {
                table.WidthPercentage = float.Parse(node.Attributes["width"].Value);
            }
            if (node.Attributes["colwidths"] != null)
            {
                float[] widths = Regex.Replace(node.Attributes["colwidths"].Value, @"\s+", "").Split(',').Select(s => float.Parse(s)).ToArray();
                table.SetWidths(widths);
            }

            if (node.Attributes["data"] != null)
            {
                string path = ReportEnums.GetVariablePath(node.Attributes["data"].Value.ToUpper().Insert(0, "L_"));
                IList list = ExtensionMethods.GetNestedObject(path.Split('.'), save, 0) as IList;
                listCount = list.Count;
            }

            foreach (XmlNode tr in ((XmlElement)node).GetElementsByTagName("tr"))
            {
                int Stop = 1;
                for (AutoTableLoopCount = 0; AutoTableLoopCount < Stop; AutoTableLoopCount++)
                {
                    foreach (XmlNode td in ((XmlElement)tr).GetElementsByTagName("td"))
                    {
                        f = new Phrase();
                        PrintChapterToPDFFile(save, doc, Font, enums, td);

                        PdfPCell cell = new PdfPCell(f);
                        if (td.Attributes["align"] != null)
                        {
                            if (td.Attributes["align"].Value == "left")
                            {
                                cell.HorizontalAlignment = 0;
                            }
                            else if (td.Attributes["align"].Value == "center")
                            {
                                cell.HorizontalAlignment = 1;
                            }
                            else if (td.Attributes["align"].Value == "right")
                            {
                                cell.HorizontalAlignment = 2;
                            }
                        }
                        if (td.Attributes["colspan"] != null)
                        {
                            cell.Colspan = int.Parse(td.Attributes["colspan"].Value);
                        }
                        table.AddCell(cell);
                    }

                    Stop = (AutoHasStrated) ? listCount : 1;
                }
                AutoHasStrated = (AutoHasStrated) ? false : false;
            }

            doc.Add(table);
            AutoTableLoopCount = 0;
            f = null;
        }


        private static void AddPlainList(ProjectToSave save, Document doc, Font Font, ReportEnums enums, XmlNode node)
        {
            string path = ReportEnums.GetVariablePath(node.Attributes["data"].Value.ToUpper().Insert(0, "L_"));
            string join = (node.Attributes["join"] != null) ? node.Attributes["join"].Value : "";
            IList list = ExtensionMethods.GetNestedObject(path.Split('.'), save, 0) as IList;


            PrintChapterToPDFFile(save, doc, Font, enums, node);
            //node.InnerText = node.InnerText + join;
            AutoTableLoopCount++;
            for (int i = 1; i < list.Count; i++)
            {
                f.Add(new Chunk(join));
                PrintChapterToPDFFile(save, doc, Font, enums, node);
                AutoTableLoopCount++;
            }

            AutoTableLoopCount = 0;
        }

        /// <summary>
        /// Adds phrases and paragraphs to document and creates new instances
        /// </summary>
        private static void AddContentToDocument()
        {
            if (p != null)
            {
                if (f != null)
                {
                    p.Add(f);
                    f = new Phrase();
                }
                doc.Add(p);
                p = new Paragraph();
            }
            else
            {
                if (f != null)
                {
                    doc.Add(f);
                    f = new Phrase();
                    p = new Paragraph();
                }

            }
        }

        public static Font F(string Name)
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
