using System;
using System.Collections.Generic;
using System.Net.Mail;
using Ufo.DAL.Common;
using Ufo.Domain;


namespace Ufo.BL
{
    public class ViewerImpl : IViewer
    {
        #region private members
        private IDatabase database = DalFactory.CreateDatabase();

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
    }
}
