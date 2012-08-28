using Api.Contracts.DTO;
using Api.Contracts.Dto;
using ServiceStack.ServiceHost;

namespace Api.Implementations
{
	public static class RestPaths
	{
		public static readonly string SupportedServices = "/supportedservices";

		public static readonly string ReceivedToken = "/{PrincipalId}/{Service}/register/token";

		public static readonly string ReceivedServiceProvider = "/register/serviceprovider";

		public static readonly string RegistrationHtml = "/{PrincipalId}/{Service}/registrationhtml";

		public static readonly string ServiceProviderToken = "/{PrincipalId}/{Service}/token";

		public static readonly string IsRegistered = "/{PrincipalId}/{Service}/isregistered";

		public static readonly string OauthRequestToken = "/{PrincipalId}/{Service}/register/requestoauthtoken";

		public static readonly string Applications = "/applications";

		public static readonly string Application = "/application/{Id}";

		public static readonly string ApplicationServices = "/application/{Id}/services";

		public static readonly string RegisterAccount = "/register/account";

		public static readonly string RegisterUser = "/account/{Id}/register/user";

		public static readonly string AccountUsers = "/account/{Id}/users";

		public static readonly string AccountUser = "/account/{Id}/user/{UserId}";
	}

	public class ApiRegistration
	{
		public static readonly string AppSecretHeader = "Secret";
		public static readonly string AppKeyHeader = "App";

		public static void Register(IServiceRoutes serviceRoutes)
		{
			serviceRoutes
				.Add<GetSupportedServicesRequest>(RestPaths.SupportedServices)
				.Add<GetRegistrationHtmlRequest>(RestPaths.RegistrationHtml)
				.Add<IsRegisteredForServiceRequest>(RestPaths.IsRegistered)
				.Add<GetServiceTokenForPrincipalIdRequest>(RestPaths.ServiceProviderToken)
				.Add<RegisterServiceTokenRequest>(RestPaths.ReceivedToken)
				.Add<RegisterServiceProviderRequest>(RestPaths.ReceivedServiceProvider)
				.Add<BrowseApplicationsRequest>(RestPaths.Applications)
				.Add<GetApplicationRequest>(RestPaths.Application, "GET")
				.Add<AddApplicationRequest>(RestPaths.Application, "PUT")
				.Add<DeleteApplicationRequest>(RestPaths.Application, "DELETE")
				.Add<BrowseApplicationServicesRequest>(RestPaths.ApplicationServices)
				.Add<AddApplicationServiceRequest>(RestPaths.ApplicationServices, "PUT")
				.Add<DeleteApplicationServiceRequest>(RestPaths.ApplicationServices, "DELETE")
				.Add<RegisterAccountRequest>(RestPaths.RegisterAccount, "POST")
				.Add<RegisterAccountUserRequest>(RestPaths.RegisterUser, "POST")
				.Add<BrowseAccountUsersRequest>(RestPaths.AccountUsers, "GET")
				.Add<GetUserRequest>(RestPaths.AccountUser, "GET");
		}
	}
}
