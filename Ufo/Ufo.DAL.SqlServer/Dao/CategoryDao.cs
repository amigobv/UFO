using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ufo.DAL.Common;
using Ufo.Domain;

namespace Ufo.DAL.SqlServer.Dao
{
    public class CategoryDao : ICategoryDao
    {
        private const string SQL_COUNT =
            @"Select COUNT(idCategory) FROM Category";

        private const string SQL_FIND_BY_ID =
            @"SELECT * " +
            @"FROM Category " +
            @"WHERE idCategory = @id";

        private const string SQL_FIND_ALL =
            @"SELECT * FROM Category " +
            @"ORDER BY label";

        private const string SQL_INSERT =
            @"INSERT INTO Category " +
            @"VALUES (@id, @label)";

        private const string SQL_UPDATE =
            @"UPDATE Category " +
            @"SET label = @label " +
            @"WHERE idCategory = @id";

        private const string SQL_DELETE = @"DELETE FROM Category WHERE idCategory = @id";

        private IDatabase _database;

        public CategoryDao(IDatabase database)
        {
            _database = database;
        }

        public int Count()
        {
            var command = _database.CreateCommand(SQL_COUNT);

            return (int)_database.ExecuteScalar(command);
        }

        public IList<Category> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var categories = new List<Category>();

                while (reader.Read())
                {
                    categories.Add(new Category((string)reader["idCategory"], (string)reader["label"]));   
                }

                return categories;
            }
        }

        public Category FindById(string id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    return new Category((string)reader["idCategory"], (string)reader["label"]);  
                }

                return null;
            }
        }

        public bool Insert(Category o)
        {
            if (o == null ||
                o.Id == null ||
                o.Label == null)
                return false;

            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@id", DbType.String, o.Id);
            _database.DefineParameter(command, "@label", DbType.String, o.Label);
            

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Update(Category o)
        {
            if (o == null ||
                o.Id == null ||
                o.Label == null)
                return false;

            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.String, o.Id);
            _database.DefineParameter(command, "@label", DbType.String, o.Label);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(string id)
        {
            if (id == null)
                return false;

            var command = _database.CreateCommand(SQL_DELETE);
            _database.DefineParameter(command, "@id", DbType.String, id);

            return _database.ExecuteNonQuery(command) == 1;
        }
    }
}
