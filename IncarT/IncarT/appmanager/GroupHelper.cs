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
			manager.GroupH.InitNewGroup();
			manager.GroupH.FillGroupFields(groupData);
			manager.GroupH.SubmitGroupFields();
			manager.GroupH.ReturnGroupPage();
		}

		public void Modify(int index, GroupData newData)
		{
			manager.NavigatorH.OpenGroupPage();
			manager.GroupH.SelectGroupItem(index);
			manager.GroupH.EditGroup();
			manager.GroupH.FillGroupFields(newData);
			manager.GroupH.UpdateGroup();
			manager.GroupH.ReturnGroupPage();
		}

		internal void Remove(int index)
		{
			manager.NavigatorH.OpenGroupPage();
			manager.GroupH.SelectGroupItem(index);
			manager.GroupH.DeleteGroup();
			manager.GroupH.ReturnGroupPage();
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
