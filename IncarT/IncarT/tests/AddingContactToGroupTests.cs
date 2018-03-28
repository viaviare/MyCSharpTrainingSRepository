using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class AddingContactToGroupTests : TestBaseAuth
	{
		[Test]
		public void AddingContactToGroupTest()
		{
			ContactData tempData = new ContactData("q", "q");
			GroupData tempGroup = new GroupData("z", "z", "z");

			app.ContactH.CheckCountContacts(tempData);
			app.GroupH.CheckCountGroups(tempGroup);

			//-------------------
			GroupData group = new GroupData();

			ContactData contact = ContactData.GetAll().First();
			List<GroupData> contactGroups = contact.GetGroups();
			IEnumerable<GroupData> freeGroups = GroupData.GetAll().Except(contactGroups);
			if (freeGroups.Count() == 0)
			{
				app.ContactH.Create(tempData);
				contact = ContactData.GetAll().Last();
				freeGroups = GroupData.GetAll();
			}
			group = freeGroups.First();

			List<ContactData> oldCont = group.GetContacts();
			//-------------------

			app.ContactH.AddContactToGroup(contact, group);


			List<ContactData> newCont = group.GetContacts();
			oldCont.Add(contact);
			oldCont.Sort();
			newCont.Sort();

			Assert.AreEqual(oldCont, newCont);
		}
	}
}
