namespace DoAnCKver1
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.TabPage tabOrderHistory;
        private System.Windows.Forms.TabPage tabInvoiceDetails;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabWarranty;

        private System.Windows.Forms.Button btnShowPassword;

        private System.Windows.Forms.Button btnOrderProduct;
        private System.Windows.Forms.Button btnViewProductDetail;
        private System.Windows.Forms.Button btnApplyVoucher;

        private System.Windows.Forms.Button btnViewOrderDetail;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnReviewProduct;

        private System.Windows.Forms.Button btnViewInvoiceDetail;
        private System.Windows.Forms.Button btnPrintInvoice;

        private System.Windows.Forms.Button btnViewWarrantyDetail;
        private System.Windows.Forms.Button btnRequestWarranty;

        // Personal Info controls
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnChangeAddress;
        private System.Windows.Forms.Button btnLogout;

        // Order History
        private System.Windows.Forms.DataGridView dgvOrderHistory;
        private System.Windows.Forms.Panel panelOrderHistory;

        // Invoice Details
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.Panel panelInvoiceDetails;

        // Products
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panelProducts;

        // Warranty
        private System.Windows.Forms.DataGridView dgvWarranty;
        private System.Windows.Forms.Panel panelWarranty;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Load += CustomerForm_Load;

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnChangeAddress = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnShowPassword = new System.Windows.Forms.Button();

            this.tabOrderHistory = new System.Windows.Forms.TabPage();
            this.panelOrderHistory = new System.Windows.Forms.Panel();
            this.dgvOrderHistory = new System.Windows.Forms.DataGridView();
            this.btnViewOrderDetail = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnReviewProduct = new System.Windows.Forms.Button();

            this.tabInvoiceDetails = new System.Windows.Forms.TabPage();
            this.panelInvoiceDetails = new System.Windows.Forms.Panel();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.btnViewInvoiceDetail = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();

            this.tabProducts = new System.Windows.Forms.TabPage();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnOrderProduct = new System.Windows.Forms.Button();
            this.btnViewProductDetail = new System.Windows.Forms.Button();
            this.btnApplyVoucher = new System.Windows.Forms.Button();

            this.tabWarranty = new System.Windows.Forms.TabPage();
            this.panelWarranty = new System.Windows.Forms.Panel();
            this.dgvWarranty = new System.Windows.Forms.DataGridView();
            this.btnViewWarrantyDetail = new System.Windows.Forms.Button();
            this.btnRequestWarranty = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tabOrderHistory.SuspendLayout();
            this.panelOrderHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).BeginInit();
            this.tabInvoiceDetails.SuspendLayout();
            this.panelInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.tabProducts.SuspendLayout();
            this.panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabWarranty.SuspendLayout();
            this.panelWarranty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranty)).BeginInit();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabPersonalInfo);
            this.tabControl.Controls.Add(this.tabOrderHistory);
            this.tabControl.Controls.Add(this.tabInvoiceDetails);
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Controls.Add(this.tabWarranty);
            this.tabControl.Location = new System.Drawing.Point(12, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(981, 617);
            this.tabControl.TabIndex = 0;

            // tabPersonalInfo
            this.tabPersonalInfo.Controls.Add(this.lblUsername);
            this.tabPersonalInfo.Controls.Add(this.txtUsername);
            this.tabPersonalInfo.Controls.Add(this.lblAccount);
            this.tabPersonalInfo.Controls.Add(this.txtAccount);
            this.tabPersonalInfo.Controls.Add(this.lblPassword);
            this.tabPersonalInfo.Controls.Add(this.txtPassword);
            this.tabPersonalInfo.Controls.Add(this.lblAddress);
            this.tabPersonalInfo.Controls.Add(this.txtAddress);
            this.tabPersonalInfo.Controls.Add(this.btnChangeAddress);
            this.tabPersonalInfo.Controls.Add(this.btnLogout);
            this.tabPersonalInfo.Controls.Add(this.btnShowPassword);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Size = new System.Drawing.Size(973, 591);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";

            // Personal Info controls
            this.lblUsername.Location = new System.Drawing.Point(40, 40);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";

            this.txtUsername.Location = new System.Drawing.Point(150, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(250, 20);
            this.txtUsername.TabIndex = 1;

            this.lblAccount.Location = new System.Drawing.Point(40, 80);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(100, 23);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "Account:";

            this.txtAccount.Location = new System.Drawing.Point(150, 80);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(250, 20);
            this.txtAccount.TabIndex = 3;

            this.lblPassword.Location = new System.Drawing.Point(40, 120);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";

            this.txtPassword.Location = new System.Drawing.Point(150, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;

            this.btnShowPassword.Location = new System.Drawing.Point(410, 120);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(60, 22);
            this.btnShowPassword.TabIndex = 10;
            this.btnShowPassword.Text = "Hiện";
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);

            this.lblAddress.Location = new System.Drawing.Point(40, 160);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address:";

            this.txtAddress.Location = new System.Drawing.Point(150, 160);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 20);
            this.txtAddress.TabIndex = 7;

            this.btnChangeAddress.Location = new System.Drawing.Point(420, 160);
            this.btnChangeAddress.Name = "btnChangeAddress";
            this.btnChangeAddress.Size = new System.Drawing.Size(120, 25);
            this.btnChangeAddress.TabIndex = 8;
            this.btnChangeAddress.Text = "Change Address";
            this.btnChangeAddress.Click += new System.EventHandler(this.btnChangeAddress_Click);

            this.btnLogout.Location = new System.Drawing.Point(150, 210);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // tabOrderHistory
            this.tabOrderHistory.Controls.Add(this.panelOrderHistory);
            this.tabOrderHistory.Controls.Add(this.btnViewOrderDetail);
            this.tabOrderHistory.Controls.Add(this.btnCancelOrder);
            this.tabOrderHistory.Controls.Add(this.btnReviewProduct);
            this.tabOrderHistory.Location = new System.Drawing.Point(4, 22);
            this.tabOrderHistory.Name = "tabOrderHistory";
            this.tabOrderHistory.Size = new System.Drawing.Size(973, 591);
            this.tabOrderHistory.TabIndex = 1;
            this.tabOrderHistory.Text = "Order History";

            // panelOrderHistory
            this.panelOrderHistory.Location = new System.Drawing.Point(0, 0);
            this.panelOrderHistory.Size = new System.Drawing.Size(973, 500);
            this.panelOrderHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelOrderHistory.Controls.Add(this.dgvOrderHistory);

            // dgvOrderHistory
            this.dgvOrderHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderHistory.Name = "dgvOrderHistory";
            this.dgvOrderHistory.Size = new System.Drawing.Size(973, 500);
            this.dgvOrderHistory.TabIndex = 0;

            // Buttons OrderHistory
            this.btnViewOrderDetail.Location = new System.Drawing.Point(20, 520);
            this.btnViewOrderDetail.Name = "btnViewOrderDetail";
            this.btnViewOrderDetail.Size = new System.Drawing.Size(100, 30);
            this.btnViewOrderDetail.TabIndex = 1;
            this.btnViewOrderDetail.Text = "Xem chi tiết";
            this.btnViewOrderDetail.Click += new System.EventHandler(this.btnViewOrderDetail_Click);

            this.btnCancelOrder.Location = new System.Drawing.Point(140, 520);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(100, 30);
            this.btnCancelOrder.TabIndex = 2;
            this.btnCancelOrder.Text = "Hủy đơn";
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);

            this.btnReviewProduct.Location = new System.Drawing.Point(260, 520);
            this.btnReviewProduct.Name = "btnReviewProduct";
            this.btnReviewProduct.Size = new System.Drawing.Size(140, 30);
            this.btnReviewProduct.TabIndex = 3;
            this.btnReviewProduct.Text = "Đánh giá sản phẩm";
            this.btnReviewProduct.Click += new System.EventHandler(this.btnReviewProduct_Click);

            // tabInvoiceDetails
            this.tabInvoiceDetails.Controls.Add(this.panelInvoiceDetails);
            this.tabInvoiceDetails.Controls.Add(this.btnViewInvoiceDetail);
            this.tabInvoiceDetails.Controls.Add(this.btnPrintInvoice);
            this.tabInvoiceDetails.Location = new System.Drawing.Point(4, 22);
            this.tabInvoiceDetails.Name = "tabInvoiceDetails";
            this.tabInvoiceDetails.Size = new System.Drawing.Size(973, 591);
            this.tabInvoiceDetails.TabIndex = 2;
            this.tabInvoiceDetails.Text = "Invoice Details";

            // panelInvoiceDetails
            this.panelInvoiceDetails.Location = new System.Drawing.Point(0, 0);
            this.panelInvoiceDetails.Size = new System.Drawing.Size(973, 500);
            this.panelInvoiceDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelInvoiceDetails.Controls.Add(this.dgvInvoiceDetails);

            // dgvInvoiceDetails
            this.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(973, 500);
            this.dgvInvoiceDetails.TabIndex = 0;

            // Buttons InvoiceDetails
            this.btnViewInvoiceDetail.Location = new System.Drawing.Point(20, 520);
            this.btnViewInvoiceDetail.Name = "btnViewInvoiceDetail";
            this.btnViewInvoiceDetail.Size = new System.Drawing.Size(100, 30);
            this.btnViewInvoiceDetail.TabIndex = 1;
            this.btnViewInvoiceDetail.Text = "Xem chi tiết";
            this.btnViewInvoiceDetail.Click += new System.EventHandler(this.btnViewInvoiceDetail_Click);

            this.btnPrintInvoice.Location = new System.Drawing.Point(140, 520);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(100, 30);
            this.btnPrintInvoice.TabIndex = 2;
            this.btnPrintInvoice.Text = "In hóa đơn";
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);

            // tabProducts
            this.tabProducts.Controls.Add(this.panelProducts);
            this.tabProducts.Controls.Add(this.btnOrderProduct);
            this.tabProducts.Controls.Add(this.btnViewProductDetail);
            this.tabProducts.Controls.Add(this.btnApplyVoucher);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Size = new System.Drawing.Size(973, 591);
            this.tabProducts.TabIndex = 3;
            this.tabProducts.Text = "Products";

            // panelProducts
            this.panelProducts.Location = new System.Drawing.Point(0, 0);
            this.panelProducts.Size = new System.Drawing.Size(973, 500);
            this.panelProducts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelProducts.Controls.Add(this.dgvProducts);

            // dgvProducts
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(973, 500);
            this.dgvProducts.TabIndex = 0;

            // Buttons Products
            this.btnOrderProduct.Location = new System.Drawing.Point(20, 520);
            this.btnOrderProduct.Name = "btnOrderProduct";
            this.btnOrderProduct.Size = new System.Drawing.Size(100, 30);
            this.btnOrderProduct.TabIndex = 1;
            this.btnOrderProduct.Text = "Đặt hàng";
            this.btnOrderProduct.Click += new System.EventHandler(this.btnOrderProduct_Click);

            this.btnViewProductDetail.Location = new System.Drawing.Point(140, 520);
            this.btnViewProductDetail.Name = "btnViewProductDetail";
            this.btnViewProductDetail.Size = new System.Drawing.Size(100, 30);
            this.btnViewProductDetail.TabIndex = 2;
            this.btnViewProductDetail.Text = "Xem chi tiết";
            this.btnViewProductDetail.Click += new System.EventHandler(this.btnViewProductDetail_Click);

            this.btnApplyVoucher.Location = new System.Drawing.Point(260, 520);
            this.btnApplyVoucher.Name = "btnApplyVoucher";
            this.btnApplyVoucher.Size = new System.Drawing.Size(120, 30);
            this.btnApplyVoucher.TabIndex = 3;
            this.btnApplyVoucher.Text = "Áp dụng voucher";
            this.btnApplyVoucher.Click += new System.EventHandler(this.btnApplyVoucher_Click);

            // tabWarranty
            this.tabWarranty.Controls.Add(this.panelWarranty);
            this.tabWarranty.Controls.Add(this.btnViewWarrantyDetail);
            this.tabWarranty.Controls.Add(this.btnRequestWarranty);
            this.tabWarranty.Location = new System.Drawing.Point(4, 22);
            this.tabWarranty.Name = "tabWarranty";
            this.tabWarranty.Size = new System.Drawing.Size(973, 591);
            this.tabWarranty.TabIndex = 4;
            this.tabWarranty.Text = "Warranty";

            // panelWarranty
            this.panelWarranty.Location = new System.Drawing.Point(0, 0);
            this.panelWarranty.Size = new System.Drawing.Size(973, 500);
            this.panelWarranty.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelWarranty.Controls.Add(this.dgvWarranty);

            // dgvWarranty
            this.dgvWarranty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarranty.Location = new System.Drawing.Point(0, 0);
            this.dgvWarranty.Name = "dgvWarranty";
            this.dgvWarranty.Size = new System.Drawing.Size(973, 500);
            this.dgvWarranty.TabIndex = 0;

            // Buttons Warranty
            this.btnViewWarrantyDetail.Location = new System.Drawing.Point(20, 520);
            this.btnViewWarrantyDetail.Name = "btnViewWarrantyDetail";
            this.btnViewWarrantyDetail.Size = new System.Drawing.Size(100, 30);
            this.btnViewWarrantyDetail.TabIndex = 1;
            this.btnViewWarrantyDetail.Text = "Xem chi tiết";
            this.btnViewWarrantyDetail.Click += new System.EventHandler(this.btnViewWarrantyDetail_Click);

            this.btnRequestWarranty.Location = new System.Drawing.Point(140, 520);
            this.btnRequestWarranty.Name = "btnRequestWarranty";
            this.btnRequestWarranty.Size = new System.Drawing.Size(120, 30);
            this.btnRequestWarranty.TabIndex = 2;
            this.btnRequestWarranty.Text = "Yêu cầu bảo hành";
            this.btnRequestWarranty.Click += new System.EventHandler(this.btnRequestWarranty_Click);

            // CustomerForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 639);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerForm";
            this.Text = "Customer Portal";
            this.tabControl.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabPersonalInfo.PerformLayout();
            this.tabOrderHistory.ResumeLayout(false);
            this.panelOrderHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).EndInit();
            this.tabInvoiceDetails.ResumeLayout(false);
            this.panelInvoiceDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.tabProducts.ResumeLayout(false);
            this.panelProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabWarranty.ResumeLayout(false);
            this.panelWarranty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranty)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
