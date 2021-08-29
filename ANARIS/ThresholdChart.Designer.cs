namespace ANARIS
{
    partial class ThresholdChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThresholdChart));
            this.actNowLst = new System.Windows.Forms.ListView();
            this.Scenario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Risk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Uncertainty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reasLastLst = new System.Windows.Forms.ListView();
            this.RLScenario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RLRisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RLUncertainty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reasNowLst = new System.Windows.Forms.ListView();
            this.RNScenario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RNRisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RNUncertainty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.actLastLst = new System.Windows.Forms.ListView();
            this.ALScenario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ALRisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ALUncertainty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.actLastLbl = new System.Windows.Forms.Label();
            this.reasNowLbl = new System.Windows.Forms.Label();
            this.reasLastLbl = new System.Windows.Forms.Label();
            this.loadBtn = new System.Windows.Forms.Button();
            this.actNowLbl = new System.Windows.Forms.Label();
            this.dataCmb = new System.Windows.Forms.ComboBox();
            this.wrTxt = new System.Windows.Forms.TextBox();
            this.uwrTxt = new System.Windows.Forms.TextBox();
            this.dataLbl = new System.Windows.Forms.Label();
            this.wrLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // actNowLst
            // 
            this.actNowLst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actNowLst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Scenario,
            this.Risk,
            this.Uncertainty});
            this.actNowLst.GridLines = true;
            this.actNowLst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.actNowLst.Location = new System.Drawing.Point(12, 62);
            this.actNowLst.Name = "actNowLst";
            this.actNowLst.Size = new System.Drawing.Size(273, 161);
            this.actNowLst.TabIndex = 0;
            this.actNowLst.UseCompatibleStateImageBehavior = false;
            this.actNowLst.View = System.Windows.Forms.View.Details;
            // 
            // Scenario
            // 
            this.Scenario.Text = "Scenariusz";
            this.Scenario.Width = 129;
            // 
            // Risk
            // 
            this.Risk.Text = "WR";
            this.Risk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Uncertainty
            // 
            this.Uncertainty.Text = "Niepewność";
            this.Uncertainty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Uncertainty.Width = 80;
            // 
            // reasLastLst
            // 
            this.reasLastLst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reasLastLst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RLScenario,
            this.RLRisk,
            this.RLUncertainty});
            this.reasLastLst.GridLines = true;
            this.reasLastLst.Location = new System.Drawing.Point(300, 250);
            this.reasLastLst.Name = "reasLastLst";
            this.reasLastLst.Size = new System.Drawing.Size(273, 161);
            this.reasLastLst.TabIndex = 1;
            this.reasLastLst.UseCompatibleStateImageBehavior = false;
            this.reasLastLst.View = System.Windows.Forms.View.Details;
            // 
            // RLScenario
            // 
            this.RLScenario.Text = "Scenariusz";
            this.RLScenario.Width = 129;
            // 
            // RLRisk
            // 
            this.RLRisk.Text = "WR";
            this.RLRisk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RLUncertainty
            // 
            this.RLUncertainty.Text = "Niepewność";
            this.RLUncertainty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RLUncertainty.Width = 80;
            // 
            // reasNowLst
            // 
            this.reasNowLst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reasNowLst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RNScenario,
            this.RNRisk,
            this.RNUncertainty});
            this.reasNowLst.GridLines = true;
            this.reasNowLst.Location = new System.Drawing.Point(300, 62);
            this.reasNowLst.Name = "reasNowLst";
            this.reasNowLst.Size = new System.Drawing.Size(273, 161);
            this.reasNowLst.TabIndex = 2;
            this.reasNowLst.UseCompatibleStateImageBehavior = false;
            this.reasNowLst.View = System.Windows.Forms.View.Details;
            // 
            // RNScenario
            // 
            this.RNScenario.Text = "Scenariusz";
            this.RNScenario.Width = 129;
            // 
            // RNRisk
            // 
            this.RNRisk.Text = "WR";
            this.RNRisk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RNUncertainty
            // 
            this.RNUncertainty.Text = "Niepewność";
            this.RNUncertainty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RNUncertainty.Width = 80;
            // 
            // actLastLst
            // 
            this.actLastLst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actLastLst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ALScenario,
            this.ALRisk,
            this.ALUncertainty});
            this.actLastLst.GridLines = true;
            this.actLastLst.Location = new System.Drawing.Point(12, 250);
            this.actLastLst.Name = "actLastLst";
            this.actLastLst.Size = new System.Drawing.Size(273, 161);
            this.actLastLst.TabIndex = 3;
            this.actLastLst.UseCompatibleStateImageBehavior = false;
            this.actLastLst.View = System.Windows.Forms.View.Details;
            // 
            // ALScenario
            // 
            this.ALScenario.Text = "Scenariusz";
            this.ALScenario.Width = 129;
            // 
            // ALRisk
            // 
            this.ALRisk.Text = "WR";
            this.ALRisk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ALUncertainty
            // 
            this.ALUncertainty.Text = "Niepewność";
            this.ALUncertainty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ALUncertainty.Width = 80;
            // 
            // actLastLbl
            // 
            this.actLastLbl.AutoSize = true;
            this.actLastLbl.Location = new System.Drawing.Point(13, 234);
            this.actLastLbl.Name = "actLastLbl";
            this.actLastLbl.Size = new System.Drawing.Size(158, 13);
            this.actLastLbl.TabIndex = 5;
            this.actLastLbl.Text = "Zostaw to zagrożenie na koniec";
            // 
            // reasNowLbl
            // 
            this.reasNowLbl.AutoSize = true;
            this.reasNowLbl.Location = new System.Drawing.Point(309, 43);
            this.reasNowLbl.Name = "reasNowLbl";
            this.reasNowLbl.Size = new System.Drawing.Size(141, 13);
            this.reasNowLbl.TabIndex = 6;
            this.reasNowLbl.Text = "Zbadaj sytuację natychmiast";
            // 
            // reasLastLbl
            // 
            this.reasLastLbl.AutoSize = true;
            this.reasLastLbl.Location = new System.Drawing.Point(309, 234);
            this.reasLastLbl.Name = "reasLastLbl";
            this.reasLastLbl.Size = new System.Drawing.Size(118, 13);
            this.reasLastLbl.TabIndex = 7;
            this.reasLastLbl.Text = "Zbadaj sytuację później";
            // 
            // loadBtn
            // 
            this.loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBtn.Location = new System.Drawing.Point(429, 11);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 8;
            this.loadBtn.Text = "Zastosuj";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // actNowLbl
            // 
            this.actNowLbl.AutoSize = true;
            this.actNowLbl.Location = new System.Drawing.Point(13, 43);
            this.actNowLbl.Name = "actNowLbl";
            this.actNowLbl.Size = new System.Drawing.Size(215, 13);
            this.actNowLbl.TabIndex = 4;
            this.actNowLbl.Text = "Przeciwdziałaj tym zagrożeniom natychmiast";
            // 
            // dataCmb
            // 
            this.dataCmb.FormattingEnabled = true;
            this.dataCmb.Location = new System.Drawing.Point(60, 13);
            this.dataCmb.Name = "dataCmb";
            this.dataCmb.Size = new System.Drawing.Size(121, 21);
            this.dataCmb.TabIndex = 9;
            // 
            // wrTxt
            // 
            this.wrTxt.Location = new System.Drawing.Point(233, 12);
            this.wrTxt.Name = "wrTxt";
            this.wrTxt.Size = new System.Drawing.Size(45, 20);
            this.wrTxt.TabIndex = 10;
            this.wrTxt.Text = "10";
            this.wrTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uwrTxt
            // 
            this.uwrTxt.Location = new System.Drawing.Point(378, 12);
            this.uwrTxt.Name = "uwrTxt";
            this.uwrTxt.Size = new System.Drawing.Size(45, 20);
            this.uwrTxt.TabIndex = 11;
            this.uwrTxt.Text = "2";
            this.uwrTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataLbl
            // 
            this.dataLbl.AutoSize = true;
            this.dataLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataLbl.Location = new System.Drawing.Point(12, 16);
            this.dataLbl.Name = "dataLbl";
            this.dataLbl.Size = new System.Drawing.Size(37, 13);
            this.dataLbl.TabIndex = 12;
            this.dataLbl.Text = "Dane";
            // 
            // wrLbl
            // 
            this.wrLbl.AutoSize = true;
            this.wrLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wrLbl.Location = new System.Drawing.Point(199, 15);
            this.wrLbl.Name = "wrLbl";
            this.wrLbl.Size = new System.Drawing.Size(28, 13);
            this.wrLbl.TabIndex = 13;
            this.wrLbl.Text = "WR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(296, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Niepewność";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(548, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ThresholdChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 434);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wrLbl);
            this.Controls.Add(this.dataLbl);
            this.Controls.Add(this.uwrTxt);
            this.Controls.Add(this.wrTxt);
            this.Controls.Add(this.dataCmb);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.reasLastLbl);
            this.Controls.Add(this.reasNowLbl);
            this.Controls.Add(this.actLastLbl);
            this.Controls.Add(this.actNowLbl);
            this.Controls.Add(this.actLastLst);
            this.Controls.Add(this.reasNowLst);
            this.Controls.Add(this.reasLastLst);
            this.Controls.Add(this.actNowLst);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "ThresholdChart";
            this.Text = "Tabela wielkości ryzyka i niepewności";
            this.Resize += new System.EventHandler(this.ThresholdChart_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView actNowLst;
        private System.Windows.Forms.ListView reasLastLst;
        private System.Windows.Forms.ListView reasNowLst;
        private System.Windows.Forms.ListView actLastLst;
        private System.Windows.Forms.ColumnHeader Scenario;
        private System.Windows.Forms.ColumnHeader Risk;
        private System.Windows.Forms.ColumnHeader Uncertainty;
        private System.Windows.Forms.Label actLastLbl;
        private System.Windows.Forms.Label reasNowLbl;
        private System.Windows.Forms.Label reasLastLbl;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.ColumnHeader RLScenario;
        private System.Windows.Forms.ColumnHeader RLRisk;
        private System.Windows.Forms.ColumnHeader RLUncertainty;
        private System.Windows.Forms.ColumnHeader RNScenario;
        private System.Windows.Forms.ColumnHeader RNRisk;
        private System.Windows.Forms.ColumnHeader RNUncertainty;
        private System.Windows.Forms.ColumnHeader ALScenario;
        private System.Windows.Forms.ColumnHeader ALRisk;
        private System.Windows.Forms.ColumnHeader ALUncertainty;
        private System.Windows.Forms.Label actNowLbl;
        private System.Windows.Forms.ComboBox dataCmb;
        private System.Windows.Forms.TextBox wrTxt;
        private System.Windows.Forms.TextBox uwrTxt;
        private System.Windows.Forms.Label dataLbl;
        private System.Windows.Forms.Label wrLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}