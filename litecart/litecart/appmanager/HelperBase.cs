using OpenQA.Selenium;

namespace litecart
{
	public class HelperBase
	{
		protected ApplicationManager manager;
		protected IWebDriver driver;

		public static bool PERFORM_LOGIN_AGAIN = false;

		public HelperBase(ApplicationManager manager)
		{
			this.manager = manager;
			this.driver = manager.Driver;
		}

		public void Type(By locator, string text)
		{
			driver.FindElement(locator).SendKeys(text);
		}
	}
}
