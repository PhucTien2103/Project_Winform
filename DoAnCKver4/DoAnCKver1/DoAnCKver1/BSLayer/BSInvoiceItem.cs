using DoAnCKver1.DBLayer;
using DoAnCKver1.Model;
using System;
using System.Data;

namespace DoAnCKver1.BSLayer
{
    internal class BSInvoiceItem
    {
        // Lấy danh sách chi tiết hóa đơn theo InvoiceId
        public static DataTable GetInvoiceItems(int invoiceId)
        {
            string query = "SELECT InvoiceId, ProductId, Quantity, UnitPrice FROM InvoiceItem";
            DataTable dt = DBMain.ExecuteSelectQuery(query);
            return dt;
        }

        // Thêm chi tiết hóa đơn
        public static bool AddInvoiceItem(int invoiceId, int productId, int quantity, decimal unitPrice)
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
            string insertSql = "INSERT INTO InvoiceItem (InvoiceId, ProductId, Quantity, UnitPrice) VALUES ('" + invoiceId + "', '" + productId + "', '" + quantity + "', '" + unitPrice + "')";
            return DBMain.ExecuteNonQuery(insertSql) > 0;
        }

        // Cập nhật chi tiết hóa đơn
        public static bool UpdateInvoiceItem(int invoiceId, int productId, int quantity, decimal unitPrice)
        {
            // Kiểm tra chi tiết hóa đơn tồn tại
            string checkSql = "SELECT COUNT(*) FROM InvoiceItem WHERE InvoiceId = '" + invoiceId + "' AND ProductId = '" + productId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Cập nhật
            string updateSql = "UPDATE InvoiceItem SET Quantity = '" + quantity + "', UnitPrice = '" + unitPrice + "' WHERE InvoiceId = '" + invoiceId + "' AND ProductId = '" + productId + "'";
            return DBMain.ExecuteNonQuery(updateSql) > 0;
        }

        // Xóa chi tiết hóa đơn
        public static bool DeleteInvoiceItem(int invoiceId, int productId)
        {
            // Kiểm tra chi tiết hóa đơn tồn tại
            string checkSql = "SELECT COUNT(*) FROM InvoiceItem WHERE InvoiceId = '" + invoiceId + "' AND ProductId = '" + productId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Xóa
            string deleteSql = "DELETE FROM InvoiceItem WHERE InvoiceId = '" + invoiceId + "' AND ProductId = '" + productId + "'";
            return DBMain.ExecuteNonQuery(deleteSql) > 0;
        }
    }
}