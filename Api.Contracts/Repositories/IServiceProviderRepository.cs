using System.Collections.Generic;
using Data;

namespace Api.Contracts.Repositories
{
    public interface IServiceProviderRepository: ISimpleDataItemRepository<ServiceProvider>
    {
        ServiceProvider GetByServiceName(string service);
    	List<string> GetSupportedServices();
    }
}
