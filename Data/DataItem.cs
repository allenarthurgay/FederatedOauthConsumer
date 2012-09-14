using System;
using ServiceStack.DataAnnotations;

namespace Data
{
	public class DataItem : IDataItem
	{
        public DataItem()
        {
            UniqueId = Guid.NewGuid();
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
	        Status = 1;
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
