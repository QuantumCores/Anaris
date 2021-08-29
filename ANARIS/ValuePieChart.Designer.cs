namespace ANARIS
{
    partial class ValuePieChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValuePieChart));
            this.chr_PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gb_Settings = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cmb_SplitBy = new System.Windows.Forms.ComboBox();
            this.lblSplitBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chr_PieChart)).BeginInit();
            this.gb_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // chr_PieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.chr_PieChart.ChartAreas.Add(chartArea1);
            this.chr_PieChart.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chr_PieChart.Legends.Add(legend1);
            this.chr_PieChart.Location = new System.Drawing.Point(0, 0);
            this.chr_PieChart.Name = "chr_PieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.CustomProperties = "PieLabelStyle=Outside";
            series1.Legend = "Legend1";
            series1.Name = "PieChartSerie";
            series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chr_PieChart.Series.Add(series1);
            this.chr_PieChart.Size = new System.Drawing.Size(1156, 584);
            this.chr_PieChart.TabIndex = 0;
            this.chr_PieChart.Text = "Diagram kołowy wartości";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Diagram kołowy wartości";
            this.chr_PieChart.Titles.Add(title1);
            // 
            // gb_Settings
            // 
            this.gb_Settings.Controls.Add(this.button1);
            this.gb_Settings.Controls.Add(this.btnCopyImage);
            this.gb_Settings.Controls.Add(this.btnLoad);
            this.gb_Settings.Controls.Add(this.cmb_SplitBy);
            this.gb_Settings.Controls.Add(this.lblSplitBy);
            this.gb_Settings.Dock = System.Windows.Forms.DockStyle.Right;
            this.gb_Settings.Location = new System.Drawing.Point(1162, 0);
            this.gb_Settings.Name = "gb_Settings";
            this.gb_Settings.Size = new System.Drawing.Size(188, 584);
            this.gb_Settings.TabIndex = 1;
            this.gb_Settings.TabStop = false;
            this.gb_Settings.Text = "Zarządzaj";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(146, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyImage.Location = new System.Drawing.Point(7, 157);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(175, 23);
            this.btnCopyImage.TabIndex = 3;
            this.btnCopyImage.Text = "Kopiuj obraz";
            this.btnCopyImage.UseVisualStyleBackColor = true;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(6, 127);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(176, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Zastosuj";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmb_SplitBy
            // 
            this.cmb_SplitBy.FormattingEnabled = true;
            this.cmb_SplitBy.Location = new System.Drawing.Point(7, 73);
            this.cmb_SplitBy.Name = "cmb_SplitBy";
            this.cmb_SplitBy.Size = new System.Drawing.Size(175, 21);
            this.cmb_SplitBy.TabIndex = 1;
            // 
            // lblSplitBy
            // 
            this.lblSplitBy.AutoSize = true;
            this.lblSplitBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplitBy.Location = new System.Drawing.Point(17, 56);
            this.lblSplitBy.Name = "lblSplitBy";
            this.lblSplitBy.Size = new System.Drawing.Size(94, 13);
            this.lblSplitBy.TabIndex = 0;
            this.lblSplitBy.Text = "Podziel według";
            // 
            // ValuePieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 584);
            this.ControlBox = false;
            this.Controls.Add(this.gb_Settings);
            this.Controls.Add(this.chr_PieChart);
            this.Name = "ValuePieChart";
            this.Text = "Diagram kołowy wartości";
            this.Resize += new System.EventHandler(this.ValuePieChart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chr_PieChart)).EndInit();
            this.gb_Settings.ResumeLayout(false);
            this.gb_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chr_PieChart;
        private System.Windows.Forms.GroupBox gb_Settings;
        private System.Windows.Forms.Label lblSplitBy;
        private System.Windows.Forms.ComboBox cmb_SplitBy;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCopyImage;
        private System.Windows.Forms.Button button1;
    }
}