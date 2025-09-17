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
    public partial class MainDashboard : Form
    {
        private void btnHome_Click(object sender, EventArgs e)
        {
            panelDesktopPane.Controls.Clear();
            // Optionally, you can load a default home form or dashboard here
            MainDashboard_Load(new adminDash());
        }

        private void MainDashboard_Load(Form childForm)
        {
            panelDesktopPane.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelDesktopPane.Controls.Add(childForm);
            panelDesktopPane.Tag = childForm;
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainDashboard_Load(new StudentRegistration() );
        }
    }
}
