using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	class GroupModificationTests : TestBaseAuth
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData newData = new GroupData("o", "l", "x");

			app.GroupH.Modify(0, newData);
		}
	}
}
