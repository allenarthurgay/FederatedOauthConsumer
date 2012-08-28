using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Data
{
	public class Application: DataItem
	{
		[StringLength(500)]
		[Required]
		[Key]
		public string Name { get; set; }

		public string AppKey { get; set; }

		public string AppSecret { get; set; }

		public ulong Options { get; set; }

		[Ignore]
		public List<ApplicationService> Services { get; set; }
	}

	public class ApplicationService:DataItem
	{
		public ServiceProvider Service { get; set; }

		public string ServiceAppKey { get; set; }

		public string ServiceAppSecret { get; set; }

		public ulong Options { get; set; }
	}
}
