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
    public partial class AnarisProject : Form, ANS_View
    {

        public ANS_Controller _controller;
        public DataGridView newDGV;
        public List<Control> contra = new List<Control>();
        public List<ToolStripLabel> labelList = new List<ToolStripLabel>();
        public List<ToolStripLabel> labelList2 = new List<ToolStripLabel>();
        public StatusStrip newStatus;
        public StatusStrip dbStatus;
        ToolStripLabel dbTotalValueLbl;
        ToolStripLabel dbTotalValueNumLbl;
        ToolStripLabel dbTotalNumberLbl;
        ToolStripLabel dbTotalNumberNumLbl;
        ToolStripLabel dbTotalSelection = new ToolStripLabel();
        ToolStripLabel totalSelection;


        private int tabIndex = -1;
        private List<int> scenarioIndex = new List<int>();
        //private Color DBColor = Color.Peru;
        private Color DBColor = Color.Tan;
        private Color DBFontColor = Color.White;
        //private Color ARColor = Color.PaleGoldenrod;
        private Color ARColor = Color.Wheat;
        private Color ARFontColor = Color.Black;
        private string columnForSort = "";
        private bool sortOrder = false;



        //StringBuilder totalValTxt = new StringBuilder();



        public AnarisProject(List<string> RC_BaseList)
        {
            //_controller.ARLoadStatus = 1;
            InitializeComponent();
            tabControl.TabPages[0].Text = "Baza Danych";



            dbStatus = new StatusStrip();
            dbStatus.Location = new System.Drawing.Point(3, 221);
            dbTotalValueLbl = new ToolStripLabel();
            dbTotalValueNumLbl = new ToolStripLabel();
            dbTotalNumberLbl = new ToolStripLabel();
            dbTotalNumberNumLbl = new ToolStripLabel();
            dbTotalValueLbl.Font = new Font(dbTotalValueLbl.Font, FontStyle.Bold);
            dbTotalValueLbl.Text = "Wartość całkowita:  ";
            dbTotalValueNumLbl.Text = "0   ";
            dbTotalNumberLbl.Font = new Font(dbTotalNumberLbl.Font, FontStyle.Bold);
            dbTotalNumberLbl.Text = "Liczba obiektów:  ";
            dbTotalNumberNumLbl.Text = "0   ";
            dbStatus.Items.AddRange(new ToolStripLabel[] { dbTotalValueLbl, dbTotalValueNumLbl, dbTotalNumberLbl, dbTotalNumberNumLbl });

            dbStatus.Items.Add(dbTotalSelection);

            tabControl.TabPages[0].Controls.Add(dbStatus);

            for (int i = 0; i < RC_BaseList.Count; i++)
            {
                TabPage tab = new TabPage();
                tab.Text = RC_BaseList[i];
                tab.Name = "tab_" + i.ToString();
                tab.Padding = new Padding { Left = 3, Top = 3 };
                newDGV = new DataGridView();
                tab.Controls.Add(newDGV);
                contra.Add(newDGV as Control);
                newDGV.Dock = DockStyle.Fill;
                newDGV.Name = "dgv_" + (i + 1).ToString();
                newDGV.ColumnHeadersHeight = 47;
                newDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                newDGV.Location = new System.Drawing.Point(3, 3);
                newDGV.Size = new System.Drawing.Size(770, 240);
                newDGV.Visible = true;
                newDGV.AllowUserToAddRows = false;
                newDGV.AllowUserToResizeRows = false;

                newDGV.RowsAdded += NewDGV_RowsAdded;
                newDGV.RowsRemoved += NewDGV_RowsRemoved;
                newDGV.CellValueChanged += NewDGV_CellValueChanged;
                newDGV.MouseDown += NewDGV_MouseDown;
                newDGV.RowPostPaint += NewDGV_RowPostPaint;
                newDGV.CellEnter += NewDGV_CellEnter;
                newDGV.DataError += NewDGV_DataError;
                newDGV.CellLeave += NewDGV_CellLeave;
                newDGV.ColumnWidthChanged += NewDGV_ColumnWidthChanged;
                newDGV.CellClick += NewDGV_CellClick;

                newStatus = new StatusStrip();
                newStatus.Location = new System.Drawing.Point(3, 221);
                ToolStripLabel totalValueLbl = new ToolStripLabel();
                totalValueLbl.Text = "Wartość całkowita: 0";
                labelList.Add(totalValueLbl);
                newStatus.Items.Add(totalValueLbl);
                totalSelection = new ToolStripLabel();
                labelList2.Add(totalSelection);
                newStatus.Items.Add(totalSelection);
                tab.Controls.Add(newStatus);

                //DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                //col.SortMode = DataGridViewColumnSortMode.Programmatic;
                //col.HeaderText = "Column " + i;
                //newDGV.Columns.Add(col);

                tabControl.TabPages.Add(tab);

                scenarioIndex.Add(-1);
            }
            //_controller.ARLoadStatus = 0;
            //scenarioComBox.Items.AddRange(RC_BaseList.ToArray());
        }

        private void NewDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentIndex = scenarioIndex[tabIndex];
            Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[currentIndex];
            DataGridView dgv = (DataGridView)contra[tabIndex];
            bool crossSelection = false;

            if (scenarioIndex[tabIndex] != 0)
            {
                for (int i = 0; i < dgv.SelectedCells.Count - 1 && dgv.SelectedCells.Count > 1; i++)//DataGridViewCell cell in dgv.SelectedCells)
                {
                    if (dgv.SelectedCells[i].ColumnIndex != dgv.SelectedCells[i + 1].ColumnIndex)
                    {
                        crossSelection = true;
                        break;
                    }
                }

                if (crossSelection == false)
                {
                    string name = dgv.Columns[dgv.SelectedCells[0].ColumnIndex].Name;
                    if (name == "CLow" || name == "CMid" || name == "CHigh")
                    {
                        labelList2[tabIndex].Text = calculateSelectionValue(dgv, data, dgv.SelectedCells[0].ColumnIndex, "N2");
                    }
                    else
                    {
                        int numberIndex = data.columns.Find(x => x.name == "Number").index;
                        labelList2[tabIndex].Text = calculateSelectionValue(dgv, data, numberIndex, "N0");
                    }
                }
                else
                {
                    //int numberIndex = data.columns.Find(x => x.name == "Number").index;
                    //labelList2[tabIndex].Text = calculateSelectionValue(dgv, data, numberIndex, "N0");
                    labelList2[tabIndex].Text = "";
                }
            }
            else
            {
                int numberIndex = data.columns.Find(x => x.name == "Number").index;
                labelList2[tabIndex].Text = calculateSelectionValue(dgv, data, numberIndex, "N0");
            }
        }

        private void NewDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (_controller != null)
            {
                int currentIndex = scenarioIndex[tabIndex];
                Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[currentIndex];

                int columnIndex = e.Column.Index;
                data.columns[columnIndex].width = e.Column.Width;
            }
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        public void InitializeGrid()
        {
            _controller.DB.InitializeDataFromGrid(dataGridView1);
        }


        private void NewDGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_controller.ARLoadStatus == 0)
            {
                int currentIndex = scenarioIndex[tabIndex];
                Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[currentIndex];
                DataGridView dgv = (DataGridView)contra[tabIndex];

                //Console.WriteLine("CellLeave : " + data.rows[e.RowIndex].cells[e.ColumnIndex].value);
                if (data.columns[e.ColumnIndex].name == "CLow" || data.columns[e.ColumnIndex].name == "CMid" || data.columns[e.ColumnIndex].name == "CHigh")
                {
                    dgv.CellValueChanged -= NewDGV_CellValueChanged;
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data.rows[e.RowIndex].cells[e.ColumnIndex].value;
                    dgv.CellValueChanged += NewDGV_CellValueChanged;
                    //Console.WriteLine("CellLeave : " + dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                }
            }
        }


        private void NewDGV_MouseDown(object sender, MouseEventArgs e)
        {
            int currentIndex = scenarioIndex[tabIndex];

            if (scenarioComBox.SelectedIndex != -1 && tabIndex >= 0) //&& _controller != null
            {
                Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[currentIndex];
                DataGridView dgv = (DataGridView)contra[tabIndex];
                int selectedInddex = -1;

                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgv.HitTest(e.X, e.Y);
                    dgv.ClearSelection();
                    selectedInddex = hti.RowIndex;
                    //Console.WriteLine("SelecetdIndex: " + selectedInddex);
                }


                if (selectedInddex >= 0 && selectedInddex < dgv.Rows.Count - 1 && scenarioIndex[tabIndex] == 0)
                {
                    if (data.rows[selectedInddex].isDBrow == true)
                    {
                        dgv.Rows[selectedInddex].Selected = true;
                        rowContext.Items["splitRowmnu"].Enabled = true;
                        rowContext.Items["rmvRowMnu"].Enabled = false;
                        rowContext.Show(Cursor.Position);
                    }
                    if (data.rows[selectedInddex].isARrow == true && scenarioComBox.SelectedIndex == 0)
                    {
                        dgv.Rows[selectedInddex].Selected = true;
                        rowContext.Items["splitRowmnu"].Enabled = false;
                        rowContext.Items["rmvRowMnu"].Enabled = true;
                        rowContext.Show(Cursor.Position);
                    }
                    if (data.rows[selectedInddex].isARrow == false && data.rows[selectedInddex].isDBrow == false && scenarioComBox.SelectedIndex > 0)
                    {
                        dgv.Rows[selectedInddex].Selected = true;
                        rowContext.Items["splitRowmnu"].Enabled = false;
                        rowContext.Items["rmvRowMnu"].Enabled = true;
                        rowContext.Show(Cursor.Position);
                    }
                }

            }

        }

        private void NewDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (_controller != null && _controller.ARLoadStatus == 0 && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[scenarioIndex[tabIndex]];
                DataGridView dgv = (DataGridView)contra[tabIndex];
                DataGridViewCell dgvCell = dgv.Rows[rowIndex].Cells[columnIndex];


                //Console.WriteLine("CellValueChnaged");

                if (scenarioIndex[tabIndex] == 0)
                {
                    string rowName = data.rows[rowIndex].name;
                    string colName = data.columns[columnIndex].name;
                    string zeroValue = "";
                    //Console.WriteLine("Zmiana wartości");
                    Console.WriteLine("LO : " + dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString());
                    data.rows[rowIndex].cells[columnIndex].value = dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    if (e.ColumnIndex > 0)
                    {
                        if (dgv.Rows[rowIndex].Cells[columnIndex].Value != null)
                        {
                            _controller.RAList.CellValueChanged(rowName, colName, dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString(), tabIndex);

                            if (dgv.Columns[columnIndex].Name == "Number")
                            {
                                //dgv.Rows[rowIndex].Cells[columnIndex].Value = data.rows[rowIndex].cells[columnIndex].getValue(data, rowIndex);
                                _controller.RAList.RefreshValuesByFormulas(rowName, tabIndex);
                                for (int i = 1; i < _controller.RAList.RiskAnalysis[tabIndex].dgvList.Count; i++)//(Dgv lol in _controller.RAList.RiskAnalysis[tabIndex].dgvList)
                                {                                    
                                    _controller.calculateMagnitudeOfRisk(_controller.RAList.RiskAnalysis[tabIndex].dgvList[i], tabIndex, i - 1);
                                }
                            }
                        }
                        else { _controller.RAList.CellValueChanged(rowName, colName, null, tabIndex); }
                    }
                }
                else
                {
                    if (dgv.Rows[rowIndex].Cells[columnIndex].Value != null)
                    {
                        //Console.WriteLine("IsNotNull : " + dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString());
                        data.rows[rowIndex].cells[columnIndex].value = dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                        dgv.Rows[rowIndex].Cells[columnIndex].Value = data.rows[rowIndex].cells[columnIndex].getValue(data, rowIndex);
                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = data.rows[e.RowIndex].cells[e.ColumnIndex].formula;

                        if (dgv.Columns[e.ColumnIndex].Name == "CLow" || dgv.Columns[e.ColumnIndex].Name == "CMid" || dgv.Columns[e.ColumnIndex].Name == "CHigh")
                        {
                            double ok = 0;

                            if (double.TryParse(dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString(), out ok))
                            {
                                _controller.calculateMagnitudeOfRisk(data, tabIndex, scenarioIndex[tabIndex] - 1);
                                labelList[tabIndex].Text = "MRmin: " + String.Format("{0:0.00}", data.MRmin) + "    MR: " + String.Format("{0:0.00}", data.MR) + "    MRmax: " + String.Format("{0:0.00}", data.MRmax);
                            }
                            else
                            {
                                dgv.Rows[rowIndex].Cells[columnIndex].Value = "";
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine("IsNull : ");
                        data.rows[rowIndex].cells[columnIndex].value = null; data.rows[rowIndex].cells[columnIndex].formula = null;
                    }

                    //_controller.calculateMagnitudeOfRisk(data, tabIndex, scenarioIndex[tabIndex] - 1);
                }


            }

        }

        private DgvCell validateCellValue(DataGridViewCell dgvCell)
        {
            DgvCell dataCell = new DgvCell();
            string value = "";
            string formula = "";

            if (dgvCell.Value != null)
            {
                dataCell.value = dgvCell.Value.ToString();

            }

            return dataCell;
        }


        private void NewDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[scenarioIndex[tabIndex]];
            DataGridView dgv = (DataGridView)contra[tabIndex];
            //Console.WriteLine("Jestem: " + e.RowIndex + ":" + e.ColumnIndex);

            if (data.columns[e.ColumnIndex].name == "CLow" || data.columns[e.ColumnIndex].name == "CMid" || data.columns[e.ColumnIndex].name == "CHigh")
            {
                //Console.WriteLine("fromula: "+data.rows[e.RowIndex].cells[e.ColumnIndex].formula);
                if (data.rows[e.RowIndex].cells[e.ColumnIndex].formula != "")
                {
                    dgv.CellValueChanged -= NewDGV_CellValueChanged;
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data.rows[e.RowIndex].cells[e.ColumnIndex].formula;
                    //Console.WriteLine("new val: " + dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dgv.CellValueChanged += NewDGV_CellValueChanged;
                }

            }
        }

        private void NewDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string msg = "";

            DataGridView dgv = (DataGridView)contra[tabIndex];

            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(double))
            {
                msg += "Wporwadź liczbę np. 12,345.";
            }

            MessageBox.Show(msg);
        }

        private void NewDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_controller.ARLoadStatus == 0)
            {
                Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[scenarioIndex[tabIndex]];
                DataGridView dgv = (DataGridView)contra[tabIndex];

                int childIndex = e.RowIndex;
                int parentIndex = -1;

                for (int i = childIndex - 1; i >= 0; i--)
                {
                    if (data.rows[i].isDBrow == true) { parentIndex = i; break; }
                }
                //Console.WriteLine("Parent w: " + parentIndex);
                //Console.WriteLine("Dziecko w: " + childIndex);
                string parent = data.rows[parentIndex].name;
                //Console.WriteLine("Parent: " + dgv.Rows[rowIndex].Cells[1].Value.ToString() + " index: " + rowIndex + ", chilsIndex: " + childIndex);

                if (scenarioIndex[tabIndex] == 0)
                {
                    _controller.RAList.AddRows(parent, tabIndex);
                    SetRowStyles(dgv, data);
                    dgv.Refresh();
                }
                else
                {
                    data.AddRow(false, childIndex, parent);
                    SetRowStyles(dgv, data);
                    dgv.Refresh();
                }
            }
        }


        private void NewDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_controller.ARLoadStatus == 0)
            {
                Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[scenarioIndex[tabIndex]];
                DataGridView dgv = (DataGridView)contra[tabIndex];

                int childIndex = e.RowIndex;
                int parentIndex = -1;

                for (int i = childIndex - 1; i >= 0; i--)
                {
                    if (data.rows[i].isDBrow == true) { parentIndex = i; break; }
                }

                string parent = data.rows[parentIndex].name;

                if (scenarioIndex[tabIndex] == 0)
                {
                    _controller.RAList.RmvRows(childIndex, tabIndex, parent);
                    SetRowStyles(dgv, data);
                    dgv.Refresh();
                }
                else
                {
                    data.RmvRow(childIndex, parent);
                    SetRowStyles(dgv, data);
                    dgv.Refresh();
                }
            }
        }

        private void NewDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)contra[tabIndex];
            //Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[scenarioIndex[tabIndex]];

            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);

        }


        private void loadDBMenu_Click(object sender, EventArgs e)
        {
            _controller.ARLoadStatus = 1;
            string openedFileName = "";

            openFD.InitialDirectory = "C:";
            openFD.Title = "Otwórz plik Anaris";
            openFD.FileName = "";
            openFD.Filter = "Anaris Pliki|*.anrs|Word Documents|*.doc";


            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                for (int i = dataGridView1.ColumnCount - 1; i >= 0; i--)
                {
                    dataGridView1.Columns.RemoveAt(i);
                }
                _controller.LoadDataBase(openFD.FileName, 1);
                _controller.setNewCategories(); // po co to ?

                tabControl.TabPages[0].Text = "Baza Danych: " + _controller.dbBasicInfo.dbName;
                //dbTotalValueLbl.Text = "Wartość całkowita: " + _controller.calculateTotalValue(_controller.DB).ToString() + "   ";
                dbTotalNumberNumLbl.Text = _controller.DB.collectionTotalNumber.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                dbTotalValueNumLbl.Text = _controller.DB.collectionTotalValue.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
            }

            _controller.ARLoadStatus = 0;
        }

        private void saveDBMenu_Click(object sender, EventArgs e)
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

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(tabControl.SelectedIndex);
            scenarioComBox.Items.Clear();
            scenarioComBox.Text = "Scenariusze";


            if (tabControl.SelectedIndex != 0)
            {
                tabIndex = tabControl.SelectedIndex - 1;
                scenarioComBox.Items.Add("Pochodna baza danych");

                SingleRisk sinri = new SingleRisk();
                List<string> tab = new List<string>();

                foreach (ElementaryRisk eris in _controller.RC_Tabele.Risk[tabIndex].DistinctiveRisk)
                {
                    tab.Add(eris.name);
                    //Console.WriteLine(index + ", " + eris.name);
                }
                scenarioComBox.Items.AddRange(tab.ToArray());

                //Sprawdzamy czy jakiś scenariusz nie został usunięty
                if (scenarioIndex[tabIndex] >= scenarioComBox.Items.Count) { scenarioIndex[tabIndex] = 0; }
                scenarioComBox.SelectedIndex = scenarioIndex[tabIndex];
            }
            else
            {
                dbTotalValueNumLbl.Text = _controller.calculateTotalValue().ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                dbTotalNumberNumLbl.Text = _controller.DB.calculateTotalNumber().ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                //dbTotalValueNumLbl.Text = _controller.DB.collectionTotalValue.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                //dbTotalNumberNumLbl.Text = _controller.DB.collectionTotalNumber.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
            }
        }

        public void setTotalValues()
        {
            dbTotalValueNumLbl.Text = _controller.calculateTotalValue().ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
            dbTotalNumberNumLbl.Text = _controller.DB.calculateTotalNumber().ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
        }

        private void scenarioComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ten warunek jest chyba zbędny
            if (scenarioIndex[tabIndex] >= scenarioComBox.Items.Count) { scenarioIndex[tabIndex] = 0; }

            int currentIndex = scenarioIndex[tabIndex] = scenarioComBox.SelectedIndex;
            _controller.ARLoadStatus = 1; //będziemy ładowali Data do Dgv więc ustawiamy loadStatus

            if (scenarioComBox.SelectedIndex != -1 && _controller != null && tabIndex >= 0)
            {
                Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[currentIndex];
                DataGridView dgv = (DataGridView)contra[tabIndex];
                //MessageBox.Show(data.name);
                dgv.Columns.Clear();



                data.Load(dgv, data);
                _controller.BindData(dgv);
                SetRowStyles(dgv, data);
                dgv.Refresh();

                if (currentIndex > 0)
                {
                    //_controller.calculateTotalValue(data);
                    //_controller.calculateMagnitudeOfRisk(data, tabIndex, currentIndex - 1);
                    //Console.WriteLine(data.rows[17].cells[8].value);

                    labelList[tabIndex].Text = "MRmin: " + String.Format("{0:0.00}", data.MRmin) + "    MR: " + String.Format("{0:0.00}", data.MR) + "    MRmax: " + String.Format("{0:0.00}", data.MRmax);
                }
                else
                {
                    labelList[tabIndex].Text = "Wartość całkowita:  " + _controller.DB.collectionTotalValue.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                }

            }

            _controller.ARLoadStatus = 0;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            Dgv data = _controller.DB;
            DataGridView dgv = dataGridView1;
            int columnIndex = dgv.HitTest(e.X, e.Y).ColumnIndex;
            int selectedInddex = -2;

            if (e.Button == MouseButtons.Right)
            {
                var hti = dgv.HitTest(e.X, e.Y);
                dgv.ClearSelection();
                selectedInddex = hti.RowIndex;
                //Console.WriteLine("SelecetdIndex: " + selectedInddex);
            }


            if (selectedInddex >= 0 && selectedInddex < dgv.Rows.Count - 1)
            {
                dgv.Rows[selectedInddex].Selected = true;
                rowContext.Items["splitRowmnu"].Enabled = false;
                rowContext.Items["rmvRowMnu"].Enabled = true;
                rowContext.Show(Cursor.Position);
            }

            if (selectedInddex == -1 && columnIndex >= 0 && columnIndex < dgv.Columns.Count)
            {
                if (columnForSort == dgv.Columns[columnIndex].Name) { sortOrder = !sortOrder; }
                else { sortOrder = false; }

                columnForSort = dgv.Columns[columnIndex].Name;

                ContextMenuStrip sortContext = new ContextMenuStrip();
                ToolStripMenuItem newSort = new ToolStripMenuItem();
                newSort.Name = "sortMnu";
                newSort.Text = "Sortuj";
                newSort.Enabled = true;
                sortContext.Items.Add(newSort);
                newSort.Click += NewSort_Click;

                ToolStripDropDownButton newSortBy = new ToolStripDropDownButton();
                newSortBy.Text = "Sortuj wg";
                newSortBy.Name = "sortByMnu";
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    ToolStripMenuItem itemOne = new ToolStripMenuItem(col.HeaderText);
                    newSortBy.DropDownItems.Add(itemOne);
                }

                sortContext.Items.Add(newSortBy);
                sortContext.Show(Cursor.Position);
            }

        }

        private void NewSort_Click(object sender, EventArgs e)
        {
            Dgv data = _controller.DB;
            _controller.ARLoadStatus = 1;

            _controller._log.LogEntry.Add("NewSort: Wierszy: " + data.rows.Count.ToString());
            _controller._log.LogEntry.Add("NewSort: Nazwa: " + data.rows[data.rows.Count - 1].name + "  :Zostanie usunięty.");
            _controller._log.LogEntry.Add("NewSort: Grupa: " + data.rows[data.rows.Count - 1].cells[1].value);
            _controller._log.LogEntry.Add("NewSort: Liczba: " + data.rows[data.rows.Count - 1].cells[6].value);

            data.rows.RemoveAt(data.rows.Count - 1);
            _controller.simpleSort(data, columnForSort, sortOrder);
            for (int i = dataGridView1.ColumnCount - 1; i >= 0; i--)
            {
                dataGridView1.Columns.RemoveAt(i);
            }

            data.Load(dataGridView1, data);
            _controller.BindData(dataGridView1);
            data.AddRow(true, "");

            _controller._log.LogEntry.Add("NewSort: Wierszy: " + data.rows.Count.ToString());
            _controller._log.LogEntry.Add("NewSort: Nazwa: " + data.rows[data.rows.Count - 1].name + "  :Został dodany.");
            _controller._log.LogEntry.Add("NewSort: Grupa: " + data.rows[data.rows.Count - 1].cells[1].value);
            _controller._log.LogEntry.Add("NewSort: Liczba: " + data.rows[data.rows.Count - 1].cells[6].value);


            _controller.ARLoadStatus = 0;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            if (_controller != null && _controller.ARLoadStatus == 0 && rowIndex >= 0)
            {
                Dgv data = _controller.DB;
                string rowName = data.rows[rowIndex].name;
                string colName = data.columns[columnIndex].name;

                data.rows[rowIndex].cells[columnIndex].value = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                if (columnIndex > 0)
                {
                    _controller.RAList.CellValueChanged(rowName, colName, dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString());
                }
                if (dataGridView1.Columns[columnIndex].Name == "Lista" || dataGridView1.Columns[columnIndex].Name == "Number")
                {
                    _controller.RAList.RefreshValuesByFormulas(rowName);
                    dbTotalNumberNumLbl.Text = _controller.DB.calculateTotalNumber().ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                    dbTotalValueNumLbl.Text = _controller.calculateTotalValue().ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + "   ";
                }
            }
            if (_controller != null && _controller.ARLoadStatus == 0 && rowIndex == -1)
            { //tutaj zminia się tylko KolumnHeader !!
                Dgv data = _controller.DB;
                string colName = data.columns[columnIndex].name;
                string header = data.columns[columnIndex].headerText;
                _controller.RAList.ColumnHeaderCellChanged(colName, header);
                if (scenarioComBox.SelectedIndex != -1 && tabIndex >= 0)
                {
                    DataGridView dgv = (DataGridView)contra[tabIndex];
                    dgv.Columns[colName].HeaderText = header;
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_controller != null && _controller.ARLoadStatus == 0)
            {
                Dgv data = _controller.DB;
                data.AddRow(true, "");
                _controller.RAList.AddRows(true, data.rows[data.rows.Count - 1].name, "");
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_controller.ARLoadStatus == 0)
            {
                Dgv data = _controller.DB;
                _controller.RAList.RmvRows(data.rows[e.RowIndex].name);
                data.rows.RemoveAt(e.RowIndex);
                _controller.calculateTotalValue();
            }
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (_controller.ARLoadStatus == 0)
            {
                //Console.WriteLine("Jestem dodwajem");
                Dgv data = _controller.DB;
                data.AddColumn(e.Column.Index, e.Column);
                _controller.RAList.AddColumns(data.columns.Count, e.Column);

                if (scenarioComBox.SelectedIndex != -1 && _controller != null && tabIndex >= 0)
                {
                    DataGridView dgv = (DataGridView)contra[tabIndex];
                    if (e.Column.CellType.ToString() == "System.Windows.Forms.DataGridViewComboBoxCell")
                    {
                        DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)e.Column.Clone();
                        column.DefaultCellStyle.BackColor = DBColor;
                        column.DefaultCellStyle.ForeColor = DBFontColor;
                        column.ReadOnly = true;
                        dgv.Columns.Insert(data.columns.Count - 3, column);
                    }

                    if (e.Column.CellType.ToString() == "System.Windows.Forms.DataGridViewTextBoxCell")
                    {
                        DataGridViewTextBoxColumn column = (DataGridViewTextBoxColumn)e.Column.Clone();
                        column.DefaultCellStyle.BackColor = DBColor;
                        column.DefaultCellStyle.ForeColor = DBFontColor;
                        column.ReadOnly = true;
                        dgv.Columns.Insert(data.columns.Count - 3, column);
                    }
                }

            }
        }

        private void dataGridView1_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //Console.WriteLine("Im in 1 ");
            //event nie działa
            if (_controller.ARLoadStatus == 0)
            {
                _controller.RAList.ColumnHeaderCellChanged(e.Column.Name, e.Column.HeaderText);
            }
        }

        private void splitRowMnu_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)contra[tabIndex];
            int rowIndex = dgv.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            //Dgv data = _controller.RAList.RiskAnalysis[tabIndex].dgvList[scenarioIndex[tabIndex]];
            //string name = data.rows[rowIndex].name;

            //Możemy dzielić tylko DBrows więc napewno jest DBrow            

            DataGridViewRow row = (DataGridViewRow)dgv.Rows[rowIndex].Clone();

            int stop = row.Cells.Count;
            if (scenarioIndex[tabIndex] != 0) { stop -= 3; }
            for (int i = 1; i < stop; i++)
            {
                row.Cells[i].Value = dgv.Rows[rowIndex].Cells[i].Value;
            }
            //row.Cells["Item"].Value = "A";
            //Console.WriteLine("Wrzucamy nowy do: " + (dgv.CurrentCell.RowIndex + 1).ToString());

            //Musimy zmienić index jeżeli jest dzielony w pochodnej to index = count - childs
            int index = -1;
            int childRows = _controller.RAList.RiskAnalysis[tabIndex].dgvList[0].rows[rowIndex].childRows.Count;
            int allKids = _controller.RAList.RiskAnalysis[tabIndex].dgvList[scenarioIndex[tabIndex]].rows[rowIndex].childRows.Count;

            if (scenarioIndex[tabIndex] == 0) { index = rowIndex + childRows + 1; }
            else { index = rowIndex + allKids + 1; }

            dgv.Rows.Insert(index, row);

        }

        private void rmvRowMnu_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex > 0)
            {
                DataGridView dgv = (DataGridView)contra[tabIndex];
                int rowIndex = dgv.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                dgv.Rows.RemoveAt(rowIndex);
            }
            if (tabControl.SelectedIndex == 0)
            {
                DataGridView dgv = dataGridView1;
                int rowIndex = dgv.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                dgv.Rows.RemoveAt(rowIndex);
            }
        }

        public void SetRowStyles(DataGridView dgv, Dgv data)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int cellsCount = dgv.Rows[i].Cells.Count;

                if (data.rows[i].isDBrow)
                {
                    for (int k = 0; k < dgv.Rows[i].Cells.Count; k++)
                    {
                        dgv.Rows[i].Cells[k].Style.BackColor = DBColor;
                        dgv.Rows[i].Cells[k].Style.ForeColor = DBFontColor;
                        dgv.Rows[i].Cells[k].ReadOnly = true;
                    }

                    if (data.rows[i].childRows.Count == 0 && !data.name.Contains("RADB_"))
                    {
                        //Console.WriteLine("Row: " + i + ", Warunek DB Ch==0");
                        for (int k = 0; k < 3; k++)
                        {
                            dgv.Rows[i].Cells[cellsCount - 1 - k].ReadOnly = false;
                            dgv.Rows[i].Cells[cellsCount - 1 - k].Style.BackColor = Color.White;
                            dgv.Rows[i].Cells[cellsCount - 1 - k].Style.ForeColor = Color.Black;
                        }
                    }
                }

                if (!data.rows[i].isDBrow)
                {
                    for (int k = 0; k < dgv.Rows[i].Cells.Count; k++)
                    {
                        dgv.Rows[i].Cells[k].Style.BackColor = ARColor;
                        dgv.Rows[i].Cells[k].Style.ForeColor = ARFontColor;
                        dgv.Rows[i].Cells[k].ReadOnly = true;
                    }

                    dgv.Rows[i].Cells[1].ReadOnly = false;
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.White;
                    dgv.Rows[i].Cells[1].Style.ForeColor = Color.Black;

                    int stop = 1;
                    if (!data.name.Contains("RADB_")) { stop = 4; }
                    for (int k = 0; k < stop; k++)
                    {
                        dgv.Rows[i].Cells[cellsCount - 1 - k].ReadOnly = false;
                        dgv.Rows[i].Cells[cellsCount - 1 - k].Style.BackColor = Color.White;
                        dgv.Rows[i].Cells[cellsCount - 1 - k].Style.ForeColor = Color.Black;
                    }
                }

                dgv.Rows[i].Cells[0].Style.BackColor = Color.White;
                dgv.Rows[i].Cells[0].ReadOnly = false;
            }
        }

        private void AnarisProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            _controller.closeAnarisProject();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string msg = "";

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(double))
            {
                //Console.WriteLine("Wporwadź double.");
                msg += "Wporwadź liczbę np. 12,345.";
            }

            //MessageBox.Show(msg);
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (_controller != null)
            {
                int columnIndex = e.Column.Index;
                _controller.DB.columns[columnIndex].width = e.Column.Width;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numberIndex = _controller.DB.columns.Find(x => x.name == "Number").index;
            dbTotalSelection.Text = calculateSelectionValue(dataGridView1, _controller.DB, numberIndex, "N0");
        }

        private string calculateSelectionValue(DataGridView dgv, Dgv data, int numberIndex, string format)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                List<int> rows = new List<int>();
                double sum = 0;
                double val = 0;

                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    //Console.WriteLine("Index: " + cell.RowIndex);
                    if (data.rows[cell.RowIndex].cells[numberIndex].value != null && data.rows[cell.RowIndex].cells[numberIndex].value != "")
                    {
                        sum += double.Parse(data.rows[cell.RowIndex].cells[numberIndex].value);
                        rows.Add(cell.RowIndex);
                    }
                }

                val = data.calculateSelectionValue(rows, _controller.dbValues.valueList, numberIndex);
                return "Liczba:  " + sum.ToString(format, CultureInfo.CreateSpecificCulture("sv-SE")) + "   Wartość:  " + val.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE"));

            }
            else
            {
                return "";
            }
        }

        private void thresholdManBtn_Click(object sender, EventArgs e)
        {
            if (_controller.thresholdChart != null)
            {

                if (_controller.thresholdChart.Visible == true)
                {
                    _controller.thresholdChart.BringToFront();
                }
                else
                {
                    _controller.ShowHideThresholdChart();
                }

            }
        }

        private void btn_Tornado_Click(object sender, EventArgs e)
        {
            if (_controller.tornadoChart != null)
            {

                if (_controller.tornadoChart.Visible == true)
                {
                    _controller.tornadoChart.BringToFront();
                }
                else
                {
                    _controller.ShowHideTornadoChart();
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

        private void btn_ScenarioMngr_Click(object sender, EventArgs e)
        {
            if (_controller.riskManager != null)
            {
                if (_controller.riskManager.Visible == true)
                {
                    _controller.riskManager.BringToFront();
                }
                else
                {
                    _controller.ShowHideRiskManager();
                }
            }
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            _controller.generateReport();
        }

        private void btn_ProjectProp_Click(object sender, EventArgs e)
        {
            if (_controller.propertiesAR != null)
            {
                if (_controller.propertiesAR.Visible == true)
                {
                    _controller.propertiesAR.BringToFront();
                }
                else
                {
                    _controller.ShowHideARProperties();
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _controller.SaveARProject(_controller.filePath);
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = (_controller.filePath == "") ? "C:" : _controller.filePath;
            //saveFD.InitialDirectory = "C:";
            saveFD.Title = "Zapisz projekt jako";
            saveFD.FileName = "";

            saveFD.Filter = "Anaris Pliki|*.anrs| Wszystkie Pliki|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.SaveARProject(saveFD.FileName);
            }
        }
    }
}
