﻿using OpenQA.Selenium;

namespace WebAddressBookTests
{
	public class LoginHelper: HelperBase
	{

		public LoginHelper(ApplicationManager manager) : base(manager)
		{}

		public void Login(AccountData account)
		{
			Type(By.Name("user"), account.Username);
			Type(By.Name("pass"), account.Password);
			driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
		}

		public void Logout()
		{
			driver.FindElement(By.LinkText("Logout")).Click();
		}
	}
}
