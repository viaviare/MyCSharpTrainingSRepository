using System;
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

		public bool CheckGroupPresents()
		{
			manager.NavigatorH.OpenGroupPage();
			return driver.FindElements(By.CssSelector("span.group")).Count > 0;
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
		}

		public void SubmitGroupFields()
		{
			driver.FindElement(By.Name("submit")).Click();
		}

		public void DeleteGroup()
		{
			driver.FindElement(By.Name("delete")).Click();
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
