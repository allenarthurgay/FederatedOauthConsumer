using System;
using System.Configuration;
using System.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Core
{
    public class DataConnectionProvider : IDataConnectionProvider
    {
        private readonly string _connString;
        private readonly OrmLiteConnectionFactory _dbFactory;

        public DataConnectionProvider(string connectionString)
        {
            _connString = connectionString;

            var setting =
                ConfigurationManager.ConnectionStrings[_connString].ConnectionString;

            _dbFactory = new OrmLiteConnectionFactory(
                setting,
                SqlServerOrmLiteDialectProvider.Instance);
        }

        public IDbConnection OpenConnection()
        {
            return _dbFactory.OpenDbConnection();
        }

		public void TransactionWithCommand(Action<IDbConnection> commandAction)
        {
            using (var dbConn = _dbFactory.OpenDbConnection())            
			using (var trans = dbConn.BeginTransaction())
            {
				commandAction(dbConn);

                trans.Commit();
            }
        }

		public void WithCommand(Action<IDbConnection> commandAction)
        {
            using (var dbConn = _dbFactory.OpenDbConnection())
            {
				commandAction(dbConn);
            }
        }

        public T ExecuteQuery<T>(Func<IDbConnection, T> commandAction)
        {
            T retVal;

            using (var dbConn = _dbFactory.OpenDbConnection())            
            {
				retVal = commandAction(dbConn);
            }
            return retVal;
        }

        public T Single<T>(string name, string value) where T : new()
        {
            T retVal;

            using (var dbConn = _dbFactory.OpenDbConnection())
			using (var dbCmd = dbConn.CreateCommand())
            {
				retVal = dbCmd.SingleWhere<T>(name, value);
            }
            return retVal;
        }

        public long LastInsertedId()
        {
            using (var dbConn = _dbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            {
                return dbCmd.GetLastInsertId();
            }
        }

        public readonly static string Connectionstring = "DataLayer.Properties.Settings.ProductionConnectionString";
    }
}
