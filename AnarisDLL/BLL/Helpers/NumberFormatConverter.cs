using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.AnarisGrid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Helpers
{
    public class NumberFormatConverter
    {

        public static void ConvertNumberFormat(Anaris.Anaris save, string coma)
        {
            List<int> numberColumns = new List<int>();
            foreach (var column in save.DataBase.dgv.columns)
            {
                if (column.name == "Number" || column.name == "CLow" || column.name == "CMid" || column.name == "CHigh")
                {
                    numberColumns.Add(column.index);
                }
            }
            numberColumns.Add(save.DataBase.dgv.columns.Count);
            numberColumns.Add(save.DataBase.dgv.columns.Count + 1);
            numberColumns.Add(save.DataBase.dgv.columns.Count + 2);

            foreach (RiskDgvList list in save.RiskAnalysis.RiskAnalysis)
            {
                foreach (Dgv grid in list.dgvList)
                {
                    ConvertNumberFormat(grid, coma, numberColumns);
                }
            }

            ConvertNumberFormat(save.DataBase.dgv, coma, numberColumns);

        }

        public static void ConvertNumberFormat(Dgv grid, string coma, List<int> numberColumns)
        {
            foreach (DgvRow row in grid.rows)
            {

                for (int i = 0; i < row.cells.Count; i++)
                {
                    DgvCell cell = row.cells[i];
                    ConvertNumberFormat(cell, coma, numberColumns, i);
                }
            }

        }

        public static void ConvertNumberFormat(DgvCell cell, string coma, List<int> numberColumns, int i)
        {
            if (numberColumns.Contains(i) && !string.IsNullOrWhiteSpace(cell.value))
            {
                cell.value = cell.value.Replace(".", coma);
                cell.value = cell.value.Replace(",", coma);

                if (!string.IsNullOrWhiteSpace(cell.formula))
                {
                    cell.formula = cell.formula.Replace(".", coma);
                    cell.formula = cell.formula.Replace(",", coma);
                }
            }
        }
    }
}
