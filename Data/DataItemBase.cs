using System;
using ServiceStack.DataAnnotations;

namespace Data
{
	public class DataItemBase : IDataItem
	{
        public DataItemBase()
        {
            UniqueId = Guid.NewGuid();
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }
		[AutoIncrement]
		[PrimaryKey]
		public int Id { get; set; }
		public Guid UniqueId { get; set; }
		public int Status { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
	}
}
