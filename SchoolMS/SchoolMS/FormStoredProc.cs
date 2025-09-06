using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolMS
{
    public partial class FormStoredProc : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["census"].ConnectionString;
        private int? selectedPersonId = null; // for update/delete

        public FormStoredProc()
        {
            InitializeComponent();
        }

        private void FormStoredProc_Load(object sender, EventArgs e)
        {
            LoadReligions();
            LoadPersons();
        }

        // 🔹 Utility: Clear all input fields
        private void ClearForm()
        {
            txtLastName.Clear();
            txtOtherNames.Clear();
            radioMale.Checked = false;
            radioFemale.Checked = false;
            datePickerDOB.Value = DateTime.Now;
            comboReligion.SelectedIndex = -1;

            txtLastName.Focus();
        }

        // 🔹 Utility: Set button mode
        private void SetMode(bool isNew)
        {
            btnSave.Enabled = isNew;
            btnUpdate.Enabled = !isNew;
            btnDelete.Enabled = !isNew;
            if (isNew) selectedPersonId = null;
        }

        // 🔹 Load Religion dropdown
        private void LoadReligions()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Code, ReligionName FROM ReligionCodes";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                comboReligion.Items.Clear();
                while (reader.Read())
                {
                    comboReligion.Items.Add(new ComboItem(reader.GetString("ReligionName"), reader.GetInt32("Code")));
                }
            }
        }

        // Helper class for dropdown
        private class ComboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public ComboItem(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }

        // 🔹 Load Persons (via Stored Procedure)
        private void LoadPersons(string filter = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd;

                if (string.IsNullOrWhiteSpace(filter))
                {
                    cmd = new MySqlCommand("GetPersons", conn); // SP with no filter
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd = new MySqlCommand("SearchPersonsByName", conn); // SP with filter
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_SearchTerm", filter);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridPersons.DataSource = dt;

                // polish grid
                dataGridPersons.AutoGenerateColumns = true;
                dataGridPersons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridPersons.ColumnHeadersVisible = true;
                dataGridPersons.AllowUserToAddRows = false;
                dataGridPersons.ReadOnly = true;

                if (dataGridPersons.Columns.Contains("LastName"))
                    dataGridPersons.Columns["LastName"].HeaderText = "Last Name";
                if (dataGridPersons.Columns.Contains("OtherNames"))
                    dataGridPersons.Columns["OtherNames"].HeaderText = "Other Names";
                if (dataGridPersons.Columns.Contains("DateOfBirth"))
                    dataGridPersons.Columns["DateOfBirth"].HeaderText = "Date of Birth";
                if (dataGridPersons.Columns.Contains("ReligionName"))
                    dataGridPersons.Columns["ReligionName"].HeaderText = "Religion";
            }
        }

        // 🔹 Save (Insert via SP)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string sex = radioMale.Checked ? "M" : "F";
            int religionCode = ((ComboItem)comboReligion.SelectedItem).Value;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("InsertPerson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@p_OtherNames", txtOtherNames.Text);
                cmd.Parameters.AddWithValue("@p_Sex", sex);
                cmd.Parameters.AddWithValue("@p_DateOfBirth", datePickerDOB.Value);
                cmd.Parameters.AddWithValue("@p_ReligionCode", religionCode);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("✅ Person inserted successfully!");
            LoadPersons();
            ClearForm();
            SetMode(true);
        }

        // 🔹 Update (via SP)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPersonId == null) { MessageBox.Show("⚠️ Select a person first."); return; }
            if (!ValidateForm()) return;

            string sex = radioMale.Checked ? "M" : "F";
            int religionCode = ((ComboItem)comboReligion.SelectedItem).Value;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UpdatePerson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_PersonID", selectedPersonId);
                cmd.Parameters.AddWithValue("@p_LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@p_OtherNames", txtOtherNames.Text);
                cmd.Parameters.AddWithValue("@p_Sex", sex);
                cmd.Parameters.AddWithValue("@p_DateOfBirth", datePickerDOB.Value);
                cmd.Parameters.AddWithValue("@p_ReligionCode", religionCode);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("✅ Person updated successfully!");
            LoadPersons();
            ClearForm();
            SetMode(true);
        }

        // 🔹 Delete (via SP)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPersonId == null) { MessageBox.Show("⚠️ Select a person first."); return; }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this person?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DeletePerson", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_PersonID", selectedPersonId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("🗑️ Person deleted successfully!");
            LoadPersons();
            ClearForm();
            SetMode(true);
        }

        // 🔹 Grid Row Click
        private void dataGridPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridPersons.Rows[e.RowIndex];
            selectedPersonId = Convert.ToInt32(row.Cells["PersonID"].Value);

            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            txtOtherNames.Text = row.Cells["OtherNames"].Value.ToString();
            string sex = row.Cells["Sex"].Value.ToString();
            radioMale.Checked = (sex == "M");
            radioFemale.Checked = (sex == "F");
            datePickerDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
            comboReligion.SelectedIndex = comboReligion.FindString(row.Cells["ReligionName"].Value.ToString());

            SetMode(false);
        }

        // 🔹 Validation helper
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtOtherNames.Text) ||
                (!radioMale.Checked && !radioFemale.Checked) ||
                comboReligion.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Please fill in all fields before saving.");
                return false;
            }
            return true;
        }

        // 🔹 Search box (calls SP for filtering)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPersons(txtSearch.Text);
        }
    }
}
