using System;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
	public class LoginHelper: HelperBase
	{

		public LoginHelper(ApplicationManager manager) : base(manager)
		{}

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
			Type(By.Name("user"), account.Username);
			Type(By.Name("pass"), account.Password);
			driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
		}

		private bool LoggedIn()
		{
			return IsElementPresent(By.LinkText("Logout"));
		}

		private bool LoggedIn(AccountData account)
		{
			return LoggedIn() &&
				driver.FindElement(By.CssSelector("form[name='logout'] b")).Text 
				== "(" + account.Username + ")";
		}

		public void Logout()
		{
			driver.FindElement(By.LinkText("Logout")).Click();
		}
	}
}
