using System;
using System.Data;

namespace Core
{
    public interface IDataConnectionProvider
    {
        IDbConnection OpenConnection();

        void TransactionWithCommand(Action<IDbCommand> commandAction);

        void WithCommand(Action<IDbCommand> commandAction);

        T ExecuteQuery<T>(Func<IDbCommand, T> commandAction);

        T Single<T>(string name, string value) where T : new();

        long LastInsertedId();
    }
}