namespace ANARIS
{
    partial class CategoryTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryTree));
            this.catTreeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.addNodeBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chngNameBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.discardBtn = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // catTreeView
            // 
            this.catTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.catTreeView.CausesValidation = false;
            this.catTreeView.HideSelection = false;
            this.catTreeView.Location = new System.Drawing.Point(12, 86);
            this.catTreeView.Name = "catTreeView";
            this.catTreeView.ShowNodeToolTips = true;
            this.catTreeView.Size = new System.Drawing.Size(267, 222);
            this.catTreeView.TabIndex = 0;
            this.catTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.catTreeView_NodeMouseClick);
            this.catTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.catTreeView_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Usuń";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addNodeBtn
            // 
            this.addNodeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.addNodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNodeBtn.Location = new System.Drawing.Point(204, 57);
            this.addNodeBtn.Name = "addNodeBtn";
            this.addNodeBtn.Size = new System.Drawing.Size(75, 23);
            this.addNodeBtn.TabIndex = 2;
            this.addNodeBtn.Text = "Dodaj";
            this.addNodeBtn.UseVisualStyleBackColor = false;
            this.addNodeBtn.Click += new System.EventHandler(this.addNodeBtn_Click);
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameBox.Location = new System.Drawing.Point(12, 31);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(267, 20);
            this.nameBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nazwa";
            // 
            // chngNameBtn
            // 
            this.chngNameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chngNameBtn.Location = new System.Drawing.Point(85, 57);
            this.chngNameBtn.Name = "chngNameBtn";
            this.chngNameBtn.Size = new System.Drawing.Size(113, 23);
            this.chngNameBtn.TabIndex = 6;
            this.chngNameBtn.Text = "Zmień nazwę";
            this.chngNameBtn.UseVisualStyleBackColor = true;
            this.chngNameBtn.Click += new System.EventHandler(this.chngNameBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.applyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyBtn.Location = new System.Drawing.Point(171, 314);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(108, 23);
            this.applyBtn.TabIndex = 7;
            this.applyBtn.Text = "Zastosuj zmiany";
            this.applyBtn.UseVisualStyleBackColor = false;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // discardBtn
            // 
            this.discardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.discardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discardBtn.Location = new System.Drawing.Point(12, 314);
            this.discardBtn.Name = "discardBtn";
            this.discardBtn.Size = new System.Drawing.Size(108, 23);
            this.discardBtn.TabIndex = 8;
            this.discardBtn.Text = "Cofnij zmiany";
            this.discardBtn.UseVisualStyleBackColor = false;
            this.discardBtn.Click += new System.EventHandler(this.discardBtn_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(297, 57);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(274, 280);
            this.txtDescription.TabIndex = 9;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(301, 38);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(85, 13);
            this.lblDesc.TabIndex = 10;
            this.lblDesc.Text = "Opis kategorii";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(556, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 20;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CategoryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 364);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.discardBtn);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.chngNameBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.addNodeBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.catTreeView);
            this.Name = "CategoryTree";
            this.Text = "Zarządzaj kategoriami";
            this.Load += new System.EventHandler(this.CategoryTree_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addNodeBtn;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chngNameBtn;
        public System.Windows.Forms.TreeView catTreeView;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button discardBtn;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button button2;
    }
}