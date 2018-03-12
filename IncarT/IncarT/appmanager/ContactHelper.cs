using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

		private List<ContactData> contactCache;

		public List<ContactData> GetContactList()
		{
			if (contactCache == null)
			{
				contactCache = new List<ContactData>();
				ICollection<IWebElement> items = driver.FindElements(By.CssSelector("tr[name='entry']"));
				foreach (IWebElement item in items)
				{
					string lastName = item.FindElement(By.CssSelector("td:nth-of-type(2)")).Text;
					string firstName = item.FindElement(By.CssSelector("td:nth-of-type(3)")).Text;
					contactCache.Add(new ContactData(firstName, lastName));
				}
			}
			return new List<ContactData>(contactCache);
		}

		public ContactData GetContactPageData(int index)
		{
			manager.NavigatorH.OpenMainPage();
			IList<IWebElement> itemLines = driver.FindElements(By.XPath("//tr[@name='entry']/td"));
			string lastName = itemLines[1].Text;
			string firstName = itemLines[2].Text;
			string address = itemLines[3].Text;
			string allPhones = itemLines[5].Text;

			ContactData contact = new ContactData(firstName, lastName)
			{
				Address = address,
				AllPhones = allPhones
			};
			return contact;
		}

		public ContactData GetContactFormData(int index)
		{
			manager.NavigatorH.OpenMainPage();
			SelectContactItem(index);
			InitEditionContact(index);
			string lastName = driver.FindElement(By.CssSelector("input[name = 'lastname']")).GetAttribute("value");
			string firstName = driver.FindElement(By.CssSelector("input[name = 'firstname']")).GetAttribute("value");
			string address = driver.FindElement(By.CssSelector("textarea[name = 'address']")).GetAttribute("value");

			string homePhone = driver.FindElement(By.CssSelector("input[name = 'home']")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.CssSelector("input[name = 'mobile']")).GetAttribute("value");
			string workPhone = driver.FindElement(By.CssSelector("input[name = 'work']")).GetAttribute("value");
			ContactData contact = new ContactData(firstName, lastName)
			{
				Address = address,
				Home = homePhone,
				Mobile = mobilePhone,
				Work = workPhone
			};
			return contact;
		}

		public ContactData GetContactDetailsData(int index)
		{
			manager.NavigatorH.OpenMainPage();
			SelectContactItem(index);
			InitViewDetailsContact(index);
			ContactData contact = new ContactData()
			{
				AllInfo = Regex.Replace(driver.FindElement(By.CssSelector("div#content")).Text, @"\r\n[HMW]:\s", "")
			};
			return contact;
		}
 
		public int CountContactItems()
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

		public void InitViewDetailsContact(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
		}

		public void SelectContactItem(int index)
		{
			driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + (index + 1) + "]")).Click();
		}

		public void UpdateContact()
		{
			driver.FindElement(By.Name("update")).Click();
			contactCache = null;
		}

		public void SubmitContactFields()
		{
			driver.FindElement(By.Name("submit")).Click();
			contactCache = null;
		}

		public void DeleteContact()
		{
			driver.FindElement(By.CssSelector("input[value = Delete]")).Click();
			driver.SwitchTo().Alert().Accept();
			contactCache = null;
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
