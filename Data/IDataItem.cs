using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;

namespace Data
{
    public enum Status
    {
        Active = 1,
        Paused = 2,
        Hidden = 3,
        Deleted = 4,
        Pending = 5,
        Initiated = 6,
        Killed = 7,
        InProgress = 8
    }

    public interface IDataItem
    {

        int Id { get; set; }
        Guid UniqueId { get; set; }
        int Status { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}
