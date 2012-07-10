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
			using (var dbCmd = dbConn.CreateCommand())
			{
				return dbCmd.Select<T>();
			}
		}

		public IDataItem GetById(int id)
		{
			using (var dbConn = DbFactory.OpenDbConnection())
			using (var dbCmd = dbConn.CreateCommand())
			{
				return dbCmd.GetById<T>(id);
			}
		}

		// Todo: Add 'UpdatedBy'
		public void Add(T itemToAdd)
		{
			using (var dbConn = DbFactory.OpenDbConnection())
			using (var dbCmd = dbConn.CreateCommand())
			{
				itemToAdd.Created = itemToAdd.Updated = DateTime.Now;
				dbCmd.Insert(itemToAdd);
			}
		}
	}
}