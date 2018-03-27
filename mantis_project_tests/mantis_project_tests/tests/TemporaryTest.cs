using System.Collections.Generic;
using NUnit.Framework;


namespace mantis_projects_tests
{
	[TestFixture]
	public class TemporaryTests : TestBaseAuth
	{
		[Test]
		public void TemporaryTest()
		{
			AccountData tempData = new AccountData()
			{ Username = "t", Password = "t" };

			app.LoginH.Login(tempData);


			List<ProjectData> projects = ProjectData.GetProjectListFromBD();
			foreach (ProjectData item in projects)
			{
				System.Console.Out.WriteLine(item.Id + "  " + item.ProjectName);
			}
		}

	}
}
