using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace litecart
{
	public class ApplicationManager
	{
		private IWebDriver driver;
		private string baseURL;
		private NavigationHelper navigatorH;
		private LoginHelper loginH;
		private ManuHelper manuH;


		public static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

		private ApplicationManager()
		{
			driver = new ChromeDriver();
			baseURL = "http://localhost/litecart/admin";

			navigatorH = new NavigationHelper(this, baseURL);
			loginH = new LoginHelper(this);
			manuH = new ManuHelper(this);
		}

		public static ApplicationManager GetInstance()
		{
			if (! app.IsValueCreated)
			{
				ApplicationManager instance = new ApplicationManager();
				instance.NavigatorH.OpenStartPage();
				app.Value = instance;
			}
			return app.Value;
		}

		~ApplicationManager()
		{
			try
			{
				driver.Quit();
			}
			catch (Exception)
			{ }
		}


		public NavigationHelper NavigatorH
		{
			get { return navigatorH; }
		}

		public LoginHelper LoginH
		{
			get { return loginH; }
		}

		public ManuHelper ManuH
		{
			get { return manuH; }
		}


		public IWebDriver Driver
		{
			get { return driver; }
		}
	}
}
