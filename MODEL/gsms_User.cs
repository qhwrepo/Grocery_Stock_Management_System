using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class gsms_User
    {
        private string _password;
        private string _username;
        private string _useridentity;

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Useridentity
        {
            get
            {
                return _useridentity;
            }

            set
            {
                _useridentity = value;
            }
        }
    }
}
