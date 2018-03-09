using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressBookTests
{
	public class ApplicationManager
	{
		private IWebDriver driver;
		private string baseURL;

		protected LoginHelper loginH;
		protected GroupHelper groupH;
		protected NavigationHelper navigatorH;
		protected ContactHelper contactH;

		public ApplicationManager()
		{
			driver = new ChromeDriver();
			baseURL = "http://localhost";

			loginH = new LoginHelper(this);
			groupH = new GroupHelper(this);
			navigatorH = new NavigationHelper(this, baseURL);
			contactH = new ContactHelper(this);
		}

		public void Stop()
		{
			try
			{
				driver.Quit();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
		}

		public LoginHelper LoginH
		{
			get { return loginH; }
		}
		public GroupHelper GroupH
		{
			get { return groupH; }
		}
		public ContactHelper ContactH
		{
			get { return contactH; }
		}
		public NavigationHelper NavigatorH
		{
			get { return navigatorH; }
		}

		public IWebDriver Driver
		{
			get { return driver; }
		}
	}
}
