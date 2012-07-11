using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Api.Contracts.Services
{
    public interface IAuthTokenMassagerServiceFactory
    {
        IAuthProviderTokenMassager GetMassagerForService(ServiceProvider serviceProvider);
    }
}
