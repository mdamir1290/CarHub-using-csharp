using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarHub.Customer
{
    public partial class CustomerService : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;
        decimal currentTotalCost = 0;

        public CustomerService()
        {
            InitializeComponent();
            LoadMyCars();
            LoadServiceList();
        }

        // --- 1. LOAD DATA

        private void LoadMyCars()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                   
                    string query = "SELECT CarID, Brand, Model, Year FROM Cars WHERE OwnerID = @uid";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@uid", currentUserId);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    cars_dgv.DataSource = dt;

                    // --- DARK MODE STYLING
                    cars_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    cars_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    cars_dgv.RowHeadersVisible = false;
                    cars_dgv.ReadOnly = true;

                    cars_dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    cars_dgv.DefaultCellStyle.ForeColor = Color.White;
                    cars_dgv.EnableHeadersVisualStyles = false;
                    cars_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    cars_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading cars: " + ex.Message); }
        }

        private void LoadServiceList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ServiceName, Price FROM ServiceList";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    Service_dgv.DataSource = dt;

                    // --- DARK MODE STYLING
                    Service_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Service_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    Service_dgv.RowHeadersVisible = false;
                    Service_dgv.ReadOnly = true;

                    Service_dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    Service_dgv.DefaultCellStyle.ForeColor = Color.White;
                    Service_dgv.EnableHeadersVisualStyles = false;
                    Service_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    Service_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading services: " + ex.Message); }
        }

        // --- 2. SELECTION EVENTS ---

        // A. Select Car
        private void cars_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Car_ID_tb.Text = cars_dgv.Rows[e.RowIndex].Cells["CarID"].Value.ToString();
            }
        }

        // B. Select Service
        private void Service_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Service_Name.Text = Service_dgv.Rows[e.RowIndex].Cells["ServiceName"].Value.ToString();
                Service_Cost.Text = Service_dgv.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            }
        }

        // --- 3. ADD SERVICE BUTTON 
        private void ad_ser_btn_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(Car_ID_tb.Text))
            {
                MessageBox.Show("Please select a Car first.");
                return;
            }
            if (string.IsNullOrEmpty(Service_Name.Text) || string.IsNullOrEmpty(Service_Cost.Text))
            {
                MessageBox.Show("Please select a Service from the list.");
                return;
            }

            string newService = Service_Name.Text;
            decimal price = Convert.ToDecimal(Service_Cost.Text);

            // 1. DUPLICATE CHECK
            string currentDesc = SerDesc_rtb.Text;
            if (currentDesc.Contains(newService))
            {
                MessageBox.Show("This service is already added!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. APPEND TO DESCRIPTION
            if (string.IsNullOrEmpty(currentDesc))
                SerDesc_rtb.Text = newService;
            else
                SerDesc_rtb.Text += " ; " + newService;

            // 3. UPDATE TOTAL ESTIMATE
            currentTotalCost += price;
            estimate_tb.Text = "$" + currentTotalCost.ToString("N2");

            // 4. CLEAR STAGING FIELDS
            Service_Name.Clear();
            Service_Cost.Clear();
            Service_dgv.ClearSelection();
        }

        // --- 4. CONFIRM SERVICE 
        private void confirm_ser_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Car_ID_tb.Text) || string.IsNullOrEmpty(SerDesc_rtb.Text))
            {
                MessageBox.Show("Please add at least one service to the list.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // STEP 1: CHECK BALANCE
                    SqlCommand balCmd = new SqlCommand("SELECT Balance FROM Users WHERE UserID = @uid", con);
                    balCmd.Parameters.AddWithValue("@uid", currentUserId);
                    object result = balCmd.ExecuteScalar();
                    decimal currentBalance = (result != null) ? Convert.ToDecimal(result) : 0;

                    if (currentBalance < currentTotalCost)
                    {
                        MessageBox.Show($"Insufficient Funds.\nYour Balance: ${currentBalance}\nService Cost: ${currentTotalCost}");
                        return;
                    }

                    // STEP 2: INSERT RECORD
                    string query = @"INSERT INTO ServiceRecords (CarID, ServiceDate, ServiceDetails, ServiceCost, ServiceStatus, ServicedBy)
                                     VALUES (@cid, @date, @details, @cost, 'Pending', @eid)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(Car_ID_tb.Text));
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@details", SerDesc_rtb.Text);
                    cmd.Parameters.AddWithValue("@cost", currentTotalCost);
                    cmd.Parameters.AddWithValue("@eid", DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Service Booked Successfully!\n\nEst. Cost: ${currentTotalCost}\nStatus: Pending (Funds Verified)");

                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking Failed: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            Car_ID_tb.Clear();
            Service_Name.Clear();
            Service_Cost.Clear();
            SerDesc_rtb.Clear();
            estimate_tb.Clear();
            currentTotalCost = 0;
            cars_dgv.ClearSelection();
            Service_dgv.ClearSelection();
        }

        // --- 5. NAVIGATION

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
            LoadMyCars();
            ResetForm();
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

        private void CustomerService_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}