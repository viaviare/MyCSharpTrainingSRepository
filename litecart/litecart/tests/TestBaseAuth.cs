using NUnit.Framework;

namespace litecart
{
	public class TestBaseAuth : TestBase
	{
		[SetUp]
		public void SetUpLogin()
		{
			app.LoginH.Login(new AccountData("admin", "admin"));
		}

		[TearDown]
		public void TearDownLogout()
		{
			app.LoginH.Logout();
		}
	}
}
