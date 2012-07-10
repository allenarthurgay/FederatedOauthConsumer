using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;

namespace Data
{
    public class AuthenticationProvider: IDataItem
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
    }
}
