using ANARIS.BLL.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ANARIS.BLL.Load
{
    public class LoadAnaris_v_1_0
    {

        //public static ProjectToSave Load(string filePath)
        //{


        //    string tmpData = string.Empty;
        //    List<string> tmpList = new List<string>();
        //    DateTime tmpDate = new DateTime();
        //    List<XElement> tmpXElemnts = new List<XElement>();


        //    XDocument File = new XDocument();
        //    File = XDocument.Load(filePath);

        //    XElement xmlProjectToSave = File.Elements().ToList()[0];

        //    ProjectToSave projectToSave = new ProjectToSave();
        //    projectToSave.Properties = new ProjectProperties();
        //    XElement xmlProjectProperties = xmlProjectToSave.Element("Properties");
        //    //tmpData = xmlProjectToSave.Element("projectName").Value;
        //    //projectToSave.Properties.projectName = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    tmpData = xmlProjectProperties.Element("programVersion").Value;
        //    projectToSave.Properties.programVersion = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;


        //    tmpData = xmlProjectProperties.Element("filePath").Value;
        //    projectToSave.Properties.filePath = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    tmpData = xmlProjectProperties.Element("creationTime").Value;
        //    try
        //    {
        //        tmpDate = DateTime.Parse(tmpData);
        //    }
        //    catch
        //    {
        //        tmpDate = DateTime.UtcNow;
        //    }
        //    projectToSave.Properties.creationTime = tmpDate;

        //    tmpData = xmlProjectProperties.Element("modifiedTime").Value;
        //    try
        //    {
        //        tmpDate = DateTime.Parse(tmpData);
        //    }
        //    catch
        //    {
        //        tmpDate = DateTime.UtcNow;
        //    }
        //    projectToSave.Properties.modifiedTime = tmpDate;

        //    tmpXElemnts = xmlProjectProperties.Elements("Authors").ToList();
        //    foreach (XElement element in tmpXElemnts)
        //    {
        //        if (!string.IsNullOrEmpty(element.Value))
        //        {
        //            projectToSave.Properties.Authors.Add(element.Value);
        //        }
        //    }

        //    tmpData = xmlProjectProperties.Element("organisation").Value;
        //    projectToSave.Properties.organisation = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    XElement xmlDataBase = xmlProjectToSave.Element("DataBase");

        //    projectToSave.DataBase = new DBToSave();

        //    //tmpData = xmlDataBase.Element("programVersion").Value;
        //    //projectToSave.DataBase.programVersion = (string.IsNullOrEmpty(tmpData))? string.Empty : tmpData;

        //    dbBasicInfo basicInformation = new dbBasicInfo();

        //    XElement xmlBasicInformation = xmlDataBase.Element("basicInformation");

        //    tmpData = xmlBasicInformation.Element("dbName").Value;
        //    basicInformation.dbName = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    tmpData = xmlBasicInformation.Element("dbFileName").Value;
        //    basicInformation.dbFileName = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    tmpData = xmlBasicInformation.Element("dbDirrectory").Value;
        //    basicInformation.dbDirrectory = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    tmpData = xmlBasicInformation.Element("dbOrganisationName").Value;
        //    basicInformation.dbOrganisationName = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    //tmpData = xmlBasicInformation.Element("dbMuseumName").Value;
        //    //basicInformation.dbMuseumName = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    //tmpData = xmlBasicInformation.Element("dbMuseumAdres").Value;
        //    //basicInformation.dbMuseumAdres = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    tmpXElemnts = xmlProjectProperties.Elements("dbAuthorsList").ToList();
        //    foreach (XElement element in tmpXElemnts)
        //    {
        //        if (!string.IsNullOrEmpty(element.Value))
        //        {
        //            basicInformation.dbAuthorsList.Add(element.Value);
        //        }
        //    }

        //    projectToSave.DataBase.basicInformation = basicInformation;
        //    XElement xmlDgv = xmlDataBase.Element("dgv");
        //    Dgv dgv = ReadDgvFromXml(xmlDgv);

        //    projectToSave.DataBase.dgv = dgv;

        //    List<SingleValue> valueManager = new List<SingleValue>();

        //    tmpXElemnts = xmlDataBase.Element("valueManager").Elements("SingleValue").ToList();
        //    foreach (XElement xmlSigleValue in tmpXElemnts)
        //    {
        //        SingleValue singleValue = new SingleValue();

        //        tmpData = xmlSigleValue.Element("text").Value;
        //        singleValue.text = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = xmlSigleValue.Element("name").Value;
        //        singleValue.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = xmlSigleValue.Element("value").Value;
        //        singleValue.value = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //        valueManager.Add(singleValue);
        //    }

        //    projectToSave.DataBase.valueManager = valueManager;

        //    DataBaseCategories categoryManager = new DataBaseCategories();

        //    List<XElement> xmlCategories = xmlDataBase.Element("categoryManager").Element("List").Elements("Category").ToList();
        //    foreach (XElement xmlCategory in xmlCategories)
        //    {

        //        Category category = new Category();

        //        tmpData = xmlCategory.Element("text").Value;
        //        category.text = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = xmlCategory.Element("name").Value;
        //        category.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpXElemnts = xmlCategory.Element("subCategories").Elements("SubCategory").ToList();
        //        foreach (XElement xmlSubCategory in tmpXElemnts)
        //        {
        //            SubCategory subCategory = new SubCategory();

        //            tmpData = xmlSubCategory.Element("text").Value;
        //            subCategory.text = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            tmpData = xmlSubCategory.Element("name").Value;
        //            subCategory.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            category.subCategories.Add(subCategory);
        //        }

        //        categoryManager.List.Add(category);

        //    }


        //    projectToSave.DataBase.categoryManager = categoryManager;
        //    RiskCollection riskCollection = new RiskCollection();
        //    //riskCollection.Risk = new List<SingleRisk>();

        //    List<XElement> xmlSingleRisks = xmlDataBase.Element("riskManager").Element("Risk").Elements("SingleRisk").ToList();

        //    foreach (XElement xmlsingleRisk in xmlSingleRisks)
        //    {
        //        SingleRisk singleRisk = new SingleRisk();

        //        tmpData = xmlsingleRisk.Element("name").Value;
        //        singleRisk.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpXElemnts = xmlsingleRisk.Element("DistinctiveRisk").Elements("ElementaryRisk").ToList();
        //        foreach (XElement xmlElementary in tmpXElemnts)
        //        {
        //            ElementaryRisk elementaryRisk = new ElementaryRisk();

        //            tmpData = xmlElementary.Element("name").Value;
        //            elementaryRisk.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            tmpData = xmlElementary.Element("opis").Value;
        //            elementaryRisk.opis = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            tmpData = xmlElementary.Element("AHigh").Value;
        //            elementaryRisk.AHigh = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("AMid").Value;
        //            elementaryRisk.AMid = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("ALow").Value;
        //            elementaryRisk.ALow = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("opisA").Value;
        //            elementaryRisk.opisA = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            tmpData = xmlElementary.Element("BHigh").Value;
        //            elementaryRisk.BHigh = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("BMid").Value;
        //            elementaryRisk.BMid = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("BLow").Value;
        //            elementaryRisk.BLow = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("opisB").Value;
        //            elementaryRisk.opisB = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            tmpData = xmlElementary.Element("CHigh").Value;
        //            elementaryRisk.CHigh = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("CMid").Value;
        //            elementaryRisk.CMid = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("CLow").Value;
        //            elementaryRisk.CLow = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //            tmpData = xmlElementary.Element("opisC").Value;
        //            elementaryRisk.opisC = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            singleRisk.DistinctiveRisk.Add(elementaryRisk);
        //        }


        //        riskCollection.Risk.Add(singleRisk);
        //    }

        //    projectToSave.DataBase.riskManager = riskCollection;

        //    projectToSave.RiskAnalysis = new RAToSave();
        //    XElement xmlRAToSave = xmlProjectToSave.Element("RiskAnalysis").Element("RiskAnalysis");

        //    List<XElement> xmlRiskdgvs = xmlRAToSave.Elements("RiskDgvList").ToList();
        //    foreach (XElement xmlRiskDgv in xmlRiskdgvs)
        //    {
        //        RiskDgvList riskDgvList = new RiskDgvList();

        //        tmpData = xmlRiskDgv.Element("name").Value;
        //        riskDgvList.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpXElemnts = xmlRiskDgv.Element("dgvList").Elements("Dgv").ToList();
        //        foreach (XElement xmlDgvR in tmpXElemnts)
        //        {
        //            Dgv dgvR = ReadDgvFromXml(xmlDgvR);
        //            riskDgvList.dgvList.Add(dgvR);
        //        }

        //        projectToSave.RiskAnalysis.RiskAnalysis.Add(riskDgvList);
        //    }

        //    return projectToSave;
        //}


        //private static Dgv ReadDgvFromXml(XElement xmlDgv)
        //{
        //    Dgv dgv = new Dgv();
        //    string tmpData = string.Empty;
        //    List<XElement> tmpXElemnts = new List<XElement>();

        //    tmpData = xmlDgv.Element("name").Value;
        //    dgv.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //    tmpData = xmlDgv.Element("collectionTotalValue").Value;
        //    dgv.collectionTotalValue = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //    tmpData = xmlDgv.Element("collectionTotalNumber").Value;
        //    dgv.collectionTotalNumber = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //    tmpData = xmlDgv.Element("MR").Value;
        //    dgv.MR = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //    tmpData = xmlDgv.Element("MRmax").Value;
        //    dgv.MRmax = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //    tmpData = xmlDgv.Element("MRmin").Value;
        //    dgv.MRmin = (string.IsNullOrEmpty(tmpData)) ? 0.0 : double.Parse(tmpData);

        //    tmpXElemnts = xmlDgv.Element("columns").Elements("DgvColumn").ToList();

        //    foreach (XElement column in tmpXElemnts)
        //    {
        //        DgvColumn dgvColumn = new DgvColumn();

        //        tmpData = column.Element("name").Value;
        //        dgvColumn.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = column.Element("headerText").Value;
        //        dgvColumn.headerText = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = column.Element("index").Value;
        //        dgvColumn.index = (string.IsNullOrEmpty(tmpData)) ? 0 : int.Parse(tmpData);

        //        tmpData = column.Element("type").Value;
        //        dgvColumn.type = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = column.Element("visible").Value;
        //        dgvColumn.visible = (string.IsNullOrEmpty(tmpData)) ? true : bool.Parse(tmpData);

        //        tmpData = column.Element("width").Value;
        //        dgvColumn.width = (string.IsNullOrEmpty(tmpData)) ? 0 : int.Parse(tmpData);

        //        tmpData = column.Element("sortable").Value;
        //        dgvColumn.sortable = (string.IsNullOrEmpty(tmpData)) ? true : bool.Parse(tmpData);

        //        tmpData = column.Element("cellStyle").Value;
        //        dgvColumn.cellStyle = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        //tmpData = column.Element("valueType").Value;
        //        //dgvColumn.valueType = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = column.Element("isARcol").Value;
        //        dgvColumn.isARcol = (string.IsNullOrEmpty(tmpData)) ? false : bool.Parse(tmpData);

        //        tmpData = column.Element("isDBcol").Value;
        //        dgvColumn.isDBcol = (string.IsNullOrEmpty(tmpData)) ? true : bool.Parse(tmpData);

        //        dgv.columns.Add(dgvColumn);
        //    }

        //    List<XElement> xmlDgvRows = xmlDgv.Element("rows").Elements("DgvRow").ToList();

        //    foreach (XElement row in xmlDgvRows)
        //    {
        //        DgvRow dgvRow = new DgvRow();

        //        tmpData = row.Element("isDBrow").Value;
        //        dgvRow.isDBrow = (string.IsNullOrEmpty(tmpData)) ? true : bool.Parse(tmpData);

        //        tmpData = row.Element("isARrow").Value;
        //        dgvRow.isARrow = (string.IsNullOrEmpty(tmpData)) ? true : bool.Parse(tmpData);

        //        tmpData = row.Element("name").Value;
        //        dgvRow.name = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpData = row.Element("parent").Value;
        //        dgvRow.parent = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //        tmpXElemnts = row.Elements("childRows").ToList();
        //        foreach (XElement element in tmpXElemnts)
        //        {
        //            if (!string.IsNullOrEmpty(element.Value))
        //            {
        //                dgvRow.childRows.Add(element.Value);
        //            }
        //        }


        //        List<XElement> xmlDgvCells = row.Element("cells").Elements("DgvCell").ToList();

        //        foreach (XElement cell in xmlDgvCells)
        //        {
        //            DgvCell dgvCell = new DgvCell();

        //            tmpData = (cell.Element("value") != null) ? cell.Element("value").Value : string.Empty;
        //            dgvCell.value = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            tmpData = (cell.Element("formula") != null) ? cell.Element("formula").Value : string.Empty;
        //            dgvCell.formula = (string.IsNullOrEmpty(tmpData)) ? string.Empty : tmpData;

        //            dgvRow.cells.Add(dgvCell);
        //        }

        //        dgv.rows.Add(dgvRow);
        //    }

        //    return dgv;
        //}

        public static ANARIS.ProjectToSave Load(string filePath)
        {
            ProjectToSave project = new ProjectToSave();

            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                XmlSerializer bf = new XmlSerializer(typeof(ProjectToSave));
                project = (ProjectToSave)bf.Deserialize(file);
                file.Close();
            }

            ANARIS.ProjectToSave mapedProject = new ANARIS.ProjectToSave();
            MapModelsProperties(project, mapedProject);

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

            foreach (string author in old.Properties.Authors)
            {
                string[] names = author.Split(';');
                Author newone = new Author();
                newone.FirstName = names[0];
                newone.LastName = (names.Length >= 2) ? names[1] : string.Empty;
                pts.Properties.Authors.Add(newone);
            }

            pts.Properties.Organization = new Organization() { Name = old.Properties.organisation };

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


        #region MODEL VERSION 1.0.0.0


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
            public List<string> Authors { get; set; }
            public string organisation { get; set; }

            public ProjectProperties()
            {
                Authors = new List<string>();
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
