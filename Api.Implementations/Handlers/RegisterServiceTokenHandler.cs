using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Api.Contracts.dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	public class RegisterServiceTokenHandler : RestServiceBase<RegisterServiceTokenRequest>
	{
		private readonly IAuthConsumerService _service;

		public RegisterServiceTokenHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnPut(RegisterServiceTokenRequest request)
		{
			_service.RegisterServiceToken(request);
			return null;
		}
	}
}
