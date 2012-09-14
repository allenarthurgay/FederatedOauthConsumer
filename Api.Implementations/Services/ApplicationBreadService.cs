using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.DTO;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
	public class ApplicationBreadService : IApplicationBreadService
	{
		private readonly IAccountApplicationRepository _accountApplicationRepository;
		private readonly IApplicationRepository _applicationRepository;

		public ApplicationBreadService(IAccountApplicationRepository accountApplicationRepository)
		{
			_accountApplicationRepository = accountApplicationRepository;
		}

		public Application GetApplication(GetApplicationRequest request)
		{
			return request.Application;
		}

		public Application RegisterApplicationForAccount(AddApplicationRequest request)
		{
			throw new NotImplementedException();
		}

		public ApplicationService RegisterServiceForApplication(AddApplicationServiceRequest request)
		{
			throw new NotImplementedException();
		}

		public EnumerableResponse<ApplicationService> BrowseServicesForApplication(BrowseApplicationServicesRequest request)
		{
			throw new NotImplementedException();
		}

		public EnumerableResponse<Application> BrowseApplications(BrowseApplicationsRequest request)
		{
			throw new NotImplementedException();
		}

		public void DeleteApplication(DeleteApplicationRequest request)
		{
			throw new NotImplementedException();
		}

		public void DeleteApplicationService(DeleteApplicationServiceRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
