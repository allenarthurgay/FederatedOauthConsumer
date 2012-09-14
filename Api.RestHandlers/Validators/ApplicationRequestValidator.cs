using Api.Contracts.Dto;

namespace Api.RestHandlers.Validators
{
	public interface IApplicationRequestValidator
	{
		bool ValidApplicationRequest(ApplicationRequest request);
	}

	public class ApplicationRequestValidator: IApplicationRequestValidator
	{
		public bool ValidApplicationRequest(ApplicationRequest request)
		{
			return !string.IsNullOrEmpty(request.AppKey) && !string.IsNullOrEmpty(request.AppSecret);
		}
	}
}
