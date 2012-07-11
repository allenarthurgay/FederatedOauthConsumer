using System;
using ServiceStack.DataAnnotations;

namespace Data
{
	public class DataItemBase : IDataItem
	{
		[AutoIncrement]
		[PrimaryKey]
		public int Id { get; set; }
		public Guid UniqueId { get; set; }
		public int Status { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
	}
}
