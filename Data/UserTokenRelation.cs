using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;

namespace Data
{
    class UserTokenRelation : DataItemBase
    {
        [References(typeof(UserRecord))]
        public int Uid { get; set; }

        [References(typeof(ServiceProvider))]
        public int Sid { get; set; }

        public string Token { get; set; }
        public string TimeoutDate { get; set; }
    }
}
