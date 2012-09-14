using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Dto;
using ServiceStack.FluentValidation;

namespace Api.RestHandlers.Validators
{
	public class GetSupportedServicesRequestValidator : AbstractValidator<GetSupportedServicesRequest>
	{
		public IApplicationRequestValidator ApplicationRequestValidator { get; set; }

		public GetSupportedServicesRequestValidator()
		{
			RuleFor(msg => msg).Must(x => ApplicationRequestValidator.ValidApplicationRequest(x));
		}
	}
}
