using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DoAnCKver1.BSLayer;
using DoAnCKver1.Model;

namespace DoAnCKver1
{
    public partial class EmployeeForm : Form
    {
        private User currentUser;
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        public EmployeeForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            // Cấu hình PrintDocument
            this.printDocument.PrintPage += PrintDocument_PrintPage;
            // Cấu hình PrintPreviewDialog
            this.printPreviewDialog.Document = printDocument;
            this.printPreviewDialog.Width = 800;
            this.printPreviewDialog.Height = 600;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            lblEmployeeName.Text = "Nhân viên: " + currentUser.Username;
            // Khởi tạo data
            InitializeControls();
        }

        private void InitializeControls()
        {
            LoadInvoices();
            LoadProducts();
            LoadWarrantyVouchers();

            // ComboBox
            comboBoxCustomer.DataSource = BSUser.GetAllCustomer();
            comboBoxCustomer.DisplayMember = "Username";
            comboBoxCustomer.ValueMember = "UserId";

            comboBoxSupplier.DataSource = BSSupplier.GetAllSuppliers();
            comboBoxSupplier.DisplayMember = "Name";
            comboBoxSupplier.ValueMember = "SupplierId";

            comboBoxProduct.DataSource = BSProduct.GetAllProducts();
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "ProductId";

            comboBoxInvoice.DataSource = BSInvoice.GetInvoice();
            comboBoxInvoice.DisplayMember = "InvoiceId";
            comboBoxInvoice.ValueMember = "InvoiceId";
        }

        private void LoadInvoices()
        {
            dataGridViewInvoices.DataSource = BSInvoice.GetInvoice();
        }

        private void LoadProducts()
        {
            dataGridViewProducts.DataSource = BSProduct.GetAllProducts();
        }

        private void LoadWarrantyVouchers()
        {
            dataGridViewWarrantyVouchers.DataSource = BSWarrantyVoucher.GetAllWarrantyVouchers();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(comboBoxCustomer.SelectedValue is int customerId))
                {
                    MessageBox.Show("Chưa chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int employeeId = currentUser.UserId;
                DateTime invoiceDate = dateTimePickerInvoiceDate.Value;
                if (!decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount))
                {
                    MessageBox.Show($"Tổng tiền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSInvoice.AddInvoice(customerId, employeeId, invoiceDate, totalAmount, "InStore");
                if (success)
                {
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi thêm hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtInvoiceId.Text, out int invoiceId))
                {
                    MessageBox.Show("ID hóa đơn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!(comboBoxCustomer.SelectedValue is int customerId))
                {
                    MessageBox.Show("Chưa chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int employeeId = currentUser.UserId;
                DateTime invoiceDate = dateTimePickerInvoiceDate.Value;
                if (!decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount))
                {
                    MessageBox.Show($"Tổng tiền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSInvoice.UpdateInvoice(invoiceId, customerId, employeeId, invoiceDate, totalAmount, "InStore");
                if (success)
                {
                    MessageBox.Show("Sửa hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi sửa hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtInvoiceId.Text, out int invoiceId))
                {
                    MessageBox.Show("ID hóa đơn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSInvoice.DeleteInvoice(invoiceId);
                if (success)
                {
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi xóa hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchInvoices_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerFromDate.Value;
            DateTime toDate = dateTimePickerToDate.Value;
            dataGridViewInvoices.DataSource = BSInvoice.SearchInvoices(fromDate, toDate);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(comboBoxSupplier.SelectedValue is int supplierId))
                {
                    MessageBox.Show("Chưa chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string name = txtProductName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) || unitPrice < 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtStockQuantity.Text, out int stockQuantity) || stockQuantity < 0)
                {
                    MessageBox.Show("Số lượng tồn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSProduct.AddProduct(supplierId, name, unitPrice, stockQuantity);
                if (success)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi thêm sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductId.Text, out int productId))
                {
                    MessageBox.Show("ID sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!(comboBoxSupplier.SelectedValue is int supplierId))
                {
                    MessageBox.Show("Chưa chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string name = txtProductName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) || unitPrice < 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtStockQuantity.Text, out int stockQuantity) || stockQuantity < 0)
                {
                    MessageBox.Show("Số lượng tồn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSProduct.UpdateProduct(productId, supplierId, name, unitPrice, stockQuantity);
                if (success)
                {
                    MessageBox.Show("Sửa sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi sửa sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductId.Text, out int productId))
                {
                    MessageBox.Show("ID sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSProduct.DeleteProduct(productId);
                if (success)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi xóa sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchProducts_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchProduct.Text.Trim();
            dataGridViewProducts.DataSource = BSProduct.SearchProducts(keyword);
        }

        private void btnAddWarrantyVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(comboBoxInvoice.SelectedValue is int invoiceId))
                {
                    MessageBox.Show("Chưa chọn hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!(comboBoxProduct.SelectedValue is int productId))
                {
                    MessageBox.Show("Chưa chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime issueDate = dateTimePickerIssueDate.Value;
                DateTime expiryDate = dateTimePickerExpiryDate.Value;
                if (expiryDate < issueDate)
                {
                    MessageBox.Show("Ngày hết hạn phải sau ngày lập phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSWarrantyVoucher.AddWarrantyVoucher(invoiceId, productId, issueDate, expiryDate);
                if (success)
                {
                    MessageBox.Show("Thêm phiếu bảo hành thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi thêm phiếu bảo hành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateWarrantyVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtVoucherId.Text, out int voucherId))
                {
                    MessageBox.Show("ID phiếu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!(comboBoxInvoice.SelectedValue is int invoiceId))
                {
                    MessageBox.Show("Chưa chọn hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!(comboBoxProduct.SelectedValue is int productId))
                {
                    MessageBox.Show("Chưa chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime issueDate = dateTimePickerIssueDate.Value;
                DateTime expiryDate = dateTimePickerExpiryDate.Value;
                if (expiryDate < issueDate)
                {
                    MessageBox.Show("Ngày hết hạn phải sau ngày lập phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSWarrantyVoucher.UpdateWarrantyVoucher(voucherId, invoiceId, productId, issueDate, expiryDate);
                if (success)
                {
                    MessageBox.Show("Sửa phiếu bảo hành thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi sửa phiếu bảo hành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteWarrantyVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtVoucherId.Text, out int voucherId))
                {
                    MessageBox.Show("ID phiếu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = BSWarrantyVoucher.DeleteWarrantyVoucher(voucherId);
                if (success)
                {
                    MessageBox.Show("Xóa phiếu bảo hành thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeControls();
                }
                else
                    MessageBox.Show("Lỗi khi xóa phiếu bảo hành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchWarrantyVouchers_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedValue is int productId)
            {
                dataGridViewWarrantyVouchers.DataSource = BSWarrantyVoucher.SearchWarrantyVouchers(productId);
            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm để tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedInvoiceId = Convert.ToInt32(dataGridViewInvoices.SelectedRows[0].Cells["InvoiceId"].Value);

            // Lấy thông tin hóa đơn và chi tiết hóa đơn
            invoiceInfo = BSInvoice.GetInvoiceById(selectedInvoiceId);
            invoiceDetails = BSInvoice.GetInvoiceItems(selectedInvoiceId);

            // Hiển thị xem trước bản in
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
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

        private void dataGridViewInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count > 0)
            {
                int invoiceId = Convert.ToInt32(dataGridViewInvoices.SelectedRows[0].Cells["InvoiceId"].Value);
                dataGridViewInvoiceDetails.DataSource = BSInvoice.GetInvoiceItems(invoiceId);
            }
            else
            {
                dataGridViewInvoiceDetails.DataSource = null;
            }
        }



        private void txtInvoiceId_TextChanged(object sender, EventArgs e)
        {
            // Xử lý khi thay đổi mã hóa đơn (nếu cần)
        }

        private void tabProducts_Click(object sender, EventArgs e)
        {
            // Xử lý khi click vào tab Sản phẩm (nếu cần)
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            // Xử lý khi thay đổi mã sản phẩm (nếu cần)
        }

        private void tabWarrantyVouchers_Click(object sender, EventArgs e)
        {
            // Xử lý khi click vào tab Phiếu bảo hành (nếu cần)
        }

        private void dateTimePickerIssueDate_ValueChanged(object sender, EventArgs e)
        {
            // Xử lý khi thay đổi ngày cấp phiếu bảo hành (nếu cần)
        }
    }
}
