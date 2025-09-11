using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SchoolMS
{
    public partial class StudentRegistration : Form
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["schooldb"].ConnectionString;
        private int? selectedStudentId = null; // Stores selected record ID

        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            LoadReligions();
            LoadClass();
            LoadStatus();
            LoadStudents();
        }

        // ========================== UTILITIES =============================

        private void ClearForm()
        {
            txtLastName.Clear();
            txtOtherNames.Clear();
            radioMale.Checked = false;
            radioFemale.Checked = false;
            datePickerDOB.Value = DateTime.Now;
            comboReligion.SelectedIndex = -1;
            comboClass.SelectedIndex = -1;
            comboStatus.SelectedIndex = 0;
            txtLastName.Focus();
        }

        private void SetMode(bool isNew)
        {
            btnSave.Enabled = isNew;
            btnUpdate.Enabled = !isNew;
            btnDelete.Enabled = !isNew;
            if (isNew) selectedStudentId = null;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtOtherNames.Text) ||
                (!radioMale.Checked && !radioFemale.Checked) ||
                comboReligion.SelectedItem == null||
                    comboClass.SelectedItem == null)
                   
            {
                MessageBox.Show("⚠️ Please fill in all fields.");
                return false;
            }
            return true;
        }

        // ========================== RELIGION DROPDOWN =============================

        private void LoadReligions()
        {
            comboReligion.Items.Clear();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT ReligionID, ReligionName FROM religion;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Use the actual column names
                    comboReligion.Items.Add(new ComboItem(reader.GetString("ReligionName"), reader.GetInt32("ReligionID")));
                }
            }
        }

        private class ComboItem
        {
            public string Text { get; }
            public int Value { get; }
            public ComboItem(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }

       // ========================== STATUS DROPDOWN =============================

        private void LoadStatus()
        {
            comboStatus.Items.Clear();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT StatusID, StatusName FROM student_status;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Use the actual column names
                    comboStatus.Items.Add(new ComboItem2(reader.GetString("StatusName"), reader.GetInt32("StatusID")));
                }
            }
        }

        private class ComboItem2
        {
            public string Text { get; }
            public int Value { get; }
            public ComboItem2(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }
        // ========================== CLASS DROPDOWN =============================

        private void LoadClass()
        {
            comboClass.Items.Clear();
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT ClassID, ClassName FROM class;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Use the actual column names
                    comboClass.Items.Add(new ComboItem1(reader.GetString("ClassName"), reader.GetInt32("ClassID")));
                }
            }

            if (comboClass.Items.Count > 0)
                comboClass.SelectedIndex = -1;
        }

        private class ComboItem1
        {
            public string Text { get; }
            public int Value { get; }
            public ComboItem1(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }

        // ========================== CRUD OPERATIONS =============================

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string sex = radioMale.Checked ? "Male" : "Female";
            int religionID = ((ComboItem)comboReligion.SelectedItem).Value;
            int ClassID = ((ComboItem1)comboClass.SelectedItem).Value;
            int StatusID = ((ComboItem2)comboStatus.SelectedItem).Value;

            // Image handling: check if an image was selected
            string imagePath = null;
            if (pictureBoxStudent.Tag != null) // We set this in btnBrowse_Click
            {
                string sourcePath = pictureBoxStudent.Tag.ToString();
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");

                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
                string destPath = Path.Combine(imagesFolder, fileName);

                File.Copy(sourcePath, destPath, true);
                imagePath = destPath; // full path saved to DB
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO students (LastName, OtherNames, Sex, DateOfBirth, religionID,StatusID, ClassID, ImagePath) 
                           VALUES (@LN, @ON, @Sex, @DOB, @Rel,@Sta,@Cla,@Image)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@LN", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@ON", txtOtherNames.Text);
                    cmd.Parameters.AddWithValue("@Sex", sex);
                    cmd.Parameters.AddWithValue("@DOB", datePickerDOB.Value);
                    cmd.Parameters.AddWithValue("@Rel", religionID);
                    cmd.Parameters.AddWithValue("@Sta", StatusID);
                    cmd.Parameters.AddWithValue("@Cla", ClassID);
                    cmd.Parameters.AddWithValue("@Image", imagePath);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Student saved successfully!");

                    LoadStudents();
                    ClearForm();
                    SetMode(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error while saving: " + ex.Message);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == null)
            {
                MessageBox.Show("⚠️ Select a Student to update.");
                return;
            }
            if (!ValidateForm()) return;

            string sex = radioMale.Checked ? "Male" : "Female";
            int religionID = ((ComboItem)comboReligion.SelectedItem).Value;
            int ClassID = ((ComboItem1)comboClass.SelectedItem).Value;
            int StatusID = ((ComboItem2)comboStatus.SelectedItem).Value;

            // ✅ Handle image path (keep old if not changed)
            string imgPath = pictureBoxStudent.Tag != null ? pictureBoxStudent.Tag.ToString() : null;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE students 
                           SET LastName=@LN, OtherNames=@ON, Sex=@Sex, DateOfBirth=@DOB, religionID=@Rel, StatusID=@Sta, ClassId=@Cla, ImagePath=@Img
                           WHERE StudentID=@ID";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@LN", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@ON", txtOtherNames.Text);
                    cmd.Parameters.AddWithValue("@Sex", sex);
                    cmd.Parameters.AddWithValue("@DOB", datePickerDOB.Value);
                    cmd.Parameters.AddWithValue("@Rel", religionID);
                    cmd.Parameters.AddWithValue("@Sta", StatusID);
                    cmd.Parameters.AddWithValue("@Cla", ClassID);
                    cmd.Parameters.AddWithValue("@Img", imgPath);
                    cmd.Parameters.AddWithValue("@ID", selectedStudentId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Student updated successfully!");

                    LoadStudents();
                    ClearForm();
                    SetMode(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error while updating: " + ex.Message);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == null) { MessageBox.Show("⚠️ Select a Student to delete."); return; }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this Student?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM students WHERE StudentID=@ID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", selectedStudentId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("🗑️ Student deleted successfully!");
                    LoadStudents();
                    ClearForm();
                    SetMode(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error while deleting: " + ex.Message);
                }
            }
        }

        // ========================== LOAD + SEARCH =============================

        private void LoadStudents(string filter = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT p.StudentID, p.LastName, p.OtherNames, p.Sex, p.DateOfBirth, 
                              r.ReligionName, s.StatusName,c.ClassName, p.ImagePath
                       FROM students p
                       LEFT JOIN religion r ON p.ReligionID = r.ReligionID
                        LEFT JOIN class c ON p.ClassID = c.ClassID
                        LEFT JOIN student_status s ON p.StatusID = s.StatusID";

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    sql += " WHERE LOWER(p.LastName) LIKE @filter OR LOWER(p.OtherNames) LIKE @filter";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@filter", "%" + filter.ToLower() + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                var dt = new System.Data.DataTable();
                adapter.Fill(dt);
                dataGridStudents.DataSource = dt;

                // Grid polish
                dataGridStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (dataGridStudents.Rows.Count > 0)
                {
                    dataGridStudents.ClearSelection();

                    if (string.IsNullOrWhiteSpace(filter))
                    {
                        // Default: select last row (new entry)
                        int lastRowIndex = dataGridStudents.Rows.Count - 1;
                        dataGridStudents.Rows[lastRowIndex].Selected = true;
                        dataGridStudents.FirstDisplayedScrollingRowIndex = lastRowIndex;
                        ClearForm();
                        SetMode(true);
                    }
                    else
                    {
                        // Search: load first match into form
                        LoadRowIntoForm(dataGridStudents.Rows[0]);
                    }
                }
                else
                {
                    // No records found
                    ClearForm();
                    SetMode(true);
                }
            }
        }

        
    
        

        // ========================== GRID + SEARCH EVENTS =============================

        
        private void dataGridStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row
            LoadRowIntoForm(dataGridStudents.Rows[e.RowIndex]);
        }


        private void LoadRowIntoForm(DataGridViewRow row)
        {
            if (row.Cells["StudentID"].Value == null || row.Cells["StudentID"].Value == DBNull.Value)
            {
                selectedStudentId = null;
                return;
            }

            selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            txtOtherNames.Text = row.Cells["OtherNames"].Value.ToString();

            string sex = row.Cells["Sex"].Value.ToString();
            radioMale.Checked = (sex == "Male");
            radioFemale.Checked = (sex == "Female");

            datePickerDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
            comboReligion.SelectedIndex = comboReligion.FindString(row.Cells["ReligionName"].Value.ToString());
            comboStatus.SelectedIndex = comboStatus.FindString(row.Cells["StatusName"].Value.ToString());
            comboClass.SelectedIndex = comboClass.FindString(row.Cells["ClassName"].Value.ToString());


            // ✅ Load Image if available
            if (row.Cells["ImagePath"] != null && row.Cells["ImagePath"].Value != DBNull.Value)
            {
                string imgPath = row.Cells["ImagePath"].Value.ToString();
                if (!string.IsNullOrWhiteSpace(imgPath) && File.Exists(imgPath))
                {
                    pictureBoxStudent.Image = new Bitmap(imgPath);
                    pictureBoxStudent.Tag = imgPath; // store the path for update
                }
                else
                {
                    pictureBoxStudent.Image = null;
                    pictureBoxStudent.Tag = null;
                }
            }
            else
            {
                pictureBoxStudent.Image = null;
                pictureBoxStudent.Tag = null;
            }

            SetMode(false); // Update/Delete mode
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStudents(txtSearch.Text);
        }

        private void btnSearchByID_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearchByID.Text, out int StudentId))
            {
                MessageBox.Show("⚠️ Please enter a valid numeric ID.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT p.StudentID, p.LastName, p.OtherNames, p.Sex, p.DateOfBirth,
                   r.ReligionName,s.StatusName, c.ClassName, p.ImagePath

               FROM students p
               LEFT JOIN religion r ON p.ReligionID = r.ReligionID
                LEFT JOIN student_status s ON p.StatusID = s.StatusID
               LEFT JOIN class c ON p.ClassID = c.ClassID
               WHERE p.StudentID = @ID";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", StudentId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    selectedStudentId = reader.GetInt32("StudentID");
                    txtLastName.Text = reader["LastName"].ToString();
                    txtOtherNames.Text = reader["OtherNames"].ToString();
                    string sex = reader["Sex"].ToString();
                    radioMale.Checked = (sex == "Male");
                    radioFemale.Checked = (sex == "Female");
                    datePickerDOB.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                    comboReligion.SelectedIndex = comboReligion.FindString(reader["ReligionName"].ToString());
                    comboStatus.SelectedIndex = comboStatus.FindString(reader["StatusName"].ToString());
                    comboClass.SelectedIndex = comboClass.FindString(reader["ClassName"].ToString());
                    SetMode(false);
                }
                else
                {
                    MessageBox.Show("❌ Student not found.");
                    ClearForm();
                    SetMode(true);
                }
            }
        }

        private void txtSearchByID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchByID.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxStudent.Image = new Bitmap(ofd.FileName);
                pictureBoxStudent.Tag = ofd.FileName; // store file path temporarily
            }
        }
    }
}
