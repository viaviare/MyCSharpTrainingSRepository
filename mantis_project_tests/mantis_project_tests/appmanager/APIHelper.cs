using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_project_tests
{
	public class APIHelper : HelperBase
	{

		public APIHelper(ApplicationManager manager) : base(manager)
		{}

		public void Create(AccountData account, ProjectData project)
		{
			Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
			Mantis.ProjectData projectM = new Mantis.ProjectData();
			projectM.id = project.Id;
			projectM.name = project.ProjectName;
			client.mc_project_add(account.Username, account.Password, projectM);
		}

		public void Remove(AccountData account, ProjectData project)
		{
			Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
			Mantis.ProjectData projectM = new Mantis.ProjectData();
			projectM.id = project.Id;
			client.mc_project_delete(account.Username, account.Password, projectM.id);
		}


			public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
		{
			Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
			Mantis.IssueData issue = new Mantis.IssueData();
			issue.summary = issueData.Summary;
			issue.description = issueData.Description;
			issue.category = issueData.Category;
			issue.project = new Mantis.ObjectRef();
			issue.project.id = project.Id;
			client.mc_issue_add(account.Username, account.Password, issue);
		}


		public List<ProjectData> GetProjectListWithApi(AccountData account)
		{
			Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
			List<ProjectData> apiList = new List<ProjectData>();
			Mantis.ProjectData[] arrayProjects = client.mc_projects_get_user_accessible(account.Username, account.Password);

			foreach (Mantis.ProjectData item in arrayProjects)
			{
				apiList.Add(new ProjectData() { Id = item.id, ProjectName = item.name });
			}
			return apiList;
		}



		public int CountProjectItems(AccountData account)
		{
			List<ProjectData> apiList = GetProjectListWithApi(account);
			return apiList.Count();
		}
	}
}

