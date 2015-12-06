using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.SqlServer.Factories
{
    public static class CategoryDaoFactory
    {
        private static CategoryDao categoryDao;

        public static CategoryDao GetCategoryDao()
        {
            if (categoryDao == null)
                categoryDao = new CategoryDao(new Database(DbConfiguration.ConnectionString));

            return categoryDao;
        }

    }
}
