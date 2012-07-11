using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
	public class UserRecord : DataItemBase
	{
		[StringLength(500)]
		public string ServiceType { get; set; }
	}
}
