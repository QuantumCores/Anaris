namespace ANARIS
{
    partial class LogEntries
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
            this.logBox = new System.Windows.Forms.TextBox();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(530, 357);
            this.logBox.TabIndex = 0;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(434, 7);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(75, 23);
            this.reloadBtn.TabIndex = 1;
            this.reloadBtn.Text = "LOGS";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(328, 9);
            this.passTxt.Name = "passTxt";
            this.passTxt.Size = new System.Drawing.Size(100, 20);
            this.passTxt.TabIndex = 2;
            // 
            // LogEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 357);
            this.Controls.Add(this.passTxt);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.logBox);
            this.Name = "LogEntries";
            this.Text = "LogEntries";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.TextBox passTxt;
    }
}