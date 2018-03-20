using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	[TestFixture]
	class GroupModificationTests : GroupTestBase
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData tempData = new GroupData("zz", "qq", "aa");
			GroupData newData = new GroupData("o", "l", "x");
			int index = 0;

			if (app.GroupH.CountGroupItems() == 0)
			{				
				app.GroupH.Create(tempData);
			}
			List<GroupData> oldGroup = GroupData.GetAll();
			GroupData modifiedGroup = oldGroup[index];
			modifiedGroup.Name = newData.Name;

			app.GroupH.Modify(modifiedGroup, newData);

			List<GroupData> newGroup = GroupData.GetAll();
			oldGroup.Sort();
			newGroup.Sort();
			Assert.AreEqual(oldGroup, newGroup);

			foreach (GroupData currentGroup in newGroup)
			{
				if (currentGroup.Id == modifiedGroup.Id)
				{
					Assert.AreEqual(newData.Name, currentGroup.Name);
					break;
				}
			}
		}
	}
}
