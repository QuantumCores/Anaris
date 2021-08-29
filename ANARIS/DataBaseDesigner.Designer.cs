namespace ANARIS
{
    partial class DataBaseDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseDesigner));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dBToolStrip = new System.Windows.Forms.ToolStrip();
            this.btn_Export = new System.Windows.Forms.ToolStripButton();
            this.btn_MergeDB = new System.Windows.Forms.ToolStripButton();
            this.btn_ValueMngr = new System.Windows.Forms.ToolStripButton();
            this.catManBtn = new System.Windows.Forms.ToolStripButton();
            this.btn_PieChart = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lista = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_SaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dBToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dBToolStrip
            // 
            this.dBToolStrip.AutoSize = false;
            this.dBToolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.dBToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Save,
            this.btn_SaveAs,
            this.toolStripSeparator1,
            this.btn_Export,
            this.btn_MergeDB,
            this.btn_ValueMngr,
            this.catManBtn,
            this.btn_PieChart});
            this.dBToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.dBToolStrip.Location = new System.Drawing.Point(0, 0);
            this.dBToolStrip.Name = "dBToolStrip";
            this.dBToolStrip.Size = new System.Drawing.Size(892, 43);
            this.dBToolStrip.TabIndex = 0;
            this.dBToolStrip.Text = "toolStrip1";
            // 
            // btn_Export
            // 
            this.btn_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Export.Image = ((System.Drawing.Image)(resources.GetObject("btn_Export.Image")));
            this.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(44, 40);
            this.btn_Export.Text = "Eksportuj bazę danych";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_MergeDB
            // 
            this.btn_MergeDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_MergeDB.Image = ((System.Drawing.Image)(resources.GetObject("btn_MergeDB.Image")));
            this.btn_MergeDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MergeDB.Name = "btn_MergeDB";
            this.btn_MergeDB.Size = new System.Drawing.Size(44, 40);
            this.btn_MergeDB.Text = "Scal bazy danych";
            // 
            // btn_ValueMngr
            // 
            this.btn_ValueMngr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ValueMngr.Image = ((System.Drawing.Image)(resources.GetObject("btn_ValueMngr.Image")));
            this.btn_ValueMngr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ValueMngr.Name = "btn_ValueMngr";
            this.btn_ValueMngr.Size = new System.Drawing.Size(44, 40);
            this.btn_ValueMngr.Text = "Zarządzaj wartościami";
            this.btn_ValueMngr.Click += new System.EventHandler(this.btn_ValueMngr_Click);
            // 
            // catManBtn
            // 
            this.catManBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.catManBtn.Image = ((System.Drawing.Image)(resources.GetObject("catManBtn.Image")));
            this.catManBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.catManBtn.Name = "catManBtn";
            this.catManBtn.Size = new System.Drawing.Size(44, 40);
            this.catManBtn.Text = "Zarządzaj kategoriami";
            this.catManBtn.Click += new System.EventHandler(this.catManBtn_Click);
            // 
            // btn_PieChart
            // 
            this.btn_PieChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_PieChart.Image = ((System.Drawing.Image)(resources.GetObject("btn_PieChart.Image")));
            this.btn_PieChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_PieChart.Name = "btn_PieChart";
            this.btn_PieChart.Size = new System.Drawing.Size(44, 40);
            this.btn_PieChart.Text = "Diagram kołowy wartości";
            this.btn_PieChart.Click += new System.EventHandler(this.btn_PieChart_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(892, 229);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Tag = "DB";
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnAdded);
            this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // Select
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle22.NullValue = false;
            this.Select.DefaultCellStyle = dataGridViewCellStyle22;
            this.Select.DividerWidth = 1;
            this.Select.Frozen = true;
            this.Select.HeaderText = "Zaznacz";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Select.Width = 60;
            // 
            // Item
            // 
            this.Item.HeaderText = "Grupa podstawowa";
            this.Item.Name = "Item";
            this.Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item.Width = 300;
            // 
            // Lista
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lista.DefaultCellStyle = dataGridViewCellStyle23;
            this.Lista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lista.HeaderText = "Wartość";
            this.Lista.Name = "Lista";
            this.Lista.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Number
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = null;
            this.Number.DefaultCellStyle = dataGridViewCellStyle24;
            this.Number.HeaderText = "Liczba";
            this.Number.Name = "Number";
            this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Number.Width = 60;
            // 
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(44, 40);
            this.btn_Save.Text = "Zapisz";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btn_SaveAs.Image")));
            this.btn_SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(44, 40);
            this.btn_SaveAs.Text = "Zapisz jako";
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // DataBaseDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 272);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dBToolStrip);
            this.Name = "DataBaseDesigner";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Baza danych Anaris";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataBaseDesigner_FormClosed);
            this.dBToolStrip.ResumeLayout(false);
            this.dBToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip dBToolStrip;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewComboBoxColumn Lista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.ToolStripButton btn_Export;
        private System.Windows.Forms.ToolStripButton btn_MergeDB;
        private System.Windows.Forms.ToolStripButton btn_ValueMngr;
        private System.Windows.Forms.ToolStripButton catManBtn;
        private System.Windows.Forms.ToolStripButton btn_PieChart;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_SaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}