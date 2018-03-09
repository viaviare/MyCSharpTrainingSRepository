using OpenQA.Selenium;

namespace WebAddressBookTests
{
	public class HelperBase
	{
		protected ApplicationManager manager;
		protected IWebDriver driver;

		public HelperBase(ApplicationManager manager)
		{
			this.manager = manager;
			this.driver = manager.Driver;
		}

		protected void Type(By Locator, string test)
		{
			driver.FindElement(Locator).Clear();
			driver.FindElement(Locator).SendKeys(test);
		}
	}
}
