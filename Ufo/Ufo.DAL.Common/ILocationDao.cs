using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.DAL.Common
{
    public interface ILocationDao
    {
        int Count();

        IList<Location> FindAll();

        Location FindById(string id);

        bool Insert(Location o);

        bool Update(Location o);

        bool Delete(string id);
    }
}
