namespace CarHub.Customer
{
    partial class CustomerAnalytics
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.sidebar_panel = new System.Windows.Forms.Panel();
            this.User_analytics_btn = new System.Windows.Forms.Button();
            this.CusProfile_btn = new System.Windows.Forms.Button();
            this.logout_btn = new System.Windows.Forms.Button();
            this.CusBookService_btn = new System.Windows.Forms.Button();
            this.CusBuyCar_btn = new System.Windows.Forms.Button();
            this.cus_gar_btn = new System.Windows.Forms.Button();
            this.cus_dashboard_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uname_l = new System.Windows.Forms.Label();
            this.carorder_dgv = new System.Windows.Forms.DataGridView();
            this.sert_dgv = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carorder_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sert_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebar_panel
            // 
            this.sidebar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sidebar_panel.Controls.Add(this.User_analytics_btn);
            this.sidebar_panel.Controls.Add(this.CusProfile_btn);
            this.sidebar_panel.Controls.Add(this.logout_btn);
            this.sidebar_panel.Controls.Add(this.CusBookService_btn);
            this.sidebar_panel.Controls.Add(this.CusBuyCar_btn);
            this.sidebar_panel.Controls.Add(this.cus_gar_btn);
            this.sidebar_panel.Controls.Add(this.cus_dashboard_btn);
            this.sidebar_panel.Controls.Add(this.panel1);
            this.sidebar_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar_panel.Location = new System.Drawing.Point(0, 0);
            this.sidebar_panel.Name = "sidebar_panel";
            this.sidebar_panel.Size = new System.Drawing.Size(224, 729);
            this.sidebar_panel.TabIndex = 54;
            // 
            // User_analytics_btn
            // 
            this.User_analytics_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(25)))));
            this.User_analytics_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.User_analytics_btn.FlatAppearance.BorderSize = 0;
            this.User_analytics_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.User_analytics_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.User_analytics_btn.ForeColor = System.Drawing.Color.White;
            this.User_analytics_btn.Location = new System.Drawing.Point(0, 400);
            this.User_analytics_btn.Name = "User_analytics_btn";
            this.User_analytics_btn.Padding = new System.Windows.Forms.Padding(10);
            this.User_analytics_btn.Size = new System.Drawing.Size(224, 60);
            this.User_analytics_btn.TabIndex = 6;
            this.User_analytics_btn.Text = "Analytics";
            this.User_analytics_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.User_analytics_btn.UseVisualStyleBackColor = false;
            this.User_analytics_btn.Click += new System.EventHandler(this.User_analytics_btn_Click);
            // 
            // CusProfile_btn
            // 
            this.CusProfile_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CusProfile_btn.FlatAppearance.BorderSize = 0;
            this.CusProfile_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CusProfile_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CusProfile_btn.ForeColor = System.Drawing.Color.White;
            this.CusProfile_btn.Location = new System.Drawing.Point(0, 340);
            this.CusProfile_btn.Name = "CusProfile_btn";
            this.CusProfile_btn.Padding = new System.Windows.Forms.Padding(10);
            this.CusProfile_btn.Size = new System.Drawing.Size(224, 60);
            this.CusProfile_btn.TabIndex = 5;
            this.CusProfile_btn.Text = "Profile";
            this.CusProfile_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CusProfile_btn.Click += new System.EventHandler(this.CusProfile_btn_Click);
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.Firebrick;
            this.logout_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Location = new System.Drawing.Point(0, 669);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(224, 60);
            this.logout_btn.TabIndex = 0;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // CusBookService_btn
            // 
            this.CusBookService_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CusBookService_btn.FlatAppearance.BorderSize = 0;
            this.CusBookService_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CusBookService_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CusBookService_btn.ForeColor = System.Drawing.Color.White;
            this.CusBookService_btn.Location = new System.Drawing.Point(0, 280);
            this.CusBookService_btn.Name = "CusBookService_btn";
            this.CusBookService_btn.Padding = new System.Windows.Forms.Padding(10);
            this.CusBookService_btn.Size = new System.Drawing.Size(224, 60);
            this.CusBookService_btn.TabIndex = 1;
            this.CusBookService_btn.Text = "Book Services";
            this.CusBookService_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CusBookService_btn.Click += new System.EventHandler(this.CusBookService_btn_Click);
            // 
            // CusBuyCar_btn
            // 
            this.CusBuyCar_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CusBuyCar_btn.FlatAppearance.BorderSize = 0;
            this.CusBuyCar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CusBuyCar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CusBuyCar_btn.ForeColor = System.Drawing.Color.White;
            this.CusBuyCar_btn.Location = new System.Drawing.Point(0, 220);
            this.CusBuyCar_btn.Name = "CusBuyCar_btn";
            this.CusBuyCar_btn.Padding = new System.Windows.Forms.Padding(10);
            this.CusBuyCar_btn.Size = new System.Drawing.Size(224, 60);
            this.CusBuyCar_btn.TabIndex = 2;
            this.CusBuyCar_btn.Text = "Buy Cars";
            this.CusBuyCar_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CusBuyCar_btn.Click += new System.EventHandler(this.CusBuyCar_btn_Click);
            // 
            // cus_gar_btn
            // 
            this.cus_gar_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.cus_gar_btn.FlatAppearance.BorderSize = 0;
            this.cus_gar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cus_gar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cus_gar_btn.ForeColor = System.Drawing.Color.White;
            this.cus_gar_btn.Location = new System.Drawing.Point(0, 160);
            this.cus_gar_btn.Name = "cus_gar_btn";
            this.cus_gar_btn.Padding = new System.Windows.Forms.Padding(10);
            this.cus_gar_btn.Size = new System.Drawing.Size(224, 60);
            this.cus_gar_btn.TabIndex = 3;
            this.cus_gar_btn.Text = "Garage";
            this.cus_gar_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cus_gar_btn.Click += new System.EventHandler(this.cus_gar_btn_Click);
            // 
            // cus_dashboard_btn
            // 
            this.cus_dashboard_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.cus_dashboard_btn.FlatAppearance.BorderSize = 0;
            this.cus_dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cus_dashboard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cus_dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.cus_dashboard_btn.Location = new System.Drawing.Point(0, 100);
            this.cus_dashboard_btn.Name = "cus_dashboard_btn";
            this.cus_dashboard_btn.Padding = new System.Windows.Forms.Padding(10);
            this.cus_dashboard_btn.Size = new System.Drawing.Size(224, 60);
            this.cus_dashboard_btn.TabIndex = 4;
            this.cus_dashboard_btn.Text = "Dashboard";
            this.cus_dashboard_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cus_dashboard_btn.Click += new System.EventHandler(this.cus_dashboard_btn_Click);
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
            this.uname_l.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.uname_l.ForeColor = System.Drawing.Color.White;
            this.uname_l.Location = new System.Drawing.Point(36, 38);
            this.uname_l.Name = "uname_l";
            this.uname_l.Size = new System.Drawing.Size(151, 26);
            this.uname_l.TabIndex = 0;
            this.uname_l.Text = "Customer Portal";
            // 
            // carorder_dgv
            // 
            this.carorder_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carorder_dgv.Location = new System.Drawing.Point(286, 75);
            this.carorder_dgv.Name = "carorder_dgv";
            this.carorder_dgv.Size = new System.Drawing.Size(633, 254);
            this.carorder_dgv.TabIndex = 55;
            // 
            // sert_dgv
            // 
            this.sert_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sert_dgv.Location = new System.Drawing.Point(286, 400);
            this.sert_dgv.Name = "sert_dgv";
            this.sert_dgv.Size = new System.Drawing.Size(633, 273);
            this.sert_dgv.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(500, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 24);
            this.label4.TabIndex = 66;
            this.label4.Text = "Service History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(500, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 67;
            this.label1.Text = "Car Order History";
            // 
            // CustomerAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sert_dgv);
            this.Controls.Add(this.carorder_dgv);
            this.Controls.Add(this.sidebar_panel);
            this.Name = "CustomerAnalytics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerAnalytics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerAnalytics_FormClosed);
            this.sidebar_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carorder_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sert_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidebar_panel;
        private System.Windows.Forms.Button User_analytics_btn;
        private System.Windows.Forms.Button CusProfile_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button CusBookService_btn;
        private System.Windows.Forms.Button CusBuyCar_btn;
        private System.Windows.Forms.Button cus_gar_btn;
        private System.Windows.Forms.Button cus_dashboard_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label uname_l;
        private System.Windows.Forms.DataGridView carorder_dgv;
        private System.Windows.Forms.DataGridView sert_dgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}