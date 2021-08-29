using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ANARIS.BLL.Report;
using ANARIS.Components;

namespace ANARIS
{
    public partial class ReportForm : Form, ANS_View
    {
        ANS_Controller _controller;
        ReportSettings rs;

        public ReportForm(ReportSettings _rs)
        {
            InitializeComponent();
            rs = _rs;
            if (rs.ReportDate.Year == 1)
            {
                rs.ReportDate = DateTime.Now;
            }
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern;
            this.dateTimePicker.Value = rs.ReportDate;

            dgv_Scenarios.ColumnHeadersHeight = 26;
            dgv_Scenarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            LoadSetting();

        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (_controller != null)
            {
                cmb_factorsList.Items.AddRange(_controller.RC_Tabele.Risk.Select(r => r.name).ToArray());
            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            _controller.generateReport();
            //GeneratePDF();

            /**/
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //general
            rs.ReportPath = txt_reportDir.Text;
            rs.ReportTitle = txt_reportTitle.Text;

            //fonts
            ReportFonts.Title = rf_TitleFont.Save();
            ReportFonts.ChapterTitle = rf_ChapterFont.Save();
            ReportFonts.SectionTitle = rf_SubChapterFont.Save();
            ReportFonts.SubSectionTitle = rf_SubSubFont.Save();
            ReportFonts.Regular = rf_RegularFont.Save();

            rs.SetFont(ReportFonts.Title, rs.TitleFont);
            rs.SetFont(ReportFonts.ChapterTitle, rs.ChapterFont);
            rs.SetFont(ReportFonts.SectionTitle, rs.SectionFont);
            rs.SetFont(ReportFonts.SubSectionTitle, rs.SubSectionFont);
            rs.SetFont(ReportFonts.Regular, rs.RegularFont);

            //table
            rs.TableCaptionWord = txt_tabWord.Text;
            rs.TableMarginBottom = (int)nud_tabMrgDn.Value;
            rs.TableMarginTop = (int)nud_tabMrgUp.Value;
            rs.TableBorderColor = new RColor() { R = (int)nud_tabR.Value, G = (int)nud_tabG.Value, B = (int)nud_tabB.Value };

            //image
            rs.ImageCaptionWord = txt_imgWord.Text;
            rs.ImageMarginBottom = (int)nud_imgMrgDn.Value;
            rs.ImageMarginTop = (int)nud_imgMrgUp.Value;
            rs.ImageBorderColor = new RColor() { R = (int)nud_imgR.Value, G = (int)nud_imgG.Value, B = (int)nud_imgB.Value };

            //ReportSettings.FontTitle = ReportSettings.FontChapterTitle = ReportSettings.FontSectionTitle = ReportSettings.FontSubSectionTitle = FontFactory.GetFont("Verdana", 16, 1, new BaseColor(125, 88, 15));
        }

        private void LoadSetting()
        {
            //general
            txt_reportDir.Text = rs.ReportPath;
            txt_reportTitle.Text = rs.ReportTitle;

            //font
            rf_TitleFont.LoadFont(rs.TitleFont);
            rf_ChapterFont.LoadFont(rs.ChapterFont);
            rf_SubChapterFont.LoadFont(rs.SectionFont);
            rf_SubSubFont.LoadFont(rs.SubSectionFont);
            rf_RegularFont.LoadFont(rs.RegularFont);

            //table
            txt_tabWord.Text = rs.TableCaptionWord;
            nud_tabMrgDn.Value = rs.TableMarginBottom;
            nud_tabMrgUp.Value = rs.TableMarginTop;
            nud_tabR.Value = rs.TableBorderColor != null ? rs.TableBorderColor.R : 0;
            nud_tabG.Value = rs.TableBorderColor != null ? rs.TableBorderColor.G : 0;
            nud_tabB.Value = rs.TableBorderColor != null ? rs.TableBorderColor.B : 0;

            //image
            txt_imgWord.Text = rs.ImageCaptionWord;
            nud_imgMrgDn.Value = rs.ImageMarginBottom;
            nud_imgMrgUp.Value = rs.ImageMarginTop;
            nud_imgR.Value = rs.ImageBorderColor != null ? rs.ImageBorderColor.R : 0;
            nud_imgG.Value = rs.ImageBorderColor != null ? rs.ImageBorderColor.G : 0;
            nud_imgB.Value = rs.ImageBorderColor != null ? rs.ImageBorderColor.B : 0;

            //ReportSettings.FontTitle = ReportSettings.FontChapterTitle = ReportSettings.FontSectionTitle = ReportSettings.FontSubSectionTitle = FontFactory.GetFont("Verdana", 16, 1, new BaseColor(125, 88, 15));
        }

        private void btn_ReportDir_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = (string.IsNullOrWhiteSpace(_controller.filePath)) ? "C:" : _controller.filePath;
            saveFD.Title = "Zapisz raport jako";
            saveFD.FileName = "";

            saveFD.Filter = "PDF Pliki|*.pdf| Wszystkie Pliki|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                rs.ReportPath = saveFD.FileName;
                txt_reportDir.Text = saveFD.FileName;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rs.ReportDate = dateTimePicker.Value;
        }

        private void cmb_factorsList_SelectedValueChanged(object sender, EventArgs e)
        {
            dgv_Scenarios.Rows.Clear();
            int s = cmb_factorsList.SelectedIndex;
            dgv_Scenarios.Rows.Add(new DataGridViewRow());

            DataGridViewRow row = dgv_Scenarios.Rows[0];
            row.Cells[0].Value = _controller.RC_Tabele.Risk[s].Print;
            row.Cells[1].Value = _controller.RC_Tabele.Risk[s].name;

            if (_controller.RC_Tabele.Risk[s].DistinctiveRisk.Count != 0)
            {
                int i = 1;
                foreach (ElementaryRisk scenario in _controller.RC_Tabele.Risk[s].DistinctiveRisk)
                {
                    dgv_Scenarios.Rows.Add(new DataGridViewRow());
                    dgv_Scenarios.Rows[i].Cells[0].Value = scenario.Print;
                    dgv_Scenarios.Rows[i].Cells[1].Value = scenario.name;
                    i++;
                }
            }

        }

        private void dgv_Scenarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;
            int s = cmb_factorsList.SelectedIndex;

            if (s != -1 && c == 0 && r == 0)
            {
                _controller.RC_Tabele.Risk[s].Print = (bool)dgv_Scenarios.Rows[0].Cells[0].Value;
            }
            if (s != -1 && c == 0 && r > 0)
            {
                _controller.RC_Tabele.Risk[s].DistinctiveRisk[r-1].Print = (bool)dgv_Scenarios.Rows[r].Cells[0].Value;
            }
        }

        private void dgv_Scenarios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_Scenarios.IsCurrentCellDirty)
            {
                dgv_Scenarios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.ShowHideReportForm();
        }
    }
}
