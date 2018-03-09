using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : TestBase
	{
		[Test]
		public void GroupCreationTest()
		{
			GroupData groupData = new GroupData("lili")
			{
				Header = "oror",
				Footer = "nene"
			};

			app.GroupH.Create(groupData);
		}
	}
}
