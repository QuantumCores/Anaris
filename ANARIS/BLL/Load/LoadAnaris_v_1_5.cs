using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ANARIS.BLL.Load
{
    public class LoadAnaris_v_1_5
    {
        public static ANARIS.ProjectToSave Load(string filePath)
        {
            ProjectToSave old = new ProjectToSave();
            XDocument xmlFile = XDocument.Load(filePath);

            string base64string = xmlFile.Element("data").Value;
            string project = string.Empty;

            byte[] b = Convert.FromBase64String(base64string);
            using (var stream = new MemoryStream(b))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Binder = new OldProjectToNewProject();

                object tmp = binaryFormatter.Deserialize(stream);
                old = (ProjectToSave)tmp;

                //var formatter = new BinaryFormatter();
                //stream.Seek(0, SeekOrigin.Begin);
                //object tmp = formatter. Deserialize(stream);
                //old = (ProjectToSave)tmp;
            }

            ANARIS.ProjectToSave mapedProject = new ANARIS.ProjectToSave();
            MapModelsProperties(old, mapedProject);

            return mapedProject;
        }

        public class OldProjectToNewProject : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                typeName = typeName.Replace(
                    "ANARIS.DBToSave",
                    "ANARIS.BLL.Load.LoadAnaris_v_1_5.DBToSave");

                assemblyName = assemblyName.Replace("ANARIS", "ANARIS.BLL.Load.LoadAnaris_v_1_5");

                return Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
            }
        }

        

        private static void MapModelsProperties(ProjectToSave old, ANARIS.ProjectToSave pts)
        {

            pts.Properties = new ANARIS.ProjectProperties();
            pts.Properties.projectName = old.Properties.projectName;
            pts.Properties.programVersion = old.Properties.programVersion;
            pts.Properties.filePath = old.Properties.filePath;
            pts.Properties.creationTime = old.Properties.creationTime;
            pts.Properties.modifiedTime = old.Properties.modifiedTime;
            pts.Properties.Authors = old.Properties.Authors.ToList();

            pts.Properties.Organization = old.Properties.Organization;

            pts.DataBase = new ANARIS.DBToSave();
            ANARIS.dbBasicInfo basicInformation = new ANARIS.dbBasicInfo();
            basicInformation.dbDirrectory = old.DataBase.basicInformation.dbDirrectory;
            basicInformation.dbFileName = old.DataBase.basicInformation.dbFileName;
            basicInformation.dbMuseumAdres = old.DataBase.basicInformation.dbMuseumAdres;
            basicInformation.dbMuseumName = old.DataBase.basicInformation.dbMuseumName;
            basicInformation.dbName = old.DataBase.basicInformation.dbName;
            basicInformation.dbOrganisationName = old.DataBase.basicInformation.dbOrganisationName;
            basicInformation.dbAuthorsList = old.DataBase.basicInformation.dbAuthorsList;
            pts.DataBase.basicInformation = basicInformation;


            ANARIS.Dgv dgv = MapDgvProperties(old.DataBase.dgv);
            pts.DataBase.dgv = dgv;

            pts.DataBase.valueManager = new ANARIS.DataBaseValues();
            List<ANARIS.SingleValue> valueList = new List<ANARIS.SingleValue>();
            foreach (SingleValue oldsigleValue in old.DataBase.valueManager)
            {
                ANARIS.SingleValue singleValue = new ANARIS.SingleValue();

                singleValue.text = oldsigleValue.text;
                singleValue.name = oldsigleValue.name;
                singleValue.value = oldsigleValue.value;

                valueList.Add(singleValue);
            }

            pts.DataBase.valueManager.valueList = valueList.ToList();

            ANARIS.DataBaseCategories categoryManager = new ANARIS.DataBaseCategories();
            foreach (Category oldCategory in old.DataBase.categoryManager.List)
            {

                ANARIS.Category category = new ANARIS.Category();


                category.text = oldCategory.text;
                category.name = oldCategory.name;

                foreach (SubCategory oldSubCategory in oldCategory.subCategories)
                {
                    ANARIS.SubCategory subCategory = new ANARIS.SubCategory();

                    subCategory.text = oldSubCategory.text;
                    subCategory.name = oldSubCategory.name;

                    category.subCategories.Add(subCategory);
                }

                categoryManager.List.Add(category);

            }


            pts.DataBase.categoryManager = categoryManager;
            ANARIS.RiskCollection riskCollection = new ANARIS.RiskCollection();

            foreach (SingleRisk oldsingleRisk in old.DataBase.riskManager.Risk)
            {
                ANARIS.SingleRisk singleRisk = new ANARIS.SingleRisk();

                singleRisk.name = oldsingleRisk.name;

                foreach (ElementaryRisk oldElementary in oldsingleRisk.DistinctiveRisk)
                {
                    ANARIS.ElementaryRisk elementaryRisk = new ANARIS.ElementaryRisk();


                    elementaryRisk.name = oldElementary.name;
                    elementaryRisk.opis = oldElementary.opis;

                    elementaryRisk.AHigh = oldElementary.AHigh;
                    elementaryRisk.AMid = oldElementary.AMid;
                    elementaryRisk.ALow = oldElementary.ALow;
                    elementaryRisk.opisA = oldElementary.opisA;

                    elementaryRisk.BHigh = oldElementary.BHigh;
                    elementaryRisk.BMid = oldElementary.BMid;
                    elementaryRisk.BLow = oldElementary.BLow;
                    elementaryRisk.opisB = oldElementary.opisB;

                    elementaryRisk.CHigh = oldElementary.CHigh;
                    elementaryRisk.CMid = oldElementary.CMid;
                    elementaryRisk.CLow = oldElementary.CLow;
                    elementaryRisk.opisC = oldElementary.opisC;

                    singleRisk.DistinctiveRisk.Add(elementaryRisk);
                }


                riskCollection.Risk.Add(singleRisk);
            }

            pts.DataBase.riskManager = riskCollection;

            pts.RiskAnalysis = new ANARIS.RAToSave();



            foreach (RiskDgvList oldRiskDgv in old.RiskAnalysis.RiskAnalysis)
            {
                ANARIS.RiskDgvList riskDgvList = new ANARIS.RiskDgvList();

                riskDgvList.name = oldRiskDgv.name;

                foreach (Dgv oldDgvR in oldRiskDgv.dgvList)
                {
                    ANARIS.Dgv dgvR = MapDgvProperties(oldDgvR);
                    riskDgvList.dgvList.Add(dgvR);
                }

                pts.RiskAnalysis.RiskAnalysis.Add(riskDgvList);
            }

        }

        private static ANARIS.Dgv MapDgvProperties(Dgv oldDgv)
        {
            ANARIS.Dgv dgv = new ANARIS.Dgv();
            string tmpData = string.Empty;
            List<XElement> tmpXElemnts = new List<XElement>();


            dgv.name = oldDgv.name;
            dgv.collectionTotalValue = oldDgv.collectionTotalValue;
            dgv.collectionTotalNumber = oldDgv.collectionTotalNumber;
            dgv.MR = oldDgv.MR;
            dgv.MRmax = oldDgv.MRmax;
            dgv.MRmin = oldDgv.MRmin;


            foreach (DgvColumn oldColumn in oldDgv.columns)
            {
                ANARIS.DgvColumn dgvColumn = new ANARIS.DgvColumn();

                dgvColumn.name = oldColumn.name;
                dgvColumn.headerText = oldColumn.headerText;
                dgvColumn.index = oldColumn.index;
                dgvColumn.type = oldColumn.type;
                dgvColumn.visible = oldColumn.visible;
                dgvColumn.width = oldColumn.width;
                dgvColumn.sortable = oldColumn.sortable;
                dgvColumn.cellStyle = oldColumn.cellStyle;
                dgvColumn.valueType = oldColumn.valueType;
                dgvColumn.isARcol = oldColumn.isARcol;
                dgvColumn.isDBcol = oldColumn.isDBcol;

                dgv.columns.Add(dgvColumn);
            }


            foreach (DgvRow oldRow in oldDgv.rows)
            {
                ANARIS.DgvRow dgvRow = new ANARIS.DgvRow();

                dgvRow.isDBrow = oldRow.isDBrow;
                dgvRow.isARrow = oldRow.isARrow;
                dgvRow.name = oldRow.name;
                dgvRow.parent = oldRow.parent;

                foreach (string element in oldRow.childRows)
                {
                    dgvRow.childRows.Add(element);
                }

                foreach (DgvCell oldCell in oldRow.cells)
                {
                    ANARIS.DgvCell dgvCell = new ANARIS.DgvCell();

                    dgvCell.value = oldCell.value;
                    dgvCell.formula = oldCell.formula;

                    dgvRow.cells.Add(dgvCell);
                }

                dgv.rows.Add(dgvRow);
            }

            return dgv;
        }


        #region MODEL VERSION 1.5.0.0
        [Serializable]
        public class RiskCollection
        {
            public List<SingleRisk> Risk { get; set; }

            public RiskCollection()
            {
                Risk = new List<SingleRisk>();
            }
        }

        [Serializable]
        public class SingleRisk
        {
            public string name { get; set; }
            public List<ElementaryRisk> DistinctiveRisk { get; set; }

            public SingleRisk()
            {
                DistinctiveRisk = new List<ElementaryRisk>();
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
            
        }

        [Serializable]
        public class CategoryCollection
        {
            public DataBaseCategories DBCategories { get; set; }
            public List<ScenarioCategories> Scenario { get; set; }            
        }

        [Serializable]
        public class ScenarioCategories
        {
            public List<Category> List { get; set; }
            public string name { get; set; }
        }

        [Serializable]
        public class DataBaseCategories
        {
            public List<Category> List { get; set; }            
        }

        [Serializable]
        public class Category
        {
            public string text { get; set; }
            public string name { get; set; }
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
        }

        [Serializable]
        public class SingleValue
        {
            public string text { get; set; }
            public string name { get; set; }
            public double value { get; set; }
        }


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
            public string valueType { get; set; }
            public string valueFormat { get; set; }
            public bool isDBcol { get; set; }
            public bool isARcol { get; set; }           
        }


        [Serializable]
        public class DgvCell
        {
            public string value { get; set; }
            public string formula { get; set; }
            private bool block { get; set; }
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
        }

        [Serializable]
        public class DBToSave
        {
            public string programVersion { get; set; }
            public dbBasicInfo basicInformation { get; set; }

            public Dgv dgv { get; set; }

            public List<SingleValue> valueManager { get; set; }
            public DataBaseCategories categoryManager { get; set; }
            public RiskCollection riskManager { get; set; }


            public DBToSave()
            {
                valueManager = new List<SingleValue>();
                dgv = new Dgv();
                valueManager = new List<SingleValue>();
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

            public ProjectProperties()
            {
                Authors = new List<Author>();
                RiskTeam = new List<Author>();
                External = new List<Author>();
                Other = new List<Author>();
                Organization = new Organization();
            }
        }

        [Serializable]
        public class ProjectToSave
        {
            public ProjectProperties Properties { get; set; }
            public DBToSave DataBase { get; set; }
            public RAToSave RiskAnalysis { get; set; }
        }

        #endregion




    }
}
