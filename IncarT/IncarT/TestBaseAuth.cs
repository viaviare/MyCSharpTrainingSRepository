using NUnit.Framework;

namespace WebAddressBookTests
{
	public class TestBaseAuth : TestBase
	{
		[SetUp]
		public void SetupLogin()
		{
			app.LoginH.Login(new AccountData("admin", "secret"));
		}

		[TearDown]
		public void TeardownLogout()
		{
			app.LoginH.Logout();
		}
	}
}
