namespace CarHub.Employee
{
    partial class EmpSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sidebar_panel = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.Emp_Service_btn = new System.Windows.Forms.Button();
            this.Emp_Sales_btn = new System.Windows.Forms.Button();
            this.Emp_Customers_btn = new System.Windows.Forms.Button();
            this.Emp_Inv_btn = new System.Windows.Forms.Button();
            this.admin_dashboard_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uname_l = new System.Windows.Forms.Label();
            this.Sales_dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateEmp_P = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Order_offerP_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Confirm_Sell_btn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Cancel_sell_btn = new System.Windows.Forms.Button();
            this.Order_cus_name_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Order_id_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sidebar_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sales_dgv)).BeginInit();
            this.UpdateEmp_P.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.sidebar_panel.TabIndex = 47;
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
            this.Emp_Sales_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(25)))));
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
            this.Emp_Sales_btn.UseVisualStyleBackColor = false;
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
            this.uname_l.Location = new System.Drawing.Point(47, 38);
            this.uname_l.Name = "uname_l";
            this.uname_l.Size = new System.Drawing.Size(108, 26);
            this.uname_l.TabIndex = 0;
            this.uname_l.Text = "Staff Portal";
            // 
            // Sales_dgv
            // 
            this.Sales_dgv.AllowUserToAddRows = false;
            this.Sales_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Sales_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Sales_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Sales_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Sales_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Sales_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sales_dgv.EnableHeadersVisualStyles = false;
            this.Sales_dgv.Location = new System.Drawing.Point(234, 98);
            this.Sales_dgv.MultiSelect = false;
            this.Sales_dgv.Name = "Sales_dgv";
            this.Sales_dgv.ReadOnly = true;
            this.Sales_dgv.RowHeadersVisible = false;
            this.Sales_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Sales_dgv.Size = new System.Drawing.Size(522, 597);
            this.Sales_dgv.TabIndex = 7;
            this.Sales_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Sales_dgv_CellClick);
            //
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(381, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 24);
            this.label1.TabIndex = 49;
            this.label1.Text = "SALES MANAGEMENT";
            // 
            // UpdateEmp_P
            // 
            this.UpdateEmp_P.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.UpdateEmp_P.Controls.Add(this.pictureBox1);
            this.UpdateEmp_P.Controls.Add(this.Order_offerP_tb);
            this.UpdateEmp_P.Controls.Add(this.label2);
            this.UpdateEmp_P.Controls.Add(this.Confirm_Sell_btn);
            this.UpdateEmp_P.Controls.Add(this.label9);
            this.UpdateEmp_P.Controls.Add(this.Cancel_sell_btn);
            this.UpdateEmp_P.Controls.Add(this.Order_cus_name_tb);
            this.UpdateEmp_P.Controls.Add(this.label6);
            this.UpdateEmp_P.Controls.Add(this.Order_id_tb);
            this.UpdateEmp_P.Controls.Add(this.label3);
            this.UpdateEmp_P.Dock = System.Windows.Forms.DockStyle.Right;
            this.UpdateEmp_P.Location = new System.Drawing.Point(768, 0);
            this.UpdateEmp_P.Name = "UpdateEmp_P";
            this.UpdateEmp_P.Size = new System.Drawing.Size(240, 729);
            this.UpdateEmp_P.TabIndex = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(41, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // Order_offerP_tb
            // 
            this.Order_offerP_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Order_offerP_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Order_offerP_tb.ForeColor = System.Drawing.Color.White;
            this.Order_offerP_tb.Location = new System.Drawing.Point(14, 442);
            this.Order_offerP_tb.Name = "Order_offerP_tb";
            this.Order_offerP_tb.ReadOnly = true;
            this.Order_offerP_tb.Size = new System.Drawing.Size(214, 26);
            this.Order_offerP_tb.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(67, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Offered Price";
            // 
            // Confirm_Sell_btn
            // 
            this.Confirm_Sell_btn.BackColor = System.Drawing.Color.ForestGreen;
            this.Confirm_Sell_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Confirm_Sell_btn.FlatAppearance.BorderSize = 0;
            this.Confirm_Sell_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirm_Sell_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Confirm_Sell_btn.ForeColor = System.Drawing.Color.White;
            this.Confirm_Sell_btn.Location = new System.Drawing.Point(0, 624);
            this.Confirm_Sell_btn.Name = "Confirm_Sell_btn";
            this.Confirm_Sell_btn.Size = new System.Drawing.Size(240, 50);
            this.Confirm_Sell_btn.TabIndex = 27;
            this.Confirm_Sell_btn.Text = "Confirm Order";
            this.Confirm_Sell_btn.UseVisualStyleBackColor = false;
            this.Confirm_Sell_btn.Click += new System.EventHandler(this.Confirm_Sell_btn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label9.Location = new System.Drawing.Point(43, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "Order Execution";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cancel_sell_btn
            // 
            this.Cancel_sell_btn.BackColor = System.Drawing.Color.Firebrick;
            this.Cancel_sell_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Cancel_sell_btn.FlatAppearance.BorderSize = 0;
            this.Cancel_sell_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_sell_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_sell_btn.ForeColor = System.Drawing.Color.White;
            this.Cancel_sell_btn.Location = new System.Drawing.Point(0, 674);
            this.Cancel_sell_btn.Name = "Cancel_sell_btn";
            this.Cancel_sell_btn.Size = new System.Drawing.Size(240, 55);
            this.Cancel_sell_btn.TabIndex = 38;
            this.Cancel_sell_btn.Text = "Cancel Order";
            this.Cancel_sell_btn.UseVisualStyleBackColor = false;
            this.Cancel_sell_btn.Click += new System.EventHandler(this.Cancel_sell_btn_Click);
            // 
            // Order_cus_name_tb
            // 
            this.Order_cus_name_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Order_cus_name_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Order_cus_name_tb.ForeColor = System.Drawing.Color.White;
            this.Order_cus_name_tb.Location = new System.Drawing.Point(14, 359);
            this.Order_cus_name_tb.Name = "Order_cus_name_tb";
            this.Order_cus_name_tb.ReadOnly = true;
            this.Order_cus_name_tb.Size = new System.Drawing.Size(214, 26);
            this.Order_cus_name_tb.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(58, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Customer Name";
            // 
            // Order_id_tb
            // 
            this.Order_id_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Order_id_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Order_id_tb.ForeColor = System.Drawing.Color.White;
            this.Order_id_tb.Location = new System.Drawing.Point(14, 278);
            this.Order_id_tb.Name = "Order_id_tb";
            this.Order_id_tb.ReadOnly = true;
            this.Order_id_tb.Size = new System.Drawing.Size(214, 26);
            this.Order_id_tb.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(79, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Order ID";
            // 
            // EmpSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.Sales_dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateEmp_P);
            this.Controls.Add(this.sidebar_panel);
            this.Name = "EmpSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmpSales";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmpSales_FormClosed);
            this.sidebar_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sales_dgv)).EndInit();
            this.UpdateEmp_P.ResumeLayout(false);
            this.UpdateEmp_P.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.DataGridView Sales_dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel UpdateEmp_P;
        private System.Windows.Forms.Button Confirm_Sell_btn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Order_cus_name_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Order_id_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Order_offerP_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Cancel_sell_btn;
    }
}