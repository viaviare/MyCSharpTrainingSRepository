using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	public class GroupTestBase : TestBaseAuth
	{
		[TearDown]
		public void CompareGroupUI_DB()
		{
			if (PERFORM_LOGN_UI_CHECKS)
			{
				List<GroupData> fromUI = app.GroupH.GetGroupList();
				List<GroupData> fromDB = GroupData.GetAll();
				fromUI.Sort();
				fromDB.Sort();
				Assert.AreEqual(fromUI, fromDB);
			}
		}
	}
}
