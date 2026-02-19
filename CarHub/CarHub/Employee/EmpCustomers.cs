using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarHub.Employee
{
    public partial class EmpCustomers : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int selectedCustomerId = 0;
        int currentUserId = Session.UserID;

        public EmpCustomers()
        {
            InitializeComponent();
            LoadCustomers();
        }

        // --- 1. LOAD CUSTOMERS
        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Get customers only
                    string query = "SELECT UserID, FullName, Username, Email, NID FROM Users WHERE Role = 'Customer'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    Emp_dgv.DataSource = dt;

                    // Grid Styling
                    Emp_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Emp_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    Emp_dgv.ReadOnly = true;
                    Emp_dgv.RowHeadersVisible = false;
                    Emp_dgv.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        // --- 2. ADD CUSTOMER LOGIC
        private void NewCus_add_btn_Click(object sender, EventArgs e)
        {
            // Empty check
            if (NewCus_name_tb.Text == "" || NewCus_un_tb.Text == "" || NewCus_pass_tb.Text == "")
            {
                MessageBox.Show("Fill required fields.");
                return;
            }

            // Password match check
            if (NewCus_pass_tb.Text != NewCus_con_pass.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO Users (FullName, Username, Email, Password, NID, Role, Status, Balance) 
                                     VALUES (@name, @username, @email, @pass, @nid, 'Customer', 'Active', 0.00)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", NewCus_name_tb.Text);
                        cmd.Parameters.AddWithValue("@username", NewCus_un_tb.Text);
                        cmd.Parameters.AddWithValue("@email", NewCus_email_tb.Text);
                        cmd.Parameters.AddWithValue("@pass", NewCus_pass_tb.Text);
                        cmd.Parameters.AddWithValue("@nid", NewCus_nid_tb.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer Added!");

                        LoadCustomers();
                        ClearAddFields();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                    MessageBox.Show("Username or Email already exists.");
                else
                    MessageBox.Show("DB Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void NewCus_clear_btn_Click(object sender, EventArgs e)
        {
            ClearAddFields();
        }

        private void ClearAddFields()
        {
            NewCus_name_tb.Clear();
            NewCus_un_tb.Clear();
            NewCus_email_tb.Clear();
            NewCus_nid_tb.Clear();
            NewCus_pass_tb.Clear();
            NewCus_con_pass.Clear();
        }

        // --- 3. DELETE CUSTOMER LOGIC 

        private void Emp_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Emp_dgv.Rows[e.RowIndex];

                // Store ID for logic
                selectedCustomerId = Convert.ToInt32(row.Cells["UserID"].Value.ToString());

                DelCus_id_tb.Text = selectedCustomerId.ToString();

                if (row.Cells["FullName"].Value != DBNull.Value)
                    DelCus_name_tb.Text = row.Cells["FullName"].Value.ToString();
            }
        }

        private void DelCus_delete_btn_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0 || string.IsNullOrEmpty(DelCus_id_tb.Text))
            {
                MessageBox.Show("Select a customer to delete.");
                return;
            }

            if (MessageBox.Show("Delete this customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Users WHERE UserID=@id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Customer Deleted.");

                            LoadCustomers();

                            // RESET FIELDS to prevent accidental double-deletes
                            selectedCustomerId = 0;
                            DelCus_id_tb.Clear();
                            DelCus_name_tb.Clear();
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Error 547: Foreign Key Conflict (Customer has bought cars)
                    if (sqlEx.Number == 547)
                        MessageBox.Show("Cannot delete: This customer has Sales/Service records.");
                    else
                        MessageBox.Show("DB Error: " + sqlEx.Message);
                }
            }
        }

        // --- 4. NAVIGATION ---
        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            new EmployeeDashboard().Show();
            this.Hide();
        }

        private void Emp_Inv_btn_Click(object sender, EventArgs e)
        {
            new EmpInventory().Show();
            this.Hide();
        }

        private void Emp_Customers_btn_Click(object sender, EventArgs e)
        {
        }

        private void Emp_Sales_btn_Click(object sender, EventArgs e)
        {
            new EmpSales().Show();
            this.Hide();
        }

        private void Emp_Service_btn_Click(object sender, EventArgs e)
        {
            new EmpService().Show();
            this.Hide();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Session.UserID = 0;
                new Loginform().Show();
                this.Hide();
            }
        }

        private void EmpCustomers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}