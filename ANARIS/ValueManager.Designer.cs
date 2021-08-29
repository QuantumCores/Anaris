namespace ANARIS
{
    partial class ValueManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValueManager));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.applyBtn = new System.Windows.Forms.Button();
            this.txtDescAll = new System.Windows.Forms.TextBox();
            this.txtDescSingle = new System.Windows.Forms.TextBox();
            this.lblDescAll = new System.Windows.Forms.Label();
            this.lbl_descSingle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lst_Values = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_rmv = new System.Windows.Forms.Button();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nazwa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(167, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Wartość :";
            // 
            // applyBtn
            // 
            this.applyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.applyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyBtn.Location = new System.Drawing.Point(495, 381);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 24;
            this.applyBtn.Text = "Zastosuj";
            this.applyBtn.UseVisualStyleBackColor = false;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // txtDescAll
            // 
            this.txtDescAll.Location = new System.Drawing.Point(332, 34);
            this.txtDescAll.Multiline = true;
            this.txtDescAll.Name = "txtDescAll";
            this.txtDescAll.Size = new System.Drawing.Size(238, 341);
            this.txtDescAll.TabIndex = 34;
            // 
            // txtDescSingle
            // 
            this.txtDescSingle.Location = new System.Drawing.Point(12, 237);
            this.txtDescSingle.Multiline = true;
            this.txtDescSingle.Name = "txtDescSingle";
            this.txtDescSingle.Size = new System.Drawing.Size(314, 112);
            this.txtDescSingle.TabIndex = 35;
            // 
            // lblDescAll
            // 
            this.lblDescAll.AutoSize = true;
            this.lblDescAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescAll.Location = new System.Drawing.Point(332, 18);
            this.lblDescAll.Name = "lblDescAll";
            this.lblDescAll.Size = new System.Drawing.Size(124, 13);
            this.lblDescAll.TabIndex = 36;
            this.lblDescAll.Text = "Opis ogólny wartości";
            // 
            // lbl_descSingle
            // 
            this.lbl_descSingle.AutoSize = true;
            this.lbl_descSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descSingle.Location = new System.Drawing.Point(12, 221);
            this.lbl_descSingle.Name = "lbl_descSingle";
            this.lbl_descSingle.Size = new System.Drawing.Size(87, 13);
            this.lbl_descSingle.TabIndex = 37;
            this.lbl_descSingle.Text = "Opis wartości ";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(540, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 38;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lst_Values
            // 
            this.lst_Values.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.value});
            this.lst_Values.Location = new System.Drawing.Point(12, 12);
            this.lst_Values.Name = "lst_Values";
            this.lst_Values.Size = new System.Drawing.Size(314, 206);
            this.lst_Values.TabIndex = 39;
            this.lst_Values.UseCompatibleStateImageBehavior = false;
            this.lst_Values.View = System.Windows.Forms.View.Details;
            this.lst_Values.SelectedIndexChanged += new System.EventHandler(this.lst_Values_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "Nazwa";
            this.name.Width = 120;
            // 
            // value
            // 
            this.value.Text = "Wartość";
            this.value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.value.Width = 120;
            // 
            // btn_add
            // 
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(251, 381);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 40;
            this.btn_add.Text = "Dodaj";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_rmv
            // 
            this.btn_rmv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rmv.Location = new System.Drawing.Point(12, 381);
            this.btn_rmv.Name = "btn_rmv";
            this.btn_rmv.Size = new System.Drawing.Size(75, 23);
            this.btn_rmv.TabIndex = 41;
            this.btn_rmv.Text = "Usuń";
            this.btn_rmv.UseVisualStyleBackColor = true;
            this.btn_rmv.Click += new System.EventHandler(this.btn_rmv_Click);
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(226, 355);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(100, 20);
            this.txt_value.TabIndex = 42;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(61, 355);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 20);
            this.txt_name.TabIndex = 43;
            // 
            // btn_edit
            // 
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Location = new System.Drawing.Point(170, 381);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 44;
            this.btn_edit.Text = "Zmień";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(335, 381);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 45;
            this.btn_cancel.Text = "Anuluj";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // ValueManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 416);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.btn_rmv);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lst_Values);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_descSingle);
            this.Controls.Add(this.lblDescAll);
            this.Controls.Add(this.txtDescSingle);
            this.Controls.Add(this.txtDescAll);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ValueManager";
            this.Text = "Zarządzaj wartościami";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.TextBox txtDescAll;
        private System.Windows.Forms.TextBox txtDescSingle;
        private System.Windows.Forms.Label lblDescAll;
        private System.Windows.Forms.Label lbl_descSingle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lst_Values;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_rmv;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_cancel;
    }
}