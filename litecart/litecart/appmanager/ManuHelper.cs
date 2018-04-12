using OpenQA.Selenium;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace litecart
{
	public class ManuHelper : HelperBase
	{
		public ManuHelper(ApplicationManager manager) : base(manager) { }



		public void CheckMainMenu()
		{
			ReadOnlyCollection<IWebElement> menuItems = GetMainManu();
			int countM = menuItems.Count;
			for (int i = 0; i < countM; i++)
			{
				menuItems = GetMainManu();
				menuItems[i].Click();
				if (!SubMenu())
				{
					CheckTag();
				}
				else
				{
					ReadOnlyCollection<IWebElement> subMenuItems = GetSubManu();
					int countS = GetSubManu().Count;
					for (int j=0; j< countS; j++)
					{
						subMenuItems = GetSubManu();
						subMenuItems[j].Click();
						CheckTag();
					}
				}
			}
		}

		private void CheckTag()
		{
			Assert.IsNotNull(driver.FindElement(By.CssSelector("h1")));
		}

		private bool SubMenu()
		{
			return driver.FindElements(By.CssSelector("ul.docs")).Count>0;
		}

		private ReadOnlyCollection<IWebElement> GetMainManu()
		{
			return driver.FindElements(By.CssSelector("ul#box-apps-menu li#app-"));
		}

		private ReadOnlyCollection<IWebElement> GetSubManu()
		{
			return driver.FindElements(By.CssSelector("ul.docs li"));
		}


	}
}
