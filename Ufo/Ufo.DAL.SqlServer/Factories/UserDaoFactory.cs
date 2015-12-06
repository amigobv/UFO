using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.SqlServer.Factories
{
    public static class UserDaoFactory
    {
        private static UserDao userDao;

        public static UserDao GetUserDao()
        {
            if (userDao == null)
                userDao = new UserDao(new Database(DbConfiguration.ConnectionString));

            return userDao;
        }
    }
}
