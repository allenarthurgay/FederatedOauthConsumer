using System.ComponentModel.DataAnnotations;

namespace Data
{
	public class ServiceProvider : DataItemBase
	{
		[StringLength(500)]
		[Required]
		[Key]
		public string Name { get; set; }
	}
}
