using DoAnCKver1.DBLayer;
using DoAnCKver1.Model;
using System;
using System.Data;

namespace DoAnCKver1.BSLayer
{
    internal class BSWarrantyVoucher
    {
        // Lấy danh sách tất cả phiếu bảo hành
        public static DataTable GetAllWarrantyVouchers()
        {
            string sql = "SELECT w.*, p.Name AS ProductName FROM WarrantyVoucher w JOIN Product p ON w.ProductId = p.ProductId";
            return DBMain.ExecuteSelectQuery(sql);
        }

        // Thêm phiếu bảo hành
        public static bool AddWarrantyVoucher(int invoiceId, int productId, DateTime issueDate, DateTime expiryDate)
        {
            // Kiểm tra hóa đơn tồn tại
            string checkInvoiceSql = "SELECT COUNT(*) FROM Invoice WHERE InvoiceId = '" + invoiceId + "'";
            DataTable dtChkInvoice = DBMain.ExecuteSelectQuery(checkInvoiceSql);
            int invoiceExists = Convert.ToInt32(dtChkInvoice.Rows[0][0]);
            if (invoiceExists == 0) return false;

            // Kiểm tra sản phẩm tồn tại
            string checkProductSql = "SELECT COUNT(*) FROM Product WHERE ProductId = '" + productId + "'";
            DataTable dtChkProduct = DBMain.ExecuteSelectQuery(checkProductSql);
            int productExists = Convert.ToInt32(dtChkProduct.Rows[0][0]);
            if (productExists == 0) return false;

            // Chèn mới
            string insertSql = "INSERT INTO WarrantyVoucher (InvoiceId, ProductId, IssueDate, ExpiryDate) VALUES ('" + invoiceId + "', '" + productId + "', '" + issueDate + "', '" + expiryDate + "')";
            return DBMain.ExecuteNonQuery(insertSql) > 0;
        }

        // Cập nhật phiếu bảo hành
        public static bool UpdateWarrantyVoucher(int voucherId, int invoiceId, int productId, DateTime issueDate, DateTime expiryDate)
        {
            // Kiểm tra phiếu bảo hành tồn tại
            string checkSql = "SELECT COUNT(*) FROM WarrantyVoucher WHERE VoucherId = '" + voucherId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Kiểm tra hóa đơn tồn tại
            string checkInvoiceSql = "SELECT COUNT(*) FROM Invoice WHERE InvoiceId = '" + invoiceId + "'";
            DataTable dtChkInvoice = DBMain.ExecuteSelectQuery(checkInvoiceSql);
            int invoiceExists = Convert.ToInt32(dtChkInvoice.Rows[0][0]);
            if (invoiceExists == 0) return false;

            // Kiểm tra sản phẩm tồn tại
            string checkProductSql = "SELECT COUNT(*) FROM Product WHERE ProductId = '" + productId + "'";
            DataTable dtChkProduct = DBMain.ExecuteSelectQuery(checkProductSql);
            int productExists = Convert.ToInt32(dtChkProduct.Rows[0][0]);
            if (productExists == 0) return false;

            // Cập nhật
            string updateSql = "UPDATE WarrantyVoucher SET InvoiceId = '" + invoiceId + "', ProductId = '" + productId + "', IssueDate = '" + issueDate + "', ExpiryDate = '" + expiryDate + "' WHERE VoucherId = '" + voucherId + "'";
            return DBMain.ExecuteNonQuery(updateSql) > 0;
        }

        // Xóa phiếu bảo hành
        public static bool DeleteWarrantyVoucher(int voucherId)
        {
            // Kiểm tra phiếu bảo hành tồn tại
            string checkSql = "SELECT COUNT(*) FROM WarrantyVoucher WHERE VoucherId = '" + voucherId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Xóa
            string deleteSql = "DELETE FROM WarrantyVoucher WHERE VoucherId = '" + voucherId + "'";
            return DBMain.ExecuteNonQuery(deleteSql) > 0;
        }

        // Tìm phiếu bảo hành theo sản phẩm
        public static DataTable SearchWarrantyVouchers(int productId)
        {
            string sql = "SELECT w.*, p.Name AS ProductName FROM WarrantyVoucher w JOIN Product p ON w.ProductId = p.ProductId WHERE w.ProductId = '" + productId + "'";
            return DBMain.ExecuteSelectQuery(sql);
        }
    }
}