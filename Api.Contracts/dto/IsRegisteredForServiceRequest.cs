using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Contracts.Dto
{
	public class IsRegisteredForServiceRequest
	{
		public Guid PrincipalId { get; set; }
		public string Service { get; set; }
	}
}
