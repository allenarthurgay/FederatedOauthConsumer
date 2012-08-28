using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class AddApplicationServiceRequest : ApplicationRequest
	{
		public string Id { get; set; }

		public int ServiceProviderId { get; set; }
	}
}