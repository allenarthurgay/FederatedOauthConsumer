using Data;

namespace Api.Contracts.Repositories
{
    public interface IServiceProviderRepository: ISimpleDataItemRepository<ServiceProvider>
    {
        ServiceProvider GetByServiceName(string service);
    }
}
