using CarHub.Customer;
using CarHub.Employee;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarHub
{
    public partial class Loginform : Form
    {
        // Connection String
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        public Loginform()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Query checks credentials AND user status (must be Active)
                    string query = "SELECT UserID, Role, FullName, Username, Status FROM Users WHERE Username = @user AND Password = @pass";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text); 

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check if user is banned/inactive
                                string status = reader["Status"].ToString();
                                if (status != "Active")
                                {
                                    MessageBox.Show("Your account is currently " + status + ". Please contact Admin.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // Store Session Data
                                // NOTE: Ensure 'Session' class is defined only ONCE in your project namespace
                                Session.UserID = Convert.ToInt32(reader["UserID"]);
                                Session.Username = reader["Username"].ToString();
                                Session.Role = reader["Role"].ToString().ToLower();
                                string name = reader["FullName"].ToString();

                                MessageBox.Show("Login Successful! Welcome " + name, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Role-Based Redirection
                                string role = Session.Role;

                                if (role == "admin")
                                {
                                    new AdminDashboard().Show();
                                }
                                else if (role == "employee")
                                {
                                    new EmployeeDashboard().Show();
                                }
                                else if (role == "customer" || role == "client")
                                {
                                    new CustomerDashboard().Show();
                                }
                                else
                                {
                                    MessageBox.Show("Role not recognized!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Error: " + ex.Message);
            }
        }

        private void Signup_link_Click(object sender, EventArgs e)
        {
            SignupForm sf = new SignupForm();
            sf.Show();
            this.Hide();
        }

        private void Loginform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}