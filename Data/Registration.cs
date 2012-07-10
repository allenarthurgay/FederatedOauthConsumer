using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Core;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;


namespace Data
{
    public class Registration: IFunqRegistrationModule
    {
        public readonly static string Connectionstring = "DataLayer.Properties.Settings.ProductionConnectionString";

        public void RegisterDependencies(Funq.Container container)
        {
            CreateTablesForTypes();
        }

        public void CreateTablesForTypes()
        {
            var dbFactory = OrmLiteConnectionFactory();
            var allIDataItems = GetAllIDataItems();

            using (var dbConn = dbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            {
                const bool overwrite = false;
                dbCmd.CreateTables(overwrite, allIDataItems);
            }
        }

        //in case we need to drop them for testing 
        public void DropTables()
        {
            var dbFactory = OrmLiteConnectionFactory();
            using (var dbConn = dbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            {
                dbCmd.DropTable<AuthenticationProvider>();
            }
        }

        private Type[] GetAllIDataItems()
        {
            var type = typeof(IDataItem);
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(type.IsAssignableFrom);
            return types.ToArray();
        }


        private static OrmLiteConnectionFactory OrmLiteConnectionFactory()
        {
            var setting =
                ConfigurationManager.ConnectionStrings[
                    Connectionstring].ConnectionString;

            var dbFactory = new OrmLiteConnectionFactory(
                setting,
                SqlServerOrmLiteDialectProvider.Instance);
            return dbFactory;
        }
    }
}
