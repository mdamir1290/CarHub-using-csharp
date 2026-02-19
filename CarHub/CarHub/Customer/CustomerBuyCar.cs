using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; // For Color
using System.IO;
using System.Windows.Forms;

namespace CarHub.Customer
{
    public partial class CustomerBuyCar : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;
        int selectedCarID = 0;
        int selectedSellerID = 0;

        public CustomerBuyCar()
        {
            InitializeComponent();
            LoadAvailableCars();
        }

        // --- 1. LOAD AVAILABLE CARS ---
        private void LoadAvailableCars()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Fetch OwnerID to prevent buying your own car
                    string query = @"SELECT CarID, Brand, Model, Year, Price, OwnerID, Image_Path 
                                     FROM Cars 
                                     WHERE Status = 'Available' AND OwnerID != @uid";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@uid", currentUserId);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // --- VISUAL FIXES ---
                    if (dataGridView1.Columns["Image_Path"] != null) dataGridView1.Columns["Image_Path"].Visible = false;
                    if (dataGridView1.Columns["OwnerID"] != null) dataGridView1.Columns["OwnerID"].Visible = false;
                    if (dataGridView1.Columns["CarID"] != null) dataGridView1.Columns["CarID"].Visible = false;

                    // Dark Mode Styling
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ReadOnly = true;

                    dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cars: " + ex.Message);
            }
        }

        // --- 2. SELECTION LOGIC ---
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedCarID = Convert.ToInt32(row.Cells["CarID"].Value);
                selectedSellerID = Convert.ToInt32(row.Cells["OwnerID"].Value);

                Car_brand_tb.Text = row.Cells["Brand"].Value.ToString();
                Car_model_tb.Text = row.Cells["Model"].Value.ToString();
                Car_year_tb.Text = row.Cells["Year"].Value.ToString();

                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                CarAsk_price_tb.Text = price.ToString("N2");

                // Auto-fill offer
                CarOffer_price_tb.Text = price.ToString("0");

                // Load Image
                string path = row.Cells["Image_Path"].Value != DBNull.Value ? row.Cells["Image_Path"].Value.ToString() : "";
                if (File.Exists(path))
                {
                    Car_pb.Image = Image.FromFile(path);
                    Car_pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    Car_pb.Image = null;
                }
            }
        }

        // --- 3. PURCHASE LOGIC ---
        private void update_car_btn_Click(object sender, EventArgs e) // Confirm Order Button
        {
            if (selectedCarID == 0)
            {
                MessageBox.Show("Please select a car to buy.");
                return;
            }

            if (!decimal.TryParse(CarOffer_price_tb.Text, out decimal offerPrice) || offerPrice <= 0)
            {
                MessageBox.Show("Please enter a valid offer price.");
                return;
            }

            if (!CheckBalance(offerPrice))
            {
                MessageBox.Show("Insufficient Balance in your wallet.");
                return;
            }

            if (MessageBox.Show($"Confirm order for {Car_brand_tb.Text} {Car_model_tb.Text} at ${offerPrice}?", "Confirm Purchase", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateOrder(offerPrice);
            }
        }

        private bool CheckBalance(decimal amount)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Balance FROM Users WHERE UserID = @uid", con);
                    cmd.Parameters.AddWithValue("@uid", currentUserId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        decimal balance = Convert.ToDecimal(result);
                        return balance >= amount;
                    }
                }
            }
            catch { return false; }
            return false;
        }

        private void CreateOrder(decimal offerPrice)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Check for existing pending orders to prevent spam
                    string checkQuery = "SELECT COUNT(*) FROM SalesRecords WHERE CarID = @cid AND CustomerID = @custid AND SalesStatus = 'Pending'";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@cid", selectedCarID);
                    checkCmd.Parameters.AddWithValue("@custid", currentUserId);

                    int existingOrders = (int)checkCmd.ExecuteScalar();
                    if (existingOrders > 0)
                    {
                        MessageBox.Show("You already have a pending order for this car.");
                        return;
                    }

                    string query = @"INSERT INTO SalesRecords (CarID, CustomerID, SellerID, SaleDate, InitialPrice, FinalPrice, SalesStatus) 
                                     VALUES (@cid, @custid, @selid, @date, @ask, @offer, 'Pending')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cid", selectedCarID);
                    cmd.Parameters.AddWithValue("@custid", currentUserId);
                    cmd.Parameters.AddWithValue("@selid", selectedSellerID);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ask", Convert.ToDecimal(CarAsk_price_tb.Text));
                    cmd.Parameters.AddWithValue("@offer", offerPrice);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Order Placed Successfully!\n\nStatus: Pending Approval.");

                    // Reset Fields
                    selectedCarID = 0;
                    Car_brand_tb.Clear();
                    Car_model_tb.Clear();
                    Car_year_tb.Clear();
                    CarAsk_price_tb.Clear();
                    CarOffer_price_tb.Clear();
                    Car_pb.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order Failed: " + ex.Message);
            }
        }

        // --- 4. NAVIGATION (EXPANDED STYLE) ---

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
            LoadAvailableCars(); // Refresh
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
            CustomerAnalytics ca = new CustomerAnalytics();
            ca.Show();
            this.Hide();
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

        private void CustomerBuyCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}