using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarHub.Employee
{
    public partial class EmployeeDashboard : Form
    {
        // Connection String
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";
        int currentUserId = Session.UserID;

        public EmployeeDashboard()
        {
            InitializeComponent();
            LoadDashboardStats();
            LoadLogs();
        }

        // --- 1. LOAD STATISTICS & BALANCE
        private void LoadDashboardStats()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // A. Total Available Cars
                    string queryCars = "SELECT COUNT(*) FROM Cars WHERE Status = 'Available'";
                    SqlCommand cmdCars = new SqlCommand(queryCars, con);
                    int carCount = (int)cmdCars.ExecuteScalar();
                    CarCount_lb.Text = carCount.ToString();

                    // B. Sales Today
                    string querySales = "SELECT COUNT(*) FROM SalesRecords WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand cmdSales = new SqlCommand(querySales, con);
                    int salesCount = (int)cmdSales.ExecuteScalar();
                    SalesTodayCount_lb.Text = salesCount.ToString();

                    // C. Cars In Service
                    string queryService = "SELECT COUNT(*) FROM ServiceRecords WHERE ServiceStatus NOT IN ('Completed', 'Cancelled')";

                    SqlCommand cmdService = new SqlCommand(queryService, con);
                    int serviceCount = (int)cmdService.ExecuteScalar();
                    ServiceCount_lb.Text = serviceCount.ToString();

                    // D. Employee Balance

                    string queryBalance = "SELECT Balance FROM Users WHERE UserID = @uid";
                    SqlCommand cmdBalance = new SqlCommand(queryBalance, con);
                    cmdBalance.Parameters.AddWithValue("@uid", currentUserId);

                    object result = cmdBalance.ExecuteScalar();
                    decimal balance = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0.00m;

                    Emp_balance_lb.Text = "$" + balance.ToString("N2"); // Formats ($45.00)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard stats: " + ex.Message);
            }
        }

        // --- 2. LOAD LOGS INTO GRIDS 
        private void LoadLogs()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // A. Sales Log (Last 5)
                    string querySalesLog = @"
                       SELECT TOP 5 
                           c.Brand, 
                           c.Model, 
                           sr.FinalPrice, 
                           sr.SalesStatus,
                           sr.SaleDate 
                        FROM SalesRecords sr
                        JOIN Cars c ON sr.CarID = c.CarID
                        ORDER BY sr.SaleDate DESC";

                    SqlDataAdapter sdaSales = new SqlDataAdapter(querySalesLog, con);
                    DataTable dtSales = new DataTable();
                    sdaSales.Fill(dtSales);
                    Sales_dgv.DataSource = dtSales;
                    FormatGrid(Sales_dgv);

                    // B. Services Log (Last 5)
                    string queryServiceLog = @"
                        SELECT TOP 5 
                            c.Brand, 
                            c.Model, 
                            ser.ServiceDetails, 
                            ser.ServiceStatus,
                            ser.ServiceDate 
                        FROM ServiceRecords ser
                        JOIN Cars c ON ser.CarID = c.CarID
                        ORDER BY ser.ServiceDate DESC";

                    SqlDataAdapter sdaService = new SqlDataAdapter(queryServiceLog, con);
                    DataTable dtService = new DataTable();
                    sdaService.Fill(dtService);
                    Services_dgv.DataSource = dtService;
                    FormatGrid(Services_dgv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logs: " + ex.Message);
            }
        }

        private void FormatGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }

        // --- 3. WITHDRAW BUTTON LOGIC
        private void emp_balance_wd_btn_Click(object sender, EventArgs e)
        {
            // Check if balance is effectively zero 
            string balanceText = Emp_balance_lb.Text.Replace("$", "");
            decimal currentBalance = 0;
            decimal.TryParse(balanceText, out currentBalance);

            if (currentBalance <= 0)
            {
                MessageBox.Show("You have no balance to withdraw.", "Balance Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1. Confirm Intent
            if (MessageBox.Show("Do you want to withdraw your balance of " + Emp_balance_lb.Text + "?", "Confirm Withdrawal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // 2. Update Database: Set Balance to 0 for current user
                        int currentUserId = (Session.UserID == 0) ? 1 : Session.UserID;
                        string query = "UPDATE Users SET Balance = 0 WHERE UserID = @uid";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@uid", currentUserId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // 3. Success & UI Update
                                MessageBox.Show("Withdrawal Successful! Amount transferred.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Emp_balance_lb.Text = "$0.00";
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
                    MessageBox.Show("Error processing withdrawal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 4. LOGOUT BUTTON LOGIC
        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.UserID = 0;
                Loginform login = new Loginform();
                login.Show();
                this.Hide();
            }
        }

        // --- 5. SIDEBAR NAVIGATION 

        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            LoadDashboardStats();
            LoadLogs();
        }

        // Inventory Button
        private void Emp_Inv_btn_Click(object sender, EventArgs e)
        {
            EmpInventory inv = new EmpInventory();
            inv.Show();
            this.Hide();
        }

        // Customers Button
        private void Emp_Customers_btn_Click(object sender, EventArgs e)
        {
            EmpCustomers cust = new EmpCustomers();
            cust.Show();
            this.Hide();
        }

        // Sales Button
        private void Emp_Sales_btn_Click(object sender, EventArgs e)
        {
            EmpSales sales = new EmpSales();
            sales.Show();
            this.Hide();
        }

        // Service Button
        private void Emp_Service_btn_Click(object sender, EventArgs e)
        {
            EmpService service = new EmpService();
            service.Show();
            this.Hide();
        }

        // --- 6. QUICK ACCESS BUTTONS 

        private void QuickSell_btn_Click(object sender, EventArgs e) 
        {
            Emp_Sales_btn_Click(sender, e);
        }

        private void Add_customer_btn_Click(object sender, EventArgs e) 
        {
            Emp_Customers_btn_Click(sender, e);
        }

        private void EmployeeDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}