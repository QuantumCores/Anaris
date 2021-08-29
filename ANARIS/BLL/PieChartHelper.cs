using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANARIS.BLL
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

        public static Dictionary<string, double> LoadDataByNameValue(Dgv DB, List<SingleValue> valueList)
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
                    ItemsSplitByCategory[DB.rows[i].cells[columnIndex].value] += CalculateValue(i, valueIndex, numberIndex, DB, valueList);
                }
            }

            Dictionary<string, double> ItemsSplitByCategoryRet = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> pair in ItemsSplitByCategory)
            {
                ItemsSplitByCategoryRet.Add(WrapLabels(pair.Key), pair.Value);
            }

            return ItemsSplitByCategoryRet;
        }

        public static Dictionary<string, double> LoadDataByCategoryCount(Dgv DB, DataBaseCategories categories, string category, List<SingleValue> valueList)
        {
            int columnIndex = DB.columns.Where(c => c.name == category).FirstOrDefault().index;
            int valueIndex = DB.columns.Find(x => x.name == "Lista").index;
            int numberIndex = DB.columns.Find(x => x.name == "Number").index;
            List<SubCategory> subCategories = categories.List.Where(c => c.name == category).FirstOrDefault().subCategories;
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



        public static Dictionary<string, double> LoadDataByCategoryValue(Dgv DB, DataBaseCategories categories, string category, List<SingleValue> valueList)
        {
            int columnIndex = DB.columns.Where(c => c.name == category).FirstOrDefault().index;
            int valueIndex = DB.columns.Find(x => x.name == "Lista").index;
            int numberIndex = DB.columns.Find(x => x.name == "Number").index;
            List<SubCategory> subCategories = categories.List.Where(c => c.name == category).FirstOrDefault().subCategories;
            List<string> subCategoriesAsString = subCategories.Select(s => s.text).ToList();

            Dictionary<string, double> ItemsSplitByCategory = new Dictionary<string, double>();

            foreach (string SubCategory in subCategoriesAsString)
            {
                ItemsSplitByCategory.Add(SubCategory, 0.0);
            }

            for (int i = 0; i < DB.rows.Count - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(DB.rows[i].cells[columnIndex].value) && subCategories.Where(sc => sc.name == DB.rows[i].cells[columnIndex].value).Count() != 0)
                {
                    string what = subCategories.Where(sc => sc.name == DB.rows[i].cells[columnIndex].value).FirstOrDefault().text;
                    ItemsSplitByCategory[what] += CalculateValue(i, valueIndex, numberIndex, DB, valueList);
                }
            }

            Dictionary<string, double> ItemsSplitByCategoryRet = new Dictionary<string, double>();
            foreach (KeyValuePair<string,double> pair in ItemsSplitByCategory)
            {
                ItemsSplitByCategoryRet.Add(WrapLabels(pair.Key), pair.Value);
            }

            return ItemsSplitByCategoryRet;
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
                        wraped.Add("\n" + word );
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



    }
}
