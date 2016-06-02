using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using MODEL;


namespace BLL
{
    public class gsms_UserManager
    {
        private gsms_UserServer US = new gsms_UserServer();
        public int add_User(gsms_User user)
        {
            return US.add_User(user);
        }

        public int search_User(gsms_User user)
        {
            return US.search_User(user);
        }
        
        public DataTable show_User()
        {
            return US.show_User();
        }

        public int delete_User(gsms_User user)
        {
            return US.delete_User(user);
        }
    }
}
