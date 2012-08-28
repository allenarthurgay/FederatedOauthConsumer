using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class AuthenticationProvider: DataItem
    {
        [StringLength(500)]
        public string Name { get; set; }

    }
}
