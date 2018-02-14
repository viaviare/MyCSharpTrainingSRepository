using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactModificationTests : TestBase
	{
		[Test]
		public void ContactModificationTest()
		{
			OpenStartPage();
			Login(new AccountData("admin", "secret"));
			OpenMainPage();
			SelectContactItem(0);
			InitEditionContact(0);
			FillContactFields(new ContactData("11", "22"));
			UpdateContact();
			ReturnHomePage();
		}
	}
}


