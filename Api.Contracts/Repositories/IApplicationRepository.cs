using Data;

namespace Api.Contracts.Repositories
{
	public interface IApplicationRepository : ISimpleDataItemRepository<Application>
	{
		Application FindApplication(string appKey, string appSecret);
	}
}
