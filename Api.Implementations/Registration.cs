using Api.Contracts.Services;
using Api.Implementations.Services;
using Core;

namespace Api.Implementations
{
    public class Registration : IFunqRegistrationModule
    {
        public void RegisterDependencies(Funq.Container container)
        {
        	container.Register<IAuthConsumerService>(c => new AuthConsumerService());
        }
    }
}
