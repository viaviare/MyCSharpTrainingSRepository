using NUnit.Framework;

namespace litecart
{
	[TestFixture]
	public class CheckMenu7 : TestBaseAuth
	{

		[Test]
		public void CheckMenu()
		{
			app.ManuH.CheckMainMenu();
		}
	}
}
