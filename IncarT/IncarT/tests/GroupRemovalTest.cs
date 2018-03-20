using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupRemovalTests : GroupTestBase
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

			List<GroupData> oldGroup = GroupData.GetAll();
			GroupData removedGroup = oldGroup[index];

			app.GroupH.Remove(removedGroup);

			
			oldGroup.RemoveAt(index);
			List<GroupData> newGroup = GroupData.GetAll();
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

