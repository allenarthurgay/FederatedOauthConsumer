using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
    public class TwitterServiceProviderHtmlService : IServiceProviderHtmlService
    {
        public ServiceProvider SupportedService
        {
            get
            {
                return new ServiceProvider
                {
                    Name = "twitter"
                };
            }
        }

        public string GetHtmlForService(ServiceProvider provider)
        {
            return @"<img src=""https://si0.twimg.com/images/dev/buttons/sign-in-with-twitter-d.png"" />";
        }
    }
}
