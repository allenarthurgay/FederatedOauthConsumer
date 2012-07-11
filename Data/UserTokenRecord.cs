using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
	public class UserTokenRecord : DataItemBase
	{
		public Guid UserId { get; set; }
		
		[StringLength(500)]
		public string ServiceType { get; set; }
		
		[StringLength(500)]
		public string Token { get; set; }
	}
}
