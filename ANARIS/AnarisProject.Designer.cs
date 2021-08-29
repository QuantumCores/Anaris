namespace ANARIS
{
    partial class AnarisProject
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnarisProject));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lista = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_SaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.loadDBMenu = new System.Windows.Forms.ToolStripButton();
            this.saveDBMenu = new System.Windows.Forms.ToolStripButton();
            this.btn_MergeDB = new System.Windows.Forms.ToolStripButton();
            this.btn_ValueMngr = new System.Windows.Forms.ToolStripButton();
            this.catManBtn = new System.Windows.Forms.ToolStripButton();
            this.btn_PieChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_ScenarioMngr = new System.Windows.Forms.ToolStripButton();
            this.btn_MergeAnalysis = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scenarioComBox = new System.Windows.Forms.ToolStripComboBox();
            this.btn_Tornado = new System.Windows.Forms.ToolStripButton();
            this.thresholdManBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Report = new System.Windows.Forms.ToolStripButton();
            this.btn_ProjectProp = new System.Windows.Forms.ToolStripButton();
            this.rowContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitRowMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.rmvRowMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.rowContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(3, 46);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(967, 342);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(959, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 47;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Item,
            this.Lista,
            this.Number});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(953, 310);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnAdded);
            this.dataGridView1.ColumnHeaderCellChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnHeaderCellChanged);
            this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // Select
            // 
            this.Select.HeaderText = "Zaznacz";
            this.Select.Name = "Select";
            this.Select.Width = 60;
            // 
            // Item
            // 
            this.Item.HeaderText = "Grupa";
            this.Item.Name = "Item";
            this.Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item.Width = 300;
            // 
            // Lista
            // 
            this.Lista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lista.HeaderText = "Wartość";
            this.Lista.Name = "Lista";
            // 
            // Number
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Number.DefaultCellStyle = dataGridViewCellStyle2;
            this.Number.HeaderText = "Liczba";
            this.Number.Name = "Number";
            this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Save,
            this.btn_SaveAs,
            this.toolStripSeparator4,
            this.loadDBMenu,
            this.saveDBMenu,
            this.btn_MergeDB,
            this.btn_ValueMngr,
            this.catManBtn,
            this.btn_PieChart,
            this.toolStripSeparator3,
            this.btn_ScenarioMngr,
            this.btn_MergeAnalysis,
            this.toolStripSeparator2,
            this.scenarioComBox,
            this.btn_Tornado,
            this.thresholdManBtn,
            this.toolStripSeparator1,
            this.btn_Report,
            this.btn_ProjectProp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(972, 43);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(39, 40);
            this.btn_Save.Text = "Zapisz";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btn_SaveAs.Image")));
            this.btn_SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(39, 40);
            this.btn_SaveAs.Text = "Zapisz jako";
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // loadDBMenu
            // 
            this.loadDBMenu.AutoSize = false;
            this.loadDBMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadDBMenu.Image = ((System.Drawing.Image)(resources.GetObject("loadDBMenu.Image")));
            this.loadDBMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadDBMenu.Name = "loadDBMenu";
            this.loadDBMenu.Size = new System.Drawing.Size(40, 40);
            this.loadDBMenu.Text = "Wczytaj bazę danych";
            this.loadDBMenu.Click += new System.EventHandler(this.loadDBMenu_Click);
            // 
            // saveDBMenu
            // 
            this.saveDBMenu.AutoSize = false;
            this.saveDBMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveDBMenu.Image = ((System.Drawing.Image)(resources.GetObject("saveDBMenu.Image")));
            this.saveDBMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveDBMenu.Name = "saveDBMenu";
            this.saveDBMenu.Size = new System.Drawing.Size(40, 40);
            this.saveDBMenu.Text = "Eksportuj bazę danych";
            this.saveDBMenu.Click += new System.EventHandler(this.saveDBMenu_Click);
            // 
            // btn_MergeDB
            // 
            this.btn_MergeDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_MergeDB.Image = ((System.Drawing.Image)(resources.GetObject("btn_MergeDB.Image")));
            this.btn_MergeDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MergeDB.Name = "btn_MergeDB";
            this.btn_MergeDB.Size = new System.Drawing.Size(39, 40);
            this.btn_MergeDB.Text = "Scal bazy danych";
            // 
            // btn_ValueMngr
            // 
            this.btn_ValueMngr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ValueMngr.Image = ((System.Drawing.Image)(resources.GetObject("btn_ValueMngr.Image")));
            this.btn_ValueMngr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ValueMngr.Name = "btn_ValueMngr";
            this.btn_ValueMngr.Size = new System.Drawing.Size(39, 40);
            this.btn_ValueMngr.Text = "Zarządzaj wartościami";
            this.btn_ValueMngr.Click += new System.EventHandler(this.btn_ValueMngr_Click);
            // 
            // catManBtn
            // 
            this.catManBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.catManBtn.Image = ((System.Drawing.Image)(resources.GetObject("catManBtn.Image")));
            this.catManBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.catManBtn.Name = "catManBtn";
            this.catManBtn.Size = new System.Drawing.Size(39, 40);
            this.catManBtn.Text = "Zarządzaj kategoriami";
            this.catManBtn.ToolTipText = "Zarządzaj kategoriami";
            this.catManBtn.Click += new System.EventHandler(this.catManBtn_Click);
            // 
            // btn_PieChart
            // 
            this.btn_PieChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_PieChart.Image = ((System.Drawing.Image)(resources.GetObject("btn_PieChart.Image")));
            this.btn_PieChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_PieChart.Name = "btn_PieChart";
            this.btn_PieChart.Size = new System.Drawing.Size(39, 40);
            this.btn_PieChart.Text = "Diagram kołowy wartości";
            this.btn_PieChart.Click += new System.EventHandler(this.btn_PieChart_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // btn_ScenarioMngr
            // 
            this.btn_ScenarioMngr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ScenarioMngr.Image = ((System.Drawing.Image)(resources.GetObject("btn_ScenarioMngr.Image")));
            this.btn_ScenarioMngr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ScenarioMngr.Name = "btn_ScenarioMngr";
            this.btn_ScenarioMngr.Size = new System.Drawing.Size(39, 40);
            this.btn_ScenarioMngr.Text = "Zarządzaj scenariuszami";
            this.btn_ScenarioMngr.Click += new System.EventHandler(this.btn_ScenarioMngr_Click);
            // 
            // btn_MergeAnalysis
            // 
            this.btn_MergeAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_MergeAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("btn_MergeAnalysis.Image")));
            this.btn_MergeAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MergeAnalysis.Name = "btn_MergeAnalysis";
            this.btn_MergeAnalysis.Size = new System.Drawing.Size(39, 40);
            this.btn_MergeAnalysis.Text = "Scal analizy ryzyka";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // scenarioComBox
            // 
            this.scenarioComBox.Name = "scenarioComBox";
            this.scenarioComBox.Size = new System.Drawing.Size(300, 43);
            this.scenarioComBox.Text = "Scenariusze";
            this.scenarioComBox.SelectedIndexChanged += new System.EventHandler(this.scenarioComBox_SelectedIndexChanged);
            // 
            // btn_Tornado
            // 
            this.btn_Tornado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Tornado.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tornado.Image")));
            this.btn_Tornado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Tornado.Name = "btn_Tornado";
            this.btn_Tornado.Size = new System.Drawing.Size(39, 40);
            this.btn_Tornado.Text = "Wykres ryzyka";
            this.btn_Tornado.ToolTipText = "Wykres ryzyka";
            this.btn_Tornado.Click += new System.EventHandler(this.btn_Tornado_Click);
            // 
            // thresholdManBtn
            // 
            this.thresholdManBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.thresholdManBtn.Image = ((System.Drawing.Image)(resources.GetObject("thresholdManBtn.Image")));
            this.thresholdManBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.thresholdManBtn.Name = "thresholdManBtn";
            this.thresholdManBtn.Size = new System.Drawing.Size(39, 40);
            this.thresholdManBtn.Text = "Tabela niepewności";
            this.thresholdManBtn.ToolTipText = "Tabela niepewności";
            this.thresholdManBtn.Click += new System.EventHandler(this.thresholdManBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // btn_Report
            // 
            this.btn_Report.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Report.Image = ((System.Drawing.Image)(resources.GetObject("btn_Report.Image")));
            this.btn_Report.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(39, 40);
            this.btn_Report.Text = "Generuj raport";
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // btn_ProjectProp
            // 
            this.btn_ProjectProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ProjectProp.Image = ((System.Drawing.Image)(resources.GetObject("btn_ProjectProp.Image")));
            this.btn_ProjectProp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ProjectProp.Name = "btn_ProjectProp";
            this.btn_ProjectProp.Size = new System.Drawing.Size(39, 40);
            this.btn_ProjectProp.Text = "Informacje ogólne";
            this.btn_ProjectProp.Click += new System.EventHandler(this.btn_ProjectProp_Click);
            // 
            // rowContext
            // 
            this.rowContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitRowMnu,
            this.rmvRowMnu});
            this.rowContext.Name = "rowContext";
            this.rowContext.Size = new System.Drawing.Size(148, 48);
            // 
            // splitRowMnu
            // 
            this.splitRowMnu.Name = "splitRowMnu";
            this.splitRowMnu.Size = new System.Drawing.Size(147, 22);
            this.splitRowMnu.Text = "Podziel wiersz";
            this.splitRowMnu.Click += new System.EventHandler(this.splitRowMnu_Click);
            // 
            // rmvRowMnu
            // 
            this.rmvRowMnu.Name = "rmvRowMnu";
            this.rmvRowMnu.Size = new System.Drawing.Size(147, 22);
            this.rmvRowMnu.Text = "Usuń wiersz";
            this.rmvRowMnu.Click += new System.EventHandler(this.rmvRowMnu_Click);
            // 
            // AnarisProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 391);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl);
            this.Name = "AnarisProject";
            this.Text = "Analiza ryzyka";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnarisProject_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.rowContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadDBMenu;
        private System.Windows.Forms.ToolStripButton saveDBMenu;
        private System.Windows.Forms.ToolStripComboBox scenarioComBox;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip rowContext;
        private System.Windows.Forms.ToolStripMenuItem splitRowMnu;
        private System.Windows.Forms.ToolStripMenuItem rmvRowMnu;
        private System.Windows.Forms.ToolStripButton btn_Tornado;
        private System.Windows.Forms.ToolStripButton thresholdManBtn;
        private System.Windows.Forms.ToolStripButton catManBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewComboBoxColumn Lista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.ToolStripButton btn_ValueMngr;
        private System.Windows.Forms.ToolStripButton btn_PieChart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_MergeDB;
        private System.Windows.Forms.ToolStripButton btn_ScenarioMngr;
        private System.Windows.Forms.ToolStripButton btn_MergeAnalysis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Report;
        private System.Windows.Forms.ToolStripButton btn_ProjectProp;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_SaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}