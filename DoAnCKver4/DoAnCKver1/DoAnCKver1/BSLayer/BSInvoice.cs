using DoAnCKver1.DBLayer;
using DoAnCKver1.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DoAnCKver1.BSLayer
{
    internal class BSInvoice
    {
        // Retrieves a list of all invoices with basic details
        public static DataTable GetInvoice()
        {
            string query = "SELECT InvoiceId, CustomerId, EmployeeId, InvoiceDate, TotalAmount, OrderType, ShippingAddress FROM Invoice";
            DataTable dt = DBMain.ExecuteSelectQuery(query);
            return dt;
        }

        // Adds a new invoice after validating customer and employee
        public static bool AddInvoice(int customerId, int employeeId, DateTime invoiceDate, decimal totalAmount, string orderType)
        {
            // Check if customer exists
            string checkCustomerSql = "SELECT COUNT(*) FROM [User] WHERE UserId = @CustomerId AND Role = 'Customer'";
            SqlParameter[] checkCustomerParams = new SqlParameter[] { new SqlParameter("@CustomerId", customerId) };
            DataTable dtChkCustomer = DBMain.ExecuteSelectQuery(checkCustomerSql, checkCustomerParams);
            int customerExists = Convert.ToInt32(dtChkCustomer.Rows[0][0]);
            if (customerExists == 0) return false;

            // Check if employee exists
            string checkEmployeeSql = "SELECT COUNT(*) FROM [User] WHERE UserId = @EmployeeId AND Role IN ('Admin', 'Employee')";
            SqlParameter[] checkEmployeeParams = new SqlParameter[] { new SqlParameter("@EmployeeId", employeeId) };
            DataTable dtChkEmployee = DBMain.ExecuteSelectQuery(checkEmployeeSql, checkEmployeeParams);
            int employeeExists = Convert.ToInt32(dtChkEmployee.Rows[0][0]);
            if (employeeExists == 0) return false;

            // Insert new invoice
            string insertSql = "INSERT INTO Invoice (CustomerId, EmployeeId, InvoiceDate, TotalAmount, OrderType, ShippingAddress) VALUES (@CustomerId, @EmployeeId, @InvoiceDate, @TotalAmount, @Ordertype, 'null')";
            SqlParameter[] insertParams = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@EmployeeId", employeeId),
                new SqlParameter("@InvoiceDate", invoiceDate),
                new SqlParameter("@TotalAmount", totalAmount),
                new SqlParameter("@OrderType", orderType),
            };
            return DBMain.ExecuteNonQuery(insertSql, insertParams) > 0;
        }

        // Updates an existing invoice after validating its existence, customer, and employee
        public static bool UpdateInvoice(int invoiceId, int customerId, int employeeId, DateTime invoiceDate, decimal totalAmount, string orderType)
        {
            // Check if invoice exists
            string checkSql = "SELECT COUNT(*) FROM Invoice WHERE InvoiceId = @InvoiceId";
            SqlParameter[] checkParams = new SqlParameter[] { new SqlParameter("@InvoiceId", invoiceId) };
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql, checkParams);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Check if customer exists
            string checkCustomerSql = "SELECT COUNT(*) FROM [User] WHERE UserId = @CustomerId AND Role = 'Customer'";
            SqlParameter[] checkCustomerParams = new SqlParameter[] { new SqlParameter("@CustomerId", customerId) };
            DataTable dtChkCustomer = DBMain.ExecuteSelectQuery(checkCustomerSql, checkCustomerParams);
            int customerExists = Convert.ToInt32(dtChkCustomer.Rows[0][0]);
            if (customerExists == 0) return false;

            // Check if employee exists
            string checkEmployeeSql = "SELECT COUNT(*) FROM [User] WHERE UserId = @EmployeeId AND Role IN ('Admin', 'Employee')";
            SqlParameter[] checkEmployeeParams = new SqlParameter[] { new SqlParameter("@EmployeeId", employeeId) };
            DataTable dtChkEmployee = DBMain.ExecuteSelectQuery(checkEmployeeSql, checkEmployeeParams);
            int employeeExists = Convert.ToInt32(dtChkEmployee.Rows[0][0]);
            if (employeeExists == 0) return false;

            // Update invoice
            string updateSql = "UPDATE Invoice SET CustomerId = @CustomerId, EmployeeId = @EmployeeId, InvoiceDate = @InvoiceDate, TotalAmount = @TotalAmount, Ordertype = @OrderType, ShippingAddress = null WHERE InvoiceId = @InvoiceId";
            SqlParameter[] updateParams = new SqlParameter[]
            {
                new SqlParameter("@InvoiceId", invoiceId),
                new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@EmployeeId", employeeId),
                new SqlParameter("@InvoiceDate", invoiceDate),
                new SqlParameter("@TotalAmount", totalAmount),
                new SqlParameter("@OrderType", orderType)
            };
            return DBMain.ExecuteNonQuery(updateSql, updateParams) > 0;
        }

        // Deletes an invoice if it exists
        public static bool DeleteInvoice(int invoiceId)
        {
            // Check if invoice exists
            string checkSql = "SELECT COUNT(*) FROM Invoice WHERE InvoiceId = @InvoiceId";
            SqlParameter[] checkParams = new SqlParameter[] { new SqlParameter("@InvoiceId", invoiceId) };
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql, checkParams);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            // Delete invoice
            string deleteSql = "DELETE FROM Invoice WHERE InvoiceId = @InvoiceId";
            SqlParameter[] deleteParams = new SqlParameter[] { new SqlParameter("@InvoiceId", invoiceId) };
            return DBMain.ExecuteNonQuery(deleteSql, deleteParams) > 0;
        }

        // Searches invoices within a date range, including customer and employee names
        public static DataTable SearchInvoices(DateTime fromDate, DateTime toDate)
        {
            string sql = "SELECT i.*, c.Username AS CustomerName, e.Username AS EmployeeName FROM Invoice i " +
                         "JOIN [User] c ON i.CustomerId = c.UserId " +
                         "JOIN [User] e ON i.EmployeeId = e.UserId " +
                         "WHERE i.InvoiceDate BETWEEN @FromDate AND @ToDate";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };
            return DBMain.ExecuteSelectQuery(sql, parameters);
        }

        // Retrieves monthly revenue for a given year, including total, laptop, and component revenue
        public static DataTable GetMonthlyRevenue(int year)
        {
            string sql = @"
                SELECT 
                    MONTH(i.InvoiceDate) AS Month,
                    ISNULL(SUM(i.TotalAmount), 0) AS Revenue,
                    ISNULL(SUM(CASE WHEN p.Name LIKE 'Laptop%' THEN ii.Quantity * ii.UnitPrice ELSE 0 END), 0) AS LaptopRevenue,
                    ISNULL(SUM(CASE WHEN p.Name NOT LIKE 'Laptop%' THEN ii.Quantity * ii.UnitPrice ELSE 0 END), 0) AS ComponentRevenue
                FROM Invoice i
                LEFT JOIN InvoiceItem ii ON i.InvoiceId = ii.InvoiceId
                LEFT JOIN Product p ON ii.ProductId = p.ProductId
                WHERE YEAR(i.InvoiceDate) = @Year
                GROUP BY MONTH(i.InvoiceDate)
                ORDER BY Month";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Year", year)
            };
            DataTable dt = DBMain.ExecuteSelectQuery(sql, parameters);
            dt.TableName = "MonthlyRevenue";
            return dt;
        }
        public static DataRow GetInvoiceById(int invoiceId)
        {
            string sql = "SELECT i.*, c.Username AS CustomerName FROM Invoice i JOIN [User] c ON i.CustomerId = c.UserId WHERE i.InvoiceId = @InvoiceId";
            var dt = DBMain.ExecuteSelectQuery(sql, new[] { new SqlParameter("@InvoiceId", invoiceId) });
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable GetInvoiceItems(int invoiceId)
        {
            string sql = "SELECT ii.*, p.Name AS ProductName FROM InvoiceItem ii JOIN Product p ON ii.ProductId = p.ProductId WHERE ii.InvoiceId = @InvoiceId";
            return DBMain.ExecuteSelectQuery(sql, new[] { new SqlParameter("@InvoiceId", invoiceId) });
        }

    }
}