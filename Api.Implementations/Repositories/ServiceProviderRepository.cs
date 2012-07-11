using Api.Contracts.Repositories;
using Core;
using Data;

namespace Api.Implementations.Repositories
{
	public class ServiceProviderRepository : BaseDataItemRepository<ServiceProvider>, IServiceProviderRepository
	{
	    public ServiceProviderRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
	    {
	    }
	}
}
