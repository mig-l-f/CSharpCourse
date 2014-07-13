using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager
{
    class User
    {
        public String Username { get; set; }
        public Byte[] Password { get; set; }
        public String Realname { get; set; }

        public User(String Username, Byte[] Password, String Realname = "")
        {
            this.Username = Username;
            this.Password = Password;
            this.Realname = Realname;
        }
    }
}
