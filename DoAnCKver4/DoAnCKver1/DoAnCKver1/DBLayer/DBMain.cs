using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCKver1.DBLayer
{
    internal class DBMain
    {
        private static string connStr = @"Data Source=localhost;Initial Catalog=SimpleSalesApp;Integrated Security=True";



        // Phương thức thực hiện truy vấn SELECT với tham số SQL query
        public static DataTable ExecuteSelectQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (parameters != null)
                {
                    da.SelectCommand.Parameters.AddRange(parameters);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Phương thức thực hiện truy vấn INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                return cmd.ExecuteNonQuery();  // Trả về số dòng bị ảnh hưởng
            }
        }
    }
}