namespace SchoolMS
{
    partial class MainForm
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
            this.btnInLineSQL = new System.Windows.Forms.Button();
            this.btnStoredProc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInLineSQL
            // 
            this.btnInLineSQL.Location = new System.Drawing.Point(198, 72);
            this.btnInLineSQL.Name = "btnInLineSQL";
            this.btnInLineSQL.Size = new System.Drawing.Size(111, 23);
            this.btnInLineSQL.TabIndex = 0;
            this.btnInLineSQL.Text = "In Line SQL";
            this.btnInLineSQL.UseVisualStyleBackColor = true;
            this.btnInLineSQL.Click += new System.EventHandler(this.btnInLineSQL_Click);
            // 
            // btnStoredProc
            // 
            this.btnStoredProc.Location = new System.Drawing.Point(396, 72);
            this.btnStoredProc.Name = "btnStoredProc";
            this.btnStoredProc.Size = new System.Drawing.Size(130, 23);
            this.btnStoredProc.TabIndex = 1;
            this.btnStoredProc.Text = "Stored Procedure";
            this.btnStoredProc.UseVisualStyleBackColor = true;
            this.btnStoredProc.Click += new System.EventHandler(this.btnStoredProc_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStoredProc);
            this.Controls.Add(this.btnInLineSQL);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInLineSQL;
        private System.Windows.Forms.Button btnStoredProc;
        private System.Windows.Forms.Button button1;
    }
}