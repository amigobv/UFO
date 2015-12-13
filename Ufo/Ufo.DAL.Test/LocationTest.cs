using System;
using System.Collections.Generic;
using Ufo.DAL.Common;
using Ufo.Domain;
using Ufo.DAL.SqlServer;
using Ufo.DAL.SqlServer.Dao;
using Ufo.DAL.Test.Common;
using Xunit;

namespace Ufo.DAL.Test
{
    public class LocationTest
    {
        private IList<Location> items;

        private const string CAP_HAUPPLATZ = "HAUPTPLATZ";
        private const string HAUPTPLATZ = "Hauptplatz";
        private const string HAUPTPLATZ_ID = "H";

        private const string LANDSTRASSE = "Landstraße";
        private const string LANDSTRASSE_ID = "L";

        private const string ALTSTADT = "Altstadt";
        private const string ALTSTADT_ID = "A";

        private const string PROMENADE = "Promenade";
        private const string PROMENADE_ID = "P";

        private void CreateTestData()
        {
            items = new List<Location>();
            items.Add(new Location(HAUPTPLATZ_ID, HAUPTPLATZ));
            items.Add(new Location(LANDSTRASSE_ID, LANDSTRASSE));
            items.Add(new Location(ALTSTADT_ID, ALTSTADT));
            items.Add(new Location(PROMENADE_ID, PROMENADE));
        }

        void InsertDummyData(ILocationDao dao)
        {
            CreateTestData();

            foreach (var item in items)
            {
                dao.Insert(item);
            }
        }

        [Fact]
        [AutoRollback]
        public void InsertLocationTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var locationDao = new LocationDao(database);
            InsertDummyData(locationDao);
            Assert.Equal(items.Count, locationDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void FindAllLocationsTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var locationDao = new LocationDao(database);
            InsertDummyData(locationDao);
            Assert.Equal(items.Count, locationDao.Count());

            IList<Location> dbLocations = locationDao.FindAll();
            Assert.NotNull(dbLocations);
            Assert.Equal(items.Count, dbLocations.Count);

            foreach (var loc in dbLocations)
            {
                Assert.True(items.Contains(loc));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindLocationByIdTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var locationDao = new LocationDao(database);
            InsertDummyData(locationDao);
            Assert.Equal(items.Count, locationDao.Count());

            var myLocation = locationDao.FindById(HAUPTPLATZ_ID);
            Assert.NotNull(myLocation);
            Assert.Equal(HAUPTPLATZ, myLocation.Label);

            locationDao.Delete(myLocation.Id);
            Assert.Equal(items.Count-1, locationDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void UpdateLocationTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var locationDao = new LocationDao(database);
            InsertDummyData(locationDao);
            Assert.Equal(items.Count, locationDao.Count());


            locationDao.Update(new Location(HAUPTPLATZ_ID, CAP_HAUPPLATZ));
            var myNewLoc = locationDao.FindById(HAUPTPLATZ_ID);
            Assert.NotNull(myNewLoc);
            Assert.True(!items.Contains(myNewLoc));
            Assert.Equal(CAP_HAUPPLATZ, myNewLoc.Label);
        }

        [Fact]
        [AutoRollback]
        public void DeleteLocationTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var locationDao = new LocationDao(database);
            InsertDummyData(locationDao);
            Assert.Equal(items.Count, locationDao.Count());

            foreach (var item in items)
            {
                locationDao.Delete(item.Id);
            }
            Assert.Equal(0, locationDao.Count());
        }
    }
}
