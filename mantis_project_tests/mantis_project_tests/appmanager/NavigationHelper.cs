using OpenQA.Selenium;

namespace mantis_project_tests
{
	public class NavigationHelper : HelperBase
	{
		private string baseURL;


		public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
		{ this.baseURL = baseURL; }

		public void GetProjectsTable()
		{
			if (driver.Url == baseURL + "/manage_proj_page.php")
			{ return; }
			manager.ManagManuH.GetManagePage();
			manager.ManagManuH.GetProjectsPage();
		}

		public void GetProjectsTableForApi()
		{
			if (driver.Url == baseURL + "/manage_proj_page.php")
			{
				manager.ManagManuH.GetProjectsPage();
				return;
			}
			manager.ManagManuH.GetManagePage();
			manager.ManagManuH.GetProjectsPage();
		}

		public void LoginSubmitButton()
		{
			driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
		}


	}
}
