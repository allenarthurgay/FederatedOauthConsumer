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

        public void TransactionWithCommand(Action<IDbCommand> commandAction)
        {
            using (var dbConn = _dbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            using (var trans = dbCmd.BeginTransaction())
            {
                commandAction(dbCmd);

                trans.Commit();
            }
        }

        public void WithCommand(Action<IDbCommand> commandAction)
        {
            using (var dbConn = _dbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            {
                commandAction(dbCmd);
            }
        }

        public T ExecuteQuery<T>(Func<IDbCommand, T> commandAction)
        {
            T retVal;

            using (var dbConn = _dbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            {
                retVal = commandAction(dbCmd);
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
