using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Risk;
using AnarisDLL.BLL.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnarisDLL.BLL.Anaris
{
    [Serializable]
    public class RAToSave
    {
        public List<RiskDgvList> RiskAnalysis { get; set; }
        

        private int rowNameLength = 6;

        public RAToSave()
        {
            RiskAnalysis = new List<RiskDgvList>();
        }

        public void Initialize(RiskCollection RiskList)
        {
            for (int i = 0; i < RiskList.Risks.Count; i++)
            {
                RiskDgvList newRisAn = new RiskDgvList();
                newRisAn.name = RiskList.Risks[i].name;
                RiskAnalysis.Add(newRisAn);
            }
        }

        public void Clone(RAToSave toCopy)
        {
            RiskAnalysis.Clear();
            foreach (RiskDgvList dgvList in toCopy.RiskAnalysis)
            {
                RiskDgvList newList = new RiskDgvList();
                newList.Clone(dgvList);
                RiskAnalysis.Add(newList);
            }

        }

        private Dictionary<int, List<Dgv>> GetDgvToImport(Dictionary<int, List<ElementaryRisk>> iRisk)
        {
            Dictionary<int, List<Dgv>> result = new Dictionary<int, List<Dgv>>();

            foreach (KeyValuePair<int, List<ElementaryRisk>> risk in iRisk)
            {
                List<Dgv> tmp = new List<Dgv>();
                foreach (ElementaryRisk er in risk.Value)
                {
                    Dgv dgv = RiskAnalysis[risk.Key].dgvList.Where(l => l.name == er.Name).FirstOrDefault();
                    tmp.Add(dgv);
                }

                result.Add(risk.Key, tmp);
            }

            return result;
        }

        public void MergeProjects(RAToSave iAnaris, Dictionary<int, List<ElementaryRisk>> iRisks, List<DgvRow> imported, List<DgvRow> missing, Dictionary<int, int> calumnMapping, Dictionary<int, Dictionary<string, string>> valueMapping)
        {
            //childrens are unique to the scenario so in new scnarios we only add db rows

            //first we add rows to main db that are unique in imported DB (we did that in Controller method)
            // we also add these rows (without childrens) to the scenarios
            this.AddRangeOfRows(imported);

            //next we use the same method to get unique rows (UiRows) from main db that are not available in imported db (we did that in Controller method)


            //and we add UiRows rows (also with childrens) to the main dgvs


            //We need to remap original values to the imported values 
            // or add those rows after remaping imported to original bvalues
            iAnaris.AddRangeOfRows(missing);

            //we add new scenarios (dgv) from impoerted that are mapped with iRisks
            Dictionary<int, List<Dgv>> dgvRisks = iAnaris.GetDgvToImport(iRisks);
            foreach (KeyValuePair<int, List<Dgv>> risk in dgvRisks)
            {
                foreach (Dgv sr in risk.Value)
                {
                    sr.RemapValues(valueMapping, calumnMapping);
                    RiskAnalysis[risk.Key].dgvList.Add(sr);
                }
            }
            //ToDo

        }

        public void AddNewScenario(string scenarioName, int riskIndex)
        {
            Dgv newone = new Dgv();
            newone.Clone(this.RiskAnalysis[riskIndex].dgvList[0]);
            newone.name = scenarioName;
            newone.AddRAColumns();
            this.RiskAnalysis[riskIndex].dgvList.Add(newone);
        }

        public void AddScenario(Dgv scenario, int riskIndex)
        {
            this.RiskAnalysis[riskIndex].dgvList.Add(scenario);
        }



        public void AddRows(DgvRow row)
        {
            foreach (RiskDgvList lista in RiskAnalysis)
            {
                foreach (Dgv data in lista.dgvList)
                {
                    data.rows.Add(row);
                }
            }
        }

        public void AddRangeOfRows(List<DgvRow> rows)
        {
            foreach (RiskDgvList lista in RiskAnalysis)
            {
                foreach (Dgv data in lista.dgvList)
                {
                    data.rows.AddRange(rows);
                }
            }
        }

        public void AddRows(bool isDBrow, string name, string parent)
        {
            foreach (RiskDgvList lista in RiskAnalysis)
            {
                foreach (Dgv data in lista.dgvList)
                {
                    data.AddRow(true, name, parent);
                }
            }
        }

        public void AddRows(string parent, int riskIndex)
        {

            string nazwa = randomNameGenerator(rowNameLength, riskIndex);
            int childRows = RiskAnalysis[riskIndex].dgvList[0].rows.Find(x => x.name == parent).childRows.Count;

            foreach (Dgv dgv in RiskAnalysis[riskIndex].dgvList)
            {
                DgvRow row = new DgvRow();
                DgvRow _parRow = dgv.rows.Find(x => x.name == parent);
                int parentIndex = GetRowIndex(dgv, parent);


                List<DgvCell> cells = new List<DgvCell>();
                for (int i = 0; i < dgv.columns.Count; i++)
                {
                    DgvCell nowa = new DgvCell();
                    if (dgv.columns[i].isDBcol == true && i > 0) //&& i < dgv.columnPropeties.Count - 3
                    {
                        nowa.value = _parRow.cells[i].value;
                    }
                    cells.Add(nowa);
                }

                row.cells.AddRange(cells);
                row.name = nazwa;
                row.parent = parent;
                row.isDBrow = false;
                row.isARrow = true;
                _parRow.childRows.Add(row.name);

                int index = parentIndex + childRows + 1;

                dgv.rows.Insert(index, row);
            }
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


        /// <summary>
        /// Removes all rows when DataBase row is removed
        /// </summary>
        /// <param name="rowName">system row name</param>
        public void RmvRows(string rowName)
        {
            foreach (RiskDgvList lista in RiskAnalysis)
            {
                foreach (Dgv dgv in lista.dgvList)
                {
                    //find the row in every tab and every scenario
                    DgvRow row = dgv.rows.Find(x => x.name == rowName);
                    foreach (string child in row.childRows)
                    {
                        //first remove every childrow that this row may have
                        DgvRow childRow = dgv.rows.Find(x => x.name == child);
                        dgv.rows.Remove(childRow);
                    }
                    //finally remove the row
                    dgv.rows.Remove(row);
                }
            }

        }


        public void RmvRows(int index, int riskIndex, string parent)
        {
            string rowName = RiskAnalysis[riskIndex].dgvList[0].rows[index].name;

            foreach (Dgv dgv in RiskAnalysis[riskIndex].dgvList)
            {
                DgvRow _parRow = dgv.rows.Find(x => x.name == parent);
                DgvRow row = dgv.rows.Find(x => x.name == rowName);

                _parRow.childRows.Remove(row.name);
                dgv.rows.Remove(row);
            }

        }

        /// <summary>
        /// Recalculates total value for all Dgv objects in the project
        /// </summary>
        /// <param name="valueList">List from value manager</param>
        public void calculateTotalValue(List<SingleValue> valueList)
        {
            foreach (RiskDgvList lista in RiskAnalysis)
            {

                foreach (Dgv dgv in lista.dgvList)
                {

                    dgv.calculateTotalValue(valueList);
                }
            }

        }

        public void calculateMagnitudeOfRisk(List<SingleValue> valueList, RiskCollection riskList)
        {
            int i = 0;

            foreach (RiskDgvList lista in RiskAnalysis)
            {

                for (int j = 1; j < lista.dgvList.Count; j++)
                {
                    lista.dgvList[j].calculateMagnitudeOfRisk(valueList, riskList, i, j - 1);
                }
                i += 1;
            }
        }

        public void CellValueChanged(string rowName, string colName, string value)
        {
            foreach (RiskDgvList risk in RiskAnalysis)
            {
                foreach (Dgv dgv in risk.dgvList)
                {
                    DgvRow row = dgv.rows.Find(x => x.name == rowName);
                    int rowIndex = GetRowIndex(dgv, rowName);
                    int columnIndex = dgv.columns.Find(x => x.name == colName).index;
                    //Console.WriteLine("coln: " + colName + " rown: " + rowName + " index: " + columnIndex);

                    if (row != null)
                    {
                        int stop = row.childRows.Count + 1;
                        if (colName == "Item" || colName == "Number") { stop = 1; }

                        for (int i = 0; i < stop; i++)
                        {
                            //row.cells[columnIndex].value = value;
                            dgv.rows[rowIndex + i].cells[columnIndex].value = value;
                        }

                        //Console.WriteLine("rows: " + dgv.rows.Count);
                    }
                }
            }

        }

        /// <summary>
        /// Change the value of a cell in all the scenarios depedant to the given risk database
        /// </summary>
        /// <param name="rowName">Cell vertical coordinate</param>
        /// <param name="colName">Cell horisontal coordinate</param>
        /// <param name="value"></param>
        /// <param name="riskIndex"></param>
        public void CellValueChanged(string rowName, string colName, string value, int riskIndex)
        {

            foreach (Dgv dgv in RiskAnalysis[riskIndex].dgvList)
            {
                DgvRow row = dgv.rows.Find(x => x.name == rowName);
                int columnIndex = dgv.columns.Find(x => x.name == colName).index;
                //Console.WriteLine("coln: " + colName + " rown: " + rowName + " index: " + columnIndex);

                if (row != null)
                {
                    row.cells[columnIndex].value = value;
                    //Console.WriteLine("rows: " + dgv.rows.Count);
                }
            }

        }

        /// <summary>
        /// When the number is changed in the main database the fomulas in all data has to be recalculated
        /// </summary>
        /// <param name="rowName"></param>        
        public void RefreshValuesByFormulas(string rowName)
        {
            for (int i = 0; i < RiskAnalysis.Count; i++)//RiskDgvList list in RiskAnalysis)
            {
                //int rowIndex = GetRowIndex(RiskAnalysis[i].dgvList[0], rowName);
                //Console.WriteLine("Rowek Znaleziony: " + RiskAnalysis[i].dgvList[0].rows[rowIndex].cells[1].value);
                RefreshValuesByFormulas(rowName, i);
            }


        }


        /// <summary>
        /// When the number is changed in the risk database the fomulas in dependent data has to be recalculated
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="riskIndex"></param>        
        public void RefreshValuesByFormulas(string rowName, int riskIndex)
        {
            for (int i = 1; i < RiskAnalysis[riskIndex].dgvList.Count; i++)//(Dgv lol in _controller.RAList.RiskAnalysis[tabIndex].dgvList)
            {
                Dgv data = RiskAnalysis[riskIndex].dgvList[i];
                int rowIndex = GetRowIndex(data, rowName);
                //Console.WriteLine("Rowek Znaleziony 2: " + data.rows[rowIndex].cells[1].value + "mijesce: " + data.rows[rowIndex].cells[2].value);
                int IL = data.columns.Find(x => x.name == "CLow").index;
                string FL = data.rows[rowIndex].cells[IL].formula;
                if (!(FL == null || FL == ""))
                {
                    data.rows[rowIndex].cells[IL].value = FL;
                    data.rows[rowIndex].cells[IL].value = data.rows[rowIndex].cells[IL].getValue(data, rowIndex);
                }

                int IM = data.columns.Find(x => x.name == "CMid").index;
                string FM = data.rows[rowIndex].cells[IM].formula;
                if (!(FM == null || FM == ""))
                {
                    data.rows[rowIndex].cells[IM].value = FM;
                    data.rows[rowIndex].cells[IM].value = data.rows[rowIndex].cells[IM].getValue(data, rowIndex);
                }

                int IH = data.columns.Find(x => x.name == "CHigh").index;
                string FH = data.rows[rowIndex].cells[IH].formula;
                if (!(FH == null || FH == ""))
                {
                    data.rows[rowIndex].cells[IH].value = FL;
                    data.rows[rowIndex].cells[IH].value = data.rows[rowIndex].cells[IH].getValue(data, rowIndex);
                }

            }

        }

        public void ColumnHeaderCellChanged(string colName, string header)
        {
            foreach (RiskDgvList risk in RiskAnalysis)
            {
                foreach (Dgv dgv in risk.dgvList)
                {
                    //Console.WriteLine("Modele nazwa: " + dgv.name + ".");
                    dgv.columns.Find(x => x.name == colName).headerText = header;
                }
            }

        }

        public void AddColumns(int dbColumns, DataGridViewColumn column)
        {

            foreach (RiskDgvList risk in RiskAnalysis)
            {

                foreach (Dgv data in risk.dgvList)
                {
                    int columnIndex = dbColumns - 3;

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
                    newColumn.isDBcol = true;

                    data.columns.Insert(columnIndex, newColumn);

                    for (int i = columnIndex + 1; i < data.columns.Count; i++)
                    {
                        data.columns[i].index = i;
                    }

                    foreach (DgvRow r in data.rows)
                    {
                        DgvCell cell = new DgvCell();
                        r.cells.Insert(columnIndex, cell);
                    }

                }
            }

        }

        public void AddColumns(int tabIndex)
        {
            foreach (RiskDgvList list in RiskAnalysis)
            {
                /*foreach (Dgv widok in lista.dgvList)
                {
                    widok.AddRow(true, data.rows[data.rows.Count - 1].name, "");
                }*/
            }
        }

        private string randomNameGenerator(int length, int riskIndex)
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

            foreach (Dgv dgv in RiskAnalysis[riskIndex].dgvList)
            {
                foreach (DgvRow r in dgv.rows)
                {
                    if (r.name == nazwa)
                    {
                        nazwa = randomNameGenerator(length, riskIndex);
                    }
                }
            }

            return nazwa;
        }

        public void Save()
        {
            List<RiskDgvList> SimplifiedRisAn = new List<RiskDgvList>();

            for (int i = 0; i < RiskAnalysis.Count; i++)
            {
                RiskDgvList newRisAn = new RiskDgvList();
                newRisAn.name = RiskAnalysis[i].name;
                SimplifiedRisAn.Add(newRisAn);
            }

            foreach (RiskDgvList lista in RiskAnalysis)
            {
                foreach (Dgv dgv in lista.dgvList)
                {

                }
            }
        }

        internal void Clear()
        {
            foreach (RiskDgvList item in RiskAnalysis)
            {
                item.dgvList.Clear();
                item.name = null;
            }
        }
    }
}
