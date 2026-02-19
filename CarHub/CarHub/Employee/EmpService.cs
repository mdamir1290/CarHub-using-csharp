using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarHub.Employee
{
    public partial class EmpService : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        // Use Session ID, fall back to 2 if testing
        int currentEmpId = (Session.UserID == 0) ? 2 : Session.UserID;

        public EmpService()
        {
            InitializeComponent();
            FillStatusCombo();
            LoadServiceGrid();
        }

        private void FillStatusCombo()
        {
            Ser_status_cb.Items.Clear();
            Ser_status_cb.Items.Add("Pending");
            Ser_status_cb.Items.Add("In Progress");
            Ser_status_cb.Items.Add("Completed"); 
            Ser_status_cb.Items.Add("Cancelled");
        }

        // --- 1. LOAD DATA
        private void LoadServiceGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Join with Cars and Users to show real names
                    string query = @"
                        SELECT 
                            sr.ServiceID, 
                            sr.CarID,
                            c.Brand,
                            c.Model,
                            u.Username AS Owner,
                            sr.ServiceDetails, 
                            sr.ServiceCost, 
                            sr.ServiceStatus,
                            sr.ServiceDate
                        FROM ServiceRecords sr
                        LEFT JOIN Cars c ON sr.CarID = c.CarID
                        LEFT JOIN Users u ON c.OwnerID = u.UserID
                        ORDER BY 
                            CASE WHEN sr.ServiceStatus = 'Pending' THEN 1 ELSE 2 END,
                            sr.ServiceDate DESC";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    Sales_dgv.DataSource = dt;

                    // --- DARK MODE STYLING 
                    Sales_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Sales_dgv.RowHeadersVisible = false;
                    Sales_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    Sales_dgv.ReadOnly = true;
                    Sales_dgv.AllowUserToAddRows = false;

                    Sales_dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    Sales_dgv.DefaultCellStyle.ForeColor = Color.White;
                    Sales_dgv.EnableHeadersVisualStyles = false;
                    Sales_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    Sales_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message);
            }
        }

        // --- 2. SELECT ROW (WITH LOCKING LOGIC) 
        private void Sales_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Sales_dgv.Rows[e.RowIndex];

                SerID_tb.Text = row.Cells["ServiceID"].Value.ToString();
                CarId_tb.Text = row.Cells["CarID"].Value.ToString();
                SerDesc_rtb.Text = row.Cells["ServiceDetails"].Value.ToString();
                Ser_cost_tb.Text = row.Cells["ServiceCost"].Value.ToString();

                string status = row.Cells["ServiceStatus"].Value.ToString();

                if (Ser_status_cb.Items.Contains(status))
                    Ser_status_cb.SelectedItem = status;
                else
                    Ser_status_cb.Text = status;

                // --- LOCKING LOGIC 
                // If Completed or Cancelled
                if (status == "Completed" || status == "Cancelled")
                {
                    CarId_tb.ReadOnly = true;
                    SerDesc_rtb.ReadOnly = true;
                    Ser_cost_tb.ReadOnly = true;
                    Ser_status_cb.Enabled = false;   
                    update_ser_btn.Enabled = false; 

                    // Optional visual cue
                    SerDesc_rtb.BackColor = Color.FromArgb(40, 40, 40);
                }
                else
                {
                    // Unlock fields for Pending/In Progress
                    CarId_tb.ReadOnly = false;
                    SerDesc_rtb.ReadOnly = false;
                    Ser_cost_tb.ReadOnly = false;
                    Ser_status_cb.Enabled = true;
                    update_ser_btn.Enabled = true;
                    SerDesc_rtb.BackColor = SystemColors.Window;
                }

                // Load Image
                if (int.TryParse(CarId_tb.Text, out int carId))
                {
                    LoadCarImage(carId);
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
                            SerCar_pb.Image = Image.FromStream(fs);
                        }
                        SerCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        SerCar_pb.Image = null;
                    }
                }
            }
            catch { SerCar_pb.Image = null; }
        }

        // --- 3. MAIN LOGIC (ADD / UPDATE) 
        private void update_ser_btn_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(CarId_tb.Text) || string.IsNullOrEmpty(SerDesc_rtb.Text) || string.IsNullOrEmpty(Ser_cost_tb.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!decimal.TryParse(Ser_cost_tb.Text, out decimal cost))
            {
                MessageBox.Show("Invalid Cost.");
                return;
            }

            string newStatus = Ser_status_cb.SelectedItem?.ToString() ?? "Pending";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    

                    // --- UPDATE EXISTING RECORD 

                    // 1. Get Old Status and Owner Info to prevent double charging
                    string checkQuery = @"
                        SELECT sr.ServiceStatus, c.OwnerID, u.Balance, u.FullName 
                        FROM ServiceRecords sr
                        JOIN Cars c ON sr.CarID = c.CarID
                        JOIN Users u ON c.OwnerID = u.UserID
                        WHERE sr.ServiceID = @sid";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@sid", int.Parse(SerID_tb.Text));

                    string oldStatus = "";
                    int ownerId = 0;
                    decimal ownerBalance = 0;
                    string ownerName = "";

                    using (SqlDataReader rdr = checkCmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            oldStatus = rdr["ServiceStatus"].ToString();
                            ownerId = Convert.ToInt32(rdr["OwnerID"]);
                            ownerBalance = Convert.ToDecimal(rdr["Balance"]);
                            ownerName = rdr["FullName"].ToString();
                        }
                        else { MessageBox.Show("Service/Car not found."); return; }
                    }

                    // 2. Logic: Only process payment if moving TO 'Completed' FROM something else
                    bool processPayment = (newStatus == "Completed" && oldStatus != "Completed");

                    if (processPayment)
                    {
                        if (ownerBalance < cost)
                        {
                            MessageBox.Show($"Cannot Complete Service.\nCustomer {ownerName} has insufficient funds (${ownerBalance}).");
                            return;
                        }
                    }

                    // 3. Execute Transaction
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // Update the Service Record
                        string updateQuery = @"UPDATE ServiceRecords SET 
                                               ServiceDetails = @desc, 
                                               ServiceCost = @cost, 
                                               ServiceStatus = @status 
                                               WHERE ServiceID = @sid";

                        SqlCommand cmdUp = new SqlCommand(updateQuery, con, transaction);
                        cmdUp.Parameters.AddWithValue("@desc", SerDesc_rtb.Text);
                        cmdUp.Parameters.AddWithValue("@cost", cost);
                        cmdUp.Parameters.AddWithValue("@status", newStatus);
                        cmdUp.Parameters.AddWithValue("@sid", int.Parse(SerID_tb.Text));
                        cmdUp.ExecuteNonQuery();

                        // IF Marking Completed -> Move Money
                        if (processPayment)
                        {
                            // Deduct from Owner
                            string deduct = "UPDATE Users SET Balance = Balance - @amt WHERE UserID = @oid";
                            SqlCommand cmdDed = new SqlCommand(deduct, con, transaction);
                            cmdDed.Parameters.AddWithValue("@amt", cost);
                            cmdDed.Parameters.AddWithValue("@oid", ownerId);
                            cmdDed.ExecuteNonQuery();

                            // Add to Employee
                            string payEmp = "UPDATE Users SET Balance = Balance + @amt WHERE UserID = @eid";
                            SqlCommand cmdPay = new SqlCommand(payEmp, con, transaction);
                            cmdPay.Parameters.AddWithValue("@amt", cost);
                            cmdPay.Parameters.AddWithValue("@eid", currentEmpId);
                            cmdPay.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        if (processPayment)
                            MessageBox.Show($"Service Completed!\n${cost} deducted from {ownerName}.");
                        else
                            MessageBox.Show("Service Updated Successfully.");

                        LoadServiceGrid();
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

        // --- 4. CLEAR FIELDS (AND RESET LOCKS) 
        private void clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            SerID_tb.Clear();
            CarId_tb.Clear();
            SerDesc_rtb.Clear();
            Ser_cost_tb.Clear();
            Ser_status_cb.SelectedIndex = -1;
            SerCar_pb.Image = null;

            // --- UNLOCK EVERYTHING 
            CarId_tb.ReadOnly = false;
            SerDesc_rtb.ReadOnly = false;
            Ser_cost_tb.ReadOnly = false;
            Ser_status_cb.Enabled = true;
            update_ser_btn.Enabled = true;
            SerDesc_rtb.BackColor = SystemColors.Window;
        }

        // --- 5. NAVIGATION -
        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            EmployeeDashboard ed = new EmployeeDashboard();
            ed.Show();
            this.Hide();
        }

        private void Emp_Inv_btn_Click(object sender, EventArgs e)
        {
            EmpInventory ei = new EmpInventory();
            ei.Show();
            this.Hide();
        }

        private void Emp_Customers_btn_Click(object sender, EventArgs e)
        {
            EmpCustomers ec = new EmpCustomers();
            ec.Show();
            this.Hide();
        }

        private void Emp_Sales_btn_Click(object sender, EventArgs e)
        {
            EmpSales es = new EmpSales();
            es.Show();
            this.Hide();
        }

        private void Emp_Service_btn_Click(object sender, EventArgs e)
        {
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
        private void EmpService_FormClosed(object sender, FormClosedEventArgs e) { Application.Exit(); }
    }
}