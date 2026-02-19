using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; 
using System.IO;
using System.Windows.Forms;

namespace CarHub
{
    public partial class AdminCarDashboard : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        int currentUserId = Session.UserID;
        string selectedAddImagePath = "";
        string selectedUpdateImagePath = "";
        int selectedCarID = -1;

        public AdminCarDashboard()
        {
            InitializeComponent();
            SetupDropdowns();
            LoadCarList();
        }

        private void SetupDropdowns()
        {
            UpCar_status_cb.Items.Clear();
            UpCar_status_cb.Items.AddRange(new object[] { "Available", "Sold", "Rented", "Out of Stock", "Pre-order", "Unavailable" });
        }

        private Image LoadImageSafe(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return Image.FromStream(ms);
                }
            }
            catch { return null; }
        }

        // --- 1. LOAD CARS ---
        private void LoadCarList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            c.CarID, 
                            c.Brand, 
                            c.Model, 
                            c.Year, 
                            c.Price, 
                            c.Status, 
                            u.FullName as ListedBy, 
                            c.Image_Path 
                        FROM Cars c
                        LEFT JOIN Users u ON c.ListedBy = u.UserID
                        ORDER BY 
                            CASE WHEN c.Status = 'Available' THEN 1 ELSE 2 END,
                            c.CarID DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- DARK MODE STYLING (FIXED) ---
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.RowTemplate.Height = 35;

                    // Base Dark Colors
                    dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    if (dataGridView1.Columns["Image_Path"] != null)
                        dataGridView1.Columns["Image_Path"].Visible = false;

                    // --- STATUS COLORING (TEXT ONLY) ---
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string status = row.Cells["Status"].Value.ToString();
                        if (status == "Sold")
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red; 
                        }
                        else if (status == "Available")
                        {
                            row.DefaultCellStyle.ForeColor = Color.LightGreen; 
                        }
                        else
                        {
                            row.DefaultCellStyle.ForeColor = Color.Gold; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cars: " + ex.Message);
            }
        }

        // --- 2. BROWSE IMAGE (ADD)
        private void AddCar_pic_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedAddImagePath = dialog.FileName;
                AddCar_pb.Image = LoadImageSafe(selectedAddImagePath);
                AddCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // --- 3. ADD CAR BUTTON
        private void addcar_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddCar_brand_tb.Text) ||
                string.IsNullOrWhiteSpace(AddCar_model_tb.Text) ||
                string.IsNullOrWhiteSpace(AddCar_year_tb.Text) ||
                string.IsNullOrWhiteSpace(AddCar_price_tb.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(AddCar_year_tb.Text, out int year))
            {
                MessageBox.Show("Year must be a valid number.");
                return;
            }
            if (!decimal.TryParse(AddCar_price_tb.Text, out decimal price))
            {
                MessageBox.Show("Price must be a valid number.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Cars 
                            (Brand, Model, Year, Price, Status, Image_Path, OwnerID, ListedBy) 
                            VALUES 
                            (@brand, @model, @year, @price, @status, @img, @ownerId, @listedBy)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@brand", AddCar_brand_tb.Text);
                        cmd.Parameters.AddWithValue("@model", AddCar_model_tb.Text);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@img", selectedAddImagePath);
                        cmd.Parameters.AddWithValue("@status", "Available");

                        // Admin Logic: Admin owns it until sold
                        cmd.Parameters.AddWithValue("@ownerId", Session.UserID);
                        cmd.Parameters.AddWithValue("@listedBy", Session.UserID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Car Added Successfully to Inventory!");

                        LoadCarList();
                        ClearAddFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            ClearAddFields();
        }

        private void ClearAddFields()
        {
            AddCar_brand_tb.Clear();
            AddCar_model_tb.Clear();
            AddCar_year_tb.Clear();
            AddCar_price_tb.Clear();
            AddCar_pb.Image = null;
            selectedAddImagePath = "";
        }

        // --- 4. GRID CELL CLICK
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedCarID = Convert.ToInt32(row.Cells["CarID"].Value);

                UpCar_brand_tb.Text = row.Cells["Brand"].Value.ToString();
                UpCar_model_tb.Text = row.Cells["Model"].Value.ToString();
                UpCar_year_tb.Text = row.Cells["Year"].Value.ToString();
                UpCar_price_tb.Text = row.Cells["Price"].Value.ToString();

                string status = row.Cells["Status"].Value.ToString();

                if (UpCar_status_cb.Items.Contains(status))
                    UpCar_status_cb.SelectedItem = status;
                else
                    UpCar_status_cb.Text = status;

                // Safety: Disable editing critical fields if Sold
                bool isSold = (status == "Sold");
                UpCar_price_tb.Enabled = !isSold;
                UpCar_brand_tb.Enabled = !isSold;
                UpCar_model_tb.Enabled = !isSold;
                UpCar_year_tb.Enabled = !isSold;

                // Image Handling
                string imgPath = row.Cells["Image_Path"].Value != DBNull.Value ? row.Cells["Image_Path"].Value.ToString() : "";
                selectedUpdateImagePath = imgPath;

                if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    UpCar_pb.Image = LoadImageSafe(imgPath);
                    UpCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    UpCar_pb.Image = null;
                }
            }
        }

        // --- 5. BROWSE IMAGE (UPDATE)
        private void UpCar_pic_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedUpdateImagePath = dialog.FileName;
                UpCar_pb.Image = LoadImageSafe(selectedUpdateImagePath);
                UpCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // --- 6. UPDATE BUTTON
        private void UpdateCar_btn_Click(object sender, EventArgs e)
        {
            if (selectedCarID == -1)
            {
                MessageBox.Show("Please select a car from the list first.");
                return;
            }

            string newStatus = UpCar_status_cb.SelectedItem.ToString();

            if (newStatus == "Sold")
            {
                var confirmResult = MessageBox.Show(
                    "Marking this car as SOLD will lock its details.\nAre you sure?",
                    "Confirm Sale",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.No) return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Cars SET 
                            Brand=@brand, 
                            Model=@model, 
                            Year=@year, 
                            Price=@price, 
                            Status=@status, 
                            Image_Path=@img 
                            WHERE CarID=@id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@brand", UpCar_brand_tb.Text);
                        cmd.Parameters.AddWithValue("@model", UpCar_model_tb.Text);
                        cmd.Parameters.AddWithValue("@year", Convert.ToInt32(UpCar_year_tb.Text));
                        cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(UpCar_price_tb.Text));
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@img", selectedUpdateImagePath);
                        cmd.Parameters.AddWithValue("@id", selectedCarID);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Car Updated Successfully!");
                        LoadCarList();

                        // Reset Selection
                        selectedCarID = -1;
                        UpCar_brand_tb.Clear();
                        UpCar_model_tb.Clear();
                        UpCar_year_tb.Clear();
                        UpCar_price_tb.Clear();
                        UpCar_pb.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // --- 7. DELETE BUTTON
        private void delete_car_btn_Click(object sender, EventArgs e)
        {
            if (selectedCarID == -1)
            {
                MessageBox.Show("Please select a car to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Cars WHERE CarID = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedCarID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Car Deleted.");

                            LoadCarList();

                            // Clear Selection
                            selectedCarID = -1;
                            UpCar_brand_tb.Clear();
                            UpCar_model_tb.Clear();
                            UpCar_year_tb.Clear();
                            UpCar_price_tb.Clear();
                            UpCar_pb.Image = null;
                            UpCar_status_cb.SelectedIndex = -1;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                        MessageBox.Show("Cannot delete this car because it has related Sales or Service records. Mark it as 'Unavailable' or 'Sold' instead.");
                    else
                        MessageBox.Show("Database Error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // --- NAVIGATION
        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            AdminDashboard dash = new AdminDashboard();
            dash.Show();
            this.Hide();
        }

        private void emp_manage_btn_Click(object sender, EventArgs e)
        {
            AdminEmployeeManagement emp = new AdminEmployeeManagement();
            emp.Show();
            this.Hide();
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            LoadCarList();
        }

        private void AdminAnalytics_btn_Click(object sender, EventArgs e)
        {
            AdminAnalytics analytics = new AdminAnalytics();
            analytics.Show();
            this.Hide();
        }

        private void AdminCarDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}