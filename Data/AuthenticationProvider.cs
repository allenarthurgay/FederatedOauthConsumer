using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class AuthenticationProvider: DataItemBase
    {
        [StringLength(500)]
        public string Name { get; set; }

    }
}
