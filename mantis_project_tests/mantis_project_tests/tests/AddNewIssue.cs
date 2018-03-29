using NUnit.Framework;

namespace mantis_project_tests
{
	[TestFixture]
	public class AddNewIssues : TestBase
	{
		[Test]
		public void AddNewIssue()
		{
			AccountData account = new AccountData()
			{
				Username = "administrator",
				Password = "root"
			};
			IssueData issueData = new IssueData()
			{
				Summary = "some short text",
				Description = "some long text",
				Category = "General"
			};

			ProjectData project = new ProjectData()
			{
				Id = "3"
			};

			app.ApiH.CreateNewIssue(account, project, issueData);
		}
	}
}
