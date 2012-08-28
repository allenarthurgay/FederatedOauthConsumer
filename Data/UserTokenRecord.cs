using System;

namespace Data
{
	public class UserTokenRecord : DataItem
	{
		public Guid UserId { get; set; }
		
		public int ServiceTypeId { get; set; }
		
		public string Token { get; set; }
	}
}
