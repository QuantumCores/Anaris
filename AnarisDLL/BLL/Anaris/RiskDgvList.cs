using AnarisDLL.BLL.AnarisGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Anaris
{
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

        public void Clone(RiskDgvList toCopy)
        {
            name = toCopy.name;
            dgvList.Clear();

            foreach (Dgv dgv in toCopy.dgvList)
            {
                Dgv newDgv = new Dgv();
                newDgv.Clone(dgv);
                dgvList.Add(newDgv);
            }

        }

        public void AddDB(Dgv DB)
        {
            dgvList.Add(DB);
        }

        public void MoveUp(int i)
        {
            Dgv change = dgvList[i - 1];
            dgvList[i - 1] = dgvList[i];
            dgvList[i] = change;
        }

        public void MoveDown(int i)
        {
            Dgv change = dgvList[i + 1];
            dgvList[i + 1] = dgvList[i];
            dgvList[i] = change;
        }
    }
}
