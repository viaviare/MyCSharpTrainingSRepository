using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactCreationTests : TestBaseAuth
	{

		[Test, TestCaseSource ("RandomContactDataProvider")]
		public void ContactCreationTest(ContactData contData)
		{
			List<ContactData> oldContact = app.ContactH.GetContactList();

			app.ContactH.Create(contData);

			oldContact.Add(contData);
			List<ContactData> newContact = app.ContactH.GetContactList();
			oldContact.Sort();
			newContact.Sort();
			Assert.AreEqual(oldContact, newContact);

		}

		public static IEnumerable<ContactData> RandomContactDataProvider()
		{
			List<ContactData> contact = new List<ContactData>();
			for (int j = 0; j < 3; j++)
			{
				contact.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(15))
				{
					Address = GenerateRandomString(30)
				});
			}
			return contact;
		}
	}
}

