using NUnit.Framework;

namespace mantis_projects_tests
{
	public class TestBase
	{
		public static bool PERFORM_LOGN_UI_CHECKS = true;
		protected ApplicationManager app;

		[OneTimeSetUp]
		public void SetupApplicationManager()
		{
			app = ApplicationManager.GetInstance();
		}
	}
}


