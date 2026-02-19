using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarHub
{
    public partial class AdminDashboard : Form
    {
        // --- Connection String
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;

        public AdminDashboard()
        {
            InitializeComponent();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            // Reset labels to default values
            CarCount_lb.Text = "0";
            SalesCount_lb.Text = "0";
            CustomersCount_lb.Text = "0";
            EmployeeCount_lb.Text = "0";
            admin_balance_lb.Text = "$0.00";

            LoadDashboardData();
            LoadInventoryGrid();
        }

        // --- 1. Load Dashboard Statistics
        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Total Cars
                    SqlCommand cmdCars = new SqlCommand("SELECT COUNT(*) FROM Cars", conn);
                    int totalCars = (int)cmdCars.ExecuteScalar();
                    CarCount_lb.Text = totalCars.ToString();

                    // Total Sales
                    SqlCommand cmdSales = new SqlCommand("SELECT COUNT(*) FROM SalesRecords", conn);
                    int totalSales = (int)cmdSales.ExecuteScalar();
                    SalesCount_lb.Text = totalSales.ToString();

                    // Total Customers
                    SqlCommand cmdCustomers = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Role='Customer'", conn);
                    int totalCustomers = (int)cmdCustomers.ExecuteScalar();
                    CustomersCount_lb.Text = totalCustomers.ToString();

                    // Total Employees (Sellers + Admins)
                    SqlCommand cmdEmployees = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Role IN ('Seller', 'Admin')", conn);
                    int totalEmployees = (int)cmdEmployees.ExecuteScalar();
                    EmployeeCount_lb.Text = totalEmployees.ToString();

                    // Admin Balance
                    if (Session.UserID != 0)
                    {
                        string queryBalance = "SELECT Balance FROM Users WHERE UserID = @uid";
                        SqlCommand cmdBalance = new SqlCommand(queryBalance, conn);
                        cmdBalance.Parameters.AddWithValue("@uid", Session.UserID);

                        object result = cmdBalance.ExecuteScalar();
                        decimal balance = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0.00m;

                        admin_balance_lb.Text = "$" + balance.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 2. Load Inventory Grid (Available Cars Only)
        private void LoadInventoryGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Filtered query to show only Available cars
                    string query = "SELECT CarID, Brand, Model, Year, Price, Status FROM Cars WHERE Status = 'Available'";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    InventoryStats_dgv.DataSource = dt;

                    // --- VISUAL FIXES 
                    InventoryStats_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    InventoryStats_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    InventoryStats_dgv.ReadOnly = true;
                    InventoryStats_dgv.AllowUserToAddRows = false;
                    InventoryStats_dgv.RowHeadersVisible = false;

                    // Dark Mode Styling
                    InventoryStats_dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    InventoryStats_dgv.DefaultCellStyle.ForeColor = Color.White;
                    InventoryStats_dgv.EnableHeadersVisualStyles = false;
                    InventoryStats_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    InventoryStats_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    // Column Headers
                    if (InventoryStats_dgv.Columns["CarID"] != null) InventoryStats_dgv.Columns["CarID"].HeaderText = "ID";
                    if (InventoryStats_dgv.Columns["Brand"] != null) InventoryStats_dgv.Columns["Brand"].HeaderText = "Brand";
                    if (InventoryStats_dgv.Columns["Model"] != null) InventoryStats_dgv.Columns["Model"].HeaderText = "Model";
                    if (InventoryStats_dgv.Columns["Year"] != null) InventoryStats_dgv.Columns["Year"].HeaderText = "Year";

                    if (InventoryStats_dgv.Columns["Price"] != null)
                    {
                        InventoryStats_dgv.Columns["Price"].HeaderText = "Price ($)";
                        InventoryStats_dgv.Columns["Price"].DefaultCellStyle.Format = "c2"; 
                    }
                    if (InventoryStats_dgv.Columns["Status"] != null) InventoryStats_dgv.Columns["Status"].HeaderText = "Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message);
            }
        }

        // --- 3. Button Events

        private void admin_balance_wd_btn_Click(object sender, EventArgs e)
        {
            if (admin_balance_lb.Text == "$0.00")
            {
                MessageBox.Show("Balance is already empty.");
                return;
            }

            if (MessageBox.Show("Do you want to withdraw your balance?", "Confirm Withdrawal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "UPDATE Users SET Balance = 0 WHERE UserID = @uid";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@uid", Session.UserID);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Withdrawal Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                admin_balance_lb.Text = "$0.00";
                            }
                            else
                            {
                                MessageBox.Show("Withdrawal failed. User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing withdrawal: " + ex.Message);
                }
            }
        }

        // --- 4. Navigation & Quick Access

        private void Add_car_btn_Click(object sender, EventArgs e)
        {
            AdminCarDashboard acd = new AdminCarDashboard();
            acd.Show();
            this.Hide();
        }

        private void Add_emp_btn_Click(object sender, EventArgs e)
        {
            AdminEmployeeManagement aem = new AdminEmployeeManagement();
            aem.Show();
            this.Hide();
        }

        // --- Sidebar Navigation ---

        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            LoadInventoryGrid();
        }

        private void cars_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminCarDashboard acd = new AdminCarDashboard();
            acd.Show();
            this.Hide();
        }

        private void emp_manage_btn_Click(object sender, EventArgs e)
        {
            AdminEmployeeManagement aem = new AdminEmployeeManagement();
            aem.Show();
            this.Hide();
        }

        private void AdminCustomerManagement_btn_Click(object sender, EventArgs e)
        {
            AdminCustomerManagement acm = new AdminCustomerManagement();
            acm.Show();
            this.Hide();
        }

        private void AdminAnalysis_btn_Click(object sender, EventArgs e)
        {
            AdminAnalytics aa = new AdminAnalytics();
            aa.Show();
            this.Hide();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.UserID = 0;
                Loginform loginForm = new Loginform();
                loginForm.Show();
                this.Hide();
            }
        }

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}