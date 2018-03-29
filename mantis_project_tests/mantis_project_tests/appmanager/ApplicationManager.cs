using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace mantis_project_tests
{
	public class ApplicationManager
	{
		private IWebDriver driver;

		public LoginHelper LoginH { get; private set; }
		public ManagementMenuHelper ManagManuH { get; private set; }
		public ProjectManagementHelper ProjectManagH { get; private set; }
		public NavigationHelper NavigatorH { get; private set; }
		public APIHelper ApiH { get; private set; }

		private string baseURL;


		public static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

		private ApplicationManager()
		{
			driver = new ChromeDriver();
			baseURL = "http://localhost/mantisbt-2.12.0";

			LoginH = new LoginHelper(this);
			ManagManuH = new ManagementMenuHelper(this);
			ProjectManagH = new ProjectManagementHelper(this);
			NavigatorH = new NavigationHelper(this, baseURL);
			ApiH = new APIHelper(this);
		}

		public static ApplicationManager GetInstance()
		{
			if (!app.IsValueCreated)
			{
				ApplicationManager instance = new ApplicationManager();
				instance.driver.Url = "http://localhost/mantisbt-2.12.0/login_page.php";
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
			{
				// Ignore errors if unable to close the browser
			}
		}

		public IWebDriver Driver
		{
			get { return driver; }
		}

	}
}

