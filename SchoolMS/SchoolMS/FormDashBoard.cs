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
    public partial class FormDashBoard : Form
    {
        public FormDashBoard()
        {
            InitializeComponent();
        }

        private void btnInLine_Click(object sender, EventArgs e)
        {
            StudentRegistration inlineForm = new StudentRegistration();
            inlineForm.Show();
        }

        private void btnStored_Click(object sender, EventArgs e)
        {
            FormStoredProc spForm = new FormStoredProc();
            spForm.Show();
        }
    }
}
