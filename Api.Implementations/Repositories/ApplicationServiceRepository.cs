using Api.Contracts.Repositories;
using Core;
using Data;

namespace Api.Implementations.Repositories
{
	public class ApplicationServiceRepository : BaseDataItemRepository<ApplicationService>, IApplicationServiceRepository
	{
		public ApplicationServiceRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
		{
		}
	}
}
