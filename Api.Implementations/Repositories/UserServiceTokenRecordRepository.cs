using System;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
    public class UserServiceTokenRecordRepository : BaseDataItemRepository<UserServiceTokenRecord>, IUserServiceTokenRepository
    {
        public UserServiceTokenRecordRepository(IDataConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public UserServiceTokenRecord GetUserServiceTokenRecord(Guid uid, Guid sid)
        {
            return ConnectionProvider.ExecuteQuery(cmd =>
                                                   ReadExtensions.FirstOrDefault<UserServiceTokenRecord>(cmd,
                                                                                                         record =>
                                                                                                         record.Uid == uid &&
                                                                                                         record.Sid == sid));
        }
    }
}