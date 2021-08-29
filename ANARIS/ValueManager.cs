using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class ValueManager : Form, ANS_View
    {
        ANS_Controller _controller;
        public DataBaseValues tmp = new DataBaseValues();
        int r = -1;

        public ValueManager(DataBaseValues dbValues)
        {
            InitializeComponent();

            lst_Values.Columns[0].Width = lst_Values.Size.Width / 2 - 2;
            lst_Values.Columns[1].Width = lst_Values.Size.Width / 2 - 2;
            lst_Values.MultiSelect = false;
            lst_Values.AllowColumnReorder = false;
            lst_Values.HideSelection = false;
            lst_Values.FullRowSelect = true;

            tmp.Clone(dbValues);
            reloadValues();
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }


        public void applyBtn_Click(object sender, EventArgs e)
        {
            tmp.ValuesDescription = txtDescAll.Text;
            _controller.dbValues.Clone(tmp);
            if (_controller.anarisProject != null)
            {
                _controller.setNewValues(_controller.anarisProject.dataGridView1);
            }
            else
            {
                _controller.setNewValues(_controller.newDataBase.dataGridView1);
            }
        }

        private void reloadValues()
        {
            lst_Values.Items.Clear();
            foreach (SingleValue sv in tmp.valueList)
            {
                ListViewItem newItem = new ListViewItem(new[] { sv.text, sv.value.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE")) });
                lst_Values.Items.Add(newItem);               
            }

            txtDescAll.Text = tmp.ValuesDescription;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.ShowHideValueManager();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            double valueParse = 0;
            if (string.IsNullOrWhiteSpace(txt_name.Text) || !tmp.IsTextUnique(txt_name.Text))
            {
                MessageBox.Show("Wartość o nazwie " + txt_name.Text + " już istenije bądź nazwa jest pusta. Nazwy muszą być unikatowe.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txt_value.Text) || double.TryParse(txt_value.Text, out valueParse))
            {
                string name = string.Empty;
                do
                {
                    name = _controller.randomNameGenerator(3);
                }
                while (!tmp.IsNameUnique(name));

                SingleValue sv = new SingleValue() { name = name, text = txt_name.Text, value = valueParse, description = txtDescSingle.Text };
                tmp.valueList.Add(sv);
                tmp.valueList = tmp.valueList.OrderByDescending(v => v.value).ToList();
                tmp.ValuesDescription = txtDescAll.Text;

                reloadValues();
            }
            else
            {
                MessageBox.Show("W polu wartość należy wprowadzić liczbę bez dodatkowych znaków.");
            }
        }

        private void btn_rmv_Click(object sender, EventArgs e)
        {
            if (lst_Values.SelectedIndices.Count == 1)
            {
                int index = lst_Values.SelectedIndices[0];
                tmp.valueList.RemoveAt(index);
                lst_Values.Items.RemoveAt(index);
            }
        }

        private void lst_Values_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_Values.SelectedIndices.Count == 1)
            {
                int index = lst_Values.SelectedIndices[0];
                txt_name.Text = tmp.valueList[index].text;
                txt_value.Text = tmp.valueList[index].value.ToString();
                txtDescSingle.Text = tmp.valueList[index].description;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (lst_Values.SelectedIndices.Count == 1)
            {
                if (string.IsNullOrWhiteSpace(txt_name.Text))
                {
                    MessageBox.Show("Nazwa jest pusta.");
                    return;
                }

                double valueParse = 0;

                if (string.IsNullOrWhiteSpace(txt_value.Text) || double.TryParse(txt_value.Text, out valueParse))
                {
                    int index = lst_Values.SelectedIndices[0];
                    tmp.valueList[index].text = txt_name.Text;
                    tmp.valueList[index].value = valueParse;
                    tmp.valueList[index].description = txtDescSingle.Text;
                    tmp.valueList = tmp.valueList.OrderByDescending(v => v.value).ToList();

                    reloadValues();
                }
                else
                {
                    MessageBox.Show("W polu wartość należy wprowadzić liczbę bez dodatkowych znaków.");
                }
                
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            tmp.Clone(_controller.dbValues);
            reloadValues();
        }
    }
}
