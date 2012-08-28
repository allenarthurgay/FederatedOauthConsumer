using System;

namespace Api.Contracts.Dto
{
	public class RegisterServiceTokenRequest: ApplicationRequest
	{
		public Guid PrincipalId { get; set; }

		public string Service { get; set; }

		public string Token { get; set; } 
	}
}
