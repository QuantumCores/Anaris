using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnarisDLL.BLL.SaveDataBase;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace AnarisDLL.BLL.LoadDataBase
{
    using Helpers;
    using System.Globalization;
    using static AnarisDLL.BLL.LoadAnaris.LoadAnaris_v_1_7;

    public class LoadDataBase_v_1_7
    {

        public static Database.Database Load(string filePath)
        {
            DBToSave file = new DBToSave();

            using (ZipFile zip = new ZipFile(filePath))
            {
                ZipEntry dataEntry = zip.Entries.Where(e => e.FileName.Contains(SaveDataBase.SaveDataBase.DataFileName)).FirstOrDefault();
                using (MemoryStream ms = new MemoryStream())
                {
                    dataEntry.Extract(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer bf = new XmlSerializer(typeof(DBToSave));
                    file = (DBToSave)bf.Deserialize(ms);
                }
            }

            Database.Database mapedProject = new Database.Database();
            mapedProject.ProjectProperties.FilePath = filePath;
            MapModelsProperties(file, mapedProject);

            return mapedProject;
        }

        internal static void MapModelsProperties(DBToSave old, Database.Database pts)
        {
            pts.ProjectProperties.ProjectName = old.basicInformation.dbFileName;
            pts.ProjectProperties.ProgramVersion = old.programVersion != null ? old.programVersion : "";
            pts.ProjectProperties.FilePath = Path.Combine(old.basicInformation.dbDirrectory, pts.ProjectProperties.ProjectName + ".anrb");
            pts.ProjectProperties.CreationTime = DateTime.UtcNow;
            pts.ProjectProperties.ModifiedTime = DateTime.UtcNow;

            List<AnarisDLL.BLL.Anaris.Author> authors = new List<AnarisDLL.BLL.Anaris.Author>();
            foreach (string author in old.basicInformation.dbAuthorsList)
            {
                string[] tab = author.Split(' ');
                AnarisDLL.BLL.Anaris.Author tmp = new AnarisDLL.BLL.Anaris.Author();
                tmp.FirstName = tab[0];
                if (tab.Length > 1)
                {
                    tmp.LastName = tab[1];
                }

                authors.Add(tmp);
            }
            pts.ProjectProperties.Authors = authors;
            pts.ProjectProperties.ReportIntro = "";
            pts.ProjectProperties.Organization = new AnarisDLL.BLL.Anaris.Organization() { Name = old.basicInformation.dbOrganisationName };

            pts.dgv = MapDgvProperties(old.dgv, null);

            pts.valueManager = new AnarisDLL.BLL.Value.DataBaseValues();
            pts.valueManager.ValuesDescription = old.valueManager.ValuesDescription;

            foreach (SingleValue sv in old.valueManager.valueList)
            {
                AnarisDLL.BLL.Value.SingleValue ns = new Value.SingleValue();
                ns.description = sv.description;
                ns.name = sv.name;
                ns.text = sv.text;
                ns.value = sv.value;

                pts.valueManager.valueList.Add(ns);
            }

            AnarisDLL.BLL.Category.DataBaseCategories categoryManager = new BLL.Category.DataBaseCategories();
            foreach (Category oldCategory in old.categoryManager.List)
            {
                AnarisDLL.BLL.Category.Category category = new AnarisDLL.BLL.Category.Category();
                category.text = oldCategory.text;
                category.name = oldCategory.name;
                category.description = oldCategory.description;

                foreach (SubCategory oldSubCategory in oldCategory.subCategories)
                {
                    AnarisDLL.BLL.Category.SubCategory subCategory = new AnarisDLL.BLL.Category.SubCategory();

                    subCategory.text = oldSubCategory.text;
                    subCategory.name = oldSubCategory.name;
                    subCategory.description = oldSubCategory.description;

                    category.subCategories.Add(subCategory);
                }

                categoryManager.List.Add(category);
            }


            pts.categoryManager = categoryManager;



        }

        internal static AnarisDLL.BLL.AnarisGrid.Dgv MapDgvProperties(Dgv oldDgv, Risk.ElementaryRisk elr)
        {
            AnarisDLL.BLL.AnarisGrid.Dgv dgv = new AnarisDLL.BLL.AnarisGrid.Dgv();
            string tmpData = string.Empty;
            List<XElement> tmpXElemnts = new List<XElement>();

            if (elr != null)
            {
                dgv.name = elr.Name;
                dgv.text = elr.Text;
            }
            else
            {
                dgv.name = oldDgv.name;
                dgv.text = oldDgv.name;
            }

            dgv.collectionTotalValue = oldDgv.collectionTotalValue;
            dgv.collectionTotalNumber = oldDgv.collectionTotalNumber;
            dgv.MR = oldDgv.MR;
            dgv.MRmax = oldDgv.MRmax;
            dgv.MRmin = oldDgv.MRmin;
            List<int> numberColumns = new List<int>();

            string coma = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            foreach (DgvColumn oldColumn in oldDgv.columns)
            {

                AnarisDLL.BLL.AnarisGrid.DgvColumn dgvColumn = new AnarisDLL.BLL.AnarisGrid.DgvColumn();

                dgvColumn.name = oldColumn.name;
                dgvColumn.headerText = oldColumn.headerText;
                dgvColumn.index = oldColumn.index;
                dgvColumn.type = oldColumn.type;
                dgvColumn.visible = oldColumn.visible;
                dgvColumn.width = (int)(oldColumn.width * 1.2);
                dgvColumn.sortable = oldColumn.sortable;
                dgvColumn.cellStyle = oldColumn.cellStyle;
                dgvColumn.valueType = oldColumn.valueType;
                dgvColumn.isARcol = oldColumn.isARcol;
                dgvColumn.isDBcol = oldColumn.isDBcol;

                if (oldColumn.name == "Number" || oldColumn.name == "CLow" || oldColumn.name == "CMid" || oldColumn.name == "CHigh")
                {
                    numberColumns.Add(oldColumn.index);

                    switch (oldColumn.name)
                    {
                        case "Number":
                            dgvColumn.headerText = "Liczba";
                            break;
                        case "CLow":
                            dgvColumn.headerText = "Dolna";
                            break;
                        case "CMid":
                            dgvColumn.headerText = "Prawdopodobna";
                            break;
                        case "CHigh":
                            dgvColumn.headerText = "Górna";
                            break;

                    }
                }

                dgv.columns.Add(dgvColumn);
            }


            foreach (DgvRow oldRow in oldDgv.rows)
            {
                AnarisDLL.BLL.AnarisGrid.DgvRow dgvRow = new AnarisDLL.BLL.AnarisGrid.DgvRow();

                dgvRow.isDBrow = oldRow.isDBrow;
                dgvRow.isARrow = oldRow.isARrow;
                dgvRow.name = oldRow.name;
                dgvRow.parent = oldRow.parent;

                foreach (string element in oldRow.childRows)
                {
                    dgvRow.childRows.Add(element);
                }

                for (int i = 0; i < oldRow.cells.Count; i++)
                {

                    DgvCell oldCell = oldRow.cells[i];
                    AnarisDLL.BLL.AnarisGrid.DgvCell dgvCell = new AnarisDLL.BLL.AnarisGrid.DgvCell();

                    dgvCell.value = oldCell.value;
                    dgvCell.formula = oldCell.formula;

                    double outValue = 0;
                    if (double.TryParse(oldCell.value, out outValue))
                    {
                        NumberFormatConverter.ConvertNumberFormat(dgvCell, coma, numberColumns, i);
                    }

                    if (!string.IsNullOrWhiteSpace(dgvCell.formula))
                    {
                        dgvCell.formula = dgvCell.formula.Replace("Ilość", "Liczba");
                    }

                    dgvRow.cells.Add(dgvCell);
                }

                dgv.rows.Add(dgvRow);
            }

            return dgv;
        }


    }
}
