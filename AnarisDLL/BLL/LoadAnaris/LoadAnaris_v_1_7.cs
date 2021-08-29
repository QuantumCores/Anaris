using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.Report;
using AnarisDLL.BLL.SaveAnaris;
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

namespace AnarisDLL.BLL.LoadAnaris
{
    public class LoadAnaris_v_1_7
    {
        public static Anaris.Anaris Load(string filePath)
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

            Anaris.Anaris mapedProject = new Anaris.Anaris();
            mapedProject.ProjectProperties.FilePath = filePath;
            MapModelsProperties(file, mapedProject);


            return mapedProject;
        }

        private static void MapModelsProperties(ProjectToSave old, Anaris.Anaris pts)
        {
            LoadDataBase.LoadDataBase_v_1_7.MapModelsProperties(old.DataBase, pts.DataBase);

            pts.ProjectProperties = new Anaris.ProjectProperties();
            pts.ProjectProperties.ProjectName = old.Properties.projectName;
            pts.ProjectProperties.ProgramVersion = old.Properties.programVersion;
            pts.ProjectProperties.FilePath = old.Properties.filePath;
            pts.ProjectProperties.CreationTime = old.Properties.creationTime;
            pts.ProjectProperties.ModifiedTime = old.Properties.modifiedTime;
            pts.ProjectProperties.Authors = new List<Anaris.Author>();

            foreach (Author o in old.Properties.Authors)
            {
                Anaris.Author tmp = new Anaris.Author();

                tmp.CellPhone = o.CellPhone;
                tmp.Email = o.Email;
                tmp.Fax = o.Fax;
                tmp.FirstName = o.FirstName;
                tmp.LastName = o.LastName;
                tmp.JobDescription = o.JobDescription;
                tmp.WorkPhone = o.WorkPhone;

                if (o.Organization != null)
                {
                    tmp.Organization.City = o.Organization.City;
                    tmp.Organization.Name = o.Organization.Name;
                    tmp.Organization.Postal = o.Organization.Postal;
                    tmp.Organization.Street = o.Organization.Street;
                }
            }

            pts.ProjectProperties.ReportIntro = old.Properties.ReportIntro;

            pts.ProjectProperties.Organization.City = old.Properties.Organization.City;
            pts.ProjectProperties.Organization.Name = old.Properties.Organization.Name;
            pts.ProjectProperties.Organization.Postal = old.Properties.Organization.Postal;
            pts.ProjectProperties.Organization.Street = old.Properties.Organization.Street;

            pts.ReportSettings.ChapterFont.Color.R = old.ReportSettings.ChapterFont.Color.R;
            pts.ReportSettings.ChapterFont.Color.G = old.ReportSettings.ChapterFont.Color.G;
            pts.ReportSettings.ChapterFont.Color.B = old.ReportSettings.ChapterFont.Color.B;

            pts.ReportSettings.ChapterFont.Face = old.ReportSettings.ChapterFont.Face;
            pts.ReportSettings.ChapterFont.Size = old.ReportSettings.ChapterFont.Size;
            pts.ReportSettings.ChapterFont.Style = old.ReportSettings.ChapterFont.Style;

            pts.ReportSettings.ChapterWord = old.ReportSettings.ChapterWord;
            pts.ReportSettings.ImageBorderColor.R = old.ReportSettings.ImageBorderColor.R;
            pts.ReportSettings.ImageBorderColor.G = old.ReportSettings.ImageBorderColor.G;
            pts.ReportSettings.ImageBorderColor.B = old.ReportSettings.ImageBorderColor.B;

            pts.ReportSettings.ImageBorderWidth = old.ReportSettings.ImageBorderWidth;
            pts.ReportSettings.ImageCaptionWord = old.ReportSettings.ImageCaptionWord;
            pts.ReportSettings.ImageMarginBottom = old.ReportSettings.ImageMarginBottom;
            pts.ReportSettings.ImageMarginTop = old.ReportSettings.ImageMarginTop;
            pts.ReportSettings.ImgPath = old.ReportSettings.ImgPath;
            pts.ReportSettings.IsTwoSidePrint = old.ReportSettings.IsTwoSidePrint;
            pts.ReportSettings.MarginBottom = old.ReportSettings.MarginBottom;
            pts.ReportSettings.MarginRight = old.ReportSettings.MarginRight;
            pts.ReportSettings.MarginsLeft = old.ReportSettings.MarginsLeft;
            pts.ReportSettings.MarginTop = old.ReportSettings.MarginTop;
            pts.ReportSettings.PageSize = old.ReportSettings.PageSize;


            pts.ReportSettings.ReportDate = old.ReportSettings.ReportDate;
            pts.ReportSettings.ReportPath = old.ReportSettings.ReportPath;
            pts.ReportSettings.ReportTitle = old.ReportSettings.ReportTitle;
            pts.ReportSettings.SectionWord = old.ReportSettings.SectionWord;

            pts.ReportSettings.SubSectionWord = old.ReportSettings.SubSectionWord;
            pts.ReportSettings.TableBorderColor.R = old.ReportSettings.TableBorderColor.R;
            pts.ReportSettings.TableBorderColor.G = old.ReportSettings.TableBorderColor.G;
            pts.ReportSettings.TableBorderColor.B = old.ReportSettings.TableBorderColor.B;


            pts.ReportSettings.TableBorderWidth = old.ReportSettings.TableBorderWidth;
            pts.ReportSettings.TableCaptionWord = old.ReportSettings.TableCaptionWord;
            pts.ReportSettings.TableMarginBottom = old.ReportSettings.TableMarginBottom;
            pts.ReportSettings.TableMarginTop = old.ReportSettings.TableMarginTop;

            pts.ReportSettings.TitleFont.Color.R = old.ReportSettings.TitleFont.Color.R;
            pts.ReportSettings.TitleFont.Color.G = old.ReportSettings.TitleFont.Color.G;
            pts.ReportSettings.TitleFont.Color.B = old.ReportSettings.TitleFont.Color.B;

            pts.ReportSettings.TitleFont.Face = old.ReportSettings.TitleFont.Face;
            pts.ReportSettings.TitleFont.Size = old.ReportSettings.TitleFont.Size;
            pts.ReportSettings.TitleFont.Style = old.ReportSettings.TitleFont.Style;

            pts.ReportSettings.RegularFont.Color.R = old.ReportSettings.RegularFont.Color.R;
            pts.ReportSettings.RegularFont.Color.G = old.ReportSettings.RegularFont.Color.G;
            pts.ReportSettings.RegularFont.Color.B = old.ReportSettings.RegularFont.Color.B;

            pts.ReportSettings.RegularFont.Face = old.ReportSettings.RegularFont.Face;
            pts.ReportSettings.RegularFont.Size = old.ReportSettings.RegularFont.Size;
            pts.ReportSettings.RegularFont.Style = old.ReportSettings.RegularFont.Style;

            pts.ReportSettings.SectionFont.Color.R = old.ReportSettings.SectionFont.Color.R;
            pts.ReportSettings.SectionFont.Color.G = old.ReportSettings.SectionFont.Color.G;
            pts.ReportSettings.SectionFont.Color.B = old.ReportSettings.SectionFont.Color.B;

            pts.ReportSettings.SectionFont.Face = old.ReportSettings.SectionFont.Face;
            pts.ReportSettings.SectionFont.Size = old.ReportSettings.SectionFont.Size;
            pts.ReportSettings.SectionFont.Style = old.ReportSettings.SectionFont.Style;

            pts.ReportSettings.SubSectionFont.Color.R = old.ReportSettings.SubSectionFont.Color.R;
            pts.ReportSettings.SubSectionFont.Color.G = old.ReportSettings.SubSectionFont.Color.G;
            pts.ReportSettings.SubSectionFont.Color.B = old.ReportSettings.SubSectionFont.Color.B;

            pts.ReportSettings.SubSectionFont.Face = old.ReportSettings.SubSectionFont.Face;
            pts.ReportSettings.SubSectionFont.Size = old.ReportSettings.SubSectionFont.Size;
            pts.ReportSettings.SubSectionFont.Style = old.ReportSettings.SubSectionFont.Style;


            //foreach (SingleRisk oldsingleRisk in old.DataBase.riskManager.Risk)
            //{
            //    AnarisDLL.BLL.Risk.SingleRisk singleRisk = new AnarisDLL.BLL.Risk.SingleRisk();

            //    singleRisk.name = oldsingleRisk.name;
            //    singleRisk.Print = oldsingleRisk.Print;

            //    foreach (ElementaryRisk oldElementary in oldsingleRisk.DistinctiveRisk)
            //    {
            //        AnarisDLL.BLL.Risk.ElementaryRisk elementaryRisk = new AnarisDLL.BLL.Risk.ElementaryRisk();

            //        elementaryRisk.name = oldElementary.name;
            //        elementaryRisk.text = oldElementary.name;
            //        elementaryRisk.opis = oldElementary.opis;

            //        elementaryRisk.AHigh = oldElementary.AHigh;
            //        elementaryRisk.AMid = oldElementary.AMid;
            //        elementaryRisk.ALow = oldElementary.ALow;
            //        elementaryRisk.opisA = oldElementary.opisA;

            //        elementaryRisk.BHigh = oldElementary.BHigh;
            //        elementaryRisk.BMid = oldElementary.BMid;
            //        elementaryRisk.BLow = oldElementary.BLow;
            //        elementaryRisk.opisB = oldElementary.opisB;

            //        elementaryRisk.CHigh = oldElementary.CHigh;
            //        elementaryRisk.CMid = oldElementary.CMid;
            //        elementaryRisk.CLow = oldElementary.CLow;
            //        elementaryRisk.opisC = oldElementary.opisC;

            //        elementaryRisk.Print = oldElementary.Print;

            //        singleRisk.DistinctiveRisk.Add(elementaryRisk);
            //    }


            //    pts.ScenarioManager.Risks.Add(singleRisk);
            //}            

            Risk.RiskCollection riskCollection = new Risk.RiskCollection();
            
            foreach (SingleRisk oldsingleRisk in old.DataBase.riskManager.Risk)
            {
                Risk.SingleRisk singleRisk = new Risk.SingleRisk();

                singleRisk.name = oldsingleRisk.name;
                singleRisk.Print = oldsingleRisk.Print;
                riskCollection.Risks.Add(singleRisk);

                foreach (ElementaryRisk oldElementary in oldsingleRisk.DistinctiveRisk)
                {
                    Risk.ElementaryRisk elementaryRisk = new Risk.ElementaryRisk();
                    
                    //elementaryRisk.Name = riskCollection.GenerateNewName();
                    elementaryRisk.Name = RandomNameGenerator.GenerateAndCheck(riskCollection.Risks.SelectMany(er => er.DistinctiveRisk).ToList(), Risk.RiskCollection.ScenarioNameLength);
                    elementaryRisk.Text = oldElementary.name;
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

                    //singleRisk.DistinctiveRisk.Add(elementaryRisk);
                    riskCollection.Risks.Last().DistinctiveRisk.Add(elementaryRisk);
                }

                //riskCollection.Risks.Add(singleRisk);
            }

            pts.ScenarioManager = riskCollection;


            foreach (RiskDgvList oldRiskDgv in old.RiskAnalysis.RiskAnalysis)
            {
                Anaris.RiskDgvList riskDgvList = new Anaris.RiskDgvList();
                int riskIndex = old.RiskAnalysis.RiskAnalysis.IndexOf(oldRiskDgv);

                riskDgvList.name = oldRiskDgv.name;

                foreach (Dgv oldDgvR in oldRiskDgv.dgvList)
                {
                    int scenarioIndex = oldRiskDgv.dgvList.IndexOf(oldDgvR);
                    oldDgvR.rows.Remove(oldDgvR.rows.Last());

                    Risk.ElementaryRisk elr = null;
                    if (scenarioIndex > 0)
                    {
                       elr = riskCollection.Risks[riskIndex].DistinctiveRisk[scenarioIndex - 1];
                    }
                    
                    AnarisGrid.Dgv dgvR = LoadDataBase.LoadDataBase_v_1_7.MapDgvProperties(oldDgvR, elr);
                    riskDgvList.dgvList.Add(dgvR);
                }

                pts.RiskAnalysis.RiskAnalysis.Add(riskDgvList);
            }

        }

        #region MODEL VERSION 1.7.0.0

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
            public string valueType { get; set; } //?
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
            public string ReportIntro { get; set; }

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
        public class Author
        {
            public Author()
            {

            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
            public string CellPhone { get; set; }
            public string WorkPhone { get; set; }
            public string Fax { get; set; }
            public string Email { get; set; }
            public Organization Organization { get; set; }
            public string JobDescription { get; set; }

        }

        [Serializable]
        public class Organization
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string Postal { get; set; }
            public string Street { get; set; }

            public Organization()
            {

            }

        }

        [Serializable]
        public class RColor
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }

        }

        [Serializable]
        public class RFont
        {
            public RFont()
            {
                Color = new RColor();
            }
            public float Size { get; set; }
            public string Face { get; set; }
            public RColor Color { get; set; }
            public int Style { get; set; }
        }

        [Serializable]
        public class ReportSettings
        {

            public ReportSettings()
            {
                TitleFont = new RFont();
                ChapterFont = new RFont();
                SectionFont = new RFont();
                SubSectionFont = new RFont();
                RegularFont = new RFont();
            }

            //geSubSectionFontnral setings
            public string ReportTitle { get; set; }
            public string ReportPath { get; set; }
            public string ImgPath { get; set; }
            public DateTime ReportDate { get; set; }


            //pageSettings
            public string PageSize { get; set; }
            public float MarginsLeft { get; set; }
            public float MarginTop { get; set; }
            public float MarginRight { get; set; }
            public float MarginBottom { get; set; }
            public int IsTwoSidePrint { get; set; }

            //Fonts
            public RFont TitleFont { get; set; }
            public RFont ChapterFont { get; set; }
            public RFont SectionFont { get; set; }
            public RFont SubSectionFont { get; set; }
            public RFont RegularFont { get; set; }

            public string ChapterWord { get; set; }
            public string SectionWord { get; set; }
            public string SubSectionWord { get; set; }

            //Table settings
            public string TableCaptionWord { get; set; }
            public int TableMarginTop { get; set; }
            public int TableMarginBottom { get; set; }
            public int TableBorderWidth { get; set; }
            public RColor TableBorderColor { get; set; }

            //image
            public string ImageCaptionWord { get; set; }
            public int ImageMarginTop { get; set; }
            public int ImageMarginBottom { get; set; }
            public int ImageBorderWidth { get; set; }
            public RColor ImageBorderColor { get; set; }

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
