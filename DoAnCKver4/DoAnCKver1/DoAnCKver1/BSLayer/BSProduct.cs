using DoAnCKver1.DBLayer;
using DoAnCKver1.Model;
using System;
using System.Data;

namespace DoAnCKver1.BSLayer
{
    internal class BSProduct
    {
        // Lấy danh sách tất cả sản phẩm
        public static DataTable GetAllProducts()
        {
            string sql = "SELECT p.*, s.Name AS SupplierName FROM Product p JOIN Supplier s ON p.SupplierId = s.SupplierId";
            return DBMain.ExecuteSelectQuery(sql);
        }

        // Thêm sản phẩm
        public static bool AddProduct(int supplierId, string name, decimal unitPrice, int stockQuantity)
        {
            // Kiểm tra nhà cung cấp tồn tại
            string checkSupplierSql = "SELECT COUNT(*) FROM Supplier WHERE SupplierId = '" + supplierId + "'";
            DataTable dtChkSupplier = DBMain.ExecuteSelectQuery(checkSupplierSql);
            int supplierExists = Convert.ToInt32(dtChkSupplier.Rows[0][0]);
            if (supplierExists == 0) return false;

            // Kiểm tra sản phẩm tồn tại
            string checkSql = "SELECT COUNT(*) FROM Product WHERE Name = '" + name + "' AND SupplierId = '" + supplierId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists > 0) return false;

            // Chèn mới
            string insertSql = "INSERT INTO Product (SupplierId, Name, UnitPrice, StockQuantity) VALUES ('" + supplierId + "', '" + name + "', '" + unitPrice + "', '" + stockQuantity + "')";
            return DBMain.ExecuteNonQuery(insertSql) > 0;
        }

        // Cập nhật sản phẩm
        public static bool UpdateProduct(int productId, int supplierId, string name, decimal unitPrice, int stockQuantity)
        {
            // Kiểm tra sản phẩm tồn tại
            string checkSql = "SELECT COUNT(*) FROM Product WHERE ProductId = '" + productId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Kiểm tra nhà cung cấp tồn tại
            string checkSupplierSql = "SELECT COUNT(*) FROM Supplier WHERE SupplierId = '" + supplierId + "'";
            DataTable dtChkSupplier = DBMain.ExecuteSelectQuery(checkSupplierSql);
            int supplierExists = Convert.ToInt32(dtChkSupplier.Rows[0][0]);
            if (supplierExists == 0) return false;

            // Cập nhật
            string updateSql = "UPDATE Product SET SupplierId = '" + supplierId + "', Name = '" + name + "', UnitPrice = '" + unitPrice + "', StockQuantity = '" + stockQuantity + "' WHERE ProductId = '" + productId + "'";
            return DBMain.ExecuteNonQuery(updateSql) > 0;
        }

        // Xóa sản phẩm
        public static bool DeleteProduct(int productId)
        {
            // Kiểm tra sản phẩm tồn tại
            string checkSql = "SELECT COUNT(*) FROM Product WHERE ProductId = '" + productId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Xóa
            string deleteSql = "DELETE FROM Product WHERE ProductId = '" + productId + "'";
            return DBMain.ExecuteNonQuery(deleteSql) > 0;
        }

        // Tìm sản phẩm theo tên
        public static DataTable SearchProducts(string name)
        {
            string sql = "SELECT p.*, s.Name AS SupplierName FROM Product p JOIN Supplier s ON p.SupplierId = s.SupplierId WHERE p.Name LIKE '%" + name + "%'";
            return DBMain.ExecuteSelectQuery(sql);
        }
    }
}