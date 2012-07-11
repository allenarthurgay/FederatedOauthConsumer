using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
    public class AuthTokenMassagerServiceFactory : IAuthTokenMassagerServiceFactory
    {
        private readonly List<IAuthProviderTokenMassager> _tokenMassagers;

        public AuthTokenMassagerServiceFactory(IEnumerable<IAuthProviderTokenMassager> tokenMassagers)
        {
            _tokenMassagers = tokenMassagers.ToList();
        }

        public IAuthProviderTokenMassager GetMassagerForService(ServiceProvider serviceProvider)
        {
            return
                _tokenMassagers.FirstOrDefault(
                    c =>
                    c.SupportedService.Name.ToLower()==serviceProvider.Name.ToLower());
        }
    }
}
