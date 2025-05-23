using DoAnCKver1.DBLayer;
using DoAnCKver1.Model;
using System;
using System.Data;

namespace DoAnCKver1.BSLayer
{
    internal class BSSupplier
    {
        // Lấy danh sách tất cả nhà cung cấp
        public static DataTable GetAllSuppliers()
        {
            string sql = "SELECT * FROM Supplier";
            return DBMain.ExecuteSelectQuery(sql);
        }

        // Thêm nhà cung cấp
        public static bool AddSupplier(string name)
        {
            // Kiểm tra tồn tại
            string checkSql = "SELECT COUNT(*) FROM Supplier WHERE Name = '" + name + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists > 0) return false;

            // Chèn mới
            string insertSql = "INSERT INTO Supplier (Name) VALUES ('" + name + "')";
            return DBMain.ExecuteNonQuery(insertSql) > 0;
        }

        // Cập nhật nhà cung cấp
        public static bool UpdateSupplier(int supplierId, string name)
        {
            // Kiểm tra tồn tại
            string checkSql = "SELECT COUNT(*) FROM Supplier WHERE SupplierId = '" + supplierId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Cập nhật
            string updateSql = "UPDATE Supplier SET Name = '" + name + "' WHERE SupplierId = '" + supplierId + "'";
            return DBMain.ExecuteNonQuery(updateSql) > 0;
        }

        // Xóa nhà cung cấp
        public static bool DeleteSupplier(int supplierId)
        {
            // Kiểm tra tồn tại
            string checkSql = "SELECT COUNT(*) FROM Supplier WHERE SupplierId = '" + supplierId + "'";
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Xóa
            string deleteSql = "DELETE FROM Supplier WHERE SupplierId = '" + supplierId + "'";
            return DBMain.ExecuteNonQuery(deleteSql) > 0;
        }

        // Tìm nhà cung cấp theo tên
        public static DataTable SearchSuppliers(string name)
        {
            string sql = "SELECT * FROM Supplier WHERE Name LIKE '%" + name + "%'";
            return DBMain.ExecuteSelectQuery(sql);
        }
    }
}