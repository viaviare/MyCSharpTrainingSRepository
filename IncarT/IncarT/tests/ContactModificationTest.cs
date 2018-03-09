using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactModificationTests : TestBase
	{
		[Test]
		public void ContactModificationTest()
		{
			ContactData newData = new ContactData("11", "22");

			app.ContactH.Modify(0, newData);
		}
	}
}


