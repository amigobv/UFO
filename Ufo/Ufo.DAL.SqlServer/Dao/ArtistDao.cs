using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common;
using Ufo.DAL.Common.Dao;
using Ufo.DAL.Common.Domain;

namespace Ufo.DAL.SqlServer.Dao
{
    public class ArtistDao : IDao<Artist, int>
    {
        private const string SQL_COUNT =
            @"Select COUNT(idArtist) FROM Artist";

        private const string SQL_FIND_BY_ID =
            @"SELECT a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, a.deleted, c.idCategory, c.label " +
            @"FROM Artist as a, Category as c " +
            @"WHERE a.category = c.idCategory AND a.idArtist = @id";

        // TODO: check FIND_ALL query
        private const string SQL_FIND_ALL =
            @"SELECT a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, a.deleted, c.idCategory, c.label " +
            @"FROM Artist as a, Category as c " +
            @"WHERE a.category = c.idCategory";

        private const string SQL_FIND_BY_NAME =
            @"SELECT a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, a.deleted, c.idCategory, c.label " +
            @"FROM Artist as a, Category as c " +
            @"WHERE a.category = c.idCategory AND a.name LIKE @name " + 
            @"ORDER BY a.name ASC";

        private const string SQL_FIND_BY_COUNTRY =
            @"SELECT a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, a.deleted, c.idCategory, c.label " +
            @"FROM Artist as a, Category as c " +
            @"WHERE a.category = c.idCategory AND a.country LIKE @country " +
            @"ORDER BY a.name ASC";

        private const string SQL_FIND_BY_CATEGORY =
            @"SELECT a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, a.deleted, c.idCategory, c.label " +
            @"FROM Artist as a, Category as c " +
            @"WHERE a.category = c.idCategory AND c.label LIKE @category " +
            @"ORDER BY a.name ASC";

        private const string SQL_FIND_BY_CATEGORY_ID =
            @"SELECT a.idArtist, a.name, a.country, a.email, a.description, a.homepage, a.picture, a.video, a.deleted, c.idCategory, c.label " +
            @"FROM Artist as a, Category as c " +
            @"WHERE a.category = c.idCategory AND a.category LIKE @categoryId " +
            @"ORDER BY a.name ASC";

        private const string SQL_INSERT =
            @"INSERT INTO Artist " +
            @"VALUES (@name, @country, @email, @description, @homepage, @picture, @video, @category, @delete);" +
            @"SELECT SCOPE_IDENTITY()";

        private const string SQL_UPDATE = 
            @"UPDATE Artist " +
            @"SET name = @name, country = @country, email = @email, description = @description, " +
            @"homepage = @homepage, picture = @picture, video = @video, category = @categoryId, deleted = @delete " + 
            @"WHERE idArtist = @id";

        private const string SQL_MARK_DELETED =
            @"UPDATE FROM Artist " +
            @"SET deleted = @delete " +
            @"WHERE idArtist = @id";

        private const string SQL_DELETE =
            @"DELETE FROM Artist " +
            @"WHERE idArtist = @id";

        private const string SQL_IDENTITY = "Select @@Identity";

        private IDatabase _database;

        public ArtistDao(IDatabase database)
        {
            _database = database;
        }

        public int Count()
        {
            var command = _database.CreateCommand(SQL_COUNT);

            return (int)_database.ExecuteScalar(command);
        }

        public IList<Artist> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        private IList<Artist> DataReaderToList(IDataReader reader)
        {
            if (reader == null)
                return null;

            var artists = new List<Artist>();

            while (reader.Read())
            {
                var artist = new Artist((int)reader["idArtist"],
                                        (string)reader["name"],
                                        (string)reader["country"],
                                        (string)reader["email"],
                                        (string)reader["description"],
                                        (string)reader["homepage"],
                                        (string)reader["picture"],
                                        (string)reader["video"],
                                        new Category((string)reader["idCategory"], (string)reader["label"]),
                                        (bool)reader["deleted"]);
                artists.Add(artist);
            }

            return artists;
        }

        public Artist FindById(int id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    return new Artist((int)reader["idArtist"],
                                            (string)reader["name"],
                                            (string)reader["country"],
                                            (string)reader["email"],
                                            (string)reader["description"],
                                            (string)reader["homepage"],
                                            (string)reader["picture"],
                                            (string)reader["video"],
                                            new Category((string)reader["idCategory"], (string)reader["label"]),
                                            (bool)reader["deleted"]);
                }
            }

            return null;
        }

        public IList<Artist> FindByName(string name)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_NAME);
            _database.DefineParameter(command, "@name", DbType.String, name);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public IList<Artist> FindByCountry(string country)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_COUNTRY);
            _database.DefineParameter(command, "@country", DbType.String, country);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public IList<Artist> FindByCategory(string category)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_CATEGORY);
            _database.DefineParameter(command, "@category", DbType.String, category);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public IList<Artist> FindByCategoryId(string categoryId)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_CATEGORY_ID);
            _database.DefineParameter(command, "@categoryId", DbType.String, categoryId);

            using (var reader = _database.ExecuteReader(command))
            {
                return DataReaderToList(reader);
            }
        }

        public bool Insert(Artist o)
        {
            if (o == null ||
                o.Name == null ||
                o.Country == null ||
                o.Email == null)
                return false;

            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@name", DbType.String, o.Name);
            _database.DefineParameter(command, "@country", DbType.String, o.Country);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);
            _database.DefineParameter(command, "@description", DbType.String, o.Description);
            _database.DefineParameter(command, "@homepage", DbType.String, o.Homepage);
            _database.DefineParameter(command, "@picture", DbType.String, o.PictureUrl);
            _database.DefineParameter(command, "@video", DbType.String, o.VideoUrl);
            _database.DefineParameter(command, "@category", DbType.String, o.Category.Id);
            _database.DefineParameter(command, "@delete", DbType.Boolean, o.IsDeleted);

            var id = _database.ExecuteScalar(command);
            o.Id = Convert.ToInt32(id.ToString());

            return id != null;
        }


        public bool Update(Artist o)
        {
            if (o == null ||
                o.Name == null ||
                o.Country == null ||
                o.Email == null)
                return false;

            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.Int32, o.Id);
            _database.DefineParameter(command, "@name", DbType.String, o.Name);
            _database.DefineParameter(command, "@country", DbType.String, o.Country);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);
            _database.DefineParameter(command, "@description", DbType.String, o.Description);
            _database.DefineParameter(command, "@homepage", DbType.String, o.Homepage);
            _database.DefineParameter(command, "@picture", DbType.String, o.PictureUrl);
            _database.DefineParameter(command, "@video", DbType.String, o.VideoUrl);
            _database.DefineParameter(command, "@categoryId", DbType.String, o.Category.Id);
            _database.DefineParameter(command, "@delete", DbType.Boolean, o.IsDeleted);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            var command = _database.CreateCommand(SQL_DELETE);
            _database.DefineParameter(command, "@id", DbType.Int32, id);
            _database.DefineParameter(command, "@deleted", DbType.Boolean, true);

            return _database.ExecuteNonQuery(command) == 1;
        }
    }
}
