using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;

namespace Data
{
	public class DataItemRepository<T> : IDataItemRepository where T : IDataItem, new()
	{
		protected OrmLiteConnectionFactory DbFactory = Registration.OrmLiteConnectionFactory();

		public IEnumerable<T> GetAll()
		{
			using (var dbConn = DbFactory.OpenDbConnection())
			{
				return dbConn.Select<T>();
			}
		}

		public IDataItem GetById(int id)
		{
			using (var dbConn = DbFactory.OpenDbConnection())
			{
				return dbConn.GetById<T>(id);
			}
		}

		// Todo: Add 'UpdatedBy'
		public void Add(T itemToAdd)
		{
			using (var dbConn = DbFactory.OpenDbConnection())
			{
				itemToAdd.Created = itemToAdd.Updated = DateTime.Now;
				dbConn.Insert(itemToAdd);
			}
		}
	}
}