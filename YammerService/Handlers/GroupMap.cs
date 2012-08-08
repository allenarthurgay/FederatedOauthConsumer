using System.Collections.Generic;

namespace Api.RestServiceHost.Handlers
{
	public static class GroupMap
	{
		private static Dictionary<string, string> Map;

		public static string GetGroupId(string projectId)
		{
			//return Map[projectId];
			return "866627";

		}
	
		public static void AddGroupId(string groupId, string projectId)
		{
			if(Map == null)
			{
				Map = new Dictionary<string, string>();
			}
			Map[projectId] = groupId;
		}
	}
}