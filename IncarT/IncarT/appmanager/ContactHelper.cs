using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;

namespace WebAddressBookTests
{
	public class ContactHelper : HelperBase
	{

		public ContactHelper(ApplicationManager manager) : base(manager)
		{}

		public void Create(ContactData contData)
		{
			manager.NavigatorH.OpenMainPage();
			manager.ContactH.OpenNewContact();
			manager.ContactH.FillContactFields(contData);
			manager.ContactH.SubmitContactFields();
			manager.ContactH.ReturnHomePage();
		}

		public void Modify(int index, ContactData newData)
		{
			manager.NavigatorH.OpenMainPage();
			manager.ContactH.SelectContactItem(index);
			manager.ContactH.InitEditionContact(index);
			manager.ContactH.FillContactFields(newData);
			manager.ContactH.UpdateContact();
			manager.ContactH.ReturnHomePage();
		}

		public void Remove(int index)
		{
			manager.NavigatorH.OpenMainPage();
			manager.ContactH.SelectContactItem(index);
			manager.ContactH.DeleteContact();
			manager.NavigatorH.OpenMainPage();
		}

		public void FillContactFields(ContactData contact)
		{
			Type(By.Name("firstname"), contact.FirstName);
			Type(By.Name("lastname"), contact.LastName);
		}

		public void InitEditionContact(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
		}

		public void SelectContactItem(int index)
		{
			driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + (index + 1) + "]")).Click();
		}

		public void UpdateContact()
		{
			driver.FindElement(By.Name("update")).Click();
		}

		public void SubmitContactFields()
		{
			driver.FindElement(By.Name("submit")).Click();
		}

		public void DeleteContact()
		{
			driver.FindElement(By.CssSelector("input[value = Delete]")).Click();
			driver.SwitchTo().Alert().Accept();
		}

		public void OpenNewContact()
		{
			driver.FindElement(By.LinkText("add new")).Click();
		}

		public void ReturnHomePage()
		{
			driver.FindElement(By.LinkText("home page")).Click();
		}
	}
}
