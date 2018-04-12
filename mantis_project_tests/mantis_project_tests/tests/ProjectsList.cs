using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_project_tests
{
	[TestFixture]
	public class ProjectsLists : TestBase
	{
		[Test]
		public void ProjectsList()
		{
			AccountData account = new AccountData()
			{
				Username = "administrator",
				Password = "root"
			};
			//IssueData issueData = new IssueData()
			//{
			//	Summary = "some short text",
			//	Description = "some long text",
			//	Category = "General"
			//};

			//ProjectData project = new ProjectData()
			//{
			//	Id = "3"
			//};

			List<ProjectData> checkList = app.ApiH.GetProjectListWithApi(account);

			for (int j = 0; j < checkList.Count; j++)
			{
				System.Console.Out.WriteLine(checkList[j].Id + "  " + checkList[j].ProjectName);
			}
		}
	}
}