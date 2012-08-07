using System;

namespace Api.Contracts.dto
{
	public class GetRegistrationHtmlRequest
	{
		public Guid PrincipalId { get; set; }
		public string Service { get; set; }
	}



}
