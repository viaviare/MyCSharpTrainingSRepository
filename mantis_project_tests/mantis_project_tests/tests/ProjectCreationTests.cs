using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_projects_tests
{
	[TestFixture]
	public class ProjectCreationTests : TestBaseProjectsLongChecks
	{

		[Test]
		public void ProjectCreationTest()
		{
			ProjectData prData = new ProjectData()
			{ ProjectName = "Project3" };


			List<ProjectData> oldProjects = ProjectData.GetProjectListFromBD();

			app.ProjectManagH.Create(prData);


			oldProjects.Add(prData);
			List<ProjectData> newProjects = ProjectData.GetProjectListFromBD();
			oldProjects.Sort();
			newProjects.Sort();
			Assert.AreEqual(oldProjects, newProjects);
		}
	}
}
