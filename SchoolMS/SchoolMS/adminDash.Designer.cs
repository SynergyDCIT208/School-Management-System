namespace SchoolMS
{
    partial class adminDash
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
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblTotalOwing = new System.Windows.Forms.Label();
            this.lblTeachingStaff = new System.Windows.Forms.Label();
            this.lblNonTeaching = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.Location = new System.Drawing.Point(96, 46);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(166, 24);
            this.lblTotalStudents.TabIndex = 0;
            this.lblTotalStudents.Tag = "";
            this.lblTotalStudents.Text = "Total Students: 0";
            // 
            // lblTotalOwing
            // 
            this.lblTotalOwing.AutoSize = true;
            this.lblTotalOwing.Location = new System.Drawing.Point(338, 54);
            this.lblTotalOwing.Name = "lblTotalOwing";
            this.lblTotalOwing.Size = new System.Drawing.Size(106, 13);
            this.lblTotalOwing.TabIndex = 1;
            this.lblTotalOwing.Text = "Total owing: GHC 00";
            // 
            // lblTeachingStaff
            // 
            this.lblTeachingStaff.AutoSize = true;
            this.lblTeachingStaff.Location = new System.Drawing.Point(550, 57);
            this.lblTeachingStaff.Name = "lblTeachingStaff";
            this.lblTeachingStaff.Size = new System.Drawing.Size(119, 13);
            this.lblTeachingStaff.TabIndex = 2;
            this.lblTeachingStaff.Text = "Total Teaching Staff:  3";
            // 
            // lblNonTeaching
            // 
            this.lblNonTeaching.AutoSize = true;
            this.lblNonTeaching.Location = new System.Drawing.Point(553, 100);
            this.lblNonTeaching.Name = "lblNonTeaching";
            this.lblNonTeaching.Size = new System.Drawing.Size(139, 13);
            this.lblNonTeaching.TabIndex = 3;
            this.lblNonTeaching.Text = "Total Non Teaching Staff: 4";
            // 
            // adminDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNonTeaching);
            this.Controls.Add(this.lblTeachingStaff);
            this.Controls.Add(this.lblTotalOwing);
            this.Controls.Add(this.lblTotalStudents);
            this.Name = "adminDash";
            this.Text = "adminDash";
            this.Load += new System.EventHandler(this.adminDash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblTotalOwing;
        private System.Windows.Forms.Label lblTeachingStaff;
        private System.Windows.Forms.Label lblNonTeaching;
    }
}