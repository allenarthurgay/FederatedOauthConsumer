using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Data
{
	public class Account: DataItem
	{
		[StringLength(500)]
		[Required]
		[Key]
		public string Name { get; set; }

		public ulong Options { get; set; }

		[Ignore]
		public List<User> Users { get; set; }

		[Ignore]
		public List<Application> Applications { get; set; } 
	}

	public class User:DataItem
	{
		[StringLength(500)]
		public string Name { get; set; }

		[StringLength(500)]
		public string Email { get; set; }

		[StringLength(500)]
		public string Alias { get; set; }
		
		[StringLength(500)]
		public string Password { get; set; }

		public DateTime LastLogin { get; set; }

		public ulong Options { get; set; }
	}

	public class AccountUser:DataItem
	{
		public int AccountId { get; set; }

		public int UserId { get; set; }

		public ulong Options { get; set; }
	}

	public class AccountApplication : DataItem
	{
		public int AccountId { get; set; }

		public int ApplicationId { get; set; }

		public ulong Options { get; set; }
	}
}
