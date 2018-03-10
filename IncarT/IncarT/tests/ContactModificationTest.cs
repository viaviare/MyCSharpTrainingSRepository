using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactModificationTests : TestBaseAuth
	{
		[Test]
		public void ContactModificationTest()
		{
			ContactData tempData = new ContactData("z", "z");
			ContactData newData = new ContactData("11", "22");
			int index = 0;

			if (app.ContactH.CountContactItems() == 0)
			{
				app.ContactH.Create(tempData);
			}
			List<ContactData> oldContact = app.ContactH.GetContactList();

			app.ContactH.Modify(index, newData);

			oldContact[index].FirstName = newData.FirstName;
			oldContact[index].LastName = newData.LastName;

			List<ContactData> newContact = app.ContactH.GetContactList();
			oldContact.Sort();
			newContact.Sort();
			Assert.AreEqual(oldContact, newContact);
		}
	}
}


