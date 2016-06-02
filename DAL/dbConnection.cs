using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    class dbConnection
    {
        private static string con = "Data Source=Jason;Initial Catalog=GSMS_DB;Integrated Security=True";

        #region Update Database
        /// <summary>
        /// 更新数据库，数据库行数变更返回。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlCommand command = null;
            try
            {
                SqlConnection connection = new SqlConnection(@con);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new SqlCommand(sql, connection);
                int row = command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
                return row;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Search Database
        public static int Search(string sql)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@con);
                SqlDataAdapter sda = new SqlDataAdapter(sql, connection);
                DataTable DT = new DataTable();
                sda.Fill(DT);
                connection.Close();
                connection.Dispose();
                return DT.Rows.Count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Show table
        public static DataTable Show(string sql)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@con);
                SqlDataAdapter sda = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        
    }
}
