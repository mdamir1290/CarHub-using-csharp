namespace CarHub.Employee
{
    partial class EmpService
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
            this.clear_btn = new System.Windows.Forms.Button();
            this.SerDesc_rtb = new System.Windows.Forms.RichTextBox();
            this.Ser_status_cb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SerID_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SerCar_pb = new System.Windows.Forms.PictureBox();
            this.Ser_cost_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.update_ser_btn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CarId_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sidebar_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sales_dgv)).BeginInit();
            this.UpdateEmp_P.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SerCar_pb)).BeginInit();
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
            this.Emp_Service_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(25)))));
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
            this.Emp_Service_btn.UseVisualStyleBackColor = false;
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
            this.Sales_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Sales_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Sales_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Sales_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Sales_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sales_dgv.EnableHeadersVisualStyles = false;
            this.Sales_dgv.GridColor = System.Drawing.Color.Black;
            this.Sales_dgv.Location = new System.Drawing.Point(231, 77);
            this.Sales_dgv.Name = "Sales_dgv";
            this.Sales_dgv.RowHeadersVisible = false;
            this.Sales_dgv.Size = new System.Drawing.Size(529, 642);
            this.Sales_dgv.TabIndex = 51;
            this.Sales_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Sales_dgv_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(419, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 52;
            this.label1.Text = "SERVICES LIST";
            // 
            // UpdateEmp_P
            // 
            this.UpdateEmp_P.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.UpdateEmp_P.Controls.Add(this.clear_btn);
            this.UpdateEmp_P.Controls.Add(this.SerDesc_rtb);
            this.UpdateEmp_P.Controls.Add(this.Ser_status_cb);
            this.UpdateEmp_P.Controls.Add(this.label7);
            this.UpdateEmp_P.Controls.Add(this.SerID_tb);
            this.UpdateEmp_P.Controls.Add(this.label4);
            this.UpdateEmp_P.Controls.Add(this.SerCar_pb);
            this.UpdateEmp_P.Controls.Add(this.Ser_cost_tb);
            this.UpdateEmp_P.Controls.Add(this.label2);
            this.UpdateEmp_P.Controls.Add(this.update_ser_btn);
            this.UpdateEmp_P.Controls.Add(this.label9);
            this.UpdateEmp_P.Controls.Add(this.label6);
            this.UpdateEmp_P.Controls.Add(this.CarId_tb);
            this.UpdateEmp_P.Controls.Add(this.label3);
            this.UpdateEmp_P.Dock = System.Windows.Forms.DockStyle.Right;
            this.UpdateEmp_P.Location = new System.Drawing.Point(768, 0);
            this.UpdateEmp_P.Name = "UpdateEmp_P";
            this.UpdateEmp_P.Size = new System.Drawing.Size(240, 729);
            this.UpdateEmp_P.TabIndex = 53;
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.clear_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clear_btn.FlatAppearance.BorderSize = 0;
            this.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.clear_btn.ForeColor = System.Drawing.Color.Black;
            this.clear_btn.Location = new System.Drawing.Point(0, 645);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(240, 42);
            this.clear_btn.TabIndex = 47;
            this.clear_btn.Text = "Clear Fields";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // SerDesc_rtb
            // 
            this.SerDesc_rtb.Location = new System.Drawing.Point(14, 382);
            this.SerDesc_rtb.Name = "SerDesc_rtb";
            this.SerDesc_rtb.Size = new System.Drawing.Size(213, 106);
            this.SerDesc_rtb.TabIndex = 46;
            this.SerDesc_rtb.Text = "";
            // 
            // Ser_status_cb
            // 
            this.Ser_status_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Ser_status_cb.FormattingEnabled = true;
            this.Ser_status_cb.Location = new System.Drawing.Point(13, 592);
            this.Ser_status_cb.Name = "Ser_status_cb";
            this.Ser_status_cb.Size = new System.Drawing.Size(214, 28);
            this.Ser_status_cb.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(66, 561);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "Service Status";
            // 
            // SerID_tb
            // 
            this.SerID_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SerID_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SerID_tb.ForeColor = System.Drawing.Color.White;
            this.SerID_tb.Location = new System.Drawing.Point(13, 261);
            this.SerID_tb.Name = "SerID_tb";
            this.SerID_tb.ReadOnly = true;
            this.SerID_tb.Size = new System.Drawing.Size(214, 26);
            this.SerID_tb.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(77, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "Service ID";
            // 
            // SerCar_pb
            // 
            this.SerCar_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SerCar_pb.Location = new System.Drawing.Point(41, 108);
            this.SerCar_pb.Name = "SerCar_pb";
            this.SerCar_pb.Size = new System.Drawing.Size(153, 109);
            this.SerCar_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SerCar_pb.TabIndex = 41;
            this.SerCar_pb.TabStop = false;
            // 
            // Ser_cost_tb
            // 
            this.Ser_cost_tb.BackColor = System.Drawing.Color.White;
            this.Ser_cost_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Ser_cost_tb.ForeColor = System.Drawing.Color.Black;
            this.Ser_cost_tb.Location = new System.Drawing.Point(14, 525);
            this.Ser_cost_tb.Name = "Ser_cost_tb";
            this.Ser_cost_tb.Size = new System.Drawing.Size(214, 26);
            this.Ser_cost_tb.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Service Total Cost";
            // 
            // update_ser_btn
            // 
            this.update_ser_btn.BackColor = System.Drawing.Color.ForestGreen;
            this.update_ser_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.update_ser_btn.FlatAppearance.BorderSize = 0;
            this.update_ser_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_ser_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.update_ser_btn.ForeColor = System.Drawing.Color.White;
            this.update_ser_btn.Location = new System.Drawing.Point(0, 687);
            this.update_ser_btn.Name = "update_ser_btn";
            this.update_ser_btn.Size = new System.Drawing.Size(240, 42);
            this.update_ser_btn.TabIndex = 27;
            this.update_ser_btn.Text = "Service Update";
            this.update_ser_btn.UseVisualStyleBackColor = false;
            this.update_ser_btn.Click += new System.EventHandler(this.update_ser_btn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label9.Location = new System.Drawing.Point(30, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "Service Execution";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(47, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Service Description";
            // 
            // CarId_tb
            // 
            this.CarId_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CarId_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CarId_tb.ForeColor = System.Drawing.Color.White;
            this.CarId_tb.Location = new System.Drawing.Point(14, 323);
            this.CarId_tb.Name = "CarId_tb";
            this.CarId_tb.Size = new System.Drawing.Size(214, 26);
            this.CarId_tb.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(91, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Car ID";
            // 
            // EmpService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.Sales_dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateEmp_P);
            this.Controls.Add(this.sidebar_panel);
            this.Name = "EmpService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmpService";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmpService_FormClosed);
            this.sidebar_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sales_dgv)).EndInit();
            this.UpdateEmp_P.ResumeLayout(false);
            this.UpdateEmp_P.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SerCar_pb)).EndInit();
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
        private System.Windows.Forms.PictureBox SerCar_pb;
        private System.Windows.Forms.TextBox Ser_cost_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button update_ser_btn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CarId_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SerID_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Ser_status_cb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.RichTextBox SerDesc_rtb;
    }
}