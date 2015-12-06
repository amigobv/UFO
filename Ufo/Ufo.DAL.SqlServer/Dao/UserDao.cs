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
    public class UserDao : IDao<User, string>
    {
        private const string SQL_COUNT =
            @"Select COUNT(username) FROM Admin";

        private const string SQL_FIND_BY_ID =
            @"SELECT * " +
            @"FROM Admin " +
            @"WHERE username = @username";

        private const string SQL_FIND_ALL =
            @"SELECT * FROM Admin";

        private const string SQL_INSERT =
            @"INSERT INTO Admin " +
            @"VALUES (@username, @password, @email)";

        private const string SQL_UPDATE =
            @"UPDATE Admin " +
            @"SET username = @username, password = @password, email = @email " +
            @"WHERE username = @username";

        private const string SQL_DELETE = @"DELETE FROM Admin WHERE username = @username";

        private IDatabase _database;

        public UserDao(IDatabase database)
        {
            _database = database;
        }

        public int Count()
        {
            var command = _database.CreateCommand(SQL_COUNT);
            return (int)_database.ExecuteScalar(command);
        }

        public IList<User> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var users = new List<User>();

                while (reader.Read())
                {
                    users.Add(new User((string)reader["username"],
                                       (string)reader["password"],
                                       (string)reader["email"]));
                }

                return users;
            }
        }

        public User FindById(string id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@username", DbType.String, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    return new User((string)reader["username"],
                                    (string)reader["password"],
                                    (string)reader["email"]);
                }

                return null;
            }
        }

        public bool Insert(User o)
        {
            if (o == null ||
                o.Username == null ||
                o.Password == null ||
                o.Email == null)
                return false;

            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@username", DbType.String, o.Username);
            _database.DefineParameter(command, "@password", DbType.String, o.Password);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Update(User o)
        {
            if (o == null ||
                o.Username == null ||
                o.Password == null ||
                o.Email == null)
                return false;

            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@username", DbType.String, o.Username);
            _database.DefineParameter(command, "@password", DbType.String, o.Password);
            _database.DefineParameter(command, "@email", DbType.String, o.Email);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(string id)
        {
            var command = _database.CreateCommand(SQL_DELETE);
            _database.DefineParameter(command, "@username", DbType.String, id);

            return _database.ExecuteNonQuery(command) == 1;
        }
    }
}
