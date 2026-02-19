using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarHub
{
    public partial class SignupForm : Form
    {
        // Connection String
        string connectionString = @"Data Source=AMIR\SQLEXPRESS;Initial Catalog=CarHubDB;Integrated Security=True;TrustServerCertificate=True";

        public SignupForm()
        {
            InitializeComponent();
            // Default role selection to prevent null errors
            cmbRole.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtNID.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) || string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                lblMsg.Text = "All fields are required!";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            if (txtPass.Text != txtConfirm.Text)
            {
                lblMsg.Text = "Passwords do not match!";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            if (cmbRole.SelectedIndex == -1)
            {
                lblMsg.Text = "Please select a Role!";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            if (txtUser.Text.Length > 50)
            {
                lblMsg.Text = "Username is too long (Max 50 characters).";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            if (txtName.Text.Length > 100)
            {
                lblMsg.Text = "Full Name is too long (Max 100 characters).";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            if (txtEmail.Text.Length > 100)
            {
                lblMsg.Text = "Email is too long (Max 100 characters).";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            if (txtNID.Text.Length > 30)
            {
                lblMsg.Text = "NID is too long (Max 30 characters).";
                lblMsg.ForeColor = Color.Red;
                return;
            }

            // 2. Database Insertion
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // UPDATED QUERY: Added Email and NID
                    string query = @"INSERT INTO Users (FullName, Username, Email, NID, Password, Role, Status, Balance) 
                                     VALUES (@name, @user, @email, @nid, @pass, @role, 'Active', 0.00)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@user", txtUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim()); // New Parameter
                        cmd.Parameters.AddWithValue("@nid", txtNID.Text.Trim());     // New Parameter
                        cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                        cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Registration Successful! Please Login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Navigate to Login
                        Loginform lf = new Loginform();
                        lf.Show();
                        this.Hide();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Check for duplicate Username or Email
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    lblMsg.Text = "Username or Email already exists!";
                    lblMsg.ForeColor = Color.Red;
                }
                else
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error: " + ex.Message);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Loginform lf = new Loginform();
            lf.Show();
            this.Hide();
        }

        private void SignupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}