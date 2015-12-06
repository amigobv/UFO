using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.Model
{
    public class UserModel
    {
        private User user;

        public UserModel()
        {
            user = new User(string.Empty, string.Empty, string.Empty);
        }

        public User GetInstance()
        {
            return user;
        }

        public string Username
        {
            get { return user.Username; }
            set { user.Username = value; }
        }


        public string Password
        {
            get { return user.Password; }
            set { user.Password = value; }
        }


        public string Email
        {
            get { return user.Email; }
            set { user.Email = value; }
        }


    }
}
