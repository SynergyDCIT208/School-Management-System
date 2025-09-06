namespace SchoolMS
{
    partial class FormDashBoard
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
            this.btnInLine = new System.Windows.Forms.Button();
            this.btnStored = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInLine
            // 
            this.btnInLine.Location = new System.Drawing.Point(225, 121);
            this.btnInLine.Name = "btnInLine";
            this.btnInLine.Size = new System.Drawing.Size(75, 23);
            this.btnInLine.TabIndex = 0;
            this.btnInLine.Text = "btnInLine";
            this.btnInLine.UseVisualStyleBackColor = true;
            this.btnInLine.Click += new System.EventHandler(this.btnInLine_Click);
            // 
            // btnStored
            // 
            this.btnStored.Location = new System.Drawing.Point(421, 121);
            this.btnStored.Name = "btnStored";
            this.btnStored.Size = new System.Drawing.Size(75, 23);
            this.btnStored.TabIndex = 1;
            this.btnStored.Text = "btnStored";
            this.btnStored.UseVisualStyleBackColor = true;
            this.btnStored.Click += new System.EventHandler(this.btnStored_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "CENSUS DATA MENU";
            // 
            // FormDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStored);
            this.Controls.Add(this.btnInLine);
            this.Name = "FormDashBoard";
            this.Text = "FormDashBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInLine;
        private System.Windows.Forms.Button btnStored;
        private System.Windows.Forms.Label label1;
    }
}