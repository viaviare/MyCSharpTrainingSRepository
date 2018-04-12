using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactRemovalTests : ContactTestBase
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

			List<ContactData> oldContact = ContactData.GetAll();
			ContactData removedCont = oldContact[index];

			app.ContactH.Remove(removedCont);

			oldContact.RemoveAt(index);
			List<ContactData> newContact = ContactData.GetAll();
			oldContact.Sort();
			newContact.Sort();
			Assert.AreEqual(oldContact, newContact);			
		}

	}
}

