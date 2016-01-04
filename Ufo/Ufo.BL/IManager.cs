using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.BL.Interfaces
{
    public interface IManager
    {
        #region User
        string HashPassword(string input);
        bool Exist(string username);
        void Login(User user);
        void Registrate(User user);
        IList<User> GetAllUsers();
        void RemoveUser(User user);
        void UpdateUser(User user);
        User GetActiveUser();
        #endregion

        #region Artist
        void CreateArtist(Artist artist);
        IList<Artist> GetArtistByName(string name);
        IList<Artist> GetAllArtists();
        IList<Artist> GetAllArtistsByCountry(string country);
        IList<Artist> GetAllArtistsByCategory(Category category);
        void RemoveArtist(Artist artist);
        void UpdateArtist(Artist artist);
        #endregion

        #region Category
        bool CategoryExists(Category category);
        void CreateCategory(Category category);
        IList<Category> GetAllCategories();
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        #endregion

        #region Location
        bool LocationExists(Location location);
        void CreateLocation(Location location);
        IList<Location> GetAllLocations();
        void RemoveLocation(Location location);
        void UpdateLocation(Location location);
        #endregion

        #region Venue
        void CreateVenue(Venue venue);
        Venue GetVenueById(string id);
        IList<Venue> GetAllVenues();
        IList<Venue> GetVenuesBySpectators(int numberOfSpectators);
        IList<Venue> GetVenuesByLocation(string location);
        void RemoveVenue(Venue venue);
        void UpdateVenue(Venue venue);
        #endregion

        #region Performance
        void CreatePerformance(Performance performance);
        IList<Performance> GetAllPerformances();
        IList<Performance> GetPerformanceByDay(DateTime day);
        IList<Performance> GetPerformanceByArtist(Artist artist);
        IList<Performance> GetPerformanceByVenue(Venue venue);
        void RemovePerformance(Performance performance);
        void UpdatePerformance(Performance performance);
        bool IsPerformanceValid(Performance performance);
        #endregion

        void SendEmail(string address, string subject, string content);
        void NotifiyAllArtists();
    }
}
