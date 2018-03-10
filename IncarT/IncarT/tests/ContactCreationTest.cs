using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactCreationTests : TestBaseAuth
	{

		[Test]
		public void ContactCreationTest()
		{
			ContactData contData = new ContactData("uu", "yy");

			List<ContactData> oldContact = app.ContactH.GetContactList();

			app.ContactH.Create(contData);

			oldContact.Add(contData);
			List<ContactData> newContact = app.ContactH.GetContactList();
			oldContact.Sort();
			newContact.Sort();
			Assert.AreEqual(oldContact, newContact);

		}
	}
}

