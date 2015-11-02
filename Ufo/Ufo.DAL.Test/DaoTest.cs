using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Dao;
using Xunit;

namespace Ufo.DAL.Test
{
    public abstract class DaoTest<T, V> 
    {
        internal IList<T> items;

        internal abstract void CreateTestData();

        internal virtual void InsertDummyData(IDao<T, V> dao)
        {
            CreateTestData();

            foreach (var item in items)
            {
                dao.Insert(item);
            }
        }
    }
}
