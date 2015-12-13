using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.DAL.Common
{
    public interface IRestrictionDao
    {
        int Count();

        IList<Restriction> FindAll();

        Restriction FindById(int id);

        bool Insert(Restriction o);

        bool Update(Restriction o);

        bool Delete(int id);
    }
}
