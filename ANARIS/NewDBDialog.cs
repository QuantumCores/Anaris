using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class NewDBDialog : Form, ANS_View
    {
        public string projectFileName;
        public string projectAuthorName;
        public string projectDirrectory;
        public string projectOrganisationName;
        public string projMuseumName;
        public string projMuseumAdres;

        ANS_Controller _controller;

        public NewDBDialog()
        {
            InitializeComponent();
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }
        
        

        //ProjectProperties _nowyProjekt = new ProjectProperties();

        int btnClick = 1;

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void projDirTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                projDirTxtBox.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void authTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msgTxt = "Musisz podać :\n";


            if (textBox1.Text == "") { msgTxt += "Nazwa projektu \n"; }            
            if (projDirTxtBox.Text == "") { msgTxt += "Ścieżka projektu \n"; }

            if (textBox1.Text != "" && projDirTxtBox.Text != "")
            {

                projectFileName = textBox1.Text;                
                projectDirrectory = projDirTxtBox.Text;                

                //MessageBox.Show(projectFileName + "\n" + projectDirrectory + "\n" + projectAuthorName + "\n" + projectOrganisationName + "\n");

                this.DialogResult = DialogResult.OK;
                //this.Close();               

            }
            else { MessageBox.Show(msgTxt); }

        }

        private void authorAskBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Separate multiple authors with semicolon ';'.");
        }

    }
}
