using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class AddApplicationRequest : ApplicationRequest
	{
		public string Name { get; set; }
	}
}