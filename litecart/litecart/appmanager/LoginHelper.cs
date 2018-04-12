using OpenQA.Selenium;

namespace litecart
{
	public class LoginHelper : HelperBase
	{
		public LoginHelper(ApplicationManager manager) : base(manager)
		{
		}

		public void Login(AccountData account)
		{
			if (LoggedIn())
			{
				if (PERFORM_LOGIN_AGAIN)
				{
					Logout();
				}
				else
				{
					return;
				}
			}
			Type(By.CssSelector("input[name='username']"), account.UserName);
			Type(By.CssSelector("input[name='password']"), account.Password);
			driver.FindElement(By.CssSelector("button[type='submit']")).Click();
		}

		public void Logout()
		{
			driver.FindElement(By.CssSelector("a[title='Logout']")).Click();
		}

		private bool LoggedIn()
		{
			return driver.FindElements(By.CssSelector("div#box-apps-menu-wrapper")).Count > 0;
		}
	}
}