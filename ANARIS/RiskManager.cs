using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class RiskManager : Form, ANS_View
    {

        //Random rnd = new Random();
        ANS_Controller _controller;

        private RiskCollection RC_Tabele;


        public RiskManager(RiskCollection RC_tabs, List<string> RC_BaseList)
        {
            InitializeComponent();
            RC_Tabele = RC_tabs;
            riskComBox.DataSource = RC_BaseList;
            //Console.WriteLine("IN: " + RC_Tabele.Risk.Count + " " + RC_Tabele.Risk[0].name + ", " + RC_Tabele.Risk[0].DistinctiveRisk.Count);

            foreach (ElementaryRisk item in RC_Tabele.Risk[0].DistinctiveRisk)
            {
                listBox2.Items.Add(item.name);
            }


        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
            //Console.WriteLine("CN: " + _controller.RC_Tabele.Risk.Count + " " + _controller.RC_Tabele.Risk[0].name + ", " + _controller.RC_Tabele.Risk[0].DistinctiveRisk.Count);
        }


        private void chngNameBtn_Click(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            int selectedIndex1 = riskComBox.SelectedIndex;


            if (index != -1 && nameBox.Text != "")
            {
                listBox2.Items[index] = nameBox.Text;


                if (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk.Count != 0)
                {
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[index].name = nameBox.Text;
                }

            }
        }


        private void ClearAll()
        {
            nameBox.Clear();
            opisTxtBox.Clear();

            ALowTxt.Clear();
            AMidTxt.Clear();
            AHighTxt.Clear();
            opisATxtBox.Clear();
            AScoreTxt.Clear();
            AminScoreTxt.Clear();
            AmaxScoreTxt.Clear();

            BLowTxt.Clear();
            BMidTxt.Clear();
            BHighTxt.Clear();
            opisBTxtBox.Clear();
            BScoreTxt.Clear();
            BminScoreTxt.Clear();
            BmaxScoreTxt.Clear();

            CLowTxt.Clear();
            CMidTxt.Clear();
            CHighTxt.Clear();
            opisCTxtBox.Clear();
            CScoreTxt.Clear();
            CminScoreTxt.Clear();
            CmaxScoreTxt.Clear();
     
            RScoreTxt.Clear();
            RminScoreTxt.Clear();
            RmaxScoreTxt.Clear();

        }

        private void moveUpBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex2 = listBox2.SelectedIndex;
            int selectedIndex1 = riskComBox.SelectedIndex;

            if (selectedIndex2 > 0 && RC_Tabele.Risk[selectedIndex1] != null)
            {
                ElementaryRisk change = new ElementaryRisk();
                string selected = listBox2.GetItemText(listBox2.SelectedItem);

                change = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2 - 1];
                RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2 - 1] = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2];
                RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2] = change;

                _controller.RAList.RiskAnalysis[selectedIndex1].MoveUp(selectedIndex2 + 1);

                listBox2.Items.Clear();
                foreach (ElementaryRisk item in RC_Tabele.Risk[selectedIndex1].DistinctiveRisk) { listBox2.Items.Add(item.name); }

            }
        }

        private void moveDownBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex2 = listBox2.SelectedIndex;
            int selectedIndex1 = riskComBox.SelectedIndex;

            if (selectedIndex2 != -1 && selectedIndex2 < listBox2.Items.Count - 1 && RC_Tabele.Risk[selectedIndex1] != null)
            {
                ElementaryRisk change = new ElementaryRisk();
                string selected = listBox2.GetItemText(listBox2.SelectedItem);

                change = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2 + 1];
                RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2 + 1] = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2];
                RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2] = change;

                _controller.RAList.RiskAnalysis[selectedIndex1].MoveDown(selectedIndex2 + 1);

                listBox2.Items.Clear();
                foreach (ElementaryRisk item in RC_Tabele.Risk[selectedIndex1].DistinctiveRisk) { listBox2.Items.Add(item.name); }

            }

        }

        private void riskComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            listBox2.Items.Clear();
            //Console.WriteLine("IC: " + RC_Tabele.Risk.Count + " " + RC_Tabele.Risk[0].name + ", " + RC_Tabele.Risk[0].DistinctiveRisk.Count);

            int selectedIndex1 = riskComBox.SelectedIndex;

            if (selectedIndex1 >= 0 && _controller != null)
            {
                foreach (ElementaryRisk item in RC_Tabele.Risk[selectedIndex1].DistinctiveRisk)
                {
                    listBox2.Items.Add(item.name);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex1 = riskComBox.SelectedIndex;
            int selectedIndex2 = listBox2.SelectedIndex;
            opisTxtBox.Clear();

            if (selectedIndex1 >= 0 && selectedIndex2 >= 0)
            {
                nameBox.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].name;
                opisTxtBox.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opis;
                ALowTxt.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].ALow.ToString();
                AMidTxt.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AMid.ToString();
                AHighTxt.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AHigh.ToString();
                AScoreTxt.Text = Math.Round(5 - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AMid), 2).ToString();
                AminScoreTxt.Text = Math.Round(5 - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].ALow), 2).ToString();
                AmaxScoreTxt.Text = Math.Round(5 - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AHigh), 2).ToString();
                opisATxtBox.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opisA;

                BLowTxt.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BLow.ToString();
                BMidTxt.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BMid.ToString();
                BHighTxt.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BHigh.ToString();
                BScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BMid / 100.0), 2).ToString();
                BminScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BLow / 100.0), 2).ToString();
                BmaxScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BHigh / 100.0), 2).ToString();
                opisBTxtBox.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opisB;

                CLowTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow));
                CMidTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid));
                CHighTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh));
                CScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid / 100.0), 2).ToString();
                CminScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow / 100.0), 2).ToString();
                CmaxScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh / 100.0), 2).ToString();
                opisCTxtBox.Text = RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opisC;

                RScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BMid / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AMid ), 2).ToString();
                RminScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BLow / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].ALow ), 2).ToString();
                RmaxScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BHigh / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AHigh ), 2).ToString();
            }
        }

        private void addOpisElem_Click(object sender, EventArgs e)
        {
            int selectedIndex1 = riskComBox.SelectedIndex;
            int selectedIndex2 = listBox2.SelectedIndex;
            bool original = true;

            if (nameBox.Text != "" && selectedIndex1 >= 0 && selectedIndex2 >= 0)
            {
                foreach (ElementaryRisk ElemRisk in RC_Tabele.Risk[selectedIndex1].DistinctiveRisk)
                {
                    if (ElemRisk.name == nameBox.Text && RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].name != nameBox.Text)
                    {
                        original = false;
                        MessageBox.Show("Scenariusz o nazwie '" + nameBox.Text + "' już istnieje.");
                    }
                }
                if (original == true && AHighTxt.Text != "" && AMidTxt.Text != "" && ALowTxt.Text != "" && BHighTxt.Text != "" && BMidTxt.Text != "" && BLowTxt.Text != "")
                {
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opis = opisTxtBox.Text;
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opisA = opisATxtBox.Text;
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AHigh = double.Parse(AHighTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].ALow = double.Parse(ALowTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AMid = double.Parse(AMidTxt.Text);

                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opisB = opisBTxtBox.Text;
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BHigh = double.Parse(BHighTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BLow = double.Parse(BLowTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BMid = double.Parse(BMidTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].name = nameBox.Text;

                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].opisC = opisCTxtBox.Text;
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh = double.Parse(CHighTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow = double.Parse(CLowTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid = double.Parse(CMidTxt.Text);
                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].name = nameBox.Text;

                    listBox2.Items[selectedIndex2] = nameBox.Text; // to musi być na końcu bo wywołuje eventHandler listBox2_SelectedIndexChanged
                    //Console.WriteLine("AfterUpdate :" + AMidTxt.Text);

                    //MessageBox.Show(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AHigh.ToString() + "  " + double.Parse(AHighTxt.Text));

                    ClearAll();
                }
                else { MessageBox.Show("Uzupełniej wszystkie pola A i B."); }
            }
            else { MessageBox.Show("Uzupełniej nazwę scenariusza \n oraz wszystkie pola A i B."); }
        }



        private void AMidTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ALowTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void AHighTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void BMidTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void BLowTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void BHighTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void addScenarioBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex1 = riskComBox.SelectedIndex;
            bool original = true;

            if (nameBox.Text != "")
            {
                foreach (ElementaryRisk ElemRisk in RC_Tabele.Risk[selectedIndex1].DistinctiveRisk)
                {
                    if (ElemRisk.name == nameBox.Text)
                    {
                        original = false;
                        MessageBox.Show("Scenariusz o nazwie '" + nameBox.Text + "' już istnieje.");
                    }
                }
                if (original == true && AHighTxt.Text != "" && AMidTxt.Text != "" && ALowTxt.Text != "" && BHighTxt.Text != "" && BMidTxt.Text != "" && BLowTxt.Text != "")
                {
                    listBox2.Items.Add(nameBox.Text);
                    ElementaryRisk nowy = new ElementaryRisk();
                    nowy.name = nameBox.Text;
                    nowy.opis = opisTxtBox.Text;
                    if (AHighTxt.Text != "") { nowy.AHigh = double.Parse(AHighTxt.Text); }
                    if (ALowTxt.Text != "") { nowy.ALow = double.Parse(ALowTxt.Text); }
                    if (AMidTxt.Text != "") { nowy.AMid = double.Parse(AMidTxt.Text); }
                    nowy.opisA = opisATxtBox.Text;

                    if (BHighTxt.Text != "") nowy.BHigh = double.Parse(BHighTxt.Text);
                    if (BLowTxt.Text != "") { nowy.BLow = double.Parse(BLowTxt.Text); }
                    if (BMidTxt.Text != "") { nowy.BMid = double.Parse(BMidTxt.Text); }
                    nowy.opisB = opisBTxtBox.Text;

                    if (CHighTxt.Text != "") { nowy.CHigh = double.Parse(CHighTxt.Text); }
                    if (CLowTxt.Text != "") { nowy.CLow = double.Parse(CLowTxt.Text); }
                    if (CMidTxt.Text != "") { nowy.CMid = double.Parse(CMidTxt.Text); }
                    nowy.opisC = opisCTxtBox.Text;

                    RC_Tabele.Risk[selectedIndex1].DistinctiveRisk.Add(nowy);

                    if (_controller.anarisProject != null) // a co jeśli będzie otwarty razem z bazą danych ?
                    {
                        Dgv newone = new Dgv();
                        newone.Clone(_controller.RAList.RiskAnalysis[selectedIndex1].dgvList[0]);
                        //Console.WriteLine("Name: " + _controller.DB.name + ", klonujemy: " + _controller.DB.rows[1].cells.Count);
                        //Console.WriteLine("Utworzony ma: " + newone.rows[1].cells.Count);                    
                        newone.name = nowy.name;
                        newone.AddRAColumns();
                        _controller.RAList.RiskAnalysis[selectedIndex1].dgvList.Add(newone);
                        //Console.WriteLine("Super");
                    }

                    ClearAll();
                }
                else { MessageBox.Show("Uzupełniej wszystkie pola A i B."); }
            }
            else { MessageBox.Show("Uzupełniej nazwę scenariusza \n oraz wszystkie pola A i B."); }
        }

        private void rmvScenarioBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex1 = riskComBox.SelectedIndex;
            int selectedIndex2 = listBox2.SelectedIndex;
            if (selectedIndex1 >= 0 && selectedIndex2 >= 0)
            {
                listBox2.Items.Remove(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].name);
                RC_Tabele.Risk[selectedIndex1].DistinctiveRisk.Remove(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2]);
                MessageBox.Show("Usuniesz \n" + _controller.RAList.RiskAnalysis[selectedIndex1].dgvList[selectedIndex2 + 1].name);
                _controller.RAList.RiskAnalysis[selectedIndex1].dgvList.Remove(_controller.RAList.RiskAnalysis[selectedIndex1].dgvList[selectedIndex2 + 1]);

                ClearAll();
            }
        }

        private bool valueValidation(double min, double max)
        {
            bool isOk = true;

            if (min > max) { isOk = false; }
            MessageBox.Show(min + " nie może być większe od " + max);

            return isOk;

        }

        private void ALowTxt_Leave(object sender, EventArgs e)
        {
            double years = 0.0;
            if (ALowTxt.Text != "")
            {
                bool ok = double.TryParse(ALowTxt.Text, out years);
                if (ok)
                {
                    if (years < 0) { years = 0; }
                    ALowTxt.Text = years.ToString();
                }
                else
                {
                    MessageBox.Show("Wprowadź liczbę.");
                    ALowTxt.Text = "";
                }
            }
        }

        private void AMidTxt_Leave(object sender, EventArgs e)
        {
            double years = 0.0;
            if (AMidTxt.Text != "")
            {
                bool ok = double.TryParse(AMidTxt.Text, out years);
                if (ok)
                {
                    if (years < 0) { years = 0; }
                    AMidTxt.Text = years.ToString();
                    AScoreTxt.Text = Math.Round(5 - Math.Log10(years), 2).ToString();
                }
                else
                {
                    MessageBox.Show("Wprowadź liczbę.");
                    AMidTxt.Text = "";
                }
            }
        }

        private void AHighTxt_Leave(object sender, EventArgs e)
        {
            double years = 0.0;
            if (AHighTxt.Text != "")
            {
                bool ok = double.TryParse(AHighTxt.Text, out years);
                if (ok)
                {
                    if (years < 0) { years = 0; }
                    AHighTxt.Text = years.ToString();
                }
                else
                {
                    MessageBox.Show("Wprowadź liczbę.");
                    AHighTxt.Text = "";
                }
            }
        }

        private void BLowTxt_Leave(object sender, EventArgs e)
        {
            double loss = 0.0;
            if (BLowTxt.Text != "")
            {
                bool ok = double.TryParse(BLowTxt.Text, out loss);
                if (ok)
                {
                    if (loss < 0) { loss = 0; }
                    if (loss > 100) { loss = 100; }
                    BLowTxt.Text = loss.ToString();
                    //BScoreTxt.Text = Math.Round(5 + Math.Log10(loss / 100.0), 1).ToString();
                }
                else
                {
                    MessageBox.Show("Wprowadź liczbę");
                    BLowTxt.Text = "";
                }
            }
        }

        private void BMidTxt_Leave(object sender, EventArgs e)
        {
            double loss = 0.0;
            if (BMidTxt.Text != "")
            {
                bool ok = double.TryParse(BMidTxt.Text, out loss);
                if (ok)
                {
                    if (loss < 0) { loss = 0; }
                    if (loss > 100) { loss = 100; }
                    BMidTxt.Text = loss.ToString();
                    BScoreTxt.Text = Math.Round(5 + Math.Log10(loss / 100.0), 2).ToString();
                }
                else
                {
                    MessageBox.Show("Wprowadź liczbę.");
                    BMidTxt.Text = "";
                }
            }
        }

        private void BHighTxt_Leave(object sender, EventArgs e)
        {
            double loss = 0.0;
            if (BHighTxt.Text != "")
            {
                bool ok = double.TryParse(BHighTxt.Text, out loss);
                if (ok)
                {
                    if (loss < 0) { loss = 0; }
                    if (loss > 100) { loss = 100; }
                    BHighTxt.Text = loss.ToString();

                }
                else
                {
                    MessageBox.Show("Wprowadź liczbę.");
                    BHighTxt.Text = "";
                }
            }

        }

        public void UpdateAllCValues()
        {
            for (int i = 0; i < RC_Tabele.Risk.Count; i++)//SingleRisk sr in RC_Tabele.Risk)
            {
                SingleRisk sr = RC_Tabele.Risk[i];

                for (int j = 0; j < sr.DistinctiveRisk.Count; j++)//ElementaryRisk er in sr.DistinctiveRisk)
                {
                    ElementaryRisk er = sr.DistinctiveRisk[j];
                    er.CLow = _controller.RAList.RiskAnalysis[i].dgvList[j + 1].getAvrCValue(0) * 100;
                    er.CMid = _controller.RAList.RiskAnalysis[i].dgvList[j + 1].getAvrCValue(1) * 100;
                    er.CHigh = _controller.RAList.RiskAnalysis[i].dgvList[j + 1].getAvrCValue(2) * 100;

                }
            }

            int selectedIndex1 = riskComBox.SelectedIndex;
            int selectedIndex2 = listBox2.SelectedIndex;

            if (selectedIndex2 != -1)
            {
                CLowTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow));
                CMidTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid));
                CHighTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh));

                CScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid / 100.0), 2).ToString();
                CminScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow / 100.0), 2).ToString();
                CmaxScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh / 100.0), 2).ToString();

                RScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BMid / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AMid), 2).ToString();
                RminScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BLow / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].ALow), 2).ToString();
                RmaxScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BHigh / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AHigh), 2).ToString();
            }

        }

        public void UpdateCValues(double MRmin, double MR, double MRmax, int riskIndex, int distIndex)
        {
            int selectedIndex1 = riskComBox.SelectedIndex;
            int selectedIndex2 = listBox2.SelectedIndex;


            RC_Tabele.Risk[riskIndex].DistinctiveRisk[distIndex].CLow = MRmin * 100;
            RC_Tabele.Risk[riskIndex].DistinctiveRisk[distIndex].CMid = MR * 100;
            RC_Tabele.Risk[riskIndex].DistinctiveRisk[distIndex].CHigh = MRmax * 100;

            if (riskIndex == selectedIndex1 && distIndex == selectedIndex2)
            {
                CLowTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow));
                CMidTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid));
                CHighTxt.Text = String.Format("{0:N2}", (RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh));
                CScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid / 100.0), 2).ToString();
                CminScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow / 100.0), 2).ToString();
                CmaxScoreTxt.Text = Math.Round(5 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh / 100.0), 2).ToString();

                RScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CMid / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BMid / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AMid), 2).ToString();
                RminScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CLow / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BLow / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].ALow), 2).ToString();
                RmaxScoreTxt.Text = Math.Round(15 + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].CHigh / 100.0) + Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].BHigh / 100.0) - Math.Log10(RC_Tabele.Risk[selectedIndex1].DistinctiveRisk[selectedIndex2].AHigh), 2).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.ShowHideRiskManager();
        }
    }
}
