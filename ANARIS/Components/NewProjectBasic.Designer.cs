namespace ANARIS.Components
{
    partial class NewProjectBasic
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
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.txt_ProjectName = new System.Windows.Forms.TextBox();
            this.lbl_ProjectDir = new System.Windows.Forms.Label();
            this.txt_ProjectDierctory = new System.Windows.Forms.TextBox();
            this.btn_Dir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.AutoSize = true;
            this.lbl_ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectName.Location = new System.Drawing.Point(28, 19);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(99, 13);
            this.lbl_ProjectName.TabIndex = 0;
            this.lbl_ProjectName.Text = "Nazwa projektu:";
            // 
            // txt_ProjectName
            // 
            this.txt_ProjectName.Location = new System.Drawing.Point(147, 16);
            this.txt_ProjectName.Name = "txt_ProjectName";
            this.txt_ProjectName.Size = new System.Drawing.Size(401, 20);
            this.txt_ProjectName.TabIndex = 1;
            // 
            // lbl_ProjectDir
            // 
            this.lbl_ProjectDir.AutoSize = true;
            this.lbl_ProjectDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProjectDir.Location = new System.Drawing.Point(28, 46);
            this.lbl_ProjectDir.Name = "lbl_ProjectDir";
            this.lbl_ProjectDir.Size = new System.Drawing.Size(106, 13);
            this.lbl_ProjectDir.TabIndex = 2;
            this.lbl_ProjectDir.Text = "Ścieżka projektu:";
            // 
            // txt_ProjectDierctory
            // 
            this.txt_ProjectDierctory.Location = new System.Drawing.Point(147, 43);
            this.txt_ProjectDierctory.Name = "txt_ProjectDierctory";
            this.txt_ProjectDierctory.Size = new System.Drawing.Size(312, 20);
            this.txt_ProjectDierctory.TabIndex = 3;
            // 
            // btn_Dir
            // 
            this.btn_Dir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dir.Location = new System.Drawing.Point(465, 40);
            this.btn_Dir.Name = "btn_Dir";
            this.btn_Dir.Size = new System.Drawing.Size(83, 23);
            this.btn_Dir.TabIndex = 4;
            this.btn_Dir.Text = "Ścieżka";
            this.btn_Dir.UseVisualStyleBackColor = true;
            this.btn_Dir.Click += new System.EventHandler(this.btn_Dir_Click);
            // 
            // NewProjectBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Dir);
            this.Controls.Add(this.txt_ProjectDierctory);
            this.Controls.Add(this.lbl_ProjectDir);
            this.Controls.Add(this.txt_ProjectName);
            this.Controls.Add(this.lbl_ProjectName);
            this.Name = "NewProjectBasic";
            this.Size = new System.Drawing.Size(567, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProjectName;
        private System.Windows.Forms.TextBox txt_ProjectName;
        private System.Windows.Forms.Label lbl_ProjectDir;
        private System.Windows.Forms.TextBox txt_ProjectDierctory;
        private System.Windows.Forms.Button btn_Dir;
    }
}
