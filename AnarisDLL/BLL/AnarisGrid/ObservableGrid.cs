using AnarisDLL.BLL;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.Risk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.AnarisGrid
{
    public class ObservableGrid : ViewModelBase, RandomNameGenerator.IIdentifier
    {

        public ObservableGrid()
        {
            Rows = new ObservableCollection<ObservableRow>();
            Columns = new List<DgvColumn>();
            Rows.CollectionChanged += Rows_CollectionChanged;
        }



        public ObservableCollection<ObservableRow> Rows { get; set; }
        public List<DgvColumn> Columns { get; set; }

        public static int DatabaseColumnCount { get; set; }

        public string Name { get; set; }

        private string _Text { get; set; }
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                OnPropertyChanged("Text");
            }
        }

        private double _CollectionTotalValue { get; set; }
        public double CollectionTotalValue
        {
            get { return _CollectionTotalValue; }
            set
            {
                _CollectionTotalValue = value;
                OnPropertyChanged("CollectionTotalValue");
            }
        }

        private double _CollectionTotalNumber { get; set; }
        public double CollectionTotalNumber
        {
            get { return _CollectionTotalNumber; }
            set
            {
                _CollectionTotalNumber = value;
                OnPropertyChanged("CollectionTotalNumber");
            }
        }

        public double MR { get; set; }
        public double MRmax { get; set; }
        public double MRmin { get; set; }
        private double AvrC { get; set; }
        private double AvrCmin { get; set; }
        private double AvrCmax { get; set; }

        readonly public static int DBRowNameLength = 7;


        public void Clone(Dgv toClone)
        {
            Name = toClone.name;
            Text = toClone.text;
            CollectionTotalValue = toClone.collectionTotalValue;
            CollectionTotalNumber = toClone.collectionTotalNumber;
            MR = toClone.MR;
            MRmax = toClone.MRmax;
            MRmin = toClone.MRmin;
            Columns = toClone.columns.ToList();

            foreach (DgvRow row in toClone.rows)
            {
                ObservableRow oRow = new ObservableRow();
                oRow.Clone(row);
                Rows.Add(oRow);
            }
        }

        public Dgv Convert()
        {
            Dgv dgv = new Dgv();

            dgv.name = Name;
            dgv.text = Text;
            dgv.collectionTotalValue = CollectionTotalValue;
            dgv.collectionTotalNumber = CollectionTotalNumber;
            dgv.MR = MR;
            dgv.MRmax = MRmax;
            dgv.MRmin = MRmin;
            dgv.columns = Columns.ToList();

            foreach (ObservableRow oRow in Rows)
            {
                DgvRow row = oRow.Convert();
                dgv.rows.Add(row);
            }

            return dgv;

        }

        private void Rows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //((ObservableCollection<ObservableRow>)sender)[0]
            ObservableRow row = this.Rows.Last();

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                if (string.IsNullOrWhiteSpace(row.Name))
                {
                    bool isOriginal = false;
                    string name = string.Empty;
                    //while (!isOriginal)
                    //{
                    //    name = AnarisDLL.BLL.Helpers.RandomNameGenerator.Generate(_DBRowNameLength);
                    //    isOriginal = CheckIfNameIsOriginal(name);
                    //}

                    row.Name = RandomNameGenerator.GenerateAndCheck(Rows, DBRowNameLength);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                //I think nothing is needed? What about removing row from database? It requires removing them from all the grids
            }

        }

        public string GenerateNewName(bool isDBRow)
        {
            int rowNameLength = DBRowNameLength;
            string name = string.Empty;

            if (!isDBRow)
            {
                rowNameLength = DBRowNameLength + 1;
            }

            name = RandomNameGenerator.GenerateAndCheck(Rows, rowNameLength);

            return name;
        }

        public double CalculateTotalNumber()
        {
            double number = 0;
            double dn = 0;

            int numberIndex = Columns.Find(x => x.name == "Number").index;

            foreach (ObservableRow row in Rows)
            {
                if (double.TryParse(row.Cells[numberIndex].Value, out dn))
                {
                    number += dn;
                }
            }

            CollectionTotalNumber = number;
            return number;
        }

        public double CalculateTotalValue(Dictionary<string, double> values)
        {
            double _TV = 0.0;
            int valueIndex = Columns.Find(x => x.name == "Lista").index;
            int numberIndex = Columns.Find(x => x.name == "Number").index;

            for (int i = 0; i < Rows.Count; i++)
            {
                ObservableRow row = Rows[i];

                if (row.IsDBrow == true)
                {
                    if (!string.IsNullOrWhiteSpace(row.Cells[valueIndex].Value) && !string.IsNullOrWhiteSpace(row.Cells[numberIndex].Value))
                    {
                        _TV += values[row.Cells[valueIndex].Value] * double.Parse(row.Cells[numberIndex].Value, CultureInfo.CurrentCulture);
                    }
                }
            }

            CollectionTotalValue = _TV;
            return _TV;
        }

        /// <summary>
        /// This odesnt make sense bacause we need only C to calculate A and B are rigid in scenario
        /// </summary>
        /// <param name="values">Values are dictionary where Key i the same as cell.Value value</param>
        /// <param name="risksCollection"></param>
        /// <param name="agent"></param>
        /// <param name="scenario"></param>
        public void CalculateMagnitudeOfRisk(Dictionary<string, double> values, ElementaryRisk scenario)
        {
            double _MR = 0;
            double _MRmin = 0;
            double _MRmax = 0;

            double C = 0;
            double Cmin = 0;
            double Cmax = 0;

            double L = 0;
            double V = 0;

            int valueIndex = Columns.Find(x => x.name == "Lista").index;
            int numberIndex = Columns.Find(x => x.name == "Number").index;

            int lossIndexMin = Columns.Find(x => x.name == "CLow").index;
            double Amin = scenario.ALow;
            double Bmin = scenario.BLow;

            int lossIndex = Columns.Find(x => x.name == "CMid").index;
            double A = scenario.AMid;
            double B = scenario.BMid;

            int lossIndexMax = Columns.Find(x => x.name == "CHigh").index;
            double Amax = scenario.AHigh;
            double Bmax = scenario.BHigh;

            for (int i = 0; i < Rows.Count - 1; i++)
            {
                ObservableRow row = Rows[i];

                if (row.Cells[valueIndex].Value != null)
                {
                    V = values[Rows[i].Cells[valueIndex].Value];

                    if (row.IsDBrow == true && Rows[i].ChildRows.Count == 0)
                    {

                        if (!string.IsNullOrWhiteSpace(row.Cells[lossIndex].Value))
                        {
                            C = double.Parse(row.Cells[lossIndex].Value, CultureInfo.CurrentCulture);
                            _MR += C * V;
                        }
                        if (!string.IsNullOrWhiteSpace(row.Cells[lossIndexMin].Value))
                        {
                            Cmin = double.Parse(row.Cells[lossIndexMin].Value, CultureInfo.CurrentCulture);
                            _MRmin += Cmin * V;
                        }
                        if (!string.IsNullOrWhiteSpace(row.Cells[lossIndexMax].Value))
                        {
                            Cmax = double.Parse(row.Cells[lossIndexMax].Value, CultureInfo.CurrentCulture);
                            _MRmax += Cmax * V;
                        }

                    }

                    if (row.IsDBrow == true && row.ChildRows.Count > 0)
                    {
                        for (int j = i + 1; j < i + row.ChildRows.Count + 1; j++)
                        {
                            if (!string.IsNullOrWhiteSpace(Rows[j].Cells[lossIndex].Value))
                            {
                                C = double.Parse(Rows[j].Cells[lossIndex].Value, CultureInfo.CurrentCulture);
                                _MR += C * V;
                            }
                            if (!string.IsNullOrWhiteSpace(Rows[j].Cells[lossIndexMin].Value))
                            {
                                Cmin = double.Parse(Rows[j].Cells[lossIndexMin].Value, CultureInfo.CurrentCulture);
                                _MRmin += Cmin * V;
                            }
                            if (!string.IsNullOrWhiteSpace(Rows[j].Cells[lossIndexMax].Value))
                            {
                                Cmax = double.Parse(Rows[j].Cells[lossIndexMax].Value, CultureInfo.CurrentCulture);
                                _MRmax += Cmax * V;
                            }

                        }
                        i += row.ChildRows.Count;

                    }
                }
            }

            AvrC = _MR / CollectionTotalValue;
            AvrCmin = (_MRmin == 0) ? AvrC : _MRmin / CollectionTotalValue;
            AvrCmax = (_MRmax == 0) ? AvrC : _MRmax / CollectionTotalValue;

            scenario.Update(AvrCmin * 100, AvrC * 100, AvrCmax * 100);

            MR = (_MR == 0) ? 0 : MR = 15 + Math.Log10(AvrC * (B / 100.0) / A);
            MRmin = (_MRmin == 0) ? 0 : 15 + Math.Log10(AvrCmin * (Bmin / 100.0) / Amin);
            MRmax = (_MRmax == 0) ? 0 : 15 + Math.Log10(AvrCmax * (Bmax / 100.0) / Amax);
        }

        public ObservableGrid CreateScenarioGrid(ObservableGrid derivedDb, string name, string text)
        {
            Name = name;
            Text = text;
            CollectionTotalValue = derivedDb.CollectionTotalValue;
            CollectionTotalNumber = derivedDb.CollectionTotalNumber;
            MR = derivedDb.MR;
            MRmax = derivedDb.MRmax;
            MRmin = derivedDb.MRmin;
            Columns = derivedDb.Columns.ToList();
            AddCColumns();

            foreach (ObservableRow row in derivedDb.Rows)
            {
                ObservableRow oRow = new ObservableRow(this.Columns.Count);
                oRow.Clone(row);
                Rows.Add(oRow);
            }

            return this;
        }

        public void AddCColumns()
        {
            int columnIndex = Columns.Count;

            for (int i = 0; i < 3; i++)
            {
                DgvColumn newColumn = new DgvColumn();
                if (i == 0) { newColumn.name = "CLow"; }
                if (i == 0) { newColumn.headerText = "C min"; }
                if (i == 1) { newColumn.name = "CMid"; }
                if (i == 1) { newColumn.headerText = "C"; }
                if (i == 2) { newColumn.name = "CHigh"; }
                if (i == 2) { newColumn.headerText = "C max"; }


                newColumn.index = columnIndex + i;
                newColumn.type = "System.Windows.Forms.DataGridViewTextBoxCell";
                newColumn.visible = true;
                newColumn.width = 60;
                newColumn.sortable = false;
                newColumn.cellStyle = "MiddleCenter";
                newColumn.isDBcol = false;

                Columns.Add(newColumn);

                foreach (ObservableRow r in Rows)
                {
                    ObservableCell cell = new ObservableCell();
                    r.Cells.Add(cell);
                }

            }

        }

        public ObservableRow this[string name]
        {
            get { return Rows.FirstOrDefault(r => r.Name == name); }
            set
            {
                ObservableRow tmp = Rows.FirstOrDefault(r => r.Name == name);
                tmp = value;
            }
        }

        public ObservableRow CreateNewRow(int columns, string name, bool isDBRow, string parentRow)
        {
            ObservableRow row = new ObservableRow();
            int rowNameLength = DBRowNameLength;

            if (string.IsNullOrWhiteSpace(name))
            {
                name = GenerateNewName(isDBRow);
            }

            row.Name = name;
            row.IsDBrow = isDBRow;
            row.IsARrow = !isDBRow;
            if (!isDBRow)
            {
                row.Parent = parentRow;
            }

            for (int i = row.Cells.Count; i < columns; i++)
            {
                row.Cells.Add(new ObservableCell());
            }

            return row;
        }

        public ObservableRow AddNewChildRow(ObservableRow parent, int columns, string name)
        {
            ObservableRow row = new ObservableRow();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = GenerateNewName(false);
            }

            row.Name = name;
            row.IsDBrow = false;
            row.IsARrow = true;
            row.Parent = parent.Name;
            parent.ChildRows.Add(name);

            for (int i = row.Cells.Count; i < columns; i++)
            {
                row.Cells.Add(new ObservableCell());
            }

            for (int i = 0; i < parent.Cells.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(parent.Cells[i].Value))
                {
                    row.Cells[i].Value = parent.Cells[i].Value;
                }
            }



            return row;
        }



        public void AddNewColumn(int index, int width, Category.Category category)
        {
            DgvColumn newColumn = new DgvColumn();
            newColumn.name = category.name;
            newColumn.headerText = category.text;
            newColumn.index = index;
            newColumn.type = Enums.ColumnTypes.ComboBox.ToString();
            newColumn.visible = true;
            newColumn.width = width;
            newColumn.sortable = false;
            newColumn.isDBcol = true;

            Columns.Insert(index, newColumn);

            for (int i = index + 1; i < Columns.Count; i++)
            {
                Columns[i].index = i;
            }

            foreach (ObservableRow r in Rows)
            {
                ObservableCell cell = new ObservableCell();
                r.Cells.Insert(index, cell);
            }
        }

        public void RemoveColumn(string name)
        {
            DgvColumn column = Columns.FirstOrDefault(c => c.name == name);
            if (column != null)
            {
                Columns.Remove(column);
            }

            foreach (ObservableRow r in Rows)
            {
                r.Cells.RemoveAt(column.index);
            }

            for (int i = column.index; i < Columns.Count; i++)
            {
                Columns[i].index = i;
            }
        }
    }

    public class ObservableRow : RandomNameGenerator.IIdentifier
    {
        public ObservableCollection<ObservableCell> Cells
        {
            get;
            set;
        }


        public bool IsDBrow { get; set; }
        public bool IsARrow { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public ObservableCollection<string> ChildRows { get; set; }

        public Action OnRowChanged;
        //private double PartialRisk { get; set; }
        //private double partialRiskMin { get; set; }
        //private double partialRiskMax { get; set; }

        public ObservableRow()
        {
            Cells = new ObservableCollection<ObservableCell>();
            ChildRows = new ObservableCollection<string>();
            IsDBrow = true;
            IsARrow = false;
            //we add rows only in DataBase
            for (int i = 0; i < ObservableGrid.DatabaseColumnCount; i++)
            {
                Cells.Add(new ObservableCell());
            }
        }

        public ObservableRow(int columns)
        {
            Cells = new ObservableCollection<ObservableCell>();
            ChildRows = new ObservableCollection<string>();
            IsDBrow = true;
            IsARrow = false;

            for (int i = 0; i < columns; i++)
            {
                Cells.Add(new ObservableCell());
            }
        }

        public ObservableRow Clone(DgvRow toClone)
        {
            IsDBrow = toClone.isDBrow;
            IsARrow = toClone.isARrow;
            Name = toClone.name;
            Parent = toClone.parent;
            ChildRows = new ObservableCollection<string>(toClone.childRows);

            //if (ObservableGrid.DatabaseColumnCount == 0)
            //{
            foreach (DgvCell cell in toClone.cells)
            {
                ObservableCell oCell = new ObservableCell();
                Cells.Add(oCell.Clone(cell));
            }
            //}
            //else
            //{
            //    if (toClone.cells.Count != this.Cells.Count)
            //    {
            //        throw new Exception("Podczas operacji wystapił następujący błąd:\n On ObservableRow.Clone(). Number of cells in DgvRow object doesn't match number od cells in ObservableRow object.");
            //    }

            //    for (int i = 0; i < toClone.cells.Count; i++)
            //    {
            //        ObservableCell oCell = new ObservableCell();
            //        Cells[i] = oCell.Clone(toClone.cells[i]);
            //    }
            //}

            return this;
        }

        public DgvRow Convert()
        {
            DgvRow row = new DgvRow();

            row.isDBrow = IsDBrow;
            row.isARrow = IsARrow;
            row.name = Name;
            row.parent = Parent;
            row.childRows = ChildRows.ToList();

            foreach (ObservableCell oCell in Cells)
            {
                DgvCell cell = oCell.Convert();
                row.cells.Add(cell);
            }

            return row;
        }

        public ObservableRow Clone(ObservableRow toClone)
        {
            IsDBrow = toClone.IsDBrow;
            IsARrow = toClone.IsARrow;
            Name = toClone.Name;
            Parent = toClone.Parent;
            //ChildRows = new ObservableCollection<string>(toClone.ChildRows);

            foreach (string child in toClone.ChildRows)
            {
                ChildRows.Add(child);
            }

            for (int i = 0; i < toClone.Cells.Count; i++)
            {
                Cells[i].Clone(toClone.Cells[i]);
            }

            return this;
        }
    }

    public class ObservableCell : ViewModelBase
    {
        public ObservableCell()
        {

        }

        private string _Value;
        public string Value
        {
            get { return _Value; } //Tutaj rozpisać z uwzględnieniem formuly
            set
            {
                _Value = value;
                if (!Block)
                {
                    Formula = null;
                    Block = false;
                }

                OnPropertyChanged("Value");
            }
        }

        private string _Formula;
        public string Formula
        {
            get { return _Formula; }
            set
            {
                _Formula = value;
                OnPropertyChanged("Formula");
            }
        }

        public bool Block { get; set; }

        public ObservableCell Clone(DgvCell toClone)
        {
            Value = toClone.value;
            Formula = toClone.formula;

            return this;
        }

        public void Clone(ObservableCell toClone)
        {
            Value = toClone.Value;
            Formula = toClone.Formula;
        }

        public DgvCell Convert()
        {
            DgvCell cell = new DgvCell();

            cell.value = Value;
            cell.formula = Formula;

            return cell;
        }

        public static KeyValuePair<string, double> DecomposeFormula(ObservableCell cell)
        {

            if (!string.IsNullOrWhiteSpace(cell.Formula))
            {
                int start = cell.Formula.IndexOf("[") + 1;
                int stop = cell.Formula.IndexOf("]");
                string colName = cell.Formula.Substring(start, stop - start);

                start = cell.Formula.IndexOf("*") + 1;
                double number = double.Parse(cell.Formula.Substring(start), CultureInfo.InvariantCulture);

                return new KeyValuePair<string, double>(colName, number);
            }

            return new KeyValuePair<string, double>("Liczba", 0.0);

        }

        public static void SetNewFormula(ObservableCell cell, string columnHeader, double number)
        {
            cell.Formula = $"=[{columnHeader}]*{number.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
        }

        public Action OnCellChanged;

    }
}
