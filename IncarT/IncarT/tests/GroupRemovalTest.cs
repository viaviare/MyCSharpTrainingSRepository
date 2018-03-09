using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupRemovalTests : TestBaseAuth
	{

		[Test]
		public void GroupRemovalTest()
		{
			GroupData tempData = new GroupData("zz");

			if (!app.GroupH.CheckGroupPresents())
			{
				app.GroupH.Create(tempData);
			}
			app.GroupH.Remove(0);
		}
	}
}

