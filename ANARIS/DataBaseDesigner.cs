using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class DataBaseDesigner : Form, ANS_View
    {

        public ANS_Controller _controller;
        //private int loadStatus = 1;
        //private ComboBox combo = null;
        public StatusStrip newStatus;
        ToolStripLabel totalValueLbl;
        ToolStripLabel totalValueNumLbl;
        ToolStripLabel totalNumberLbl;
        ToolStripLabel totalNumberNumLbl;

        public DataBaseDesigner()
        {
            InitializeComponent();

            newStatus = new StatusStrip();
            newStatus.Location = new System.Drawing.Point(3, 221);
            totalValueLbl = new ToolStripLabel();
            totalValueNumLbl = new ToolStripLabel();
            totalNumberLbl = new ToolStripLabel();
            totalNumberNumLbl = new ToolStripLabel();
            totalValueLbl.Font = new Font(totalValueLbl.Font, FontStyle.Bold);
            totalValueLbl.Text = "Wartość całkowita:  ";
            totalValueNumLbl.Text = "0   ";
            totalNumberLbl.Font = new Font(totalNumberLbl.Font, FontStyle.Bold);
            totalNumberLbl.Text = "Liczba obiektów:  ";
            totalNumberNumLbl.Text = "0   ";
            newStatus.Items.AddRange( new ToolStripLabel[] { totalValueLbl, totalValueNumLbl, totalNumberLbl, totalNumberNumLbl });
            this.Controls.Add(newStatus);
            dataGridView1.Columns["Number"].ValueType = typeof(double);
            dataGridView1.Columns["Number"].DefaultCellStyle.Format = "N2";
            //Console.WriteLine(dataGridView1.Columns["Number"].ValueType.ToString());

        }


        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        public void InitializeGrid()
        {
            _controller.DB.InitializeDataFromGrid(dataGridView1);
            //Console.WriteLine("Chciałem dodawać");
        }

        public void addComboBoxColumn()
        {


        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control.GetType().ToString() == ) { combo = e.Control as ComboBox; }
        }

        private void DataBaseDesigner_FormClosed(object sender, FormClosedEventArgs e)
        {
            _controller.closeDataBaseProject();
        }               

        private string GenerateColumnName(int length)
        {
            string rndName = _controller.randomNameGenerator(length);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name == rndName) { rndName = GenerateColumnName(length); }
            }
            return rndName;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[0].Cells[1].Value.ToString());
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_controller.DBLoadStatus == 0)
            {
                _controller.DB.AddRow(true, "");

                //int ile = _controller.DB.rows.Count;
                //MessageBox.Show("Dodałem: " + _controller.DB.rows[e.RowIndex].name + ", index: " + e.RowIndex);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (_controller != null && rowIndex >= 0 && _controller.DBLoadStatus == 0)
            {
                //if (_controller.DBLoadStatus == 0 && rowIndex >0 && columnIndex >0)
                //Console.WriteLine("W DB mam" + _controller.DB.rows.Count + ", W dgv mam: " + dataGridView1.Rows.Count + ", robie w: " + rowIndex + ":" + columnIndex);
                //MessageBox.Show("W DB mam" + _controller.DB.rows.Count + ", W dgv mam: " + dataGridView1.Rows.Count + ", robie w: " + rowIndex + ":" + columnIndex);
                if ( dataGridView1.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    //Console.WriteLine("W rokwu: " + rowIndex + ", cells:" + _controller.DB.rows[rowIndex].cells.Count);
                    _controller.DB.rows[rowIndex].cells[columnIndex].value = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                }
                if ( dataGridView1.Columns[columnIndex].Name == "Lista" || dataGridView1.Columns[columnIndex].Name == "Number")
                {
                    _controller.calculateTotalValue();
                    _controller.DB.calculateTotalNumber();
                    totalValueNumLbl.Text = _controller.DB.collectionTotalValue.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                    totalNumberNumLbl.Text = _controller.DB.collectionTotalNumber.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                }
            }
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (_controller.DBLoadStatus == 0)
            {
                _controller.DB.AddColumn(e.Column.Index, e.Column);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string msg = "";
            //Console.WriteLine(e.ColumnIndex +" : "+ e.RowIndex +", ex: " + e.Exception);

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
            {
                Console.WriteLine("Wporwadź decimal.");
                msg += "Wporwadź liczbę np. 12,345m.";
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(double))
            {
                Console.WriteLine("Wporwadź double.");
                msg += "Wporwadź liczbę np. 12,345.";
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(bool))
            {
                Console.WriteLine("Wporwadź bool.");
                msg += "Wporwadź 0 (fałsz) lub 1 (prawda).";
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(string))
            {
                Console.WriteLine("Wprowadź string");
                msg += "Wporwadź łańcuch znaków.";
            }
            MessageBox.Show(msg);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGridView1.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (_controller != null)
            {
                int columnIndex = e.Column.Index;
                _controller.DB.columns[columnIndex].width = e.Column.Width;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = "C:";
            saveFD.Title = "Zapisz projekt jako";
            saveFD.FileName = "";

            saveFD.Filter = "Anaris Pliki|*.anrb| Wszystkie Pliki|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.SaveDataBase(saveFD.FileName);
            }
        }

        private void btn_ValueMngr_Click(object sender, EventArgs e)
        {
            if (_controller.valueManager != null)
            {
                if (_controller.valueManager.Visible == true)
                {
                    _controller.valueManager.BringToFront();
                }
                else
                {
                    _controller.ShowHideValueManager();
                }
            }
        }

        private void btn_PieChart_Click(object sender, EventArgs e)
        {
            if (_controller.valuePieChart != null)
            {
                if (_controller.valuePieChart.Visible == true)
                {
                    _controller.valuePieChart.BringToFront();
                }
                else
                {
                    _controller.ShowHideValuePieChart();
                }
            }
        }

        private void catManBtn_Click(object sender, EventArgs e)
        {
            if (_controller.categoryManager != null)
            {

                if (_controller.categoryManager.Visible == true)
                {
                    _controller.categoryManager.BringToFront();
                }
                else
                {
                    _controller.ShowHideCategoryManager();
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _controller.SaveDataBase(_controller.filePath);
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = "C:";
            saveFD.Title = "Zapisz projekt jako";
            saveFD.FileName = "";

            saveFD.Filter = "Anaris Pliki|*.anrb| Wszystkie Pliki|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.SaveDataBase(saveFD.FileName);
            }
        }
    }
}
