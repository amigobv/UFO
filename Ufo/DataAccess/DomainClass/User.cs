using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DomainClass
{
    class User : IDomain
    {
        #region properties
        public int Id { get; set; }
        public string Username { get; set; }
        public long Password { get; set; }
        public string Email { get; set; }
        #endregion

        public User(int id, string username, long password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public override string ToString()
        {
            return "User: " + Username + " " + Email;
        }
    }
}
