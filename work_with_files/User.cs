using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_files
{
    internal class User
    {

        public User()
        {


        }

        public User(string name)
        {
            Name = name;


        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
