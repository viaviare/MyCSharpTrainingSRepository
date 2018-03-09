using OpenQA.Selenium;

namespace WebAddressBookTests
{
	public class NavigationHelper : HelperBase
	{
		private string baseURL;

		public NavigationHelper(ApplicationManager manager, string baseURL): base(manager)
		{
			this.baseURL = baseURL;
		}

		public bool CheckAddressLocator(string address, By locator)
		{
			return driver.Url == baseURL + address && IsElementPresent(locator);
		}

		public void OpenGroupPage()
		{
			if (CheckAddressLocator("/addressbook/group.php", By.Name("edit")))
			{
				return;
			}
			driver.FindElement(By.LinkText("groups")).Click();
		}

		public void OpenMainPage()
		{
			if (CheckAddressLocator("/addressbook/", By.LinkText("Logout")))
			{
				return;
			}
			driver.FindElement(By.LinkText("home")).Click();
		}

		public void OpenStartPage()
		{
			driver.Navigate().GoToUrl(baseURL + "/addressbook/");
		}
	}
}
