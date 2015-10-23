using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common;
using Ufo.DAL.Common.Dao;
using Ufo.DAL.Common.Domain;

namespace Ufo.DAL.SqlServer.Dao
{
    public class UserDao : IDao<User, int>
    {
        private const string SQL_FIND_BY_ID =
            @"SELECT * " +
            @"FROM User " +
            @"WHERE idUser = @id";

        private const string SQL_FIND_ALL =
            @"SELECT * FROM User";

        private const string SQL_INSERT =
            @"INSERT INTO User " +
            @"VALUES (@username, @password, @email)";

        private const string SQL_UPDATE =
            @"UPDATE User " +
            @"SET username = @username, password = @password, email = @email " +
            @"WHERE idUser = @id";

        private const string SQL_DELETE = @"DELETE User WHERE idUser = @id";

        private IDatabase _database;

        public UserDao(IDatabase database)
        {
            _database = database;
        }

        public IList<User> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var users = new List<User>();

                while (reader.Read())
                {
                    users.Add(new User((int)reader["idUser"],
                                       (string)reader["username"],
                                       (string)reader["password"],
                                       (string)reader["email"]));
                }

                return users;
            }
        }

        public User FindById(int id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    return new User((int)reader["idUser"],
                                    (string)reader["username"],
                                    (string)reader["password"],
                                    (string)reader["email"]);
                }

                return null;
            }
        }

        public bool Insert(User o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@username", DbType.String, o.Username);
            _database.DefineParameter(command, "@password", DbType.String, o.Password);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Update(User o)
        {
            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.Int32, o.Id);
            _database.DefineParameter(command, "@username", DbType.String, o.Username);
            _database.DefineParameter(command, "@password", DbType.String, o.Password);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);

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
