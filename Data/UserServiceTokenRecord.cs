using System;
using ServiceStack.DataAnnotations;

namespace Data
{
    public class UserServiceTokenRecord : DataItemBase
    {
        [References(typeof(UserTokenRecord))]
        public Guid Uid { get; set; }

        [References(typeof(ServiceProvider))]
        public Guid Sid { get; set; }

        public string Token { get; set; }
    }
}