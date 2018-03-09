using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactRemovalTests : TestBaseAuth
	{
		[Test]
		public void ContactRemovalTest()
		{
			app.ContactH.Remove(0);
		}

	}
}

