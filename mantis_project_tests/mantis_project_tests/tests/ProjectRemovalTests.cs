using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_project_tests
{
	[TestFixture]
	public class ProjectRemovalTests : TestBaseProjectsLongChecks
	{
		[Test]
		public void ProjectRemovalTest()
		{
			ProjectData tempData = new ProjectData()
			{ ProjectName = "z"};
			int index = 0;

			AccountData account = new AccountData()
			{
				Username = "administrator",
				Password = "root"
			};

			if (app.ProjectManagH.CountProjectItems() == 0)
			{
				app.ApiH.Create(account, tempData);
				app.NavigatorH.GetProjectsTableForApi();
			}


			List<ProjectData> oldProjects = app.ApiH.GetProjectListWithApi(account);
			ProjectData removedProject = oldProjects[index];

			app.ProjectManagH.Remove(removedProject);

			oldProjects.RemoveAt(index);
			List<ProjectData> newProjects = app.ApiH.GetProjectListWithApi(account);
			oldProjects.Sort();
			newProjects.Sort();
			Assert.AreEqual(oldProjects, newProjects);
		}
	}
}



	
