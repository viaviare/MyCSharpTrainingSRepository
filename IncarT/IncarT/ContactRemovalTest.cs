using System;
using System.Text;
using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactRemovalTests : TestBase
	{
		[Test]
		public void ContactRemovalTest()
		{
			OpenStartPage();
			Login(new AccountData("admin", "secret"));
			OpenMainPage();
			SelectContactItem(0);
			DeleteContact();
			OpenMainPage();
		}

	}
}

