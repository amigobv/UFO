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
    public class ArtistTest : DaoTest<Artist, int>
    {
        private const string COMEDY_LABEL = "Comedy";
        private const string COMEDY_ID = "C";

        private const int ARTIST1_ID = 1;
        private const string ARTIST1_NAME = "Artist 1";
        private const string ARTIST1_COUNTRY = "Österreich";
        private const string ARTIST1_MAIL = "Artist_1@mail.com";

        private const int ARTIST2_ID = 1;
        private const string ARTIST2_NAME = "Artist 2";
        private const string ARTIST2_COUNTRY = "Deutschland";
        private const string ARTIST2_MAIL = "Artist_2@mail.com";

        private const int ARTIST3_ID = 1;
        private const string ARTIST3_NAME = "Artist 3";
        private const string ARTIST3_COUNTRY = "Schweiz";
        private const string ARTIST3_MAIL = "Artist_3@mail.com";

        private IDatabase database;

        internal override void CreateTestData()
        {
            var cat = new Category(COMEDY_ID, COMEDY_LABEL);
            var categoryDao = new CategoryDao(database);
            categoryDao.Insert(cat);

            items = new List<Artist>();
            items.Add(new Artist(ARTIST1_ID, ARTIST1_NAME, ARTIST1_COUNTRY, ARTIST1_MAIL, "", "", "", "", cat, false));
            items.Add(new Artist(ARTIST2_ID, ARTIST2_NAME, ARTIST2_COUNTRY, ARTIST2_MAIL, "", "", "", "", cat, false));
            items.Add(new Artist(ARTIST3_ID, ARTIST3_NAME, ARTIST3_COUNTRY, ARTIST3_MAIL, "", "", "", "", cat, false));
        }

        [Fact]
        [AutoRollback]
        public void InsertArtistTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var artistDao = new ArtistDao(database);
            InsertDummyData(artistDao);
            Assert.Equal(items.Count, artistDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void FindAllArtistsTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var artistDao = new ArtistDao(database);
            InsertDummyData(artistDao);
            Assert.Equal(items.Count, artistDao.Count());

            IList<Artist> dbArtists = artistDao.FindAll();
            Assert.NotNull(dbArtists);
            Assert.Equal(items.Count, dbArtists.Count);

            foreach (var cat in dbArtists)
            {
                Assert.True(items.Contains(cat));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindArtisByIdTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var artistDao = new ArtistDao(database);
            InsertDummyData(artistDao);
            Assert.Equal(items.Count, artistDao.Count());

            var it = items.GetEnumerator();
            var currArtist = it.Current;

            Artist myArtist = artistDao.FindById(currArtist.Id);
            Assert.NotNull(myArtist);
            Assert.Equal(currArtist, myArtist);

            artistDao.Delete(myArtist.Id);
            Assert.Equal(items.Count - 1, artistDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void UpdateArtistTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var artistDao = new ArtistDao(database);
            InsertDummyData(artistDao);
            Assert.Equal(items.Count, artistDao.Count());

            var it = items.GetEnumerator();
            var currArtist = it.Current;

            currArtist.Name = "AlteredName";

            artistDao.Update(currArtist);
            var myNewArtist = artistDao.FindById(currArtist.Id);
            Assert.NotNull(myNewArtist);
            Assert.Equal("AlteredName", myNewArtist.Name);
        }

        [Fact]
        [AutoRollback]
        public void DeleteArtistTest()
        {
            if (database == null)
            {
                database = new Database(TestUtils.ConnString);
            }
            Assert.NotNull(database);

            var artistDao = new ArtistDao(database);
            InsertDummyData(artistDao);
            Assert.Equal(items.Count, artistDao.Count());

            foreach (var item in items)
            {
                artistDao.Delete(item.Id);
            }
            Assert.Equal(0, artistDao.Count());
        }
    }
}
