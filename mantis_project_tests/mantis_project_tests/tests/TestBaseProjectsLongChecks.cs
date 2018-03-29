using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_project_tests
{
	public class TestBaseProjectsLongChecks : TestBaseAuth
	{
		[TearDown]
		public void CompareGroupUI_DB()
		{
			if (PERFORM_LOGN_UI_CHECKS)
			{
				List<ProjectData> fromUI = app.ProjectManagH.GetProjectListFromUI();
				List<ProjectData> fromDB = ProjectData.GetProjectListFromBD();
				fromUI.Sort();
				fromDB.Sort();
				Assert.AreEqual(fromUI, fromDB);
			}
		}
	}
}
