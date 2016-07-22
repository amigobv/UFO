using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using Ufo.BL.Exceptions;
using Ufo.DAL.Common;
using Ufo.Domain;


namespace Ufo.BL
{
    public class ViewerImpl : IViewer
    {
        #region private members
        private IDatabase database = DalFactory.CreateDatabase();

        private IUserDao userDao;
        private IArtistDao artistDao;
        private IVenueDao venueDao;
        private IPerformanceDao performanceDao;
        private ICategoryDao categoryDao;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewerImpl"/> class.
        /// </summary>
        public ViewerImpl()
        {
            userDao = DalFactory.CreateUserDao(database);
            artistDao = DalFactory.CreateArtistDao(database);
            venueDao = DalFactory.CreateVenueDao(database);
            performanceDao = DalFactory.CreatePerformanceDao(database);
            categoryDao = DalFactory.CreateCategoryDao(database);
        }

        /// <summary>
        /// Gets all artists.
        /// </summary>
        /// <returns></returns>
        public IList<Artist> GetAllArtists()
        {
            return artistDao.FindAll();
        }

        /// <summary>
        /// Gets all artists.
        /// </summary>
        /// <returns></returns>
        public Artist GetArtistById(int id)
        {
            return artistDao.FindById(id);
        }

        /// <summary>
        /// Gets all artists by category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid Country provided</exception>
        public IList<Artist> GetAllArtistsByCategory(Category category)
        {
            if (category == null ||
                category.Id == null)
                throw new ArgumentNullException("Invalid Country provided");

            return artistDao.FindByCategoryId(category.Id);
        }

        /// <summary>
        /// Gets all artists by country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid Country provided</exception>
        public IList<Artist> GetAllArtistsByCountry(string country)
        {
            if (country == null)
                throw new ArgumentNullException("Invalid Country provided");

            return artistDao.FindByCountry(country);
        }

        /*
        public byte[] GetPictureByArtistId(int id)
        {
            Artist artist = artistDao.FindById(id);

            if (!string.IsNullOrEmpty(artist.PictureUrl))
                return File.ReadAllBytes(artist.PictureUrl);

            return null;
        }

        public byte[] GetVideoByArtistsId(int id)
        {
            Artist artist = artistDao.FindById(id);

            if (!string.IsNullOrEmpty(artist.VideoUrl))
                return File.ReadAllBytes(artist.VideoUrl);

            return null;
        }*/

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <returns></returns>
        public IList<Performance> GetAllPerformances()
        {
            return performanceDao.FindAll();
        }

        /// <summary>
        /// Gets all venues.
        /// </summary>
        /// <returns></returns>
        public IList<Venue> GetAllVenues()
        {
            return venueDao.FindAll();
        }

        /// <summary>
        /// Gets the performance by artist.
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns></returns>
        public IList<Performance> GetPerformanceByArtist(Artist artist)
        {
            return performanceDao.FindByArtistId(artist.Id);
        }

        /// <summary>
        /// Gets the performance by day.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public IList<Performance> GetPerformanceByDay(DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime end = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);

            return performanceDao.FindBetween(start, end);
        }

        /// <summary>
        /// Gets the performance by venue.
        /// </summary>
        /// <param name="venue">The venue.</param>
        /// <returns></returns>
        public IList<Performance> GetPerformanceByVenue(Venue venue)
        {
            return performanceDao.FindByVenue(venue.Label);
        }


        /// <summary>
        /// Gets the performance by venue and date.
        /// </summary>
        /// <param name="venue">The venue.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public IList<Performance> GetPerformanceByVenueAndDate(Venue venue, DateTime date)
        {
            DateTime start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime end = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

            return performanceDao.FindByVenueAndDate(venue.Label, start, end);
        }


        /// <summary>
        /// Determines whether [is performance valid] [the specified p].
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
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

            foreach (var performance in listPerformances)
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


        /// <summary>
        /// Gets the performance by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Performance GetPerformanceById(int id)
        {
            return performanceDao.FindById(id);
        }

        /// <summary>
        /// Updates the performance.
        /// </summary>
        /// <param name="performance">The performance.</param>
        /// <exception cref="System.ArgumentNullException">Invalid performance!</exception>
        /// <exception cref="VenueException">Cannot update performance!</exception>
        public bool UpdatePerformance(Performance performance)
        {
            if (performance == null)
                return false;

            if (performanceDao.FindById(performance.Id) != null)
            {
                if (!performanceDao.Update(performance))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the venues by location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public IList<Venue> GetVenuesByLocation(string location)
        {
            return venueDao.FindByLocationId(location);
        }


        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAllCategories()
        {
            return categoryDao.FindAll();
        }

        public void SendEmail(string address, string subject, string content)
        {
            SmtpClient client = new SmtpClient();
            MailMessage mail = new MailMessage()
            {
                To = { new MailAddress(address) },
                Subject = subject,
                Body = content
            };

            client.Send(mail);
        }

        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid user!</exception>
        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            if (string.IsNullOrEmpty(password))
                return false;

            User user = userDao.FindById(username);

            if (user == null)
                return false;


            if (user.Username.Equals(username) && user.Password.Equals(password))
                return true;

            return false;
        }

        /// <summary>
        /// Check if the specified username is already registrated.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid username!</exception>
        private bool Exist(string username)
        {
            return userDao.FindById(username) != null;
        }


        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string HashPassword(string input)
        {
            return Utils.HashPassword(input);
        }
    }
}
