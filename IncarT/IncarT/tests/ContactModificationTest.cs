using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactModificationTests : ContactTestBase
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
			List<ContactData> oldContact = ContactData.GetAll();
			ContactData modifiedCont = oldContact[index];

			oldContact[index].FirstName = newData.FirstName;
			oldContact[index].LastName = newData.LastName;

			app.ContactH.Modify(modifiedCont, newData);

			List<ContactData> newContact = ContactData.GetAll();
			oldContact.Sort();
			newContact.Sort();
			Assert.AreEqual(oldContact, newContact);
		}
	}
}


