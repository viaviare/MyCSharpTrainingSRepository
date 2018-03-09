using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressBookTests
{
	public class TestBase
	{
		protected ApplicationManager app;

		[SetUp]
		public void SetupTest()
		{
			app = new ApplicationManager();

			app.NavigatorH.OpenStartPage();
			app.LoginH.Login(new AccountData("admin", "secret"));

		}

		[TearDown]
		public void TeardownTest()
		{
			app.LoginH.Logout();

			app.Stop();
		}

	}
}

