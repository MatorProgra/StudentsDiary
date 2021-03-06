using System.Collections.Generic;

namespace StudentsDiary
{
	class GroupsHelper
	{
		public static List<Group> GetGroups(string defaultGroup)
		{
			return new List<Group>
			{
				new Group {Id = 0, Name = defaultGroup},
				new Group {Id = 1, Name = "1A"},
				new Group {Id = 2, Name = "1B"},
				new Group {Id = 3, Name = "2A"},
				new Group {Id = 4, Name = "2B"},
				new Group {Id = 5, Name = "3A"},
				new Group {Id = 6, Name = "3B"},
			};
		}
	}
}
