using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Api.Contracts.dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	public class GetSupportedServicesHandler : RestServiceBase<GetSupportedServicesRequest>
	{
		private readonly IAuthConsumerService _service;

		public GetSupportedServicesHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnGet(GetSupportedServicesRequest request)
		{
			return _service.GetSupportedServices(request);
		}
	}
}
