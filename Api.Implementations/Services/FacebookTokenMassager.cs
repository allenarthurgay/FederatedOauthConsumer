using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
    public class FacebookTokenMassager : IAuthProviderTokenMassager
    {
        public ServiceProvider SupportedService
        {
            get
            {
                return new ServiceProvider
                {
                    Name = "Facebook"
                };
            }
        }

        public string NormalizeToken(string serviceAuthToken)
        {
            return serviceAuthToken;
        }
    }
}
