using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactRemovalTests : TestBase
	{
		[Test]
		public void ContactRemovalTest()
		{
			app.ContactH.Remove(0);
		}

	}
}

