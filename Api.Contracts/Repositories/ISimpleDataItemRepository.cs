using System;
using System.Collections.Generic;
using Data;

namespace Api.Contracts.Repositories
{
    public interface ISimpleDataItemRepository<T> where T : IDataItem, new()
    {
        long Add(T dataitem);

        void Edit(T dataitem);

        void Delete(int id);

        T GetById(int id);

        T GetByUniqueId(Guid uniqueId);

        void SetStatus(int id, Status status);

        IEnumerable<T> GetAll();
        
        IEnumerable<T> GetValues(int page, int pagesize);

        IEnumerable<T> GetValues(Status status, int page, int pagesize);
    }
    
}
