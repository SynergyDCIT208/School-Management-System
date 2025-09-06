using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolMS
{
    public partial class AdminDashboard : Form
    {
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
    }
}
