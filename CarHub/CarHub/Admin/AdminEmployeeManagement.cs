using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarHub
{
    public partial class AdminEmployeeManagement : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;

        public AdminEmployeeManagement()
        {
            InitializeComponent();
            SetupStatusComboBox();
            LoadEmployees();
        }

        private void SetupStatusComboBox()
        {
            UpEmp_status_cb.Items.Clear();
            UpEmp_status_cb.Items.AddRange(new object[] { "Active", "Inactive", "On Leave", "Terminated" });
        }

        // --- 1. LOAD DATA
        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Selecting Employee specific data
                    string query = "SELECT UserID, FullName, Username, Email, NID, Role, Status FROM Users WHERE Role='Employee'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    Emp_dgv.DataSource = dt;

                    // --- VISUAL FIXES 
                    Emp_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Emp_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    Emp_dgv.ReadOnly = true;
                    Emp_dgv.AllowUserToAddRows = false;
                    Emp_dgv.RowHeadersVisible = false;

                    // Dark Mode Styling
                    Emp_dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    Emp_dgv.DefaultCellStyle.ForeColor = Color.White;
                    Emp_dgv.EnableHeadersVisualStyles = false;
                    Emp_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    Emp_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        // --- 2. GRID CLICK (Fill Right Panel)
        private void Emp_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Emp_dgv.Rows[e.RowIndex];

                UpEmp_id_tb.Text = row.Cells["UserID"].Value.ToString();

                if (row.Cells["FullName"].Value != DBNull.Value)
                    UpEmp_name_tb.Text = row.Cells["FullName"].Value.ToString();

                string status = row.Cells["Status"].Value.ToString();
                if (!string.IsNullOrEmpty(status) && UpEmp_status_cb.Items.Contains(status))
                {
                    UpEmp_status_cb.SelectedItem = status;
                }
                else
                {
                    UpEmp_status_cb.Text = status;
                }
            }
        }

        // --- 3. ADD BUTTON (Green)
        private void NewEmp_add_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewEmp_name_tb.Text) ||
                string.IsNullOrEmpty(NewEmp_un_tb.Text) ||
                string.IsNullOrEmpty(NewEmp_pass_tb.Text) ||
                string.IsNullOrEmpty(NewEmp_email_tb.Text) ||
                string.IsNullOrEmpty(NewEmp_nid_tb.Text))
            {
                MessageBox.Show("Please fill all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (NewEmp_pass_tb.Text != NewEmp_con_pass.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Users (FullName, Username, Password, Email, NID, Role, Status) 
                                     VALUES (@name, @user, @pass, @email, @nid, 'Employee', 'Active')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", NewEmp_name_tb.Text);
                        cmd.Parameters.AddWithValue("@user", NewEmp_un_tb.Text);
                        cmd.Parameters.AddWithValue("@pass", NewEmp_pass_tb.Text);
                        cmd.Parameters.AddWithValue("@email", NewEmp_email_tb.Text);
                        cmd.Parameters.AddWithValue("@nid", NewEmp_nid_tb.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearNewEmployeeFields();
                        LoadEmployees();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) MessageBox.Show("Username or Email already exists!");
                else MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        // --- 4. CLEAR BUTTON
        private void NewEmp_clear_btn_Click(object sender, EventArgs e)
        {
            ClearNewEmployeeFields();
        }

        private void ClearNewEmployeeFields()
        {
            NewEmp_name_tb.Clear();
            NewEmp_email_tb.Clear();
            NewEmp_un_tb.Clear();
            NewEmp_nid_tb.Clear();
            NewEmp_pass_tb.Clear();
            NewEmp_con_pass.Clear();
        }

        // --- 5. UPDATE BUTTON 
        private void UpEmp_update_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UpEmp_id_tb.Text))
            {
                MessageBox.Show("Please select an employee first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET FullName = @name, Status = @status WHERE UserID = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", UpEmp_name_tb.Text);
                        string status = string.IsNullOrEmpty(UpEmp_status_cb.Text) ? "Active" : UpEmp_status_cb.Text;
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", UpEmp_id_tb.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee: " + ex.Message);
            }
        }

        // --- 6. DELETE BUTTON (Red) ---
        private void UpEmp_delete_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UpEmp_id_tb.Text))
            {
                MessageBox.Show("Select an employee first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this employee? This cannot be undone.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Users WHERE UserID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", UpEmp_id_tb.Text);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Employee deleted.");

                            // Reset UI
                            UpEmp_id_tb.Clear();
                            UpEmp_name_tb.Clear();
                            UpEmp_status_cb.SelectedIndex = -1;
                            LoadEmployees();
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Cannot delete this employee because they have related Sales or Service records. Please change their status to 'Terminated' or 'Inactive' instead.");
                    }
                    else
                    {
                        MessageBox.Show("Database Error: " + sqlEx.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // --- NAVIGATION ---
        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Hide();
        }

        private void cars_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminCarDashboard acd = new AdminCarDashboard();
            acd.Show();
            this.Hide();
        }

        private void AdminCustomerManagement_btn_Click(object sender, EventArgs e)
        {
            AdminCustomerManagement acm = new AdminCustomerManagement();
            acm.Show();
            this.Hide();
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Session.UserID = 0;
                Loginform login = new Loginform();
                login.Show();
                this.Hide();
            }
        }

        private void AdminAnalytics_btn_Click(object sender, EventArgs e)
        {
            AdminAnalytics ad = new AdminAnalytics();
            ad.Show();
            this.Hide();
        }

        private void emp_manage_btn_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void AdminEmployeeManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}