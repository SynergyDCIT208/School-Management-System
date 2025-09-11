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
    public partial class FormCreateBill : Form
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["schooldb"].ConnectionString;
        public FormCreateBill()
        {
            InitializeComponent();
            this.Load += FormCreateBill_Load;

        }
        private void LoadAcademicYears()
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT YearID, YearName FROM AcademicYear ORDER BY YearName DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                comboAcademicYear.Items.Clear();
                while (rdr.Read())
                {
                    comboAcademicYear.Items.Add(new ComboItem(rdr.GetInt32("YearID"), rdr.GetString("YearName")));
                }
            }
        }
        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAcademicYear.SelectedItem is ComboItem selectedYear)
            {
                LoadTerms(selectedYear.Value);
            }
        }

        private void LoadTerms(int yearID)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT TermID, TermName FROM Term WHERE YearID=@YearID ORDER BY TermOrder";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@YearID", yearID);

                MySqlDataReader rdr = cmd.ExecuteReader();
                comboTerm.Items.Clear();
                while (rdr.Read())
                {
                    comboTerm.Items.Add(new ComboItem(rdr.GetInt32("TermID"), rdr.GetString("TermName")));
                }
            }
        }
        private void LoadClasses()
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT ClassID, ClassName FROM Class ORDER BY ClassName";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                comboClass.Items.Clear();
                while (rdr.Read())
                {
                    comboClass.Items.Add(new ComboItem(rdr.GetInt32("ClassID"), rdr.GetString("ClassName")));
                }
            }
        }

        private void FormCreateBill_Load(object sender, EventArgs e)
        {
            LoadAcademicYears();
            LoadClasses();
        }

        private void comboAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAcademicYear.SelectedItem is ComboItem selectedYear)
            {
                LoadTerms(selectedYear.Value);
            }
        }

        private void AmountColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, control keys (like backspace), and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // block anything else (letters, symbols, etc.)
            }

            // If user presses '.' but there's already a '.' in the text, block it
            TextBox tb = sender as TextBox;
            if (e.KeyChar == '.' && tb.Text.Contains("."))
            {
                e.Handled = true;
            }
        }


        private void btnBillingSave_Click(object sender, EventArgs e)
        {
            if (comboAcademicYear.SelectedItem == null || comboTerm.SelectedItem == null || comboClass.SelectedItem == null)
            {
                MessageBox.Show("Please select Year, Term, and Class.");
                return;
            }

            int yearID = ((ComboItem)comboAcademicYear.SelectedItem).Value;
            int termID = ((ComboItem)comboTerm.SelectedItem).Value;
            int classID = ((ComboItem)comboClass.SelectedItem).Value;

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                // Step 1: Insert into Billing
                string sqlBilling = @"INSERT INTO Billing (ClassID, YearID, TermID) 
                              VALUES (@ClassID, @YearID, @TermID);
                              SELECT LAST_INSERT_ID();";

                MySqlCommand cmdBilling = new MySqlCommand(sqlBilling, con);
                cmdBilling.Parameters.AddWithValue("@ClassID", classID);
                cmdBilling.Parameters.AddWithValue("@YearID", yearID);
                cmdBilling.Parameters.AddWithValue("@TermID", termID);

                int billID = Convert.ToInt32(cmdBilling.ExecuteScalar());

                // Step 2: Insert each BillingItem
                foreach (DataGridViewRow row in dgvBillingItems.Rows)
                {
                    if (row.IsNewRow) continue;

                    string description = row.Cells["Description"].Value?.ToString();
                    if (string.IsNullOrWhiteSpace(description)) continue;

                    decimal amount;
                    if (!decimal.TryParse(row.Cells["Amount"].Value?.ToString(), out amount))
                        continue;

                    string sqlItem = @"INSERT INTO BillingItems (BillID, Description, Amount) 
                               VALUES (@BillID, @Description, @Amount)";

                    MySqlCommand cmdItem = new MySqlCommand(sqlItem, con);
                    cmdItem.Parameters.AddWithValue("@BillID", billID);
                    cmdItem.Parameters.AddWithValue("@Description", description);
                    cmdItem.Parameters.AddWithValue("@Amount", amount);
                    cmdItem.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Bill saved successfully!");
        }
    }
        public class ComboItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public ComboItem(int value, string text)
        {
            Value = value;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }


}
