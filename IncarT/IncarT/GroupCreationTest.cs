using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : TestBase
	{
		[Test]
		public void GroupCreationTest()
		{
			OpenStartPage();
			Login(new AccountData("admin", "secret"));
			OpenGroupPage();
			InitNewGroup();
			FillGroupFields(new GroupData("lili", "oror", "nene"));
			SubmitGroupFields();
			ReturnGroupPage();
			Logout();
		}
	}
}
