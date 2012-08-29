using Api.Contracts.Dto;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers
{
	[RequiresAppRegistration(Priority = -1, ApplyTo = ApplyTo.All)]
	public class GetRegistrationHtmlHandler : RestServiceBase<GetRegistrationHtmlRequest>
	{
		private readonly IAuthConsumerService _service;

		public GetRegistrationHtmlHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnGet(GetRegistrationHtmlRequest request)
		{
			return _service.GetRegistrationHtml(request);
		}
	}
}
