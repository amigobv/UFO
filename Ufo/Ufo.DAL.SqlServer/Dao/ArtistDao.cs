﻿using System;
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
        private const string SQL_FIND_BY_ID = 
            @"SELECT * " +
            @"FROM Artist " + 
            @"WHERE idArtist = @id";

        // TODO: check FIND_ALL query
        private const string SQL_FIND_ALL = 
            @"SELECT * FROM Artist";

        private const string SQL_INSERT = 
            @"INSERT INTO Artist " +
            @"VALUES (@name, @country, @email, @description, @homepage, @picture, @video, @category, @delete)";

        private const string SQL_UPDATE = 
            @"UPDATE Artist " +
            @"SET name = @name, country = @country, email = @email, description = @description, " +
            @"homepage = @homepage, picture = @picture, video = @video, category = @categoryId, deleted = @delete " + 
            @"WHERE idArtist = @id";

        private const string SQL_DELETE = 
            @"UPDATE Artist " +
            @"SET deleted = @delete" +
            @"WHERE idArtist = @id";

        private IDatabase _database;

        public ArtistDao(IDatabase database)
        {
            _database = database;
        }

        public IList<Artist> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var artists = new List<Artist>();

                while (reader.Read())
                {
                    var category = new CategoryDao(_database).FindById((string)reader["category"]);

                    var artist = new Artist((int)reader["idArtist"],
                                            (string)reader["name"],
                                            (string)reader["country"],
                                            (string)reader["email"],
                                            (string)reader["description"],
                                            (string)reader["homepage"],
                                            (string)reader["picture"],
                                            (string)reader["video"],
                                            category,
                                            (bool)reader["deleted"]);

                    artists.Add(artist);
                }

                return artists;
            }
        }

        public Artist FindById(int id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    var category = new CategoryDao(_database).FindById((string)reader["category"]);

                    return new Artist((int)reader["idArtist"],
                                            (string)reader["name"],
                                            (string)reader["country"],
                                            (string)reader["email"],
                                            (string)reader["description"],
                                            (string)reader["homepage"],
                                            (string)reader["picture"],
                                            (string)reader["video"],
                                            category,
                                            (bool)reader["deleted"]);
                }
            }

            return null;
        }

        public bool Insert(Artist o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@name", DbType.String, o.Name);
            _database.DefineParameter(command, "@country", DbType.String, o.Country);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);
            _database.DefineParameter(command, "@description", DbType.String, o.Description);
            _database.DefineParameter(command, "@homepage", DbType.String, o.Homepage);
            _database.DefineParameter(command, "@picture", DbType.String, o.PictureUri);
            _database.DefineParameter(command, "@video", DbType.String, o.VideoUri);
            _database.DefineParameter(command, "@category", DbType.String, o.Category.Id);
            _database.DefineParameter(command, "@delete", DbType.Boolean, o.IsDeleted);

            return _database.ExecuteNonQuery(command) == 1;

        }


        public bool Update(Artist o)
        {
            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.Int32, o.Id);
            _database.DefineParameter(command, "@name", DbType.String, o.Name);
            _database.DefineParameter(command, "@country", DbType.String, o.Country);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);
            _database.DefineParameter(command, "@description", DbType.String, o.Description);
            _database.DefineParameter(command, "@homepage", DbType.String, o.Homepage);
            _database.DefineParameter(command, "@picture", DbType.String, o.PictureUri);
            _database.DefineParameter(command, "@video", DbType.String, o.VideoUri);
            _database.DefineParameter(command, "@category", DbType.String, o.Category.Id);
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
