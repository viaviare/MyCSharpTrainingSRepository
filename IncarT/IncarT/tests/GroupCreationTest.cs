using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : TestBaseAuth
	{
		[Test, TestCaseSource ("RandomGroupDataProvider")]
		public void GroupCreationTest(GroupData groupData)
		{

			List<GroupData> oldGroup = app.GroupH.GetGroupList();

			app.GroupH.Create(groupData);

			oldGroup.Add(groupData);

			List<GroupData> newGroup = app.GroupH.GetGroupList();
			oldGroup.Sort();
			newGroup.Sort();
			Assert.AreEqual(oldGroup, newGroup);
		}


		public static IEnumerable<GroupData> RandomGroupDataProvider()
		{
			List<GroupData> group = new List<GroupData>();
			for (int j = 0; j < 3; j++)
			{
				group.Add(new GroupData(GenerateRandomString(10))
				{
					Header = GenerateRandomString(20),
					Footer = GenerateRandomString(20)
				});
			}
			return group;
		}
	}
}
