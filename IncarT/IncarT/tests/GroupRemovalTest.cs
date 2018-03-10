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
			if (app.GroupH.CountGroupItems() > 1)
			{
				List<GroupData> oldGroup = app.GroupH.GetGroupList();

				app.GroupH.Remove(index);

				oldGroup.RemoveAt(index);
				List<GroupData> newGroup = app.GroupH.GetGroupList();
				oldGroup.Sort();
				newGroup.Sort();
				Assert.AreEqual(oldGroup, newGroup);
			}
			else
			{
				app.GroupH.Remove(0);
			}
			
		}
	}
}

