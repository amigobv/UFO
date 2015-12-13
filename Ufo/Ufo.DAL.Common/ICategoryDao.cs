using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.DAL.Common
{
    public interface ICategoryDao
    {
        int Count();

        IList<Category> FindAll();

        Category FindById(string id);

        bool Insert(Category o);

        bool Update(Category o);

        bool Delete(string id);
    }
}
