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

		public void OpenMainPage()
		{
			driver.FindElement(By.LinkText("home")).Click();
		}

		public void OpenGroupPage()
		{
			driver.FindElement(By.LinkText("groups")).Click();
		}

		public void OpenStartPage()
		{
			driver.Navigate().GoToUrl(baseURL + "/addressbook/");
		}
	}
}
