using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.AnarisGrid
{
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

        public void Clone(DgvRow row)
        {
            isDBrow = row.isDBrow;
            isARrow = row.isARrow;
            name = row.name;
            parent = row.parent;

            childRows.Clear();
            foreach (string child in row.childRows)
            {
                childRows.Add(child);
            }

            cells.Clear();
            foreach (DgvCell cell in row.cells)
            {
                DgvCell newCell = new DgvCell();
                newCell.value = cell.value;
                newCell.formula = cell.formula;
                cells.Add(newCell);
            }
        }

        public void ReMapValues(Dictionary<int, Dictionary<string, string>> valueMapping)
        {
            for (int i = 1; i < cells.Count; i++)
            {
                if (valueMapping.ContainsKey(i))
                {
                    DgvCell cell = cells[i];
                    if (cell.value != null)
                    {
                        cell.value = valueMapping[i][cell.value];
                    }
                }
            }
        }
    }
}
