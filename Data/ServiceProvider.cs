using System.ComponentModel.DataAnnotations;

namespace Data
{
	public class ServiceProvider : DataItemBase
	{
		// TODO: Give this a UNIQUE constraint
		[StringLength(500)]
		[Required]
		public string Name { get; set; }
	}
}
