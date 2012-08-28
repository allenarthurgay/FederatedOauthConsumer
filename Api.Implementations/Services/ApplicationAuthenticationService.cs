using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
	public class ApplicationAuthenticationService : IApplicationAuthenticationService
	{
		private readonly IApplicationRepository _applicationRepository;

		public ApplicationAuthenticationService(IApplicationRepository applicationRepository)
		{
			_applicationRepository = applicationRepository;
		}

		public Application Authenticate(string appKey, string appSecret)
		{
			return _applicationRepository.FindApplication(appKey, appSecret);
		}
	}
}
