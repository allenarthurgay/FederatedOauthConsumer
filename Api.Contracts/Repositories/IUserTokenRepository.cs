using System;
using Data;

namespace Api.Contracts.Repositories
{
    public interface IUserTokenRepository: ISimpleDataItemRepository<UserTokenRecord>
    {
        UserTokenRecord GetUserTokenRecord(Guid userId, string serviceType);
    }



}
