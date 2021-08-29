namespace ANARIS
{
    partial class NewAuthor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_firstName = new System.Windows.Forms.Label();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.lbl_secondName = new System.Windows.Forms.Label();
            this.txt_SecondName = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_cellPhone = new System.Windows.Forms.TextBox();
            this.lbl_cellPhone = new System.Windows.Forms.Label();
            this.txt_workPhone = new System.Windows.Forms.TextBox();
            this.lbl_workPhone = new System.Windows.Forms.Label();
            this.txt_jobDescription = new System.Windows.Forms.TextBox();
            this.lbl_jobDescription = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_firstName
            // 
            this.lbl_firstName.AutoSize = true;
            this.lbl_firstName.Location = new System.Drawing.Point(16, 16);
            this.lbl_firstName.Name = "lbl_firstName";
            this.lbl_firstName.Size = new System.Drawing.Size(29, 13);
            this.lbl_firstName.TabIndex = 0;
            this.lbl_firstName.Text = "Imię:";
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.Location = new System.Drawing.Point(127, 13);
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.Size = new System.Drawing.Size(213, 20);
            this.txt_FirstName.TabIndex = 1;
            // 
            // lbl_secondName
            // 
            this.lbl_secondName.AutoSize = true;
            this.lbl_secondName.Location = new System.Drawing.Point(16, 40);
            this.lbl_secondName.Name = "lbl_secondName";
            this.lbl_secondName.Size = new System.Drawing.Size(56, 13);
            this.lbl_secondName.TabIndex = 2;
            this.lbl_secondName.Text = "Nazwisko:";
            // 
            // txt_SecondName
            // 
            this.txt_SecondName.Location = new System.Drawing.Point(127, 37);
            this.txt_SecondName.Name = "txt_SecondName";
            this.txt_SecondName.Size = new System.Drawing.Size(213, 20);
            this.txt_SecondName.TabIndex = 3;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(127, 64);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(213, 20);
            this.txt_email.TabIndex = 4;
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(16, 67);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(35, 13);
            this.lbl_email.TabIndex = 5;
            this.lbl_email.Text = "Email:";
            // 
            // txt_cellPhone
            // 
            this.txt_cellPhone.Location = new System.Drawing.Point(127, 91);
            this.txt_cellPhone.Name = "txt_cellPhone";
            this.txt_cellPhone.Size = new System.Drawing.Size(213, 20);
            this.txt_cellPhone.TabIndex = 6;
            // 
            // lbl_cellPhone
            // 
            this.lbl_cellPhone.AutoSize = true;
            this.lbl_cellPhone.Location = new System.Drawing.Point(16, 94);
            this.lbl_cellPhone.Name = "lbl_cellPhone";
            this.lbl_cellPhone.Size = new System.Drawing.Size(97, 13);
            this.lbl_cellPhone.TabIndex = 7;
            this.lbl_cellPhone.Text = "Telefon kmórkowy:";
            // 
            // txt_workPhone
            // 
            this.txt_workPhone.Location = new System.Drawing.Point(127, 118);
            this.txt_workPhone.Name = "txt_workPhone";
            this.txt_workPhone.Size = new System.Drawing.Size(213, 20);
            this.txt_workPhone.TabIndex = 8;
            // 
            // lbl_workPhone
            // 
            this.lbl_workPhone.AutoSize = true;
            this.lbl_workPhone.Location = new System.Drawing.Point(16, 121);
            this.lbl_workPhone.Name = "lbl_workPhone";
            this.lbl_workPhone.Size = new System.Drawing.Size(103, 13);
            this.lbl_workPhone.TabIndex = 9;
            this.lbl_workPhone.Text = "Telefon stacjonarny:";
            // 
            // txt_jobDescription
            // 
            this.txt_jobDescription.Location = new System.Drawing.Point(127, 145);
            this.txt_jobDescription.Multiline = true;
            this.txt_jobDescription.Name = "txt_jobDescription";
            this.txt_jobDescription.Size = new System.Drawing.Size(213, 91);
            this.txt_jobDescription.TabIndex = 10;
            // 
            // lbl_jobDescription
            // 
            this.lbl_jobDescription.AutoSize = true;
            this.lbl_jobDescription.Location = new System.Drawing.Point(16, 148);
            this.lbl_jobDescription.Name = "lbl_jobDescription";
            this.lbl_jobDescription.Size = new System.Drawing.Size(72, 13);
            this.lbl_jobDescription.TabIndex = 11;
            this.lbl_jobDescription.Text = "Zakres pracy:";
            // 
            // btn_save
            // 
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Location = new System.Drawing.Point(169, 251);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(90, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Zapisz zmiany";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Location = new System.Drawing.Point(88, 251);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 13;
            this.btn_clear.Text = "Wyczyść";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Location = new System.Drawing.Point(265, 251);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 14;
            this.btn_Add.Text = "Dodaj";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // NewAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 286);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_jobDescription);
            this.Controls.Add(this.txt_jobDescription);
            this.Controls.Add(this.lbl_workPhone);
            this.Controls.Add(this.txt_workPhone);
            this.Controls.Add(this.lbl_cellPhone);
            this.Controls.Add(this.txt_cellPhone);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_SecondName);
            this.Controls.Add(this.lbl_secondName);
            this.Controls.Add(this.txt_FirstName);
            this.Controls.Add(this.lbl_firstName);
            this.Name = "NewAuthor";
            this.Text = "NewAuthor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_firstName;
        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.Label lbl_secondName;
        private System.Windows.Forms.TextBox txt_SecondName;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_cellPhone;
        private System.Windows.Forms.Label lbl_cellPhone;
        private System.Windows.Forms.TextBox txt_workPhone;
        private System.Windows.Forms.Label lbl_workPhone;
        private System.Windows.Forms.TextBox txt_jobDescription;
        private System.Windows.Forms.Label lbl_jobDescription;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_Add;
    }
}