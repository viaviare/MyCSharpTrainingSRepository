﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressBookTests
{
	public class ContactHelper : HelperBase
	{

		public ContactHelper(ApplicationManager manager) : base(manager)
		{}

		public void Create(ContactData contData)
		{
			manager.NavigatorH.OpenMainPage();
			OpenNewContact();
			FillContactFields(contData);
			SubmitContactFields();
			ReturnHomePage();
		}

		public void Modify(int index, ContactData newData)
		{
			manager.NavigatorH.OpenMainPage();
			SelectContactItem(index);
			InitEditionContact(index);
			FillContactFields(newData);
			UpdateContact();
			ReturnHomePage();
		}

		public void Remove(int index)
		{
			manager.NavigatorH.OpenMainPage();
			SelectContactItem(index);
			DeleteContact();
			manager.NavigatorH.OpenMainPage();
		}

		public List<ContactData> GetContactList()
		{
			List<ContactData> contact = new List<ContactData>();
			ICollection<IWebElement> items = driver.FindElements(By.CssSelector("tr[name='entry']"));
			foreach (IWebElement item in items)
			{
				string lastName = item.FindElement(By.CssSelector("td:nth-of-type(2)")).Text;
				string firstName = item.FindElement(By.CssSelector("td:nth-of-type(3)")).Text;
				contact.Add(new ContactData(firstName, lastName));
			}			
			return contact;
		}

		internal int CountContactItems()
		{
			return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
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
