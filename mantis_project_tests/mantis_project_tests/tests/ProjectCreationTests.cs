using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_project_tests
{
	[TestFixture]
	public class ProjectCreationTests : TestBaseProjectsLongChecks
	{

		[Test]
		public void ProjectCreationTest()
		{
			ProjectData prData = new ProjectData()
			{ ProjectName = "Project3" };

			AccountData account = new AccountData()
			{
				Username = "administrator",
				Password = "root"
			};


			List<ProjectData> oldProjects = app.ApiH.GetProjectListWithApi(account);

			foreach (ProjectData item in oldProjects)
			{
				if (item.ProjectName == prData.ProjectName)
				{
					app.ApiH.Remove(account, item);
					oldProjects.Remove(item);
					break;
				}
			}

			app.ProjectManagH.Create(prData);


			oldProjects.Add(prData);
			List<ProjectData> newProjects = app.ApiH.GetProjectListWithApi(account);
			oldProjects.Sort();
			newProjects.Sort();
			Assert.AreEqual(oldProjects, newProjects);
		}
	}
}
