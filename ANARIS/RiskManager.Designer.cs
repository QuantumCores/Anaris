namespace ANARIS
{
    partial class RiskManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiskManager));
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ElemRiskCollection = new System.Windows.Forms.Label();
            this.RiskCollection = new System.Windows.Forms.Label();
            this.opisTxtBox = new System.Windows.Forms.TextBox();
            this.moveUpBtn = new System.Windows.Forms.Button();
            this.moveDownBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addOpisElem = new System.Windows.Forms.Button();
            this.riskComBox = new System.Windows.Forms.ComboBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ALabel = new System.Windows.Forms.Label();
            this.ALowTxt = new System.Windows.Forms.TextBox();
            this.AMidTxt = new System.Windows.Forms.TextBox();
            this.AHighTxt = new System.Windows.Forms.TextBox();
            this.AScoreTxt = new System.Windows.Forms.TextBox();
            this.BScoreTxt = new System.Windows.Forms.TextBox();
            this.BHighTxt = new System.Windows.Forms.TextBox();
            this.BMidTxt = new System.Windows.Forms.TextBox();
            this.BLowTxt = new System.Windows.Forms.TextBox();
            this.BLabel = new System.Windows.Forms.Label();
            this.addScenarioBtn = new System.Windows.Forms.Button();
            this.rmvScenarioBtn = new System.Windows.Forms.Button();
            this.opisATxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.opisBTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.opisCTxtBox = new System.Windows.Forms.TextBox();
            this.CScoreTxt = new System.Windows.Forms.TextBox();
            this.CHighTxt = new System.Windows.Forms.TextBox();
            this.CMidTxt = new System.Windows.Forms.TextBox();
            this.CLowTxt = new System.Windows.Forms.TextBox();
            this.CLabel = new System.Windows.Forms.Label();
            this.CminScoreTxt = new System.Windows.Forms.TextBox();
            this.CmaxScoreTxt = new System.Windows.Forms.TextBox();
            this.BminScoreTxt = new System.Windows.Forms.TextBox();
            this.BmaxScoreTxt = new System.Windows.Forms.TextBox();
            this.AmaxScoreTxt = new System.Windows.Forms.TextBox();
            this.AminScoreTxt = new System.Windows.Forms.TextBox();
            this.RmaxScoreTxt = new System.Windows.Forms.TextBox();
            this.RminScoreTxt = new System.Windows.Forms.TextBox();
            this.RScoreTxt = new System.Windows.Forms.TextBox();
            this.RLabel = new System.Windows.Forms.Label();
            this.RminLabel = new System.Windows.Forms.Label();
            this.RmaxLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 67);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(307, 147);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // ElemRiskCollection
            // 
            this.ElemRiskCollection.AutoSize = true;
            this.ElemRiskCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElemRiskCollection.Location = new System.Drawing.Point(12, 51);
            this.ElemRiskCollection.Name = "ElemRiskCollection";
            this.ElemRiskCollection.Size = new System.Drawing.Size(76, 13);
            this.ElemRiskCollection.TabIndex = 3;
            this.ElemRiskCollection.Text = "Scenariusze";
            // 
            // RiskCollection
            // 
            this.RiskCollection.AutoSize = true;
            this.RiskCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RiskCollection.Location = new System.Drawing.Point(12, 11);
            this.RiskCollection.Name = "RiskCollection";
            this.RiskCollection.Size = new System.Drawing.Size(51, 13);
            this.RiskCollection.TabIndex = 4;
            this.RiskCollection.Text = "Czynnik";
            // 
            // opisTxtBox
            // 
            this.opisTxtBox.Location = new System.Drawing.Point(12, 289);
            this.opisTxtBox.Multiline = true;
            this.opisTxtBox.Name = "opisTxtBox";
            this.opisTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.opisTxtBox.Size = new System.Drawing.Size(360, 238);
            this.opisTxtBox.TabIndex = 5;
            // 
            // moveUpBtn
            // 
            this.moveUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveUpBtn.Location = new System.Drawing.Point(325, 67);
            this.moveUpBtn.Name = "moveUpBtn";
            this.moveUpBtn.Size = new System.Drawing.Size(47, 47);
            this.moveUpBtn.TabIndex = 6;
            this.moveUpBtn.Text = "Do góry";
            this.moveUpBtn.UseVisualStyleBackColor = true;
            this.moveUpBtn.Click += new System.EventHandler(this.moveUpBtn_Click);
            // 
            // moveDownBtn
            // 
            this.moveDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveDownBtn.Location = new System.Drawing.Point(325, 115);
            this.moveDownBtn.Name = "moveDownBtn";
            this.moveDownBtn.Size = new System.Drawing.Size(47, 47);
            this.moveDownBtn.TabIndex = 7;
            this.moveDownBtn.Text = "Do dołu";
            this.moveDownBtn.UseVisualStyleBackColor = true;
            this.moveDownBtn.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(15, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Opis scenariusza";
            // 
            // addOpisElem
            // 
            this.addOpisElem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addOpisElem.Location = new System.Drawing.Point(120, 539);
            this.addOpisElem.Name = "addOpisElem";
            this.addOpisElem.Size = new System.Drawing.Size(138, 24);
            this.addOpisElem.TabIndex = 9;
            this.addOpisElem.Text = "Uaktualnij scenariusz";
            this.addOpisElem.UseVisualStyleBackColor = true;
            this.addOpisElem.Click += new System.EventHandler(this.addOpisElem_Click);
            // 
            // riskComBox
            // 
            this.riskComBox.FormattingEnabled = true;
            this.riskComBox.Location = new System.Drawing.Point(12, 27);
            this.riskComBox.Name = "riskComBox";
            this.riskComBox.Size = new System.Drawing.Size(307, 21);
            this.riskComBox.TabIndex = 10;
            this.riskComBox.SelectedIndexChanged += new System.EventHandler(this.riskComBox_SelectedIndexChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 248);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(307, 20);
            this.nameBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(15, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nazwa scenariusza";
            // 
            // ALabel
            // 
            this.ALabel.AutoSize = true;
            this.ALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ALabel.Location = new System.Drawing.Point(411, 50);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(19, 13);
            this.ALabel.TabIndex = 13;
            this.ALabel.Text = "A:";
            // 
            // ALowTxt
            // 
            this.ALowTxt.Location = new System.Drawing.Point(436, 47);
            this.ALowTxt.Name = "ALowTxt";
            this.ALowTxt.Size = new System.Drawing.Size(45, 20);
            this.ALowTxt.TabIndex = 14;
            this.ALowTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ALowTxt.TextChanged += new System.EventHandler(this.ALowTxt_TextChanged);
            this.ALowTxt.Leave += new System.EventHandler(this.ALowTxt_Leave);
            // 
            // AMidTxt
            // 
            this.AMidTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AMidTxt.Location = new System.Drawing.Point(552, 45);
            this.AMidTxt.Name = "AMidTxt";
            this.AMidTxt.Size = new System.Drawing.Size(45, 22);
            this.AMidTxt.TabIndex = 15;
            this.AMidTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AMidTxt.TextChanged += new System.EventHandler(this.AMidTxt_TextChanged);
            this.AMidTxt.Leave += new System.EventHandler(this.AMidTxt_Leave);
            // 
            // AHighTxt
            // 
            this.AHighTxt.Location = new System.Drawing.Point(669, 47);
            this.AHighTxt.Name = "AHighTxt";
            this.AHighTxt.Size = new System.Drawing.Size(45, 20);
            this.AHighTxt.TabIndex = 16;
            this.AHighTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AHighTxt.TextChanged += new System.EventHandler(this.AHighTxt_TextChanged);
            this.AHighTxt.Leave += new System.EventHandler(this.AHighTxt_Leave);
            // 
            // AScoreTxt
            // 
            this.AScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AScoreTxt.Location = new System.Drawing.Point(603, 45);
            this.AScoreTxt.Name = "AScoreTxt";
            this.AScoreTxt.ReadOnly = true;
            this.AScoreTxt.Size = new System.Drawing.Size(45, 22);
            this.AScoreTxt.TabIndex = 17;
            this.AScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BScoreTxt
            // 
            this.BScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BScoreTxt.Location = new System.Drawing.Point(603, 199);
            this.BScoreTxt.Name = "BScoreTxt";
            this.BScoreTxt.ReadOnly = true;
            this.BScoreTxt.Size = new System.Drawing.Size(45, 22);
            this.BScoreTxt.TabIndex = 23;
            this.BScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BHighTxt
            // 
            this.BHighTxt.Location = new System.Drawing.Point(669, 201);
            this.BHighTxt.Name = "BHighTxt";
            this.BHighTxt.Size = new System.Drawing.Size(45, 20);
            this.BHighTxt.TabIndex = 22;
            this.BHighTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BHighTxt.TextChanged += new System.EventHandler(this.BHighTxt_TextChanged);
            this.BHighTxt.Leave += new System.EventHandler(this.BHighTxt_Leave);
            // 
            // BMidTxt
            // 
            this.BMidTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BMidTxt.Location = new System.Drawing.Point(552, 199);
            this.BMidTxt.Name = "BMidTxt";
            this.BMidTxt.Size = new System.Drawing.Size(45, 22);
            this.BMidTxt.TabIndex = 21;
            this.BMidTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BMidTxt.TextChanged += new System.EventHandler(this.BMidTxt_TextChanged);
            this.BMidTxt.Leave += new System.EventHandler(this.BMidTxt_Leave);
            // 
            // BLowTxt
            // 
            this.BLowTxt.Location = new System.Drawing.Point(436, 201);
            this.BLowTxt.Name = "BLowTxt";
            this.BLowTxt.Size = new System.Drawing.Size(45, 20);
            this.BLowTxt.TabIndex = 20;
            this.BLowTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BLowTxt.TextChanged += new System.EventHandler(this.BLowTxt_TextChanged);
            this.BLowTxt.Leave += new System.EventHandler(this.BLowTxt_Leave);
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BLabel.Location = new System.Drawing.Point(411, 204);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(19, 13);
            this.BLabel.TabIndex = 19;
            this.BLabel.Text = "B:";
            // 
            // addScenarioBtn
            // 
            this.addScenarioBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.addScenarioBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addScenarioBtn.Location = new System.Drawing.Point(264, 539);
            this.addScenarioBtn.Name = "addScenarioBtn";
            this.addScenarioBtn.Size = new System.Drawing.Size(108, 24);
            this.addScenarioBtn.TabIndex = 25;
            this.addScenarioBtn.Text = "Dodaj scenariusz";
            this.addScenarioBtn.UseVisualStyleBackColor = false;
            this.addScenarioBtn.Click += new System.EventHandler(this.addScenarioBtn_Click);
            // 
            // rmvScenarioBtn
            // 
            this.rmvScenarioBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rmvScenarioBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rmvScenarioBtn.Location = new System.Drawing.Point(12, 539);
            this.rmvScenarioBtn.Name = "rmvScenarioBtn";
            this.rmvScenarioBtn.Size = new System.Drawing.Size(102, 24);
            this.rmvScenarioBtn.TabIndex = 26;
            this.rmvScenarioBtn.Text = "Usuń scenariusz";
            this.rmvScenarioBtn.UseVisualStyleBackColor = false;
            this.rmvScenarioBtn.Click += new System.EventHandler(this.rmvScenarioBtn_Click);
            // 
            // opisATxtBox
            // 
            this.opisATxtBox.Location = new System.Drawing.Point(411, 92);
            this.opisATxtBox.Multiline = true;
            this.opisATxtBox.Name = "opisATxtBox";
            this.opisATxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.opisATxtBox.Size = new System.Drawing.Size(360, 90);
            this.opisATxtBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(414, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Opis składowej A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(414, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Opis składowej B";
            // 
            // opisBTxtBox
            // 
            this.opisBTxtBox.Location = new System.Drawing.Point(411, 246);
            this.opisBTxtBox.Multiline = true;
            this.opisBTxtBox.Name = "opisBTxtBox";
            this.opisBTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.opisBTxtBox.Size = new System.Drawing.Size(360, 90);
            this.opisBTxtBox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(414, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Opis składowej C";
            // 
            // opisCTxtBox
            // 
            this.opisCTxtBox.Location = new System.Drawing.Point(411, 402);
            this.opisCTxtBox.Multiline = true;
            this.opisCTxtBox.Name = "opisCTxtBox";
            this.opisCTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.opisCTxtBox.Size = new System.Drawing.Size(360, 116);
            this.opisCTxtBox.TabIndex = 37;
            // 
            // CScoreTxt
            // 
            this.CScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CScoreTxt.Location = new System.Drawing.Point(603, 355);
            this.CScoreTxt.Name = "CScoreTxt";
            this.CScoreTxt.ReadOnly = true;
            this.CScoreTxt.Size = new System.Drawing.Size(45, 22);
            this.CScoreTxt.TabIndex = 35;
            this.CScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CHighTxt
            // 
            this.CHighTxt.Location = new System.Drawing.Point(669, 357);
            this.CHighTxt.Name = "CHighTxt";
            this.CHighTxt.ReadOnly = true;
            this.CHighTxt.Size = new System.Drawing.Size(45, 20);
            this.CHighTxt.TabIndex = 34;
            this.CHighTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CMidTxt
            // 
            this.CMidTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CMidTxt.Location = new System.Drawing.Point(552, 355);
            this.CMidTxt.Name = "CMidTxt";
            this.CMidTxt.ReadOnly = true;
            this.CMidTxt.Size = new System.Drawing.Size(45, 22);
            this.CMidTxt.TabIndex = 33;
            this.CMidTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CLowTxt
            // 
            this.CLowTxt.Location = new System.Drawing.Point(436, 357);
            this.CLowTxt.Name = "CLowTxt";
            this.CLowTxt.ReadOnly = true;
            this.CLowTxt.Size = new System.Drawing.Size(45, 20);
            this.CLowTxt.TabIndex = 32;
            this.CLowTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CLabel.Location = new System.Drawing.Point(411, 360);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(19, 13);
            this.CLabel.TabIndex = 31;
            this.CLabel.Text = "C:";
            // 
            // CminScoreTxt
            // 
            this.CminScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CminScoreTxt.Location = new System.Drawing.Point(487, 357);
            this.CminScoreTxt.Name = "CminScoreTxt";
            this.CminScoreTxt.ReadOnly = true;
            this.CminScoreTxt.Size = new System.Drawing.Size(45, 20);
            this.CminScoreTxt.TabIndex = 39;
            this.CminScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CmaxScoreTxt
            // 
            this.CmaxScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CmaxScoreTxt.Location = new System.Drawing.Point(720, 357);
            this.CmaxScoreTxt.Name = "CmaxScoreTxt";
            this.CmaxScoreTxt.ReadOnly = true;
            this.CmaxScoreTxt.Size = new System.Drawing.Size(45, 20);
            this.CmaxScoreTxt.TabIndex = 40;
            this.CmaxScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BminScoreTxt
            // 
            this.BminScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BminScoreTxt.Location = new System.Drawing.Point(487, 201);
            this.BminScoreTxt.Name = "BminScoreTxt";
            this.BminScoreTxt.ReadOnly = true;
            this.BminScoreTxt.Size = new System.Drawing.Size(45, 20);
            this.BminScoreTxt.TabIndex = 41;
            this.BminScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BmaxScoreTxt
            // 
            this.BmaxScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BmaxScoreTxt.Location = new System.Drawing.Point(720, 201);
            this.BmaxScoreTxt.Name = "BmaxScoreTxt";
            this.BmaxScoreTxt.ReadOnly = true;
            this.BmaxScoreTxt.Size = new System.Drawing.Size(45, 20);
            this.BmaxScoreTxt.TabIndex = 42;
            this.BmaxScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AmaxScoreTxt
            // 
            this.AmaxScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AmaxScoreTxt.Location = new System.Drawing.Point(720, 47);
            this.AmaxScoreTxt.Name = "AmaxScoreTxt";
            this.AmaxScoreTxt.ReadOnly = true;
            this.AmaxScoreTxt.Size = new System.Drawing.Size(45, 20);
            this.AmaxScoreTxt.TabIndex = 43;
            this.AmaxScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AminScoreTxt
            // 
            this.AminScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AminScoreTxt.Location = new System.Drawing.Point(487, 47);
            this.AminScoreTxt.Name = "AminScoreTxt";
            this.AminScoreTxt.ReadOnly = true;
            this.AminScoreTxt.Size = new System.Drawing.Size(45, 20);
            this.AminScoreTxt.TabIndex = 44;
            this.AminScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RmaxScoreTxt
            // 
            this.RmaxScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RmaxScoreTxt.Location = new System.Drawing.Point(654, 543);
            this.RmaxScoreTxt.Name = "RmaxScoreTxt";
            this.RmaxScoreTxt.ReadOnly = true;
            this.RmaxScoreTxt.Size = new System.Drawing.Size(96, 20);
            this.RmaxScoreTxt.TabIndex = 51;
            this.RmaxScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RminScoreTxt
            // 
            this.RminScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RminScoreTxt.Location = new System.Drawing.Point(424, 543);
            this.RminScoreTxt.Name = "RminScoreTxt";
            this.RminScoreTxt.ReadOnly = true;
            this.RminScoreTxt.Size = new System.Drawing.Size(96, 20);
            this.RminScoreTxt.TabIndex = 50;
            this.RminScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RScoreTxt
            // 
            this.RScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RScoreTxt.Location = new System.Drawing.Point(539, 541);
            this.RScoreTxt.Name = "RScoreTxt";
            this.RScoreTxt.ReadOnly = true;
            this.RScoreTxt.Size = new System.Drawing.Size(96, 22);
            this.RScoreTxt.TabIndex = 49;
            this.RScoreTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RLabel
            // 
            this.RLabel.AutoSize = true;
            this.RLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RLabel.Location = new System.Drawing.Point(536, 525);
            this.RLabel.Name = "RLabel";
            this.RLabel.Size = new System.Drawing.Size(28, 13);
            this.RLabel.TabIndex = 45;
            this.RLabel.Text = "WR";
            // 
            // RminLabel
            // 
            this.RminLabel.AutoSize = true;
            this.RminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RminLabel.Location = new System.Drawing.Point(421, 525);
            this.RminLabel.Name = "RminLabel";
            this.RminLabel.Size = new System.Drawing.Size(51, 13);
            this.RminLabel.TabIndex = 52;
            this.RminLabel.Text = "WR min";
            // 
            // RmaxLabel
            // 
            this.RmaxLabel.AutoSize = true;
            this.RmaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RmaxLabel.Location = new System.Drawing.Point(651, 525);
            this.RmaxLabel.Name = "RmaxLabel";
            this.RmaxLabel.Size = new System.Drawing.Size(54, 13);
            this.RmaxLabel.TabIndex = 53;
            this.RmaxLabel.Text = "WR max";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(751, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 54;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RiskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 575);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RmaxLabel);
            this.Controls.Add(this.RminLabel);
            this.Controls.Add(this.RmaxScoreTxt);
            this.Controls.Add(this.RminScoreTxt);
            this.Controls.Add(this.RScoreTxt);
            this.Controls.Add(this.RLabel);
            this.Controls.Add(this.AminScoreTxt);
            this.Controls.Add(this.AmaxScoreTxt);
            this.Controls.Add(this.BmaxScoreTxt);
            this.Controls.Add(this.BminScoreTxt);
            this.Controls.Add(this.CmaxScoreTxt);
            this.Controls.Add(this.CminScoreTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.opisCTxtBox);
            this.Controls.Add(this.CScoreTxt);
            this.Controls.Add(this.CHighTxt);
            this.Controls.Add(this.CMidTxt);
            this.Controls.Add(this.CLowTxt);
            this.Controls.Add(this.CLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.opisBTxtBox);
            this.Controls.Add(this.AMidTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rmvScenarioBtn);
            this.Controls.Add(this.ALabel);
            this.Controls.Add(this.addScenarioBtn);
            this.Controls.Add(this.opisATxtBox);
            this.Controls.Add(this.ALowTxt);
            this.Controls.Add(this.AHighTxt);
            this.Controls.Add(this.BScoreTxt);
            this.Controls.Add(this.AScoreTxt);
            this.Controls.Add(this.BHighTxt);
            this.Controls.Add(this.BMidTxt);
            this.Controls.Add(this.BLowTxt);
            this.Controls.Add(this.BLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.riskComBox);
            this.Controls.Add(this.addOpisElem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveDownBtn);
            this.Controls.Add(this.moveUpBtn);
            this.Controls.Add(this.opisTxtBox);
            this.Controls.Add(this.RiskCollection);
            this.Controls.Add(this.ElemRiskCollection);
            this.Controls.Add(this.listBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "RiskManager";
            this.Text = "Zarządzaj scenariuszami";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label ElemRiskCollection;
        private System.Windows.Forms.Label RiskCollection;
        private System.Windows.Forms.TextBox opisTxtBox;
        private System.Windows.Forms.Button moveUpBtn;
        private System.Windows.Forms.Button moveDownBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addOpisElem;
        private System.Windows.Forms.ComboBox riskComBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.TextBox ALowTxt;
        private System.Windows.Forms.TextBox AMidTxt;
        private System.Windows.Forms.TextBox AHighTxt;
        private System.Windows.Forms.TextBox AScoreTxt;
        private System.Windows.Forms.TextBox BScoreTxt;
        private System.Windows.Forms.TextBox BHighTxt;
        private System.Windows.Forms.TextBox BMidTxt;
        private System.Windows.Forms.TextBox BLowTxt;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.Button addScenarioBtn;
        private System.Windows.Forms.Button rmvScenarioBtn;
        private System.Windows.Forms.TextBox opisATxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox opisBTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox opisCTxtBox;
        private System.Windows.Forms.TextBox CScoreTxt;
        private System.Windows.Forms.TextBox CHighTxt;
        private System.Windows.Forms.TextBox CMidTxt;
        private System.Windows.Forms.TextBox CLowTxt;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.TextBox CminScoreTxt;
        private System.Windows.Forms.TextBox CmaxScoreTxt;
        private System.Windows.Forms.TextBox BminScoreTxt;
        private System.Windows.Forms.TextBox BmaxScoreTxt;
        private System.Windows.Forms.TextBox AmaxScoreTxt;
        private System.Windows.Forms.TextBox AminScoreTxt;
        private System.Windows.Forms.TextBox RmaxScoreTxt;
        private System.Windows.Forms.TextBox RminScoreTxt;
        private System.Windows.Forms.TextBox RScoreTxt;
        private System.Windows.Forms.Label RLabel;
        private System.Windows.Forms.Label RminLabel;
        private System.Windows.Forms.Label RmaxLabel;
        private System.Windows.Forms.Button button1;
    }
}