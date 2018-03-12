using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	class ContactComparisonDetailsFormTests : TestBaseAuth
	{
		[Test]
		public void ContactComparisonDetailsFormTest()
		{
			int index = 1;
			ContactData formData = app.ContactH.GetContactFormData(index);
			ContactData detailsData = app.ContactH.GetContactDetailsData(index);
			Assert.AreEqual(formData.AllInfo, detailsData.AllInfo);
		}
	}
}
