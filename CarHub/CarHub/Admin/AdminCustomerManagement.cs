using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarHub
{
    public partial class AdminCustomerManagement : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;
        int selectedCustomerId = 0;

        public AdminCustomerManagement()
        {
            InitializeComponent();
            SetupDropdowns();
            DisplayCustomers();
        }

        private void SetupDropdowns()
        {
            Cus_status_cb.Items.Clear();
            Cus_status_cb.Items.AddRange(new object[] { "Active", "Inactive", "Banned" });
        }

        // --- 1. DISPLAY DATA ---
        private void DisplayCustomers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT UserID, FullName, Email, NID, Status, Username FROM Users WHERE Role = 'Customer'";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- VISUAL FIXES ---
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;

                    // Dark Mode Styling
                    dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // --- 2. SELECT ROW ---
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedCustomerId = Convert.ToInt32(row.Cells["UserID"].Value.ToString());

                Cus_ID_tb.Text = row.Cells["UserID"].Value.ToString();

                if (row.Cells["Email"].Value != DBNull.Value)
                    Cus_email_tb.Text = row.Cells["Email"].Value.ToString();
                else
                    Cus_email_tb.Clear();

                if (row.Cells["NID"].Value != DBNull.Value)
                    Cus_nid_tb.Text = row.Cells["NID"].Value.ToString();
                else
                    Cus_nid_tb.Clear();

                if (row.Cells["FullName"].Value != DBNull.Value)
                    Cus_name_tb.Text = row.Cells["FullName"].Value.ToString();

                if (row.Cells["Status"].Value != DBNull.Value)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (Cus_status_cb.Items.Contains(status))
                        Cus_status_cb.SelectedItem = status;
                    else
                        Cus_status_cb.Text = status;
                }
            }
            else
            {
                ResetFields();
            }
        }

        // --- 3. DELETE BUTTON
        private void delete_cus_btn_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Select a customer first!");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this customer?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Users WHERE UserID = @Key";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Key", selectedCustomerId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Customer Deleted Successfully");

                        DisplayCustomers();
                        ResetFields();
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547) 
                        MessageBox.Show("Cannot delete this customer because they have related data (Cars/Sales). Mark them as 'Banned' instead.");
                    else
                        MessageBox.Show("SQL Error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // --- 4. UPDATE STATUS BUTTON ---
        private void update_cus_status_btn_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0 || Cus_status_cb.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer and a status first.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Users SET Status = @Status WHERE UserID = @Key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Status", Cus_status_cb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Key", selectedCustomerId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer Status Updated Successfully!");

                    DisplayCustomers();
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ResetFields()
        {
            selectedCustomerId = 0;
            Cus_ID_tb.Clear();
            Cus_name_tb.Clear();
            Cus_email_tb.Clear();
            Cus_nid_tb.Clear();
            Cus_status_cb.SelectedIndex = -1;
        }

        // --- NAVIGATION ---

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

        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminDashboard dashboard = new AdminDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void emp_manage_btn_Click(object sender, EventArgs e)
        {
            AdminEmployeeManagement emp = new AdminEmployeeManagement();
            emp.Show();
            this.Hide();
        }

        private void cars_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminCarDashboard cars = new AdminCarDashboard();
            cars.Show();
            this.Hide();
        }

        private void AdminAnalytics_btn_Click(object sender, EventArgs e)
        {
            AdminAnalytics adminAnalytics = new AdminAnalytics();
            adminAnalytics.Show();
            this.Hide();
        }

        private void AdminCustomerManagemnt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}