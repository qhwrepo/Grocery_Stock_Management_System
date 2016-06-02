using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MODEL;

namespace DAL
{
    public partial class gsms_UserServer
    {
        private string sql;
        public int add_User(gsms_User user)
        {
            sql = "INSERT INTO [Users](Username,Password,UserIdentity)VALUES('";
            sql += user.Username + "','";
            sql += user.Password + "','";
            sql += user.Useridentity + "');";
            return dbConnection.Update(sql);
        }

        public int search_User(gsms_User user)
        {
            sql = "SELECT * FROM [Users] WHERE Username='";
            sql += user.Username + "' and Password='";
            sql += user.Password + "' and UserIdentity='";
            sql += user.Useridentity + "';";
            return dbConnection.Search(sql);
        }

        public DataTable show_User()
        {
            string sql = "SELECT * FROM Users";
            return dbConnection.Show(sql);
        }

        public int delete_User(gsms_User user)
        {
            sql = "Delete from Users where Username='";
            sql += user.Username + "';";
            return dbConnection.Update(sql);
        }
    }
}
