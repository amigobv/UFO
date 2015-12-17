using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
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
        public ObservableCollection<Artist> GetAllArtists()
        {
            return new ObservableCollection<Artist>(artistDao.FindAll());
        }

        /// <summary>
        /// Gets all artists by category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid Country provided</exception>
        public ObservableCollection<Artist> GetAllArtistsByCategory(Category category)
        {
            if (category == null ||
                category.Id == null)
                throw new ArgumentNullException("Invalid Country provided");

            return new ObservableCollection<Artist>(artistDao.FindByCategoryId(category.Id));
        }

        /// <summary>
        /// Gets all artists by country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Invalid Country provided</exception>
        public ObservableCollection<Artist> GetAllArtistsByCountry(string country)
        {
            if (country == null)
                throw new ArgumentNullException("Invalid Country provided");

            return new ObservableCollection<Artist>(artistDao.FindByCountry(country));
        }

        /// <summary>
        /// Gets all performances.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Performance> GetAllPerformances()
        {
            return new ObservableCollection<Performance>(performanceDao.FindAll());
        }

        /// <summary>
        /// Gets all venues.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Venue> GetAllVenues()
        {
            return new ObservableCollection<Venue>(venueDao.FindAll());
        }

        /// <summary>
        /// Gets the performance by artist.
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns></returns>
        public ObservableCollection<Performance> GetPerformanceByArtist(Artist artist)
        {
            return new ObservableCollection<Performance>(performanceDao.FindByArtistId(artist.Id));
        }

        /// <summary>
        /// Gets the performance by day.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public ObservableCollection<Performance> GetPerformanceByDay(DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime end = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);

            return new ObservableCollection<Performance>(performanceDao.FindBetween(start, end));
        }

        /// <summary>
        /// Gets the performance by venue.
        /// </summary>
        /// <param name="venue">The venue.</param>
        /// <returns></returns>
        public ObservableCollection<Performance> GetPerformanceByVenue(Venue venue)
        {
            return new ObservableCollection<Performance>(performanceDao.FindByVenue(venue.Label));
        }

        /// <summary>
        /// Gets the venues by location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public ObservableCollection<Venue> GetVenuesByLocation(string location)
        {
            return new ObservableCollection<Venue>(venueDao.FindByLocationId(location));
        }


        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Category> GetAllCategories()
        {
            return new ObservableCollection<Category>(categoryDao.FindAll());
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
