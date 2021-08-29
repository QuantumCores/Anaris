using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using ANARIS.BLL;

namespace ANARIS.Components
{
    public partial class NewProjectBasic : UserControl
    {

        string errorMeasge = string.Empty;


        public NewProjectBasic()
        {
            InitializeComponent();
        }

        public ProjectProperties GetTheProperties()
        {
            ProjectProperties properties = new ProjectProperties();
            char[] chars = Path.GetInvalidFileNameChars();
            string tmpProjectName = txt_ProjectName.Text;

            foreach (char c in tmpProjectName)
            {
                if (chars.Contains(c))
                {
                    tmpProjectName = tmpProjectName.Replace(c.ToString(), "");
                }
            }

            errorMeasge += tmpProjectName != txt_ProjectName.Text ? "Nazwa projektu zawiera niedozwolone znaki" : string.Empty;
            errorMeasge += !Directory.Exists(txt_ProjectDierctory.Text) ? "Podaj ścierzkę dla projektu" : string.Empty;
            
            if (errorMeasge != string.Empty)
            {
                MessageBox.Show(errorMeasge);
                return null;
            }
            else
            {
                properties.projectName = tmpProjectName;
                properties.filePath = txt_ProjectDierctory.Text;
                properties.creationTime = DateTime.UtcNow;

                properties.modifiedTime = DateTime.UtcNow;               

            }

            return properties;
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odziel kolejnych autorów średnikami - ';'");
        }

        private void btn_Dir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txt_ProjectDierctory.Text = fbd.SelectedPath;
            }
        }
    }
}
