using ANARIS.BLL;
using ANARIS.Components;
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
    public partial class NewAuthor : Form
    {
        AuthorsControl authorsControl;

        public NewAuthor()
        {
            InitializeComponent();
        }

        public void BindToAuthorController(AuthorsControl _authorsControl)
        {
            authorsControl = _authorsControl;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.FirstName = txt_FirstName.Text;
            author.LastName = txt_SecondName.Text;
            author.Email = txt_email.Text;
            author.CellPhone = txt_cellPhone.Text;
            author.JobDescription = txt_jobDescription.Text;
            author.WorkPhone = txt_workPhone.Text;

            authorsControl.EditAuthor(author);
            //_controller.EditAuthor(author);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_FirstName.Text = string.Empty;
            txt_SecondName.Text = string.Empty;
            txt_email.Text  = string.Empty;
            txt_cellPhone.Text = string.Empty;
            txt_jobDescription.Text = string.Empty;
            txt_workPhone.Text = string.Empty;
        }

        public void EditAuthor(Author author)
        {
            txt_FirstName.Text = author.FirstName;
            txt_SecondName.Text = author.LastName;
            txt_email.Text = author.Email;
            txt_cellPhone.Text = author.CellPhone;
            txt_jobDescription.Text = author.JobDescription;
            txt_workPhone.Text = author.WorkPhone;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.FirstName = txt_FirstName.Text;
            author.LastName = txt_SecondName.Text;
            author.Email = txt_email.Text;
            author.CellPhone = txt_cellPhone.Text;
            author.JobDescription = txt_jobDescription.Text;
            author.WorkPhone = txt_workPhone.Text;

            authorsControl.AddNewAuthor(author);
            //_controller.AddNewAuthor(author);
        }
    }
}
