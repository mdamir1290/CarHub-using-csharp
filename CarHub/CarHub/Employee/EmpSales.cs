using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarHub.Employee
{
    public partial class EmpSales : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentEmpId = Session.UserID;

        public EmpSales()
        {
            InitializeComponent();
            LoadSalesGrid();
        }

        // --- 1. LOAD DATA (NOW WITH CAR DETAILS)
        private void LoadSalesGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // UPDATED QUERY: Joins Cars table to show Brand, Model, and Asking Price
                    string query = @"
                        SELECT 
                            s.SalesID, 
                            s.SaleDate, 
                            u.Username AS Customer, 
                            c.Brand,       -- NEW
                            c.Model,       -- NEW
                            c.Price AS [Asking Price], -- NEW (Original Car Price)
                            s.FinalPrice AS [Offer Price], 
                            s.SalesStatus,
                            c.Status AS [Car Status], -- NEW (Check if it's available)
                            s.CarID 
                        FROM SalesRecords s
                        LEFT JOIN Users u ON s.CustomerID = u.UserID
                        LEFT JOIN Cars c ON s.CarID = c.CarID  -- JOINING CARS TABLE
                        ORDER BY s.SaleDate DESC";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    Sales_dgv.DataSource = dt;

                    // --- PROFESSIONAL STYLING 
                    Sales_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Sales_dgv.RowHeadersVisible = false;
                    Sales_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    Sales_dgv.ReadOnly = true;
                    Sales_dgv.AllowUserToAddRows = false;

                    // Force White Text on Dark Background
                    Sales_dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    Sales_dgv.DefaultCellStyle.ForeColor = Color.White;
                    Sales_dgv.EnableHeadersVisualStyles = false;
                    Sales_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    Sales_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    // Hide the ID if you want, but keep it for logic
                    if (Sales_dgv.Columns.Contains("CarID"))
                        Sales_dgv.Columns["CarID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales: " + ex.Message);
            }
        }

        // --- 2. SELECT ROW 
        private void Sales_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Sales_dgv.Rows[e.RowIndex];

                Order_id_tb.Text = row.Cells["SalesID"].Value.ToString();

                if (row.Cells["Customer"].Value != DBNull.Value)
                    Order_cus_name_tb.Text = row.Cells["Customer"].Value.ToString();

                if (row.Cells["Offer Price"].Value != DBNull.Value)
                    Order_offerP_tb.Text = row.Cells["Offer Price"].Value.ToString();

                // Load Image
                if (row.Cells["CarID"].Value != DBNull.Value)
                {
                    LoadCarImage(Convert.ToInt32(row.Cells["CarID"].Value));
                }
            }
        }

        private void LoadCarImage(int carId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Image_Path FROM Cars WHERE CarID = @cid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cid", carId);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value && File.Exists(result.ToString()))
                    {
                        using (FileStream fs = new FileStream(result.ToString(), FileMode.Open, FileAccess.Read))
                        {
                            pictureBox1.Image = Image.FromStream(fs);
                        }
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        // --- 3. CONFIRM SALE LOGIC (WITH GHOST CAR CHECK) 
        private void Confirm_Sell_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order_id_tb.Text))
            {
                MessageBox.Show("Please select an order first.");
                return;
            }

            int salesId = Convert.ToInt32(Order_id_tb.Text);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // A. FETCH DETAILS
                    string getDetailsQuery = "SELECT CarID, CustomerID, SellerID, FinalPrice, SalesStatus FROM SalesRecords WHERE SalesID = @sid";
                    SqlCommand getCmd = new SqlCommand(getDetailsQuery, con);
                    getCmd.Parameters.AddWithValue("@sid", salesId);

                    int carId = 0, buyerId = 0, sellerId = 0;
                    decimal price = 0;
                    string currentStatus = "";

                    using (SqlDataReader reader = getCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carId = Convert.ToInt32(reader["CarID"]);
                            buyerId = Convert.ToInt32(reader["CustomerID"]);
                            sellerId = Convert.ToInt32(reader["SellerID"]);
                            price = Convert.ToDecimal(reader["FinalPrice"]);
                            currentStatus = reader["SalesStatus"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Order not found.");
                            return;
                        }
                    }

                    if (currentStatus == "Confirmed" || currentStatus == "Cancelled")
                    {
                        MessageBox.Show("Order is already processed.");
                        return;
                    }

                    // B. GHOST CAR CHECK (Is the car actually available?)
                    string checkCarStatusQuery = "SELECT Status FROM Cars WHERE CarID = @cid";
                    SqlCommand carCmd = new SqlCommand(checkCarStatusQuery, con);
                    carCmd.Parameters.AddWithValue("@cid", carId);
                    string carRealStatus = carCmd.ExecuteScalar()?.ToString();

                    if (carRealStatus != "Available")
                    {
                        MessageBox.Show($"Cannot sell this car. It is currently marked as '{carRealStatus}' in the inventory.");
                        return;
                    }

                    // C. CHECK BUYER BALANCE
                    string checkBalanceQuery = "SELECT Balance FROM Users WHERE UserID = @uid";
                    SqlCommand balCmd = new SqlCommand(checkBalanceQuery, con);
                    balCmd.Parameters.AddWithValue("@uid", buyerId);
                    decimal buyerBalance = Convert.ToDecimal(balCmd.ExecuteScalar());

                    if (buyerBalance < price)
                    {
                        MessageBox.Show($"Purchase Failed. Buyer (ID: {buyerId}) has insufficient funds.");
                        return;
                    }

                    // D. CALCULATE
                    decimal employeeCommission = price * 0.01m;
                    decimal sellerProfit = price * 0.99m;

                    // E. TRANSACTION
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // 1. Deduct Buyer
                        string deductBuyer = "UPDATE Users SET Balance = Balance - @price WHERE UserID = @buyerId";
                        SqlCommand cmd1 = new SqlCommand(deductBuyer, con, transaction);
                        cmd1.Parameters.AddWithValue("@price", price);
                        cmd1.Parameters.AddWithValue("@buyerId", buyerId);
                        cmd1.ExecuteNonQuery();

                        // 2. Update Order Status
                        string confirmOrder = "UPDATE SalesRecords SET SalesStatus = 'Confirmed' WHERE SalesID = @sid";
                        SqlCommand cmd2 = new SqlCommand(confirmOrder, con, transaction);
                        cmd2.Parameters.AddWithValue("@sid", salesId);
                        cmd2.ExecuteNonQuery();

                        // 3. Cancel Competing Orders
                        string cancelOthers = "UPDATE SalesRecords SET SalesStatus = 'Cancelled' WHERE CarID = @cid AND SalesID != @sid AND SalesStatus = 'Pending'";
                        SqlCommand cmd3 = new SqlCommand(cancelOthers, con, transaction);
                        cmd3.Parameters.AddWithValue("@cid", carId);
                        cmd3.Parameters.AddWithValue("@sid", salesId);
                        cmd3.ExecuteNonQuery();

                        // 4. Update Car Ownership
                        string updateCar = "UPDATE Cars SET Status = 'Sold', ListedBy = @buyerId, OwnerID = @buyerId WHERE CarID = @cid";
                        SqlCommand cmd4 = new SqlCommand(updateCar, con, transaction);
                        cmd4.Parameters.AddWithValue("@buyerId", buyerId);
                        cmd4.Parameters.AddWithValue("@cid", carId);
                        cmd4.ExecuteNonQuery();

                        // 5. Pay Commission
                        string payEmp = "UPDATE Users SET Balance = Balance + @comm WHERE UserID = @eid";
                        SqlCommand cmd5 = new SqlCommand(payEmp, con, transaction);
                        cmd5.Parameters.AddWithValue("@comm", employeeCommission);
                        cmd5.Parameters.AddWithValue("@eid", currentEmpId);
                        cmd5.ExecuteNonQuery();

                        // 6. Pay Seller
                        string paySeller = "UPDATE Users SET Balance = Balance + @profit WHERE UserID = @sid";
                        SqlCommand cmd6 = new SqlCommand(paySeller, con, transaction);
                        cmd6.Parameters.AddWithValue("@profit", sellerProfit);
                        cmd6.Parameters.AddWithValue("@sid", sellerId);
                        cmd6.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show($"Sale Confirmed!\nPrice: ${price}\nCommission: ${employeeCommission:N2}");

                        LoadSalesGrid();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Transaction Failed: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // --- 4. CANCEL ORDER
        private void Cancel_sell_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order_id_tb.Text))
            {
                MessageBox.Show("Select an order first.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE SalesRecords SET SalesStatus = 'Cancelled' WHERE SalesID = @sid AND SalesStatus = 'Pending'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(Order_id_tb.Text));

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Order Cancelled.");
                        LoadSalesGrid();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Could not cancel (Order might be already confirmed/cancelled).");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            Order_id_tb.Clear();
            Order_cus_name_tb.Clear();
            Order_offerP_tb.Clear();
            pictureBox1.Image = null;
        }

        // --- 5. NAVIGATION
        private void admin_dashboard_btn_Click(object sender, EventArgs e) {
            EmployeeDashboard ed = new EmployeeDashboard();
            ed.Show(); 
            this.Hide(); 
        }

        private void Emp_Inv_btn_Click(object sender, EventArgs e) {
            EmpInventory ei = new EmpInventory();
                ei.Show(); 
            this.Hide(); 
        }
        private void Emp_Customers_btn_Click(object sender, EventArgs e) {
            EmpCustomers ec = new EmpCustomers();
            ec.Show();
            this.Hide();
        }

        private void Emp_Service_btn_Click(object sender, EventArgs e) {
            EmpService es = new EmpService();
            es.Show();
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
        private void Emp_Sales_btn_Click(object sender, EventArgs e) { 
            LoadSalesGrid(); 
        }
        private void EmpSales_FormClosed(object sender, FormClosedEventArgs e) { 
            Application.Exit(); 
        }
    }
}