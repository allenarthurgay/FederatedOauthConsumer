using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Data
{
	public class ServiceProvider : DataItemBase
	{
		[StringLength(500)]
		[Required]
        [Key]
		public string Name { get; set; }

        [Required]
        public string ConsumerKey { get; set; }

        [Required]
        public string ConsumerSecret { get; set; }
	}
}
