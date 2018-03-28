using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	class ContactComparisonDetailsFormTests : TestBaseAuth
	{
		[Test]
		public void ContactComparisonDetailsFormTest()
		{
			int index = 0;
			ContactData formData = app.ContactH.GetContactFormData(index);
			ContactData detailsData = app.ContactH.GetContactDetailsData(index);
			System.Console.Out.Write("details  \r\n" + detailsData.AllInfo);
			System.Console.Out.Write("  form  \r\n" + formData.AllInfo);
			Assert.AreEqual(formData.AllInfo, detailsData.AllInfo);
		}
	}
}
