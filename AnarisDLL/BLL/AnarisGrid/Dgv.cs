using AnarisDLL.BLL.Value;
using AnarisDLL.BLL.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnarisDLL.BLL.Risk;

namespace AnarisDLL.BLL.AnarisGrid
{
    [Serializable]
    public class Dgv
    {
        public string name { get; set; }
        public string text { get; set; }
        public List<DgvColumn> columns { get; set; }
        public List<DgvRow> rows { get; set; }

        public double collectionTotalValue { get; set; }
        public double collectionTotalNumber { get; set; }
        public double MR { get; set; }
        public double MRmax { get; set; }
        public double MRmin { get; set; }
        private double AvrC { get; set; }
        private double AvrCmin { get; set; }
        private double AvrCmax { get; set; }

        private int rowNameLength = 6;


        public Dgv()
        {
            columns = new List<DgvColumn>();
            rows = new List<DgvRow>();
        }

        public void AddRAColumns()
        {
            int columnIndex = columns.Count;

            for (int i = 0; i < 3; i++)
            {
                DgvColumn newColumn = new DgvColumn();
                if (i == 0) { newColumn.name = "CLow"; }
                if (i == 0) { newColumn.headerText = "Dolna"; }
                if (i == 1) { newColumn.name = "CMid"; }
                if (i == 1) { newColumn.headerText = "Prawdopodobna"; }
                if (i == 2) { newColumn.name = "CHigh"; }
                if (i == 2) { newColumn.headerText = "Górna"; }

                newColumn.index = columnIndex + i;
                newColumn.type = "System.Windows.Forms.DataGridViewTextBoxCell";
                newColumn.visible = true;
                newColumn.width = 60;
                newColumn.sortable = false;
                newColumn.cellStyle = "MiddleCenter";
                newColumn.isDBcol = false;
                columns.Add(newColumn);

                foreach (DgvRow r in rows)
                {
                    DgvCell cell = new DgvCell();
                    r.cells.Add(cell);
                }
            }
        }

        public void AddDatabaseColumns()
        {
            int columnIndex = columns.Count;

            for (int i = 0; i < 4; i++)
            {
                DgvColumn newColumn = new DgvColumn();

                newColumn.index = i;
                newColumn.type = "System.Windows.Forms.DataGridViewCheckBoxCell";
                newColumn.visible = true;
                newColumn.sortable = false;
                newColumn.cellStyle = "MiddleCenter";
                newColumn.isDBcol = true;
                newColumn.isARcol = false;
                columns.Add(newColumn);

            }

            columns[0].name = "Select"; columns[0].headerText = "Zaznacz"; columns[0].width = 60;
            columns[1].name = "Item"; columns[1].headerText = "Grupa"; columns[1].width = 560;
            columns[2].name = "Lista"; columns[2].headerText = "Wartość"; columns[2].width = 70;
            columns[3].name = "Number"; columns[3].headerText = "Liczba"; columns[3].width = 90;
        }

        public void Clone(Dgv toCopy)
        {
            name = toCopy.name;
            collectionTotalValue = toCopy.collectionTotalValue;
            collectionTotalNumber = toCopy.collectionTotalNumber;
            MR = toCopy.MR;
            MRmax = toCopy.MRmax;
            MRmin = toCopy.MRmin;

            columns.Clear();
            rows.Clear();

            foreach (DgvColumn colprop in toCopy.columns)
            {
                DgvColumn newColumn = new DgvColumn();
                newColumn.Clone(colprop);
                columns.Add(newColumn);
            }

            foreach (DgvRow row in toCopy.rows)
            {
                DgvRow newrow = new DgvRow();
                newrow.Clone(row);
                rows.Add(newrow);
            }

        }
        public void Clear()
        {
            name = "";
            columns.Clear();
            rows.Clear();

            collectionTotalValue = 0;
            collectionTotalNumber = 0;
            MR = 0;
            MRmax = 0;
            MRmin = 0;
            AvrC = 0;
            AvrCmin = 0;
            AvrCmax = 0;
        }

        
        public void AddColumn(int columnIndex, DataGridViewColumn column)
        {
            DgvColumn newColumn = new DgvColumn();
            newColumn.name = column.Name;
            newColumn.headerText = column.HeaderText;
            newColumn.index = column.Index;
            newColumn.type = column.CellType.ToString();
            newColumn.visible = column.Visible;
            newColumn.width = column.Width;
            if (column.SortMode == DataGridViewColumnSortMode.Automatic) { newColumn.sortable = true; }
            else { newColumn.sortable = false; }
            newColumn.cellStyle = column.DefaultCellStyle.Alignment.ToString();
            newColumn.valueFormat = column.DefaultCellStyle.Format.ToString();
            if (column.ValueType != null) { newColumn.valueType = column.ValueType.ToString(); }

            newColumn.isDBcol = true;


            columns.Insert(columnIndex, newColumn);

            for (int i = columnIndex + 1; i < columns.Count; i++)
            {
                columns[i].index = i;
            }

            foreach (DgvRow r in rows)
            {
                DgvCell cell = new DgvCell();
                r.cells.Insert(columnIndex, cell);
            }
        }


        public void AddRow(bool isDBrow, int index, string parent)
        {
            DgvRow row = new DgvRow();

            List<DgvCell> cells = new List<DgvCell>();
            for (int i = 0; i < columns.Count; i++)
            {
                DgvCell nowa = new DgvCell();
                cells.Add(nowa);
            }

            row.isDBrow = isDBrow;
            row.cells.AddRange(cells);
            row.name = randomNameGenerator(rowNameLength);

            if (isDBrow == false)
            {
                row.parent = parent;
                //int parentIndex = GetRowIndex(this, parent);
                DgvRow _parRow = rows.Find(x => x.name == parent);
                _parRow.childRows.Add(row.name);

                for (int j = 1; j < _parRow.cells.Count; j++)
                {
                    if (columns[j].isDBcol == true)
                    {
                        row.cells[j].value = _parRow.cells[j].value;
                    }
                }

            }
            else { row.parent = ""; }

            rows.Insert(index, row);
        }

        private static int GetRowIndex(Dgv data, string name)
        {
            int index = -1;

            for (int i = 0; i < data.rows.Count; i++)
            {
                if (data.rows[i].name == name) { index = i; break; }
            }

            return index;
        }

        public void AddRow(bool isDBrow, string nazwa, string parent)
        {
            DgvRow row = new DgvRow();

            List<DgvCell> cells = new List<DgvCell>();
            for (int i = 0; i < columns.Count; i++)
            {
                DgvCell nowa = new DgvCell();
                cells.Add(nowa);
            }

            row.isDBrow = isDBrow;
            row.cells.AddRange(cells);
            row.name = nazwa;

            if (isDBrow == false)
            {
                row.parent = parent;
                DgvRow _parRow = rows.Find(x => x.name == parent);
                _parRow.childRows.Add(row.name);
            }
            else { row.parent = ""; }

            rows.Add(row);
        }

        public void AddRow(bool isDBrow, string parent)
        {
            DgvRow row = new DgvRow();

            List<DgvCell> cells = new List<DgvCell>();
            for (int i = 0; i < columns.Count; i++)
            {
                DgvCell nowa = new DgvCell();
                cells.Add(nowa);
            }

            row.isDBrow = isDBrow;
            row.cells.AddRange(cells);
            row.name = randomNameGenerator(rowNameLength);

            if (isDBrow == false)
            {
                row.parent = parent;
                DgvRow _parRow = rows.Find(x => x.name == parent);
                _parRow.childRows.Add(row.name);
            }
            else { row.parent = ""; }

            rows.Add(row);
        }

        public void RmvRow(int index, string parent)
        {
            string rowName = rows[index].name;

            DgvRow _parRow = rows.Find(x => x.name == parent);
            DgvRow row = rows.Find(x => x.name == rowName);

            _parRow.childRows.Remove(row.name);
            rows.Remove(row);

        }

        public double calculateTotalNumber()
        {
            double number = 0;
            double dn = 0;

            DgvColumn tmp = columns.Find(x => x.name == "Number");

            if (tmp != null)
            {
                int columnIndex = tmp.index;

                foreach (DgvRow row in rows)
                {
                    if (double.TryParse(row.cells[columnIndex].value, out dn))
                    { number += dn; }
                }
            }

            collectionTotalNumber = number;
            return number;
        }

        public double calculateTotalValue(List<SingleValue> valueList)
        {
            double _TV = 0.0;
            int valueIndex = columns.Find(x => x.name == "Lista").index;
            int numberIndex = columns.Find(x => x.name == "Number").index;

            double val = 0.0;

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].isDBrow == true)
                {
                    if (!string.IsNullOrWhiteSpace(rows[i].cells[valueIndex].value))
                    {
                        val = getCellValue(valueList, rows[i].cells[valueIndex].value);
                        //Console.WriteLine(i + ", Wykryłem wartość: " + val);
                    }

                    if (rows[i].cells[numberIndex].value != null && rows[i].cells[numberIndex].value != "")
                    {
                        //Console.WriteLine("i: " + i + ", value: " + rows[i].cells[numberIndex].value);
                        _TV += val * double.Parse(rows[i].cells[numberIndex].value);
                        //Console.WriteLine(i + ", Wykryłem wartość: " + double.Parse(rows[i].cells[numberIndex].value));
                    }
                }
            }
            //Console.WriteLine("Total val is: " + _TV);
            collectionTotalValue = _TV;
            return _TV;
        }

        public void calculateMagnitudeOfRisk(List<SingleValue> valueList, RiskCollection riskList, int riskIndex, int distIndex)
        {
            double _MR = 0;
            double _MRmin = 0;
            double _MRmax = 0;

            double A = 0;
            double Amin = 0;
            double Amax = 0;

            double B = 0;
            double Bmin = 0;
            double Bmax = 0;

            double C = 0;
            double Cmin = 0;
            double Cmax = 0;

            int lossIndex = -1;
            int lossIndexMin = -1;
            int lossIndexMax = -1;

            bool isOkN = false;
            bool isOkCmin = false;
            bool isOkC = false;
            bool isOkCmax = false;

            double N = 0;
            double V = 0;
            int valueIndex = columns.Find(x => x.name == "Lista").index;
            int numberIndex = columns.Find(x => x.name == "Number").index;

            lossIndexMin = columns.Find(x => x.name == "CLow").index;
            Amin = riskList.Risks[riskIndex].DistinctiveRisk[distIndex].ALow;
            Bmin = riskList.Risks[riskIndex].DistinctiveRisk[distIndex].BLow;

            lossIndex = columns.Find(x => x.name == "CMid").index;
            A = riskList.Risks[riskIndex].DistinctiveRisk[distIndex].AMid;
            B = riskList.Risks[riskIndex].DistinctiveRisk[distIndex].BMid;

            lossIndexMax = columns.Find(x => x.name == "CHigh").index;
            Amax = riskList.Risks[riskIndex].DistinctiveRisk[distIndex].AHigh;
            Bmax = riskList.Risks[riskIndex].DistinctiveRisk[distIndex].BHigh;

            //NumberStyles style = NumberStyles.AllowDecimalPoint;
            //CultureInfo culture = CultureInfo.InvariantCulture;            

            for (int i = 0; i < rows.Count - 1; i++)
            {
                //Console.WriteLine(i + ": " + rows[i].cells[valueIndex].value);
                if (rows[i].cells[valueIndex].value != null)
                {
                    V = getCellValue(valueList, rows[i].cells[valueIndex].value);
                    //Console.Write(i + " Value is ok. ");

                    if (rows[i].isDBrow == true && rows[i].childRows.Count == 0)
                    {
                        //Console.WriteLine(i + " IsDbRow is ok. ");

                        if (rows[i].cells[lossIndex].value != null && rows[i].cells[lossIndex].value != "")
                        {
                            C = double.Parse(rows[i].cells[lossIndex].value);
                            //Console.WriteLine(" C:" + C);
                            _MR += C * V;
                        }
                        if (rows[i].cells[lossIndexMin].value != null && rows[i].cells[lossIndexMin].value != "")
                        {
                            Cmin = double.Parse(rows[i].cells[lossIndexMin].value);
                            _MRmin += Cmin * V;
                        }
                        if (rows[i].cells[lossIndexMax].value != null && rows[i].cells[lossIndexMax].value != "")
                        {
                            Cmax = double.Parse(rows[i].cells[lossIndexMax].value);
                            _MRmax += Cmax * V;
                        }

                    }
                    if (rows[i].isDBrow == true && rows[i].childRows.Count > 0)
                    {
                        //Console.WriteLine(i + " IsArRow is ok. ");
                        //Console.WriteLine("i=" + i);
                        for (int j = i + 1; j < i + rows[i].childRows.Count + 1; j++)
                        {
                            //Console.WriteLine("i=" + j);                            
                            //isOkN = double.TryParse(rows[i].cells[numberIndex].value, style, culture, out N);
                            //Console.WriteLine(isOkC + " " + isOkCmax + " " + isOkCmin + " C: " + C);
                            //Console.WriteLine("i: " + i + ", j: " + j + ", V: " + V + ", N: " + N + ", C: " + rows[j].cells[lossIndex].value);
                            //Console.WriteLine(j + ":" + " C:" + rows[j].cells[lossIndex].value + " Cmin:" + rows[j].cells[lossIndexMin].value + " Cmax:" + rows[j].cells[lossIndexMax].value);

                            if (rows[j].cells[lossIndex].value != null && rows[j].cells[lossIndex].value != "")
                            {
                                C = double.Parse(rows[j].cells[lossIndex].value);
                                _MR += C * V;
                                //Console.WriteLine("TV=" + collectionTotalValue + ", V=" + V + ", N=" + N + ", C=" + C);
                            }
                            if (rows[j].cells[lossIndexMin].value != null && rows[j].cells[lossIndexMin].value != "")
                            {
                                Cmin = double.Parse(rows[j].cells[lossIndexMin].value);
                                _MRmin += Cmin * V;
                            }
                            if (rows[j].cells[lossIndexMax].value != null && rows[j].cells[lossIndexMax].value != "")
                            {
                                Cmax = double.Parse(rows[j].cells[lossIndexMax].value);
                                _MRmax += Cmax * V;
                            }

                        }
                        i += rows[i].childRows.Count;

                    }
                }
            }

            AvrC = _MR / collectionTotalValue;
            AvrCmin = (_MRmin == 0) ? AvrC : _MRmin / collectionTotalValue; ;
            AvrCmax = (_MRmax == 0) ? AvrC : _MRmax / collectionTotalValue; ;
            /*if (_MRmin == 0) { AvrCmin = (AvrC != 0) ? AvrC : 0; }
            else{ AvrCmin = _MRmin / collectionTotalValue; }*/

            if (_MR == 0) { MR = 0; } else { MR = 15 + Math.Log10(AvrC * (B / 100.0) / A); }
            if (_MRmin == 0) { MRmin = 0; } else { MRmin = 15 + Math.Log10(AvrCmin * (Bmin / 100.0) / Amin); }
            if (_MRmax == 0) { MRmax = 0; } else { MRmax = 15 + Math.Log10(AvrCmax * (Bmax / 100.0) / Amax); }
            //Console.WriteLine("MR: " + MR);

        }

        public double getCellValue(List<SingleValue> valueList, string text)
        {
            double value = -1.0;

            try
            {
                value = valueList.Find(x => x.name == text).value;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return -1;
            }

            return value;
        }

        public double getAvrCValue(int i)
        {
            double inne = 0;

            switch (i)
            {
                case 0:
                    return AvrCmin;
                case 1:
                    return AvrC;
                case 2:
                    return AvrCmax;
            }

            return inne;
        }

        public void RefreshFormulas(int rowIndex)
        {
            int lossIndexMin = columns.Find(x => x.name == "CLow").index;
            int lossIndex = columns.Find(x => x.name == "CMid").index;
            int lossIndexMax = columns.Find(x => x.name == "CHigh").index;

            if (rows[rowIndex].cells[lossIndexMin].formula != "") { }

        }

        public double calculateSelectionValue(List<int> lines, List<SingleValue> valueList, int numberIndex)
        {
            double val = 0;
            int valueIndex = columns.Find(x => x.name == "Lista").index;


            foreach (int i in lines)
            {
                if (rows[i].cells[valueIndex].value != null && rows[i].cells[numberIndex].value != null && rows[i].cells[numberIndex].value != "")
                {
                    //Console.WriteLine(i + ": V: " + rows[i].cells[valueIndex].value + " N: " + rows[i].cells[numberIndex].value);
                    val += getCellValue(valueList, rows[i].cells[valueIndex].value) * double.Parse(rows[i].cells[numberIndex].value);
                }
            }

            return val;
        }

        private string randomNameGenerator(int length)
        {
            Random rnd = new Random();
            int liczba;
            char znak;
            string nazwa = "";

            for (int i = 0; i <= length; i++)
            {
                do { liczba = rnd.Next(48, 123); }
                while (liczba < 48 || (liczba > 57 && liczba < 65) || (liczba > 90 && liczba < 97) || liczba > 122);

                znak = (char)liczba;
                nazwa += znak;
            }

            if (!CheckIfNameIsUnique(nazwa))
            {
                nazwa = randomNameGenerator(length);
            }

            return nazwa;
        }

        private bool CheckIfNameIsUnique(string rowName)
        {
            foreach (DgvRow r in rows)
            {
                if (r.name == rowName)
                {
                    return false;
                }
            }

            return true;
        }


        public void Load(DataGridView dgv, Dgv load)
        {

            for (int i = 0; i < load.columns.Count; i++)
            {
                //Console.WriteLine("Column: " +load.columnPropeties.Count);
                DgvColumn column = load.columns[i];

                if (column.type == "System.Windows.Forms.DataGridViewCheckBoxCell")
                {

                    DataGridViewCheckBoxColumn cp = new DataGridViewCheckBoxColumn();
                    cp.HeaderText = column.headerText;
                    cp.Name = column.name;
                    cp.Visible = column.visible;
                    cp.Width = column.width;
                    //if (column.sortable == true) { cp.SortMode = DataGridViewColumnSortMode.Automatic; }
                    //else { cp.SortMode = DataGridViewColumnSortMode.NotSortable; }
                    cp.SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (column.cellStyle == "MiddleCenter") { cp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }

                    dgv.Columns.Add(cp);

                }
                if (column.type == "System.Windows.Forms.DataGridViewTextBoxCell")
                {
                    DataGridViewTextBoxColumn cp = new DataGridViewTextBoxColumn();
                    cp.HeaderText = column.headerText;
                    cp.Name = column.name;
                    cp.Visible = column.visible;
                    cp.Width = column.width;
                    //if (column.sortable == true) { cp.SortMode = DataGridViewColumnSortMode.Automatic; }
                    //else { cp.SortMode = DataGridViewColumnSortMode.NotSortable; }
                    cp.SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (column.cellStyle == "MiddleCenter") { cp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }
                    if (column.valueType == "System.Double") { cp.ValueType = typeof(int); }
                    cp.DefaultCellStyle.Format = column.valueFormat;
                    //if (column.valueType == "System.Int32") { cp.ValueType = typeof(int); }
                    //if (column.valueType == "System.String") { cp.ValueType = typeof(string); }                    

                    dgv.Columns.Add(cp);
                }
                if (column.type == "System.Windows.Forms.DataGridViewComboBoxCell")
                {

                    DataGridViewComboBoxColumn cp = new DataGridViewComboBoxColumn();
                    cp.HeaderText = column.headerText;
                    cp.Name = column.name;
                    cp.Visible = column.visible;
                    cp.Width = column.width;
                    cp.FlatStyle = FlatStyle.Flat;
                    //if (column.sortable == true) { cp.SortMode = DataGridViewColumnSortMode.Automatic; }
                    //else { cp.SortMode = DataGridViewColumnSortMode.NotSortable; }
                    cp.SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (column.cellStyle == "MiddleCenter") { cp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }

                    dgv.Columns.Add(cp);
                }
            }


            for (int i = 0; i < load.rows.Count; i++)
            {
                DgvRow row = load.rows[i];
                dgv.Rows.Add();

                for (int j = 0; j < row.cells.Count; j++)
                {
                    DgvCell cell = row.cells[j];
                    string typ = dgv.Rows[i].Cells[j].GetType().ToString();
                    if (typ == "System.Windows.Forms.DataGridViewCheckBoxCell")
                    {
                        if (cell.value == "True") { (dgv.Rows[i].Cells[j] as DataGridViewCheckBoxCell).Value = true; }
                        else { (dgv.Rows[i].Cells[j] as DataGridViewCheckBoxCell).Value = false; }
                    }
                    else if (typ == "System.Windows.Forms.DataGridViewTextBoxCell")
                    {
                        dgv.Rows[i].Cells[j].Value = cell.value;
                        //if (j == 1) { dgv.Rows[i].Cells[j].Value += " [" + row.name + "]"; }
                    }
                    else if (typ == "System.Windows.Forms.DataGridViewComboBoxCell")
                    {
                        dgv.Rows[i].Cells[j].Value = cell.value;
                    }
                }
            }
        }

        public void Save(DataGridView dgv)
        {
            DgvColumn cp;
            DgvCell dc;
            DgvRow dr;
            name = dgv.Tag.ToString();

            /*foreach (DataGridViewColumn column in dgv.Columns)
            {
                cp = new DgvColumnProperties();
                cp.headerText = column.HeaderText;
                cp.name = column.Name;
                cp.index = column.Index;
                cp.type = column.CellType.ToString();
                cp.visible = column.Visible;
                cp.width = column.Width;
                cp.isDBcol = true;
                if (column.SortMode == DataGridViewColumnSortMode.Automatic) { cp.sortable = true; }
                else { cp.sortable = false; }
                cp.cellStyle = column.DefaultCellStyle.Alignment.ToString();

                columnPropeties.Add(cp);
            }*/

            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dgv.Rows[i];

                dr = new DgvRow();
                dr.isDBrow = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dc = new DgvCell();
                    if (cell.Value != null)
                    {
                        dc.value = cell.Value.ToString();
                    }
                    else { dc.value = ""; }
                    dr.cells.Add(dc);
                }

                rows.Add(dr);
            }
        }

        /// <summary>
        /// Merges currently opened database (this) and imported database
        /// </summary>
        /// <param name="Import">imported db</param>
        /// <param name="addAll">if true all rows will be importedand added at the end of the current DB</param>
        /// <returns></returns>
        public List<DgvRow> MergeDatabases(Dgv Import, bool addAll, Dictionary<int, Dictionary<string, string>> catMap, Dictionary<int, Dictionary<string, string>> iCatMap, Dictionary<int, Dictionary<string, string>> valueMap)
        {
            int SelectID = this.columns.Where(c => c.name == "Select").FirstOrDefault().index;
            int iSelectID = Import.columns.Where(c => c.name == "Select").FirstOrDefault().index;
            int NumberID = this.columns.Where(c => c.name == "Number").FirstOrDefault().index;
            int iNumberID = Import.columns.Where(c => c.name == "Number").FirstOrDefault().index;

            List<DgvRow> result = new List<DgvRow>();
            //map columns from one db to another db            

            if (columns.Count != Import.columns.Count)
            {
                throw new Exception("Liczba kolumn w obu bazach danych jest różna.");
            }

            Dictionary<int, int> Mapping = GetColumnMapping(Import);

            foreach (DgvRow iRow in Import.rows)
            {
                if (!CheckIfNameIsUnique(iRow.name))
                {
                    //if name is not unique we must rename the row and all of the parent children relations before adding the row
                    iRow.name = randomNameGenerator(rowNameLength);
                }

                if (addAll)
                {
                    DgvRow toAdd = ReordeCellsInRow(Mapping, iRow);
                    toAdd.ReMapValues(valueMap);
                    rows.Add(toAdd);
                    result.Add(toAdd);
                }
                else
                {
                    int i = 1;
                    bool theSameRow = false;
                    foreach (DgvRow row in rows)
                    {

                        bool theSameCells = true;
                        //Jeżeli wszystkie są takie same to nie dodajemy
                        for (i = 1; i < row.cells.Count; i++)
                        {

                            if (catMap.ContainsKey(i))
                            {
                                int ind = Mapping[i];
                                string val = catMap[i][row.cells[i].value];
                                string ival = iCatMap[Mapping[i]][iRow.cells[Mapping[i]].value];

                                if (catMap[i][row.cells[i].value] != iCatMap[Mapping[i]][iRow.cells[Mapping[i]].value])
                                {
                                    theSameCells = false;
                                    break;
                                }
                            }
                            else
                            {
                                if (row.cells[i].value != iRow.cells[Mapping[i]].value)
                                {
                                    theSameCells = false;
                                    break;
                                }
                            }
                        }

                        if (theSameCells)
                        {
                            theSameRow = true;
                            break;
                        }
                    }

                    if (!theSameRow)
                    {
                        //ALSO CHNAGE VALUES TO THOSE IN MAIN DB
                        DgvRow toAdd = ReordeCellsInRow(Mapping, iRow);
                        toAdd.ReMapValues(valueMap);
                        //rows.Add(toAdd);
                        //rows.Insert(rows.Count - 2, toAdd);


                        result.Add(toAdd);
                    }
                }

            }

            return result;
        }

        public Dictionary<int, int> GetColumnMapping(Dgv Import)
        {
            Dictionary<int, int> Mapping = new Dictionary<int, int>();

            foreach (DgvColumn column in this.columns)
            {
                DgvColumn iCol = Import.columns.Where(ic => ic.headerText == column.headerText && ic.type == column.type).FirstOrDefault();

                if (iCol != null)
                {
                    Mapping.Add(column.index, iCol.index);
                }
                else
                {
                    throw new Exception("Kolumny w bazach nie są takie same. Np. kolumna " + column.headerText + ".");
                }
            }

            return Mapping;
        }

        public void RemapValues(Dictionary<int, Dictionary<string, string>> valueMap, Dictionary<int, int> columnMapping)
        {
            foreach (DgvRow row in rows)
            {
                ReordeCellsInRow(columnMapping, row);
                row.ReMapValues(valueMap);
            }
        }

        /// <summary>
        /// Returns a dictionary with column internal name and index
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetMappingDictionary(Dgv dgv)
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>();

            foreach (DgvColumn col in dgv.columns)
            {
                mapping.Add(col.name, col.index);
            }

            return mapping;
        }

        private static DgvRow ReordeCellsInRow(Dictionary<int, int> mapping, DgvRow iRow)
        {
            //przepisac zeby operowac na tym ktory jest a nie tworzyć nowego
            DgvRow row = new DgvRow();
            //row.name = iRow.name;
            //row.isDBrow = iRow.isDBrow;
            //row.isARrow = iRow.isARrow;
            //row.parent = iRow.parent;
            //row.childRows = iRow.childRows;

            foreach (KeyValuePair<int, int> d in mapping)
            {
                row.cells.Add(iRow.cells[d.Value]);
            }

            iRow.cells = row.cells;

            return iRow;
        }

        public void AddDataGridViewRows(List<DgvRow> rows, DataGridView dgv)
        {
            foreach (DgvRow row in rows)
            {
                DataGridViewRow newone = (DataGridViewRow)dgv.Rows[0].Clone();
                //Sets values
                for (int i = 0; i < row.cells.Count; i++)
                {
                    newone.Cells[i].Value = row.cells[i].value;
                }

                dgv.Rows.Insert(dgv.Rows.Count - 1, newone);
            }
        }
    }
}
