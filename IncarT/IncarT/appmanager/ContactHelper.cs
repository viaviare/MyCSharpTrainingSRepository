using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

		public void Modify(ContactData contact, ContactData newData)
		{
			manager.NavigatorH.OpenMainPage();
			SelectContactItem(contact.Id);
			InitEditionContact(contact.Id);
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

		public void Remove(ContactData contact)
		{
			manager.NavigatorH.OpenMainPage();
			SelectContactItem(contact.Id);
			DeleteContact();
			manager.NavigatorH.OpenMainPage();
		}


		public void AddContactToGroup(ContactData contact, GroupData group)
		{
			manager.NavigatorH.OpenMainPage();
			ClearGroupFilter();
			SelectContactItem(contact.Id);
			SelectGroupToAdd(group.Name);
			CommitAddingContactToGroup();
			new WebDriverWait(driver, TimeSpan.FromSeconds(10))
				.Until(z => z.FindElements(By.CssSelector("div.msgbox")).Count > 0);
		}

		public void RemoveContactFromGroup(ContactData contact, GroupData group)
		{
			manager.NavigatorH.OpenMainPage();
			ChooseCurrentGroupFilter(group.Name);
			SelectContactItem(contact.Id);
			CommitRemovalContactFromGroup();
			new WebDriverWait(driver, TimeSpan.FromSeconds(10))
				.Until(z => z.FindElements(By.CssSelector("div.msgbox")).Count > 0);
		}

		public void CheckCountContacts(ContactData tempData)
		{
			if (CountContactItems() == 0)
			{
				Create(tempData);
			}
		}

		private void ClearGroupFilter()
		{
			var selectList = new SelectElement(driver.FindElement(By.Name("group")));
			selectList.SelectByText("[all]");
		}

		private void SelectGroupToAdd(string name)
		{
			var selectList = new SelectElement(driver.FindElement(By.Name("to_group")));
			selectList.SelectByText(name);
		}

		private void ChooseCurrentGroupFilter(string name)
		{
			var selectList = new SelectElement(driver.FindElement(By.Name("group")));
			selectList.SelectByText(name);
		}

		private void CommitAddingContactToGroup()
		{
			driver.FindElement(By.Name("add")).Click();
		}

		private void CommitRemovalContactFromGroup()
		{
			driver.FindElement(By.Name("remove")).Click();
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

			string email1 = driver.FindElement(By.CssSelector("input[name = 'email']")).GetAttribute("value");
			string email2 = driver.FindElement(By.CssSelector("input[name = 'email2']")).GetAttribute("value");
			string email3 = driver.FindElement(By.CssSelector("input[name = 'email3']")).GetAttribute("value");

			ContactData contact = new ContactData(firstName, lastName)
			{
				Address = address,
				Home = homePhone,
				Mobile = mobilePhone,
				Work = workPhone,
				Email = email1,
				Email2 = email2,
				Email3 = email3
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
				AllInfo = driver.FindElement(By.CssSelector("div#content")).Text
			};
			return contact;
		}
 
		public int CountContactItems()
		{
			manager.NavigatorH.OpenMainPage();
			return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
		}

		public void FillContactFields(ContactData contact)
		{
			Type(By.Name("firstname"), contact.FirstName);
			Type(By.Name("lastname"), contact.LastName);
		}

		public void InitViewDetailsContact(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
		}

		public void InitEditionContact(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
		}

		public void InitEditionContact(string id)
		{
			driver.FindElement(By.XPath("//a[@href = 'edit.php?id=" + id + "']")).Click();
		}


		public void SelectContactItem(int index)
		{
			driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + (index + 1) + "]")).Click();
		}

		public void SelectContactItem(string id)
		{
			driver.FindElement(By.Id(id)).Click();
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
