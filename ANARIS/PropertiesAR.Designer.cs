namespace ANARIS
{
    partial class PropertiesAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesAR));
            this.lbl_projectName = new System.Windows.Forms.Label();
            this.txt_projectName = new System.Windows.Forms.TextBox();
            this.lbl_path = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.lbl_createdOn = new System.Windows.Forms.Label();
            this.txt_createdOn = new System.Windows.Forms.TextBox();
            this.lbl_modifiedOn = new System.Windows.Forms.Label();
            this.txt_modifiedOn = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_scope = new System.Windows.Forms.TextBox();
            this.lbl_scope = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_OrgName = new System.Windows.Forms.Label();
            this.txt_OrgName = new System.Windows.Forms.TextBox();
            this.lbl_City = new System.Windows.Forms.Label();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.lbl_Postal = new System.Windows.Forms.Label();
            this.txt_Postal = new System.Windows.Forms.TextBox();
            this.lbl_street = new System.Windows.Forms.Label();
            this.txt_Street = new System.Windows.Forms.TextBox();
            this.acRiskTeam = new ANARIS.Components.AuthorsControl();
            this.acReportTeam = new ANARIS.Components.AuthorsControl();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_ReportIntro = new System.Windows.Forms.Label();
            this.txt_ReportIntro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_projectName
            // 
            this.lbl_projectName.AutoSize = true;
            this.lbl_projectName.Location = new System.Drawing.Point(13, 13);
            this.lbl_projectName.Name = "lbl_projectName";
            this.lbl_projectName.Size = new System.Drawing.Size(84, 13);
            this.lbl_projectName.TabIndex = 0;
            this.lbl_projectName.Text = "Nazwa projektu:";
            // 
            // txt_projectName
            // 
            this.txt_projectName.Location = new System.Drawing.Point(130, 10);
            this.txt_projectName.Name = "txt_projectName";
            this.txt_projectName.Size = new System.Drawing.Size(345, 20);
            this.txt_projectName.TabIndex = 1;
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(13, 40);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(48, 13);
            this.lbl_path.TabIndex = 2;
            this.lbl_path.Text = "Ścieżka:";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(130, 37);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(345, 20);
            this.txt_path.TabIndex = 3;
            // 
            // lbl_createdOn
            // 
            this.lbl_createdOn.AutoSize = true;
            this.lbl_createdOn.Location = new System.Drawing.Point(13, 67);
            this.lbl_createdOn.Name = "lbl_createdOn";
            this.lbl_createdOn.Size = new System.Drawing.Size(59, 13);
            this.lbl_createdOn.TabIndex = 4;
            this.lbl_createdOn.Text = "Stworzony:";
            // 
            // txt_createdOn
            // 
            this.txt_createdOn.Location = new System.Drawing.Point(130, 64);
            this.txt_createdOn.Name = "txt_createdOn";
            this.txt_createdOn.ReadOnly = true;
            this.txt_createdOn.Size = new System.Drawing.Size(385, 20);
            this.txt_createdOn.TabIndex = 5;
            // 
            // lbl_modifiedOn
            // 
            this.lbl_modifiedOn.AutoSize = true;
            this.lbl_modifiedOn.Location = new System.Drawing.Point(13, 93);
            this.lbl_modifiedOn.Name = "lbl_modifiedOn";
            this.lbl_modifiedOn.Size = new System.Drawing.Size(84, 13);
            this.lbl_modifiedOn.TabIndex = 6;
            this.lbl_modifiedOn.Text = "Zmodyfikowany:";
            // 
            // txt_modifiedOn
            // 
            this.txt_modifiedOn.Location = new System.Drawing.Point(130, 90);
            this.txt_modifiedOn.Name = "txt_modifiedOn";
            this.txt_modifiedOn.ReadOnly = true;
            this.txt_modifiedOn.Size = new System.Drawing.Size(385, 20);
            this.txt_modifiedOn.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Location = new System.Drawing.Point(961, 478);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 13;
            this.btn_save.Text = "Zapisz";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(880, 478);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "Anuluj";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_scope
            // 
            this.txt_scope.Location = new System.Drawing.Point(130, 117);
            this.txt_scope.Name = "txt_scope";
            this.txt_scope.Size = new System.Drawing.Size(385, 20);
            this.txt_scope.TabIndex = 16;
            // 
            // lbl_scope
            // 
            this.lbl_scope.AutoSize = true;
            this.lbl_scope.Location = new System.Drawing.Point(13, 120);
            this.lbl_scope.Name = "lbl_scope";
            this.lbl_scope.Size = new System.Drawing.Size(75, 13);
            this.lbl_scope.TabIndex = 17;
            this.lbl_scope.Text = "Zakres oceny:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Instytucja:";
            // 
            // lbl_OrgName
            // 
            this.lbl_OrgName.AutoSize = true;
            this.lbl_OrgName.Location = new System.Drawing.Point(29, 166);
            this.lbl_OrgName.Name = "lbl_OrgName";
            this.lbl_OrgName.Size = new System.Drawing.Size(43, 13);
            this.lbl_OrgName.TabIndex = 19;
            this.lbl_OrgName.Text = "Nazwa:";
            // 
            // txt_OrgName
            // 
            this.txt_OrgName.Location = new System.Drawing.Point(130, 163);
            this.txt_OrgName.Name = "txt_OrgName";
            this.txt_OrgName.Size = new System.Drawing.Size(385, 20);
            this.txt_OrgName.TabIndex = 20;
            // 
            // lbl_City
            // 
            this.lbl_City.AutoSize = true;
            this.lbl_City.Location = new System.Drawing.Point(29, 193);
            this.lbl_City.Name = "lbl_City";
            this.lbl_City.Size = new System.Drawing.Size(41, 13);
            this.lbl_City.TabIndex = 21;
            this.lbl_City.Text = "Miasto:";
            // 
            // txt_City
            // 
            this.txt_City.Location = new System.Drawing.Point(130, 190);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(192, 20);
            this.txt_City.TabIndex = 22;
            // 
            // lbl_Postal
            // 
            this.lbl_Postal.AutoSize = true;
            this.lbl_Postal.Location = new System.Drawing.Point(356, 193);
            this.lbl_Postal.Name = "lbl_Postal";
            this.lbl_Postal.Size = new System.Drawing.Size(29, 13);
            this.lbl_Postal.TabIndex = 23;
            this.lbl_Postal.Text = "Kod:";
            // 
            // txt_Postal
            // 
            this.txt_Postal.Location = new System.Drawing.Point(415, 190);
            this.txt_Postal.Name = "txt_Postal";
            this.txt_Postal.Size = new System.Drawing.Size(100, 20);
            this.txt_Postal.TabIndex = 24;
            // 
            // lbl_street
            // 
            this.lbl_street.AutoSize = true;
            this.lbl_street.Location = new System.Drawing.Point(32, 219);
            this.lbl_street.Name = "lbl_street";
            this.lbl_street.Size = new System.Drawing.Size(34, 13);
            this.lbl_street.TabIndex = 25;
            this.lbl_street.Text = "Ulica:";
            // 
            // txt_Street
            // 
            this.txt_Street.Location = new System.Drawing.Point(130, 219);
            this.txt_Street.Name = "txt_Street";
            this.txt_Street.Size = new System.Drawing.Size(386, 20);
            this.txt_Street.TabIndex = 26;
            // 
            // acRiskTeam
            // 
            this.acRiskTeam.Location = new System.Drawing.Point(528, 245);
            this.acRiskTeam.Name = "acRiskTeam";
            this.acRiskTeam.Size = new System.Drawing.Size(510, 227);
            this.acRiskTeam.TabIndex = 27;
            // 
            // acReportTeam
            // 
            this.acReportTeam.Location = new System.Drawing.Point(12, 245);
            this.acReportTeam.Name = "acReportTeam";
            this.acReportTeam.Size = new System.Drawing.Size(510, 227);
            this.acReportTeam.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(492, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_ReportIntro
            // 
            this.lbl_ReportIntro.AutoSize = true;
            this.lbl_ReportIntro.Location = new System.Drawing.Point(528, 13);
            this.lbl_ReportIntro.Name = "lbl_ReportIntro";
            this.lbl_ReportIntro.Size = new System.Drawing.Size(92, 13);
            this.lbl_ReportIntro.TabIndex = 30;
            this.lbl_ReportIntro.Text = "Wstęp do raportu:";
            // 
            // txt_ReportIntro
            // 
            this.txt_ReportIntro.Location = new System.Drawing.Point(531, 29);
            this.txt_ReportIntro.Multiline = true;
            this.txt_ReportIntro.Name = "txt_ReportIntro";
            this.txt_ReportIntro.Size = new System.Drawing.Size(505, 210);
            this.txt_ReportIntro.TabIndex = 31;
            // 
            // PropertiesAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 512);
            this.ControlBox = false;
            this.Controls.Add(this.txt_ReportIntro);
            this.Controls.Add(this.lbl_ReportIntro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.acReportTeam);
            this.Controls.Add(this.acRiskTeam);
            this.Controls.Add(this.txt_Street);
            this.Controls.Add(this.lbl_street);
            this.Controls.Add(this.txt_Postal);
            this.Controls.Add(this.lbl_Postal);
            this.Controls.Add(this.txt_City);
            this.Controls.Add(this.lbl_City);
            this.Controls.Add(this.txt_OrgName);
            this.Controls.Add(this.lbl_OrgName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_scope);
            this.Controls.Add(this.txt_scope);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_modifiedOn);
            this.Controls.Add(this.lbl_modifiedOn);
            this.Controls.Add(this.txt_createdOn);
            this.Controls.Add(this.lbl_createdOn);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.lbl_path);
            this.Controls.Add(this.txt_projectName);
            this.Controls.Add(this.lbl_projectName);
            this.Name = "PropertiesAR";
            this.Text = "Informacje ogólne";
            this.Load += new System.EventHandler(this.PropertiesAR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_projectName;
        private System.Windows.Forms.TextBox txt_projectName;
        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Label lbl_createdOn;
        private System.Windows.Forms.TextBox txt_createdOn;
        private System.Windows.Forms.Label lbl_modifiedOn;
        private System.Windows.Forms.TextBox txt_modifiedOn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_scope;
        private System.Windows.Forms.Label lbl_scope;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_OrgName;
        private System.Windows.Forms.TextBox txt_OrgName;
        private System.Windows.Forms.Label lbl_City;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.Label lbl_Postal;
        private System.Windows.Forms.TextBox txt_Postal;
        private System.Windows.Forms.Label lbl_street;
        private System.Windows.Forms.TextBox txt_Street;
        private Components.AuthorsControl acRiskTeam;
        private Components.AuthorsControl acReportTeam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_ReportIntro;
        private System.Windows.Forms.TextBox txt_ReportIntro;
    }
}