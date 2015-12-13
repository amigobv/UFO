using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common;
using Ufo.DAL.Common.Domain;
using Ufo.DAL.SqlServer;
using Ufo.DAL.SqlServer.Dao;
using Ufo.DAL.Test.Common;
using Xunit;

namespace Ufo.DAL.Test
{
    public class PerformanceTest : DaoTest<Performance, int>
    {
        private const string LOCATION = "Hauptplatz";
        private const string LOCATION_ID = "H";

        private const int VENUE_ID = 1;
        private const string VENUE_LABEL = "Oberbank";
        private const int VENUE_SPECTATORS = 40;

        private const string CATEGORY_LABEL = "Comedy";
        private const string CATEGORY_ID = "C";

        private const int ARTIST_ID = 1;
        private const string ARTIST_NAME = "Artist 1";
        private const string ARTIST_COUNTRY = "Österreich";
        private const string ARTIST_MAIL = "Artist_1@mail.com";


        private DateTime ALTER_START = new DateTime(2020, 12, 25, 12, 00, 00);

        private DateTime PERFORMANCE1_START = new DateTime(2015, 07, 22, 16, 00, 00);
        private DateTime PERFORMANCE2_START = new DateTime(2015, 07, 23, 16, 00, 00);
        private DateTime PERFORMANCE3_START = new DateTime(2015, 07, 24, 16, 00, 00);
        private DateTime PERFORMANCE4_START = new DateTime(2015, 07, 22, 20, 00, 00);

        private IDatabase database;

        internal override void CreateTestData()
        {
            var loc = new Location(LOCATION_ID, LOCATION);
            var locationDao = new LocationDao(database);
            locationDao.Insert(loc);

            var venue = new Venue(VENUE_ID, VENUE_LABEL, VENUE_SPECTATORS, loc);
            var venueDao = new VenueDao(database);
            venueDao.Insert(venue);

            var category = new Category(CATEGORY_ID, CATEGORY_LABEL);
            var categoryDao = new CategoryDao(database);
            categoryDao.Insert(category);

            var artist = new Artist(ARTIST_ID, ARTIST_NAME, ARTIST_COUNTRY, ARTIST_MAIL, "", "", "", "", category, false);
            var artistDao = new ArtistDao(database);
            artistDao.Insert(artist);

            items = new List<Performance>();
            items.Add(new Performance(1, PERFORMANCE1_START, artist, venue));
            items.Add(new Performance(2, PERFORMANCE2_START, artist, venue));
            items.Add(new Performance(3, PERFORMANCE3_START, artist, venue));
            items.Add(new Performance(4, PERFORMANCE4_START, artist, venue));
        }

        [Fact]
        [AutoRollback]
        public void InsertPerformanceTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void FindAllPerformancesTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            IList<Performance> dbPerformance = performanceDao.FindAll();
            Assert.NotNull(dbPerformance);
            Assert.Equal(items.Count, dbPerformance.Count);

            foreach (var performance in dbPerformance)
            {
                Assert.True(items.Contains(performance));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindPerformancesByArtistTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            IList<Performance> dbPerformance = performanceDao.FindByArtist(ARTIST_NAME);
            Assert.NotNull(dbPerformance);
            Assert.Equal(items.Count, dbPerformance.Count);

            foreach (var performance in dbPerformance)
            {
                Assert.True(items.Contains(performance));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindPerformancesByArtistIdTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            var artistDao = new ArtistDao(database);
            var artists = artistDao.FindByName(ARTIST_NAME);
            Assert.NotNull(artists);
            Assert.NotEqual(0, artists.Count);

            IList<Performance> dbPerformance = performanceDao.FindByArtistId(artists[0].Id);
            Assert.NotNull(dbPerformance);
            Assert.Equal(items.Count, dbPerformance.Count);

            foreach (var performance in dbPerformance)
            {
                Assert.True(items.Contains(performance));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindPerformancesByVenueTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            IList<Performance> dbPerformance = performanceDao.FindByVenue(VENUE_LABEL);
            Assert.NotNull(dbPerformance);
            Assert.Equal(items.Count, dbPerformance.Count);

            foreach (var performance in dbPerformance)
            {
                Assert.True(items.Contains(performance));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindPerformancesByDayTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            IList<Performance> dbPerformance = performanceDao.FindByDay(PERFORMANCE1_START, PERFORMANCE4_START);
            Assert.NotNull(dbPerformance);
            Assert.Equal(2, dbPerformance.Count);
        }

        

        [Fact]
        [AutoRollback]
        public void FindPerformanceByIdTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            var currPerformance = items[0];

            var myPerformance = performanceDao.FindById(currPerformance.Id);
            Assert.NotNull(myPerformance);
            Assert.Equal(currPerformance, myPerformance);

            performanceDao.Delete(myPerformance.Id);
            Assert.Equal(items.Count - 1, performanceDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void UpdatePerformanceTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            var currPerformance = items[0];
            currPerformance.Start = ALTER_START;

            performanceDao.Update(currPerformance);
            var myNewPerformance = performanceDao.FindById(currPerformance.Id);
            Assert.NotNull(myNewPerformance);
            Assert.Equal(ALTER_START, myNewPerformance.Start);
        }

        [Fact]
        [AutoRollback]
        public void DeletePerformanceTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var performanceDao = new PerformanceDao(database);
            InsertDummyData(performanceDao);
            Assert.Equal(items.Count, performanceDao.Count());

            foreach (var item in items)
            {
                performanceDao.Delete(item.Id);
            }
            Assert.Equal(0, performanceDao.Count());
        }
    }
}
