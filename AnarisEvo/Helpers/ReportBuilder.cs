using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using AnarisDLL.BLL.Helpers;
using System.IO;
using System.Windows;
using AnarisDLL.BLL;
using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Value;

namespace AnarisEvo.Helpers
{
    public class ReportBuilder : simplePDF
    {
        private Anaris save;
        private Document doc;

        public void CreateReport(Anaris _save)
        {
            save = _save;
            string outputFile = save.ReportSettings.ReportPath;
            bool isOpened = false;

            ReportFonts.LoadFonts(Anaris.Instance.ReportSettings);

            try
            {
                string Dir = Directory.GetParent(outputFile).FullName;
                if (!Directory.Exists(Dir))
                {
                    MessageBox.Show("Ścieżka w której ma powstać raport nie istnieje. Zmień ścieżkę w 'Ustawienia raportu'.");
                    isOpened = true;
                }
                if (File.Exists(outputFile))
                {
                    FileInfo file = new FileInfo(outputFile);
                    using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                    {

                    }
                }
            }
            catch (Exception exc)
            {
                string message = exc.ToString();
                MessageBox.Show("Nie można wygenerować raportu ponieważ jest on obecnie otwarty bądź używany przez inny program.");
                isOpened = true;
            }


            if (!isOpened)
            {
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

                    AddTitlePage();
                    AddAcknowledgement();
                    AddTableOfContent();
                    AddIntroduction();
                    AddChapter1(w);
                    AddChapter2();
                    AddChapterRiskEvaluation();

                    doc.Close();
                }
                doc.Dispose();

                MessageBox.Show("Wygenerowano raport.");
            }
        }

        private void AddTitlePage()
        {
            doc.Add(new Paragraph(5, "\u00a0"));
            AddVerticalSpace(4);

            AddText(ReportFonts.Title, save.ReportSettings.ReportTitle.ToUpper() + "\n\r\n");
            if (!string.IsNullOrWhiteSpace(save.ProjectProperties.Scope)) { AddText(ReportFonts.Title, save.ProjectProperties.Scope.ToUpper() + "\n\r\n\n"); }
            //AddText(ReportFonts.Title, "dla\n\r\n");
            AddText(ReportFonts.Title, save.ProjectProperties.Organization.Name.ToUpper() + "\n\r\n");

            AddVerticalSpace(2);
            AddText(ReportFonts.Regular, "Opracowanie raportu: ");
            AddText(ReportFonts.Regular, string.Join(", ", save.ProjectProperties.Authors.Select(a => a.FullName)));
            AddText(ReportFonts.Regular, "\n\r\n");
            AddText(ReportFonts.Regular, "Zespół ds. oceny ryzyka: ");
            AddText(ReportFonts.Regular, string.Join(", ", save.ProjectProperties.RiskTeam.Select(a => a.FullName)));
            AddText(ReportFonts.Regular, "\n");
            AddContentToDocument(doc);


            AddVerticalSpace(8);
            p.Alignment = Element.ALIGN_CENTER;
            DateTime rd = save.ReportSettings.ReportDate;
            AddText(ReportFonts.Regular, save.ProjectProperties.Organization.City + " " + string.Format("{0} {1} {2}", rd.Day, rd.GetPolishMonthInBiernik(), rd.Year));
            AddContentToDocument(doc);
            doc.NewPage();


        }

        private void AddAcknowledgement()
        {
            AddText(ReportFonts.Regular, "");
            AddContentToDocument(doc);
            doc.NewPage();
        }

        private void AddTableOfContent()
        {
            AddVerticalSpace(1);
            AddText(ReportFonts.ChapterTitle, "Spis treści\n\n\r");
            doc.Add(f);
            AddVerticalSpace(4);

            PdfPTable table = new PdfPTable(4);
            table.SplitLate = false;
            table.SplitRows = true;
            table.SpacingBefore = save.ReportSettings.TableMarginTop;
            table.SpacingAfter = save.ReportSettings.TableMarginBottom;
            table.WidthPercentage = 100;
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.SetWidths(new float[] { 2.5f, 2.5f, 90, 5 });
            int ccp = 10;
            int dcp = 5;

            f = new Phrase();
            AddText(ReportFonts.RegularBold, 1 + ".  " + "Wstęp");
            addCell(table, f, 0, 4, ccp);

            f = new Phrase();
            AddText(ReportFonts.RegularBold, 2 + ".  " + "Zasób dziedzictwa będący przedmiotem oceny");
            addCell(table, f, 0, 4, ccp);

            table.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0 });
            f = new Phrase();
            AddText(ReportFonts.Regular, 2 + "." + 1 + ".  " + "Informacje ogólne o zasobie");
            addCell(table, f, 0, 3, dcp);

            table.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0 });
            f = new Phrase();
            AddText(ReportFonts.Regular, 2 + "." + 2 + ".  " + "Wartość zasobu");
            addCell(table, f, 0, 3, dcp);

            f = new Phrase();
            AddText(ReportFonts.RegularBold, 3 + ".  " + "Analiza ryzyka");
            addCell(table, f, 0, 4, ccp);

            int k = 0;
            for (int i = 0; i < save.ScenarioManager.Risks.Count; i++)
            {

                if (save.ScenarioManager.Risks[i].Print)
                {
                    table.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0 });
                    f = new Phrase();
                    AddText(ReportFonts.Regular, 3 + "." + (k + 1) + ".  " + save.RiskAnalysis.RiskAnalysis[i].name);
                    addCell(table, f, 0, 3, dcp);

                    int l = 1;
                    for (int j = 1; j < save.RiskAnalysis.RiskAnalysis[i].dgvList.Count; j++)
                    {
                        if (save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].Print)
                        {
                            addCell(table, new Phrase(""), 0, 2, dcp);
                            f = new Phrase();
                            AddText(ReportFonts.Regular, 3 + "." + (k + 1) + "." + l + ".  " + save.RiskAnalysis.RiskAnalysis[i].dgvList[j].text);
                            addCell(table, f, 0, 2, dcp);
                            l++;
                        }
                    }
                    k++;
                }
            }

            f = new Phrase();
            AddText(ReportFonts.RegularBold, 4 + ".  " + "Ewaluacja ryzyka");
            addCell(table, f, 0, 4, ccp);

            //f = new Phrase();
            //AddText(regularBold, "  " + 4 + ".  " + "Wnioski");
            //addCell(table, f, 0, 4, ccp);

            table.Summary = "Whatever summary they want";

            doc.Add(table);
            //AddContentToDocument();
            f = null;
            doc.NewPage();
        }



        private void AddIntroduction()
        {
            base.AddText(ReportFonts.ChapterTitle, "1. Wstęp \n\r");

            AddText(ReportFonts.Regular, save.ProjectProperties.ReportIntro);

            AddContentToDocument(doc);
            doc.NewPage();
        }

        public void AddChapter1(PdfWriter w)
        {
            AddText(ReportFonts.ChapterTitle, "2. Zasób dziedzictwa będący przedmiotem oceny \n\r");

            AddText(ReportFonts.SectionTitle, "2.1 Informacje ogólne o zasobie \n\r");

            AddText(ReportFonts.Regular, "Zasób dziedzictwa będący przedmiotem oceny podzielono na następujące grupy podstawowe:\n\r\n");

            Dictionary<string, double> ItemsSplitByCategoryN = PieChartHelper.LoadDataByNameCount(save.DataBase.dgv, save.DataBase.valueManager.valueList);
            foreach (KeyValuePair<string, double> entry in ItemsSplitByCategoryN)
            {
                AddText(ReportFonts.Regular, " -" + entry.Key + " - " + entry.Value + "\n");
            }

            AddContentToDocument(doc);

            AddText(ReportFonts.Regular, "\n\r\n");
            int i = 0;
            foreach (Category cat in save.DataBase.categoryManager.List)
            {
                AddText(ReportFonts.Regular, cat.description + "\n");

                Dictionary<string, double> ItemsSplitByCategory = PieChartHelper.LoadDataByCategoryCount(save.DataBase.dgv, save.DataBase.categoryManager, cat.name, save.DataBase.valueManager.valueList);
                foreach (KeyValuePair<string, double> entry in ItemsSplitByCategory)
                {
                    AddText(ReportFonts.Regular, " -" + entry.Key + " - " + entry.Value + "\n");
                }

                foreach (SubCategory sub in cat.subCategories)
                {
                    AddText(ReportFonts.Regular, sub.description + " ");
                }

                AddText(ReportFonts.Regular, "\n\n");
                i++;
            }


            AddText(ReportFonts.Regular, "\n\n");
            AddText(ReportFonts.SectionTitle, "2.2 Wartość zasobu \n\r");

            AddText(ReportFonts.Regular, save.DataBase.valueManager.ValuesDescription + "\n\n");

            Dictionary<string, double> ItemsSplitByValueCount = PieChartHelper.LoadDataByValueCount(save.DataBase.dgv, save.DataBase.valueManager.valueList);

            foreach (SingleValue value in save.DataBase.valueManager.valueList)
            {
                AddText(ReportFonts.Regular, value.text + " - " + ItemsSplitByValueCount[value.name] + "\n");
                AddText(ReportFonts.Regular, value.description + "\n");
            }

            AddContentToDocument(doc);
            Image img = Image.GetInstance(Services.Service.Instance.LoadPieChartImage("Grupa"));//_controller.valuePieChart.GenerateImageAsByteArray(0)
            img.ScalePercent(50f);
            img.Alignment = Image.ALIGN_CENTER;
            doc.Add(img);


            for (i = 0; i < Services.Service.Instance.Categories.Count; i++)
            {
                Category cat = Services.Service.Instance.Categories[i];
                AddContentToDocument(doc);
                Image imga = Image.GetInstance(Services.Service.Instance.LoadPieChartImage(cat.name));//_controller.valuePieChart.GenerateImageAsByteArray(i + 1)
                imga.ScalePercent(50f);
                imga.Alignment = Image.ALIGN_CENTER;
                doc.Add(imga);

                AddText(ReportFonts.Regular, "\n\n");
            }

            //doc.Add(new Paragraph(5, "\u00a0"));
            AddVerticalSpace(12);
            AddText(ReportFonts.Regular, "                   ");
            AddContentToDocument(doc);
            w.PageEmpty = true;
            bool isadded = doc.NewPage();
            AddContentToDocument(doc);

            //AddText(ReportFonts.Regular, "to ");
            //AddContentToDocument(doc);
            //doc.NewPage();
        }

        public void AddChapter2()
        {
            AddText(ReportFonts.ChapterTitle, "3. Analiza ryzyka \n\r");

            int k = 0;
            for (int i = 0; i < save.ScenarioManager.Risks.Count; i++)
            {
                if (save.ScenarioManager.Risks[i].Print)
                {
                    AddText(ReportFonts.SectionTitle, 3 + "." + (k + 1) + ".  " + save.RiskAnalysis.RiskAnalysis[i].name + "\n\n");
                    int l = 0;
                    for (int j = 1; j < save.RiskAnalysis.RiskAnalysis[i].dgvList.Count; j++)
                    {
                        if (save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].Print)
                        {
                            l++;
                            AddText(ReportFonts.SubSectionTitle, 3 + "." + (k + 1) + "." + l + ".  " + save.RiskAnalysis.RiskAnalysis[i].dgvList[j].text + "\n\n");

                            AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opis + "\n\n");

                            double A = Math.Round(5 - Math.Log10(save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].AMid), 2);
                            string As = string.Format("{0:N2}", A);

                            double B = Math.Round(5 + Math.Log10(save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].BMid / 100.0), 2);
                            string Bs = string.Format("{0:N2}", B);

                            double C = Math.Round(5 + Math.Log10(save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].CLow / 100.0), 2);
                            string Cs = string.Format("{0:N2}", C);

                            AddText(ReportFonts.Regular, "Składowa A - " + As + "\n");
                            AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opisA + "\n\n");

                            AddText(ReportFonts.Regular, "Składowa B - " + Bs + "\n");
                            AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opisB + "\n\n");

                            AddText(ReportFonts.Regular, "Składowa C - " + Cs + "\n");
                            AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opisC + "\n\n");

                            AddText(ReportFonts.RegularBold, string.Format("Wielkość Ryzyka - {0:N2}", (A + B + C)));
                            AddText(ReportFonts.Regular, "\n\n");
                        }
                    }

                    k++;
                    AddText(ReportFonts.Regular, "\n\n");
                }
                else
                {
                    for (int j = 1; j < save.RiskAnalysis.RiskAnalysis[i].dgvList.Count; j++)
                    {
                        if (save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].Print)
                        {
                            PrintSingleScenario(save.RiskAnalysis.RiskAnalysis[i].dgvList[j].text, i, j);
                        }
                    }
                }
            }


            AddContentToDocument(doc);
            doc.NewPage();
        }


        public void AddChapterRiskEvaluation()
        {
            Image imga = Image.GetInstance(Services.Service.Instance.LoadTornadoChartImage(0, -2, 600, 400));            
            imga.ScalePercent(70f);
            imga.Alignment = Image.ALIGN_CENTER;
            doc.Add(imga);

            AddText(ReportFonts.Regular, "\n\n");
        }

        private void PrintSingleScenario(string name, int i, int j)
        {
            string outputFile = Path.Combine(Directory.GetParent(save.ReportSettings.ReportPath).FullName, name + ".pdf");


            Document sdoc = new Document(PageSize.A4);

            //Create a standard .Net FileStream for the file, setting various flags
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            //Create a new PDF document setting the size to A4
            //using (Document doc = new Document(PageSize.A4))                
            //Bind the PDF document to the FileStream using an iTextSharp PdfWriter
            using (PdfWriter w = PdfWriter.GetInstance(sdoc, fs))
            {
                w.AddViewerPreference(PdfName.DUPLEX, PdfName.DUPLEXFLIPLONGEDGE); //nie wime czy to działa
                sdoc.Open();

                //HERE
                f = new Phrase();
                p = new Paragraph();

                AddText(ReportFonts.ChapterTitle, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].Text + "\n\n\n");
                AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opis + "\n\n");

                
                string As = string.Format("{0:N2}", save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].AMM);
                string Bs = string.Format("{0:N2}", save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].BMM);                
                string Cs = string.Format("{0:N2}", save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].CMM);

                AddText(ReportFonts.Regular, "Składowa A - " + As + "\n");
                AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opisA + "\n\n");

                AddText(ReportFonts.Regular, "Składowa B - " + Bs + "\n");
                AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opisB + "\n\n");

                AddText(ReportFonts.Regular, "Składowa C - " + Cs + "\n");
                AddText(ReportFonts.Regular, save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].opisC + "\n\n");

                AddText(ReportFonts.RegularBold, string.Format("Wielkość Ryzyka - {0:N2}", save.ScenarioManager.Risks[i].DistinctiveRisk[j - 1].MM ));
                AddText(ReportFonts.Regular, "\n\n");

                AddContentToDocument(sdoc);

                //HERE

                sdoc.Close();
            }
            sdoc.Dispose();
        }
    }
}
