using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Value;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL
{
    public class PieChartHelper
    {
        public static int LineLength = 20;

        public static Dictionary<string, double> LoadDataByValueCount(Dgv DB, List<SingleValue> valueList)
        {
            int valueIndex = DB.columns.Find(x => x.name == "Lista").index;
            int numberIndex = DB.columns.Find(x => x.name == "Number").index;

            Dictionary<string, double> ItemsSplitByCategory = new Dictionary<string, double>();

            foreach (SingleValue value in valueList)
            {
                ItemsSplitByCategory.Add(value.text, 0.0);
            }

            for (int i = 0; i < DB.rows.Count - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(DB.rows[i].cells[valueIndex].value) && DB.rows[i].cells[numberIndex].value != null)
                {
                    ItemsSplitByCategory[DB.rows[i].cells[valueIndex].value] += double.Parse(DB.rows[i].cells[numberIndex].value);
                }
            }

            return ItemsSplitByCategory;
        }

        public static Dictionary<string, double> LoadDataByNameCount(Dgv DB, List<SingleValue> valueList)
        {
            int columnIndex = 1;
            int valueIndex = DB.columns.Find(x => x.name == "Lista").index;
            int numberIndex = DB.columns.Find(x => x.name == "Number").index;

            Dictionary<string, double> ItemsSplitByCategory = new Dictionary<string, double>();

            foreach (DgvRow row in DB.rows)
            {
                if (!string.IsNullOrWhiteSpace(row.cells[columnIndex].value) && !ItemsSplitByCategory.ContainsKey(row.cells[columnIndex].value))
                {
                    ItemsSplitByCategory.Add(row.cells[columnIndex].value, 0.0);
                }
            }

            for (int i = 0; i < DB.rows.Count - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(DB.rows[i].cells[columnIndex].value))
                {
                    ItemsSplitByCategory[DB.rows[i].cells[columnIndex].value] += double.Parse(DB.rows[i].cells[numberIndex].value);
                }
            }

            return ItemsSplitByCategory;
        }


        /// <summary>
        /// Loads data for an inbuilt category "Grupa". Splits database rows by string value of this column.
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="valueList"></param>
        /// <returns></returns>
        public static Dictionary<string, double> LoadDataByNameValue(ObservableGrid DB, Dictionary<string, double> valuesDictionary)
        {
            int columnIndex = 1;
            int valueIndex = DB.Columns.Find(x => x.name == "Lista").index;
            int numberIndex = DB.Columns.Find(x => x.name == "Number").index;

            Dictionary<string, double> ItemsSplitByCategory = new Dictionary<string, double>();

            foreach (ObservableRow row in DB.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells[columnIndex].Value) && !ItemsSplitByCategory.ContainsKey(row.Cells[columnIndex].Value))
                {
                    ItemsSplitByCategory.Add(row.Cells[columnIndex].Value, 0.0);
                }
            }

            for (int i = 0; i < DB.Rows.Count; i++) // -1
            {
                if (!string.IsNullOrWhiteSpace(DB.Rows[i].Cells[columnIndex].Value) && !string.IsNullOrWhiteSpace(DB.Rows[i].Cells[valueIndex].Value) && !string.IsNullOrWhiteSpace(DB.Rows[i].Cells[numberIndex].Value))
                {
                    ItemsSplitByCategory[DB.Rows[i].Cells[columnIndex].Value] += valuesDictionary[DB.Rows[i].Cells[valueIndex].Value] * double.Parse(DB.Rows[i].Cells[numberIndex].Value);
                }
            }

            Dictionary<string, double> ItemsSplitByCategoryRet = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> pair in ItemsSplitByCategory)
            {
                ItemsSplitByCategoryRet.Add(WrapLabels(pair.Key), pair.Value);
            }

            return ItemsSplitByCategoryRet.OrderByDescending(c => c.Value).ToDictionary(d => d.Key, d => d.Value);
        }

        public static Dictionary<string, double> LoadDataByCategoryCount(Dgv DB, DataBaseCategories categories, string category, List<SingleValue> valueList)
        {
            int columnIndex = DB.columns.Where(c => c.name == category).FirstOrDefault().index;
            int valueIndex = DB.columns.Find(x => x.name == "Lista").index;
            int numberIndex = DB.columns.Find(x => x.name == "Number").index;
            ObservableCollection<SubCategory> subCategories = categories.List.Where(c => c.name == category).FirstOrDefault().subCategories;
            List<string> subCategoriesAsString = subCategories.Select(s => s.text).ToList();

            Dictionary<string, double> ItemsSplitByCategory = new Dictionary<string, double>();

            foreach (string SubCategory in subCategoriesAsString)
            {
                ItemsSplitByCategory.Add(SubCategory, 0.0);
            }

            for (int i = 0; i < DB.rows.Count - 1; i++)
            {
                if (DB.rows[i].cells[columnIndex].value != null)
                {
                    //uwaga blad jak w kategorii null
                    if (!string.IsNullOrWhiteSpace(DB.rows[i].cells[columnIndex].value) && subCategories.Where(sc => sc.name == DB.rows[i].cells[columnIndex].value).Count() != 0)
                    {
                        string what = subCategories.Where(sc => sc.name == DB.rows[i].cells[columnIndex].value).FirstOrDefault().text;
                        ItemsSplitByCategory[what] += double.Parse(DB.rows[i].cells[numberIndex].value);
                    }
                }
            }

            return ItemsSplitByCategory;
        }


        /// <summary>
        /// Loads data for a given category. Splits them by total value and label by subcategory name
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="categories"></param>
        /// <param name="category"></param>
        /// <param name="valueList"></param>
        /// <returns></returns>
        public static Dictionary<string, double> LoadDataByCategoryValue(ObservableGrid DB, IList<Category.Category> categories, string category, Dictionary<string, double> valuesDictionary)
        {
            int columnIndex = DB.Columns.Where(c => c.name == category).FirstOrDefault().index;
            int valueIndex = DB.Columns.Find(x => x.name == "Lista").index;
            int numberIndex = DB.Columns.Find(x => x.name == "Number").index;
            ObservableCollection<SubCategory> subCategories = categories.FirstOrDefault(c => c.name == category).subCategories;
            Dictionary<string, string> subCategoriesDictionary = subCategories.ToDictionary(s => s.name, s => s.text);
            Dictionary<string, double> ItemsSplitByCategory = subCategories.ToDictionary(s => s.text, s => 0.0);


            for (int i = 0; i < DB.Rows.Count; i++)//-1
            {
                if (!string.IsNullOrWhiteSpace(DB.Rows[i].Cells[columnIndex].Value) && subCategoriesDictionary.ContainsKey(DB.Rows[i].Cells[columnIndex].Value) && !string.IsNullOrWhiteSpace(DB.Rows[i].Cells[numberIndex].Value) && !string.IsNullOrWhiteSpace(DB.Rows[i].Cells[valueIndex].Value))
                {
                    string what = subCategoriesDictionary[DB.Rows[i].Cells[columnIndex].Value];
                    ItemsSplitByCategory[what] += valuesDictionary[DB.Rows[i].Cells[valueIndex].Value] * double.Parse(DB.Rows[i].Cells[numberIndex].Value);
                }
            }

            Dictionary<string, double> ItemsSplitByCategoryRet = new Dictionary<string, double>();


            foreach (KeyValuePair<string, double> pair in ItemsSplitByCategory)
            {
                ItemsSplitByCategoryRet.Add(WrapLabels(pair.Key), pair.Value);
            }



            return ItemsSplitByCategoryRet.OrderByDescending(c => c.Value).ToDictionary(d => d.Key, d => d.Value);
        }

        private static double CalculateValue(int i, int valueIndex, int numberIndex, Dgv DB, List<SingleValue> valueList)
        {
            double rowValue = 0;
            double val = 0.0;

            if (DB.rows[i].isDBrow == true)
            {
                if (DB.rows[i].cells[valueIndex].value != null && DB.rows[i].cells[valueIndex].value != "")
                {
                    val = DB.getCellValue(valueList, DB.rows[i].cells[valueIndex].value);
                }

                if (DB.rows[i].cells[numberIndex].value != null && DB.rows[i].cells[numberIndex].value != "")
                {

                    rowValue = val * double.Parse(DB.rows[i].cells[numberIndex].value);
                }
            }

            return rowValue;
        }

        private static string WrapLabels(string label)
        {
            List<string> wraped = new List<string>();

            if (label.Length > LineLength)
            {
                string[] words = label.Split(' ');
                int length = 0;

                foreach (string word in words)
                {
                    length += word.Length;
                    if (length > LineLength)
                    {
                        wraped.Add("\n" + word);
                        length = 0;
                    }
                    else
                    {
                        wraped.Add(word);
                    }
                }
            }
            else
            {
                return label;
            }

            return string.Join(" ", wraped);
        }

        public static List<System.Drawing.Color> GetCustomPalette()
        {

            List<System.Drawing.Color> custom = new List<System.Drawing.Color>();

            System.Drawing.Color lightBrown = System.Drawing.Color.FromArgb(229, 184, 69);
            custom.Add(lightBrown);

            System.Drawing.Color lightBlue = System.Drawing.Color.FromArgb(89, 175, 198);
            custom.Add(lightBlue);

            System.Drawing.Color lightGreen = System.Drawing.Color.FromArgb(103, 184, 151);
            custom.Add(lightGreen);

            System.Drawing.Color lightViolet = System.Drawing.Color.FromArgb(203, 92, 160);
            custom.Add(lightViolet);            

            System.Drawing.Color darkBrown = System.Drawing.Color.FromArgb(178, 143, 62);
            custom.Add(darkBrown);

            System.Drawing.Color darkBlue = System.Drawing.Color.FromArgb(40, 121, 140);
            custom.Add(darkBlue);

            System.Drawing.Color darkGreen = System.Drawing.Color.FromArgb(57, 138, 105);
            custom.Add(darkGreen);

            System.Drawing.Color darkViolet = System.Drawing.Color.FromArgb(102, 81, 80);
            custom.Add(darkViolet);



            return custom;
        }



    }
}
