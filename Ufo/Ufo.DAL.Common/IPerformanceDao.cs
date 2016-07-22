using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.DAL.Common
{
    public interface IPerformanceDao
    {
        int Count();

        IList<Performance> FindAll();

        Performance FindById(int id);

        IList<Performance> FindByArtistId(int idArtist);

        IList<Performance> FindByArtist(string artist);

        IList<Performance> FindByVenue(string venue);

        IList<Performance> FindBetween(DateTime start, DateTime end);

        IList<Performance> FindByVenueAndDate(string venue, DateTime start, DateTime end);

        bool Insert(Performance o);

        bool Update(Performance o);

        bool Delete(int id);

        bool DeleteByArtist(int id);
    }
}
