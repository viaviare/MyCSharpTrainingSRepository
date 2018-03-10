using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
	public class GroupHelper : HelperBase
	{

		public GroupHelper(ApplicationManager manager) : base(manager)
		{ }

		public void Create(GroupData groupData)
		{
			manager.NavigatorH.OpenGroupPage();
			InitNewGroup();
			FillGroupFields(groupData);
			SubmitGroupFields();
			ReturnGroupPage();
		}

		public void Modify(int index, GroupData newData)
		{
			manager.NavigatorH.OpenGroupPage();
			SelectGroupItem(index);
			EditGroup();
			FillGroupFields(newData);
			UpdateGroup();
			ReturnGroupPage();
		}

		internal void Remove(int index)
		{
			manager.NavigatorH.OpenGroupPage();
			SelectGroupItem(index);
			DeleteGroup();
			ReturnGroupPage();
		}

		private List<GroupData> groupCache;

		public List<GroupData> GetGroupList()
		{
			if (groupCache == null)
			{
				groupCache = new List<GroupData>();
				manager.NavigatorH.OpenGroupPage();
				ICollection<IWebElement> items = driver.FindElements(By.CssSelector("span.group"));
				foreach (IWebElement item in items)
				{
					groupCache.Add(new GroupData(item.Text));
				}
			}
			return new List<GroupData>(groupCache);
		}

		public int CountGroupItems()
		{
			manager.NavigatorH.OpenGroupPage();
			return driver.FindElements(By.CssSelector("span.group")).Count;
		}

		public void FillGroupFields(GroupData group)
		{
			Type(By.Name("group_name"), group.Name);
			Type(By.Name("group_header"), group.Header);
			Type(By.Name("group_footer"), group.Footer);
		}

		public void SelectGroupItem(int index)
		{
			driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
		}

		public void UpdateGroup()
		{
			driver.FindElement(By.Name("update")).Click();
			groupCache = null;
		}

		public void SubmitGroupFields()
		{
			driver.FindElement(By.Name("submit")).Click();
			groupCache = null;
		}

		public void DeleteGroup()
		{
			driver.FindElement(By.Name("delete")).Click();
			groupCache = null;
		}

		public void EditGroup()
		{
			driver.FindElement(By.Name("edit")).Click();
		}

		public void ReturnGroupPage()
		{
			driver.FindElement(By.LinkText("group page")).Click();
		}

		public void InitNewGroup()
		{
			driver.FindElement(By.Name("new")).Click();
		}
	}
}
