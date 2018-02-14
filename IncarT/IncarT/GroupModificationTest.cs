using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	class GroupModificationTests : TestBase
	{
		[Test]
		public void GroupModificationTest()
		{
			OpenStartPage();
			Login(new AccountData("admin", "secret"));
			OpenGroupPage();
			SelectGroupItem(0);
			EditGroup();
			FillGroupFields(new GroupData("o", "l", "x"));
			UpdateGroup();
			ReturnGroupPage();
			Logout();

		}
	}
}
