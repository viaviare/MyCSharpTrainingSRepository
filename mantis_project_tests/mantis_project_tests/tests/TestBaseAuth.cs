using NUnit.Framework;

namespace mantis_project_tests
{
	public class TestBaseAuth : TestBase
	{
		[OneTimeSetUp]
		public void SetupLogin()
		{
			app.LoginH.Login(new AccountData()
			{
				Username = "administrator",
				Password = "root"
			});
		}

		[OneTimeTearDown]
		public void TeardownLogout()
		{
			app.LoginH.Logout();
		}
	}
}
