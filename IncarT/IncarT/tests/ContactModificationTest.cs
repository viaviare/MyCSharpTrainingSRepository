using System;
using NUnit.Framework;


namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactModificationTests : TestBaseAuth
	{
		[Test]
		public void ContactModificationTest()
		{
			ContactData tempData = new ContactData("z", "z");
			ContactData newData = new ContactData("11", "22");

			if (! app.ContactH.CheckContactPresents())
			{
				app.ContactH.Create(tempData);
			}
			app.ContactH.Modify(0, newData);
		}
	}
}


