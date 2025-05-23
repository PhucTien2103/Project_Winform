using System;
using System.Data;
using System.Windows.Forms;
using DoAnCKver1.BSLayer;
using DoAnCKver1.Model;
using System.Data.SqlClient;
using DoAnCKver1.DBLayer;
using System.Drawing;
using System.Drawing.Printing;

namespace DoAnCKver1
{
    public partial class AdminForm : Form
    {
        private DataGridView dgvData;
        private DataGridView dgvMonthlyRevenue;
        private Button btnUser, btnInvoice, btnInvoiceItem, btnProduct, btnSupplier, btnWarrantyVoucher;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh, btnLogout, btnViewDetails, btnShowRevenue;
        private Label lblTotalRevenue, lblTotalLaptops, lblTotalComponents;
        private ComboBox cmbYear;
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private DataRow invoiceInfo;
        private DataTable invoiceDetails;
        private int selectedInvoiceId;
        private Button btnPrintInvoice;




        // Constructor: Initializes the form and loads default data
        public AdminForm()
        {
            InitializeComponents();
            LoadUser(); // Load User table by default
            UpdateStatistics(); // Update revenue and product statistics
            PopulateYearComboBox(); // Populate year selection dropdown
        }

        // Initializes all UI components and their layout
        private void InitializeComponents()
        {
            // Set up form properties
            this.Text = "Admin Dashboard";
            this.Size = new System.Drawing.Size(1000, 850);
            this.MinimumSize = new System.Drawing.Size(1000, 850);

            // Create statistics labels
            lblTotalRevenue = new Label
            {
                Text = "Tổng doanh thu: 0 VND",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(300, 30),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            lblTotalLaptops = new Label
            {
                Text = "Tổng số laptop: 0",
                Location = new System.Drawing.Point(320, 20),
                Size = new System.Drawing.Size(150, 30),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            lblTotalComponents = new Label
            {
                Text = "Tổng số linh kiện: 0",
                Location = new System.Drawing.Point(470, 20),
                Size = new System.Drawing.Size(150, 30),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblTotalRevenue);
            this.Controls.Add(lblTotalLaptops);
            this.Controls.Add(lblTotalComponents);

            // Create year selection ComboBox
            cmbYear = new ComboBox
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(100, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbYear);

            // Create button to show monthly revenue
            btnShowRevenue = new Button
            {
                Text = "Thống kê doanh thu",
                Location = new System.Drawing.Point(130, 60),
                Size = new System.Drawing.Size(150, 30)
            };
            btnShowRevenue.Click += btnShowRevenue_Click;
            this.Controls.Add(btnShowRevenue);

            // Create DataGridView for monthly revenue
            dgvMonthlyRevenue = new DataGridView
            {
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(950, 150),
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false
            };
            this.Controls.Add(dgvMonthlyRevenue);

            // Create main DataGridView for table data
            dgvData = new DataGridView
            {
                Location = new System.Drawing.Point(20, 260),
                Size = new System.Drawing.Size(950, 400),
                ReadOnly = false,
                AllowUserToAddRows = false,
                MultiSelect = false
            };
            this.Controls.Add(dgvData);

            // Create table selection buttons
            btnUser = new Button { Text = "User", Location = new System.Drawing.Point(20, 670), Size = new System.Drawing.Size(150, 30) };
            btnUser.Click += (s, e) => LoadUser();
            btnInvoice = new Button { Text = "Invoice", Location = new System.Drawing.Point(180, 670), Size = new System.Drawing.Size(150, 30) };
            btnInvoice.Click += (s, e) => LoadInvoice();
            btnInvoiceItem = new Button { Text = "InvoiceItem", Location = new System.Drawing.Point(340, 670), Size = new System.Drawing.Size(150, 30) };
            btnInvoiceItem.Click += (s, e) => LoadInvoiceItem();
            btnProduct = new Button { Text = "Product", Location = new System.Drawing.Point(500, 670), Size = new System.Drawing.Size(150, 30) };
            btnProduct.Click += (s, e) => LoadProduct();
            btnSupplier = new Button { Text = "Supplier", Location = new System.Drawing.Point(660, 670), Size = new System.Drawing.Size(150, 30) };
            btnSupplier.Click += (s, e) => LoadSupplier();
            btnWarrantyVoucher = new Button { Text = "WarrantyVoucher", Location = new System.Drawing.Point(820, 670), Size = new System.Drawing.Size(150, 30) };
            btnWarrantyVoucher.Click += (s, e) => LoadWarrantyVoucher();

            this.Controls.Add(btnUser);
            this.Controls.Add(btnInvoice);
            this.Controls.Add(btnInvoiceItem);
            this.Controls.Add(btnProduct);
            this.Controls.Add(btnSupplier);
            this.Controls.Add(btnWarrantyVoucher);

            // Create action buttons
            btnAdd = new Button { Text = "Add", Location = new System.Drawing.Point(20, 710), Size = new System.Drawing.Size(100, 30) };
            btnAdd.Click += btnAdd_Click;
            btnEdit = new Button { Text = "Edit", Location = new System.Drawing.Point(130, 710), Size = new System.Drawing.Size(100, 30) };
            btnEdit.Click += btnEdit_Click;
            btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(240, 710), Size = new System.Drawing.Size(100, 30) };
            btnDelete.Click += btnDelete_Click;
            btnRefresh = new Button { Text = "Refresh", Location = new System.Drawing.Point(350, 710), Size = new System.Drawing.Size(100, 30) };
            btnRefresh.Click += btnRefresh_Click;
            btnViewDetails = new Button { Text = "View Details", Location = new System.Drawing.Point(460, 710), Size = new System.Drawing.Size(100, 30) };
            btnViewDetails.Click += btnViewDetails_Click;
            btnLogout = new Button { Text = "Logout", Location = new System.Drawing.Point(850, 20), Size = new System.Drawing.Size(100, 30) };
            btnLogout.Click += btnLogout_Click;

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnViewDetails);
            this.Controls.Add(btnLogout);

            // Ensure controls are layered correctly
            lblTotalRevenue.BringToFront();
            lblTotalLaptops.BringToFront();
            lblTotalComponents.BringToFront();
            cmbYear.BringToFront();
            btnShowRevenue.BringToFront();
            dgvMonthlyRevenue.BringToFront();
            dgvData.BringToFront();
            btnUser.BringToFront();
            btnInvoice.BringToFront();
            btnInvoiceItem.BringToFront();
            btnProduct.BringToFront();
            btnSupplier.BringToFront();
            btnWarrantyVoucher.BringToFront();
            btnAdd.BringToFront();
            btnEdit.BringToFront();
            btnDelete.BringToFront();
            btnRefresh.BringToFront();
            btnViewDetails.BringToFront();
            btnLogout.BringToFront();

            // Cấu hình PrintDocument và PrintPreviewDialog
            this.printDocument.PrintPage += PrintDocument_PrintPage;
            this.printPreviewDialog.Document = printDocument;
            this.printPreviewDialog.Width = 800;
            this.printPreviewDialog.Height = 600;
            btnPrintInvoice = new Button { Text = "In hóa đơn", Location = new System.Drawing.Point(570, 710), Size = new System.Drawing.Size(100, 30) };
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            this.Controls.Add(btnPrintInvoice);
            btnPrintInvoice.BringToFront();


        }

        // Updates the statistics labels with total revenue, laptops, and components sold
        private void UpdateStatistics()
        {
            decimal totalRevenue = BSUser.GetTotalRevenue();
            int totalLaptops = BSUser.GetTotalLaptopsSold();
            int totalComponents = BSUser.GetTotalComponentsSold();
            decimal laptopRevenue = BSUser.GetLaptopRevenue();
            decimal componentRevenue = BSUser.GetComponentRevenue();

            lblTotalRevenue.Text = $"Tổng doanh thu: {totalRevenue:N2} VND (Laptop: {laptopRevenue:N2}, Linh kiện: {componentRevenue:N2})";
            lblTotalLaptops.Text = $"Tổng số laptop: {totalLaptops}";
            lblTotalComponents.Text = $"Tổng số linh kiện: {totalComponents}";
        }

        // Populates the year ComboBox with distinct years from invoices
        private void PopulateYearComboBox()
        {
            try
            {
                string sql = "SELECT DISTINCT YEAR(InvoiceDate) AS Year FROM Invoice ORDER BY Year DESC";
                DataTable dt = DBMain.ExecuteSelectQuery(sql);
                cmbYear.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbYear.Items.Add(row["Year"].ToString());
                }
                // Add current year if no invoices exist
                int currentYear = DateTime.Now.Year;
                if (!cmbYear.Items.Contains(currentYear.ToString()))
                {
                    cmbYear.Items.Add(currentYear.ToString());
                }
                cmbYear.SelectedIndex = 0; // Select the most recent year
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách năm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Displays monthly revenue with laptop and component breakdowns for the selected year
        private void btnShowRevenue_Click(object sender, EventArgs e)
        {
            if (cmbYear.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một năm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int year = int.Parse(cmbYear.SelectedItem.ToString());
                DataTable dt = BSInvoice.GetMonthlyRevenue(year);

                // Create a DataTable for all 12 months
                DataTable resultTable = new DataTable();
                resultTable.Columns.Add("Month", typeof(string));
                resultTable.Columns.Add("Revenue", typeof(decimal));
                resultTable.Columns.Add("LaptopRevenue", typeof(decimal));
                resultTable.Columns.Add("ComponentRevenue", typeof(decimal));

                string[] monthNames = new string[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6",
                                                    "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
                for (int i = 1; i <= 12; i++)
                {
                    DataRow newRow = resultTable.NewRow();
                    newRow["Month"] = monthNames[i - 1];
                    newRow["Revenue"] = 0;
                    newRow["LaptopRevenue"] = 0;
                    newRow["ComponentRevenue"] = 0;
                    resultTable.Rows.Add(newRow);
                }

                // Update revenue data from query results
                foreach (DataRow row in dt.Rows)
                {
                    int month = Convert.ToInt32(row["Month"]);
                    decimal revenue = Convert.ToDecimal(row["Revenue"]);
                    decimal laptopRevenue = Convert.ToDecimal(row["LaptopRevenue"]);
                    decimal componentRevenue = Convert.ToDecimal(row["ComponentRevenue"]);
                    resultTable.Rows[month - 1]["Revenue"] = revenue;
                    resultTable.Rows[month - 1]["LaptopRevenue"] = laptopRevenue;
                    resultTable.Rows[month - 1]["ComponentRevenue"] = componentRevenue;
                }

                dgvMonthlyRevenue.DataSource = resultTable;
                dgvMonthlyRevenue.Columns["Revenue"].DefaultCellStyle.Format = "N2";
                dgvMonthlyRevenue.Columns["LaptopRevenue"].DefaultCellStyle.Format = "N2";
                dgvMonthlyRevenue.Columns["ComponentRevenue"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thống kê doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads the User table data into the main DataGridView
        private void LoadUser()
        {
            try
            {
                DataTable dt = BSUser.GetUsers();
                dt.TableName = "User";
                dgvData.DataSource = dt;
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách User: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads the Invoice table data into the main DataGridView
        private void LoadInvoice()
        {
            try
            {
                DataTable dt = BSInvoice.GetInvoice();
                dt.TableName = "Invoice";
                dgvData.DataSource = dt;
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách Invoice: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads the InvoiceItem table data into the main DataGridView
        private void LoadInvoiceItem()
        {
            try
            {
                DataTable dt = BSInvoiceItem.GetInvoiceItems(0); // Placeholder: Replace with actual method if exists
                dt.TableName = "InvoiceItem";
                dgvData.DataSource = dt;
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách InvoiceItem: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads the Product table data into the main DataGridView
        private void LoadProduct()
        {
            try
            {
                DataTable dt = BSProduct.GetAllProducts(); // Placeholder: Replace with actual method if exists
                dt.TableName = "Product";
                dgvData.DataSource = dt;
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách Product: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads the Supplier table data into the main DataGridView
        private void LoadSupplier()
        {
            try
            {
                DataTable dt = BSSupplier.GetAllSuppliers(); // Placeholder: Replace with actual method if exists
                dt.TableName = "Supplier";
                dgvData.DataSource = dt;
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách Supplier: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads the WarrantyVoucher table data into the main DataGridView
        private void LoadWarrantyVoucher()
        {
            try
            {
                DataTable dt = BSWarrantyVoucher.GetAllWarrantyVouchers(); // Placeholder: Replace with actual method if exists
                dt.TableName = "WarrantyVoucher";
                dgvData.DataSource = dt;
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách WarrantyVoucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Opens a form to add a new record to the current table
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvData.DataSource == null) return;

            DataTable dt = dgvData.DataSource as DataTable;
            if (dt == null) return;

            string tableName = GetTableNameFromDataSource();
            if (string.IsNullOrEmpty(tableName)) return;

            Form addForm = CreateAddForm(tableName);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCurrentTable();
            }
        }

        // Opens a form to edit the selected record
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để chỉnh sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvData.SelectedRows[0];
            string tableName = GetTableNameFromDataSource();
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Không xác định được bảng dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form editForm = CreateEditForm(tableName, row);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadCurrentTable();
            }
        }

        // Deletes the selected record after confirmation
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = dgvData.SelectedRows[0];
                string tableName = GetTableNameFromDataSource();
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Không xác định được bảng dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    if (tableName == "InvoiceItem")
                    {
                        int invoiceId = Convert.ToInt32(row.Cells["InvoiceId"].Value);
                        int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                        if (BSInvoiceItem.DeleteInvoiceItem(invoiceId, productId)) // Placeholder: Replace with actual method
                        {
                            MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCurrentTable();
                        }
                        else
                        {
                            MessageBox.Show("Xóa bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (tableName == "[User]")
                    {
                        int userId = Convert.ToInt32(row.Cells["UserId"].Value);
                        if (BSUser.DeleteUser(userId))
                        {
                            MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCurrentTable();
                        }
                        else
                        {
                            MessageBox.Show("Xóa bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (tableName == "Invoice")
                    {
                        int invoiceId = Convert.ToInt32(row.Cells["InvoiceId"].Value);
                        if (BSInvoice.DeleteInvoice(invoiceId))
                        {
                            MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCurrentTable();
                        }
                        else
                        {
                            MessageBox.Show("Xóa bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (tableName == "Product")
                    {
                        int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                        if (BSProduct.DeleteProduct(productId)) // Placeholder: Replace with actual method
                        {
                            MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCurrentTable();
                        }
                        else
                        {
                            MessageBox.Show("Xóa bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (tableName == "Supplier")
                    {
                        int supplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                        if (BSSupplier.DeleteSupplier(supplierId)) // Placeholder: Replace with actual method
                        {
                            MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCurrentTable();
                        }
                        else
                        {
                            MessageBox.Show("Xóa bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (tableName == "WarrantyVoucher")
                    {
                        int voucherId = Convert.ToInt32(row.Cells["VoucherId"].Value);
                        if (BSWarrantyVoucher.DeleteWarrantyVoucher(voucherId)) // Placeholder: Replace with actual method
                        {
                            MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCurrentTable();
                        }
                        else
                        {
                            MessageBox.Show("Xóa bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa bản ghi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Refreshes the current table data
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCurrentTable();
        }

        // Logs out the user and opens the login form
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        // Opens a form to view customer details if a customer is selected
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xem chi tiết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvData.SelectedRows[0];
            string tableName = GetTableNameFromDataSource();
            if (tableName != "[User]")
            {
                MessageBox.Show("Chức năng này chỉ khả dụng khi xem bảng User!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string role = row.Cells["Role"].Value.ToString();
            if (role != "Customer")
            {
                MessageBox.Show("Vui lòng chọn một tài khoản có vai trò Customer!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(row.Cells["UserId"].Value);
            CustomerDetailsForm detailsForm = new CustomerDetailsForm(userId);
            detailsForm.ShowDialog();
        }

        // Determines the current table name from the DataGridView's data source
        private string GetTableNameFromDataSource()
        {
            if (dgvData.DataSource is DataTable dt)
            {
                string tableName = dt.TableName.ToLower();
                if (tableName == "user") return "[User]";
                if (tableName == "invoice") return "Invoice";
                if (tableName == "invoiceitem") return "InvoiceItem";
                if (tableName == "product") return "Product";
                if (tableName == "supplier") return "Supplier";
                if (tableName == "warrantyvoucher") return "WarrantyVoucher";
                return null;
            }
            return null;
        }

        // Returns the primary key column name for a given table
        private string GetIdColumn(string tableName)
        {
            if (tableName == "[User]") return "UserId";
            if (tableName == "Invoice") return "InvoiceId";
            if (tableName == "InvoiceItem") return null; // InvoiceItem uses composite key
            if (tableName == "Product") return "ProductId";
            if (tableName == "Supplier") return "SupplierId";
            if (tableName == "WarrantyVoucher") return "VoucherId";
            return null;
        }

        // Reloads the current table based on the DataGridView's data source
        private void LoadCurrentTable()
        {
            string tableName = GetTableNameFromDataSource();
            if (tableName == null)
            {
                LoadUser(); // Default to User table
                return;
            }

            if (tableName.ToLower() == "[user]") LoadUser();
            else if (tableName.ToLower() == "invoice") LoadInvoice();
            else if (tableName.ToLower() == "invoiceitem") LoadInvoiceItem();
            else if (tableName.ToLower() == "product") LoadProduct();
            else if (tableName.ToLower() == "supplier") LoadSupplier();
            else if (tableName.ToLower() == "warrantyvoucher") LoadWarrantyVoucher();
        }

        // Creates a form for adding a new record to the specified table
        private Form CreateAddForm(string tableName)
        {
            Form form = new Form { Text = $"Add {tableName}", Size = new System.Drawing.Size(300, 300) };
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 6, ColumnCount = 2 };
            TextBox[] textBoxes = new TextBox[5];
            Label[] labels = new Label[5];

            string[] fields = GetFieldsForTable(tableName);
            for (int i = 0; i < 5 && i < fields.Length; i++)
            {
                labels[i] = new Label { Text = fields[i] + ":", Dock = DockStyle.Fill };
                textBoxes[i] = new TextBox { Dock = DockStyle.Fill };
                panel.Controls.Add(labels[i], 0, i);
                panel.Controls.Add(textBoxes[i], 1, i);
            }

            Button btnSave = new Button { Text = "Save", Dock = DockStyle.Bottom, Height = 30 };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    bool success = false;
                    if (tableName == "[User]")
                    {
                        success = BSUser.AddUser(textBoxes[0].Text, textBoxes[1].Text, textBoxes[2].Text, (char.ToUpper(textBoxes[3].Text[0]) + textBoxes[3].Text.Substring(1)), (char.ToUpper(textBoxes[4].Text[0]) + textBoxes[4].Text.Substring(1)));
                    }
                    else if (tableName == "Invoice")
                    {
                        int customerId = int.Parse(textBoxes[0].Text);
                        int employeeId = int.Parse(textBoxes[1].Text);
                        DateTime invoiceDate = DateTime.Parse(textBoxes[2].Text);
                        decimal totalAmount = decimal.Parse(textBoxes[3].Text);
                        success = BSInvoice.AddInvoice(customerId, employeeId, invoiceDate, totalAmount, "InStore");
                    }
                    else if (tableName == "InvoiceItem")
                    {
                        int invoiceId = int.Parse(textBoxes[0].Text);
                        int productId = int.Parse(textBoxes[1].Text);
                        int quantity = int.Parse(textBoxes[2].Text);
                        decimal unitPrice = decimal.Parse(textBoxes[3].Text);
                        success = BSInvoiceItem.AddInvoiceItem(invoiceId, productId, quantity, unitPrice); // Placeholder
                    }
                    else if (tableName == "Product")
                    {
                        int supplierId = int.Parse(textBoxes[0].Text);
                        string name = textBoxes[1].Text;
                        decimal unitPrice = decimal.Parse(textBoxes[2].Text);
                        int stockQuantity = int.Parse(textBoxes[3].Text);
                        success = BSProduct.AddProduct(supplierId, name, unitPrice, stockQuantity); // Placeholder
                    }
                    else if (tableName == "Supplier")
                    {
                        string name = textBoxes[0].Text;
                        success = BSSupplier.AddSupplier(name); // Placeholder
                    }
                    else if (tableName == "WarrantyVoucher")
                    {
                        int invoiceId = int.Parse(textBoxes[0].Text);
                        int productId = int.Parse(textBoxes[1].Text);
                        DateTime issueDate = DateTime.Parse(textBoxes[2].Text);
                        DateTime expiryDate = DateTime.Parse(textBoxes[3].Text);
                        success = BSWarrantyVoucher.AddWarrantyVoucher(invoiceId, productId, issueDate, expiryDate); // Placeholder
                    }

                    if (success)
                    {
                        MessageBox.Show("Thêm bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Thêm bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi thêm bản ghi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            panel.Controls.Add(btnSave, 1, 5);
            form.Controls.Add(panel);
            return form;
        }

        // Creates a form for editing an existing record
        private Form CreateEditForm(string tableName, DataGridViewRow row)
        {
            Form form = new Form { Text = $"Edit {tableName}", Size = new System.Drawing.Size(300, 300) };
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 6, ColumnCount = 2 };
            TextBox[] textBoxes = new TextBox[5];
            Label[] labels = new Label[5];

            string[] fields = GetFieldsForTable(tableName);
            string idColumn = GetIdColumn(tableName);
            int id = tableName == "InvoiceItem" ? 0 : Convert.ToInt32(row.Cells[idColumn].Value);

            for (int i = 0; i < 5 && i < fields.Length; i++)
            {
                labels[i] = new Label { Text = fields[i] + ":", Dock = DockStyle.Fill };
                textBoxes[i] = new TextBox { Dock = DockStyle.Fill, Text = row.Cells[fields[i]].Value?.ToString() ?? "" };
                panel.Controls.Add(labels[i], 0, i);
                panel.Controls.Add(textBoxes[i], 1, i);
            }

            Button btnSave = new Button { Text = "Save", Dock = DockStyle.Bottom, Height = 30 };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    bool success = false;
                    if (tableName == "[User]")
                    {
                        success = BSUser.UpdateUser(Convert.ToInt32(row.Cells["UserId"].Value), textBoxes[0].Text, textBoxes[1].Text, textBoxes[2].Text, textBoxes[3].Text, textBoxes[4].Text);
                    }
                    else if (tableName == "Invoice")
                    {
                        int invoiceId = Convert.ToInt32(row.Cells["InvoiceId"].Value);
                        int customerId = int.Parse(textBoxes[0].Text);
                        int employeeId = int.Parse(textBoxes[1].Text);
                        DateTime invoiceDate = DateTime.Parse(textBoxes[2].Text);
                        decimal totalAmount = decimal.Parse(textBoxes[3].Text);
                        success = BSInvoice.UpdateInvoice(invoiceId, customerId, employeeId, invoiceDate, totalAmount, "InStore");
                    }
                    else if (tableName == "InvoiceItem")
                    {
                        int invoiceId = Convert.ToInt32(row.Cells["InvoiceId"].Value);
                        int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                        int quantity = int.Parse(textBoxes[2].Text);
                        decimal unitPrice = decimal.Parse(textBoxes[3].Text);
                        success = BSInvoiceItem.UpdateInvoiceItem(invoiceId, productId, quantity, unitPrice); // Placeholder
                    }
                    else if (tableName == "Product")
                    {
                        int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                        int supplierId = int.Parse(textBoxes[0].Text);
                        string name = textBoxes[1].Text;
                        decimal unitPrice = decimal.Parse(textBoxes[2].Text);
                        int stockQuantity = int.Parse(textBoxes[3].Text);
                        success = BSProduct.UpdateProduct(productId, supplierId, name, unitPrice, stockQuantity); // Placeholder
                    }
                    else if (tableName == "Supplier")
                    {
                        int supplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                        string name = textBoxes[0].Text;
                        success = BSSupplier.UpdateSupplier(supplierId, name); // Placeholder
                    }
                    else if (tableName == "WarrantyVoucher")
                    {
                        int voucherId = Convert.ToInt32(row.Cells["VoucherId"].Value);
                        int invoiceId = int.Parse(textBoxes[0].Text);
                        int productId = int.Parse(textBoxes[1].Text);
                        DateTime issueDate = DateTime.Parse(textBoxes[2].Text);
                        DateTime expiryDate = DateTime.Parse(textBoxes[3].Text);
                        success = BSWarrantyVoucher.UpdateWarrantyVoucher(voucherId, invoiceId, productId, issueDate, expiryDate); // Placeholder
                    }

                    if (success)
                    {
                        MessageBox.Show("Cập nhật bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật bản ghi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi cập nhật bản ghi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            panel.Controls.Add(btnSave, 1, 5);
            form.Controls.Add(panel);
            return form;
        }

        // Returns the field names for a given table for form creation
        private string[] GetFieldsForTable(string tableName)
        {
            if (tableName == "[User]") return new[] { "Username", "Email", "Password", "Role", "Status" };
            if (tableName == "Invoice") return new[] { "CustomerId", "EmployeeId", "InvoiceDate", "TotalAmount" };
            if (tableName == "InvoiceItem") return new[] { "InvoiceId", "ProductId", "Quantity", "UnitPrice" };
            if (tableName == "Product") return new[] { "SupplierId", "Name", "UnitPrice", "StockQuantity" };
            if (tableName == "Supplier") return new[] { "Name" };
            if (tableName == "WarrantyVoucher") return new[] { "InvoiceId", "ProductId", "IssueDate", "ExpiryDate" };
            return new string[0];
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy InvoiceId từ dòng được chọn
            selectedInvoiceId = Convert.ToInt32(dgvData.SelectedRows[0].Cells["InvoiceId"].Value);

            // Lấy thông tin hóa đơn và chi tiết hóa đơn
            invoiceInfo = BSInvoice.GetInvoiceById(selectedInvoiceId);
            invoiceDetails = BSInvoice.GetInvoiceItems(selectedInvoiceId);

            // Hiển thị xem trước bản in
            printPreviewDialog.ShowDialog();
        }
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float y = 20;
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 200, y);
            y += 40;

            e.Graphics.DrawString($"Mã hóa đơn: {invoiceInfo["InvoiceId"]}", font, Brushes.Black, 50, y); y += 25;
            e.Graphics.DrawString($"Khách hàng: {invoiceInfo["CustomerName"]}", font, Brushes.Black, 50, y); y += 25;
            e.Graphics.DrawString($"Ngày lập: {Convert.ToDateTime(invoiceInfo["InvoiceDate"]).ToString("dd/MM/yyyy")}", font, Brushes.Black, 50, y); y += 25;
            e.Graphics.DrawString($"Tổng tiền: {invoiceInfo["TotalAmount"]:N0} VND", font, Brushes.Black, 50, y); y += 40;

            e.Graphics.DrawString("Sản phẩm", font, Brushes.Black, 50, y);
            e.Graphics.DrawString("Số lượng", font, Brushes.Black, 250, y);
            e.Graphics.DrawString("Đơn giá", font, Brushes.Black, 350, y);
            e.Graphics.DrawString("Thành tiền", font, Brushes.Black, 450, y);
            y += 25;

            foreach (DataRow row in invoiceDetails.Rows)
            {
                e.Graphics.DrawString(row["ProductName"].ToString(), font, Brushes.Black, 50, y);
                e.Graphics.DrawString(row["Quantity"].ToString(), font, Brushes.Black, 250, y);
                e.Graphics.DrawString($"{row["UnitPrice"]:N0}", font, Brushes.Black, 350, y);
                e.Graphics.DrawString($"{Convert.ToInt32(row["Quantity"]) * Convert.ToDecimal(row["UnitPrice"]):N0}", font, Brushes.Black, 450, y);
                y += 25;
            }
        }



    }
}