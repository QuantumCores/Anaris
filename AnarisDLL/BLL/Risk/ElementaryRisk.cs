using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Risk
{
    [Serializable]
    public class ElementaryRisk : Helpers.RandomNameGenerator.IIdentifier
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string opis { get; set; }

        public double AHigh { get; set; }
        public double AMH { get { return GetMagnitudeA(AHigh); } }
        public double AMid { get; set; }
        public double AMM { get { return GetMagnitudeA(AMid); } }
        public double ALow { get; set; }
        public double AML { get { return GetMagnitudeA(ALow); } }
        public string opisA { get; set; }

        public double BHigh { get; set; }
        public double BMH { get { return GetMagnitudeB(BHigh); } }
        public double BMid { get; set; }
        public double BMM { get { return GetMagnitudeB(BMid); } }
        public double BLow { get; set; }
        public double BML { get { return GetMagnitudeB(BLow); } }
        public string opisB { get; set; }

        public double CHigh { get; set; }
        public double CMH { get { return GetMagnitudeC(CHigh); } }
        public double CMid { get; set; }
        public double CMM { get { return GetMagnitudeC(CMid); } }
        public double CLow { get; set; }
        public double CML { get { return GetMagnitudeC(CLow); } }
        public string opisC { get; set; }

        public double ML { get { return AML + BML + CML; } }
        public double MM { get { return AMM + BMM + CMM; } }
        public double MH { get { return AMH + BMH + CMH; } }

        public double Uncertainty { get { return GetUncertainty(ML, MM, MH); } }

        public bool Print { get; set; }

        public ElementaryRisk Clone(ElementaryRisk toCopy)
        {

            //text = toCopy.text != null ? toCopy.text: toCopy.name;
            Text = toCopy.Text;
            Name = toCopy.Name;
            opis = toCopy.opis;

            AHigh = toCopy.AHigh;
            AMid = toCopy.AMid;
            ALow = toCopy.ALow;
            opisA = toCopy.opisA;

            BHigh = toCopy.BHigh;
            BMid = toCopy.BMid;
            BLow = toCopy.BLow;
            opisB = toCopy.opisB;

            CHigh = toCopy.CHigh;
            CMid = toCopy.CMid;
            CLow = toCopy.CLow;
            opisC = toCopy.opisC;

            Print = toCopy.Print;

            return this;
        }

        private double GetMagnitudeA(double A)
        {
            double cutOff = 1;
            return Math.Round((A < cutOff) ? 5 : 5 - Math.Log10(A), 2);
        }

        private double GetMagnitudeB(double B)
        {
            double cutOff = 0.001;
            return Math.Round((B < cutOff) ? 0 : 5 + Math.Log10(B / 100.0), 2);
        }

        private double GetMagnitudeC(double C)
        {
            double cutOff = 0.001;
            double tmp = Math.Round((C < cutOff) ? 0 : 5 + Math.Log10(C / 100.0), 2);
            return Math.Round((C < cutOff) ? 0 : 5 + Math.Log10(C / 100.0), 2);
        }

        public double GetUncertainty(double l, double m, double h)
        {
            return Math.Max(Math.Abs(m - l), Math.Abs(m - h));
        }

        public ElementaryRisk Update(double CLow, double CMid, double CHigh)
        {
            this.CLow = CLow;
            this.CMid = CMid;
            this.CHigh = CHigh;

            return this;
        }

    }
}
