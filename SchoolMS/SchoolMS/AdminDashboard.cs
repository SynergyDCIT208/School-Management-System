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

        private void LoadTotalStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetTotalStudents", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            LblTotalStudents.Text = result.ToString();
                        }
                        else
                        {
                            LblTotalStudents.Text = "0";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching total students: " + ex.Message);
                }
            }
        }



        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            LoadTotalStudents();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
