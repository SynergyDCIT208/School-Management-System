using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SchoolMS
{
   
    public partial class AdminDashboard : Form
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["schooldb"].ConnectionString;
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            // Close the dashboard form
            this.Close();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentRegistration studentRegistration = new StudentRegistration();    
            studentRegistration.Show();
            this.Hide();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            FormCreateBill formCreateBill = new FormCreateBill();
            formCreateBill.Show();
            this.Hide();
        }
        private void LoadDashboardData()
        {
            
           
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Total Students
                MySqlCommand cmdStudents = new MySqlCommand("SELECT COUNT(*) FROM students", conn);
                LblTotalStudents.Text = cmdStudents.ExecuteScalar().ToString();


                // Enrolment by Class (Chart)
                MySqlCommand cmdEnrol = new MySqlCommand("SELECT ClassName, COUNT(*) FROM students GROUP BY ClassName", conn);
                MySqlDataReader reader = cmdEnrol.ExecuteReader();
                chartEnrolment.Series.Clear();
                Series series = chartEnrolment.Series.Add("Students");
                series.ChartType = SeriesChartType.Bar;
                while (reader.Read())
                {
                    series.Points.AddXY(reader[0].ToString(), reader[1]);
                }
                reader.Close();

             
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

    }
}
