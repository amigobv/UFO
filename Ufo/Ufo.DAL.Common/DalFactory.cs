using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common
{
    public class DalFactory
    {
        private static string assemblyName;
        private static Assembly dalAssembly;

        static DalFactory()
        {
            assemblyName = ConfigurationManager.AppSettings["DalAssembly"];
            dalAssembly = Assembly.Load(assemblyName);
        }

        public static IDatabase CreateDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            return CreateDatabase(connectionString);
        }

        public static IDatabase CreateDatabase(string connectionString)
        {
            string databaseClassName = assemblyName + ".Database";
            Type dbClass = dalAssembly.GetType(databaseClassName);

            return Activator.CreateInstance(dbClass, new object[] { connectionString }) as IDatabase;
        }

        public static IArtistDao CreateArtistDao(IDatabase database)
        {
            return CreateDao<IArtistDao>(database, "ArtistDao");
        }

        public static ICategoryDao CreateCategoryDao(IDatabase database)
        {
            return CreateDao<ICategoryDao>(database, "CategoryDao");
        }

        public static ILocationDao CreateLocationDao(IDatabase database)
        {
            return CreateDao<ILocationDao>(database, "LocationDao");
        }

        public static IVenueDao CreateVenueDao(IDatabase database)
        {
            return CreateDao<IVenueDao>(database, "VenueDao");
        }

        public static IUserDao CreateUserDao(IDatabase database)
        {
            return CreateDao<IUserDao>(database, "UserDao");
        }

        public static IRestrictionDao CreateRestrictionDao(IDatabase database)
        {
            return CreateDao<IRestrictionDao>(database, "RestrictionDao");
        }

        public static IPerformanceDao CreatePerformanceDao(IDatabase database)
        {
            return CreateDao<IPerformanceDao>(database, "PerformanceDao");
        }

        private static TInterface CreateDao<TInterface>(IDatabase database, string typeName)
        {
            Type daoType = dalAssembly.GetType(assemblyName + ".Dao." + typeName);
            return (TInterface)Activator.CreateInstance(daoType, new object[] { database });
        }
    }
}
