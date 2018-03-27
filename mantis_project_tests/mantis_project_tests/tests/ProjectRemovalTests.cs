using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_projects_tests.tests
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

			if (app.ProjectManagH.CountProjectItems() == 0)
			{
				app.ProjectManagH.Create(tempData);
			}


			List<ProjectData> oldProjects = ProjectData.GetProjectListFromBD();
			ProjectData removedProject = oldProjects[index];

			app.ProjectManagH.Remove(removedProject);

			oldProjects.RemoveAt(index);
			List<ProjectData> newProjects = ProjectData.GetProjectListFromBD();
			oldProjects.Sort();
			newProjects.Sort();
			Assert.AreEqual(oldProjects, newProjects);
		}
	}
}



	
