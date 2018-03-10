using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	[TestFixture]
	class GroupModificationTests : TestBaseAuth
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData tempData = new GroupData("zz");
			GroupData newData = new GroupData("o", "l", "x");
			int index = 0;

			if (app.ContactH.CountContactItems() == 0)
			{				
				app.GroupH.Create(tempData);
			}
			List<GroupData> oldGroup = app.GroupH.GetGroupList();

			app.GroupH.Modify(index, newData);

			oldGroup[index].Name = newData.Name;

			List<GroupData> newGroup = app.GroupH.GetGroupList();
			oldGroup.Sort();
			newGroup.Sort();
			Assert.AreEqual(oldGroup, newGroup);
		}
	}
}
