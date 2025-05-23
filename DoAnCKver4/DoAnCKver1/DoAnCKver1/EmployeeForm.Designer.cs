using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace DoAnCKver1
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.dataGridViewInvoices = new System.Windows.Forms.DataGridView();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtInvoiceId = new System.Windows.Forms.TextBox();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnUpdateInvoice = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.btnSearchInvoices = new System.Windows.Forms.Button();
            this.dateTimePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelInvoiceDate = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.labelInvoiceId = new System.Windows.Forms.Label();
            this.labelFromDate = new System.Windows.Forms.Label();
            this.labelToDate = new System.Windows.Forms.Label();
            this.tabInvoiceDetails = new System.Windows.Forms.TabPage();
            this.dataGridViewInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.btnAddInvoiceItem = new System.Windows.Forms.Button();
            this.btnUpdateInvoiceItem = new System.Windows.Forms.Button();
            this.btnDeleteInvoiceItem = new System.Windows.Forms.Button();
            this.btnSearchInvoiceItem = new System.Windows.Forms.Button();
            this.labelInvoiceItemId = new System.Windows.Forms.Label();
            this.txtInvoiceItemId = new System.Windows.Forms.TextBox();
            this.labelInvoiceItem_Invoice = new System.Windows.Forms.Label();
            this.comboBoxInvoiceItem_Invoice = new System.Windows.Forms.ComboBox();
            this.labelInvoiceItem_Product = new System.Windows.Forms.Label();
            this.comboBoxInvoiceItem_Product = new System.Windows.Forms.ComboBox();
            this.labelInvoiceItemQuantity = new System.Windows.Forms.Label();
            this.txtInvoiceItemQuantity = new System.Windows.Forms.TextBox();
            this.labelInvoiceItemUnitPrice = new System.Windows.Forms.Label();
            this.txtInvoiceItemUnitPrice = new System.Windows.Forms.TextBox();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnSearchProducts = new System.Windows.Forms.Button();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelUnitPrice = new System.Windows.Forms.Label();
            this.labelStockQuantity = new System.Windows.Forms.Label();
            this.labelProductId = new System.Windows.Forms.Label();
            this.labelSearchProduct = new System.Windows.Forms.Label();
            this.tabWarrantyVouchers = new System.Windows.Forms.TabPage();
            this.dataGridViewWarrantyVouchers = new System.Windows.Forms.DataGridView();
            this.comboBoxInvoice = new System.Windows.Forms.ComboBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.dateTimePickerIssueDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.txtVoucherId = new System.Windows.Forms.TextBox();
            this.btnAddWarrantyVoucher = new System.Windows.Forms.Button();
            this.btnUpdateWarrantyVoucher = new System.Windows.Forms.Button();
            this.btnDeleteWarrantyVoucher = new System.Windows.Forms.Button();
            this.btnSearchWarrantyVouchers = new System.Windows.Forms.Button();
            this.labelInvoice = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelIssueDate = new System.Windows.Forms.Label();
            this.labelExpiryDate = new System.Windows.Forms.Label();
            this.labelVoucherId = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).BeginInit();
            this.tabInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoiceDetails)).BeginInit();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.tabWarrantyVouchers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarrantyVouchers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInvoices);
            this.tabControl.Controls.Add(this.tabInvoiceDetails);
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Controls.Add(this.tabWarrantyVouchers);
            this.tabControl.Location = new System.Drawing.Point(9, 32);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(985, 596);
            this.tabControl.TabIndex = 0;
            // 
            // tabInvoices
            // 
            this.tabInvoices.Controls.Add(this.btnPrintInvoice);
            this.tabInvoices.Controls.Add(this.dataGridViewInvoices);
            this.tabInvoices.Controls.Add(this.comboBoxCustomer);
            this.tabInvoices.Controls.Add(this.dateTimePickerInvoiceDate);
            this.tabInvoices.Controls.Add(this.txtTotalAmount);
            this.tabInvoices.Controls.Add(this.txtInvoiceId);
            this.tabInvoices.Controls.Add(this.btnAddInvoice);
            this.tabInvoices.Controls.Add(this.btnUpdateInvoice);
            this.tabInvoices.Controls.Add(this.btnDeleteInvoice);
            this.tabInvoices.Controls.Add(this.btnSearchInvoices);
            this.tabInvoices.Controls.Add(this.dateTimePickerFromDate);
            this.tabInvoices.Controls.Add(this.dateTimePickerToDate);
            this.tabInvoices.Controls.Add(this.labelCustomer);
            this.tabInvoices.Controls.Add(this.labelInvoiceDate);
            this.tabInvoices.Controls.Add(this.labelTotalAmount);
            this.tabInvoices.Controls.Add(this.labelInvoiceId);
            this.tabInvoices.Controls.Add(this.labelFromDate);
            this.tabInvoices.Controls.Add(this.labelToDate);
            this.tabInvoices.Location = new System.Drawing.Point(4, 22);
            this.tabInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.Padding = new System.Windows.Forms.Padding(2);
            this.tabInvoices.Size = new System.Drawing.Size(977, 570);
            this.tabInvoices.TabIndex = 0;
            this.tabInvoices.Text = "Hóa đơn";
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(538, 527);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(77, 38);
            this.btnPrintInvoice.TabIndex = 0;
            this.btnPrintInvoice.Text = "In hóa đơn";
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // dataGridViewInvoices
            // 
            this.dataGridViewInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoices.Location = new System.Drawing.Point(4, 5);
            this.dataGridViewInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.RowHeadersWidth = 51;
            this.dataGridViewInvoices.Size = new System.Drawing.Size(971, 325);
            this.dataGridViewInvoices.TabIndex = 0;
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(123, 351);
            this.comboBoxCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(201, 21);
            this.comboBoxCustomer.TabIndex = 1;
            // 
            // dateTimePickerInvoiceDate
            // 
            this.dateTimePickerInvoiceDate.Location = new System.Drawing.Point(123, 394);
            this.dateTimePickerInvoiceDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerInvoiceDate.Name = "dateTimePickerInvoiceDate";
            this.dateTimePickerInvoiceDate.Size = new System.Drawing.Size(201, 20);
            this.dateTimePickerInvoiceDate.TabIndex = 2;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(123, 431);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(201, 20);
            this.txtTotalAmount.TabIndex = 3;
            // 
            // txtInvoiceId
            // 
            this.txtInvoiceId.Location = new System.Drawing.Point(123, 478);
            this.txtInvoiceId.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceId.Name = "txtInvoiceId";
            this.txtInvoiceId.Size = new System.Drawing.Size(201, 20);
            this.txtInvoiceId.TabIndex = 4;
            this.txtInvoiceId.TextChanged += new System.EventHandler(this.txtInvoiceId_TextChanged);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(364, 351);
            this.btnAddInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(74, 38);
            this.btnAddInvoice.TabIndex = 5;
            this.btnAddInvoice.Text = "Thêm";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // btnUpdateInvoice
            // 
            this.btnUpdateInvoice.Location = new System.Drawing.Point(364, 413);
            this.btnUpdateInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateInvoice.Name = "btnUpdateInvoice";
            this.btnUpdateInvoice.Size = new System.Drawing.Size(74, 38);
            this.btnUpdateInvoice.TabIndex = 6;
            this.btnUpdateInvoice.Text = "Sửa";
            this.btnUpdateInvoice.UseVisualStyleBackColor = true;
            this.btnUpdateInvoice.Click += new System.EventHandler(this.btnUpdateInvoice_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(364, 478);
            this.btnDeleteInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(74, 38);
            this.btnDeleteInvoice.TabIndex = 7;
            this.btnDeleteInvoice.Text = "Xóa";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // btnSearchInvoices
            // 
            this.btnSearchInvoices.Location = new System.Drawing.Point(538, 478);
            this.btnSearchInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchInvoices.Name = "btnSearchInvoices";
            this.btnSearchInvoices.Size = new System.Drawing.Size(77, 38);
            this.btnSearchInvoices.TabIndex = 8;
            this.btnSearchInvoices.Text = "Tìm kiếm";
            this.btnSearchInvoices.UseVisualStyleBackColor = true;
            this.btnSearchInvoices.Click += new System.EventHandler(this.btnSearchInvoices_Click);
            // 
            // dateTimePickerFromDate
            // 
            this.dateTimePickerFromDate.Location = new System.Drawing.Point(634, 376);
            this.dateTimePickerFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFromDate.Name = "dateTimePickerFromDate";
            this.dateTimePickerFromDate.Size = new System.Drawing.Size(201, 20);
            this.dateTimePickerFromDate.TabIndex = 9;
            // 
            // dateTimePickerToDate
            // 
            this.dateTimePickerToDate.Location = new System.Drawing.Point(634, 428);
            this.dateTimePickerToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerToDate.Name = "dateTimePickerToDate";
            this.dateTimePickerToDate.Size = new System.Drawing.Size(201, 20);
            this.dateTimePickerToDate.TabIndex = 10;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(15, 359);
            this.labelCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(68, 13);
            this.labelCustomer.TabIndex = 11;
            this.labelCustomer.Text = "Khách hàng:";
            // 
            // labelInvoiceDate
            // 
            this.labelInvoiceDate.AutoSize = true;
            this.labelInvoiceDate.Location = new System.Drawing.Point(15, 401);
            this.labelInvoiceDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInvoiceDate.Name = "labelInvoiceDate";
            this.labelInvoiceDate.Size = new System.Drawing.Size(78, 13);
            this.labelInvoiceDate.TabIndex = 12;
            this.labelInvoiceDate.Text = "Ngày hóa đơn:";
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Location = new System.Drawing.Point(15, 438);
            this.labelTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(55, 13);
            this.labelTotalAmount.TabIndex = 13;
            this.labelTotalAmount.Text = "Tổng tiền:";
            // 
            // labelInvoiceId
            // 
            this.labelInvoiceId.AutoSize = true;
            this.labelInvoiceId.Location = new System.Drawing.Point(15, 485);
            this.labelInvoiceId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInvoiceId.Name = "labelInvoiceId";
            this.labelInvoiceId.Size = new System.Drawing.Size(68, 13);
            this.labelInvoiceId.TabIndex = 14;
            this.labelInvoiceId.Text = "Mã hóa đơn:";
            // 
            // labelFromDate
            // 
            this.labelFromDate.AutoSize = true;
            this.labelFromDate.Location = new System.Drawing.Point(549, 383);
            this.labelFromDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFromDate.Name = "labelFromDate";
            this.labelFromDate.Size = new System.Drawing.Size(49, 13);
            this.labelFromDate.TabIndex = 15;
            this.labelFromDate.Text = "Từ ngày:";
            // 
            // labelToDate
            // 
            this.labelToDate.AutoSize = true;
            this.labelToDate.Location = new System.Drawing.Point(549, 434);
            this.labelToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelToDate.Name = "labelToDate";
            this.labelToDate.Size = new System.Drawing.Size(56, 13);
            this.labelToDate.TabIndex = 16;
            this.labelToDate.Text = "Đến ngày:";
            // 
            // tabInvoiceDetails
            // 
            this.tabInvoiceDetails.Controls.Add(this.dataGridViewInvoiceDetails);
            this.tabInvoiceDetails.Controls.Add(this.btnAddInvoiceItem);
            this.tabInvoiceDetails.Controls.Add(this.btnUpdateInvoiceItem);
            this.tabInvoiceDetails.Controls.Add(this.btnDeleteInvoiceItem);
            this.tabInvoiceDetails.Controls.Add(this.btnSearchInvoiceItem);
            this.tabInvoiceDetails.Controls.Add(this.labelInvoiceItemId);
            this.tabInvoiceDetails.Controls.Add(this.txtInvoiceItemId);
            this.tabInvoiceDetails.Controls.Add(this.labelInvoiceItem_Invoice);
            this.tabInvoiceDetails.Controls.Add(this.comboBoxInvoiceItem_Invoice);
            this.tabInvoiceDetails.Controls.Add(this.labelInvoiceItem_Product);
            this.tabInvoiceDetails.Controls.Add(this.comboBoxInvoiceItem_Product);
            this.tabInvoiceDetails.Controls.Add(this.labelInvoiceItemQuantity);
            this.tabInvoiceDetails.Controls.Add(this.txtInvoiceItemQuantity);
            this.tabInvoiceDetails.Controls.Add(this.labelInvoiceItemUnitPrice);
            this.tabInvoiceDetails.Controls.Add(this.txtInvoiceItemUnitPrice);
            this.tabInvoiceDetails.Location = new System.Drawing.Point(4, 22);
            this.tabInvoiceDetails.Name = "tabInvoiceDetails";
            this.tabInvoiceDetails.Padding = new System.Windows.Forms.Padding(2);
            this.tabInvoiceDetails.Size = new System.Drawing.Size(977, 570);
            this.tabInvoiceDetails.TabIndex = 3;
            this.tabInvoiceDetails.Text = "Chi tiết hóa đơn";
            this.tabInvoiceDetails.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInvoiceDetails
            // 
            this.dataGridViewInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoiceDetails.Location = new System.Drawing.Point(4, 5);
            this.dataGridViewInvoiceDetails.Name = "dataGridViewInvoiceDetails";
            this.dataGridViewInvoiceDetails.RowHeadersWidth = 51;
            this.dataGridViewInvoiceDetails.Size = new System.Drawing.Size(971, 325);
            this.dataGridViewInvoiceDetails.TabIndex = 0;
            // 
            // btnAddInvoiceItem
            // 
            this.btnAddInvoiceItem.Location = new System.Drawing.Point(228, 510);
            this.btnAddInvoiceItem.Name = "btnAddInvoiceItem";
            this.btnAddInvoiceItem.Size = new System.Drawing.Size(74, 38);
            this.btnAddInvoiceItem.TabIndex = 1;
            this.btnAddInvoiceItem.Text = "Thêm";
            this.btnAddInvoiceItem.UseVisualStyleBackColor = true;
            // 
            // btnUpdateInvoiceItem
            // 
            this.btnUpdateInvoiceItem.Location = new System.Drawing.Point(340, 510);
            this.btnUpdateInvoiceItem.Name = "btnUpdateInvoiceItem";
            this.btnUpdateInvoiceItem.Size = new System.Drawing.Size(74, 38);
            this.btnUpdateInvoiceItem.TabIndex = 2;
            this.btnUpdateInvoiceItem.Text = "Sửa";
            this.btnUpdateInvoiceItem.UseVisualStyleBackColor = true;
            // 
            // btnDeleteInvoiceItem
            // 
            this.btnDeleteInvoiceItem.Location = new System.Drawing.Point(464, 510);
            this.btnDeleteInvoiceItem.Name = "btnDeleteInvoiceItem";
            this.btnDeleteInvoiceItem.Size = new System.Drawing.Size(74, 38);
            this.btnDeleteInvoiceItem.TabIndex = 3;
            this.btnDeleteInvoiceItem.Text = "Xóa";
            this.btnDeleteInvoiceItem.UseVisualStyleBackColor = true;
            // 
            // btnSearchInvoiceItem
            // 
            this.btnSearchInvoiceItem.Location = new System.Drawing.Point(575, 510);
            this.btnSearchInvoiceItem.Name = "btnSearchInvoiceItem";
            this.btnSearchInvoiceItem.Size = new System.Drawing.Size(74, 38);
            this.btnSearchInvoiceItem.TabIndex = 4;
            this.btnSearchInvoiceItem.Text = "Tìm kiếm";
            this.btnSearchInvoiceItem.UseVisualStyleBackColor = true;
            // 
            // labelInvoiceItemId
            // 
            this.labelInvoiceItemId.AutoSize = true;
            this.labelInvoiceItemId.Location = new System.Drawing.Point(30, 400);
            this.labelInvoiceItemId.Name = "labelInvoiceItemId";
            this.labelInvoiceItemId.Size = new System.Drawing.Size(102, 13);
            this.labelInvoiceItemId.TabIndex = 5;
            this.labelInvoiceItemId.Text = "Mã chi tiết hóa đơn:";
            // 
            // txtInvoiceItemId
            // 
            this.txtInvoiceItemId.Location = new System.Drawing.Point(130, 397);
            this.txtInvoiceItemId.Name = "txtInvoiceItemId";
            this.txtInvoiceItemId.Size = new System.Drawing.Size(120, 20);
            this.txtInvoiceItemId.TabIndex = 6;
            // 
            // labelInvoiceItem_Invoice
            // 
            this.labelInvoiceItem_Invoice.AutoSize = true;
            this.labelInvoiceItem_Invoice.Location = new System.Drawing.Point(30, 444);
            this.labelInvoiceItem_Invoice.Name = "labelInvoiceItem_Invoice";
            this.labelInvoiceItem_Invoice.Size = new System.Drawing.Size(52, 13);
            this.labelInvoiceItem_Invoice.TabIndex = 7;
            this.labelInvoiceItem_Invoice.Text = "Hóa đơn:";
            // 
            // comboBoxInvoiceItem_Invoice
            // 
            this.comboBoxInvoiceItem_Invoice.Location = new System.Drawing.Point(130, 444);
            this.comboBoxInvoiceItem_Invoice.Name = "comboBoxInvoiceItem_Invoice";
            this.comboBoxInvoiceItem_Invoice.Size = new System.Drawing.Size(120, 21);
            this.comboBoxInvoiceItem_Invoice.TabIndex = 8;
            // 
            // labelInvoiceItem_Product
            // 
            this.labelInvoiceItem_Product.AutoSize = true;
            this.labelInvoiceItem_Product.Location = new System.Drawing.Point(325, 400);
            this.labelInvoiceItem_Product.Name = "labelInvoiceItem_Product";
            this.labelInvoiceItem_Product.Size = new System.Drawing.Size(58, 13);
            this.labelInvoiceItem_Product.TabIndex = 9;
            this.labelInvoiceItem_Product.Text = "Sản phẩm:";
            // 
            // comboBoxInvoiceItem_Product
            // 
            this.comboBoxInvoiceItem_Product.Location = new System.Drawing.Point(418, 396);
            this.comboBoxInvoiceItem_Product.Name = "comboBoxInvoiceItem_Product";
            this.comboBoxInvoiceItem_Product.Size = new System.Drawing.Size(120, 21);
            this.comboBoxInvoiceItem_Product.TabIndex = 10;
            // 
            // labelInvoiceItemQuantity
            // 
            this.labelInvoiceItemQuantity.AutoSize = true;
            this.labelInvoiceItemQuantity.Location = new System.Drawing.Point(325, 452);
            this.labelInvoiceItemQuantity.Name = "labelInvoiceItemQuantity";
            this.labelInvoiceItemQuantity.Size = new System.Drawing.Size(52, 13);
            this.labelInvoiceItemQuantity.TabIndex = 11;
            this.labelInvoiceItemQuantity.Text = "Số lượng:";
            // 
            // txtInvoiceItemQuantity
            // 
            this.txtInvoiceItemQuantity.Location = new System.Drawing.Point(418, 452);
            this.txtInvoiceItemQuantity.Name = "txtInvoiceItemQuantity";
            this.txtInvoiceItemQuantity.Size = new System.Drawing.Size(60, 20);
            this.txtInvoiceItemQuantity.TabIndex = 12;
            // 
            // labelInvoiceItemUnitPrice
            // 
            this.labelInvoiceItemUnitPrice.AutoSize = true;
            this.labelInvoiceItemUnitPrice.Location = new System.Drawing.Point(572, 404);
            this.labelInvoiceItemUnitPrice.Name = "labelInvoiceItemUnitPrice";
            this.labelInvoiceItemUnitPrice.Size = new System.Drawing.Size(47, 13);
            this.labelInvoiceItemUnitPrice.TabIndex = 13;
            this.labelInvoiceItemUnitPrice.Text = "Đơn giá:";
            // 
            // txtInvoiceItemUnitPrice
            // 
            this.txtInvoiceItemUnitPrice.Location = new System.Drawing.Point(648, 401);
            this.txtInvoiceItemUnitPrice.Name = "txtInvoiceItemUnitPrice";
            this.txtInvoiceItemUnitPrice.Size = new System.Drawing.Size(80, 20);
            this.txtInvoiceItemUnitPrice.TabIndex = 14;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.dataGridViewProducts);
            this.tabProducts.Controls.Add(this.comboBoxSupplier);
            this.tabProducts.Controls.Add(this.txtProductName);
            this.tabProducts.Controls.Add(this.txtUnitPrice);
            this.tabProducts.Controls.Add(this.txtStockQuantity);
            this.tabProducts.Controls.Add(this.txtProductId);
            this.tabProducts.Controls.Add(this.txtSearchProduct);
            this.tabProducts.Controls.Add(this.btnAddProduct);
            this.tabProducts.Controls.Add(this.btnUpdateProduct);
            this.tabProducts.Controls.Add(this.btnDeleteProduct);
            this.tabProducts.Controls.Add(this.btnSearchProducts);
            this.tabProducts.Controls.Add(this.labelSupplier);
            this.tabProducts.Controls.Add(this.labelProductName);
            this.tabProducts.Controls.Add(this.labelUnitPrice);
            this.tabProducts.Controls.Add(this.labelStockQuantity);
            this.tabProducts.Controls.Add(this.labelProductId);
            this.tabProducts.Controls.Add(this.labelSearchProduct);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Margin = new System.Windows.Forms.Padding(2);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(2);
            this.tabProducts.Size = new System.Drawing.Size(977, 570);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Text = "Sản phẩm";
            this.tabProducts.Click += new System.EventHandler(this.tabProducts_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(4, 5);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.Size = new System.Drawing.Size(971, 325);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(125, 348);
            this.comboBoxSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(201, 21);
            this.comboBoxSupplier.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(125, 390);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(201, 20);
            this.txtProductName.TabIndex = 2;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(125, 436);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(201, 20);
            this.txtUnitPrice.TabIndex = 3;
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.Location = new System.Drawing.Point(125, 479);
            this.txtStockQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.Size = new System.Drawing.Size(201, 20);
            this.txtStockQuantity.TabIndex = 4;
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(125, 528);
            this.txtProductId.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(201, 20);
            this.txtProductId.TabIndex = 5;
            this.txtProductId.TextChanged += new System.EventHandler(this.txtProductId_TextChanged);
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(619, 349);
            this.txtSearchProduct.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(201, 20);
            this.txtSearchProduct.TabIndex = 6;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(400, 348);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(74, 38);
            this.btnAddProduct.TabIndex = 7;
            this.btnAddProduct.Text = "Thêm";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(400, 426);
            this.btnUpdateProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(74, 38);
            this.btnUpdateProduct.TabIndex = 8;
            this.btnUpdateProduct.Text = "Sửa";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(400, 510);
            this.btnDeleteProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(74, 38);
            this.btnDeleteProduct.TabIndex = 9;
            this.btnDeleteProduct.Text = "Xóa";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnSearchProducts
            // 
            this.btnSearchProducts.Location = new System.Drawing.Point(548, 390);
            this.btnSearchProducts.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchProducts.Name = "btnSearchProducts";
            this.btnSearchProducts.Size = new System.Drawing.Size(74, 38);
            this.btnSearchProducts.TabIndex = 10;
            this.btnSearchProducts.Text = "Tìm kiếm";
            this.btnSearchProducts.UseVisualStyleBackColor = true;
            this.btnSearchProducts.Click += new System.EventHandler(this.btnSearchProducts_Click);
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Location = new System.Drawing.Point(17, 355);
            this.labelSupplier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(78, 13);
            this.labelSupplier.TabIndex = 11;
            this.labelSupplier.Text = "Nhà cung cấp:";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(17, 397);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(78, 13);
            this.labelProductName.TabIndex = 12;
            this.labelProductName.Text = "Tên sản phẩm:";
            // 
            // labelUnitPrice
            // 
            this.labelUnitPrice.AutoSize = true;
            this.labelUnitPrice.Location = new System.Drawing.Point(17, 443);
            this.labelUnitPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUnitPrice.Name = "labelUnitPrice";
            this.labelUnitPrice.Size = new System.Drawing.Size(47, 13);
            this.labelUnitPrice.TabIndex = 13;
            this.labelUnitPrice.Text = "Đơn giá:";
            // 
            // labelStockQuantity
            // 
            this.labelStockQuantity.AutoSize = true;
            this.labelStockQuantity.Location = new System.Drawing.Point(17, 482);
            this.labelStockQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStockQuantity.Name = "labelStockQuantity";
            this.labelStockQuantity.Size = new System.Drawing.Size(70, 13);
            this.labelStockQuantity.TabIndex = 14;
            this.labelStockQuantity.Text = "Số lượng tồn:";
            // 
            // labelProductId
            // 
            this.labelProductId.AutoSize = true;
            this.labelProductId.Location = new System.Drawing.Point(17, 535);
            this.labelProductId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductId.Name = "labelProductId";
            this.labelProductId.Size = new System.Drawing.Size(74, 13);
            this.labelProductId.TabIndex = 15;
            this.labelProductId.Text = "Mã sản phẩm:";
            // 
            // labelSearchProduct
            // 
            this.labelSearchProduct.AutoSize = true;
            this.labelSearchProduct.Location = new System.Drawing.Point(545, 355);
            this.labelSearchProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearchProduct.Name = "labelSearchProduct";
            this.labelSearchProduct.Size = new System.Drawing.Size(52, 13);
            this.labelSearchProduct.TabIndex = 16;
            this.labelSearchProduct.Text = "Tìm kiếm:";
            // 
            // tabWarrantyVouchers
            // 
            this.tabWarrantyVouchers.Controls.Add(this.dataGridViewWarrantyVouchers);
            this.tabWarrantyVouchers.Controls.Add(this.comboBoxInvoice);
            this.tabWarrantyVouchers.Controls.Add(this.comboBoxProduct);
            this.tabWarrantyVouchers.Controls.Add(this.dateTimePickerIssueDate);
            this.tabWarrantyVouchers.Controls.Add(this.dateTimePickerExpiryDate);
            this.tabWarrantyVouchers.Controls.Add(this.txtVoucherId);
            this.tabWarrantyVouchers.Controls.Add(this.btnAddWarrantyVoucher);
            this.tabWarrantyVouchers.Controls.Add(this.btnUpdateWarrantyVoucher);
            this.tabWarrantyVouchers.Controls.Add(this.btnDeleteWarrantyVoucher);
            this.tabWarrantyVouchers.Controls.Add(this.btnSearchWarrantyVouchers);
            this.tabWarrantyVouchers.Controls.Add(this.labelInvoice);
            this.tabWarrantyVouchers.Controls.Add(this.labelProduct);
            this.tabWarrantyVouchers.Controls.Add(this.labelIssueDate);
            this.tabWarrantyVouchers.Controls.Add(this.labelExpiryDate);
            this.tabWarrantyVouchers.Controls.Add(this.labelVoucherId);
            this.tabWarrantyVouchers.Location = new System.Drawing.Point(4, 22);
            this.tabWarrantyVouchers.Margin = new System.Windows.Forms.Padding(2);
            this.tabWarrantyVouchers.Name = "tabWarrantyVouchers";
            this.tabWarrantyVouchers.Padding = new System.Windows.Forms.Padding(2);
            this.tabWarrantyVouchers.Size = new System.Drawing.Size(977, 570);
            this.tabWarrantyVouchers.TabIndex = 2;
            this.tabWarrantyVouchers.Text = "Phiếu bảo hành";
            this.tabWarrantyVouchers.Click += new System.EventHandler(this.tabWarrantyVouchers_Click);
            // 
            // dataGridViewWarrantyVouchers
            // 
            this.dataGridViewWarrantyVouchers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWarrantyVouchers.Location = new System.Drawing.Point(4, 5);
            this.dataGridViewWarrantyVouchers.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewWarrantyVouchers.Name = "dataGridViewWarrantyVouchers";
            this.dataGridViewWarrantyVouchers.RowHeadersWidth = 51;
            this.dataGridViewWarrantyVouchers.Size = new System.Drawing.Size(971, 325);
            this.dataGridViewWarrantyVouchers.TabIndex = 0;
            // 
            // comboBoxInvoice
            // 
            this.comboBoxInvoice.FormattingEnabled = true;
            this.comboBoxInvoice.Location = new System.Drawing.Point(98, 358);
            this.comboBoxInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxInvoice.Name = "comboBoxInvoice";
            this.comboBoxInvoice.Size = new System.Drawing.Size(201, 21);
            this.comboBoxInvoice.TabIndex = 1;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(98, 404);
            this.comboBoxProduct.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(201, 21);
            this.comboBoxProduct.TabIndex = 2;
            // 
            // dateTimePickerIssueDate
            // 
            this.dateTimePickerIssueDate.Location = new System.Drawing.Point(394, 358);
            this.dateTimePickerIssueDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerIssueDate.Name = "dateTimePickerIssueDate";
            this.dateTimePickerIssueDate.Size = new System.Drawing.Size(201, 20);
            this.dateTimePickerIssueDate.TabIndex = 3;
            this.dateTimePickerIssueDate.ValueChanged += new System.EventHandler(this.dateTimePickerIssueDate_ValueChanged);
            // 
            // dateTimePickerExpiryDate
            // 
            this.dateTimePickerExpiryDate.Location = new System.Drawing.Point(394, 404);
            this.dateTimePickerExpiryDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerExpiryDate.Name = "dateTimePickerExpiryDate";
            this.dateTimePickerExpiryDate.Size = new System.Drawing.Size(201, 20);
            this.dateTimePickerExpiryDate.TabIndex = 4;
            // 
            // txtVoucherId
            // 
            this.txtVoucherId.Location = new System.Drawing.Point(98, 450);
            this.txtVoucherId.Margin = new System.Windows.Forms.Padding(2);
            this.txtVoucherId.Name = "txtVoucherId";
            this.txtVoucherId.Size = new System.Drawing.Size(201, 20);
            this.txtVoucherId.TabIndex = 5;
            // 
            // btnAddWarrantyVoucher
            // 
            this.btnAddWarrantyVoucher.Location = new System.Drawing.Point(645, 366);
            this.btnAddWarrantyVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddWarrantyVoucher.Name = "btnAddWarrantyVoucher";
            this.btnAddWarrantyVoucher.Size = new System.Drawing.Size(74, 38);
            this.btnAddWarrantyVoucher.TabIndex = 6;
            this.btnAddWarrantyVoucher.Text = "Thêm";
            this.btnAddWarrantyVoucher.UseVisualStyleBackColor = true;
            this.btnAddWarrantyVoucher.Click += new System.EventHandler(this.btnAddWarrantyVoucher_Click);
            // 
            // btnUpdateWarrantyVoucher
            // 
            this.btnUpdateWarrantyVoucher.Location = new System.Drawing.Point(847, 366);
            this.btnUpdateWarrantyVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateWarrantyVoucher.Name = "btnUpdateWarrantyVoucher";
            this.btnUpdateWarrantyVoucher.Size = new System.Drawing.Size(74, 38);
            this.btnUpdateWarrantyVoucher.TabIndex = 7;
            this.btnUpdateWarrantyVoucher.Text = "Sửa";
            this.btnUpdateWarrantyVoucher.UseVisualStyleBackColor = true;
            this.btnUpdateWarrantyVoucher.Click += new System.EventHandler(this.btnUpdateWarrantyVoucher_Click);
            // 
            // btnDeleteWarrantyVoucher
            // 
            this.btnDeleteWarrantyVoucher.Location = new System.Drawing.Point(743, 366);
            this.btnDeleteWarrantyVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteWarrantyVoucher.Name = "btnDeleteWarrantyVoucher";
            this.btnDeleteWarrantyVoucher.Size = new System.Drawing.Size(74, 38);
            this.btnDeleteWarrantyVoucher.TabIndex = 8;
            this.btnDeleteWarrantyVoucher.Text = "Xóa";
            this.btnDeleteWarrantyVoucher.UseVisualStyleBackColor = true;
            this.btnDeleteWarrantyVoucher.Click += new System.EventHandler(this.btnDeleteWarrantyVoucher_Click);
            // 
            // btnSearchWarrantyVouchers
            // 
            this.btnSearchWarrantyVouchers.Location = new System.Drawing.Point(321, 450);
            this.btnSearchWarrantyVouchers.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchWarrantyVouchers.Name = "btnSearchWarrantyVouchers";
            this.btnSearchWarrantyVouchers.Size = new System.Drawing.Size(74, 38);
            this.btnSearchWarrantyVouchers.TabIndex = 9;
            this.btnSearchWarrantyVouchers.Text = "Tìm kiếm";
            this.btnSearchWarrantyVouchers.UseVisualStyleBackColor = true;
            this.btnSearchWarrantyVouchers.Click += new System.EventHandler(this.btnSearchWarrantyVouchers_Click);
            // 
            // labelInvoice
            // 
            this.labelInvoice.AutoSize = true;
            this.labelInvoice.Location = new System.Drawing.Point(15, 366);
            this.labelInvoice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInvoice.Name = "labelInvoice";
            this.labelInvoice.Size = new System.Drawing.Size(52, 13);
            this.labelInvoice.TabIndex = 10;
            this.labelInvoice.Text = "Hóa đơn:";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(15, 407);
            this.labelProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(58, 13);
            this.labelProduct.TabIndex = 11;
            this.labelProduct.Text = "Sản phẩm:";
            // 
            // labelIssueDate
            // 
            this.labelIssueDate.AutoSize = true;
            this.labelIssueDate.Location = new System.Drawing.Point(318, 366);
            this.labelIssueDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIssueDate.Name = "labelIssueDate";
            this.labelIssueDate.Size = new System.Drawing.Size(56, 13);
            this.labelIssueDate.TabIndex = 12;
            this.labelIssueDate.Text = "Ngày cấp:";
            // 
            // labelExpiryDate
            // 
            this.labelExpiryDate.AutoSize = true;
            this.labelExpiryDate.Location = new System.Drawing.Point(318, 412);
            this.labelExpiryDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExpiryDate.Name = "labelExpiryDate";
            this.labelExpiryDate.Size = new System.Drawing.Size(74, 13);
            this.labelExpiryDate.TabIndex = 13;
            this.labelExpiryDate.Text = "Ngày hết hạn:";
            // 
            // labelVoucherId
            // 
            this.labelVoucherId.AutoSize = true;
            this.labelVoucherId.Location = new System.Drawing.Point(15, 453);
            this.labelVoucherId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVoucherId.Name = "labelVoucherId";
            this.labelVoucherId.Size = new System.Drawing.Size(54, 13);
            this.labelVoucherId.TabIndex = 14;
            this.labelVoucherId.Text = "Mã phiếu:";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(9, 10);
            this.lblEmployeeName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(62, 13);
            this.lblEmployeeName.TabIndex = 1;
            this.lblEmployeeName.Text = "Nhân viên: ";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 639);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblEmployeeName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmployeeForm";
            this.Text = "Employee Dashboard";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            this.tabInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
            this.tabInvoiceDetails.ResumeLayout(false);
            this.tabInvoiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoiceDetails)).EndInit();
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.tabWarrantyVouchers.ResumeLayout(false);
            this.tabWarrantyVouchers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarrantyVouchers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrintInvoice;
        private int selectedInvoiceId;
        private DataTable invoiceDetails;
        private DataRow invoiceInfo;
        private System.Windows.Forms.TabPage tabInvoiceDetails;
        private System.Windows.Forms.DataGridView dataGridViewInvoiceDetails;
        private System.Windows.Forms.Button btnAddInvoiceItem;
        private System.Windows.Forms.Button btnUpdateInvoiceItem;
        private System.Windows.Forms.Button btnDeleteInvoiceItem;
        private System.Windows.Forms.Button btnSearchInvoiceItem;
        private System.Windows.Forms.TextBox txtInvoiceItemId;
        private System.Windows.Forms.ComboBox comboBoxInvoiceItem_Invoice;
        private System.Windows.Forms.ComboBox comboBoxInvoiceItem_Product;
        private System.Windows.Forms.TextBox txtInvoiceItemQuantity;
        private System.Windows.Forms.TextBox txtInvoiceItemUnitPrice;
        private System.Windows.Forms.Label labelInvoiceItemId;
        private System.Windows.Forms.Label labelInvoiceItem_Invoice;
        private System.Windows.Forms.Label labelInvoiceItem_Product;
        private System.Windows.Forms.Label labelInvoiceItemQuantity;
        private System.Windows.Forms.Label labelInvoiceItemUnitPrice;




        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInvoices;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabWarrantyVouchers;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.DataGridView dataGridViewInvoices;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.DateTimePicker dateTimePickerInvoiceDate;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtInvoiceId;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnUpdateInvoice;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Button btnSearchInvoices;
        private System.Windows.Forms.DateTimePicker dateTimePickerFromDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerToDate;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelInvoiceDate;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Label labelInvoiceId;
        private System.Windows.Forms.Label labelFromDate;
        private System.Windows.Forms.Label labelToDate;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtStockQuantity;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnSearchProducts;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelUnitPrice;
        private System.Windows.Forms.Label labelStockQuantity;
        private System.Windows.Forms.Label labelProductId;
        private System.Windows.Forms.Label labelSearchProduct;
        private System.Windows.Forms.DataGridView dataGridViewWarrantyVouchers;
        private System.Windows.Forms.ComboBox comboBoxInvoice;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssueDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpiryDate;
        private System.Windows.Forms.TextBox txtVoucherId;
        private System.Windows.Forms.Button btnAddWarrantyVoucher;
        private System.Windows.Forms.Button btnUpdateWarrantyVoucher;
        private System.Windows.Forms.Button btnDeleteWarrantyVoucher;
        private System.Windows.Forms.Button btnSearchWarrantyVouchers;
        private System.Windows.Forms.Label labelInvoice;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelIssueDate;
        private System.Windows.Forms.Label labelExpiryDate;
        private System.Windows.Forms.Label labelVoucherId;
    }
}