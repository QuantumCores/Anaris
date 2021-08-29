namespace ANARIS
{
    partial class MergeDB
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
            this.lbl_dir = new System.Windows.Forms.Label();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.btn_dir = new System.Windows.Forms.Button();
            this.rd_all = new System.Windows.Forms.RadioButton();
            this.rd_origial = new System.Windows.Forms.RadioButton();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_merge = new System.Windows.Forms.Button();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lbl_dir
            // 
            this.lbl_dir.AutoSize = true;
            this.lbl_dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dir.Location = new System.Drawing.Point(12, 30);
            this.lbl_dir.Name = "lbl_dir";
            this.lbl_dir.Size = new System.Drawing.Size(148, 13);
            this.lbl_dir.TabIndex = 0;
            this.lbl_dir.Text = "Baza do zaimportowania:";
            // 
            // txt_dir
            // 
            this.txt_dir.Location = new System.Drawing.Point(166, 28);
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(279, 20);
            this.txt_dir.TabIndex = 1;
            // 
            // btn_dir
            // 
            this.btn_dir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dir.Location = new System.Drawing.Point(451, 26);
            this.btn_dir.Name = "btn_dir";
            this.btn_dir.Size = new System.Drawing.Size(75, 23);
            this.btn_dir.TabIndex = 2;
            this.btn_dir.Text = "Ścieżka";
            this.btn_dir.UseVisualStyleBackColor = true;
            this.btn_dir.Click += new System.EventHandler(this.btn_dir_Click);
            // 
            // rd_all
            // 
            this.rd_all.AutoSize = true;
            this.rd_all.Location = new System.Drawing.Point(57, 72);
            this.rd_all.Name = "rd_all";
            this.rd_all.Size = new System.Drawing.Size(148, 17);
            this.rd_all.TabIndex = 3;
            this.rd_all.TabStop = true;
            this.rd_all.Text = "Importuj wszystkie wiersze";
            this.rd_all.UseVisualStyleBackColor = true;
            // 
            // rd_origial
            // 
            this.rd_origial.AutoSize = true;
            this.rd_origial.Location = new System.Drawing.Point(245, 72);
            this.rd_origial.Name = "rd_origial";
            this.rd_origial.Size = new System.Drawing.Size(151, 17);
            this.rd_origial.TabIndex = 4;
            this.rd_origial.TabStop = true;
            this.rd_origial.Text = "Importuj oryginalne wiersze";
            this.rd_origial.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(370, 110);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Anuluj";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_merge
            // 
            this.btn_merge.Location = new System.Drawing.Point(451, 110);
            this.btn_merge.Name = "btn_merge";
            this.btn_merge.Size = new System.Drawing.Size(75, 23);
            this.btn_merge.TabIndex = 6;
            this.btn_merge.Text = "Scalaj";
            this.btn_merge.UseVisualStyleBackColor = true;
            this.btn_merge.Click += new System.EventHandler(this.btn_merge_Click);
            // 
            // openFD
            // 
            this.openFD.FileName = "database.anrb";
            // 
            // MergeDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 145);
            this.Controls.Add(this.btn_merge);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.rd_origial);
            this.Controls.Add(this.rd_all);
            this.Controls.Add(this.btn_dir);
            this.Controls.Add(this.txt_dir);
            this.Controls.Add(this.lbl_dir);
            this.Name = "MergeDB";
            this.Text = "Scal bazy danych";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_dir;
        private System.Windows.Forms.Button btn_dir;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_merge;
        public System.Windows.Forms.TextBox txt_dir;
        public System.Windows.Forms.RadioButton rd_all;
        public System.Windows.Forms.RadioButton rd_origial;
        private System.Windows.Forms.OpenFileDialog openFD;
    }
}