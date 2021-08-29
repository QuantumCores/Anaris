namespace ANARIS.Components
{
    partial class AuthorsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_authors = new System.Windows.Forms.ListView();
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CellPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_rmvAuthor = new System.Windows.Forms.Button();
            this.btn_editAuthor = new System.Windows.Forms.Button();
            this.btn_addAuthor = new System.Windows.Forms.Button();
            this.lbl_authors = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_authors
            // 
            this.lst_authors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstName,
            this.LastName,
            this.Email,
            this.CellPhone});
            this.lst_authors.Location = new System.Drawing.Point(3, 24);
            this.lst_authors.Name = "lst_authors";
            this.lst_authors.Size = new System.Drawing.Size(409, 192);
            this.lst_authors.TabIndex = 20;
            this.lst_authors.UseCompatibleStateImageBehavior = false;
            this.lst_authors.View = System.Windows.Forms.View.Details;
            // 
            // FirstName
            // 
            this.FirstName.Text = "Imię";
            // 
            // LastName
            // 
            this.LastName.Text = "Nazwisko";
            // 
            // Email
            // 
            this.Email.Text = "Email";
            // 
            // CellPhone
            // 
            this.CellPhone.Text = "Telefon";
            // 
            // btn_rmvAuthor
            // 
            this.btn_rmvAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rmvAuthor.Location = new System.Drawing.Point(427, 83);
            this.btn_rmvAuthor.Name = "btn_rmvAuthor";
            this.btn_rmvAuthor.Size = new System.Drawing.Size(75, 23);
            this.btn_rmvAuthor.TabIndex = 19;
            this.btn_rmvAuthor.Text = "Usuń";
            this.btn_rmvAuthor.UseVisualStyleBackColor = true;
            this.btn_rmvAuthor.Click += new System.EventHandler(this.btn_rmvAuthor_Click);
            // 
            // btn_editAuthor
            // 
            this.btn_editAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editAuthor.Location = new System.Drawing.Point(428, 54);
            this.btn_editAuthor.Name = "btn_editAuthor";
            this.btn_editAuthor.Size = new System.Drawing.Size(75, 23);
            this.btn_editAuthor.TabIndex = 18;
            this.btn_editAuthor.Text = "Edytuj";
            this.btn_editAuthor.UseVisualStyleBackColor = true;
            this.btn_editAuthor.Click += new System.EventHandler(this.btn_editAuthor_Click);
            // 
            // btn_addAuthor
            // 
            this.btn_addAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addAuthor.Location = new System.Drawing.Point(427, 24);
            this.btn_addAuthor.Name = "btn_addAuthor";
            this.btn_addAuthor.Size = new System.Drawing.Size(75, 23);
            this.btn_addAuthor.TabIndex = 17;
            this.btn_addAuthor.Text = "Dodaj";
            this.btn_addAuthor.UseVisualStyleBackColor = true;
            this.btn_addAuthor.Click += new System.EventHandler(this.btn_addAuthor_Click);
            // 
            // lbl_authors
            // 
            this.lbl_authors.AutoSize = true;
            this.lbl_authors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_authors.Location = new System.Drawing.Point(7, 4);
            this.lbl_authors.Name = "lbl_authors";
            this.lbl_authors.Size = new System.Drawing.Size(53, 13);
            this.lbl_authors.TabIndex = 16;
            this.lbl_authors.Text = "Autorzy:";
            // 
            // AuthorsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_authors);
            this.Controls.Add(this.btn_rmvAuthor);
            this.Controls.Add(this.btn_editAuthor);
            this.Controls.Add(this.btn_addAuthor);
            this.Controls.Add(this.lbl_authors);
            this.Name = "AuthorsControl";
            this.Size = new System.Drawing.Size(510, 221);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lst_authors;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader CellPhone;
        private System.Windows.Forms.Button btn_rmvAuthor;
        private System.Windows.Forms.Button btn_editAuthor;
        private System.Windows.Forms.Button btn_addAuthor;
        public System.Windows.Forms.Label lbl_authors;
    }
}
