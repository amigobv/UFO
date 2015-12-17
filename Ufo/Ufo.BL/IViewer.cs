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
        ObservableCollection<Artist> GetAllArtists();
        ObservableCollection<Artist> GetAllArtistsByCountry(string country);
        ObservableCollection<Artist> GetAllArtistsByCategory(Category category);
        #endregion

        #region Category
        ObservableCollection<Category> GetAllCategories();
        #endregion


        #region Venue
        ObservableCollection<Venue> GetAllVenues();
        ObservableCollection<Venue> GetVenuesByLocation(string location);
        #endregion

        #region Performance
        ObservableCollection<Performance> GetAllPerformances();
        ObservableCollection<Performance> GetPerformanceByDay(DateTime day);
        ObservableCollection<Performance> GetPerformanceByArtist(Artist artist);
        ObservableCollection<Performance> GetPerformanceByVenue(Venue venue);
        #endregion

        void SendEmail(string address, string subject, string content);
    }
}
