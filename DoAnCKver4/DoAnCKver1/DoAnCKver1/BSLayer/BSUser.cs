using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCKver1.DBLayer;
using DoAnCKver1.Model;
using System.Data.SqlClient;

namespace DoAnCKver1.BSLayer
{
    internal class BSUser
    {
        // Authenticates a user by checking username, password, and active status
        public static User Login(string username, string password)
        {
            string sql = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password AND Status = 'Active'";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            DataTable dt = DBMain.ExecuteSelectQuery(sql, parameters);
            if (dt.Rows.Count == 0)
                return null;

            DataRow r = dt.Rows[0];
            return new User
            {
                UserId = Convert.ToInt32(r["UserId"]),
                Username = r["Username"].ToString(),
                Email = r["Email"].ToString(),
                Role = r["Role"].ToString(),
                Status = r["Status"].ToString(),
                CreatedAt = Convert.ToDateTime(r["CreatedAt"])
            };
        }

        // Registers a new customer, ensuring username and email are unique
        public static bool Register(string username, string email, string password)
        {
            string checkSql = "SELECT COUNT(*) FROM [User] WHERE Username = @Username OR Email = @Email";
            SqlParameter[] checkParams = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email)
            };
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql, checkParams);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists > 0) return false;

            string insertSql = "INSERT INTO [User] (Username, Email, Password, Role, Status, CreatedAt) " +
                               "VALUES (@Username, @Email, @Password, 'Customer', 'Active', GETDATE())";
            SqlParameter[] insertParams = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password)
            };
            return DBMain.ExecuteNonQuery(insertSql, insertParams) > 0;
        }
        public static bool AddUser(string username, string email, string password, string role, string status)
        {
            string checkSql = "SELECT COUNT(*) FROM [User] WHERE Username = @Username OR Email = @Email";
            SqlParameter[] checkParams = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email)
            };
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql, checkParams);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists > 0) return false;

            string insertSql = "INSERT INTO [User] (Username, Email, Password, Role, Status, CreatedAt) " +
                               "VALUES (@Username, @Email, @Password, @Role, @Status, GETDATE())";
            SqlParameter[] insertParams = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@Role", role),
                new SqlParameter("@Status", status)
            };
            return DBMain.ExecuteNonQuery(insertSql, insertParams) > 0;
        }

        // Sends a password reset code to the user's email
        public static string SendResetCode(string email)
        {
            string chkSql = "SELECT COUNT(*) FROM [User] WHERE Email = @Email";
            SqlParameter[] chkParams = new SqlParameter[] { new SqlParameter("@Email", email) };
            DataTable dt = DBMain.ExecuteSelectQuery(chkSql, chkParams);
            if (Convert.ToInt32(dt.Rows[0][0]) == 0) return null;

            string token = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            DateTime expiry = DateTime.Now.AddMinutes(10);

            string updSql = "UPDATE [User] SET ResetToken = @Token, ResetTokenExpiry = @Expiry WHERE Email = @Email";
            SqlParameter[] updParams = new SqlParameter[]
            {
                new SqlParameter("@Token", token),
                new SqlParameter("@Expiry", expiry),
                new SqlParameter("@Email", email)
            };
            DBMain.ExecuteNonQuery(updSql, updParams);
            try
            {
                string subject = "Mã xác thực đặt lại mật khẩu";
                string body = $"Xin chào,\n\nMã xác thực của bạn là: {token}\nMã sẽ hết hạn sau 10 phút.\n\nNếu bạn không yêu cầu đặt lại mật khẩu, hãy bỏ qua email này.";

                var fromAddress = new MailAddress("taitannguyen888@yahoo.com", "Hệ thống hỗ trợ");
                var toAddress = new MailAddress(email);
                const string fromPassword = "qwybbgqfhvynflzb";

                var smtp = new SmtpClient
                {
                    Host = "smtp.mail.yahoo.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    EnableSsl = true
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                return token;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Resets the user's password if the provided token is valid and not expired
        public static bool ResetPassword(string email, string token, string newPassword)
        {
            string selSql = "SELECT ResetTokenExpiry FROM [User] WHERE Email = @Email AND ResetToken = @Token";
            SqlParameter[] selParams = new SqlParameter[]
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Token", token)
            };
            DataTable dt = DBMain.ExecuteSelectQuery(selSql, selParams);
            if (dt.Rows.Count == 0) return false;

            DateTime expiry = Convert.ToDateTime(dt.Rows[0]["ResetTokenExpiry"]);
            if (expiry < DateTime.Now) return false;

            string updSql = "UPDATE [User] SET Password = @NewPassword, ResetToken = NULL, ResetTokenExpiry = NULL WHERE Email = @Email";
            SqlParameter[] updParams = new SqlParameter[]
            {
                new SqlParameter("@NewPassword", newPassword),
                new SqlParameter("@Email", email)
            };
            return DBMain.ExecuteNonQuery(updSql, updParams) > 0;
        }

        // Retrieves a list of all users
        public static DataTable GetUsers()
        {
            string query = "SELECT UserId, Username, Password, Email, Role, Status, CreatedAt FROM [User]";
            DataTable dt = DBMain.ExecuteSelectQuery(query);
            dt.TableName = "User";
            return dt;
        }
        public static DataTable GetAllCustomer()
        {
            string query = "SELECT UserId, Username, Password, Email, Role, Status, CreatedAt FROM [User] WHERE Role='Customer'";
            DataTable dt = DBMain.ExecuteSelectQuery(query);
            dt.TableName = "User";
            return dt;
        }

        // Updates user information, ensuring no duplicate username or email
        public static bool UpdateUser(int userId, string username, string email, string password, string role, string status)
        {
            string checkSql = "SELECT COUNT(*) FROM [User] WHERE UserId = @UserId";
            SqlParameter[] checkParams = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql, checkParams);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            string checkDuplicateSql = "SELECT COUNT(*) FROM [User] WHERE (Username = @Username OR Email = @Email) AND UserId != @UserId";
            SqlParameter[] checkDuplicateParams = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email),
                new SqlParameter("@UserId", userId)
            };
            DataTable dtChkDuplicate = DBMain.ExecuteSelectQuery(checkDuplicateSql, checkDuplicateParams);
            int duplicateExists = Convert.ToInt32(dtChkDuplicate.Rows[0][0]);
            if (duplicateExists > 0) return false;

            string updateSql = "UPDATE [User] SET Username = @Username, Email = @Email, Password = @Password, Role = @Role, Status = @Status WHERE UserId = @UserId";
            SqlParameter[] updateParams = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@Role", role),
                new SqlParameter("@Status", status)
            };
            return DBMain.ExecuteNonQuery(updateSql, updateParams) > 0;
        }

        // Deletes a user by their ID
        public static bool DeleteUser(int userId)
        {
            string checkSql = "SELECT COUNT(*) FROM [User] WHERE UserId = @UserId";
            SqlParameter[] checkParams = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            DataTable dtChk = DBMain.ExecuteSelectQuery(checkSql, checkParams);
            int exists = Convert.ToInt32(dtChk.Rows[0][0]);
            if (exists == 0) return false;

            string deleteSql = "DELETE FROM [User] WHERE UserId = @UserId";
            SqlParameter[] deleteParams = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            return DBMain.ExecuteNonQuery(deleteSql, deleteParams) > 0;
        }

        // Retrieves detailed information for a customer, including laptop count, warranty count, and total spent
        public static DataTable GetCustomerDetails(int userId)
        {
            string sql = @"
                SELECT 
                    u.UserId, u.Username, u.Email, u.Password, u.Role, u.Status,
                    ISNULL((
                        SELECT SUM(ii.Quantity)
                        FROM Invoice i
                        JOIN InvoiceItem ii ON i.InvoiceId = ii.InvoiceId
                        JOIN Product p ON ii.ProductId = p.ProductId
                        WHERE i.CustomerId = u.UserId AND p.Name LIKE 'Laptop%'
                    ), 0) AS LaptopCount,
                    ISNULL((
                        SELECT COUNT(*)
                        FROM WarrantyVoucher w
                        JOIN Invoice i ON w.InvoiceId = i.InvoiceId
                        WHERE i.CustomerId = u.UserId
                    ), 0) AS WarrantyCount,
                    ISNULL((
                        SELECT SUM(i.TotalAmount)
                        FROM Invoice i
                        WHERE i.CustomerId = u.UserId
                    ), 0) AS TotalSpent
                FROM [User] u
                WHERE u.UserId = @UserId AND u.Role = 'Customer'";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            return DBMain.ExecuteSelectQuery(sql, parameters);
        }

        // Calculates the total revenue from all invoices
        public static decimal GetTotalRevenue()
        {
            string sql = "SELECT ISNULL(SUM(TotalAmount), 0) AS TotalRevenue FROM Invoice";
            DataTable dt = DBMain.ExecuteSelectQuery(sql);
            return Convert.ToDecimal(dt.Rows[0]["TotalRevenue"]);
        }

        // Calculates the total number of laptops sold
        public static int GetTotalLaptopsSold()
        {
            string sql = @"
                SELECT ISNULL(SUM(ii.Quantity), 0) AS TotalLaptops
                FROM Invoice i
                JOIN InvoiceItem ii ON i.InvoiceId = ii.InvoiceId
                JOIN Product p ON ii.ProductId = p.ProductId
                WHERE p.Name LIKE 'Laptop%'";
            DataTable dt = DBMain.ExecuteSelectQuery(sql);
            return Convert.ToInt32(dt.Rows[0]["TotalLaptops"]);
        }

        // Calculates the total number of components (non-laptop products) sold
        public static int GetTotalComponentsSold()
        {
            string sql = @"
                SELECT ISNULL(SUM(ii.Quantity), 0) AS TotalComponents
                FROM Invoice i
                JOIN InvoiceItem ii ON i.InvoiceId = ii.InvoiceId
                JOIN Product p ON ii.ProductId = p.ProductId
                WHERE p.Name NOT LIKE 'Laptop%'";
            DataTable dt = DBMain.ExecuteSelectQuery(sql);
            return Convert.ToInt32(dt.Rows[0]["TotalComponents"]);
        }

        // Calculates the total revenue from laptop sales
        public static decimal GetLaptopRevenue()
        {
            string sql = @"
                SELECT ISNULL(SUM(ii.Quantity * ii.UnitPrice), 0) AS LaptopRevenue
                FROM Invoice i
                JOIN InvoiceItem ii ON i.InvoiceId = ii.InvoiceId
                JOIN Product p ON ii.ProductId = p.ProductId
                WHERE p.Name LIKE 'Laptop%'";
            DataTable dt = DBMain.ExecuteSelectQuery(sql);
            return Convert.ToDecimal(dt.Rows[0]["LaptopRevenue"]);
        }

        // Calculates the total revenue from component (non-laptop) sales
        public static decimal GetComponentRevenue()
        {
            string sql = @"
                SELECT ISNULL(SUM(ii.Quantity * ii.UnitPrice), 0) AS ComponentRevenue
                FROM Invoice i
                JOIN InvoiceItem ii ON i.InvoiceId = ii.InvoiceId
                JOIN Product p ON ii.ProductId = p.ProductId
                WHERE p.Name NOT LIKE 'Laptop%'";
            DataTable dt = DBMain.ExecuteSelectQuery(sql);
            return Convert.ToDecimal(dt.Rows[0]["ComponentRevenue"]);
        }
    }
}