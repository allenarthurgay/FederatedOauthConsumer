using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.RestServiceHost.Contracts;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class CreateGroupHandler : RestServiceBase<CreateGroupRequest>
	{
		public override object OnPost(CreateGroupRequest request)
		{
			return request.ProjectId;
		}
	}
}