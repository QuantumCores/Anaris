using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Risk;
using AnarisDLL.BLL.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Database
{
    [Serializable]
    public class Database
    {
        public ProjectProperties ProjectProperties { get; set; }
        public DataBaseValues valueManager { get; set; }
        public DataBaseCategories categoryManager { get; set; }
        public Dgv dgv { get; set; }


        public Database()
        {
            ProjectProperties = new ProjectProperties();
            valueManager = new DataBaseValues();
            categoryManager = new DataBaseCategories();
            dgv = new Dgv();
        }

        public static Database Instance { get; set; }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Database instance = new Database();
        }

        public Database CompareManagersData(Database Import)
        {
            Database Delta = new Database();

            //Delta will contain only diferences between Import and current DB
            //If diferences are detected import won't be possible and manual manipuation will have to be performed

            return Delta;
        }

        public void SetUpEmptyProjct()
        {
            for (int r = 0; r < 3; r++)
            {
                dgv.AddRow(true, string.Empty);
                dgv.rows[r].cells[1].value = "Tutaj wpisz nazwę identyfikującą pewną grupę kolekcji np. \"Obrazy olejne Jana Matejki\"";                
            }
        }

        public void SetColumnWidths(List<double> widths)
        {
            for (int i =0; i<dgv.columns.Count; i++)
            {
                dgv.columns[i].width = (int)widths[i];
            }
        }

        //public static Database MockupDatabase()
        //{
        //    Database db = Instance;

        //    ProjectProperties pp = new ProjectProperties();
        //    pp.CreationTime = DateTime.UtcNow;
        //    pp.FilePath = @"C:\Users\Primus\Desktop\Anaris\Mockup.anrb";
        //    pp.ProgramVersion = "2.0";
        //    pp.ProjectName = "Mockup";
        //    pp.ReportIntro = "To jest wstep do raportu";
        //    pp.Scope = "Zakres prac przy analizie ryzyka";
        //    pp.Authors = new List<Author>() { new Author() { FirstName = "Barbara", LastName = "Swiatkowska", Email = "bs@gmail.com", JobDescription = "Szefowanie" } };
        //    db.ProjectProperties = pp;

        //    DataBaseCategories cat = new DataBaseCategories();
        //    List<Category.Category> c = new List<Category.Category>();
        //    c.Add(new Category.Category() { description = "Pierwsza kategoria", name = "CAT_A00001", text = "Jeden" });
        //    for (int i = 0; i < 5; i++)
        //    {
        //        SubCategory sub = new SubCategory();
        //        sub.text = "Jeden:" + (i + 1);
        //        sub.name = "AB000" + (i + 1);
        //        sub.description = "Podkategoria:" + (i + 1);
        //        c[0].subCategories.Add(sub);
        //    }
        //    c.Add(new Category.Category() { description = "Druga kategoria", name = "CAT_B00001", text = "Dwa" });
        //    cat.List = c;
        //    db.categoryManager = cat;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        SubCategory sub = new SubCategory();
        //        sub.text = "Dwa:" + (i + 1);
        //        sub.name = "BB000" + (i + 1);
        //        sub.description = "Podkategoria:" + (i + 1);
        //        c[0].subCategories.Add(sub);
        //    }

        //    Dgv dg = new Dgv();
        //    dg.columns.Add(new DgvColumn() { headerText = "Grupa", index = 0, isDBcol = true, name = "COL_name" });
        //    for (int i = 0; i < cat.List.Count; i++)
        //    {
        //        Category.Category tmp = cat.List[i];
        //        dg.columns.Add(new DgvColumn() { headerText = tmp.text, index = (i + 1), isDBcol = true, name = tmp.name });
        //    }


        //    for (int i = 0; i < 5; i++)
        //    {
        //        DgvRow row = new DgvRow();
        //        row.isDBrow = true;
        //        row.name = "Row_00" + (2 * i + 1);

        //        foreach (DgvColumn col in dg.columns)
        //        {
        //            DgvCell cell = new DgvCell();
        //            cell.value = "BB000" + (i + 1);
        //            row.cells.Add(cell);
        //        }
        //        dg.rows.Add(row);

        //        row = new DgvRow();
        //        row.isDBrow = true;
        //        row.name = "Row_00" + (2 * i + 2);
        //        foreach (DgvColumn col in dg.columns)
        //        {
        //            DgvCell cell = new DgvCell();
        //            cell.value = "AB000" + (i + 1);
        //            row.cells.Add(cell);
        //        }
        //        dg.rows.Add(row);
        //    }
        //    dg.name = "Database";
        //    db.dgv = dg;

        //    return db;
        //}
    }
}
