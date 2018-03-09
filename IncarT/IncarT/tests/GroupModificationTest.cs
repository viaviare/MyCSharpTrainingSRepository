using NUnit.Framework;

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

			if (!app.GroupH.CheckGroupPresents())
			{
				app.GroupH.Create(tempData);
			}
			app.GroupH.Modify(0, newData);
		}
	}
}
