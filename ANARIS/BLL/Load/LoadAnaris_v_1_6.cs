using ANARIS.BLL.Report;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ANARIS.BLL.Load
{
    public class LoadAnaris_v_1_6
    {
        public static ANARIS.ProjectToSave Load(string filePath)
        {
            ProjectToSave file = new ProjectToSave();

            using (ZipFile zip = new ZipFile(filePath))
            {
                ZipEntry dataEntry = zip.Entries.Where(e => e.FileName.Contains(SaveProject.projectFileName)).FirstOrDefault();
                using (MemoryStream ms = new MemoryStream())
                {
                    dataEntry.Extract(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer bf = new XmlSerializer(typeof(ProjectToSave));
                    file = (ProjectToSave)bf.Deserialize(ms);
                }
            }

            ANARIS.ProjectToSave mapedProject = new ANARIS.ProjectToSave();
            MapModelsProperties(file, mapedProject);

            ReportFonts.LoadFonts(mapedProject.ReportSettings);

            return mapedProject;
        }

        private static void MapModelsProperties(ProjectToSave old, ANARIS.ProjectToSave pts)
        {

            pts.Properties = new ANARIS.ProjectProperties();
            pts.Properties.projectName = old.Properties.projectName;
            pts.Properties.programVersion = old.Properties.programVersion;
            pts.Properties.filePath = old.Properties.filePath;
            pts.Properties.creationTime = old.Properties.creationTime;
            pts.Properties.modifiedTime = old.Properties.modifiedTime;
            pts.Properties.Authors = old.Properties.Authors;
            pts.Properties.ReportIntro = "";

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

            ReportSettings rs = new ReportSettings();

            rs.TitleFont = new RFont() { Face = "Helvetica", Size = 28, Color = new RColor { R = 50, G = 50, B = 50 }, Style = 1 };
            rs.ChapterFont = new RFont() { Face = "Times", Size = 21, Color = new RColor { R = 50, G = 50, B = 50 }, Style = 1 };
            rs.SectionFont = new RFont() { Face = "Times", Size = 18, Color = new RColor { R = 50, G = 50, B = 50 }, Style = 1 };
            rs.SubSectionFont = new RFont() { Face = "Times", Size = 15, Color = new RColor { R = 50, G = 50, B = 50 }, Style = 1 };
            rs.RegularFont = new RFont() { Face = "Times", Size = 12, Color = new RColor { R = 12, G = 12, B = 12 }, Style = 0 };

            rs.ChapterWord = "Rozdział: ";
            rs.ImageBorderColor = new RColor() { R = 125, G = 200, B = 16 };
            rs.ImageCaptionWord = "Rys: ";
            rs.ImageMarginBottom = 20;
            rs.ImageMarginTop = 20;
            rs.ImgPath = "C:\\";
            rs.IsTwoSidePrint = 0;
            rs.MarginBottom = 20;
            rs.MarginRight = 20;
            rs.MarginsLeft = 20;
            rs.MarginTop = 20;
            rs.PageSize = "A4";
            rs.ReportPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Raport ANARIS.pdf");
            rs.ReportTitle = "Ocena ryzyka";
            rs.SectionWord = "";
            rs.TableBorderColor = new RColor() { R = 16, G = 20, B = 167 };
            rs.TableCaptionWord = "Tablica: ";
            rs.TableMarginBottom = 20;
            rs.TableMarginTop = 20;

            pts.ReportSettings = rs;

            ANARIS.Dgv dgv = MapDgvProperties(old.DataBase.dgv);
            pts.DataBase.dgv = dgv;

            pts.DataBase.valueManager = new ANARIS.DataBaseValues();
            pts.DataBase.valueManager.ValuesDescription = old.DataBase.valueManager.ValuesDescription;

            foreach (SingleValue sv in old.DataBase.valueManager.valueList)
            {
                ANARIS.SingleValue ns= new ANARIS.SingleValue();
                ns.description = sv.description;
                ns.name = sv.name;
                ns.text = sv.text;
                ns.value = sv.value;

                pts.DataBase.valueManager.valueList.Add(ns);
            }            

            ANARIS.DataBaseCategories categoryManager = new ANARIS.DataBaseCategories();
            foreach (Category oldCategory in old.DataBase.categoryManager.List)
            {

                ANARIS.Category category = new ANARIS.Category();
                category.text = oldCategory.text;
                category.name = oldCategory.name;
                category.description = oldCategory.description;


                foreach (SubCategory oldSubCategory in oldCategory.subCategories)
                {
                    ANARIS.SubCategory subCategory = new ANARIS.SubCategory();

                    subCategory.text = oldSubCategory.text;
                    subCategory.name = oldSubCategory.name;
                    subCategory.description = oldSubCategory.description;

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
                singleRisk.Print = oldsingleRisk.Print;

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

                    elementaryRisk.Print = oldElementary.Print;

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


        #region MODEL VERSION 1.6.0.0

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
            public bool Print { get; set; }

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

            public bool Print { get; set; }           

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
            public DataBaseValues valueManager { get; set; }
            public DataBaseCategories categoryManager { get; set; }
            public RiskCollection riskManager { get; set; }
            
            public DBToSave()
            {
                dgv = new Dgv();
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
            
        }

        [Serializable]
        public class ProjectToSave
        {
            public ProjectProperties Properties { get; set; }
            public DBToSave DataBase { get; set; }
            public RAToSave RiskAnalysis { get; set; }
            public ReportSettings ReportSettings { get; set; }            
        }

        #endregion

    }
}