using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.DAL.Common
{
    public interface IVenueDao
    {
        int Count();

        IList<Venue> FindAll();

        Venue FindById(int venueId, string locationId);

        IList<Venue> FindByLocationId(string locationId);

        IList<Venue> FindByLocation(string location);

        IList<Venue> FindWhereSpectators(int spectators);

        bool Insert(Venue o);

        bool Update(Venue o);

        bool Delete(int idVenue, string idLocation);
    }
}
