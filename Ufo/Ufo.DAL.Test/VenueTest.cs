using System;
using System.Collections.Generic;
using Ufo.DAL.Common;
using Ufo.DAL.Common.Dao;
using Ufo.DAL.Common.Domain;
using Ufo.DAL.SqlServer;
using Ufo.DAL.SqlServer.Dao;
using Ufo.DAL.Test.Common;
using Xunit;


namespace Ufo.DAL.Test
{
    public class VenueTest : DaoTest<Venue, int>
    {
        private const string ALTER_LABEL = "Mamut Store";

        private const string LOCATION = "Hauptplatz";
        private const string LOCATION_ID = "H";

        private const int VENUE1_ID = 1;
        private const string VENUE1_LABEL = "Oberbank";
        private const int VENUE1_SPECTATORS = 40;


        private const int VENUE2_ID = 2;
        private const string VENUE2_LABEL = "Mader Reisen";
        private const int VENUE2_SPECTATORS = 100;

        private const int VENUE3_ID = 3;
        private const string VENUE3_LABEL = "Altes Rathaus";
        private const int VENUE3_SPECTATORS = 80;

        private IDatabase database;

        internal override void CreateTestData()
        {
            var loc = new Location(LOCATION_ID, LOCATION);
            var locationDao = new LocationDao(database);
            locationDao.Insert(loc);

            items = new List<Venue>();
            items.Add(new Venue(VENUE1_ID, VENUE1_LABEL, VENUE1_SPECTATORS, loc));
            items.Add(new Venue(VENUE2_ID, VENUE2_LABEL, VENUE2_SPECTATORS, loc));
            items.Add(new Venue(VENUE3_ID, VENUE3_LABEL, VENUE3_SPECTATORS, loc));
        }

        [Fact]
        [AutoRollback]
        public void InsertVenueTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var venueDao = new VenueDao(database);
            InsertDummyData(venueDao);
            Assert.Equal(items.Count, venueDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void FindAllVenuesTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var venueDao = new VenueDao(database);
            InsertDummyData(venueDao);
            Assert.Equal(items.Count, venueDao.Count());

            IList<Venue> dbVenues = venueDao.FindAll();
            Assert.NotNull(dbVenues);
            Assert.Equal(items.Count, dbVenues.Count);

            foreach (var venue in dbVenues)
            {
                Assert.True(items.Contains(venue));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindVenueByIdTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var venueDao = new VenueDao(database);
            InsertDummyData(venueDao);
            Assert.Equal(items.Count, venueDao.Count());

            var currVenue = items[0];

            var myVenue = venueDao.FindById(currVenue.Id, currVenue.Location.Id);
            Assert.NotNull(myVenue);
            Assert.Equal(currVenue, myVenue);

            venueDao.Delete(myVenue.Id, myVenue.Location.Id);
            Assert.Equal(items.Count - 1, venueDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void UpdateVenueTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var venueDao = new VenueDao(database);
            InsertDummyData(venueDao);
            Assert.Equal(items.Count, venueDao.Count());

            var currVenue = items[0];
            currVenue.Label = ALTER_LABEL;

            venueDao.Update(currVenue);
            var myNewVenue = venueDao.FindById(currVenue.Id, currVenue.Location.Id);
            Assert.NotNull(myNewVenue);
            Assert.Equal(ALTER_LABEL, myNewVenue.Label);
        }

        [Fact]
        [AutoRollback]
        public void DeleteVenueTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var venueDao = new VenueDao(database);
            InsertDummyData(venueDao);
            Assert.Equal(items.Count, venueDao.Count());

            foreach (var item in items)
            {
                venueDao.Delete(item.Id, item.Location.Id);
            }
            Assert.Equal(0, venueDao.Count());
        }
    }
}
