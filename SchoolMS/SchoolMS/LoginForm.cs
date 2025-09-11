using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string connString = "Server=localhost;Database=schooldb;Uid=root;Pwd=12345678;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT role FROM users";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    cmbRole.Items.Clear();
                    while (reader.Read())
                    {
                        cmbRole.Items.Add(reader["role"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message,
                        "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUserName.Text.Trim();
            string enteredPassword = txtPassword.Text.Trim();
            string selectedRole = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(enteredUsername) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connString = "Server=localhost;Database=schooldb;Uid=root;Pwd=12345678;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password AND role = @role";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", enteredUsername);
                    cmd.Parameters.AddWithValue("@password", enteredPassword);
                    cmd.Parameters.AddWithValue("@role", selectedRole);

                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (userCount > 0)
                    {
                        MessageBox.Show("Login successful!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        if (selectedRole == "Admin")
                        {
                            AdminDashboard adminDashboardForm = new AdminDashboard();
                            adminDashboardForm.Show();
                        }
                        else if (selectedRole == "Teacher")
                        {
                           // SchoolDashboardForm schoolDashboardForm = new SchoolDashboardForm();
                           // schoolDashboardForm.Show();
                            FormCreateBill formDashboard = new FormCreateBill();
                            formDashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Unknown role selected.", "Role Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username, password, or role.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message,
                        "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }
    }
}
