using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactRemovalTests : TestBaseAuth
	{
		[Test]
		public void ContactRemovalTest()
		{
			ContactData tempData = new ContactData("z", "z");

			if (!app.ContactH.CheckContactPresents())
			{
				app.ContactH.Create(tempData);
			}
			app.ContactH.Remove(0);
		}

	}
}

