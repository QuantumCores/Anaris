using ANARIS.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANARIS.BLL.Helpers;
using ANARIS.BLL.Report;

namespace ANARIS
{
    public class ANS_Model
    {
    }


    [Serializable]
    public class RiskCollection
    {
        public List<SingleRisk> Risk { get; set; }

        public RiskCollection()
        {
            Risk = new List<SingleRisk>();
        }

        public void Initialize()
        {
            for (int i = 0; i <= 10; i++)
            {
                SingleRisk nowySi = new SingleRisk();

                if (i == 0) { nowySi.name = "Siły fizyczne"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 1) { nowySi.name = "Przestępstwa"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 2) { nowySi.name = "Ogień"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 3) { nowySi.name = "Woda"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 4) { nowySi.name = "Zagrożenia biologiczne"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 5) { nowySi.name = "Zanieczyszczenia"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 6) { nowySi.name = "Światło i promieniowanie UV"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 7) { nowySi.name = "Niewłaściwa temperatura"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 8) { nowySi.name = "Niewłaściwa wilgotność względna"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 9) { nowySi.name = "Rozproszenie"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }
                if (i == 10) { nowySi.name = "Inne"; nowySi.DistinctiveRisk = new List<ElementaryRisk>(); }

                Risk.Add(nowySi);
            }
        }

        public Dictionary<int, List<ElementaryRisk>> ImportRisks(List<SingleRisk> iRisks)
        {
            Dictionary<int, List<ElementaryRisk>> result = new Dictionary<int, List<ElementaryRisk>>();

            for (int i = 0; i < Risk.Count; i++)
            {
                List<ElementaryRisk> ToImport = new List<ElementaryRisk>();
                string[] Names = Risk[i].DistinctiveRisk.Select(d => d.name).ToArray();

                for (int j = 0; j < iRisks[i].DistinctiveRisk.Count; j++)
                {
                    if (!Names.Contains(iRisks[i].DistinctiveRisk[j].name))
                    {
                        ToImport.Add(iRisks[i].DistinctiveRisk[j]);
                    }
                }

                Risk[i].DistinctiveRisk.AddRange(ToImport);
                result.Add(i, ToImport);

            }

            return result;
        }

        public void Clone(RiskCollection toCopy)
        {
            Risk.Clear();
            foreach (SingleRisk risk in toCopy.Risk)
            {
                SingleRisk newone = new SingleRisk();
                newone.Clone(risk);
                Risk.Add(newone);// tutaj zmienic kopiowqanie
            }
        }

        public RiskCollection CompareManagersData(DataBaseCategories Import)
        {
            RiskCollection delta = new RiskCollection();

            return delta;
        }
    }

    [Serializable]
    public class SingleRisk
    {
        public string name { get; set; }
        public List<ElementaryRisk> DistinctiveRisk { get; set; }
        public bool Print { get; set; }

        public SingleRisk()
        {
            DistinctiveRisk = new List<ElementaryRisk>();
        }

        public void Clone(SingleRisk toCopy)
        {
            DistinctiveRisk.Clear();
            name = toCopy.name;
            Print = toCopy.Print;

            foreach (ElementaryRisk elem in toCopy.DistinctiveRisk)
            {
                ElementaryRisk newone = new ElementaryRisk();
                newone.Clone(elem);
                DistinctiveRisk.Add(elem);
            }
        }

    }

    [Serializable]
    public class ElementaryRisk
    {
        public string name { get; set; }
        public string opis { get; set; }

        public double AHigh { get; set; }
        public double AMid { get; set; }
        public double ALow { get; set; }
        public string opisA { get; set; }

        public double BHigh { get; set; }
        public double BMid { get; set; }
        public double BLow { get; set; }
        public string opisB { get; set; }

        public double CHigh { get; set; }
        public double CMid { get; set; }
        public double CLow { get; set; }
        public string opisC { get; set; }

        public bool Print { get; set; }

        public void Clone(ElementaryRisk toCopy)
        {
            name = toCopy.name;
            opis = toCopy.opis;

            AHigh = toCopy.AHigh;
            AMid = toCopy.AMid;
            ALow = toCopy.ALow;
            opisA = toCopy.opisA;

            BHigh = toCopy.BHigh;
            BMid = toCopy.BMid;
            BLow = toCopy.BLow;
            opisB = toCopy.opisB;

            CHigh = toCopy.CHigh;
            CMid = toCopy.CMid;
            CLow = toCopy.CLow;
            opisC = toCopy.opisC;
        }

    }

    [Serializable]
    public class CategoryCollection
    {
        public DataBaseCategories DBCategories { get; set; }
        public List<ScenarioCategories> Scenario { get; set; }

        public CategoryCollection()
        {
            Scenario = new List<ScenarioCategories>();
        }

        internal void Initialize(RiskCollection RiskList)
        {
            for (int i = 0; i < RiskList.Risk.Count; i++)
            {
                ScenarioCategories newRisAn = new ScenarioCategories();
                newRisAn.name = RiskList.Risk[i].name;
                Scenario.Add(newRisAn);
            }
        }

        internal void Clear()
        {
            if (DBCategories != null) { DBCategories.Clear(); }
            if (Scenario != null) { Scenario.Clear(); }
        }

        internal void UpdateCategories(TreeView catTreeView)
        {
            DBCategories.List.Clear();
            foreach (TreeNode node in catTreeView.Nodes)
            {
                Category nowy = new Category();
                nowy.name = node.Name;
                nowy.text = node.Text;

                if (node.Nodes != null)
                {
                    foreach (TreeNode subnode in node.Nodes)
                    {
                        SubCategory nowySub = new SubCategory();
                        nowySub.name = subnode.Name;
                        nowySub.text = subnode.Text;
                        nowy.subCategories.Add(nowySub);
                    }
                }
                DBCategories.List.Add(nowy);
            }

        }

    }

    [Serializable]
    public class ScenarioCategories
    {
        public List<Category> List { get; set; }
        public string name { get; set; }

        public ScenarioCategories()
        {
            List = new List<Category>();
        }

        internal void UpdateCategories(TreeView catTreeView)
        {
            List.Clear();
            foreach (TreeNode node in catTreeView.Nodes)
            {
                Category nowy = new Category();
                nowy.name = node.Name;
                nowy.text = node.Text;

                if (node.Nodes != null)
                {
                    foreach (TreeNode subnode in node.Nodes)
                    {
                        SubCategory nowySub = new SubCategory();
                        nowySub.name = subnode.Name;
                        nowySub.text = subnode.Text;
                        nowy.subCategories.Add(nowySub);
                    }
                }
                List.Add(nowy);
            }
        }

    }

    [Serializable]
    public class DataBaseValues
    {
        public string ValuesDescription { get; set; }
        public List<SingleValue> valueList { get; set; }

        public DataBaseValues()
        {
            valueList = new List<SingleValue>();
        }

        public void Clone(DataBaseValues toClone)
        {
            ValuesDescription = toClone.ValuesDescription;
            valueList = toClone.valueList.ToList();
        }

        public bool IsNameUnique(string name)
        {
            foreach (SingleValue sv in valueList)
            {
                if (sv.name == name)
                    return false;
            }
            return true;
        }

        public bool IsTextUnique(string text)
        {
            foreach (SingleValue sv in valueList)
            {
                if (sv.text == text)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValues"></param>
        /// <param name="columnMap"></param>
        /// <param name="valueMap"></param>
        /// <returns></returns>
        public Dictionary<int, Dictionary<string, string>> MapDBValues(List<SingleValue> iValues, int valColIndex, Dictionary<int, Dictionary<string, string>> valueMap = null)
        {
            if (valueMap == null)
            {
                valueMap = new Dictionary<int, Dictionary<string, string>>();
            }

            Dictionary<string, string> sMap = GetSubValMap(valueList, iValues);
            valueMap.Add(valColIndex, sMap);

            return valueMap;
        }


        /// <summary>
        /// Maps imported value with main value (iVal => mVal)
        /// </summary>
        /// <param name="subValue"></param>
        /// <param name="iSubValue"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetSubValMap(List<SingleValue> subValue, List<SingleValue> iSubValue)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            Dictionary<string, SingleValue> subNames = subValue.ToDictionary(s => s.text, s => s);

            foreach (SingleValue iSub in iSubValue)
            {
                if (subNames.ContainsKey(iSub.text))
                {
                    dic.Add(iSub.name, subNames[iSub.text].name);
                }

            }

            return dic;
        }


        public DataBaseValues CompareManagersData(DataBaseValues Import)
        {
            DataBaseValues delta = new DataBaseValues();

            return delta;
        }
    }

    //here is the categiry manager object
    [Serializable]
    public class DataBaseCategories
    {
        public List<Category> List { get; set; }


        public DataBaseCategories()
        {
            List = new List<Category>();
        }

        internal void Clear()
        {
            List.Clear();
        }

        internal void Clone(DataBaseCategories toClone)
        {
            List = toClone.List.ToList();
        }

        internal void UpdateCategories(TreeView catTreeView, DataBaseCategories tmpCategories)
        {
            List.Clear();
            for (int i = 0; i < catTreeView.Nodes.Count; i++)
            {
                TreeNode node = catTreeView.Nodes[i];
                Category nowy = new Category();
                nowy.name = node.Name;
                nowy.text = node.Text;
                nowy.description = tmpCategories.List[i].description;

                if (node.Nodes != null)
                {
                    for (int j = 0; j < node.Nodes.Count; j++)
                    {
                        TreeNode subnode = node.Nodes[j];
                        SubCategory nowySub = new SubCategory();
                        nowySub.name = subnode.Name;
                        nowySub.text = subnode.Text;
                        nowySub.description = tmpCategories.List[i].subCategories[j].description;
                        nowy.subCategories.Add(nowySub);
                    }
                }
                List.Add(nowy);
            }
        }

        /// <summary>
        /// Maps category name with category text foreach column
        /// </summary>
        /// <param name="Categories"></param>
        /// <param name="columnMap"></param>
        /// <returns></returns>
        public static Dictionary<int, Dictionary<string, string>> MapCategories(DataBaseCategories Categories, Dictionary<string, int> columnMap)
        {
            Dictionary<int, Dictionary<string, string>> mapping = new Dictionary<int, Dictionary<string, string>>();

            foreach (Category cat in Categories.List)
            {
                Dictionary<string, string> sMap = GetSubCatMap(cat.subCategories);
                mapping.Add(columnMap[cat.name], sMap);
            }

            return mapping;
        }

        private static Dictionary<string, string> GetSubCatMap(List<SubCategory> sCats)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (SubCategory cat in sCats)
            {
                dic.Add(cat.name, cat.text);
            }

            return dic;
        }

        /// <summary>
        /// Maps all values for each column (mColID, (iVal, mVal))
        /// </summary>
        /// <param name="iCategeries"></param>
        /// <param name="columnMap"></param>
        /// <returns></returns>
        public Dictionary<int, Dictionary<string, string>> MapValues(DataBaseCategories iCategeries, Dictionary<string, int> columnMap)
        {

            Dictionary<int, Dictionary<string, string>> mapping = new Dictionary<int, Dictionary<string, string>>();
            //string[] catNames = this.List.Select(c => c.text).ToArray();
            Dictionary<string, Category> catNames = this.List.ToDictionary(c => c.text, c => c);

            foreach (Category iCat in iCategeries.List)
            {
                if (catNames.ContainsKey(iCat.text))
                {
                    Dictionary<string, string> sMap = GetSubValMap(catNames[iCat.text].subCategories, iCat.subCategories);
                    mapping.Add(columnMap[catNames[iCat.text].name], sMap);
                }
            }

            return mapping;
        }


        /// <summary>
        /// Maps imported value with main value (iVal => mVal)
        /// </summary>
        /// <param name="subCategories"></param>
        /// <param name="iSubCategories"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetSubValMap(List<SubCategory> subCategories, List<SubCategory> iSubCategories)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            Dictionary<string, SubCategory> subNames = subCategories.ToDictionary(s => s.text, s => s);


            foreach (SubCategory iSub in iSubCategories)
            {
                if (subNames.ContainsKey(iSub.text))
                {
                    dic.Add(iSub.name, subNames[iSub.text].name);
                }

            }

            return dic;
        }

        public DataBaseCategories CompareManagersData(DataBaseCategories Import)
        {
            DataBaseCategories delta = new DataBaseCategories();

            return delta;
        }
    }

    [Serializable]
    public class Category
    {
        public string text { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        //public List<Category> Categories { get; set; }
        public List<SubCategory> subCategories { get; set; }

        public Category()
        {
            subCategories = new List<SubCategory>();
        }
    }

    [Serializable]
    public class SubCategory
    {
        public string text { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    [Serializable]
    public class SingleValue
    {
        public string text { get; set; }
        public string name { get; set; }
        public double value { get; set; }
        public string description { get; set; }
    }

    /*[Serializable]
    public class DataBaseToSave
    {
        public List<SingleValue> valueList { get; set; }
    }*/

    #region CLASS FOR SAVE DATAGRIDVIEW

    [Serializable]
    public class DgvColumn
    {
        public string name { get; set; }
        public string headerText { get; set; }
        public int index { get; set; }
        public string type { get; set; }
        public bool visible { get; set; }
        public int width { get; set; }
        public bool sortable { get; set; }
        public string cellStyle { get; set; }
        public string valueType { get; set; } //?
        public string valueFormat { get; set; }
        public bool isDBcol { get; set; }
        public bool isARcol { get; set; }


        internal void Clone(DgvColumn column)
        {
            name = column.name;
            headerText = column.headerText;
            index = column.index;
            type = column.type;
            visible = column.visible;
            width = column.width;
            sortable = column.sortable;
            cellStyle = column.cellStyle;
            valueType = column.valueType;
            valueFormat = column.valueFormat;
            isDBcol = column.isDBcol;
            isARcol = column.isARcol;
        }
    }


    [Serializable]
    public class DgvCell
    {
        public string value { get; set; }
        public string formula { get; set; }
        private bool block { get; set; }


        public string getValue(Dgv data, int rowIndex)
        {
            bool isok = true;
            double _value = 0;

            if (value.Contains("="))
            {
                block = true;
                //Console.WriteLine("ANS In val: " + value);
                _value = executeFormula(data, value, rowIndex);
                if (_value == -1) { value = ""; }
                else { formula = value; value = _value.ToString(); }
                //Console.WriteLine("ANS form: " + formula + ", val: " + value);
            }
            else
            {
                if (!block) { formula = ""; }
                isok = double.TryParse(value, out _value);
                if (isok == false) { value = ""; }
                block = false;
                //Console.WriteLine("ANS zmieniłem form na _");
            }

            return value;
        }

        private double executeFormula(Dgv data, string formula, int rowIndex)
        {
            double result = 0;

            try
            {
                int start = formula.IndexOf("[") + 1;
                int stop = formula.IndexOf("]");

                //Console.WriteLine("P: " + start + "K: " + stop);

                string colName = formula.Substring(start, stop - start);

                //Console.WriteLine("Name: " + colName);
                //Console.WriteLine(data.columnPropeties.Count);
                DgvColumn col = data.columns.Find(x => x.headerText == colName);

                int colIndex = data.columns.Find(x => x.headerText == colName).index;
                double valA = double.Parse(data.rows[rowIndex].cells[colIndex].value);

                start = formula.IndexOf("*") + 1;
                //Console.WriteLine("Rest: " + formula.Substring(start));
                double valB = double.Parse(formula.Substring(start));
                //Console.WriteLine("valA: " + valA + ", valB: " + valB);

                result = valA * valB;

                return result;
            }
            catch
            { return -1; }
        }
    }

    [Serializable]
    public class DgvRow
    {
        public bool isDBrow { get; set; }
        public bool isARrow { get; set; }
        public string name { get; set; }
        public string parent { get; set; }
        public List<string> childRows { get; set; }
        public List<DgvCell> cells { get; set; }

        private double partialRisk { get; set; }
        private double partialRiskMin { get; set; }
        private double partialRiskMax { get; set; }

        public DgvRow()
        {
            cells = new List<DgvCell>();
            childRows = new List<string>();
        }

        public void Clone(DgvRow row)
        {
            isDBrow = row.isDBrow;
            isARrow = row.isARrow;
            name = row.name;
            parent = row.parent;

            childRows.Clear();
            foreach (string child in row.childRows)
            {
                childRows.Add(child);
            }

            cells.Clear();
            foreach (DgvCell cell in row.cells)
            {
                DgvCell newCell = new DgvCell();
                newCell.value = cell.value;
                newCell.formula = cell.formula;
                cells.Add(newCell);
            }
        }

        public void ReMapValues(Dictionary<int, Dictionary<string, string>> valueMapping)
        {
            for (int i = 1; i < cells.Count; i++)
            {
                if (valueMapping.ContainsKey(i))
                {
                    DgvCell cell = cells[i];
                    if (cell.value != null)
                    {
                        cell.value = valueMapping[i][cell.value];
                    }
                }
            }
        }
    }

    [Serializable]
    public class Dgv
    {
        public string name { get; set; }
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

        internal void AddRAColumns()
        {
            int columnIndex = columns.Count;
            //Console.WriteLine("Name: " + name + ", przed dodaniem celi jest: " + rows[1].cells.Count);

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
                //newColumn.valueType = "System.String";
                //newColumn.valueFormat = "N2";
                newColumn.isDBcol = false;

                columns.Add(newColumn);
                //Console.WriteLine("Index" + columnIndex + "columnProp: " + columnPropeties.Count);

                /*for (int j = columnIndex + 1; j < columnPropeties.Count; j++)
                {
                    columnPropeties[j].index = i;
                }*/

                foreach (DgvRow r in rows)
                {
                    DgvCell cell = new DgvCell();
                    r.cells.Add(cell);
                }

                //Console.WriteLine("Row:" + rows[1].name + ", col index: " + newColumn.index + ", cells: " + rows[1].cells.Count);
            }
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

        //Funkcja jest wywoływana tylko jak zaczynamy nowy projekt bez wczytania bazy danych
        //Jest wywoływana z DataBaseDesigner i AnarisProject
        public void InitializeDataFromGrid(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                AddRow(true, "");
                //Console.WriteLine("Dodałem rowek");

            }

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                AddColumn(i, dgv.Columns[i]);
                //Console.WriteLine("Dodałem kolumne: " + i);
            }

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
            Amin = riskList.Risk[riskIndex].DistinctiveRisk[distIndex].ALow;
            Bmin = riskList.Risk[riskIndex].DistinctiveRisk[distIndex].BLow;

            lossIndex = columns.Find(x => x.name == "CMid").index;
            A = riskList.Risk[riskIndex].DistinctiveRisk[distIndex].AMid;
            B = riskList.Risk[riskIndex].DistinctiveRisk[distIndex].BMid;

            lossIndexMax = columns.Find(x => x.name == "CHigh").index;
            Amax = riskList.Risk[riskIndex].DistinctiveRisk[distIndex].AHigh;
            Bmax = riskList.Risk[riskIndex].DistinctiveRisk[distIndex].BHigh;

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

        public void Sort(string columnName, DataBaseCategories dbCategories, List<SingleValue> valueList, bool sortOrder)
        {
            int columnIndex = columns.Find(x => x.name == columnName).index;
            int comparison = 1;
            int N = rows.Count;

            do
            {
                for (int i = 0; i < rows.Count - 1; i++)
                {
                    //Console.WriteLine(i);
                    comparison = compareCellValues(columnName, rows[i].cells[columnIndex].value, rows[i + 1].cells[columnIndex].value, dbCategories, valueList);
                    if (sortOrder == false) { comparison = -comparison; }
                    if (comparison > 0)
                    {
                        //Console.Write("Change");
                        //Console.WriteLine("_______________________________");
                        DgvRow change = new DgvRow();
                        change.Clone(rows[i + 1]);
                        rows[i + 1].Clone(rows[i]);
                        rows[i].Clone(change);
                    }

                }
                N -= 1;
            } while (N > 1);

        }

        private int compareCellValues(string colName, string valA, string valB, DataBaseCategories dbCategories, List<SingleValue> valueList)
        {
            int change = 0;
            double A = 0;
            double B = 0;

            if (colName.Contains("CAT_"))
            {
                change = string.Compare(dbCategories.List.Find(x => x.name == colName).subCategories.Find(x => x.name == valA).text, dbCategories.List.Find(x => x.name == colName).subCategories.Find(x => x.name == valB).text, true);
                //Console.WriteLine("ti  : " + valA + ": " + dbCategories.List.Find(x => x.name == colName).subCategories.Find(x => x.name == valA).text);
                //Console.WriteLine("ti+1: " + valB + ": " + dbCategories.List.Find(x => x.name == colName).subCategories.Find(x => x.name == valB).text);
            }
            else if (colName.Contains("CLow") || colName.Contains("CMid") || colName.Contains("CHigh") || colName.Contains("Number"))
            {
                if (valA == "" || valA == null) { A = 0; }
                else { A = double.Parse(valA); }
                if (valB == "" || valB == null) { B = 0; }
                else { B = double.Parse(valB); }

                if (A < B) { change = -1; }
                else if (A == B) { change = 0; }
                else /*(double.Parse(valA) > double.Parse(valB))*/ { change = 1; }

                //Console.WriteLine("i  : " + A);
                //Console.WriteLine("i+1: " + B);
            }
            else if (colName == "Lista")
            {
                if (valA == "" || valA == null) { A = 0; }
                else { A = getCellValue(valueList, valA); }
                if (valB == "" || valB == null) { B = 0; }
                else { B = getCellValue(valueList, valB); }

                if (A < B) { change = -1; }
                else if (A == B) { change = 0; }
                else /*(double.Parse(valA) > double.Parse(valB))*/ { change = 1; }

                //Console.WriteLine("i  : " + valA + ": " + A);
                //Console.WriteLine("i+1: " + valB + ": " + B);
            }
            else
            {
                change = string.Compare(valA, valB, true);
                //Console.WriteLine("i  : " + valA);
                //Console.WriteLine("i+1: " + valB);
            }


            return change;
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

                dgv.Rows.Insert(dgv.Rows.Count-1,newone);
            }
        }
    }

    [Serializable]
    public class DBToSave
    {
        public string programVersion { get; set; }
        public dbBasicInfo basicInformation { get; set; }

        public Dgv dgv { get; set; }
        public DataBaseValues valueManager { get; set; }
        public DataBaseCategories categoryManager { get; set; }
        public RiskCollection riskManager { get; set; }


        public DBToSave()
        {
            dgv = new Dgv();
        }

        public DBToSave CompareManagersData(DBToSave Import)
        {
            DBToSave Delta = new DBToSave();

            //Delta will contain only diferences between Import and current DB
            //If diferences are detected import won't be possible and manual manipuation will have to be performed

            return Delta;
        }
    }

    [Serializable]
    public class dbBasicInfo
    {
        public string dbName { get; set; }
        public string dbFileName { get; set; }
        public List<string> dbAuthorsList { get; set; }
        public string dbDirrectory { get; set; }
        public string dbOrganisationName { get; set; }
        public string dbMuseumName { get; set; }
        public string dbMuseumAdres { get; set; }

        public dbBasicInfo()
        {
            dbAuthorsList = new List<string>();
        }

        internal void Clear()
        {
            dbName = "";
            dbFileName = "";
            dbAuthorsList.Clear();
            dbDirrectory = "";
            dbOrganisationName = "";
            dbMuseumName = "";
            dbMuseumAdres = "";
        }

        public void setBasicInfo(dbBasicInfo info)
        {
            dbName = info.dbName;
            dbFileName = info.dbFileName;
            dbAuthorsList.Clear();
            dbAuthorsList.AddRange(info.dbAuthorsList);
            dbDirrectory = info.dbDirrectory;
            dbOrganisationName = info.dbOrganisationName;
            dbMuseumName = info.dbMuseumName;
            dbMuseumAdres = info.dbMuseumAdres;
        }

        public List<string> formatAuthorsString(string authors)
        {
            string[] AuthorsList = authors.Split(';');

            for (int i = 0; i < AuthorsList.Count(); i++)
            {
                string help = AuthorsList[i];
                string author = ClearSpaces(help);

                string[] names = author.Split(' ');
                string newAuthor = "";
                for (int j = 0; j < names.Count() - 1; j++)
                {
                    if (names[j] != "")
                    {
                        string name = ClearSpaces(names[j]);
                        newAuthor += name + " ";
                    }
                }
                newAuthor += names[names.Count() - 1];
                AuthorsList[i] = newAuthor;
            }
            return AuthorsList.ToList();
        }

        private string ClearSpaces(string author)
        {
            char znakk = author[author.Length - 1];
            char znako = author[0];
            while (znakk == (char)32)
            {
                string nowy = author.Substring(0, author.Length - 1);
                author = nowy;
                znakk = author[author.Length - 1];
            }

            while (znako == (char)32)
            {
                string nowy = author.Substring(1, author.Length - 1);
                author = nowy;
                znako = author[0];
            }
            return author;
        }
    }

    [Serializable]
    public class RiskDgvList
    {
        //public Dgv RiskDataBase { get; set; }
        public List<Dgv> dgvList { get; set; } // zbiór dgv dla danaego ryzyka, każde odpowida jakiemuś scenariuszowi
        public string name { get; set; } // nazwa ryzyka np. siły fizyczne


        public RiskDgvList()
        {
            dgvList = new List<Dgv>();
        }

        public void Clone(RiskDgvList toCopy)
        {
            name = toCopy.name;
            dgvList.Clear();

            foreach (Dgv dgv in toCopy.dgvList)
            {
                Dgv newDgv = new Dgv();
                newDgv.Clone(dgv);
                dgvList.Add(newDgv);
            }

        }

        public void AddDB(Dgv DB)
        {
            dgvList.Add(DB);
        }

        public void MoveUp(int i)
        {
            Dgv change = dgvList[i - 1];
            dgvList[i - 1] = dgvList[i];
            dgvList[i] = change;
        }

        public void MoveDown(int i)
        {
            Dgv change = dgvList[i + 1];
            dgvList[i + 1] = dgvList[i];
            dgvList[i] = change;
        }
    }

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
            for (int i = 0; i < RiskList.Risk.Count; i++)
            {
                RiskDgvList newRisAn = new RiskDgvList();
                newRisAn.name = RiskList.Risk[i].name;
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
                    Dgv dgv = RiskAnalysis[risk.Key].dgvList.Where(l => l.name == er.name).FirstOrDefault();
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

    [Serializable]
    public class ProjectProperties
    {
        public string projectName { get; set; }
        public string programVersion { get; set; }
        public string filePath { get; set; }
        public DateTime creationTime { get; set; }
        public DateTime modifiedTime { get; set; }
        public List<Author> Authors { get; set; }
        public List<Author> RiskTeam { get; set; }
        public List<Author> External { get; set; }
        public List<Author> Other { get; set; }
        public Organization Organization { get; set; }
        public string Scope { get; set; }
        public string ReportIntro { get; set; }

        public string Today
        {
            get
            {
                DateTime now = DateTime.Now;
                return string.Format("{0} {1} {2}", now.Day, now.GetPolishMonthInBiernik(), now.Year);
            }
        }
        public string AuthorsAsString
        {
            get
            {
                return string.Join(", ", Authors.Select(a => a.FullName));
            }
        }

        public string ContributorsAsString
        {
            get
            {
                return string.Join(", ", RiskTeam.Select(a => a.FullName));
            }
        }

        public ProjectProperties()
        {
            Authors = new List<Author>();
            RiskTeam = new List<Author>();
            External = new List<Author>();
            Other = new List<Author>();
            Organization = new Organization();
        }

        internal void Clear()
        {
            projectName = "";
            programVersion = "";
            filePath = "";
            creationTime = DateTime.Now;
            modifiedTime = DateTime.Now;
            Authors.Clear();
            Organization = new Organization();
        }

        public void Clone(ProjectProperties toCopy)
        {
            projectName = toCopy.projectName;
            programVersion = toCopy.programVersion;
            filePath = toCopy.filePath;
            creationTime = new DateTime(toCopy.creationTime.Year, toCopy.creationTime.Month, toCopy.creationTime.Day, toCopy.creationTime.Hour, toCopy.creationTime.Minute, toCopy.creationTime.Second);
            modifiedTime = new DateTime(toCopy.modifiedTime.Year, toCopy.modifiedTime.Month, toCopy.modifiedTime.Day, toCopy.modifiedTime.Hour, toCopy.modifiedTime.Minute, toCopy.modifiedTime.Second);
            Scope = toCopy.Scope;
            Organization.Clone(toCopy.Organization);
            ReportIntro = toCopy.ReportIntro;

            Authors = toCopy.Authors.ToList();
            //foreach (Author author in toCopy.Authors)
            //{
            //    Author newone = new Author();
            //    newone.Clone(author);
            //    this.Authors.Add(newone);
            //}
            RiskTeam = toCopy.RiskTeam.ToList();
        }

    }

    [Serializable]
    public class ProjectToSave
    {
        public ProjectProperties Properties { get; set; }
        public DBToSave DataBase { get; set; }
        public RAToSave RiskAnalysis { get; set; }
        public ReportSettings ReportSettings { get; set; }


        public void Initialize(RiskCollection RiskList)
        {
            for (int i = 0; i <= RiskList.Risk.Count; i++)
            {
                RiskDgvList newRisAn = new RiskDgvList();
            }
        }
    }

    #endregion

    #region CLASS FOR CHARTS
    public class tornadoPoints
    {
        public string name { get; set; }
        public double Aval { get; set; }
        public double Bval { get; set; }
        public double Cval { get; set; }
        public double Tval { get; set; }
        public double Tlow { get; set; }
        public double Thigh { get; set; }
    }

    public class tornadoChartSeries
    {
        public List<tornadoPoints> series { get; set; }

        public tornadoChartSeries()
        {
            series = new List<tornadoPoints>();
        }
    }

    #endregion
    #region REPORT MODELS
    public class ReportProperties
    {
        public float FontSize_Title = 24;
        public float FontSize_Chapter = 16;
        public float FontSize_SubChapter = 14;
        public float FontSize_Text = 12;
    }

    public class Report
    {
        ReportProperties Properties = new ReportProperties();

        public Report()
        { }

        public void generateReport(RichTextBox ReportTxt, ProjectToSave Project, List<Bitmap> ListOfImages)
        {
            ReportTxt.Font = new Font("Consolas", Properties.FontSize_Text);
            //richTextBox1.BackColor = Color.AliceBlue;
            //string[] words = { "Dot", "Net", "Perls", "is", "a", "nice", "website." };
            //Color[] colors = { Color.Aqua, Color.CadetBlue, Color.Cornsilk, Color.Gold, Color.HotPink, Color.Lavender, Color.Moccasin };


            FirstPageContent(ReportTxt, Properties, Project);
            TableOfContext(ReportTxt, Properties, Project);
            DatabaseContent(ReportTxt, Properties, Project, ListOfImages);
            ChapterContent(ReportTxt, Properties, Project);
            SummaryContent(ReportTxt, Properties, Project, ListOfImages);

            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Bold);
            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Underline);
            ReportTxt.AppendText("\n\n\n");


        }

        static void FirstPageContent(RichTextBox ReportTxt, ReportProperties Properties, ProjectToSave Project)
        {
            ReportTxt.SelectionAlignment = HorizontalAlignment.Center;
            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Title, FontStyle.Bold);
            ReportTxt.AppendText("\n\n\nOcena ryzyka \n\n\n");

            if (!string.IsNullOrWhiteSpace(Project.Properties.Scope))
            {
                ReportTxt.SelectionAlignment = HorizontalAlignment.Center;
                ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Bold);
                ReportTxt.AppendText(Project.Properties.Scope + "\n\n");
            }

            ReportTxt.SelectionAlignment = HorizontalAlignment.Center;
            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Bold);
            ReportTxt.AppendText(Project.Properties.Organization.Name + "\n\n");
            if (Project.Properties.Authors.Count != 0)
            {
                ReportTxt.AppendText("Opracowanie raportu: ");
                string tmpAuthors = string.Join(", ", Project.Properties.Authors.Select(a => a.FullName));
                ReportTxt.AppendText(tmpAuthors + "\n");

                ReportTxt.AppendText("Zespół ds. oceny ryzyka: ");
                tmpAuthors = string.Join(", ", Project.Properties.Authors.Select(a => a.FullName));
                ReportTxt.AppendText(tmpAuthors + "\n\n\n\n\n\n\n");

            }
            //ReportTxt.SelectedRtf = @"{\rtf1 \par \page}";
            string month = string.Empty;
            switch (DateTime.Now.Month)
            {
                case 1:
                    month = "stycznia";
                    break;
                case 2:
                    month = "lutego";
                    break;
                case 3:
                    month = "marca";
                    break;
                case 4:
                    month = "kwietnia";
                    break;
                case 5:
                    month = "maja";
                    break;
                case 6:
                    month = "czerwca";
                    break;
                case 7:
                    month = "lipca";
                    break;
                case 8:
                    month = "sierpnia";
                    break;
                case 9:
                    month = "września";
                    break;
                case 10:
                    month = "paźdzernika";
                    break;
                case 11:
                    month = "listopada";
                    break;
                case 12:
                    month = "grudnia";
                    break;
                default:
                    month = "stycznia";
                    break;

            }

            ReportTxt.AppendText(string.Format("Kraków {0} {1} {2}", DateTime.Now.Day, month, DateTime.Now.Year));
            ReportTxt.AppendText("\n\n\n\n\n\n\n\n\n\n\n");
        }

        static void TableOfContext(RichTextBox ReportTxt, ReportProperties Properties, ProjectToSave Project)
        {
            ReportTxt.SelectionAlignment = HorizontalAlignment.Left;
            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Bold);
            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Underline);
            ReportTxt.AppendText("  Spis treści\n\n");

            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Bold);
            ReportTxt.AppendText("  " + 1 + ".  " + "Zasób dziedzictwa będący przedmiotem oceny \n");

            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Bold);
            ReportTxt.AppendText("  " + 2 + ".  " + "Analiza ryzyka \n");

            for (int i = 0; i < Project.RiskAnalysis.RiskAnalysis.Count; i++)
            {
                ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Regular);
                ReportTxt.AppendText("   " + 2 + "." + (i + 1) + ".  " + Project.RiskAnalysis.RiskAnalysis[i].name + "\n");

                for (int j = 1; j < Project.RiskAnalysis.RiskAnalysis[i].dgvList.Count; j++)
                {
                    if (i < 9) { ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Regular); ReportTxt.AppendText("  "); }
                    ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Text, FontStyle.Regular);
                    ReportTxt.AppendText("  " + 2 + "." + (i + 1) + "." + j + ".  " + Project.RiskAnalysis.RiskAnalysis[i].dgvList[j].name + "\n");
                }
            }

            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Bold);
            ReportTxt.AppendText("  " + 3 + ".  " + "Ewaluacja ryzyka\n");

            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Bold);
            ReportTxt.AppendText("  " + 4 + ".  " + "Wnioski \n");

            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Bold);
            ReportTxt.AppendText("  " + 5 + ".  " + "Index \n");
        }

        static void DatabaseContent(RichTextBox ReportTxt, ReportProperties Properties, ProjectToSave Project, List<Bitmap> ListOfImages)
        {
            ReportTxt.AppendText("\n\n\n");
            ReportTxt.SelectionAlignment = HorizontalAlignment.Left;
            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Bold);
            ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Underline);
            ReportTxt.AppendText("  Zasób dziedzictwa będący przedmiotem oceny\n\n");

            ReportTxt.AppendText("Charakterystyka ogólna bazy danych: \n");


            int ni = Project.DataBase.dgv.columns.Find(x => x.name == "Number").index;

            ReportTxt.AppendText("Baza danych zawiera " + Project.DataBase.dgv.collectionTotalNumber.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + " obiektów ");
            ReportTxt.AppendText("podzielonych na " + Project.DataBase.dgv.rows.Count + " grup obiektów, których wartość " +
                "zgodnie z tabelą wartości* wynosi " + Project.DataBase.dgv.collectionTotalValue.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) + " jednostek. \n\n");


            int i = 0;
            foreach (Category cat in Project.DataBase.categoryManager.List)
            {
                ReportTxt.AppendText("Zasób dziedzictwa będący przedmiotem oceny podzielono również ze względu na ");
                ReportTxt.AppendText(cat.text + ".\n");

                Dictionary<string, double> ItemsSplitByCategory = PieChartHelper.LoadDataByCategoryValue(Project.DataBase.dgv, Project.DataBase.categoryManager, cat.name, Project.DataBase.valueManager.valueList);
                foreach (KeyValuePair<string, double> entry in ItemsSplitByCategory)
                {
                    ReportTxt.AppendText(" -" + entry.Key + " - " + entry.Value + "\n");
                }

                ReportTxt.AppendText("\n\n");
                //Clipboard.SetImage(ListOfImages[i+1]);
                //ReportTxt.Paste();
                i++;
            }

        }

        static void SummaryContent(RichTextBox ReportTxt, ReportProperties Properties, ProjectToSave Project, List<Bitmap> ListOfImages)
        {
            ReportTxt.AppendText("\n\n\n");
            ReportTxt.SelectionAlignment = HorizontalAlignment.Center;
            Clipboard.SetImage(ListOfImages[0]);
            ReportTxt.Paste();
        }

        static void ChapterContent(RichTextBox ReportTxt, ReportProperties Properties, ProjectToSave Project)
        {
            foreach (SingleRisk single in Project.DataBase.riskManager.Risk)
            {
                ReportTxt.AppendText("\n\n\n");
                ReportTxt.SelectionAlignment = HorizontalAlignment.Left;
                //ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Bold);
                ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_Chapter, FontStyle.Underline);
                ReportTxt.AppendText("  " + single.name + "\n\n");

                foreach (ElementaryRisk element in single.DistinctiveRisk)
                {
                    ReportTxt.SelectionFont = new Font("Consolas", Properties.FontSize_SubChapter, FontStyle.Regular);
                    ReportTxt.AppendText(" " + element.name + "\n");

                    ReportTxt.AppendText("  Opis ryzyka:\n" + "  " + element.opis + "\n");

                    ReportTxt.AppendText("  Charakterystyka ryzyka:\n");
                    ReportTxt.AppendText("   opis składowej A: " + element.opisA + "\n");
                    ReportTxt.AppendText("   opis składowej B: " + element.opisB + "\n");
                    ReportTxt.AppendText("   opis składowej C: " + element.opisC + "\n");
                    ReportTxt.AppendText("   Wynik A: " + element.AMid + " B: " + element.BMid + " C: " + element.CMid);

                    ReportTxt.AppendText("\n\n\n");
                }

            }

        }


    }



    public class Chapter
    {
        int depth { get; set; } //np. 0-pierwsza strona, 1-rozdział, 2-podrozdział itp.
        string Title { get; set; }
        string Content { get; set; }

    }

    #endregion
    #region CLASS FOR PROGRAMER MAITANANCE

    public class LogsTable
    {
        public List<string> LogEntry { get; set; }

        public LogsTable()
        {
            LogEntry = new List<string>();
        }

    }

    #endregion
}
