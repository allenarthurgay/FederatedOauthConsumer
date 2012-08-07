using Api.Contracts.Services;
using Api.Contracts.dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	class GetRegistrationHtmlHandler : RestServiceBase<GetRegistrationHtmlRequest>
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
