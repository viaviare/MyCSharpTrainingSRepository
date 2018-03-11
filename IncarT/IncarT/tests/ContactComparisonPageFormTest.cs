using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	class ContactComparisonPageFormTests : TestBaseAuth
	{
		[Test]
		public void ContactComparisonPageFormTest()
		{
			int index = 0;
			ContactData formData = app.ContactH.GetContactFormData(index);
			ContactData pageData = app.ContactH.GetContactPageData(index);
			Assert.AreEqual(formData, pageData);
			Assert.AreEqual(formData.Address, pageData.Address);
			Assert.AreEqual(formData.AllPhones, pageData.AllPhones);
		}
	}
}
