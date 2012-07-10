using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Api.Contracts.dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	public class IsRegisteredForServiceHandler : RestServiceBase<IsRegisteredForServiceRequest>
	{
		private readonly IAuthConsumerService _service;

		public IsRegisteredForServiceHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnGet(IsRegisteredForServiceRequest request)
		{
			return _service.IsRegisteredForService(request);
		}
	}
}
