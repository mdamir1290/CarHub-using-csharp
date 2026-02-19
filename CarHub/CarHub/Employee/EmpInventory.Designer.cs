using System.Windows.Forms;

namespace CarHub.Employee
{
    partial class EmpInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sidebar_panel = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.Emp_Service_btn = new System.Windows.Forms.Button();
            this.Emp_Sales_btn = new System.Windows.Forms.Button();
            this.Emp_Customers_btn = new System.Windows.Forms.Button();
            this.Emp_Inv_btn = new System.Windows.Forms.Button();
            this.admin_dashboard_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uname_l = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AddCar_year_tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.AddCar_brand_tb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.addcar_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.AddCar_price_tb = new System.Windows.Forms.TextBox();
            this.AddCar_model_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddCar_pic_browse_btn = new System.Windows.Forms.Button();
            this.AddCar_pb = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.UpCar_model_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Update_car_btn = new System.Windows.Forms.Button();
            this.UpCar_pic_browse_btn = new System.Windows.Forms.Button();
            this.UpCar_price_tb = new System.Windows.Forms.TextBox();
            this.UpCar_pb = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UpCar_status_cb = new System.Windows.Forms.ComboBox();
            this.UpCar_year_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UpCar_brand_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddCar_pb)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpCar_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebar_panel
            // 
            this.sidebar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sidebar_panel.Controls.Add(this.logout_btn);
            this.sidebar_panel.Controls.Add(this.Emp_Service_btn);
            this.sidebar_panel.Controls.Add(this.Emp_Sales_btn);
            this.sidebar_panel.Controls.Add(this.Emp_Customers_btn);
            this.sidebar_panel.Controls.Add(this.Emp_Inv_btn);
            this.sidebar_panel.Controls.Add(this.admin_dashboard_btn);
            this.sidebar_panel.Controls.Add(this.panel1);
            this.sidebar_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar_panel.Location = new System.Drawing.Point(0, 0);
            this.sidebar_panel.Name = "sidebar_panel";
            this.sidebar_panel.Size = new System.Drawing.Size(224, 729);
            this.sidebar_panel.TabIndex = 45;
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.Firebrick;
            this.logout_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Location = new System.Drawing.Point(0, 669);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Padding = new System.Windows.Forms.Padding(10);
            this.logout_btn.Size = new System.Drawing.Size(224, 60);
            this.logout_btn.TabIndex = 6;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // Emp_Service_btn
            // 
            this.Emp_Service_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Emp_Service_btn.FlatAppearance.BorderSize = 0;
            this.Emp_Service_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Emp_Service_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emp_Service_btn.ForeColor = System.Drawing.Color.White;
            this.Emp_Service_btn.Location = new System.Drawing.Point(0, 340);
            this.Emp_Service_btn.Name = "Emp_Service_btn";
            this.Emp_Service_btn.Padding = new System.Windows.Forms.Padding(10);
            this.Emp_Service_btn.Size = new System.Drawing.Size(224, 60);
            this.Emp_Service_btn.TabIndex = 5;
            this.Emp_Service_btn.Text = "Service";
            this.Emp_Service_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Emp_Service_btn.UseVisualStyleBackColor = true;
            this.Emp_Service_btn.Click += new System.EventHandler(this.Emp_Service_btn_Click);
            // 
            // Emp_Sales_btn
            // 
            this.Emp_Sales_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Emp_Sales_btn.FlatAppearance.BorderSize = 0;
            this.Emp_Sales_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Emp_Sales_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emp_Sales_btn.ForeColor = System.Drawing.Color.White;
            this.Emp_Sales_btn.Location = new System.Drawing.Point(0, 280);
            this.Emp_Sales_btn.Name = "Emp_Sales_btn";
            this.Emp_Sales_btn.Padding = new System.Windows.Forms.Padding(10);
            this.Emp_Sales_btn.Size = new System.Drawing.Size(224, 60);
            this.Emp_Sales_btn.TabIndex = 4;
            this.Emp_Sales_btn.Text = "Sales";
            this.Emp_Sales_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Emp_Sales_btn.UseVisualStyleBackColor = true;
            this.Emp_Sales_btn.Click += new System.EventHandler(this.Emp_Sales_btn_Click);
            // 
            // Emp_Customers_btn
            // 
            this.Emp_Customers_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Emp_Customers_btn.FlatAppearance.BorderSize = 0;
            this.Emp_Customers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Emp_Customers_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emp_Customers_btn.ForeColor = System.Drawing.Color.White;
            this.Emp_Customers_btn.Location = new System.Drawing.Point(0, 220);
            this.Emp_Customers_btn.Name = "Emp_Customers_btn";
            this.Emp_Customers_btn.Padding = new System.Windows.Forms.Padding(10);
            this.Emp_Customers_btn.Size = new System.Drawing.Size(224, 60);
            this.Emp_Customers_btn.TabIndex = 3;
            this.Emp_Customers_btn.Text = "Customers";
            this.Emp_Customers_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Emp_Customers_btn.UseVisualStyleBackColor = true;
            this.Emp_Customers_btn.Click += new System.EventHandler(this.Emp_Customers_btn_Click);
            // 
            // Emp_Inv_btn
            // 
            this.Emp_Inv_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(25)))));
            this.Emp_Inv_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Emp_Inv_btn.FlatAppearance.BorderSize = 0;
            this.Emp_Inv_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Emp_Inv_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emp_Inv_btn.ForeColor = System.Drawing.Color.White;
            this.Emp_Inv_btn.Location = new System.Drawing.Point(0, 160);
            this.Emp_Inv_btn.Name = "Emp_Inv_btn";
            this.Emp_Inv_btn.Padding = new System.Windows.Forms.Padding(10);
            this.Emp_Inv_btn.Size = new System.Drawing.Size(224, 60);
            this.Emp_Inv_btn.TabIndex = 2;
            this.Emp_Inv_btn.Text = "Inventory";
            this.Emp_Inv_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Emp_Inv_btn.UseVisualStyleBackColor = false;
            this.Emp_Inv_btn.Click += new System.EventHandler(this.Emp_Inv_btn_Click);
            // 
            // admin_dashboard_btn
            // 
            this.admin_dashboard_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.admin_dashboard_btn.FlatAppearance.BorderSize = 0;
            this.admin_dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_dashboard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.admin_dashboard_btn.Location = new System.Drawing.Point(0, 100);
            this.admin_dashboard_btn.Name = "admin_dashboard_btn";
            this.admin_dashboard_btn.Padding = new System.Windows.Forms.Padding(10);
            this.admin_dashboard_btn.Size = new System.Drawing.Size(224, 60);
            this.admin_dashboard_btn.TabIndex = 1;
            this.admin_dashboard_btn.Text = "Dashboard";
            this.admin_dashboard_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.admin_dashboard_btn.UseVisualStyleBackColor = true;
            this.admin_dashboard_btn.Click += new System.EventHandler(this.admin_dashboard_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uname_l);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 100);
            this.panel1.TabIndex = 0;
            // 
            // uname_l
            // 
            this.uname_l.AutoSize = true;
            this.uname_l.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uname_l.ForeColor = System.Drawing.Color.White;
            this.uname_l.Location = new System.Drawing.Point(35, 38);
            this.uname_l.Name = "uname_l";
            this.uname_l.Size = new System.Drawing.Size(154, 26);
            this.uname_l.TabIndex = 0;
            this.uname_l.Text = "Employee Portal";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel3.Controls.Add(this.AddCar_year_tb);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.AddCar_brand_tb);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.addcar_btn);
            this.panel3.Controls.Add(this.clear_btn);
            this.panel3.Controls.Add(this.AddCar_price_tb);
            this.panel3.Controls.Add(this.AddCar_model_tb);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.AddCar_pic_browse_btn);
            this.panel3.Controls.Add(this.AddCar_pb);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(224, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 204);
            this.panel3.TabIndex = 46;
            // 
            // AddCar_year_tb
            // 
            this.AddCar_year_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCar_year_tb.Location = new System.Drawing.Point(354, 99);
            this.AddCar_year_tb.Name = "AddCar_year_tb";
            this.AddCar_year_tb.Size = new System.Drawing.Size(220, 26);
            this.AddCar_year_tb.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(276, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 20);
            this.label12.TabIndex = 41;
            this.label12.Text = "Year";
            // 
            // AddCar_brand_tb
            // 
            this.AddCar_brand_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCar_brand_tb.Location = new System.Drawing.Point(354, 25);
            this.AddCar_brand_tb.Name = "AddCar_brand_tb";
            this.AddCar_brand_tb.Size = new System.Drawing.Size(220, 26);
            this.AddCar_brand_tb.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label11.Location = new System.Drawing.Point(14, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 48);
            this.label11.TabIndex = 39;
            this.label11.Text = "ADD \r\nNew Car";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addcar_btn
            // 
            this.addcar_btn.BackColor = System.Drawing.Color.ForestGreen;
            this.addcar_btn.FlatAppearance.BorderSize = 0;
            this.addcar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addcar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addcar_btn.ForeColor = System.Drawing.Color.White;
            this.addcar_btn.Location = new System.Drawing.Point(615, 106);
            this.addcar_btn.Name = "addcar_btn";
            this.addcar_btn.Size = new System.Drawing.Size(143, 40);
            this.addcar_btn.TabIndex = 26;
            this.addcar_btn.Text = "Add to Listing";
            this.addcar_btn.UseVisualStyleBackColor = false;
            this.addcar_btn.Click += new System.EventHandler(this.addcar_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.Gray;
            this.clear_btn.FlatAppearance.BorderSize = 0;
            this.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_btn.ForeColor = System.Drawing.Color.White;
            this.clear_btn.Location = new System.Drawing.Point(615, 36);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(143, 40);
            this.clear_btn.TabIndex = 26;
            this.clear_btn.Text = "Clear Fields";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // AddCar_price_tb
            // 
            this.AddCar_price_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCar_price_tb.Location = new System.Drawing.Point(354, 138);
            this.AddCar_price_tb.Name = "AddCar_price_tb";
            this.AddCar_price_tb.Size = new System.Drawing.Size(220, 26);
            this.AddCar_price_tb.TabIndex = 11;
            // 
            // AddCar_model_tb
            // 
            this.AddCar_model_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCar_model_tb.Location = new System.Drawing.Point(354, 62);
            this.AddCar_model_tb.Name = "AddCar_model_tb";
            this.AddCar_model_tb.Size = new System.Drawing.Size(220, 26);
            this.AddCar_model_tb.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(276, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(272, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Model";
            // 
            // AddCar_pic_browse_btn
            // 
            this.AddCar_pic_browse_btn.Location = new System.Drawing.Point(149, 162);
            this.AddCar_pic_browse_btn.Name = "AddCar_pic_browse_btn";
            this.AddCar_pic_browse_btn.Size = new System.Drawing.Size(75, 23);
            this.AddCar_pic_browse_btn.TabIndex = 5;
            this.AddCar_pic_browse_btn.Text = "Browse";
            this.AddCar_pic_browse_btn.UseVisualStyleBackColor = true;
            this.AddCar_pic_browse_btn.Click += new System.EventHandler(this.AddCar_pic_browse_btn_Click);
            // 
            // AddCar_pb
            // 
            this.AddCar_pb.Location = new System.Drawing.Point(121, 22);
            this.AddCar_pb.Name = "AddCar_pb";
            this.AddCar_pb.Size = new System.Drawing.Size(130, 130);
            this.AddCar_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddCar_pb.TabIndex = 4;
            this.AddCar_pb.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(271, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Brand";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.panel4.Controls.Add(this.UpCar_model_tb);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.Update_car_btn);
            this.panel4.Controls.Add(this.UpCar_pic_browse_btn);
            this.panel4.Controls.Add(this.UpCar_price_tb);
            this.panel4.Controls.Add(this.UpCar_pb);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.UpCar_status_cb);
            this.panel4.Controls.Add(this.UpCar_year_tb);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.UpCar_brand_tb);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(768, 204);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 525);
            this.panel4.TabIndex = 47;
            // 
            // UpCar_model_tb
            // 
            this.UpCar_model_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpCar_model_tb.Location = new System.Drawing.Point(14, 260);
            this.UpCar_model_tb.Name = "UpCar_model_tb";
            this.UpCar_model_tb.Size = new System.Drawing.Size(214, 26);
            this.UpCar_model_tb.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label9.Location = new System.Drawing.Point(10, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "Update Car Information";
            // 
            // Update_car_btn
            // 
            this.Update_car_btn.BackColor = System.Drawing.Color.ForestGreen;
            this.Update_car_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Update_car_btn.FlatAppearance.BorderSize = 0;
            this.Update_car_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_car_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_car_btn.ForeColor = System.Drawing.Color.White;
            this.Update_car_btn.Location = new System.Drawing.Point(0, 470);
            this.Update_car_btn.Name = "Update_car_btn";
            this.Update_car_btn.Size = new System.Drawing.Size(240, 55);
            this.Update_car_btn.TabIndex = 38;
            this.Update_car_btn.Text = "Update ";
            this.Update_car_btn.UseVisualStyleBackColor = false;
            this.Update_car_btn.Click += new System.EventHandler(this.Update_car_btn_Click);
            // 
            // UpCar_pic_browse_btn
            // 
            this.UpCar_pic_browse_btn.Location = new System.Drawing.Point(61, 138);
            this.UpCar_pic_browse_btn.Name = "UpCar_pic_browse_btn";
            this.UpCar_pic_browse_btn.Size = new System.Drawing.Size(108, 28);
            this.UpCar_pic_browse_btn.TabIndex = 30;
            this.UpCar_pic_browse_btn.Text = "Change Image";
            this.UpCar_pic_browse_btn.UseVisualStyleBackColor = true;
            this.UpCar_pic_browse_btn.Click += new System.EventHandler(this.UpCar_pic_browse_btn_Click);
            // 
            // UpCar_price_tb
            // 
            this.UpCar_price_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpCar_price_tb.Location = new System.Drawing.Point(14, 425);
            this.UpCar_price_tb.Name = "UpCar_price_tb";
            this.UpCar_price_tb.Size = new System.Drawing.Size(214, 26);
            this.UpCar_price_tb.TabIndex = 37;
            // 
            // UpCar_pb
            // 
            this.UpCar_pb.Location = new System.Drawing.Point(73, 51);
            this.UpCar_pb.Name = "UpCar_pb";
            this.UpCar_pb.Size = new System.Drawing.Size(80, 80);
            this.UpCar_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UpCar_pb.TabIndex = 26;
            this.UpCar_pb.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(87, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(87, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Status";
            // 
            // UpCar_status_cb
            // 
            this.UpCar_status_cb.FormattingEnabled = true;
            this.UpCar_status_cb.Items.AddRange(new object[] {
            "Available",
            "Sold",
            "Out of Stock",
            "Pre-order",
            "Unavailable"});
            this.UpCar_status_cb.Location = new System.Drawing.Point(14, 374);
            this.UpCar_status_cb.Name = "UpCar_status_cb";
            this.UpCar_status_cb.Size = new System.Drawing.Size(214, 21);
            this.UpCar_status_cb.TabIndex = 35;
            // 
            // UpCar_year_tb
            // 
            this.UpCar_year_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpCar_year_tb.Location = new System.Drawing.Point(14, 316);
            this.UpCar_year_tb.Name = "UpCar_year_tb";
            this.UpCar_year_tb.Size = new System.Drawing.Size(214, 26);
            this.UpCar_year_tb.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(87, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(87, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Model";
            // 
            // UpCar_brand_tb
            // 
            this.UpCar_brand_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpCar_brand_tb.Location = new System.Drawing.Point(14, 203);
            this.UpCar_brand_tb.Name = "UpCar_brand_tb";
            this.UpCar_brand_tb.Size = new System.Drawing.Size(214, 26);
            this.UpCar_brand_tb.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(87, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Brand";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(234, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(525, 454);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(434, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 49;
            this.label1.Text = "CARS LIST";
            // 
            // EmpInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.sidebar_panel);
            this.Name = "EmpInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmpInventory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmpInventory_FormClosed);
            this.sidebar_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddCar_pb)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpCar_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidebar_panel;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button Emp_Service_btn;
        private System.Windows.Forms.Button Emp_Sales_btn;
        private System.Windows.Forms.Button Emp_Customers_btn;
        private System.Windows.Forms.Button Emp_Inv_btn;
        private System.Windows.Forms.Button admin_dashboard_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label uname_l;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox AddCar_year_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox AddCar_brand_tb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button addcar_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.TextBox AddCar_price_tb;
        private System.Windows.Forms.TextBox AddCar_model_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddCar_pic_browse_btn;
        private System.Windows.Forms.PictureBox AddCar_pb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox UpCar_model_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Update_car_btn;
        private System.Windows.Forms.Button UpCar_pic_browse_btn;
        private System.Windows.Forms.TextBox UpCar_price_tb;
        private System.Windows.Forms.PictureBox UpCar_pb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox UpCar_status_cb;
        private System.Windows.Forms.TextBox UpCar_year_tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UpCar_brand_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}