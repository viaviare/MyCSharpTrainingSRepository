using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupRemovalTests : TestBaseAuth
	{

		[Test]
		public void GroupRemovalTest()
		{
			app.GroupH.Remove(0);
		}
	}
}

