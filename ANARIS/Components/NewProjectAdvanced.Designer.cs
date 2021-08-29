namespace ANARIS.Components
{
    partial class NewProjectAdvanced
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
            this.gbAdvanced = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblOtherAuthors = new System.Windows.Forms.Label();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gbInstitution = new System.Windows.Forms.GroupBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.gbAdvanced.SuspendLayout();
            this.gbInstitution.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAdvanced
            // 
            this.gbAdvanced.Controls.Add(this.gbInstitution);
            this.gbAdvanced.Controls.Add(this.lblOtherAuthors);
            this.gbAdvanced.Controls.Add(this.textBox1);
            this.gbAdvanced.Location = new System.Drawing.Point(3, 3);
            this.gbAdvanced.Name = "gbAdvanced";
            this.gbAdvanced.Size = new System.Drawing.Size(540, 228);
            this.gbAdvanced.TabIndex = 0;
            this.gbAdvanced.TabStop = false;
            this.gbAdvanced.Text = "Zaawansowane";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(398, 20);
            this.textBox1.TabIndex = 0;
            // 
            // lblOtherAuthors
            // 
            this.lblOtherAuthors.AutoSize = true;
            this.lblOtherAuthors.Location = new System.Drawing.Point(6, 35);
            this.lblOtherAuthors.Name = "lblOtherAuthors";
            this.lblOtherAuthors.Size = new System.Drawing.Size(89, 13);
            this.lblOtherAuthors.TabIndex = 1;
            this.lblOtherAuthors.Text = "Pozostali autorzy:";
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.Location = new System.Drawing.Point(15, 27);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(43, 13);
            this.lblInstitution.TabIndex = 2;
            this.lblInstitution.Text = "Nazwa:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(389, 20);
            this.textBox2.TabIndex = 3;
            // 
            // gbInstitution
            // 
            this.gbInstitution.Controls.Add(this.lblPostalCode);
            this.gbInstitution.Controls.Add(this.lblCity);
            this.gbInstitution.Controls.Add(this.textBox5);
            this.gbInstitution.Controls.Add(this.textBox4);
            this.gbInstitution.Controls.Add(this.textBox3);
            this.gbInstitution.Controls.Add(this.lblStreet);
            this.gbInstitution.Controls.Add(this.lblInstitution);
            this.gbInstitution.Controls.Add(this.textBox2);
            this.gbInstitution.Location = new System.Drawing.Point(9, 76);
            this.gbInstitution.Name = "gbInstitution";
            this.gbInstitution.Size = new System.Drawing.Size(520, 139);
            this.gbInstitution.TabIndex = 4;
            this.gbInstitution.TabStop = false;
            this.gbInstitution.Text = "Sporządzone dla";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(15, 53);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(34, 13);
            this.lblStreet.TabIndex = 4;
            this.lblStreet.Text = "Ulica:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(75, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(389, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(364, 77);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(75, 77);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(239, 20);
            this.textBox5.TabIndex = 7;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(15, 80);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(41, 13);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "Miasto:";
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(320, 80);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(28, 13);
            this.lblPostalCode.TabIndex = 9;
            this.lblPostalCode.Text = "kod:";
            // 
            // NewProjectAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAdvanced);
            this.Name = "NewProjectAdvanced";
            this.Size = new System.Drawing.Size(550, 235);
            this.gbAdvanced.ResumeLayout(false);
            this.gbAdvanced.PerformLayout();
            this.gbInstitution.ResumeLayout(false);
            this.gbInstitution.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.GroupBox gbInstitution;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblInstitution;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblOtherAuthors;
        private System.Windows.Forms.TextBox textBox1;
    }
}
