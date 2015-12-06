using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Exceptions;
using Ufo.BL.Interfaces;
using Ufo.DAL.Common.Domain;
using Ufo.DAL.SqlServer.Dao;
using Ufo.DAL.SqlServer.Factories;

namespace Ufo.BL
{
    public class Manager : IManager
    {

        #region private members
        private UserDao userDao;
        private ArtistDao artistDao;
        private CategoryDao categoryDao;
        private LocationDao locationDao;
        private VenueDao venueDao;
        private PerformanceDao performanceDao;
        private User currentUser;
        #endregion

        #region Ctor
        public Manager()
        {
            userDao = UserDaoFactory.GetUserDao();
            artistDao = ArtistDaoFactory.GetArtistDao();
            categoryDao = CategoryDaoFactory.GetCategoryDao();
            locationDao = LocationDaoFactory.GetLocationDao();
            venueDao = VenueDaoFactory.GetVenueDao();
            performanceDao = PerformanceDaoFactory.GetPerformanceDao();
        }
        #endregion


        #region User
        /// <summary>
        /// Check if the specified username is already registrated.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid username!</exception>
        public bool Exist(string username)
        {
            if (username == null)
                throw new ArgumentNullException("Invalid username!");

            var user = userDao.FindById(username);

            return user != null;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<User> GetAllUsers()
        {
            return new ObservableCollection<User>(userDao.FindAll()); 
        }

        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid user!</exception>
        public void Login(User user)
        {
            if (user == null)
                throw new ArgumentNullException("Invalid user!");

            if (string.IsNullOrEmpty(user.Username))
                throw new InvalidUserException("No username provided!");

            if (string.IsNullOrEmpty(user.Password))
                throw new InvalidUserException("No password provided!");


            if (!Exist(user.Username))
                throw new LoginException("User does not exist!");

            try
            {
                if (IsValid(user))
                    currentUser = user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Determines whether the specified user is valid.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="UserException">
        /// User does not exist!
        /// or
        /// Invalid username!
        /// or
        /// Invalid password!
        /// </exception>
        private bool IsValid(User user)
        {
            if (user == null)
                return false;

            var dbUser = userDao.FindById(user.Username);

            if (dbUser == null)
                throw new InvalidUserException("User does not exist!");

            if (!user.Username.Equals(dbUser.Username))
                throw new LoginException("Invalid username!");

            if (!user.Password.Equals(dbUser.Password))
                throw new LoginException("Invalid password!");

            return true;
        }

        /// <summary>
        /// Registrates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid user!</exception>
        /// <exception cref="UserException">Cannot registrate user</exception>
        public void Registrate(User user)
        {
            if (user == null)
                throw new ArgumentNullException("Invalid user!");

            if (string.IsNullOrEmpty(user.Username))
                throw new InvalidUserException("No username provided!");

            if (string.IsNullOrEmpty(user.Password))
                throw new InvalidUserException("No password provided!");

            if (string.IsNullOrEmpty(user.Email))
                throw new InvalidUserException("No email provided");

            if (Exist(user.Username))
                throw new RegistrationException("User already exists!");

            try
            {
                CreateUser(user);
            }
            catch (Exception)
            {
                // TODO: user logger
                throw;
            }

            currentUser = user; throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.ArgumentNullException">Invalid user argument</exception>
        /// <exception cref="DataAccessException">Cannot create user!</exception>
        private void CreateUser(User user)
        {
            if (!userDao.Insert(user))
                throw new ArgumentException("Invalid user user!");
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.ArgumentNullException">Invalid user!</exception>
        /// <exception cref="DataAccessException">Cannot remove user!</exception>
        public void RemoveUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("Invalid user!");

            if (!userDao.Delete(user.Username))
                throw new DataAccessException("Cannot remove user!");
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="DataAccessException">Cannot update user!</exception>
        public void UpdateUser(User user)
        {
            if (!userDao.Update(user))
                throw new DataAccessException("Cannot update user!");
        }

        #endregion


        #region Artist
        public void CreateArtist(Artist artist)
        {
            if (!artistDao.Insert(artist))
                    throw new ArgumentException("No valid artist");
        }

        public ObservableCollection<Artist> GetAllArtists()
        {
            return new ObservableCollection<Artist>(artistDao.FindAll());
        }

        public ObservableCollection<Artist> GetAllArtistsByCountry(string country)
        {
            if (country == null)
                throw new ArgumentNullException("Invalid Country provided");

            return new ObservableCollection<Artist>(artistDao.FindByCountry(country));
        }

        public ObservableCollection<Artist> GetAllArtistsByCountry(Category category)
        {
            if (category == null ||
                category.Id == null)
                throw new ArgumentNullException("Invalid Country provided");

            return new ObservableCollection<Artist>(artistDao.FindByCategoryId(category.Id));
        }

        public void RemoveArtist(Artist artist)
        {
            if (artist == null)
                throw new ArgumentException("Invalid Artist!");

            artistDao.Delete(artist.Id);
        }

        public void UpdateArtist(Artist artist)
        {
            if (!artistDao.Update(artist))
                throw new ArgumentException("Cannot update artist");
        }
        #endregion

        #region category
        public void CreateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Invalid category!");

            if (categoryDao.Insert(category))
                throw new CategoryException("Cannot insert category!");
        }

        public ObservableCollection<Category> GetAllCategories()
        {
            return new ObservableCollection<Category>(categoryDao.FindAll());
        }

        public void RemoveCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Invalid category!");

            if (categoryDao.Delete(category.Id))
                throw new CategoryException("Cannot remove category!");
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Invalid category");

            if (categoryDao.Update(category))
                throw new CategoryException("Cannot update category!");
        }
        #endregion

        #region location
        //private void CreateLocation(Location category)
        //{
        //    throw new NotImplementedException();
        //}

        //public ObservableCollection<Location> GetAllLocations()
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveLocation(Location category)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateLocation(Location category)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region venue
        public void CreateVenue(Venue venue)
        {
            if (venue == null)
                throw new ArgumentNullException("Invalid Venue!");

            if (locationDao.FindById(venue.Location.Id) == null)
            {
                if (!locationDao.Insert(venue.Location))
                    throw new LocationException("Cannot create location");
            }

            if (!venueDao.Insert(venue))
                throw new VenueException("Cannot insert venue!");
        }

        public ObservableCollection<Venue> GetAllVenues()
        {
            return new ObservableCollection<Venue>(venueDao.FindAll());
        }

        public ObservableCollection<Venue> GetVenuesBySpectators(int numberOfSpectators)
        {
            return new ObservableCollection<Venue>(venueDao.FindWhereSpectators(numberOfSpectators));
        }

        public ObservableCollection<Venue> GetVenuesByLocation(string location)
        {
            return new ObservableCollection<Venue>(venueDao.FindByLocationId(location));
        }

        public void RemoveVenue(Venue venue)
        {
            if (venue == null)
                throw new ArgumentNullException("Invalid venue!");

            if (!venueDao.Delete(venue.Id, venue.Location.Id))
                throw new VenueException("Cannot delete venue!");
        }

        public void UpdateVenue(Venue venue)
        {
            if (venue == null)
                throw new ArgumentNullException("Invalid venue!");

            var loc = locationDao.FindById(venue.Location.Id);
            if (loc == null)
            {
                if (!locationDao.Insert(venue.Location))
                    throw new LocationException("Cannot create location");
            }
                
            if (!loc.Equals(venue.Location))
            {
                if (!locationDao.Update(venue.Location))
                    throw new LocationException("Cannot update location!");
            }

            if (!venueDao.Update(venue))
                throw new VenueException("Cannot update venue!");
        }
        #endregion

        #region performance
        public void CreatePerformance(Performance performance)
        {
            if (performance == null)
                throw new ArgumentNullException("Invalid performance!");


            //TODO: check artist performance
            if (!performanceDao.Insert(performance))
                throw new PerformanceException("Cannot create performance!");
        }

        public ObservableCollection<Performance> GetAllPerformances()
        {
            return new ObservableCollection<Performance>(performanceDao.FindAll());
        }

        public ObservableCollection<Performance> GetPerformanceByDay(DateTime day)
        {
            return new ObservableCollection<Performance>(performanceDao.FindByDay(day));
        }

        public ObservableCollection<Performance> GetPerformanceByArtist(Artist artist)
        {
            return new ObservableCollection<Performance>(performanceDao.FindByArtistId(artist.Id));
        }

        public ObservableCollection<Performance> GetPerformanceByVenue(Venue venue)
        {
            return new ObservableCollection<Performance>(performanceDao.FindByVenue(venue.Label));
        }

        public void RemovePerformance(Performance performance)
        {
            if (!performanceDao.Delete(performance.Id))
                throw new PerformanceException("Cannot remove performance!");
        }

        public void UpdatePerformance(Performance performance)
        {
            if (!performanceDao.Update(performance))
                throw new PerformanceException("Cannot update performance!");
        }
        #endregion

    }
}
