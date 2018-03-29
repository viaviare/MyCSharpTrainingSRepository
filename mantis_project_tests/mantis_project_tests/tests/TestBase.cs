using NUnit.Framework;

namespace mantis_project_tests
{
	public class TestBase
	{
		public static bool PERFORM_LOGN_UI_CHECKS = false;
		protected ApplicationManager app;

		[OneTimeSetUp]
		public void SetupApplicationManager()
		{
			app = ApplicationManager.GetInstance();
		}
	}
}


