using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class DeleteApplicationServiceRequest : ApplicationRequest
	{
		public string Id { get; set; }
	}
}