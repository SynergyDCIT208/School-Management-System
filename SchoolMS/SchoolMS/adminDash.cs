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

namespace SchoolMS
{
    public partial class adminDash : Form
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["schooldb"].ConnectionString;
        public adminDash()
        {
            InitializeComponent();
        }



        private void LoadTotalStudents()
        {
            
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {       
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("GetTotalStudents", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                object result = cmd.ExecuteScalar();
                lblTotalStudents.Text = "Total Students: " + result.ToString();
            }
        }
        private void adminDash_Load(object sender, EventArgs e)
        {
            LoadTotalStudents();
        }

    }

}

    
