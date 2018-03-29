using OpenQA.Selenium;

namespace mantis_project_tests
{
	public class LoginHelper : HelperBase
	{

		public LoginHelper(ApplicationManager manager) : base(manager)
		{ }

		public void Login(AccountData account)
		{
			if (LoggedIn())
			{
				if (LoggedIn(account))
				{
					return;
				}
				Logout();
			}

			Type(By.Name("username"), account.Username);
			manager.NavigatorH.LoginSubmitButton();
			Type(By.Name("password"), account.Password);
			manager.NavigatorH.LoginSubmitButton();

		}

		public void Logout() 
		{
			driver.FindElement(By.CssSelector("span.user-info")).Click();
			driver.FindElement(By.CssSelector("a[href='/mantisbt-2.12.0/logout_page.php']")).Click();
		}



		private bool LoggedIn()
		{
			return IsElementPresent(By.CssSelector("span.user-info")); //By.CssSelector("div#navbar")
		}

		private bool LoggedIn(AccountData account)
		{
			return LoggedIn() &&
				driver.FindElement(By.CssSelector("span.user-info")).Text
				== account.Username;
		}
	}
}
