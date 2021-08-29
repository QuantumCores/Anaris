using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using ANARIS.BLL;
using ANARIS.BLL.Load;
using System.Diagnostics;
using System.Xml;
using ANARIS.BLL.Report;

namespace ANARIS
{
    public class ANS_Controller
    {
        MainWindow view;

        ANS_Model model;
        string programVersion = "";

        //private List<string> RC_BaseRisks = new List<string>() { "Siły fizyczne", "Przestępstwa", "Ogień", "Woda", "Zagrożenia biologiczne", "Zanieczyszczenia", "Światło i promieniowanie UV", "Niewłaściwa temperatura", "Niewłaściwa wilgotność względna", "Rozproszenie", "Inne" };
        private List<string> RC_BaseRisks = new List<string>();
        public DataBaseValues dbValues = new DataBaseValues();
        public DataBaseCategories dbCategories = new DataBaseCategories();
        public CategoryCollection allCategories = new CategoryCollection();
        public RiskCollection RC_Tabele = new RiskCollection();
        public dbBasicInfo dbBasicInfo = new dbBasicInfo();
        public ProjectProperties arBasicInfo = new ProjectProperties();
        public RAToSave RAList = new RAToSave();
        public Dgv DB = new Dgv();
        public ReportSettings rs = new ReportSettings();

        public LogsTable _log = new LogsTable();

        public string filePath = "";
        public int DBLoadStatus = 0;
        public int ARLoadStatus = 0;

        //forms
        public AnarisProject anarisProject;
        public DataBaseDesigner newDataBase;
        internal RiskManager riskManager;
        internal ValueManager valueManager;
        internal CategoryTree categoryManager;
        internal TornadoChart tornadoChart;
        internal ThresholdChart thresholdChart;
        internal ValuePieChart valuePieChart;
        internal ReportForm reportManager;
        internal PropertiesAR propertiesAR;

        public LogEntries logWindow = new LogEntries();



        public ANS_Controller(ANS_Model _model, MainWindow _view, string version)
        {
            model = _model;
            view = _view;

            programVersion = version;

            view.setController(this);
            RC_Tabele.Initialize();
            foreach (SingleRisk siris in RC_Tabele.Risk)
            {
                RC_BaseRisks.Add(siris.name);
            }
            RAList.Initialize(RC_Tabele);
            DB.name = "DB";
            allCategories.Initialize(RC_Tabele);
            logWindow.setController(this);


        }

        #region Controller for MainWindow

        public void newDataBaseProject(MainWindow okno)
        {
            newDataBase = new DataBaseDesigner();
            newDataBase.setController(this);
            newDataBase.MdiParent = okno;
            newDataBase.Show();
            newDataBase.InitializeGrid();
            setNewValues(newDataBase.dataGridView1);
        }

        public void newAnarisProject(MainWindow okno)
        {
            anarisProject = new AnarisProject(RC_BaseRisks);
            anarisProject.setController(this);
            anarisProject.MdiParent = okno;
            anarisProject.Show();
            anarisProject.InitializeGrid();
            setNewValues(anarisProject.dataGridView1);
        }

        public void openDataBaseProject(MainWindow okno)
        {
            newDataBase = new DataBaseDesigner();
            newDataBase.setController(this);
            newDataBase.MdiParent = okno;
            for (int i = newDataBase.dataGridView1.ColumnCount - 1; i >= 0; i--)
            {
                newDataBase.dataGridView1.Columns.RemoveAt(i);
            }

            newDataBase.Show();
        }

        public void openAnarisProject(MainWindow okno)
        {
            anarisProject = new AnarisProject(RC_BaseRisks);
            anarisProject.setController(this);
            anarisProject.MdiParent = okno;
            for (int i = anarisProject.dataGridView1.ColumnCount - 1; i >= 0; i--)
            {
                anarisProject.dataGridView1.Columns.RemoveAt(i);
            }

            anarisProject.Show();
        }

        public void ClearData()
        {
            List<string> RC_BaseRisks = new List<string>();
            dbValues = new DataBaseValues();
            dbCategories = new DataBaseCategories();
            allCategories = new CategoryCollection();
            RC_Tabele = new RiskCollection();
            dbBasicInfo = new dbBasicInfo();
            arBasicInfo = new ProjectProperties();
            RAList = new RAToSave();
            DB = new Dgv();
            rs = new ReportSettings();



            RC_Tabele.Initialize();
            foreach (SingleRisk siris in RC_Tabele.Risk)
            {
                RC_BaseRisks.Add(siris.name);
            }
            RAList.Initialize(RC_Tabele);
            DB.name = "DB";
            allCategories.Initialize(RC_Tabele);

            //dbValues.valueList.Clear();
            //dbCategories.Clear();
            //if (allCategories != null) { allCategories.Clear(); }            
            //RC_Tabele = new RiskCollection();
            //RC_Tabele.Initialize();
            //allCategories.Initialize(RC_Tabele);

            //dbBasicInfo.Clear();
            //if (arBasicInfo != null) { arBasicInfo.Clear(); }
            //RAList.Clear();
            //DB.Clear();
        }


        public void SaveDataBase(string filename)
        {
            DBToSave save = new DBToSave();

            save.programVersion = programVersion;
            save.valueManager = dbValues;
            save.categoryManager = dbCategories;
            save.riskManager = RC_Tabele;
            save.basicInformation = dbBasicInfo;

            save.dgv.Clone(DB);
            save.dgv.rows.RemoveAt(save.dgv.rows.Count - 1);


            BLL.SaveDataBase.SaveDataBase.Save(filename, save, programVersion);

            //using (Stream file = File.Open(filename, FileMode.Create))
            //{
            //    XmlSerializer xmlser = new XmlSerializer(typeof(DBToSave));
            //    xmlser.Serialize(file, save);
            //    file.Close();
            //}

        }


        public void SaveARProject(string filename)
        {
            ProjectToSave save = new ProjectToSave();
            ProjectProperties Properties = new ProjectProperties();
            DBToSave DataBase = new DBToSave();

            arBasicInfo.programVersion = programVersion;
            save.Properties = arBasicInfo;

            DataBase.valueManager = dbValues;
            DataBase.categoryManager = dbCategories;
            DataBase.riskManager = RC_Tabele;
            DataBase.basicInformation = dbBasicInfo;
            save.DataBase = DataBase;


            /*_log.LogEntry.Add("SaveARProject: Wierszy: " + DB.rows.Count.ToString());
            _log.LogEntry.Add("SaveARProject: Nazwa: " + DB.rows[DB.rows.Count - 1].name + "  :Zostanie usunięty.");
            _log.LogEntry.Add("SaveARProject: Grupa: " + DB.rows[DB.rows.Count - 1].cells[1].value);
            _log.LogEntry.Add("SaveARProject: Ilość: " + DB.rows[DB.rows.Count - 1].cells[6].value);
            */


            //_log.LogEntry.Add("  ");

            save.DataBase.dgv.Clone(DB);
            save.DataBase.dgv.rows.RemoveAt(save.DataBase.dgv.rows.Count - 1);



            /*_log.LogEntry.Add("SaveARProject: Wierszy: " + DB.rows.Count.ToString());
            _log.LogEntry.Add("SaveARProject: Nazwa: " + DB.rows[DB.rows.Count - 1].name);
            _log.LogEntry.Add("SaveARProject: Grupa: " + DB.rows[DB.rows.Count - 1].cells[1].value);
            _log.LogEntry.Add("SaveARProject: Ilość: " + DB.rows[DB.rows.Count - 1].cells[6].value);*/

            save.RiskAnalysis = new RAToSave();
            save.RiskAnalysis.Clone(RAList);
            save.ReportSettings = rs;


            SaveProject.Save(filename, save, programVersion);

            //Console.WriteLine(save.RiskAnalysis.RiskAnalysis[0].dgvList[1].rows[2].cells[5].value);
            //Console.WriteLine(save.RiskAnalysis.RiskAnalysis[0].dgvList[1].rows[2].cells[5].formula);



        }

        public void LoadDataBase(string filename, int co)
        {
            DBToSave load;

            try
            {
                string version = BLL.LoadDataBase.LoadDataBase.GetTheAssemblyVersion(0, filename);
                load = BLL.LoadDataBase.LoadDataBase.Load(version, filename);

                dbCategories.List.Clear();
                dbCategories = load.categoryManager;
                dbValues.ValuesDescription = load.valueManager.ValuesDescription;
                dbValues.valueList = load.valueManager.valueList.ToList();
                dbBasicInfo = load.basicInformation;
                RC_Tabele.Clone(load.riskManager);
                //valueManager.reloadValues();
                DB.Clone(load.dgv);
                //Console.WriteLine("Mam kolumn w DB: " + DB.columnPropeties.Count);

                if (co == 0)
                {
                    DB.Load(newDataBase.dataGridView1, DB);
                    BindData(newDataBase.dataGridView1);
                    newDataBase.Text = dbBasicInfo.dbName;
                    DB.AddRow(true, ""); //dodajemy wiersz bo w dgv i tak zostanie on dodany i może być użyty

                }
                else
                {
                    DB.Load(anarisProject.dataGridView1, DB);
                    BindData(anarisProject.dataGridView1);
                    DB.AddRow(true, "");
                    initializeARData();

                }


            }
            catch (Exception exc)
            {
                string error = exc.ToString();
                view.showErrorMessage("Plik jest nieodpowiedni bądź zawiera błędy.");
                newDataBase.Dispose();
                view.dataBaseProjectClosed();
            }
        }



        public void LoadAnarisProject(string filename)
        {
            ProjectToSave load;

            try
            {
                string version = LoadProject.GetTheAssemblyVersion(0, filename);
                load = LoadProject.Load(version, filename);

                dbCategories.List.Clear();
                dbCategories = load.DataBase.categoryManager;
                dbValues.ValuesDescription = load.DataBase.valueManager.ValuesDescription;
                dbValues.valueList = load.DataBase.valueManager.valueList.ToList();

                dbBasicInfo = load.DataBase.basicInformation;
                arBasicInfo.Clone(load.Properties);
                arBasicInfo.filePath = filePath;
                RC_Tabele.Clone(load.DataBase.riskManager);
                //valueManager.reloadValues();
                rs = load.ReportSettings;
                //load.DataBase.dgv.rows.RemoveAt(load.DataBase.dgv.rows.Count - 1);
                DB.Clone(load.DataBase.dgv);
                /*_log.LogEntry.Add("LoadARProject: Wierszy: " + DB.rows.Count.ToString());
                _log.LogEntry.Add("LoadARProject: Nazwa: " + DB.rows[DB.rows.Count - 1].name);
                _log.LogEntry.Add("LoadARProject: Grupa: " + DB.rows[DB.rows.Count - 1].cells[1].value);
                _log.LogEntry.Add("LoadARProject: Ilość:" + DB.rows[DB.rows.Count - 1].cells[6].value);*/

                RAList.Clone(load.RiskAnalysis);

                //Console.WriteLine("Mam kolumn w DB: " + DB.columnPropeties.Count);


                DB.Load(anarisProject.dataGridView1, DB);
                BindData(anarisProject.dataGridView1);
                //DB.AddRow(true, "");
                string name = load.RiskAnalysis.RiskAnalysis[3].dgvList[0].rows.Last().name;
                Console.WriteLine("Dodałem rowek: " + name);
                DB.AddRow(true, name, "");

                anarisProject.setTotalValues();
                //RAList.AddRows(true, DB.rows[DB.rows.Count-1].name, "");                

            }
            catch (Exception exc)
            {
                string message = exc.ToString();
                view.showErrorMessage("Plik jest nieodpowiedni bądź zawiera błędy.");
                anarisProject.Dispose();
                view.anarisProjectClosed();
            }



        }

        public void initializeARData()
        {
            for (int i = 0; i < RC_Tabele.Risk.Count; i++)
            {
                Dgv one = new Dgv();
                one.Clone(DB);
                one.name = "RADB_" + RC_Tabele.Risk[i].name;
                //one.AddRAColumns();
                RAList.RiskAnalysis[i].dgvList.Clear();
                RAList.RiskAnalysis[i].dgvList.Add(one);

                for (int j = 0; j < RC_Tabele.Risk[i].DistinctiveRisk.Count; j++)
                {
                    Dgv nowy = new Dgv();
                    nowy.Clone(DB);
                    nowy.name = RC_Tabele.Risk[i].DistinctiveRisk[j].name;
                    nowy.AddRAColumns();
                    RAList.RiskAnalysis[i].dgvList.Add(nowy);
                }
            }

        }

        public void BindData(DataGridView dgv)
        {
            foreach (DataGridViewColumn cp in dgv.Columns)
            {
                //if (cp.CellType.ToString() == "System.Windows.Forms.DataGridViewComboBoxCell")
                if (cp.CellType == typeof(DataGridViewComboBoxCell))
                {
                    int index = cp.Name.IndexOf("_");
                    if (index != -1)
                    {
                        string subs = cp.Name.Substring(0, index);
                        if (subs == "CAT")
                        {
                            BindingList<SubCategory> subcat = new BindingList<SubCategory>(dbCategories.List.Where(s => s.name == cp.Name).First().subCategories);
                            ((DataGridViewComboBoxColumn)cp).DataSource = subcat;
                            ((DataGridViewComboBoxColumn)cp).ValueMember = "name";
                            ((DataGridViewComboBoxColumn)cp).DisplayMember = "text";
                        }
                    }
                }
            }

            setNewValues(dgv);
        }

        #endregion

        #region Controller for DataBaseDesigner


        public void setNewValues(DataGridView dgv)
        {
            int index = dgv.Columns.IndexOf(dgv.Columns["Lista"]);
            ((DataGridViewComboBoxColumn)dgv.Columns[index]).DataSource = new BindingSource(dbValues.valueList, null);
            ((DataGridViewComboBoxColumn)dgv.Columns[index]).ValueMember = "name";
            ((DataGridViewComboBoxColumn)dgv.Columns[index]).DisplayMember = "text";
        }

        public void setNewValues()
        {
            int index = newDataBase.dataGridView1.Columns.IndexOf(newDataBase.dataGridView1.Columns["Lista"]);
            ((DataGridViewComboBoxColumn)newDataBase.dataGridView1.Columns[index]).DataSource = dbValues.valueList;
            ((DataGridViewComboBoxColumn)newDataBase.dataGridView1.Columns[index]).ValueMember = "name";
            ((DataGridViewComboBoxColumn)newDataBase.dataGridView1.Columns[index]).DisplayMember = "text";
        }

        public void closeDataBaseProject()
        {
            view.dataBaseProjectClosed();

            ClearData();

            newDataBase.Dispose();
            riskManager.Dispose();
            valueManager.Dispose();
            categoryManager.Dispose();
        }

        public double calculateTotalValue() // to się uruchamia chyba raz przy ładowaniu projektu. Dlaczego?
        {
            //Console.WriteLine("LICZE WSZYSTKO");
            RAList.calculateTotalValue(dbValues.valueList);
            //po zmienie wartości całkowitej należy przeliczyć wszystkie parametry zależące od tej wielkości
            RAList.calculateMagnitudeOfRisk(dbValues.valueList, RC_Tabele);
            //Console.WriteLine("Update");
            //if (riskManager == null) { Console.WriteLine("Null"); } else { Console.WriteLine("Exist: " + RC_Tabele.Risk.Count); }
            if (riskManager != null) { riskManager.UpdateAllCValues(); }
            return DB.calculateTotalValue(dbValues.valueList);
        }

        public void calculateMagnitudeOfRisk(Dgv data, int riskIndex, int distIndex)
        {
            //Console.WriteLine("Wart. w: " + data.name + ", wart: " + data.collectionTotalValue);
            //Console.WriteLine("||CON:calculateMagnitudeOfRisk:");
            //Console.WriteLine("riskIndex: " + riskIndex + ", distIndex:" + distIndex + " ||CON");
            data.calculateMagnitudeOfRisk(dbValues.valueList, RC_Tabele, riskIndex, distIndex);
            riskManager.UpdateCValues(data.getAvrCValue(0), data.getAvrCValue(1), data.getAvrCValue(2), riskIndex, distIndex);
        }

        public void simpleSort(Dgv data, string columnName, bool sortOrder)
        {
            data.Sort(columnName, dbCategories, dbValues.valueList, sortOrder);
        }


        public void MergeDataBases(string filePath, bool importAll )
        {
            string version = BLL.LoadDataBase.LoadDataBase.GetTheAssemblyVersion(0, filePath);
            DBToSave Import = BLL.LoadDataBase.LoadDataBase.Load(version, filePath);
            DataBaseValues ValueDelta = dbValues.CompareManagersData(Import.valueManager);
            DataBaseCategories categoryDelta = dbCategories.CompareManagersData(Import.categoryManager);
            

            if (newDataBase != null)
            {
                DBLoadStatus = 1;
                //Import.dgv.rows.RemoveAt(Import.dgv.rows.Count -1);
                Dictionary<string, int> columnMapping = Dgv.GetMappingDictionary(DB);
                Dictionary<string, int> icolumnMapping = Dgv.GetMappingDictionary(Import.dgv);
                Dictionary<int, Dictionary<string, string>> catMap = DataBaseCategories.MapCategories(dbCategories, columnMapping);
                Dictionary<int, Dictionary<string, string>> iCatMap = DataBaseCategories.MapCategories(Import.categoryManager, icolumnMapping);
                Dictionary<int, Dictionary<string, string>> valueMap = dbCategories.MapValues(Import.categoryManager, columnMapping);
                
                valueMap = dbValues.MapDBValues(Import.valueManager.valueList, columnMapping["Lista"], valueMap);                
                catMap.Add(columnMapping["Lista"], dbValues.valueList.ToDictionary(v => v.name, v => v.text));
                iCatMap.Add(icolumnMapping["Lista"], Import.valueManager.valueList.ToDictionary(v => v.name, v => v.text));

                List<DgvRow> Imported = DB.MergeDatabases(Import.dgv, importAll, catMap, iCatMap, valueMap);
                if (Imported.Count > 0)
                {
                    DB.rows.InsertRange(DB.rows.Count - 1, Imported);
                    DB.AddDataGridViewRows(Imported, newDataBase.dataGridView1);
                }                

                DBLoadStatus = 0;
            }
            else if (anarisProject != null)
            {
                Dictionary<string, int> columnMapping = Dgv.GetMappingDictionary(DB);
                Dictionary<string, int> icolumnMapping = Dgv.GetMappingDictionary(Import.dgv);
                Dictionary<int, Dictionary<string, string>> catMap = DataBaseCategories.MapCategories(dbCategories, columnMapping);
                Dictionary<int, Dictionary<string, string>> iCatMap = DataBaseCategories.MapCategories(Import.categoryManager, icolumnMapping);
                Dictionary<int, Dictionary<string, string>> valueMap = dbCategories.MapValues(Import.categoryManager, columnMapping);

                valueMap = dbValues.MapDBValues(Import.valueManager.valueList, columnMapping["Lista"], valueMap);
                catMap.Add(columnMapping["Lista"], dbValues.valueList.ToDictionary(v => v.name, v => v.text));
                iCatMap.Add(icolumnMapping["Lista"], Import.valueManager.valueList.ToDictionary(v => v.name, v => v.text));

                List<DgvRow> Imported = DB.MergeDatabases(Import.dgv, importAll, catMap, iCatMap, valueMap);
                if (Imported.Count > 0)
                {
                    DB.rows.InsertRange(DB.rows.Count - 1, Imported);
                    DB.AddDataGridViewRows(Imported, newDataBase.dataGridView1);
                    RAList.AddRangeOfRows(Imported);
                }
                
            }

            
        }

        public void MergeAnarisProjects(string filePath, bool importAll)
        {
            bool includeNumber = false;

            string version = BLL.Load.LoadProject.GetTheAssemblyVersion(0, filePath);
            ProjectToSave Import = BLL.Load.LoadProject.Load(version, filePath);
            Dictionary<int, List<ElementaryRisk>> iRisks = RC_Tabele.ImportRisks(Import.DataBase.riskManager.Risk);

            Dictionary<int, Dictionary<string, string>> catMap = DataBaseCategories.MapCategories(dbCategories, Dgv.GetMappingDictionary(DB));
            Dictionary<int, Dictionary<string, string>> iCatMap = DataBaseCategories.MapCategories(Import.DataBase.categoryManager, Dgv.GetMappingDictionary(Import.DataBase.dgv));
            Dictionary<int, Dictionary<string, string>> valueMap = dbCategories.MapValues(Import.DataBase.categoryManager, Dgv.GetMappingDictionary(DB));
            Dictionary<int, Dictionary<string, string>> iValueMap = Import.DataBase.categoryManager.MapValues(dbCategories, Dgv.GetMappingDictionary(Import.DataBase.dgv));
            List<DgvRow> Imported = DB.MergeDatabases(Import.DataBase.dgv, includeNumber, catMap, iCatMap, valueMap);
            List<DgvRow> Missing = Import.DataBase.dgv.MergeDatabases(DB, includeNumber, iCatMap, catMap, iValueMap);
            Dictionary<int, int> columnMapping = DB.GetColumnMapping(Import.DataBase.dgv);
            Dictionary<string, int> columnMap = DB.columns.ToDictionary(c => c.name, c => c.index);

            Dictionary<int, Dictionary<string, string>> valueMapping = dbCategories.MapValues(Import.DataBase.categoryManager, columnMap);

            RAList.MergeProjects(Import.RiskAnalysis, iRisks, Imported, Missing, columnMapping, valueMapping);

        }


        #endregion

        #region Controller for ValueManager
        public void initializeValueManager(MainWindow okno)
        {
            valueManager = new ValueManager(dbValues);
            valueManager.setController(this);
            valueManager.MdiParent = okno;
            //valueManager.ReadValues();            
        }

        public void ShowHideValueManager()
        {
            view.valueTableMnu.Checked = !view.valueTableMnu.Checked;
            valueManager.Visible = !valueManager.Visible;
        }
        #endregion

        #region Controller for RiskManager

        public void initializeRiskManager(MainWindow okno)
        {
            //Console.WriteLine("CO: " + RC_Tabele.Risk.Count + " " + RC_Tabele.Risk[0].name + ", " + RC_Tabele.Risk[0].DistinctiveRisk.Count);
            riskManager = new RiskManager(RC_Tabele, RC_BaseRisks);
            //tutaj tworzę View co ciekawe najpierw powstaje view i odpala się selecteditemchanged dopiero potem leci do konstruktora()
            //a ja już po tym wszystkim ustawiam kontroller
            riskManager.setController(this);
            riskManager.MdiParent = okno;
            if (DBLoadStatus != 1) { riskManager.UpdateAllCValues(); }

        }

        public void ShowHideRiskManager()
        {
            view.riskTableMnu.Checked = !view.riskTableMnu.Checked;
            riskManager.Visible = !riskManager.Visible;
        }


        public void closeAnarisProject()
        {
            view.anarisProjectClosed();

            ClearData();

            anarisProject.Dispose();
            riskManager.Dispose();
            valueManager.Dispose();
            categoryManager.Dispose();
        }

        #endregion

        #region Controller for CategoryTree

        public void initializeCategoryManager(MainWindow okno)
        {
            categoryManager = new CategoryTree();
            categoryManager.setController(this);
            categoryManager.MdiParent = okno;
        }

        public void ShowHideCategoryManager()
        {
            view.categoryTableMnu.Checked = !view.categoryTableMnu.Checked;
            categoryManager.Visible = !categoryManager.Visible;
        }

        public void setNewCategories()
        {
            foreach (Category cat in dbCategories.List)
            {
                TreeNode nowy = new TreeNode();
                nowy.Name = cat.name;
                nowy.Text = cat.text;
                nowy.NodeFont = new Font(categoryManager.catTreeView.Font, FontStyle.Bold);

                if (cat.subCategories.Count != 0)
                {
                    foreach (SubCategory subCat in cat.subCategories)
                    {
                        TreeNode subNowy = new TreeNode();
                        subNowy.Name = subCat.name;
                        subNowy.Text = subCat.text;
                        nowy.Nodes.Add(subNowy);
                    }
                }
                categoryManager.catTreeView.Nodes.Add(nowy);
                categoryManager.resetNodetext(nowy);
            }

            categoryManager.tmpCategories.Clone(dbCategories);

            //DOPISAC UZUPELNIANIE DRZEWEK DLA RA
        }

        public void remove_CategoryManager()
        {

        }

        public void add_CategoryManager()
        {
            int i, j;
            int nofNodes = 0;
            int nofKids = 0;
            DataGridView dgv;

            if (newDataBase == null) { dgv = anarisProject.dataGridView1; }
            else { dgv = newDataBase.dataGridView1; }

            //Console.WriteLine("mam kolumn w dgv:" + dgv.Columns.Count);

            dbCategories.List.Clear();
            dbCategories.UpdateCategories(categoryManager.catTreeView, categoryManager.tmpCategories); //here the categories gets updates in model
            valuePieChart.ReloadCategories(dbCategories);

            nofNodes = categoryManager.catTreeView.Nodes.Count;
            //Console.WriteLine("Nodes: " + nofNodes);
            if (nofNodes != 0) // potrzebny warunek ? nofNodes =0 wtedy i=0 i<0 jest niespełniony więc raczej warunek niepotrzebny
            {
                for (i = 0; i < nofNodes; i++)
                {
                    //MessageBox.Show("Szukam " + catTreeView.Nodes[i].Name.ToString());
                    //found = 0;
                    //Console.WriteLine("Wlozem");

                    //tutaj poprawić na Find() i nie na datagridView ale na DB. 
                    //Zmiana w DB spowosuje zmiany w bazach RA (najprawdpodobniej :) )

                    //MessageBox.Show("Mam " + mainProjectGrid.Columns[j].Name.ToString());

                    DgvColumn column = DB.columns.Find(x => x.name == categoryManager.catTreeView.Nodes[i].Name);

                    if (column != null)
                    {
                        j = column.index;
                        DataGridViewComboBoxColumn theColumn = (DataGridViewComboBoxColumn)dgv.Columns[j];
                        //MessageBox.Show("znalazłem");
                        if (categoryManager.catTreeView.Nodes[i].Text != column.headerText)
                        {
                            column.headerText = categoryManager.catTreeView.Nodes[i].Text;
                            theColumn.HeaderText = categoryManager.catTreeView.Nodes[i].Text;
                        }

                        //theColumn.Items.Clear();

                        nofKids = categoryManager.catTreeView.Nodes[i].Nodes.Count;
                        //if (nofKids != 0) { for (j = 0; j < nofKids; j++) { theColumn.Items.Add(categoryManager.catTreeView.Nodes[i].Nodes[j].Text); } }
                        if (nofKids != 0)
                        {
                            BindingList<SubCategory> subcat = new BindingList<SubCategory>(dbCategories.List[i].subCategories);
                            //subcat = categoryList[i].subCategories;
                            theColumn.DataSource = subcat;
                            theColumn.ValueMember = "name";
                            theColumn.DisplayMember = "text";
                        }
                        //found = 1;

                    }
                    else //if (found == 0)
                    {
                        DataGridViewComboBoxColumn newone = new DataGridViewComboBoxColumn();
                        newone.HeaderText = categoryManager.catTreeView.Nodes[i].Text;
                        newone.Name = categoryManager.catTreeView.Nodes[i].Name;
                        newone.FlatStyle = FlatStyle.Flat;
                        newone.SortMode = DataGridViewColumnSortMode.NotSortable;

                        nofKids = categoryManager.catTreeView.Nodes[i].Nodes.Count;

                        //if (nofKids != 0) { for (j = 0; j < nofKids; j++) { newone.Items.Add(categoryManager.catTreeView.Nodes[i].Nodes[j].Text); } }
                        if (nofKids != 0)
                        {
                            BindingList<SubCategory> subcat = new BindingList<SubCategory>(dbCategories.List[i].subCategories);
                            //subcat = categoryList[i].subCategories;
                            newone.DataSource = subcat;
                            newone.ValueMember = "name";
                            newone.DisplayMember = "text";
                        }
                        dgv.Columns.Insert(dgv.Columns.Count - 2, newone); //this triggers the dataGridView1_ColumnAdded in AnarisProject Form
                        dgv.Refresh();
                    }
                }

            }
        }

        public void changeName_CategoryManager()
        {

        }


        #endregion

        #region tronadoChart
        public void initializeTornadoChart(MainWindow okno)
        {
            tornadoChart = new TornadoChart(RC_BaseRisks);
            tornadoChart.setController(this);

            tornadoChart.MdiParent = okno;
        }

        public void ShowHideTornadoChart()
        {
            view.tornadoChartBtn.Checked = !view.tornadoChartBtn.Checked;
            tornadoChart.Visible = !tornadoChart.Visible;
        }

        public void LoadTornadoChart(Chart chart, int sort, int riskIndex)
        {
            chart.Series["Aval"].Points.Clear();
            chart.Series["Bval"].Points.Clear();
            chart.Series["Cval"].Points.Clear();

            tornadoChartSeries chSer = new tornadoChartSeries();
            List<tornadoPoints> Ord;
            double cutOff = 0.001;
            double A = 0;
            double Alow = 0;
            double Ahigh = 0;
            double B = 0;
            double Blow = 0;
            double Bhigh = 0;
            double C = 0;
            double Clow = 0;
            double Chigh = 0;

            if (riskIndex == -2)
            {
                foreach (SingleRisk sr in RC_Tabele.Risk)
                {
                    if (sr.DistinctiveRisk.Count != 0)
                    {
                        foreach (ElementaryRisk er in sr.DistinctiveRisk)
                        {
                            A = (er.AMid < 1) ? 5 : 5 - Math.Log10(er.AMid);
                            Alow = (er.ALow < 1) ? 5 : 5 - Math.Log10(er.ALow);
                            Ahigh = (er.AHigh < 1) ? 5 : 5 - Math.Log10(er.AHigh);

                            B = (er.BMid < cutOff) ? 0 : 5 + Math.Log10(er.BMid / 100.0);
                            Blow = (er.BLow < cutOff) ? 0 : 5 + Math.Log10(er.BLow / 100.0);
                            Bhigh = (er.BHigh < cutOff) ? 0 : 5 + Math.Log10(er.BHigh / 100.0);

                            C = (er.CMid < cutOff) ? 0 : 5 + Math.Log10(er.CMid / 100.0);
                            Clow = (er.CLow < cutOff) ? 0 : 5 + Math.Log10(er.CLow / 100.0);
                            Chigh = (er.CHigh < cutOff) ? 0 : 5 + Math.Log10(er.CHigh / 100.0);

                            //Console.WriteLine(er.name + " : A-" + A + " B-" + B + " C-" + C);
                            //chSer.series.Add(new tornadoPoints { name = er.name, Aval = er.AMid, Bval = er.BMid, Cval = er.CMid , Tval = er.AMid + er.BMid + er.CMid});
                            chSer.series.Add(new tornadoPoints { name = er.name, Aval = A, Bval = B, Cval = C, Tval = A + B + C, Tlow = Alow + Blow + Clow, Thigh = Ahigh + Bhigh + Chigh });
                        }
                    }
                }
            }
            else if (riskIndex == -1)
            {
                foreach (SingleRisk sr in RC_Tabele.Risk)
                {

                    if (sr.Print && sr.DistinctiveRisk.Count != 0)
                    {
                        foreach (ElementaryRisk er in sr.DistinctiveRisk)
                        {
                            if (er.Print)
                            {
                                A = (er.AMid < 1) ? 5 : 5 - Math.Log10(er.AMid);
                                Alow = (er.ALow < 1) ? 5 : 5 - Math.Log10(er.ALow);
                                Ahigh = (er.AHigh < 1) ? 5 : 5 - Math.Log10(er.AHigh);

                                B = (er.BMid < cutOff) ? 0 : 5 + Math.Log10(er.BMid / 100.0);
                                Blow = (er.BLow < cutOff) ? 0 : 5 + Math.Log10(er.BLow / 100.0);
                                Bhigh = (er.BHigh < cutOff) ? 0 : 5 + Math.Log10(er.BHigh / 100.0);

                                C = (er.CMid < cutOff) ? 0 : 5 + Math.Log10(er.CMid / 100.0);
                                Clow = (er.CLow < cutOff) ? 0 : 5 + Math.Log10(er.CLow / 100.0);
                                Chigh = (er.CHigh < cutOff) ? 0 : 5 + Math.Log10(er.CHigh / 100.0);

                                //Console.WriteLine(er.name + " : A-" + A + " B-" + B + " C-" + C);
                                //chSer.series.Add(new tornadoPoints { name = er.name, Aval = er.AMid, Bval = er.BMid, Cval = er.CMid , Tval = er.AMid + er.BMid + er.CMid});
                                chSer.series.Add(new tornadoPoints { name = er.name, Aval = A, Bval = B, Cval = C, Tval = A + B + C, Tlow = Alow + Blow + Clow, Thigh = Ahigh + Bhigh + Chigh });
                            }
                        }
                    }
                }

            }
            else
            {
                foreach (ElementaryRisk er in RC_Tabele.Risk[riskIndex].DistinctiveRisk)
                {
                    A = (er.AMid < 1) ? 5 : 5 - Math.Log10(er.AMid);
                    Alow = (er.ALow < 1) ? 5 : 5 - Math.Log10(er.ALow);
                    Ahigh = (er.AHigh < 1) ? 5 : 5 - Math.Log10(er.AHigh);

                    B = (er.BMid < cutOff) ? 0 : 5 + Math.Log10(er.BMid / 100.0);
                    Blow = (er.BLow < cutOff) ? 0 : 5 + Math.Log10(er.BLow / 100.0);
                    Bhigh = (er.BHigh < cutOff) ? 0 : 5 + Math.Log10(er.BHigh / 100.0);

                    C = (er.CMid < cutOff) ? 0 : 5 + Math.Log10(er.CMid / 100.0);
                    Clow = (er.CLow < cutOff) ? 0 : 5 + Math.Log10(er.CLow / 100.0);
                    Chigh = (er.CHigh < cutOff) ? 0 : 5 + Math.Log10(er.CHigh / 100.0);

                    //Console.WriteLine(er.name + " : A-" + A + " B-" + B + C + " C-" + C);
                    //chSer.series.Add(new tornadoPoints { name = er.name, Aval = er.AMid, Bval = er.BMid, Cval = er.CMid , Tval = er.AMid + er.BMid + er.CMid});
                    chSer.series.Add(new tornadoPoints { name = er.name, Aval = A, Bval = B, Cval = C, Tval = A + B + C, Tlow = Alow + Blow + Clow, Thigh = Ahigh + Bhigh + Chigh });
                }
            }

            if (chSer != null)
            {
                switch (sort)
                {
                    case 1:
                        Ord = chSer.series.OrderBy(s => s.Aval).ToList();
                        break;
                    case 2:
                        Ord = chSer.series.OrderBy(s => s.Bval).ToList();
                        break;
                    case 3:
                        Ord = chSer.series.OrderBy(s => s.Cval).ToList();
                        break;
                    case 0:
                        Ord = chSer.series.OrderBy(s => s.Tval).ToList();
                        break;
                    default:
                        Ord = chSer.series.OrderBy(s => s.Tval).ToList();
                        break;
                };

                foreach (tornadoPoints top in Ord)
                {
                    chart.Series["Aval"].Points.AddXY(top.name, top.Aval);
                    chart.Series["Bval"].Points.AddXY(top.name, top.Bval);
                    chart.Series["Cval"].Points.AddXY(top.name, top.Cval);
                }
            }
        }

        #endregion

        #region ThresholdChart
        public void initializeThresholdChart(MainWindow okno)
        {
            thresholdChart = new ThresholdChart(RC_BaseRisks);
            thresholdChart.setController(this);

            thresholdChart.MdiParent = okno;
        }

        public void ShowHideThresholdChart()
        {
            view.btnTabNiepewnosci.Checked = !view.btnTabNiepewnosci.Checked;
            thresholdChart.Visible = !thresholdChart.Visible;
        }

        public void LoadThresholdChart(double risk, double unc, int riskIndex, ListView actNow, ListView actLast, ListView reasNow, ListView reasLast)
        {
            actNow.Items.Clear();
            actLast.Items.Clear();
            reasNow.Items.Clear();
            reasLast.Items.Clear();

            tornadoChartSeries chSer = new tornadoChartSeries();
            List<tornadoPoints> Ord;
            double cutOff = 0.001;
            double A = 0;
            double Alow = 0;
            double Ahigh = 0;
            double B = 0;
            double Blow = 0;
            double Bhigh = 0;
            double C = 0;
            double Clow = 0;
            double Chigh = 0;

            if (riskIndex == -1)
            {
                foreach (SingleRisk sr in RC_Tabele.Risk)
                {
                    foreach (ElementaryRisk er in sr.DistinctiveRisk)
                    {
                        A = (er.AMid < 1) ? 5 : 5 - Math.Log10(er.AMid);
                        Alow = (er.ALow < 1) ? 5 : 5 - Math.Log10(er.ALow);
                        Ahigh = (er.AHigh < 1) ? 5 : 5 - Math.Log10(er.AHigh);

                        B = (er.BMid < cutOff) ? 0 : 5 + Math.Log10(er.BMid / 100.0);
                        Blow = (er.BLow < cutOff) ? 0 : 5 + Math.Log10(er.BLow / 100.0);
                        Bhigh = (er.BHigh < cutOff) ? 0 : 5 + Math.Log10(er.BHigh / 100.0);

                        C = (er.CMid < cutOff) ? 0 : 5 + Math.Log10(er.CMid / 100.0);
                        Clow = (er.CLow < cutOff) ? 0 : 5 + Math.Log10(er.CLow / 100.0);
                        Chigh = (er.CHigh < cutOff) ? 0 : 5 + Math.Log10(er.CHigh / 100.0);


                        chSer.series.Add(new tornadoPoints { name = er.name, Aval = A, Bval = B, Cval = C, Tval = A + B + C, Tlow = Alow + Blow + Clow, Thigh = Ahigh + Bhigh + Chigh });
                    }
                }
            }
            else
            {
                foreach (ElementaryRisk er in RC_Tabele.Risk[riskIndex].DistinctiveRisk)
                {
                    A = (er.AMid < 1) ? 5 : 5 - Math.Log10(er.AMid);
                    Alow = (er.ALow < 1) ? 5 : 5 - Math.Log10(er.ALow);
                    Ahigh = (er.AHigh < 1) ? 5 : 5 - Math.Log10(er.AHigh);

                    B = (er.BMid < cutOff) ? 5 : 5 + Math.Log10(er.BMid / 100.0);
                    Blow = (er.BLow < cutOff) ? 5 : 5 + Math.Log10(er.BLow / 100.0);
                    Bhigh = (er.BHigh < cutOff) ? 5 : 5 + Math.Log10(er.BHigh / 100.0);

                    C = (er.CMid < cutOff) ? 5 : 5 + Math.Log10(er.CMid / 100.0);
                    Clow = (er.CLow < cutOff) ? 5 : 5 + Math.Log10(er.CLow / 100.0);
                    Chigh = (er.CHigh < cutOff) ? 5 : 5 + Math.Log10(er.CHigh / 100.0);

                    //Console.WriteLine(er.name + " : A-" + A + " B-" + B + C + " C-" + C);
                    //chSer.series.Add(new tornadoPoints { name = er.name, Aval = er.AMid, Bval = er.BMid, Cval = er.CMid , Tval = er.AMid + er.BMid + er.CMid});
                    chSer.series.Add(new tornadoPoints { name = er.name, Aval = A, Bval = B, Cval = C, Tval = A + B + C, Tlow = Alow + Blow + Clow, Thigh = Ahigh + Bhigh + Chigh });
                }
            }

            Ord = chSer.series.OrderByDescending(s => s.Tval).ToList();

            foreach (tornadoPoints tp in Ord)
            {
                //double u = Math.Max(tp.Tval - tp.Tlow, tp.Thigh - tp.Tval);
                double u = tp.Thigh - tp.Tlow;
                //Console.WriteLine("Name: " + tp.name + ", WR:" + tp.Tval + ", Th: " + tp.Thigh + ", Tl: " + tp.Tlow  + ", u:" + u);

                if (tp.Tval > risk && u < unc)
                {
                    //Console.WriteLine("ActNow");
                    ListViewItem item = new ListViewItem(tp.name, 0);
                    item.SubItems.Add(String.Format("{0:N2}", tp.Tval));
                    item.SubItems.Add(String.Format("{0:N2}", u));
                    actNow.Items.Add(item);
                }
                if (tp.Tval > risk && u > unc)
                {
                    //Console.WriteLine("ReasNow");
                    ListViewItem item = new ListViewItem(tp.name, 0);
                    item.SubItems.Add(String.Format("{0:N2}", tp.Tval));
                    item.SubItems.Add(String.Format("{0:N2}", u));
                    reasNow.Items.Add(item);
                }
                if (tp.Tval < risk && u < unc)
                {
                    //Console.WriteLine("ActLast");
                    ListViewItem item = new ListViewItem(tp.name, 0);
                    item.SubItems.Add(String.Format("{0:N2}", tp.Tval));
                    item.SubItems.Add(String.Format("{0:N2}", u));
                    actLast.Items.Add(item);
                }
                if (tp.Tval < risk && u > unc)
                {
                    //Console.WriteLine("ReasLast");
                    ListViewItem item = new ListViewItem(tp.name, 0);
                    item.SubItems.Add(String.Format("{0:N2}", tp.Tval));
                    item.SubItems.Add(String.Format("{0:N2}", u));
                    reasLast.Items.Add(item);
                }
                //Console.WriteLine("__________________");
            }

        }
        #endregion

        #region Report
        public void initializeReportForm(MainWindow okno)
        {
            reportManager = new ReportForm(rs);
            reportManager.setController(this);
            reportManager.MdiParent = okno;
        }

        public void ShowHideReportForm()
        {
            view.reportFormBtn.Checked = !view.reportFormBtn.Checked;
            reportManager.Visible = !reportManager.Visible;
        }

        public Report generateReport()
        {
            //Text.Clear();
            ProjectToSave save = new ProjectToSave();
            ProjectProperties Properties = new ProjectProperties();
            DBToSave DataBase = new DBToSave();

            //XmlDocument format = new XmlDocument();
            //format.Load(@"C:\Users\Primus\Dropbox\Muzeum\PROGRAMY\ANARIS NEW 05\ReportTest.xml");

            //XmlNodeList main = format.GetElementsByTagName("report");
            //XmlNode node = main.Item(0);
            //XmlNodeList inside = node.ChildNodes;
            //List<XmlNode> elements = new List<XmlNode>();
            //foreach (XmlNode n in inside)
            //{
            //    if (n.NodeType == XmlNodeType.Element)
            //    {
            //        elements.Add(n);
            //    }
            //}


            //Properties.projectName = arBasicInfo.projectName;
            //Properties.programVersion = programVersion;
            //Properties.filePath = arBasicInfo.filePath;
            //Properties.creationTime = arBasicInfo.creationTime;
            //Properties.modifiedTime = DateTime.Now;
            //Properties.Authors = arBasicInfo.Authors;
            //Properties.RiskTeam = arBasicInfo.RiskTeam;
            //Properties.Organization = arBasicInfo.Organization;
            //Properties.Scope = arBasicInfo.Scope;
            //Properties.ReportIntro = arBasicInfo.ReportIntro;
            arBasicInfo.programVersion = programVersion;
            save.Properties = arBasicInfo;

            DataBase.valueManager = dbValues;
            DataBase.categoryManager = dbCategories;
            DataBase.riskManager = RC_Tabele;
            DataBase.basicInformation = dbBasicInfo;
            save.DataBase = DataBase;
            save.RiskAnalysis = RAList;
            save.DataBase.dgv.Clone(DB);
            save.DataBase.dgv.rows.RemoveAt(save.DataBase.dgv.rows.Count - 1);
            save.ReportSettings = rs;
            //ReportToPDF.CreateReport(save);
            simplePDF.CreateReport(save, this);

            LoadTornadoChart(tornadoChart.chart1, 0, -1);
            List<Bitmap> Imgs = new List<Bitmap>();

            using (MemoryStream ms = new MemoryStream())
            {
                tornadoChart.chart1.SaveImage(ms, ChartImageFormat.Bmp);
                Bitmap bm = new Bitmap(ms);
                Imgs.Add(bm);
                //Clipboard.SetImage(bm);
            }

            for (int i = 0; i < save.DataBase.categoryManager.List.Count + 1; i++)
            {
                Imgs.Add(valuePieChart.GenerateImageAsBitmap(i));
            }




            Report text = new Report();
            //text.generateReport(Text, save, Imgs);

            return text;
        }

        #endregion

        #region PieChart
        public void initializeValuePieChart(MainWindow okno)
        {
            valuePieChart = new ValuePieChart(dbCategories);
            valuePieChart.setController(this);

            valuePieChart.MdiParent = okno;
        }

        public void ShowHideValuePieChart()
        {
            view.ValuePieChartBtn.Checked = !view.ValuePieChartBtn.Checked;
            valuePieChart.Visible = !valuePieChart.Visible;
        }


        #endregion

        #region ARProperties

        public void initializePropertiesAR(MainWindow okno)
        {
            propertiesAR = new PropertiesAR(arBasicInfo);
            propertiesAR.setController(this);

            propertiesAR.MdiParent = okno;
        }

        public void ShowHideARProperties()
        {
            view.propertiesARMnu.Checked = !view.propertiesARMnu.Checked;
            propertiesAR.Visible = !propertiesAR.Visible;
        }
        #endregion



        #region pozostale kontroli

        public string randomNameGenerator(int length)
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

            return nazwa;
        }

        #endregion
    }
}
