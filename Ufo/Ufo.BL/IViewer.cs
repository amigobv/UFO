using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.BL
{
    public interface IViewer
    {
        #region Artist
        IList<Artist> GetAllArtists();
        IList<Artist> GetAllArtistsByCountry(string country);
        IList<Artist> GetAllArtistsByCategory(Category category);
        #endregion

        #region Category
        IList<Category> GetAllCategories();
        #endregion


        #region Venue
        IList<Venue> GetAllVenues();
        IList<Venue> GetVenuesByLocation(string location);
        #endregion

        #region Performance
        IList<Performance> GetAllPerformances();
        IList<Performance> GetPerformanceByDay(DateTime day);
        IList<Performance> GetPerformanceByArtist(Artist artist);
        IList<Performance> GetPerformanceByVenue(Venue venue);
        #endregion

        void SendEmail(string address, string subject, string content);
    }
}
