using System.Text;
using NUnit.Framework;

namespace litecart
{
	public class TestBase
	{
		protected ApplicationManager app;

		[SetUp]
		public void SetUpApplicationManager()
		{
			app = ApplicationManager.GetInstance();
		}

	}
}