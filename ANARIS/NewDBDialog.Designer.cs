namespace ANARIS
{
    partial class NewDBDialog
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
            this.newProjGrpBox1 = new System.Windows.Forms.GroupBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.projDirTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.newProjGrpBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newProjGrpBox1
            // 
            this.newProjGrpBox1.Controls.Add(this.browseBtn);
            this.newProjGrpBox1.Controls.Add(this.projDirTxtBox);
            this.newProjGrpBox1.Controls.Add(this.label2);
            this.newProjGrpBox1.Controls.Add(this.textBox1);
            this.newProjGrpBox1.Controls.Add(this.label1);
            this.newProjGrpBox1.Location = new System.Drawing.Point(12, 12);
            this.newProjGrpBox1.Name = "newProjGrpBox1";
            this.newProjGrpBox1.Size = new System.Drawing.Size(425, 95);
            this.newProjGrpBox1.TabIndex = 0;
            this.newProjGrpBox1.TabStop = false;
            this.newProjGrpBox1.Text = "Nowa baza danych";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(350, 61);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(69, 23);
            this.browseBtn.TabIndex = 6;
            this.browseBtn.Text = "Przeglądaj";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // projDirTxtBox
            // 
            this.projDirTxtBox.Location = new System.Drawing.Point(106, 64);
            this.projDirTxtBox.Name = "projDirTxtBox";
            this.projDirTxtBox.Size = new System.Drawing.Size(238, 20);
            this.projDirTxtBox.TabIndex = 3;
            this.projDirTxtBox.TextChanged += new System.EventHandler(this.projDirTxtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ścieżka projektu: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa projektu: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dalej";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(281, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewDBDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(449, 144);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newProjGrpBox1);
            this.Name = "NewDBDialog";
            this.Text = "Nowy projekt";
            this.newProjGrpBox1.ResumeLayout(false);
            this.newProjGrpBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox newProjGrpBox1;
        private System.Windows.Forms.TextBox projDirTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button browseBtn;
    }
}