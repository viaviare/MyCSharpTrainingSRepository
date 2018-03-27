using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace mantis_projects_tests
{
	public class ProjectManagementHelper : HelperBase
	{
		public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }


		public void Create(ProjectData prData)
		{
			manager.NavigatorH.GetProjectsTable();
			CreateNewProjectButton();
			FillNewProjectFields(prData);
			SubmitNewProject();
		}

		public void Remove(ProjectData project)
		{
			manager.NavigatorH.GetProjectsTable();
			SelectProjectInList(project.Id);
			DeleteProjectButton();
			ConfirmDeleteButton();
		}

		private List<ProjectData> progectCache;

		public List<ProjectData> GetProjectListFromUI()
		{
			if (progectCache == null)
			{
				progectCache = new List<ProjectData>();
				manager.NavigatorH.GetProjectsTable();
				ICollection<IWebElement> items = 
					driver.FindElements(By.CssSelector("div.table-responsive"))[0]
					.FindElements(By.CssSelector("tbody tr"));
				foreach (IWebElement item in items)
				{
					progectCache.Add(new ProjectData()
					{
						ProjectName = item.FindElement(By.CssSelector("td:nth-of-type(1)")).Text
					});
				}
			}
			return new List<ProjectData>(progectCache);
		}

		public int CountProjectItems()
		{
			manager.NavigatorH.GetProjectsTable();
			return driver.FindElements(By.CssSelector("div.table-responsive"))[0].FindElements(By.CssSelector("tbody tr")).Count;
		}

		public void SubmitNewProject()
		{
			driver.FindElement(By.CssSelector("input[type='submit']")).Click();
			progectCache = null;
			driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
		}

		public void DeleteProjectButton()
		{
			driver.FindElement(By.CssSelector("form[id='project-delete-form'] input[type='submit']")).Click();
			progectCache = null;
		}

		public void CreateNewProjectButton() 
		{
			driver.FindElement(By.CssSelector("button[class='btn btn-primary btn-white btn-round']")).Click();
		}

		public void FillNewProjectFields(ProjectData prData)
		{
			driver.FindElement(By.Id("project-name")).SendKeys(prData.ProjectName);
		}

		public void SelectProjectInList(string id)
		{
			driver.FindElement(By.CssSelector("a[href='manage_proj_edit_page.php?project_id=" + id + "']")).Click();
		}

		public void ConfirmDeleteButton()
		{
			driver.FindElement(By.CssSelector("form[class='center'] input[type='submit']")).Click();
		}
	}
}
