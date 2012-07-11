using System.ComponentModel.DataAnnotations;

namespace Data
{
	public class ServiceProvider : DataItemBase
	{
		// TODO: Give this a UNIQUE constraint
		[StringLength(500)]
		[Required]
        [Key]
		public string Name { get; set; }
	}
}
