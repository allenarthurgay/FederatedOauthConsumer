using System;
using Data;

namespace Api.Contracts.Repositories
{
    public interface IUserServiceTokenRepository: ISimpleDataItemRepository<UserServiceTokenRecord>
    {
        UserServiceTokenRecord GetUserServiceTokenRecord(Guid Uid, Guid Sid);
    }



}
