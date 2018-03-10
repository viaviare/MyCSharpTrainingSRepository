using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : TestBaseAuth
	{
		[Test]
		public void GroupCreationTest()
		{
			GroupData groupData = new GroupData("lili")
			{
				Header = "oror",
				Footer = "nene"
			};

			List<GroupData> oldGroup = app.GroupH.GetGroupList();

			app.GroupH.Create(groupData);

			oldGroup.Add(groupData);

			List<GroupData> newGroup = app.GroupH.GetGroupList();
			oldGroup.Sort();
			newGroup.Sort();
			Assert.AreEqual(oldGroup, newGroup);
		}
	}
}
