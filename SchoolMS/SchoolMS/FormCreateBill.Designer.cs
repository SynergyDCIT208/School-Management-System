namespace SchoolMS
{
    partial class FormCreateBill
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
            this.comboAcademicYear = new System.Windows.Forms.ComboBox();
            this.comboTerm = new System.Windows.Forms.ComboBox();
            this.labelAcademicYear = new System.Windows.Forms.Label();
            this.labelTerm = new System.Windows.Forms.Label();
            this.comboClass = new System.Windows.Forms.ComboBox();
            this.labelClassForm = new System.Windows.Forms.Label();
            this.dgvBillingItems = new System.Windows.Forms.DataGridView();
            this.btnBillingSave = new System.Windows.Forms.Button();
            this.btnBillingCancel = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingItems)).BeginInit();
            this.SuspendLayout();
            // 
            // comboAcademicYear
            // 
            this.comboAcademicYear.FormattingEnabled = true;
            this.comboAcademicYear.Location = new System.Drawing.Point(185, 23);
            this.comboAcademicYear.Name = "comboAcademicYear";
            this.comboAcademicYear.Size = new System.Drawing.Size(121, 21);
            this.comboAcademicYear.TabIndex = 0;
            this.comboAcademicYear.SelectedIndexChanged += new System.EventHandler(this.comboAcademicYear_SelectedIndexChanged);
            // 
            // comboTerm
            // 
            this.comboTerm.FormattingEnabled = true;
            this.comboTerm.Location = new System.Drawing.Point(185, 64);
            this.comboTerm.Name = "comboTerm";
            this.comboTerm.Size = new System.Drawing.Size(121, 21);
            this.comboTerm.TabIndex = 1;
            // 
            // labelAcademicYear
            // 
            this.labelAcademicYear.AutoSize = true;
            this.labelAcademicYear.Location = new System.Drawing.Point(84, 23);
            this.labelAcademicYear.Name = "labelAcademicYear";
            this.labelAcademicYear.Size = new System.Drawing.Size(79, 13);
            this.labelAcademicYear.TabIndex = 2;
            this.labelAcademicYear.Text = "Academic Year";
            // 
            // labelTerm
            // 
            this.labelTerm.AutoSize = true;
            this.labelTerm.Location = new System.Drawing.Point(84, 72);
            this.labelTerm.Name = "labelTerm";
            this.labelTerm.Size = new System.Drawing.Size(31, 13);
            this.labelTerm.TabIndex = 3;
            this.labelTerm.Text = "Term";
            // 
            // comboClass
            // 
            this.comboClass.FormattingEnabled = true;
            this.comboClass.Location = new System.Drawing.Point(185, 112);
            this.comboClass.Name = "comboClass";
            this.comboClass.Size = new System.Drawing.Size(121, 21);
            this.comboClass.TabIndex = 4;
            // 
            // labelClassForm
            // 
            this.labelClassForm.AutoSize = true;
            this.labelClassForm.Location = new System.Drawing.Point(87, 119);
            this.labelClassForm.Name = "labelClassForm";
            this.labelClassForm.Size = new System.Drawing.Size(60, 13);
            this.labelClassForm.TabIndex = 5;
            this.labelClassForm.Text = "Class/Form";
            // 
            // dgvBillingItems
            // 
            this.dgvBillingItems.AllowUserToOrderColumns = true;
            this.dgvBillingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillingItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.Amount});
            this.dgvBillingItems.Location = new System.Drawing.Point(2, 167);
            this.dgvBillingItems.Name = "dgvBillingItems";
            this.dgvBillingItems.Size = new System.Drawing.Size(728, 46);
            this.dgvBillingItems.TabIndex = 6;
            // 
            // btnBillingSave
            // 
            this.btnBillingSave.Location = new System.Drawing.Point(90, 361);
            this.btnBillingSave.Name = "btnBillingSave";
            this.btnBillingSave.Size = new System.Drawing.Size(75, 23);
            this.btnBillingSave.TabIndex = 7;
            this.btnBillingSave.Text = "Save";
            this.btnBillingSave.UseVisualStyleBackColor = true;
            this.btnBillingSave.Click += new System.EventHandler(this.btnBillingSave_Click);
            // 
            // btnBillingCancel
            // 
            this.btnBillingCancel.Location = new System.Drawing.Point(245, 351);
            this.btnBillingCancel.Name = "btnBillingCancel";
            this.btnBillingCancel.Size = new System.Drawing.Size(75, 23);
            this.btnBillingCancel.TabIndex = 8;
            this.btnBillingCancel.Text = "Cancel";
            this.btnBillingCancel.UseVisualStyleBackColor = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // FormCreateBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBillingCancel);
            this.Controls.Add(this.btnBillingSave);
            this.Controls.Add(this.dgvBillingItems);
            this.Controls.Add(this.labelClassForm);
            this.Controls.Add(this.comboClass);
            this.Controls.Add(this.labelTerm);
            this.Controls.Add(this.labelAcademicYear);
            this.Controls.Add(this.comboTerm);
            this.Controls.Add(this.comboAcademicYear);
            this.Name = "FormCreateBill";
            this.Text = "FormCreateBill";
            this.Load += new System.EventHandler(this.FormCreateBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAcademicYear;
        private System.Windows.Forms.ComboBox comboTerm;
        private System.Windows.Forms.Label labelAcademicYear;
        private System.Windows.Forms.Label labelTerm;
        private System.Windows.Forms.ComboBox comboClass;
        private System.Windows.Forms.Label labelClassForm;
        private System.Windows.Forms.DataGridView dgvBillingItems;
        private System.Windows.Forms.Button btnBillingSave;
        private System.Windows.Forms.Button btnBillingCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}