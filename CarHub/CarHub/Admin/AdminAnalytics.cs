using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarHub
{
    public partial class AdminAnalytics : Form
    {
        // Connection string
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";
        int currentUserId = Session.UserID;

        public AdminAnalytics()
        {
            InitializeComponent();
            LoadSalesHistory();
            LoadServiceHistory();
        }

        // --- 1. Load Sales Logs 
        private void LoadSalesHistory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            sr.SalesID, 
                            c.Brand, 
                            c.Model, 
                            cust.FullName AS CustomerName, 
                            sell.FullName AS SellerName, 
                            sr.SaleDate, 
                            sr.InitialPrice AS [Asking Price], 
                            sr.FinalPrice AS [Final Price],
                            sr.SalesStatus
                        FROM SalesRecords sr
                        JOIN Cars c ON sr.CarID = c.CarID
                        LEFT JOIN Users cust ON sr.CustomerID = cust.UserID
                        LEFT JOIN Users sell ON sr.SellerID = sell.UserID
                        ORDER BY sr.SaleDate DESC";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- VISUAL FIXES
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.ReadOnly = true;

                    // Dark Mode Colors
                    dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    // Formatting numbers to look like currency (e.g. $10,000.00)
                    if (dataGridView1.Columns["Asking Price"] != null)
                        dataGridView1.Columns["Asking Price"].DefaultCellStyle.Format = "c2";

                    if (dataGridView1.Columns["Final Price"] != null)
                        dataGridView1.Columns["Final Price"].DefaultCellStyle.Format = "c2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales history: " + ex.Message);
            }
        }

        // --- 2. Load Service Logs ---
        private void LoadServiceHistory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Joining ServiceRecords with Cars and Users (for ServicedBy)
                    string query = @"
                        SELECT 
                            sr.ServiceID, 
                            c.Brand, 
                            c.Model, 
                            sr.ServiceDetails, 
                            sr.ServiceCost, 
                            u.FullName AS ServicedBy, 
                            sr.ServiceDate, 
                            sr.ServiceStatus
                        FROM ServiceRecords sr
                        JOIN Cars c ON sr.CarID = c.CarID
                        LEFT JOIN Users u ON sr.ServicedBy = u.UserID
                        ORDER BY sr.ServiceDate DESC";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView2.DataSource = dt;

                    // --- VISUAL FIXES ---
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.RowHeadersVisible = false;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView2.ReadOnly = true;

                    // Dark Mode Colors
                    dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    dataGridView2.DefaultCellStyle.ForeColor = Color.White;
                    dataGridView2.EnableHeadersVisualStyles = false;
                    dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    // Currency Format
                    if (dataGridView2.Columns["ServiceCost"] != null)
                        dataGridView2.Columns["ServiceCost"].DefaultCellStyle.Format = "c2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading service history: " + ex.Message);
            }
        }

        // --- Navigation Buttons

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Session.UserID = 0;
                Loginform login = new Loginform();
                login.Show();
                this.Hide();
            }
        }

        private void AdminCustomerManagement_btn_Click(object sender, EventArgs e)
        {
            AdminCustomerManagement cust = new AdminCustomerManagement();
            cust.Show();
            this.Hide();
        }

        private void cars_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminCarDashboard cars = new AdminCarDashboard();
            cars.Show();
            this.Hide();
        }

        private void emp_manage_btn_Click(object sender, EventArgs e)
        {
            AdminEmployeeManagement emp = new AdminEmployeeManagement();
            emp.Show();
            this.Hide();
        }

        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminDashboard dash = new AdminDashboard();
            dash.Show();
            this.Hide();
        }

        private void AdminAnalytics_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}