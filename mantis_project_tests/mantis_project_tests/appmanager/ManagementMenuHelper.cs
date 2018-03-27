using OpenQA.Selenium;

namespace mantis_projects_tests
{
	public class ManagementMenuHelper : HelperBase
	{
		public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }


		public void GetManagePage()
		{
			driver.FindElement(By.CssSelector("a[href='/mantisbt-2.12.0/manage_overview_page.php']")).Click();
		}

		public void GetProjectsPage()
		{
			driver.FindElement(By.CssSelector("a[href='/mantisbt-2.12.0/manage_proj_page.php']")).Click();
		}
	}
}
