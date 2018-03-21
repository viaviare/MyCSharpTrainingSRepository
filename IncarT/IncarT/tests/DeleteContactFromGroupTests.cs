using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class DeleteContactFromGroupTests : TestBaseAuth
	{
		[Test]
		public void DeleteContactFromGroupTest()
		{
			GroupData group = GroupData.GetAll()[0];

			List<ContactData> oldCont = group.GetContacts();
			ContactData contact = oldCont[0];

			app.ContactH.RemoveContactFromGroup(contact, group);

			List<ContactData> newCont = group.GetContacts();
			oldCont.Remove(contact);
			oldCont.Sort();
			newCont.Sort();

			Assert.AreEqual(oldCont, newCont);

		}
	}
}