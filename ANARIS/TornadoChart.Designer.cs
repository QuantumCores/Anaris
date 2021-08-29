namespace ANARIS
{
    partial class TornadoChart
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TornadoChart));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.loadBtn = new System.Windows.Forms.Button();
            this.copyImgBtn = new System.Windows.Forms.Button();
            this.dataLbl = new System.Windows.Forms.Label();
            this.dataCmb = new System.Windows.Forms.ComboBox();
            this.sortLbl = new System.Windows.Forms.Label();
            this.sortCmb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.dataGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Scenariusz";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.Maximum = 15D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.Interval = 1D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Title = "Wielkość ryzyka";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series1.Legend = "Legend1";
            series1.LegendText = "A";
            series1.Name = "Aval";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series2.Legend = "Legend1";
            series2.LegendText = "B";
            series2.Name = "Bval";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series3.Legend = "Legend1";
            series3.LegendText = "C";
            series3.Name = "Cval";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(657, 451);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            title1.Name = "Title1";
            title1.Text = "Wielkość Ryzyka";
            this.chart1.Titles.Add(title1);
            // 
            // loadBtn
            // 
            this.loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBtn.Location = new System.Drawing.Point(6, 164);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(152, 23);
            this.loadBtn.TabIndex = 1;
            this.loadBtn.Text = "Zastosuj";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // copyImgBtn
            // 
            this.copyImgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyImgBtn.Location = new System.Drawing.Point(6, 193);
            this.copyImgBtn.Name = "copyImgBtn";
            this.copyImgBtn.Size = new System.Drawing.Size(152, 23);
            this.copyImgBtn.TabIndex = 3;
            this.copyImgBtn.Text = "Kopiuj obraz";
            this.copyImgBtn.UseVisualStyleBackColor = true;
            this.copyImgBtn.Click += new System.EventHandler(this.copyImgBtn_Click);
            // 
            // dataLbl
            // 
            this.dataLbl.AutoSize = true;
            this.dataLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataLbl.Location = new System.Drawing.Point(15, 60);
            this.dataLbl.Name = "dataLbl";
            this.dataLbl.Size = new System.Drawing.Size(105, 13);
            this.dataLbl.TabIndex = 4;
            this.dataLbl.Text = "Dane do wykresu";
            // 
            // dataCmb
            // 
            this.dataCmb.FormattingEnabled = true;
            this.dataCmb.Location = new System.Drawing.Point(6, 76);
            this.dataCmb.Name = "dataCmb";
            this.dataCmb.Size = new System.Drawing.Size(152, 21);
            this.dataCmb.TabIndex = 5;
            // 
            // sortLbl
            // 
            this.sortLbl.AutoSize = true;
            this.sortLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sortLbl.Location = new System.Drawing.Point(15, 100);
            this.sortLbl.Name = "sortLbl";
            this.sortLbl.Size = new System.Drawing.Size(60, 13);
            this.sortLbl.TabIndex = 6;
            this.sortLbl.Text = "Sortuj wg";
            // 
            // sortCmb
            // 
            this.sortCmb.FormattingEnabled = true;
            this.sortCmb.Location = new System.Drawing.Point(6, 116);
            this.sortCmb.Name = "sortCmb";
            this.sortCmb.Size = new System.Drawing.Size(152, 21);
            this.sortCmb.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(138, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGBox
            // 
            this.dataGBox.Controls.Add(this.copyImgBtn);
            this.dataGBox.Controls.Add(this.sortCmb);
            this.dataGBox.Controls.Add(this.loadBtn);
            this.dataGBox.Controls.Add(this.sortLbl);
            this.dataGBox.Controls.Add(this.dataCmb);
            this.dataGBox.Controls.Add(this.dataLbl);
            this.dataGBox.Controls.Add(this.button1);
            this.dataGBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGBox.Location = new System.Drawing.Point(663, 0);
            this.dataGBox.Name = "dataGBox";
            this.dataGBox.Size = new System.Drawing.Size(180, 451);
            this.dataGBox.TabIndex = 8;
            this.dataGBox.TabStop = false;
            this.dataGBox.Text = "Zarządzaj";
            // 
            // TornadoChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 451);
            this.ControlBox = false;
            this.Controls.Add(this.dataGBox);
            this.Controls.Add(this.chart1);
            this.Name = "TornadoChart";
            this.Text = "Wykres ryzyka";
            this.Resize += new System.EventHandler(this.TornadoChart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.dataGBox.ResumeLayout(false);
            this.dataGBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button copyImgBtn;
        private System.Windows.Forms.Label dataLbl;
        private System.Windows.Forms.ComboBox dataCmb;
        private System.Windows.Forms.Label sortLbl;
        private System.Windows.Forms.ComboBox sortCmb;
        private System.Windows.Forms.GroupBox dataGBox;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}