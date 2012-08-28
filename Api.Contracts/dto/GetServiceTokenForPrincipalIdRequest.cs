using System;
using Data;

namespace Api.Contracts.Dto
{
	public class GetServiceTokenForPrincipalIdRequest : ApplicationRequest
	{
		public Guid PrincipalId { get; set; }

		public string Service { get; set; }
	}
}
