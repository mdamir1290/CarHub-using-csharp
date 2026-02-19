using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarHub.Customer
{
    public partial class CustomerDashboard : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;

        public CustomerDashboard()
        {
            InitializeComponent();
            SetupDashboard();
        }

        private void SetupDashboard()
        {
            LoadDashboardData();
            StyleGrid();
        }
        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 1. GET USERNAME & BALANCE
                    string userQuery = "SELECT UserName, Balance FROM Users WHERE UserID = @uid";
                    using (SqlCommand cmd = new SqlCommand(userQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", currentUserId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                username_lb.Text = reader["UserName"].ToString();
                                decimal balance = reader["Balance"] != DBNull.Value ? Convert.ToDecimal(reader["Balance"]) : 0;
                                Cus_balance_lb.Text = "€" + balance.ToString("N2");
                            }
                        }
                    }

                    // 2. GET COUNTS (overview panel)

                    // Cars Owned
                    string qOwned = "SELECT COUNT(*) FROM Cars WHERE OwnerID = @uid";
                    using (SqlCommand cmd = new SqlCommand(qOwned, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", currentUserId);
                        CarCount_lb.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Cars In Service
                    string qService = @"SELECT COUNT(*) 
                                        FROM ServiceRecords s 
                                        JOIN Cars c ON 
                                        s.CarID = c.CarID 
                                        WHERE c.OwnerID = @uid 
                                        AND s.ServiceStatus NOT IN ('Completed', 'Cancelled')";
                    using (SqlCommand cmd = new SqlCommand(qService, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", currentUserId);
                        CarSerCount_lb.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Pending Orders
                    string qPending = "SELECT COUNT(*) FROM SalesRecords WHERE CustomerID = @uid AND SalesStatus = 'Pending'";
                    using (SqlCommand cmd = new SqlCommand(qPending, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", currentUserId);
                        pendingBuyCount_lb.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. LOAD GRID
                    string qGrid = @"
                        SELECT TOP 10 s.SaleDate, c.Brand, c.Model, s.FinalPrice, s.SalesStatus
                        FROM SalesRecords s
                        JOIN Cars c ON s.CarID = c.CarID
                        WHERE s.CustomerID = @uid
                        ORDER BY s.SaleDate DESC";

                    SqlDataAdapter sda = new SqlDataAdapter(qGrid, con);
                    sda.SelectCommand.Parameters.AddWithValue("@uid", currentUserId);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    purchase_dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message);
            }
        }

        private void StyleGrid()
        {
            purchase_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            purchase_dgv.RowHeadersVisible = false;
            purchase_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            purchase_dgv.ReadOnly = true;
            purchase_dgv.AllowUserToAddRows = false; 

            // --- DARK MODE 
            purchase_dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            purchase_dgv.DefaultCellStyle.ForeColor = Color.White;
            purchase_dgv.EnableHeadersVisualStyles = false;
            purchase_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            purchase_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void Add_balance_btn_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(addBalance_tb.Text, out decimal amount) && amount > 0)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "UPDATE Users SET Balance = Balance + @amt WHERE UserID = @uid";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@amt", amount);
                        cmd.Parameters.AddWithValue("@uid", currentUserId);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Successfully added ${amount}!");
                        addBalance_tb.Clear();
                        LoadDashboardData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Session.UserID = 0;
                new Loginform().Show();
                this.Hide();
            }
        }

        // Navigation Buttons 
        private void cus_gar_btn_Click(object sender, EventArgs e)
        {
            CustomerGarage cg = new CustomerGarage();
            cg.Show();
            this.Hide();
        }

        private void CusBuyCar_btn_Click(object sender, EventArgs e)
        {
            CustomerBuyCar cbc = new CustomerBuyCar();
            cbc.Show();
            this.Hide();
        }

        private void CusBookService_btn_Click(object sender, EventArgs e)
        {
            CustomerService cs = new CustomerService();
            cs.Show();
            this.Hide();
        }

        private void CusProfile_btn_Click(object sender, EventArgs e)
        {
            CustomerProfile cp = new CustomerProfile();
            cp.Show();
            this.Hide();
        }

        private void cus_dashboard_btn_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void User_analytics_btn_Click(object sender, EventArgs e)
        {
            CustomerAnalytics ca = new CustomerAnalytics();
            ca.Show();
            this.Hide();
        }

        private void CustomerDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}