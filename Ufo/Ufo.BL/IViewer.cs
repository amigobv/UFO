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
        Artist GetArtistById(int id);
        IList<Artist> GetAllArtistsByCountry(string country);
        IList<Artist> GetAllArtistsByCategory(Category category);
        /*
        byte[] GetPictureByArtistId(int id);
        byte[] GetVideoByArtistsId(int id);
        */
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
        IList<Performance> GetPerformanceByVenueAndDate(Venue venue, DateTime date);
        Performance GetPerformanceById(int id);
        bool IsPerformanceValid(Performance performance);
        bool UpdatePerformance(Performance performance);
        #endregion

        void SendEmail(string address, string subject, string content);
        string HashPassword(string input);
        bool Login(string username, string password);
    }
}
