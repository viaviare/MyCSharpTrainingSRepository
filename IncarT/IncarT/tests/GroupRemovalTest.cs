using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupRemovalTests : TestBaseAuth
	{

		[Test]
		public void GroupRemovalTest()
		{
			GroupData tempData = new GroupData("zz");
			int index = 0;

			if (app.GroupH.CountGroupItems()==0)
			{
				app.GroupH.Create(tempData);
			}

			List<GroupData> oldGroup = app.GroupH.GetGroupList();

			app.GroupH.Remove(index);

			GroupData removedGroup = oldGroup[index];
			oldGroup.RemoveAt(index);
			List<GroupData> newGroup = app.GroupH.GetGroupList();
			oldGroup.Sort();
			newGroup.Sort();
			Assert.AreEqual(oldGroup, newGroup);

			foreach (GroupData currentGroup in newGroup)
			{
				Assert.AreNotEqual(currentGroup.Id, removedGroup.Id);
			}
			
		}
	}
}

