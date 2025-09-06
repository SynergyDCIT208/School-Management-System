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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnInLineSQL_Click(object sender, EventArgs e)
        {
            StudentRegistration f = new StudentRegistration();
            f.Show();
        }

        private void btnStoredProc_Click(object sender, EventArgs e)
        {
            FormStoredProc f = new FormStoredProc();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            f.Show();
        }
    }
}
