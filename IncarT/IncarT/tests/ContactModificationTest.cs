using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactModificationTests : TestBaseAuth
	{
		[Test]
		public void ContactModificationTest()
		{
			ContactData newData = new ContactData("11", "22");

			app.ContactH.Modify(0, newData);
		}
	}
}


