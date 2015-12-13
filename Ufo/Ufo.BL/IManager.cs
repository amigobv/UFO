using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;

namespace Ufo.BL.Interfaces
{
    public interface IManager
    {
        #region User
        string HashPassword(string input);
        bool Exist(string username);
        void Login(User user);
        void Registrate(User user);
        ObservableCollection<User> GetAllUsers();
        void RemoveUser(User user);
        void UpdateUser(User user);
        User GetActiveUser();
        #endregion

        #region Artist
        void CreateArtist(Artist artist);
        ObservableCollection<Artist> GetAllArtists();
        ObservableCollection<Artist> GetAllArtistsByCountry(string country);
        ObservableCollection<Artist> GetAllArtistsByCategory(Category category);
        void RemoveArtist(Artist artist);
        void UpdateArtist(Artist artist);
        #endregion

        #region Category
        bool CategoryExists(Category category);
        void CreateCategory(Category category);
        ObservableCollection<Category> GetAllCategories();
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        #endregion

        #region Location
        bool LocationExists(Location location);
        void CreateLocation(Location location);
        ObservableCollection<Location> GetAllLocations();
        void RemoveLocation(Location location);
        void UpdateLocation(Location location);
        #endregion

        #region Venue
        void CreateVenue(Venue venue);
        ObservableCollection<Venue> GetAllVenues();
        ObservableCollection<Venue> GetVenuesBySpectators(int numberOfSpectators);
        ObservableCollection<Venue> GetVenuesByLocation(string location);
        void RemoveVenue(Venue venue);
        void UpdateVenue(Venue venue);
        #endregion

        #region Performance
        void CreatePerformance(Performance performance);
        ObservableCollection<Performance> GetAllPerformances();
        ObservableCollection<Performance> GetPerformanceByDay(DateTime day);
        ObservableCollection<Performance> GetPerformanceByArtist(Artist artist);
        ObservableCollection<Performance> GetPerformanceByVenue(Venue venue);
        void RemovePerformance(Performance performance);
        void UpdatePerformance(Performance performance);
        #endregion
    }
}
