using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common;
using Ufo.Domain;

namespace Ufo.DAL.SqlServer.Dao
{
    public class PerformanceDao : IPerformanceDao
    {
        private const string SQL_COUNT =
            @"Select COUNT(idPerformance) FROM Performance";

        private const string SQL_FIND_BY_ID =
            @"SELECT p.idPerformance, p.start, a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, " +
            @"c.idCategory, c.label, a.deleted, v.idVenue, v.label, v.maxSpectators, l.idLocation, l.label " +
            @"FROM Performance as p, Artist as a, Venue as v, Location as l, Category as c " +
            @"WHERE p.artist = a.idArtist AND a.category = c.idCategory AND p.pVenue = v.idVenue AND p.pLocation = l.idLocation AND p.idPerformance = @id";

        private const string SQL_FIND_BY_ARTIST =
            @"SELECT p.idPerformance, p.start, a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, " +
            @"c.idCategory, c.label, a.deleted, v.idVenue, v.label, v.maxSpectators, l.idLocation, l.label " +
            @"FROM Performance as p, Artist as a, Venue as v, Location as l, Category as c " +
            @"WHERE p.artist = a.idArtist AND a.category = c.idCategory AND p.pVenue = v.idVenue AND p.pLocation = l.idLocation AND a.name LIKE @artist " +
            @"ORDER BY p.start ASC";

        private const string SQL_FIND_BY_ARTIST_ID =
            @"SELECT p.idPerformance, p.start, a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, " +
            @"c.idCategory, c.label, a.deleted, v.idVenue, v.label, v.maxSpectators, l.idLocation, l.label " +
            @"FROM Performance as p, Artist as a, Venue as v, Location as l, Category as c " +
            @"WHERE p.artist = a.idArtist AND a.category = c.idCategory AND p.pVenue = v.idVenue AND p.pLocation = l.idLocation AND p.artist = @artist " +
            @"ORDER BY p.start ASC";

        private const string SQL_FIND_BY_VENUE =
            @"SELECT p.idPerformance, p.start, a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, " +
            @"c.idCategory, c.label, a.deleted, v.idVenue, v.label, v.maxSpectators, l.idLocation, l.label " +
            @"FROM Performance as p, Artist as a, Venue as v, Location as l, Category as c " +
            @"WHERE p.artist = a.idArtist AND a.category = c.idCategory AND p.pVenue = v.idVenue AND p.pLocation = l.idLocation AND v.label = @venue " +
            @"ORDER BY p.start ASC";

        private const string SQL_FIND_BY_BETWEEN =
            @"SELECT p.idPerformance, p.start, a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, " +
            @"c.idCategory, c.label, a.deleted, v.idVenue, v.label, v.maxSpectators, l.idLocation, l.label " +
            @"FROM Performance as p, Artist as a, Venue as v, Location as l, Category as c " +
            @"WHERE p.artist = a.idArtist AND a.category = c.idCategory AND p.pVenue = v.idVenue AND p.pLocation = l.idLocation AND p.pLocation = v.location AND p.start BETWEEN @start AND @end " +
            @"ORDER BY p.start ASC";

        private const string SQL_FIND_ALL =
            @"SELECT p.idPerformance, p.start, a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, " + 
            @"c.idCategory, c.label, a.deleted, v.idVenue, v.label, v.maxSpectators, l.idLocation, l.label " +
            @"FROM Performance as p, Artist as a, Venue as v, Location as l, Category as c " +
            @"WHERE p.artist = a.idArtist AND a.category = c.idCategory AND p.pVenue = v.idVenue AND p.pLocation = l.idLocation";

        private const string SQL_INSERT =
            @"INSERT INTO Performance " +
            @"VALUES (@time, @artistId, @venueId, @locationId);" +
            @"SELECT SCOPE_IDENTITY()";

        private const string SQL_UPDATE =
            @"UPDATE Performance " +
            @"SET start = @time, artist = @artistId, pVenue = @venueId, pLocation = @locationId " +
            @"WHERE idPerformance = @id";

        private const string SQL_DELETE = @"DELETE FROM Performance WHERE idPerformance = @id";

        private IDatabase _database;

        public PerformanceDao(IDatabase database)
        {
            _database = database;
        }

        public int Count()
        {
            var command = _database.CreateCommand(SQL_COUNT);

            return (int)_database.ExecuteScalar(command);
        }

        public IList<Performance> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        private IList<Performance> DataReaderToList(IDataReader reader)
        {
            if (reader == null)
                return null;

            var performancies = new List<Performance>();

            while (reader.Read())
            {
                performancies.Add(new Performance((int)reader[0],                   // performance id
                                                      (DateTime)reader[1],              // performance start
                                                      new Artist((int)reader[2],        // artist id
                                                                 (string)reader[3],     // artist name
                                                                 (string)reader[4],     // artist country
                                                                 (string)reader[5],     // artist email   
                                                                 (reader[6] == DBNull.Value) ? string.Empty : (string)reader[6],     // artist description
                                                                 (reader[7] == DBNull.Value) ? string.Empty : (string)reader[7],     // artist homepage
                                                                 (reader[8] == DBNull.Value) ? string.Empty : (string)reader[8],     // artist picture 
                                                                 (reader[9] == DBNull.Value) ? string.Empty : (string)reader[9],     // artist video
                                                                 new Category((string)reader[10],    // category id
                                                                              (string)reader[11]),   // category label
                                                                 (bool)reader[12]),     // artist deleted
                                                      new Venue((int)reader[13],        // venue id
                                                                (string)reader[14],     // venue label
                                                                (int)reader[15],        // venue spectators
                                                                new Location((string)reader[16],    // location id
                                                                             (string)reader[17])    // location label
                                                      )));
            }

            return performancies;
        }

        public IList<Performance> FindByArtistId(int idArtist)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ARTIST_ID);
            _database.DefineParameter(command, "@artist", DbType.Int32, idArtist);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public IList<Performance> FindByArtist(string artist)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ARTIST);
            _database.DefineParameter(command, "@artist", DbType.String, artist);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public IList<Performance> FindByVenue(string venue)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_VENUE);
            _database.DefineParameter(command, "@venue", DbType.String, venue);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public IList<Performance> FindBetween(DateTime start, DateTime end)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_BETWEEN);
            _database.DefineParameter(command, "@start", DbType.DateTime, start);
            _database.DefineParameter(command, "@end", DbType.DateTime, end);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public Performance FindById(int id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {

                    return new Performance((int)reader[0],                   // performance id
                                           (DateTime)reader[1],              // performance start
                                           new Artist((int)reader[2],        // artist id
                                                      (string)reader[3],     // artist name
                                                      (string)reader[4],     // artist country
                                                      (string)reader[5],     // artist email   
                                                      (reader[6] == DBNull.Value) ? string.Empty : (string)reader[6],     // artist description
                                                      (reader[7] == DBNull.Value) ? string.Empty : (string)reader[7],     // artist homepage
                                                      (reader[8] == DBNull.Value) ? string.Empty : (string)reader[8],     // artist picture 
                                                      (reader[9] == DBNull.Value) ? string.Empty : (string)reader[9],     // artist video
                                                      new Category((string)reader[10],    // category id
                                                                   (string)reader[11]),   // category label
                                                      (bool)reader[12]),     // artist deleted
                                                      new Venue((int)reader[13],        // venue id
                                                                (string)reader[14],     // venue label
                                                                (int)reader[15],        // venue spectators
                                                                new Location((string)reader[16],    // location id
                                                                             (string)reader[17])    // location label
                                                      ));
                }

                return null;
            }
        }

        public bool Insert(Performance o)
        {
            if (o == null ||
                o.Artist == null ||
                o.Venue == null ||
                o.Start == null)
                return false;

            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@time", DbType.DateTime, o.Start);
            _database.DefineParameter(command, "@artistId", DbType.String, o.Artist.Id);
            _database.DefineParameter(command, "@venueId", DbType.Int32, o.Venue.Id);
            _database.DefineParameter(command, "@locationId", DbType.Int32, o.Venue.Location.Id);

            var id = _database.ExecuteScalar(command);
            o.Id = Convert.ToInt32(id.ToString());

            return id != null;
        }

        public bool Update(Performance o)
        {
            if (o == null ||
                o.Artist == null ||
                o.Venue == null ||
                o.Start == null)
                return false;

            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.Int32, o.Id);
            _database.DefineParameter(command, "@time", DbType.Time, o.Start);
            _database.DefineParameter(command, "@artistId", DbType.String, o.Artist.Id);
            _database.DefineParameter(command, "@venueId", DbType.Int32, o.Venue.Id);
            _database.DefineParameter(command, "@locationId", DbType.Int32, o.Venue.Location.Id);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            var command = _database.CreateCommand(SQL_DELETE);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            return _database.ExecuteNonQuery(command) == 1;
        }
    }
}
