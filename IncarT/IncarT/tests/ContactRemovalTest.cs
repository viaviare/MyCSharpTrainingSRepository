using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactRemovalTests : TestBaseAuth
	{
		[Test]
		public void ContactRemovalTest()
		{
			ContactData tempData = new ContactData("z", "z");
			int index = 0;

			if (app.ContactH.CountContactItems()==0)
			{
				app.ContactH.Create(tempData);
			}
			if (app.ContactH.CountContactItems() > 1)
			{
				List<ContactData> oldContact = app.ContactH.GetContactList();

				app.ContactH.Remove(index);

				oldContact.RemoveAt(index);
				List<ContactData> newContact = app.ContactH.GetContactList();
				oldContact.Sort();
				newContact.Sort();
				Assert.AreEqual(oldContact, newContact);
			}
			else
			{
				app.ContactH.Remove(index);
			}
			
		}

	}
}

