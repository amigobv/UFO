using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.DAL.Common
{
    public interface IArtistDao
    {
        int Count();

        IList<Artist> FindAll();

        Artist FindById(int id);

        IList<Artist> FindByName(string name);

        IList<Artist> FindByCountry(string country);

        IList<Artist> FindByCategory(string category);

        IList<Artist> FindByCategoryId(string categoryId);

        bool Insert(Artist o);

        bool Update(Artist o);
        
        bool Delete(int id);
    }
}
