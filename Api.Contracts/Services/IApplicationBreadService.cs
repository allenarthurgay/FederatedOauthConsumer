using Api.Contracts.DTO;
using Data;

namespace Api.Contracts.Services
{
	public interface IApplicationBreadService
	{
		Application GetApplication(GetApplicationRequest request);

		Application RegisterApplicationForAccount(AddApplicationRequest request);

		ApplicationService RegisterServiceForApplication(AddApplicationServiceRequest request);

		EnumerableResponse<ApplicationService> BrowseServicesForApplication(BrowseApplicationServicesRequest request);

		EnumerableResponse<Application> BrowseApplications(BrowseApplicationsRequest request);

		void DeleteApplication(DeleteApplicationRequest request);

		void DeleteApplicationService(DeleteApplicationServiceRequest request);
	}
}
