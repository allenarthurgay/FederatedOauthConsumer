using System;

namespace Data
{
	public class UserTokenRecord : DataItemBase
	{
		public Guid UserId { get; set; }
		
		public int ServiceTypeId { get; set; }
		
		public string Token { get; set; }
	}
}
