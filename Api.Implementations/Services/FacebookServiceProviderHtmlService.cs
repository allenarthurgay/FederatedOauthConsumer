using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
	public class FacebookServiceProviderHtmlService : IServiceProviderHtmlService
	{
		public ServiceProvider SupportedService
		{
			get
			{
				return new ServiceProvider
				{
					Name = "Facebook"
				};
			}
		}

		public string GetHtmlForService(ServiceProvider provider)
		{
			return
@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">
<html>
	<head>
		<title></title>
	</head>
	<body>
	ioioiio
	</body>
</html>";
		}
	}
}
