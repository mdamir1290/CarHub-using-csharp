namespace CarHub.Employee
{
    partial class EmployeeDashboard
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
            this.logout_btn = new System.Windows.Forms.Button();
            this.Emp_Service_btn = new System.Windows.Forms.Button();
            this.Emp_Sales_btn = new System.Windows.Forms.Button();
            this.Emp_Customers_btn = new System.Windows.Forms.Button();
            this.Emp_Inv_btn = new System.Windows.Forms.Button();
            this.admin_dashboard_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uname_l = new System.Windows.Forms.Label();
            this.sidebar_panel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.Emp_balance_lb = new System.Windows.Forms.Label();
            this.emp_balance_wd_btn = new System.Windows.Forms.Button();
            this.Add_customer_btn = new System.Windows.Forms.Button();
            this.QuickSell_btn = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.EmployeeCount_p = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ServiceCount_lb = new System.Windows.Forms.Label();
            this.SellsCount_p = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.SalesTodayCount_lb = new System.Windows.Forms.Label();
            this.CarCount_p = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CarCount_lb = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Services_dgv = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Sales_dgv = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.sidebar_panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.EmployeeCount_p.SuspendLayout();
            this.SellsCount_p.SuspendLayout();
            this.CarCount_p.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Services_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sales_dgv)).BeginInit();
            this.SuspendLayout();
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
            this.Emp_Inv_btn.UseVisualStyleBackColor = true;
            this.Emp_Inv_btn.Click += new System.EventHandler(this.Emp_Inv_btn_Click);
            // 
            // admin_dashboard_btn
            // 
            this.admin_dashboard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(25)))));
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
            this.admin_dashboard_btn.UseVisualStyleBackColor = false;
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
            this.uname_l.Location = new System.Drawing.Point(37, 38);
            this.uname_l.Name = "uname_l";
            this.uname_l.Size = new System.Drawing.Size(154, 26);
            this.uname_l.TabIndex = 0;
            this.uname_l.Text = "Employee Portal";
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
            this.sidebar_panel.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.Add_customer_btn);
            this.panel4.Controls.Add(this.QuickSell_btn);
            this.panel4.Controls.Add(this.monthCalendar1);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(768, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 729);
            this.panel4.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Bisque;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.Emp_balance_lb);
            this.panel2.Controls.Add(this.emp_balance_wd_btn);
            this.panel2.Location = new System.Drawing.Point(25, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 136);
            this.panel2.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Brown;
            this.label7.Location = new System.Drawing.Point(59, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Balance";
            // 
            // Emp_balance_lb
            // 
            this.Emp_balance_lb.AutoSize = true;
            this.Emp_balance_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emp_balance_lb.ForeColor = System.Drawing.Color.Brown;
            this.Emp_balance_lb.Location = new System.Drawing.Point(4, 40);
            this.Emp_balance_lb.Name = "Emp_balance_lb";
            this.Emp_balance_lb.Size = new System.Drawing.Size(55, 37);
            this.Emp_balance_lb.TabIndex = 4;
            this.Emp_balance_lb.Text = "45";
            // 
            // emp_balance_wd_btn
            // 
            this.emp_balance_wd_btn.BackColor = System.Drawing.Color.LimeGreen;
            this.emp_balance_wd_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.emp_balance_wd_btn.FlatAppearance.BorderSize = 0;
            this.emp_balance_wd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emp_balance_wd_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_balance_wd_btn.ForeColor = System.Drawing.Color.Black;
            this.emp_balance_wd_btn.Location = new System.Drawing.Point(0, 86);
            this.emp_balance_wd_btn.Name = "emp_balance_wd_btn";
            this.emp_balance_wd_btn.Padding = new System.Windows.Forms.Padding(10);
            this.emp_balance_wd_btn.Size = new System.Drawing.Size(200, 50);
            this.emp_balance_wd_btn.TabIndex = 29;
            this.emp_balance_wd_btn.Text = "Withdraw Balance";
            this.emp_balance_wd_btn.UseVisualStyleBackColor = false;
            this.emp_balance_wd_btn.Click += new System.EventHandler(this.emp_balance_wd_btn_Click);
            // 
            // Add_customer_btn
            // 
            this.Add_customer_btn.BackColor = System.Drawing.Color.DarkOrange;
            this.Add_customer_btn.FlatAppearance.BorderSize = 0;
            this.Add_customer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_customer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_customer_btn.ForeColor = System.Drawing.Color.Black;
            this.Add_customer_btn.Location = new System.Drawing.Point(22, 573);
            this.Add_customer_btn.Name = "Add_customer_btn";
            this.Add_customer_btn.Padding = new System.Windows.Forms.Padding(10);
            this.Add_customer_btn.Size = new System.Drawing.Size(200, 60);
            this.Add_customer_btn.TabIndex = 29;
            this.Add_customer_btn.Text = "Add Customer";
            this.Add_customer_btn.UseVisualStyleBackColor = false;
            this.Add_customer_btn.Click += new System.EventHandler(this.Add_customer_btn_Click);
            // 
            // QuickSell_btn
            // 
            this.QuickSell_btn.BackColor = System.Drawing.Color.DarkOrange;
            this.QuickSell_btn.FlatAppearance.BorderSize = 0;
            this.QuickSell_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuickSell_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickSell_btn.ForeColor = System.Drawing.Color.Black;
            this.QuickSell_btn.Location = new System.Drawing.Point(22, 490);
            this.QuickSell_btn.Name = "QuickSell_btn";
            this.QuickSell_btn.Padding = new System.Windows.Forms.Padding(10);
            this.QuickSell_btn.Size = new System.Drawing.Size(200, 60);
            this.QuickSell_btn.TabIndex = 28;
            this.QuickSell_btn.Text = "Quick Sell";
            this.QuickSell_btn.UseVisualStyleBackColor = false;
            this.QuickSell_btn.Click += new System.EventHandler(this.QuickSell_btn_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(8, 273);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label9.Location = new System.Drawing.Point(59, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "Quick Access";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(439, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Workspace";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CadetBlue;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.EmployeeCount_p);
            this.panel3.Controls.Add(this.SellsCount_p);
            this.panel3.Controls.Add(this.CarCount_p);
            this.panel3.Location = new System.Drawing.Point(230, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 194);
            this.panel3.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(180, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 24);
            this.label11.TabIndex = 42;
            this.label11.Text = "Daily Operations";
            // 
            // EmployeeCount_p
            // 
            this.EmployeeCount_p.BackColor = System.Drawing.Color.Purple;
            this.EmployeeCount_p.Controls.Add(this.label2);
            this.EmployeeCount_p.Controls.Add(this.ServiceCount_lb);
            this.EmployeeCount_p.Location = new System.Drawing.Point(364, 75);
            this.EmployeeCount_p.Name = "EmployeeCount_p";
            this.EmployeeCount_p.Size = new System.Drawing.Size(150, 100);
            this.EmployeeCount_p.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "In Service";
            // 
            // ServiceCount_lb
            // 
            this.ServiceCount_lb.AutoSize = true;
            this.ServiceCount_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceCount_lb.ForeColor = System.Drawing.Color.White;
            this.ServiceCount_lb.Location = new System.Drawing.Point(49, 13);
            this.ServiceCount_lb.Name = "ServiceCount_lb";
            this.ServiceCount_lb.Size = new System.Drawing.Size(55, 37);
            this.ServiceCount_lb.TabIndex = 2;
            this.ServiceCount_lb.Text = "45";
            // 
            // SellsCount_p
            // 
            this.SellsCount_p.BackColor = System.Drawing.Color.Green;
            this.SellsCount_p.Controls.Add(this.label4);
            this.SellsCount_p.Controls.Add(this.SalesTodayCount_lb);
            this.SellsCount_p.Location = new System.Drawing.Point(190, 75);
            this.SellsCount_p.Name = "SellsCount_p";
            this.SellsCount_p.Size = new System.Drawing.Size(150, 100);
            this.SellsCount_p.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sales Today";
            // 
            // SalesTodayCount_lb
            // 
            this.SalesTodayCount_lb.AutoSize = true;
            this.SalesTodayCount_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesTodayCount_lb.ForeColor = System.Drawing.Color.White;
            this.SalesTodayCount_lb.Location = new System.Drawing.Point(46, 13);
            this.SalesTodayCount_lb.Name = "SalesTodayCount_lb";
            this.SalesTodayCount_lb.Size = new System.Drawing.Size(55, 37);
            this.SalesTodayCount_lb.TabIndex = 2;
            this.SalesTodayCount_lb.Text = "45";
            // 
            // CarCount_p
            // 
            this.CarCount_p.BackColor = System.Drawing.Color.RoyalBlue;
            this.CarCount_p.Controls.Add(this.label5);
            this.CarCount_p.Controls.Add(this.CarCount_lb);
            this.CarCount_p.Location = new System.Drawing.Point(18, 75);
            this.CarCount_p.Name = "CarCount_p";
            this.CarCount_p.Size = new System.Drawing.Size(150, 100);
            this.CarCount_p.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(22, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Available Cars";
            // 
            // CarCount_lb
            // 
            this.CarCount_lb.AutoSize = true;
            this.CarCount_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarCount_lb.ForeColor = System.Drawing.Color.White;
            this.CarCount_lb.Location = new System.Drawing.Point(45, 13);
            this.CarCount_lb.Name = "CarCount_lb";
            this.CarCount_lb.Size = new System.Drawing.Size(55, 37);
            this.CarCount_lb.TabIndex = 2;
            this.CarCount_lb.Text = "45";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CadetBlue;
            this.panel5.Controls.Add(this.Services_dgv);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.Sales_dgv);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Location = new System.Drawing.Point(230, 280);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(532, 437);
            this.panel5.TabIndex = 44;
            // 
            // Services_dgv
            // 
            this.Services_dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Services_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Services_dgv.Location = new System.Drawing.Point(18, 259);
            this.Services_dgv.Name = "Services_dgv";
            this.Services_dgv.Size = new System.Drawing.Size(496, 170);
            this.Services_dgv.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(195, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 24);
            this.label3.TabIndex = 45;
            this.label3.Text = "Services Log";
            // 
            // Sales_dgv
            // 
            this.Sales_dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Sales_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Sales_dgv.Location = new System.Drawing.Point(18, 44);
            this.Sales_dgv.Name = "Sales_dgv";
            this.Sales_dgv.Size = new System.Drawing.Size(496, 170);
            this.Sales_dgv.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(208, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 24);
            this.label12.TabIndex = 43;
            this.label12.Text = "Sales Log";
            // 
            // EmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sidebar_panel);
            this.Name = "EmployeeDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeDashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeDashboard_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sidebar_panel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.EmployeeCount_p.ResumeLayout(false);
            this.EmployeeCount_p.PerformLayout();
            this.SellsCount_p.ResumeLayout(false);
            this.SellsCount_p.PerformLayout();
            this.CarCount_p.ResumeLayout(false);
            this.CarCount_p.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Services_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sales_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button Emp_Service_btn;
        private System.Windows.Forms.Button Emp_Sales_btn;
        private System.Windows.Forms.Button Emp_Customers_btn;
        private System.Windows.Forms.Button Emp_Inv_btn;
        private System.Windows.Forms.Button admin_dashboard_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label uname_l;
        private System.Windows.Forms.Panel sidebar_panel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Add_customer_btn;
        private System.Windows.Forms.Button QuickSell_btn;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Emp_balance_lb;
        private System.Windows.Forms.Button emp_balance_wd_btn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel EmployeeCount_p;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ServiceCount_lb;
        private System.Windows.Forms.Panel SellsCount_p;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SalesTodayCount_lb;
        private System.Windows.Forms.Panel CarCount_p;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CarCount_lb;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView Services_dgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Sales_dgv;
        private System.Windows.Forms.Label label12;
    }
}