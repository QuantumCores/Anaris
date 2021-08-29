using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANARIS.BLL;

namespace ANARIS.Components
{
    public partial class AuthorsControl: UserControl
    {
        //ANS_Controller _controller;
        //ProjectProperties tmpProperties;
        List<Author> Authors;
        NewAuthor newAuthor;
        int EditedAuthor = -1;

        public AuthorsControl()
        {
            InitializeComponent();
            ((ColumnHeader)lst_authors.Columns[0]).Width = lst_authors.Size.Width / 4 - 2 - 20;
            ((ColumnHeader)lst_authors.Columns[1]).Width = lst_authors.Size.Width / 4 - 2 - 20;
            ((ColumnHeader)lst_authors.Columns[2]).Width = lst_authors.Size.Width / 4 - 2 + 25;
            ((ColumnHeader)lst_authors.Columns[3]).Width = lst_authors.Size.Width / 4 - 2 + 20;
            lst_authors.View = View.Details;
            lst_authors.AllowColumnReorder = false;
            lst_authors.HideSelection = false;
            lst_authors.FullRowSelect = true;
            
        }

        public void BindDataSources(List<Author> _Authors)
        {
            Authors = _Authors;          
        }

        public void AddAuthors(List<Author> _Authors)
        {
            lst_authors.Items.Clear();
            int i = 0;
            foreach (Author author in _Authors)
            {
                ListViewItem newItem = new ListViewItem(new[] { author.FirstName, author.LastName, author.Email, author.CellPhone });
                if (i % 2 == 1) { newItem.BackColor = Color.LightGray; }
                lst_authors.Items.Add(newItem);
                i++;
            }
        }

        private void btn_addAuthor_Click(object sender, EventArgs e)
        {
            if (newAuthor == null || newAuthor.IsDisposed)
            {
                newAuthor = new NewAuthor();
                newAuthor.BindToAuthorController(this);
                newAuthor.Visible = true;
                newAuthor.Show();
            }            
        }

        public void AddNewAuthor(Author author)
        {
            ListViewItem newItem = new ListViewItem(new[] { author.FirstName, author.LastName, author.Email, author.CellPhone });
            if ((lst_authors.Items.Count + 1) % 2 == 0) { newItem.BackColor = Color.LightGray; }
            lst_authors.Items.Add(newItem);
            Authors.Add(author);
        }

        private void btn_editAuthor_Click(object sender, EventArgs e)
        {
            if (lst_authors.SelectedItems.Count == 1)
            {
                EditedAuthor = lst_authors.SelectedItems[0].Index;
                Author author = Authors[EditedAuthor];

                if (newAuthor == null || newAuthor.IsDisposed)
                {
                    newAuthor = new NewAuthor();
                    newAuthor.BindToAuthorController(this);
                    newAuthor.Visible = true;
                    newAuthor.Show();
                    newAuthor.EditAuthor(author);
                }
            }
        }

        public void EditAuthor(Author author)
        {
            if (EditedAuthor != -1)
            {
                Authors[EditedAuthor] = author;
                ListViewItem newItem = new ListViewItem(new[] { author.FirstName, author.LastName, author.Email, author.CellPhone });
                lst_authors.Items[EditedAuthor] = newItem;
                EditedAuthor = -1;
            }
            else
            {
                MessageBox.Show("Kliknij \"Dodaj\" aby dodać nową osobę.");
            }
        }

        private void btn_rmvAuthor_Click(object sender, EventArgs e)
        {
            if (lst_authors.SelectedItems.Count == 1)
            {
                int index = lst_authors.SelectedItems[0].Index;
                lst_authors.Items.RemoveAt(index);
                Authors.RemoveAt(index);
            }
        }
    }
}
