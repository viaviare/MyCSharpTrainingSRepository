using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	public class ContactTestBase : TestBaseAuth
	{
		[TearDown]
		public void CompareContactUI_DB()
		{
			if (PERFORM_LOGN_UI_CHECKS)
			{
				List<ContactData> fromUI = app.ContactH.GetContactList();
				List<ContactData> fromDB = ContactData.GetAll();
				fromUI.Sort();
				fromDB.Sort();
				Assert.AreEqual(fromUI, fromDB);
			}
		}
	}
}
