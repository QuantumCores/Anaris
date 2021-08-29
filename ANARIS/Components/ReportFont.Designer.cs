namespace ANARIS.Components
{
    partial class ReportFont
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
            this.lbl_FontFor = new System.Windows.Forms.Label();
            this.cmbFontFace = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.lblFontColor = new System.Windows.Forms.Label();
            this.cbBold = new System.Windows.Forms.CheckBox();
            this.cbItalic = new System.Windows.Forms.CheckBox();
            this.lbl_R = new System.Windows.Forms.Label();
            this.nud_R = new System.Windows.Forms.NumericUpDown();
            this.lbl_G = new System.Windows.Forms.Label();
            this.nud_G = new System.Windows.Forms.NumericUpDown();
            this.lbl_B = new System.Windows.Forms.Label();
            this.nud_B = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_B)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_FontFor
            // 
            this.lbl_FontFor.AutoSize = true;
            this.lbl_FontFor.Location = new System.Drawing.Point(11, 9);
            this.lbl_FontFor.Name = "lbl_FontFor";
            this.lbl_FontFor.Size = new System.Drawing.Size(69, 13);
            this.lbl_FontFor.TabIndex = 0;
            this.lbl_FontFor.Text = "Font_for_text";
            // 
            // cmbFontFace
            // 
            this.cmbFontFace.FormattingEnabled = true;
            this.cmbFontFace.Location = new System.Drawing.Point(106, 6);
            this.cmbFontFace.Name = "cmbFontFace";
            this.cmbFontFace.Size = new System.Drawing.Size(200, 21);
            this.cmbFontFace.TabIndex = 1;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(312, 9);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(51, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Rozmiar: ";
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(369, 7);
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(41, 20);
            this.nudSize.TabIndex = 2;
            this.nudSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lblFontColor
            // 
            this.lblFontColor.AutoSize = true;
            this.lblFontColor.Location = new System.Drawing.Point(416, 9);
            this.lblFontColor.Name = "lblFontColor";
            this.lblFontColor.Size = new System.Drawing.Size(37, 13);
            this.lblFontColor.TabIndex = 4;
            this.lblFontColor.Text = "Kolor: ";
            // 
            // cbBold
            // 
            this.cbBold.AutoSize = true;
            this.cbBold.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBold.Location = new System.Drawing.Point(678, 7);
            this.cbBold.Name = "cbBold";
            this.cbBold.Size = new System.Drawing.Size(77, 17);
            this.cbBold.TabIndex = 6;
            this.cbBold.Text = "Pogrubiona";
            this.cbBold.UseVisualStyleBackColor = true;
            // 
            // cbItalic
            // 
            this.cbItalic.AutoSize = true;
            this.cbItalic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbItalic.Location = new System.Drawing.Point(761, 7);
            this.cbItalic.Name = "cbItalic";
            this.cbItalic.Size = new System.Drawing.Size(73, 17);
            this.cbItalic.TabIndex = 7;
            this.cbItalic.Text = "Pochylona";
            this.cbItalic.UseVisualStyleBackColor = true;
            // 
            // lbl_R
            // 
            this.lbl_R.AutoSize = true;
            this.lbl_R.Location = new System.Drawing.Point(459, 9);
            this.lbl_R.Name = "lbl_R";
            this.lbl_R.Size = new System.Drawing.Size(15, 13);
            this.lbl_R.TabIndex = 8;
            this.lbl_R.Text = "R";
            // 
            // nud_R
            // 
            this.nud_R.Location = new System.Drawing.Point(480, 7);
            this.nud_R.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_R.Name = "nud_R";
            this.nud_R.Size = new System.Drawing.Size(41, 20);
            this.nud_R.TabIndex = 9;
            this.nud_R.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // lbl_G
            // 
            this.lbl_G.AutoSize = true;
            this.lbl_G.Location = new System.Drawing.Point(532, 9);
            this.lbl_G.Name = "lbl_G";
            this.lbl_G.Size = new System.Drawing.Size(15, 13);
            this.lbl_G.TabIndex = 10;
            this.lbl_G.Text = "G";
            // 
            // nud_G
            // 
            this.nud_G.Location = new System.Drawing.Point(553, 7);
            this.nud_G.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_G.Name = "nud_G";
            this.nud_G.Size = new System.Drawing.Size(41, 20);
            this.nud_G.TabIndex = 11;
            this.nud_G.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // lbl_B
            // 
            this.lbl_B.AutoSize = true;
            this.lbl_B.Location = new System.Drawing.Point(607, 9);
            this.lbl_B.Name = "lbl_B";
            this.lbl_B.Size = new System.Drawing.Size(14, 13);
            this.lbl_B.TabIndex = 12;
            this.lbl_B.Text = "B";
            // 
            // nud_B
            // 
            this.nud_B.Location = new System.Drawing.Point(628, 7);
            this.nud_B.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_B.Name = "nud_B";
            this.nud_B.Size = new System.Drawing.Size(41, 20);
            this.nud_B.TabIndex = 13;
            this.nud_B.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // ReportFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_B);
            this.Controls.Add(this.nud_B);
            this.Controls.Add(this.lbl_G);
            this.Controls.Add(this.nud_G);
            this.Controls.Add(this.lbl_R);
            this.Controls.Add(this.nud_R);
            this.Controls.Add(this.cbItalic);
            this.Controls.Add(this.cbBold);
            this.Controls.Add(this.cmbFontFace);
            this.Controls.Add(this.lblFontColor);
            this.Controls.Add(this.lbl_FontFor);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.nudSize);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "ReportFont";
            this.Size = new System.Drawing.Size(845, 34);
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFontColor;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cmbFontFace;
        private System.Windows.Forms.Label lbl_FontFor;
        private System.Windows.Forms.CheckBox cbBold;
        private System.Windows.Forms.CheckBox cbItalic;
        private System.Windows.Forms.Label lbl_R;
        private System.Windows.Forms.NumericUpDown nud_R;
        private System.Windows.Forms.Label lbl_G;
        private System.Windows.Forms.NumericUpDown nud_G;
        private System.Windows.Forms.Label lbl_B;
        private System.Windows.Forms.NumericUpDown nud_B;
    }
}
