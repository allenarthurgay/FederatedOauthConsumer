namespace Api.RestServiceHost.Contracts
{
	public class CreateGroupRequest
	{
		public string ProjectId { get; set; }
		public string Name { get; set; }

	    public string PrincipalId { get; set; }
	}
}