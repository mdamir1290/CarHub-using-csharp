using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarHub.Customer
{
    public partial class CustomerAnalytics : Form
    {
        // Database Connection
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;

        public CustomerAnalytics()
        {
            InitializeComponent();
            LoadCarOrders();
            LoadServiceHistory();
        }

        // 1. LOAD ALL CAR ORDERS
        private void LoadCarOrders()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT s.SalesID, s.SaleDate, c.Brand, c.Model, s.FinalPrice, s.SalesStatus 
                                     FROM SalesRecords s
                                     JOIN Cars c ON s.CarID = c.CarID
                                     WHERE s.CustomerID = @uid 
                                     ORDER BY s.SaleDate DESC";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@uid", currentUserId);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    carorder_dgv.DataSource = dt;

                    // Formatting
                    carorder_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    carorder_dgv.RowHeadersVisible = false;
                    carorder_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    carorder_dgv.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        // 2. LOAD ALL SERVICE HISTORY
        private void LoadServiceHistory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT sr.ServiceID, sr.ServiceDate, c.Brand, c.Model, sr.ServiceDetails, sr.ServiceCost, sr.ServiceStatus
                                     FROM ServiceRecords sr
                                     JOIN Cars c ON sr.CarID = c.CarID
                                     WHERE c.OwnerID = @uid 
                                     ORDER BY sr.ServiceDate DESC";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@uid", currentUserId);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    sert_dgv.DataSource = dt;

                    // Formatting
                    sert_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    sert_dgv.RowHeadersVisible = false;
                    sert_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    sert_dgv.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message);
            }
        }

        // 3. NAVIGATION BUTTONS

        private void cus_dashboard_btn_Click(object sender, EventArgs e)
        {
            CustomerDashboard cd = new CustomerDashboard();
            cd.Show();
            this.Hide();
        }

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

        private void User_analytics_btn_Click(object sender, EventArgs e)
        {
            LoadCarOrders();
            LoadServiceHistory();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Session.UserID = 0;
                Loginform login = new Loginform();
                login.Show();
                this.Hide();
            }
        }

        private void CustomerAnalytics_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}