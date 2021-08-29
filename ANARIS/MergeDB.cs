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
    public partial class MergeDB : Form
    {
        public MergeDB()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_merge_Click(object sender, EventArgs e)
        {            

            if (System.IO.File.Exists(txt_dir.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Plik, który wskazuje ścieżka nie istnieje. Spróbuj poprawić ścieżkę.");
            }

        }

        private void btn_dir_Click(object sender, EventArgs e)
        {
            openFD.InitialDirectory = "C:";
            openFD.Title = "importuj bazę danych Anaris";
            openFD.Filter = "Anaris Pliki|*.anrb";


            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                txt_dir.Text = openFD.FileName;
            }
        }
    }
}
