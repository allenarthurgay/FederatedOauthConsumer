using System.Configuration;
using Core;
using Funq;
using ServiceStack.ServiceClient.Web;

namespace Api.RestServiceHost.Services
{
    public class Registration : IFunqRegistrationModule
    {
        private readonly string _fastServiceUrlAppKey = "FASTUrl";

        public void RegisterDependencies(Container container)
        {
            container.Register<IAuthenticatedYammerRequestFactory>(c =>
                                                                   new AuthenticatedYammerRequestFactory(
                                                                       c.Resolve<IUserAuthTokenRepository>()));
            container.Register<IUserAuthTokenRepository>(
                c =>
                new FASTUserAuthTokenRepository(new JsonServiceClient(ConfigurationManager.AppSettings[_fastServiceUrlAppKey])));
        }        
    }
}