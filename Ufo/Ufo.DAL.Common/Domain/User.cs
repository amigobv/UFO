﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Domain
{
    public class User
    {
        #region properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        #endregion

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as User;

            if (o != null)
            {
                return Username.Equals(o.Username) && Password.Equals(o.Password);
            }

            return false;
        }

        public override string ToString()
        {
            return "User: " + Username + " " + Email;
        }
    }
}
