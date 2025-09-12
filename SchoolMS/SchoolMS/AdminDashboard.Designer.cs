namespace SchoolMS
{
    partial class AdminDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnFinance = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnTeachers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartEnrolment = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxTotalAttendance = new System.Windows.Forms.GroupBox();
            this.lblTodayAttendance = new System.Windows.Forms.Label();
            this.groupBoxFeeOwe = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxTotalStudents = new System.Windows.Forms.GroupBox();
            this.LblTotalStudents = new System.Windows.Forms.Label();
            this.groupBoxTotalTeachers = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAbsentees = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEnrolment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxTotalAttendance.SuspendLayout();
            this.groupBoxFeeOwe.SuspendLayout();
            this.groupBoxTotalStudents.SuspendLayout();
            this.groupBoxTotalTeachers.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsentees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnFinance);
            this.panel1.Controls.Add(this.btnClasses);
            this.panel1.Controls.Add(this.btnStudents);
            this.panel1.Controls.Add(this.btnTeachers);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(40, 398);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSettings.Location = new System.Drawing.Point(40, 242);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(100, 23);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.White;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnReports.Location = new System.Drawing.Point(40, 212);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(100, 23);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnFinance
            // 
            this.btnFinance.BackColor = System.Drawing.Color.White;
            this.btnFinance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnFinance.Location = new System.Drawing.Point(40, 173);
            this.btnFinance.Name = "btnFinance";
            this.btnFinance.Size = new System.Drawing.Size(100, 23);
            this.btnFinance.TabIndex = 4;
            this.btnFinance.Text = "Finance";
            this.btnFinance.UseVisualStyleBackColor = false;
            this.btnFinance.Click += new System.EventHandler(this.btnFinance_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.BackColor = System.Drawing.Color.White;
            this.btnClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasses.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClasses.Location = new System.Drawing.Point(40, 129);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(100, 23);
            this.btnClasses.TabIndex = 3;
            this.btnClasses.Text = "Classes";
            this.btnClasses.UseVisualStyleBackColor = false;
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.White;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnStudents.Location = new System.Drawing.Point(40, 100);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(100, 23);
            this.btnStudents.TabIndex = 2;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnTeachers
            // 
            this.btnTeachers.BackColor = System.Drawing.Color.White;
            this.btnTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeachers.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnTeachers.Location = new System.Drawing.Point(40, 60);
            this.btnTeachers.Name = "btnTeachers";
            this.btnTeachers.Size = new System.Drawing.Size(100, 23);
            this.btnTeachers.TabIndex = 1;
            this.btnTeachers.Text = "Teachers";
            this.btnTeachers.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnDashboard.Location = new System.Drawing.Point(40, 22);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(100, 23);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 100);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.chartEnrolment, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 163);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(591, 119);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // chartEnrolment
            // 
            chartArea3.Name = "ChartArea1";
            this.chartEnrolment.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartEnrolment.Legends.Add(legend3);
            this.chartEnrolment.Location = new System.Drawing.Point(3, 3);
            this.chartEnrolment.Name = "chartEnrolment";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartEnrolment.Series.Add(series3);
            this.chartEnrolment.Size = new System.Drawing.Size(209, 113);
            this.chartEnrolment.TabIndex = 0;
            this.chartEnrolment.Text = "chart1";
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(298, 3);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(211, 113);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxTotalAttendance, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxFeeOwe, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxTotalStudents, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxTotalTeachers, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(597, 135);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // groupBoxTotalAttendance
            // 
            this.groupBoxTotalAttendance.Controls.Add(this.lblTodayAttendance);
            this.groupBoxTotalAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTotalAttendance.Location = new System.Drawing.Point(450, 3);
            this.groupBoxTotalAttendance.Name = "groupBoxTotalAttendance";
            this.groupBoxTotalAttendance.Size = new System.Drawing.Size(144, 74);
            this.groupBoxTotalAttendance.TabIndex = 2;
            this.groupBoxTotalAttendance.TabStop = false;
            this.groupBoxTotalAttendance.Text = "Total Attendance";
            // 
            // lblTodayAttendance
            // 
            this.lblTodayAttendance.AutoSize = true;
            this.lblTodayAttendance.Location = new System.Drawing.Point(30, 33);
            this.lblTodayAttendance.Name = "lblTodayAttendance";
            this.lblTodayAttendance.Size = new System.Drawing.Size(83, 15);
            this.lblTodayAttendance.TabIndex = 0;
            this.lblTodayAttendance.Text = "Total Attend";
            // 
            // groupBoxFeeOwe
            // 
            this.groupBoxFeeOwe.Controls.Add(this.label4);
            this.groupBoxFeeOwe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFeeOwe.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFeeOwe.Name = "groupBoxFeeOwe";
            this.groupBoxFeeOwe.Size = new System.Drawing.Size(130, 74);
            this.groupBoxFeeOwe.TabIndex = 3;
            this.groupBoxFeeOwe.TabStop = false;
            this.groupBoxFeeOwe.Text = "Fees Owing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Owed";
            // 
            // groupBoxTotalStudents
            // 
            this.groupBoxTotalStudents.Controls.Add(this.LblTotalStudents);
            this.groupBoxTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTotalStudents.Location = new System.Drawing.Point(152, 3);
            this.groupBoxTotalStudents.Name = "groupBoxTotalStudents";
            this.groupBoxTotalStudents.Size = new System.Drawing.Size(143, 74);
            this.groupBoxTotalStudents.TabIndex = 0;
            this.groupBoxTotalStudents.TabStop = false;
            this.groupBoxTotalStudents.Text = "Total Students";
            // 
            // LblTotalStudents
            // 
            this.LblTotalStudents.AutoSize = true;
            this.LblTotalStudents.Location = new System.Drawing.Point(29, 33);
            this.LblTotalStudents.Name = "LblTotalStudents";
            this.LblTotalStudents.Size = new System.Drawing.Size(97, 15);
            this.LblTotalStudents.TabIndex = 0;
            this.LblTotalStudents.Text = "Total students";
            // 
            // groupBoxTotalTeachers
            // 
            this.groupBoxTotalTeachers.Controls.Add(this.label2);
            this.groupBoxTotalTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTotalTeachers.Location = new System.Drawing.Point(301, 3);
            this.groupBoxTotalTeachers.Name = "groupBoxTotalTeachers";
            this.groupBoxTotalTeachers.Size = new System.Drawing.Size(143, 74);
            this.groupBoxTotalTeachers.TabIndex = 1;
            this.groupBoxTotalTeachers.TabStop = false;
            this.groupBoxTotalTeachers.Text = "Total Teachers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAbsentees);
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 350);
            this.panel3.TabIndex = 2;
            // 
            // dgvAbsentees
            // 
            this.dgvAbsentees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsentees.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAbsentees.Location = new System.Drawing.Point(0, 276);
            this.dgvAbsentees.Name = "dgvAbsentees";
            this.dgvAbsentees.Size = new System.Drawing.Size(600, 74);
            this.dgvAbsentees.TabIndex = 6;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartEnrolment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxTotalAttendance.ResumeLayout(false);
            this.groupBoxTotalAttendance.PerformLayout();
            this.groupBoxFeeOwe.ResumeLayout(false);
            this.groupBoxFeeOwe.PerformLayout();
            this.groupBoxTotalStudents.ResumeLayout(false);
            this.groupBoxTotalStudents.PerformLayout();
            this.groupBoxTotalTeachers.ResumeLayout(false);
            this.groupBoxTotalTeachers.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsentees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnFinance;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnTeachers;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEnrolment;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxTotalAttendance;
        private System.Windows.Forms.Label lblTodayAttendance;
        private System.Windows.Forms.GroupBox groupBoxFeeOwe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxTotalStudents;
        private System.Windows.Forms.Label LblTotalStudents;
        private System.Windows.Forms.GroupBox groupBoxTotalTeachers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvAbsentees;
    }
}