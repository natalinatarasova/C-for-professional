using System;
using System.Collections.Generic;
using System.Text;

namespace HW_008_Serialization_1
{
    public class Users
    {
        private string login;
        private string pass;
        private string text;

        public Users(string login, string pass)
        {
            this.login = login;
            this.pass = pass;
        }
        public string Login 
        {
            get { return login; }
            set { login = value; } 
        }

        public string Password
        {
            get { return pass; }
            set { pass = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
