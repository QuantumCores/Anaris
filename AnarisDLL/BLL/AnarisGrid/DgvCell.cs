using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.AnarisGrid
{
    [Serializable]
    public class DgvCell
    {
        public string value { get; set; }
        public string formula { get; set; }
        private bool block { get; set; }


        public string getValue(Dgv data, int rowIndex)
        {
            bool isok = true;
            double _value = 0;

            if (value.Contains("="))
            {
                block = true;
                //Console.WriteLine("ANS In val: " + value);
                _value = executeFormula(data, value, rowIndex);
                if (_value == -1) { value = ""; }
                else { formula = value; value = _value.ToString(); }
                //Console.WriteLine("ANS form: " + formula + ", val: " + value);
            }
            else
            {
                if (!block) { formula = ""; }
                isok = double.TryParse(value, out _value);
                if (isok == false) { value = ""; }
                block = false;
                //Console.WriteLine("ANS zmieniłem form na _");
            }

            return value;
        }

        private double executeFormula(Dgv data, string formula, int rowIndex)
        {
            double result = 0;

            try
            {
                int start = formula.IndexOf("[") + 1;
                int stop = formula.IndexOf("]");

                //Console.WriteLine("P: " + start + "K: " + stop);

                string colName = formula.Substring(start, stop - start);

                //Console.WriteLine("Name: " + colName);
                //Console.WriteLine(data.columnPropeties.Count);
                DgvColumn col = data.columns.Find(x => x.headerText == colName);

                int colIndex = data.columns.Find(x => x.headerText == colName).index;
                double valA = double.Parse(data.rows[rowIndex].cells[colIndex].value);

                start = formula.IndexOf("*") + 1;
                //Console.WriteLine("Rest: " + formula.Substring(start));
                double valB = double.Parse(formula.Substring(start));
                //Console.WriteLine("valA: " + valA + ", valB: " + valB);

                result = valA * valB;

                return result;
            }
            catch
            { return -1; }
        }
    }
}
