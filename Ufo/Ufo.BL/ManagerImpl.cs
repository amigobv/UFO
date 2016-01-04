using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Exceptions;
using Ufo.BL.Interfaces;
using Ufo.DAL.Common;
using Ufo.Domain;

namespace Ufo.BL
{
    public class ManagerImpl : IManager
    {

        #region private members
        private IDatabase database;

        private IUserDao userDao;
        private IArtistDao artistDao;
        private ICategoryDao categoryDao;
        private ILocationDao locationDao;
        private IVenueDao venueDao;
        private IPerformanceDao performanceDao;
        private User currentUser;
        #endregion

        #region Ctor
        public ManagerImpl()
        {
            database = DalFactory.CreateDatabase();
            userDao = DalFactory.CreateUserDao(database);
            artistDao = DalFactory.CreateArtistDao(database);
            categoryDao = DalFactory.CreateCategoryDao(database);
            locationDao = DalFactory.CreateLocationDao(database);
            venueDao = DalFactory.CreateVenueDao(database);
            performanceDao = DalFactory.CreatePerformanceDao(database);
        }
        #endregion


        #region User

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string HashPassword(string input)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(hash);

            }

        }
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
        public IList<User> GetAllUsers()
        {
            return userDao.FindAll(); 
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

            currentUser = user;
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


        public User GetActiveUser()
        {
            return currentUser;
        }
        #endregion


        #region Artist
        public void CreateArtist(Artist artist)
        {
            if (!artistDao.Insert(artist))
                    throw new ArgumentException("No valid artist");
        }

        public IList<Artist> GetArtistByName(string name)
        {
            return artistDao.FindByName(name);
        }

        public IList<Artist> GetAllArtists()
        {
            return artistDao.FindAll();
        }

        public IList<Artist> GetAllArtistsByCountry(string country)
        {
            if (country == null)
                throw new ArgumentNullException("Invalid Country provided");

            return artistDao.FindByCountry(country);
        }

        public IList<Artist> GetAllArtistsByCategory(Category category)
        {
            if (category == null ||
                category.Id == null)
                throw new ArgumentNullException("Invalid Country provided");

            return artistDao.FindByCategoryId(category.Id);
        }

        public void RemoveArtist(Artist artist)
        {
            if (artist == null)
                throw new ArgumentException("Invalid Artist!");

            artistDao.Delete(artist.Id);
        }

        public void UpdateArtist(Artist artist)
        {
            if (artist == null)
                throw new ArgumentNullException("Invalid artist!");

            if (artistDao.FindById(artist.Id) != null)
            {
                if (!artistDao.Update(artist))
                    throw new ArgumentException("Cannot update artist");
            }
            else
            {
                CreateArtist(artist);
            }
        }
        #endregion

        #region category

        public bool CategoryExists(Category category)
        {
            if (category == null)
                return false;

            return categoryDao.FindById(category.Id) != null;
        }

        public void CreateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Invalid category!");

            if (!categoryDao.Insert(category))
                throw new CategoryException("Cannot insert category!");
        }

        public IList<Category> GetAllCategories()
        {
            return categoryDao.FindAll();
        }

        public void RemoveCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Invalid category!");

            if (!categoryDao.Delete(category.Id))
                throw new CategoryException("Cannot remove category!");
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Invalid category");

            if (categoryDao.FindById(category.Id) != null)
            {
                if (!categoryDao.Update(category))
                    throw new CategoryException("Cannot update category!");
            }
            else
            {
                CreateCategory(category);
            }
        }
        #endregion

        #region location
        public bool LocationExists(Location location)
        {
            if (location == null)
                throw new ArgumentNullException("Invalid location!");

            return locationDao.FindById(location.Id) != null;
        }

        public void CreateLocation(Location location)
        {
            if (!locationDao.Insert(location))
                throw new LocationException("Cannot create location");
        }

        public IList<Location> GetAllLocations()
        {
            return locationDao.FindAll();
        }

        public void RemoveLocation(Location location)
        {
            if (location == null)
                throw new ArgumentNullException("Invalid location!");

            if (!locationDao.Delete(location.Id))
                throw new LocationException("Cannot remove location");
        }

        public void UpdateLocation(Location location)
        {
            if (location == null)
                throw new ArgumentNullException("Invalid location!");

            if (locationDao.FindById(location.Id) != null)
            {
                if (!locationDao.Update(location))
                    throw new LocationException("Cannot update location");
            }
            else
            {
                CreateLocation(location);
            }
        }
        #endregion

        #region venue
        public void CreateVenue(Venue venue)
        {
            if (venue == null)
                throw new ArgumentNullException("Invalid Venue!");

            if (!venueDao.Insert(venue))
                throw new VenueException("Cannot insert venue!");
        }

        public Venue GetVenueById(string id)
        {
            var venueId = (int)Char.GetNumericValue(id[1]);
            var locationId = id[0].ToString();

            return venueDao.FindById(venueId, locationId);
        }

        public IList<Venue> GetAllVenues()
        {
            return venueDao.FindAll();
        }

        public IList<Venue> GetVenuesBySpectators(int numberOfSpectators)
        {
            return venueDao.FindWhereSpectators(numberOfSpectators);
        }

        public IList<Venue> GetVenuesByLocation(string location)
        {
            return venueDao.FindByLocationId(location);
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

            if (venueDao.FindById(venue.Id, venue.Location.Id) != null)
            {
                if (!venueDao.Update(venue))
                    throw new VenueException("Cannot update venue!");
            }
            else
            {
                CreateVenue(venue);
            }
        }
        #endregion

        #region performance
        public void CreatePerformance(Performance performance)
        {
            if (performance == null)
                throw new ArgumentNullException("Invalid performance!");

            if (!performanceDao.Insert(performance))
                throw new PerformanceException("Cannot create performance!");
        }

        public IList<Performance> GetAllPerformances()
        {
            return performanceDao.FindAll();
        }

        public IList<Performance> GetPerformanceByDay(DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime end = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);

            return performanceDao.FindBetween(start, end);
        }

        public IList<Performance> GetPerformanceByArtist(Artist artist)
        {
            return performanceDao.FindByArtistId(artist.Id);
        }

        public IList<Performance> GetPerformanceByVenue(Venue venue)
        {
            return performanceDao.FindByVenue(venue.Label);
        }

        public void RemovePerformance(Performance performance)
        {
            if (!performanceDao.Delete(performance.Id))
                throw new PerformanceException("Cannot remove performance!");
        }

        public void UpdatePerformance(Performance performance)
        {
            if (performance == null)
                throw new ArgumentNullException("Invalid performance!");

            if (performanceDao.FindById(performance.Id) != null)
            {
                if (!performanceDao.Update(performance))
                    throw new VenueException("Cannot update performance!");
            }
            else
            {
                CreatePerformance(performance);
            }
        }

        public bool IsPerformanceValid(Performance p)
        {
            if (p == null ||
                p.Artist == null ||
                p.Venue == null)
                return false;

            DateTime start = new DateTime(p.Start.Year, 
                                          p.Start.Month, 
                                          p.Start.Day, 0, 0, 0);

            DateTime end = new DateTime(p.Start.Year, 
                                        p.Start.Month, 
                                        p.Start.Day, 23, 59, 59);

            var listPerformances = performanceDao.FindBetween(start, end);

            foreach(var performance in listPerformances)
            {
                if (p.Artist.Equals(performance.Artist))
                {
                    DateTime next = p.Start.AddHours(1);
                    DateTime prev = p.Start.AddHours(-1);
                    if (p.Start.Equals(performance.Start) || 
                        next.Equals(performance.Start) ||
                        prev.Equals(performance.Start))
                        return false;
                }
            }

            return true;
        }
        #endregion

        public void SendEmail(string address, string subject, string content)
        {
            SmtpClient client = new SmtpClient();

            MailMessage mail = new MailMessage("s1310307036@students.fh-hagenberg.com", address)
            {
                Subject = subject,
                Body = content,
                BodyEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.UTF8
            };

            client.Send(mail);
        }

        public void NotifiyAllArtists()
        {
            var artists = artistDao.FindAll();

            foreach(var artist in artists)
            {
                NotifyArtist(artist);
            }
        }

        public void NotifyArtist(Artist artist)
        {
            var performances = performanceDao.FindByArtistId(artist.Id);

            var sb = new StringBuilder();

            sb.AppendLine("Here is your festival schedule: ");
            foreach(var p in performances)
            {
                sb.AppendLine(p.Start.ToString("yyyy.MM.dd HH:mm") + " - " + 
                             p.Venue.Location.Id + p.Venue.Id + " " +
                             p.Venue.Label);
            }

            SendEmail(artist.Email, "Personal festival schedule", sb.ToString());
        }
    }
}
