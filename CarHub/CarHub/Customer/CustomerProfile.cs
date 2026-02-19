using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarHub.Customer
{
    public partial class CustomerProfile : Form
    {
        // Database Connection
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";
        int currentUserId = Session.UserID;
        bool isPasswordVisible = false;

        public CustomerProfile()
        {
            InitializeComponent();
            LoadProfileData();

            // Set initial password masking (dots/stars)
            pass_tb.PasswordChar = '*';       // Current Password
            new_pass_tb.PasswordChar = '*';   // New Password
            con_new_pass_tb.PasswordChar = '*'; // Confirm New Password
        }

        // 1. LOAD DATA
        private void LoadProfileData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT UserID, UserName, FullName, Email, NID, Password, Status FROM Users WHERE UserID = @uid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@uid", currentUserId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UID_tb.Text = reader["UserID"].ToString();
                            UN_tb.Text = reader["UserName"].ToString();

                            // Load fields 
                            FN_tb.Text = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : "";
                            email_tb.Text = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                            NID_tb.Text = reader["NID"] != DBNull.Value ? reader["NID"].ToString() : "";

                            // Load Current Password into the box 
                            pass_tb.Text = reader["Password"].ToString();

                            // Set Status ComboBox
                            Status_cb.Items.Clear();
                            Status_cb.Items.Add("Active");
                            Status_cb.Items.Add("Inactive");

                            string currentStatus = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Active";

                            if (Status_cb.Items.Contains(currentStatus))
                                Status_cb.SelectedItem = currentStatus;
                            else
                                Status_cb.SelectedItem = "Active";

                            Status_cb.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        // 2. TOGGLE PASSWORD VISIBILITY
        private void Pass_check_btn_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                // Show Password 
                pass_tb.PasswordChar = '\0';
                Pass_check_btn.Text = "Hide Password";
                Pass_check_btn.BackColor = Color.OrangeRed;
            }
            else
            {
                // Hide Password
                pass_tb.PasswordChar = '*';
                Pass_check_btn.Text = "Show Password";
                Pass_check_btn.BackColor = Color.Orange;
            }
        }

        // 3. UPDATE BASIC INFO 
        private void Up_basic_tbn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FN_tb.Text) || string.IsNullOrEmpty(email_tb.Text))
            {
                MessageBox.Show("Full Name and Email cannot be empty.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Added Status = @status to the update query
                    string query = @"UPDATE Users 
                                     SET FullName = @name, Email = @email, NID = @nid, Status = @status 
                                     WHERE UserID = @uid";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", FN_tb.Text);
                    cmd.Parameters.AddWithValue("@email", email_tb.Text);
                    cmd.Parameters.AddWithValue("@nid", NID_tb.Text);

                    // Get Status from Dropdown
                    string status = Status_cb.SelectedItem != null ? Status_cb.SelectedItem.ToString() : "Active";
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.Parameters.AddWithValue("@uid", currentUserId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Profile Information Updated Successfully!");
                }
            }
            catch (SqlException sqlEx)
            {
                // Error 2627 or 2601 means Unique Constraint Violation (Duplicate Email/Username)
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    MessageBox.Show("This Email is already associated with another account.\nPlease use a different email.");
                }
                else
                {
                    MessageBox.Show("Database Error: " + sqlEx.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        // 4. UPDATE PASSWORD
        private void Up_pass_btn_Click(object sender, EventArgs e)
        {
            string newPass = new_pass_tb.Text;
            string confirmPass = con_new_pass_tb.Text;

            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please enter a new password.");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("New passwords do not match!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Users SET Password = @pass WHERE UserID = @uid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@pass", newPass);
                    cmd.Parameters.AddWithValue("@uid", currentUserId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password Changed Successfully!");

                    // Update the "Current Password" box
                    pass_tb.Text = newPass;

                    // Clear the "New" fields
                    new_pass_tb.Clear();
                    con_new_pass_tb.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing password: " + ex.Message);
            }
        }

        // 5. NAVIGATION
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
            LoadProfileData();
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

        private void CustomerProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}