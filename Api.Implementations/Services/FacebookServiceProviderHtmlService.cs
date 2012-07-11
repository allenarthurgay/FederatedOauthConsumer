using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
    public class FacebookServiceProviderHtmlService : IServiceProviderHtmlService
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

        public string GetHtmlForService(ServiceProvider provider)
        {
            var file = System.IO.File.ReadAllText("..\templates\facebook.htm");
            return file;
        }
    }
}
