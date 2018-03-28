using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace WebAddressBookTests
{
	[TestFixture]
	public class DeleteContactFromGroupTests : TestBaseAuth
	{
		[Test]
		public void DeleteContactFromGroupTest()
		{
			ContactData tempData = new ContactData("q", "q");
			GroupData tempGroup = new GroupData("z", "z", "z");

			app.ContactH.CheckCountContacts(tempData);
			app.GroupH.CheckCountGroups(tempGroup);

			//-----------------
			GroupData group = new GroupData();

			ContactData contact = ContactData.GetAll().First();
			List<GroupData> contactGroups = contact.GetGroups();
			if (contactGroups.Count() == 0)
			{
				group = GroupData.GetAll().First();
				app.ContactH.AddContactToGroup(contact, group);
			}
			else
			{
				group = contactGroups.First();
			}

			List<ContactData> oldCont = group.GetContacts();
			//-----------------

			app.ContactH.RemoveContactFromGroup(contact, group);

			List<ContactData> newCont = group.GetContacts();
			oldCont.Remove(contact);
			oldCont.Sort();
			newCont.Sort();

			Assert.AreEqual(oldCont, newCont);

		}
	}
}