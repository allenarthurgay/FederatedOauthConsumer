using System.Linq;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
	public class ApplicationRepository : BaseDataItemRepository<Application>, IApplicationRepository
	{
		public ApplicationRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
		{
		}
		//$TODO: caching
		public Application FindApplication(string appKey, string appSecret)
		{
			return ConnectionProvider.ExecuteQuery(c =>
												c.Where<Application>(new
																			{
																				AppKey = appKey,
																				AppSecret = appSecret
																			}).FirstOrDefault()
												);
		}
	}
}
