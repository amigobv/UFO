using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Dao
{
    public interface IDao<T,in V>
    {
        T FindById(V id);
        IList<T> FindAll();
        bool Insert(T o);
        bool Update(T o);
        bool Delete(V id);
    }
}
