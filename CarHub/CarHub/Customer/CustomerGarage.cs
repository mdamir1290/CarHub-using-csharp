using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; // For Color
using System.IO;
using System.Windows.Forms;

namespace CarHub.Customer
{
    public partial class CustomerGarage : Form
    {
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        // State Variables
        int currentUserId = Session.UserID;
        int selectedCarID = 0;
        string imgPath_Add = "";
        string imgPath_Update = "";

        public CustomerGarage()
        {
            InitializeComponent();
            LoadGarageData();
        }

        // 1. LOAD DATA (MY CARS)
        private void LoadGarageData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Cars WHERE OwnerID = @uid";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@uid", currentUserId);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Hide technical columns
                    if (dataGridView1.Columns["Image_Path"] != null) dataGridView1.Columns["Image_Path"].Visible = false;
                    if (dataGridView1.Columns["ListedBy"] != null) dataGridView1.Columns["ListedBy"].Visible = false;
                    if (dataGridView1.Columns["OwnerID"] != null) dataGridView1.Columns["OwnerID"].Visible = false;

                    // --- DARK MODE STYLING ---
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
                MessageBox.Show("Error loading garage: " + ex.Message);
            }
        }

        // 2. ADD CAR LOGIC
        private void AddCar_pic_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgPath_Add = ofd.FileName;
                AddCar_pb.Image = Image.FromFile(ofd.FileName);
                AddCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void addcar_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddCar_brand_tb.Text) || string.IsNullOrEmpty(AddCar_model_tb.Text))
            {
                MessageBox.Show("Please fill in Brand and Model.");
                return;
            }

            try
            {
                string savePath = "";
                if (!string.IsNullOrEmpty(imgPath_Add))
                {
                    string folder = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imgPath_Add);
                    savePath = Path.Combine(folder, fileName);
                    File.Copy(imgPath_Add, savePath);
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Assuming adding a car here means listing it for sale ('Available')
                    string query = @"INSERT INTO Cars (Brand, Model, Year, Price, Status, ListedBy, OwnerID, Image_Path) 
                                     VALUES (@brand, @model, @year, @price, 'Available', @uid, @uid, @img)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@brand", AddCar_brand_tb.Text);
                    cmd.Parameters.AddWithValue("@model", AddCar_model_tb.Text);

                    int.TryParse(AddCar_year_tb.Text, out int year);
                    cmd.Parameters.AddWithValue("@year", year);

                    decimal.TryParse(AddCar_price_tb.Text, out decimal price);
                    cmd.Parameters.AddWithValue("@price", price);

                    cmd.Parameters.AddWithValue("@uid", currentUserId);
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrEmpty(savePath) ? (object)DBNull.Value : savePath);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Added to Listing Successfully!");

                    LoadGarageData();
                    clear_btn_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding car: " + ex.Message);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            AddCar_brand_tb.Clear();
            AddCar_model_tb.Clear();
            AddCar_year_tb.Clear();
            AddCar_price_tb.Clear();
            AddCar_pb.Image = null;
            imgPath_Add = "";
        }

        // 3. SELECTION & UPDATE LOGIC
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

                string path = row.Cells["Image_Path"].Value != DBNull.Value ? row.Cells["Image_Path"].Value.ToString() : "";
                if (File.Exists(path))
                {
                    UpCar_pb.Image = Image.FromFile(path);
                    UpCar_pb.SizeMode = PictureBoxSizeMode.Zoom;
                    imgPath_Update = path;
                }
                else
                {
                    UpCar_pb.Image = null;
                    imgPath_Update = "";
                }
            }
        }

        private void UpCar_pic_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                UpCar_pb.Image = Image.FromFile(ofd.FileName);
                imgPath_Update = ofd.FileName;
            }
        }

        private void update_car_btn_Click(object sender, EventArgs e)
        {
            if (selectedCarID == 0)
            {
                MessageBox.Show("Please select a car to update.");
                return;
            }

            try
            {
                string finalPath = imgPath_Update;
                // Only copy if it's a new file not already in our images folder
                if (!string.IsNullOrEmpty(imgPath_Update) && File.Exists(imgPath_Update) && !imgPath_Update.Contains(Path.Combine(Application.StartupPath, "Images")))
                {
                    string folder = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imgPath_Update);
                    finalPath = Path.Combine(folder, fileName);
                    File.Copy(imgPath_Update, finalPath);
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"UPDATE Cars SET Brand=@brand, Model=@model, Year=@year, Price=@price, Image_Path=@img 
                                     WHERE CarID=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@brand", UpCar_brand_tb.Text);
                    cmd.Parameters.AddWithValue("@model", UpCar_model_tb.Text);
                    cmd.Parameters.AddWithValue("@year", int.Parse(UpCar_year_tb.Text));
                    cmd.Parameters.AddWithValue("@price", decimal.Parse(UpCar_price_tb.Text));
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrEmpty(finalPath) ? (object)DBNull.Value : finalPath);
                    cmd.Parameters.AddWithValue("@id", selectedCarID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Updated Successfully!");
                    LoadGarageData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message);
            }
        }

        // 4. DELETE LOGIC
        private void delete_car_btn_Click(object sender, EventArgs e)
        {
            if (selectedCarID == 0)
            {
                MessageBox.Show("Select a car first.");
                return;
            }

            if (MessageBox.Show("Are you sure? This car will be removed from your garage.", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Cars WHERE CarID = @id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", selectedCarID);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Car Deleted.");
                        LoadGarageData();

                        // Clear Selection
                        selectedCarID = 0;
                        UpCar_brand_tb.Clear();
                        UpCar_model_tb.Clear();
                        UpCar_year_tb.Clear();
                        UpCar_price_tb.Clear();
                        UpCar_pb.Image = null;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        MessageBox.Show("Cannot delete this car because it has related sales/service records.");
                    else
                        MessageBox.Show("SQL Error: " + ex.Message);
                }
            }
        }

        // 5. NAVIGATION (STRICT FORMAT)

        private void cus_dashboard_btn_Click(object sender, EventArgs e)
        {
            CustomerDashboard cd = new CustomerDashboard();
            cd.Show();
            this.Hide();
        }

        private void cus_gar_btn_Click(object sender, EventArgs e)
        {
            // Already in Garage, just refresh
            LoadGarageData();
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

        private void CustomerGarage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}