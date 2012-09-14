using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
    public abstract class BaseDataItemRepository<T> : ISimpleDataItemRepository<T> where T : class, IDataItem, new()
    {
        protected readonly IDataConnectionProvider ConnectionProvider;

        protected BaseDataItemRepository(IDataConnectionProvider connectionProvider)
        {
            ConnectionProvider = connectionProvider;
        }

        public virtual long Add(T dataitem)
        {
            long retval = 0;
            ConnectionProvider
                           .TransactionWithCommand(cmd =>
                           {
                               retval = AddGlobal(cmd, dataitem);
                               retval = cmd.GetLastInsertId();
                           });
            ConnectionProvider.ExecuteQuery((cmd) => retval = cmd.GetLastInsertId());
            return retval;
        }

        public virtual void Edit(T dataitem)
        {
            ConnectionProvider
                .TransactionWithCommand(cmd =>
                {
                    var item = GetById(dataitem.Id, cmd);
                    if (null == item)
                    {
                        return;
                    }
                    cmd.Update(dataitem);
                });
        }

        public void Delete(int id)
        {
            SetStatus(id, Status.Deleted);
        }


        public T GetByUniqueId(Guid uniqueId)
        {
            return ConnectionProvider
                .ExecuteQuery((cmd) => cmd.Where<T>(new { UniqueId = uniqueId }).FirstOrDefault());
        }

        public void SetStatus(int id, Status status)
        {
            ConnectionProvider
                .TransactionWithCommand(cmd =>
                {
                    var item = GetById(id, cmd);
                    if (null == item)
                    {
                        return;
                    }
                    item.Status = (int)status;
                    cmd.Update(item);
                });
        }

        public IEnumerable<T> GetAll()
        {
            return ConnectionProvider.ExecuteQuery(cmd => cmd.Select<T>());
        }

        public IEnumerable<T> GetValues(int page, int pagesize)
        {
            return ConnectionProvider.ExecuteQuery(cmd => cmd.Select<T>().OrderByDescending(c => c.Created).Skip((page - 1) * pagesize).Take(pagesize));
        }

        public T GetById(int id)
        {
            using (var dbConn = ConnectionProvider.OpenConnection())            
            {
                var items = dbConn.Where<T>(new { Id = id });
                return items.FirstOrDefault();
            }
        }

        public IEnumerable<T> GetValues(Status status, int page, int pagesize)
        {
	        return ConnectionProvider.ExecuteQuery(conn =>
		        {
					var items = conn.Where<T>(new { Status = (int)status });
			        return items.Select(i => i).OrderBy(c => c.Created).Skip((page - 1)*pagesize).Take(pagesize);
		        });
        }

		public static T GetById(int id, IDbConnection cmd = null)
        {
            return cmd.SingleWhere<T>("Id", id);
        }

		protected long AddGlobal(IDbConnection cmd, T dataitem)
        {
            var item = GetById(dataitem.Id, cmd);
            if (item != null)
            {
                item.Status = (int)Status.Active;
                cmd.Update(item);
                return 0;
            }

            cmd.Insert(dataitem);
            var xx = cmd.GetLastInsertId();
            return xx;
        }
    }
}
