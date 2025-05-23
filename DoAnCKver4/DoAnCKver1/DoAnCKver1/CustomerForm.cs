using System;
using System.Data;
using System.Windows.Forms;
using DoAnCKver1.BSLayer;
using DoAnCKver1.Model;

namespace DoAnCKver1
{
    public partial class CustomerForm : Form
    {
        private int customerId;
        private User currentUser;

        public CustomerForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            customerId = user.UserId;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadPersonalInfo();
            LoadOrderHistory();
            LoadInvoiceDetails();
            LoadProducts();
            LoadWarranty();
        }

        // 1. Thông tin cá nhân
        private void LoadPersonalInfo()
        {
            DataTable dt = BSUser.GetCustomerDetails(customerId);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                txtUsername.Text = row["Username"].ToString();
                txtAccount.Text = row["Email"].ToString();
                txtPassword.Text = row["Password"].ToString();
                // Nếu có cột Address thì lấy, nếu không thì để trống
                txtAddress.Text = row.Table.Columns.Contains("Address") ? row["Address"].ToString() : "";
            }
            else
            {
                txtUsername.Text = "";
                txtAccount.Text = "";
                txtPassword.Text = "";
                txtAddress.Text = "";
            }
        }

        private void btnChangeAddress_Click(object sender, EventArgs e)
        {
            // Nếu không có cột Address, bỏ qua hoặc bổ sung ở DB và BSUser
            bool result = BSUser.UpdateUser(customerId, txtUsername.Text, txtAccount.Text, txtPassword.Text, "Customer", "Active");
            MessageBox.Show(result ? "Cập nhật địa chỉ thành công!" : "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // 2. Lịch sử mua hàng
        private void LoadOrderHistory()
        {
            DataTable dt = BSInvoice.GetInvoice();
            // Đảm bảo cột "CustomerId" và "InvoiceId" tồn tại
            if (!dt.Columns.Contains("CustomerId") || !dt.Columns.Contains("InvoiceId"))
            {
                dgvOrderHistory.DataSource = null;
                return;
            }
            DataView dv = new DataView(dt);
            dv.RowFilter = $"CustomerId = {customerId}";
            dgvOrderHistory.DataSource = dv.ToTable();
        }

        // 3. Hóa đơn chi tiết
        private void LoadInvoiceDetails()
        {
            DataTable dt = BSInvoice.GetInvoice();
            if (!dt.Columns.Contains("CustomerId") || !dt.Columns.Contains("InvoiceId"))
            {
                dgvInvoiceDetails.DataSource = null;
                return;
            }
            DataView dv = new DataView(dt);
            dv.RowFilter = $"CustomerId = {customerId}";
            dgvInvoiceDetails.DataSource = dv.ToTable();
        }

        // 4. Sản phẩm
        private void LoadProducts()
        {
            DataTable dt = BSProduct.GetAllProducts();
            // Đảm bảo các cột cần thiết tồn tại
            if (!dt.Columns.Contains("ProductId")) dt.Columns.Add("ProductId", typeof(int));
            if (!dt.Columns.Contains("Name")) dt.Columns.Add("Name", typeof(string));
            if (!dt.Columns.Contains("SupplierName")) dt.Columns.Add("SupplierName", typeof(string));
            if (!dt.Columns.Contains("UnitPrice")) dt.Columns.Add("UnitPrice", typeof(decimal));
            if (!dt.Columns.Contains("StockQuantity")) dt.Columns.Add("StockQuantity", typeof(int));
            if (!dt.Columns.Contains("Voucher")) dt.Columns.Add("Voucher", typeof(string));
            if (!dt.Columns.Contains("Stock")) dt.Columns.Add("Stock", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                int stock = row.Table.Columns.Contains("StockQuantity") && row["StockQuantity"] != DBNull.Value ? Convert.ToInt32(row["StockQuantity"]) : 0;
                row["Stock"] = stock > 0 ? "In Stock" : "Out of Stock";
            }
            dgvProducts.DataSource = dt;
        }

        // 5. Bảo hành
        private void LoadWarranty()
        {
            DataTable dt = BSWarrantyVoucher.GetAllWarrantyVouchers();
            DataTable dtInvoice = BSInvoice.GetInvoice();
            if (!dtInvoice.Columns.Contains("CustomerId") || !dtInvoice.Columns.Contains("InvoiceId"))
            {
                dgvWarranty.DataSource = null;
                return;
            }
            DataView dvInvoice = new DataView(dtInvoice);
            dvInvoice.RowFilter = $"CustomerId = {customerId}";
            var customerInvoiceIds = new System.Collections.Generic.HashSet<string>();
            foreach (DataRow row in dvInvoice.ToTable().Rows)
                customerInvoiceIds.Add(row["InvoiceId"].ToString());

            DataTable dtResult = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("InvoiceId") && customerInvoiceIds.Contains(row["InvoiceId"].ToString()))
                    dtResult.ImportRow(row);
            }
            dgvWarranty.DataSource = dtResult;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnShowPassword.Text = txtPassword.UseSystemPasswordChar ? "Hiện" : "Ẩn";
        }

        private void btnOrderProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string productId = dgvProducts.CurrentRow.Cells["ProductId"].Value.ToString();
            string productName = dgvProducts.CurrentRow.Cells["Name"].Value.ToString();
            string stock = dgvProducts.CurrentRow.Cells["Stock"].Value.ToString();

            if (stock == "Out of Stock" || stock == "Hết hàng")
            {
                MessageBox.Show("Sản phẩm này đã hết hàng, không thể đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Bạn đã chọn đặt hàng sản phẩm: {productName} (Mã: {productId})", "Đặt hàng thành công");
        }

        private void btnViewProductDetail_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string productId = dgvProducts.CurrentRow.Cells["ProductId"].Value.ToString();
            string productName = dgvProducts.CurrentRow.Cells["Name"].Value.ToString();
            string supplier = dgvProducts.CurrentRow.Cells["SupplierName"].Value.ToString();
            string price = dgvProducts.CurrentRow.Cells["UnitPrice"].Value.ToString();
            string stock = dgvProducts.CurrentRow.Cells["Stock"].Value.ToString();
            string voucher = dgvProducts.CurrentRow.Cells["Voucher"].Value.ToString();

            string detail = $"Tên sản phẩm: {productName}\nMã sản phẩm: {productId}\nNhà cung cấp: {supplier}\nGiá: {price}\nTình trạng: {stock}\nVoucher: {voucher}";
            MessageBox.Show(detail, "Chi tiết sản phẩm");
        }

        private void btnApplyVoucher_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để áp dụng voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string productName = dgvProducts.CurrentRow.Cells["Name"].Value.ToString();
            string voucher = dgvProducts.CurrentRow.Cells["Voucher"].Value.ToString();

            if (string.IsNullOrWhiteSpace(voucher))
            {
                MessageBox.Show("Sản phẩm này không có voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Đã áp dụng voucher cho sản phẩm: {productName}\nNội dung voucher: {voucher}", "Áp dụng voucher");
        }

        private void btnViewOrderDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrderHistory.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int invoiceId = Convert.ToInt32(dgvOrderHistory.CurrentRow.Cells["InvoiceId"].Value);
            DataTable dt = BSInvoice.GetInvoiceItems(invoiceId);
            MessageBox.Show($"Có {dt.Rows.Count} sản phẩm trong đơn hàng.", "Chi tiết đơn hàng");
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderHistory.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int invoiceId = Convert.ToInt32(dgvOrderHistory.CurrentRow.Cells["InvoiceId"].Value);
            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn hủy đơn hàng {invoiceId}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                bool result = BSInvoice.DeleteInvoice(invoiceId);
                MessageBox.Show(result ? "Đã hủy đơn hàng." : "Không thể hủy đơn hàng.", "Thông báo");
                LoadOrderHistory();
                LoadInvoiceDetails();
            }
        }

        private void btnReviewProduct_Click(object sender, EventArgs e)
        {
            if (dgvOrderHistory.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để đánh giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string orderId = dgvOrderHistory.CurrentRow.Cells["InvoiceId"].Value.ToString();
            MessageBox.Show($"Đánh giá sản phẩm trong đơn hàng: {orderId}", "Đánh giá sản phẩm");
        }

        private void btnViewInvoiceDetail_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceDetails.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int invoiceId = Convert.ToInt32(dgvInvoiceDetails.CurrentRow.Cells["InvoiceId"].Value);
            DataTable dt = BSInvoice.GetInvoiceItems(invoiceId);
            MessageBox.Show($"Có {dt.Rows.Count} sản phẩm trong hóa đơn.", "Chi tiết hóa đơn");
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceDetails.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int invoiceId = Convert.ToInt32(dgvInvoiceDetails.CurrentRow.Cells["InvoiceId"].Value);
            MessageBox.Show($"In hóa đơn: {invoiceId}", "In hóa đơn");
        }

        private void btnViewWarrantyDetail_Click(object sender, EventArgs e)
        {
            if (dgvWarranty.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xem chi tiết bảo hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string productName = dgvWarranty.CurrentRow.Cells["ProductName"].Value.ToString();
            MessageBox.Show($"Xem chi tiết bảo hành cho sản phẩm: {productName}", "Chi tiết bảo hành");
        }

        private void btnRequestWarranty_Click(object sender, EventArgs e)
        {
            if (dgvWarranty.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để yêu cầu bảo hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string productName = dgvWarranty.CurrentRow.Cells["ProductName"].Value.ToString();
            MessageBox.Show($"Đã gửi yêu cầu bảo hành cho sản phẩm: {productName}", "Yêu cầu bảo hành");
        }
    }
}
