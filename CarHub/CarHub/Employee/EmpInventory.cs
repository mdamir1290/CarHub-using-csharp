using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarHub.Employee
{
    public partial class EmpInventory : Form
    {
        // DB Connection
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        // Track Selection
        int selectedCarId = 0;
        string selectedImagePath = ""; 
        string updatedImagePath = ""; 

        public EmpInventory()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadCarsGrid();
        }

        // --- 1. LOAD GRID LOGIC
        private void LoadCarsGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Fetch all cars
                    // Sort: Available first
                    string query = "SELECT * FROM Cars ORDER BY CASE WHEN Status = 'Available' THEN 1 ELSE 2 END, CarID DESC";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Format grid
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.RowTemplate.Height = 35; 

                    // Hide technical cols
                    string[] hiddenCols = { "Image_Path", "ListedBy", "OwnerID" };
                    foreach (var col in hiddenCols)
                    {
                        if (dataGridView1.Columns.Contains(col))
                            dataGridView1.Columns[col].Visible = false;
                    }

                    // Color code rows
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Status"].Value == null) continue;
                        string status = row.Cells["Status"].Value.ToString();

                        if (status == "Sold")
                        {
                            // Gray out sold
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            row.DefaultCellStyle.ForeColor = Color.DarkGray;
                        }
                        else if (status == "Available")
                        {
                            // White for active
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            // Yellow for others
                            row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        // --- 2. ADD CAR LOGIC 

        private void AddCar_pic_browse_btn_Click(object sender, EventArgs e)
        {
            // Browse image file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                AddCar_pb.Image = Image.FromFile(selectedImagePath);
                AddCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void addcar_btn_Click(object sender, EventArgs e)
        {
            // Validate empty fields
            if (string.IsNullOrWhiteSpace(AddCar_brand_tb.Text) ||
                string.IsNullOrWhiteSpace(AddCar_model_tb.Text) ||
                string.IsNullOrWhiteSpace(AddCar_price_tb.Text))
            {
                MessageBox.Show("Fill all fields.");
                return;
            }

            // Validate number formats
            if (!int.TryParse(AddCar_year_tb.Text, out int year) || year < 1900 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Invalid Year.");
                return;
            }
            if (!decimal.TryParse(AddCar_price_tb.Text, out decimal price))
            {
                MessageBox.Show("Invalid Price.");
                return;
            }

            try
            {
                // Save image locally
                string savePath = "";
                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    string folderPath = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                    // Unique filename
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                    savePath = Path.Combine(folderPath, fileName);
                    File.Copy(selectedImagePath, savePath);
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Insert into DB
                    string query = @"INSERT INTO Cars (Brand, Model, Year, Price, Status, Image_Path, ListedBy, OwnerID) 
                                     VALUES (@brand, @model, @year, @price, 'Available', @img, @uid, @uid)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@brand", AddCar_brand_tb.Text);
                        cmd.Parameters.AddWithValue("@model", AddCar_model_tb.Text);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@price", price);

                        // Handle null image
                        if (string.IsNullOrEmpty(savePath))
                            cmd.Parameters.AddWithValue("@img", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@img", savePath);

                        // Use Session ID
                        int userId = (Session.UserID == 0) ? 1 : Session.UserID;
                        cmd.Parameters.AddWithValue("@uid", userId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Car Added!");

                        LoadCarsGrid();
                        ClearAddFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error: " + ex.Message);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            ClearAddFields();
        }

        private void ClearAddFields()
        {
            // Reset all inputs
            AddCar_brand_tb.Clear();
            AddCar_model_tb.Clear();
            AddCar_year_tb.Clear();
            AddCar_price_tb.Clear();
            AddCar_pb.Image = null;
            selectedImagePath = "";
        }

        // --- 3. UPDATE CAR LOGIC

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedCarId = Convert.ToInt32(row.Cells["CarID"].Value);

                // Populate textboxes
                UpCar_brand_tb.Text = row.Cells["Brand"].Value.ToString();
                UpCar_model_tb.Text = row.Cells["Model"].Value.ToString();
                UpCar_year_tb.Text = row.Cells["Year"].Value.ToString();
                UpCar_price_tb.Text = row.Cells["Price"].Value.ToString();

                string status = row.Cells["Status"].Value.ToString();

                // --- LOCK SOLD CARS 
                if (status == "Sold")
                {
                    // Disable controls
                    UpCar_brand_tb.Enabled = false;
                    UpCar_model_tb.Enabled = false;
                    UpCar_year_tb.Enabled = false;
                    UpCar_price_tb.Enabled = false;
                    UpCar_status_cb.Enabled = false;
                    Update_car_btn.Enabled = false;
                    UpCar_pic_browse_btn.Enabled = false;
                }
                else
                {
                    // Enable controls
                    UpCar_brand_tb.Enabled = true;
                    UpCar_model_tb.Enabled = true;
                    UpCar_year_tb.Enabled = true;
                    UpCar_price_tb.Enabled = true;
                    UpCar_status_cb.Enabled = true;
                    Update_car_btn.Enabled = true;
                    UpCar_pic_browse_btn.Enabled = true;
                }

                // Set status dropdown
                if (UpCar_status_cb.Items.Contains(status))
                    UpCar_status_cb.SelectedItem = status;
                else
                    UpCar_status_cb.Text = status;

                // Load existing image
                string imgPath = row.Cells["Image_Path"].Value != DBNull.Value ? row.Cells["Image_Path"].Value.ToString() : "";
                updatedImagePath = imgPath;

                if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    try { UpCar_pb.Image = Image.FromFile(imgPath); }
                    catch { UpCar_pb.Image = null; }
                    UpCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    UpCar_pb.Image = null;
                }
            }
        }

        private void UpCar_pic_browse_btn_Click(object sender, EventArgs e)
        {
            // Browse new image
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                UpCar_pb.Image = Image.FromFile(ofd.FileName);
                updatedImagePath = ofd.FileName;
            }
        }

        private void Update_car_btn_Click(object sender, EventArgs e)
        {
            if (selectedCarId == 0)
            {
                MessageBox.Show("Select a car.");
                return;
            }

            try
            {
                // Handle image logic
                string finalSavePath = updatedImagePath;
                string appPath = Path.Combine(Application.StartupPath, "Images");

                // Only copy if new
                if (!string.IsNullOrEmpty(updatedImagePath) && File.Exists(updatedImagePath))
                {
                    if (!updatedImagePath.StartsWith(appPath))
                    {
                        // Directory check
                        if (!Directory.Exists(appPath)) Directory.CreateDirectory(appPath);
                        // Unique filename
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(updatedImagePath);
                        finalSavePath = Path.Combine(appPath, fileName);
                        File.Copy(updatedImagePath, finalSavePath);
                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Update query
                    string query = @"UPDATE Cars SET 
                                     Brand=@brand, Model=@model, Year=@year, Price=@price, 
                                     Status=@status, Image_Path=@img 
                                     WHERE CarID=@id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@brand", UpCar_brand_tb.Text);
                        cmd.Parameters.AddWithValue("@model", UpCar_model_tb.Text);
                        cmd.Parameters.AddWithValue("@year", int.Parse(UpCar_year_tb.Text));
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(UpCar_price_tb.Text));

                        // Set status
                        string status = UpCar_status_cb.SelectedItem != null ? UpCar_status_cb.SelectedItem.ToString() : "Available";
                        cmd.Parameters.AddWithValue("@status", status);

                        // Set image path
                        if (string.IsNullOrEmpty(finalSavePath))
                            cmd.Parameters.AddWithValue("@img", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@img", finalSavePath);

                        cmd.Parameters.AddWithValue("@id", selectedCarId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Update Successful!");

                        LoadCarsGrid();
                        // Reset selection
                        selectedCarId = 0;
                        UpCar_brand_tb.Clear();
                        UpCar_pb.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        // --- 4. NAVIGATION LOGIC

        private void admin_dashboard_btn_Click(object sender, EventArgs e)
        {
            new EmployeeDashboard().Show();
            this.Hide();
        }

        private void Emp_Customers_btn_Click(object sender, EventArgs e)
        {
            new EmpCustomers().Show();
            this.Hide();
        }

        private void Emp_Sales_btn_Click(object sender, EventArgs e)
        {
            new EmpSales().Show();
            this.Hide();
        }

        private void Emp_Service_btn_Click(object sender, EventArgs e)
        {
            new EmpService().Show();
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

        private void Emp_Inv_btn_Click(object sender, EventArgs e)
        {
        }

        private void EmpInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}