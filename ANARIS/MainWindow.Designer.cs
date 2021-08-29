namespace ANARIS
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newDBmnu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newRAmnu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenAR = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valueTableMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryTableMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.ValuePieChartBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_exportDB = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_mergeDB = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riskTableMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMergeAR = new System.Windows.Forms.ToolStripMenuItem();
            this.ewaluacjaRyzykaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tornadoChartBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTabNiepewnosci = new System.Windows.Forms.ToolStripMenuItem();
            this.raportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesARMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportFormBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_generateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.ewaluacjaRyzykaToolStripMenuItem,
            this.raportToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDBmnu,
            this.mnuOpen,
            this.mnuSave,
            this.toolStripSeparator1,
            this.newRAmnu,
            this.mnuOpenAR,
            this.mnuSaveAR,
            this.toolStripMenuItem2,
            this.mnuQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(38, 20);
            this.mnuFile.Text = "&Plik";
            // 
            // newDBmnu
            // 
            this.newDBmnu.Name = "newDBmnu";
            this.newDBmnu.Size = new System.Drawing.Size(232, 22);
            this.newDBmnu.Text = "Nowa Baza danych";
            this.newDBmnu.Click += new System.EventHandler(this.newDBmnu_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(232, 22);
            this.mnuOpen.Text = "&Otwórz Bazę danych";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(232, 22);
            this.mnuSave.Text = "&Zapisz Bazę danych";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // newRAmnu
            // 
            this.newRAmnu.Name = "newRAmnu";
            this.newRAmnu.Size = new System.Drawing.Size(232, 22);
            this.newRAmnu.Text = "Nowa Analiza ryzyka";
            this.newRAmnu.Click += new System.EventHandler(this.newRAmnu_Click);
            // 
            // mnuOpenAR
            // 
            this.mnuOpenAR.Name = "mnuOpenAR";
            this.mnuOpenAR.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenAR.Size = new System.Drawing.Size(232, 22);
            this.mnuOpenAR.Text = "Otwórz Analizę ryzyka";
            this.mnuOpenAR.Click += new System.EventHandler(this.mnuOpenAR_Click);
            // 
            // mnuSaveAR
            // 
            this.mnuSaveAR.Name = "mnuSaveAR";
            this.mnuSaveAR.Size = new System.Drawing.Size(232, 22);
            this.mnuSaveAR.Text = "Zapisz Analizę ryzyka";
            this.mnuSaveAR.Click += new System.EventHandler(this.mnuSaveAR_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.mnuQuit.Size = new System.Drawing.Size(232, 22);
            this.mnuQuit.Text = "&Wyjdź";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUndo,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.editToolStripMenuItem.Text = "Edycja";
            this.editToolStripMenuItem.Visible = false;
            // 
            // mnuUndo
            // 
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(144, 22);
            this.mnuUndo.Text = "&Undo";
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCut.Size = new System.Drawing.Size(144, 22);
            this.mnuCut.Text = "Cu&t";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(144, 22);
            this.mnuCopy.Text = "&Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuPaste.Size = new System.Drawing.Size(144, 22);
            this.mnuPaste.Text = "&Paste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valueTableMnu,
            this.categoryTableMnu,
            this.ValuePieChartBtn,
            this.btn_exportDB,
            this.btn_mergeDB});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.projectToolStripMenuItem.Text = "&Baza Danych";
            // 
            // valueTableMnu
            // 
            this.valueTableMnu.Name = "valueTableMnu";
            this.valueTableMnu.Size = new System.Drawing.Size(207, 22);
            this.valueTableMnu.Text = "Zarządzaj wartościami";
            this.valueTableMnu.Click += new System.EventHandler(this.valueTableMnu_Click);
            // 
            // categoryTableMnu
            // 
            this.categoryTableMnu.Name = "categoryTableMnu";
            this.categoryTableMnu.Size = new System.Drawing.Size(207, 22);
            this.categoryTableMnu.Text = "Zarządzaj kategoriami";
            this.categoryTableMnu.Click += new System.EventHandler(this.categoryTableMnu_Click);
            // 
            // ValuePieChartBtn
            // 
            this.ValuePieChartBtn.Name = "ValuePieChartBtn";
            this.ValuePieChartBtn.Size = new System.Drawing.Size(207, 22);
            this.ValuePieChartBtn.Text = "Diagram kołowy wartości";
            this.ValuePieChartBtn.Click += new System.EventHandler(this.ValuePieChartBtn_Click);
            // 
            // btn_exportDB
            // 
            this.btn_exportDB.Name = "btn_exportDB";
            this.btn_exportDB.Size = new System.Drawing.Size(207, 22);
            this.btn_exportDB.Text = "Eksportuj bazę danych";
            this.btn_exportDB.Click += new System.EventHandler(this.btn_exportDB_Click);
            // 
            // btn_mergeDB
            // 
            this.btn_mergeDB.Name = "btn_mergeDB";
            this.btn_mergeDB.Size = new System.Drawing.Size(207, 22);
            this.btn_mergeDB.Text = "Scal bazy danych";
            this.btn_mergeDB.Click += new System.EventHandler(this.btn_mergeDB_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.riskTableMnu,
            this.btnMergeAR});
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.categoriesToolStripMenuItem.Text = "&Analiza Ryzyka";
            // 
            // riskTableMnu
            // 
            this.riskTableMnu.Name = "riskTableMnu";
            this.riskTableMnu.Size = new System.Drawing.Size(200, 22);
            this.riskTableMnu.Text = "Zarządzaj scenariuszami";
            this.riskTableMnu.Click += new System.EventHandler(this.riskTableMnu_Click);
            // 
            // btnMergeAR
            // 
            this.btnMergeAR.Name = "btnMergeAR";
            this.btnMergeAR.Size = new System.Drawing.Size(200, 22);
            this.btnMergeAR.Text = "Scal analizy ryzyka";
            this.btnMergeAR.Click += new System.EventHandler(this.btnMergeAR_Click);
            // 
            // ewaluacjaRyzykaToolStripMenuItem
            // 
            this.ewaluacjaRyzykaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tornadoChartBtn,
            this.btnTabNiepewnosci});
            this.ewaluacjaRyzykaToolStripMenuItem.Name = "ewaluacjaRyzykaToolStripMenuItem";
            this.ewaluacjaRyzykaToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.ewaluacjaRyzykaToolStripMenuItem.Text = "Ewaluacja Ryzyka";
            // 
            // tornadoChartBtn
            // 
            this.tornadoChartBtn.Name = "tornadoChartBtn";
            this.tornadoChartBtn.Size = new System.Drawing.Size(178, 22);
            this.tornadoChartBtn.Text = "Wykres ryzyka";
            this.tornadoChartBtn.Click += new System.EventHandler(this.tornadoChartBtn_Click);
            // 
            // btnTabNiepewnosci
            // 
            this.btnTabNiepewnosci.Name = "btnTabNiepewnosci";
            this.btnTabNiepewnosci.Size = new System.Drawing.Size(178, 22);
            this.btnTabNiepewnosci.Text = "Tabela niepewności";
            this.btnTabNiepewnosci.Click += new System.EventHandler(this.wykresNiepewnościToolStripMenuItem_Click);
            // 
            // raportToolStripMenuItem
            // 
            this.raportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesARMnu,
            this.reportFormBtn,
            this.btn_generateReport});
            this.raportToolStripMenuItem.Name = "raportToolStripMenuItem";
            this.raportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.raportToolStripMenuItem.Text = "Raport";
            // 
            // propertiesARMnu
            // 
            this.propertiesARMnu.Name = "propertiesARMnu";
            this.propertiesARMnu.Size = new System.Drawing.Size(173, 22);
            this.propertiesARMnu.Text = "Informacje ogólne";
            this.propertiesARMnu.Click += new System.EventHandler(this.propertiesARMnu_Click);
            // 
            // reportFormBtn
            // 
            this.reportFormBtn.Name = "reportFormBtn";
            this.reportFormBtn.Size = new System.Drawing.Size(173, 22);
            this.reportFormBtn.Text = "Ustawienia raportu";
            this.reportFormBtn.Click += new System.EventHandler(this.reportFormBtn_Click);
            // 
            // btn_generateReport
            // 
            this.btn_generateReport.Name = "btn_generateReport";
            this.btn_generateReport.Size = new System.Drawing.Size(173, 22);
            this.btn_generateReport.Text = "Generuj raport";
            this.btn_generateReport.Click += new System.EventHandler(this.generujRaportToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUserInstruction});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // btnUserInstruction
            // 
            this.btnUserInstruction.Name = "btnUserInstruction";
            this.btnUserInstruction.Size = new System.Drawing.Size(194, 22);
            this.btnUserInstruction.Text = "Instrukcja użytkownika";
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(639, 361);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "AnaRis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenAR;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAR;
        internal System.Windows.Forms.ToolStripMenuItem btnTabNiepewnosci;
        internal System.Windows.Forms.ToolStripMenuItem propertiesARMnu;
        internal System.Windows.Forms.ToolStripMenuItem reportFormBtn;
        internal System.Windows.Forms.ToolStripMenuItem tornadoChartBtn;
        //internal System.Windows.Forms.ToolStripMenuItem ValuePieChartBtnO;
        internal System.Windows.Forms.ToolStripMenuItem riskTableMnu;
        internal System.Windows.Forms.ToolStripMenuItem valueTableMnu;
        internal System.Windows.Forms.ToolStripMenuItem categoryTableMnu;
        private System.Windows.Forms.ToolStripMenuItem btn_exportDB;
        private System.Windows.Forms.ToolStripMenuItem btn_mergeDB;
        private System.Windows.Forms.ToolStripMenuItem btnMergeAR;
        public System.Windows.Forms.ToolStripMenuItem ValuePieChartBtn;
        private System.Windows.Forms.ToolStripMenuItem newDBmnu;
        private System.Windows.Forms.ToolStripMenuItem newRAmnu;
        private System.Windows.Forms.ToolStripMenuItem raportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btn_generateReport;
        private System.Windows.Forms.ToolStripMenuItem ewaluacjaRyzykaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnUserInstruction;
    }
}

