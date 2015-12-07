﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;
using Ufo.DAL.SqlServer.Dao;
using Ufo.DAL.SqlServer.Factories;

namespace Ufo.BL
{
    public class ViewerImpl : IViewer
    {
        #region private members
        private ArtistDao artistDao;
        private VenueDao venueDao;
        private PerformanceDao performanceDao;
        private CategoryDao categoryDao;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewerImpl"/> class.
        /// </summary>
        public ViewerImpl()
        {
            artistDao = ArtistDaoFactory.GetArtistDao();
            venueDao = VenueDaoFactory.GetVenueDao();
            performanceDao = PerformanceDaoFactory.GetPerformanceDao();
            categoryDao = CategoryDaoFactory.GetCategoryDao();
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
            return new ObservableCollection<Performance>(performanceDao.FindByDay(day));
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
    }
}
