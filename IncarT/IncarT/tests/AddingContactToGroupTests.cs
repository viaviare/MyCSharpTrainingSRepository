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
			GroupData group = GroupData.GetAll()[0];
			List<ContactData> oldCont = group.GetContacts();
			ContactData contact = ContactData.GetAll().Except(oldCont).First();

			app.ContactH.AddContactToGroup(contact, group);


			List<ContactData> newCont = group.GetContacts();
			oldCont.Add(contact);
			oldCont.Sort();
			newCont.Sort();

			Assert.AreEqual(oldCont, newCont);

		}
	}
}
