namespace Api.RestServiceHost.Contracts
{
	public class GetPostsRequest
	{
		public string ProjectId { get; set; }

	    public string PrincipalId
        { get; set; }
    }
}