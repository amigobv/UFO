using System;
using System.Collections.Generic;
using System.Linq;
using Ufo.DAL.Common;
using Ufo.DAL.Common.Domain;
using Ufo.DAL.SqlServer;
using Ufo.DAL.SqlServer.Dao;
using Ufo.DAL.Test.Common;
using Xunit;

namespace Ufo.DAL.Test
{
    public class RestrictionTest : DaoTest<Restriction, int>
    {
        private const string LOCATION = "Hauptplatz";
        private const string LOCATION_ID = "H";

        private const int VENUE_ID = 1;
        private const string VENUE_LABEL = "Oberbank";
        private const int VENUE_SPECTATORS = 40;

        private const string CATEGORY_LABEL = "Comedy";
        private const string CATEGORY_ID = "C";


        private DateTime ALTER_START = new DateTime(2020, 12, 25, 12, 00, 00);

        private DateTime RESTRICTION1_START = new DateTime(2015, 07, 22, 16, 00, 00);
        private DateTime RESTRICTION1_STOP = new DateTime(2015, 07, 22, 21, 00, 00);

        private DateTime RESTRICTION2_START = new DateTime(2015, 07, 23, 16, 00, 00);
        private DateTime RESTRICTION2_STOP = new DateTime(2015, 07, 23, 21, 00, 00);

        private DateTime RESTRICTION3_START = new DateTime(2015, 07, 24, 16, 00, 00);
        private DateTime RESTRICTION3_STOP = new DateTime(2015, 07, 24, 21, 00, 00);

        private DateTime RESTRICTION4_START = new DateTime(2015, 07, 22, 21, 00, 00);
        private DateTime RESTRICTION4_STOP = new DateTime(2015, 07, 22, 23, 00, 00);

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

            items = new List<Restriction>();
            items.Add(new Restriction(1, RESTRICTION1_START, RESTRICTION1_STOP, venue, category));
            items.Add(new Restriction(2, RESTRICTION2_START, RESTRICTION2_STOP, venue, category));
            items.Add(new Restriction(3, RESTRICTION3_START, RESTRICTION3_STOP, venue, category));
            items.Add(new Restriction(4, RESTRICTION4_START, RESTRICTION4_STOP, venue, category));
        }

        [Fact]
        [AutoRollback]
        public void InsertRestrictionTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var restrictionDao = new RestrictionDao(database);
            InsertDummyData(restrictionDao);
            Assert.Equal(items.Count, restrictionDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void FindAllRestrictionsTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var restrictionDao = new RestrictionDao(database);
            InsertDummyData(restrictionDao);
            Assert.Equal(items.Count, restrictionDao.Count());

            IList<Restriction> dbRestrictios = restrictionDao.FindAll();
            Assert.NotNull(dbRestrictios);
            Assert.Equal(items.Count, dbRestrictios.Count);

            foreach (var restriction in dbRestrictios)
            {
                Assert.True(items.Contains(restriction));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindRestrictionByIdTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var restrictionDao = new RestrictionDao(database);
            InsertDummyData(restrictionDao);
            Assert.Equal(items.Count, restrictionDao.Count());

            var currRestriction = items[0];

            var myRestriction = restrictionDao.FindById(currRestriction.Id);
            Assert.NotNull(myRestriction);
            Assert.Equal(currRestriction, myRestriction);

            restrictionDao.Delete(myRestriction.Id);
            Assert.Equal(items.Count - 1, restrictionDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void UpdateRestrictionTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var restrictionDao = new RestrictionDao(database);
            InsertDummyData(restrictionDao);
            Assert.Equal(items.Count, restrictionDao.Count());

            var currRestriction = items[0];
            currRestriction.Start = ALTER_START;

            restrictionDao.Update(currRestriction);
            var myNewRestriction = restrictionDao.FindById(currRestriction.Id);
            Assert.NotNull(myNewRestriction);
            Assert.Equal(ALTER_START, myNewRestriction.Start);
        }

        [Fact]
        [AutoRollback]
        public void DeleteRestrictionTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var restrictionDao = new RestrictionDao(database);
            InsertDummyData(restrictionDao);
            Assert.Equal(items.Count, restrictionDao.Count());

            foreach (var item in items)
            {
                restrictionDao.Delete(item.Id);
            }
            Assert.Equal(0, restrictionDao.Count());
        }
    }
}
