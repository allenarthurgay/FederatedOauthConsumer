using System;
using System.Data;

namespace Core
{
    public interface IDataConnectionProvider
    {
        IDbConnection OpenConnection();

		void TransactionWithCommand(Action<IDbConnection> commandAction);

		void WithCommand(Action<IDbConnection> commandAction);

		T ExecuteQuery<T>(Func<IDbConnection, T> commandAction);

        T Single<T>(string name, string value) where T : new();

        long LastInsertedId();
    }
}