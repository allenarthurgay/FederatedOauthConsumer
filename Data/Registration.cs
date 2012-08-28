using System;
using System.Configuration;
using System.Linq;
using Core;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;


namespace Data
{
    public class Registration: IFunqRegistrationModule
    {
        public void RegisterDependencies(Funq.Container container)
        {
            CreateTablesForTypes();
        }

        public void CreateTablesForTypes()
        {
            var dbFactory = OrmLiteConnectionFactory();
            var allIDataItems = GetAllIDataItems();

            using (var dbConn = dbFactory.OpenDbConnection())
			{
                const bool overwrite = false;
				dbConn.CreateTables(overwrite, allIDataItems);
            }
        }

        //in case we need to drop them for testing 
        public void DropTables()
        {
            var dbFactory = OrmLiteConnectionFactory();
            using (var dbConn = dbFactory.OpenDbConnection())
            {
				dbConn.DropTable<AuthenticationProvider>();
            }
        }

        private Type[] GetAllIDataItems()
        {
            var type = typeof(IDataItem);
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(c=> c.IsClass && type.IsAssignableFrom(c));
            return types.ToArray();
        }


        internal static OrmLiteConnectionFactory OrmLiteConnectionFactory()
        {
            var setting =
                ConfigurationManager.ConnectionStrings[
                    DataConnectionProvider.Connectionstring].ConnectionString;

            var dbFactory = new OrmLiteConnectionFactory(
                setting,
                SqlServerOrmLiteDialectProvider.Instance);
            return dbFactory;
        }
    }
}
