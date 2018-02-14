using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressBookTests
{
	public class TestBase
	{
		private IWebDriver driver;
		private string baseURL;
		private bool acceptNextAlert = true;

		[SetUp]
		public void SetupTest()
		{
			driver = new ChromeDriver();
			baseURL = "http://localhost";
		}

		[TearDown]
		public void TeardownTest()
		{
			try
			{
				driver.Quit();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
		}



		public void UpdateContact()
		{
			driver.FindElement(By.Name("update")).Click();
		}
		public void UpdateGroup()
		{
			driver.FindElement(By.Name("update")).Click();
		}

		public void EditGroup()
		{
			driver.FindElement(By.Name("edit")).Click();
		}

		public void OpenMainPage()
		{
			driver.FindElement(By.LinkText("home")).Click();
		}

		public void ReturnHomePage()
		{
			driver.FindElement(By.LinkText("home page")).Click();
		}

		public void FillContactFields(ContactData contact)
		{
			driver.FindElement(By.Name("firstname")).Clear();
			driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
			driver.FindElement(By.Name("lastname")).Clear();
			driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
		}

		public void OpenGroupPage()
		{
			driver.FindElement(By.LinkText("groups")).Click();
		}

		public void OpenStartPage()
		{
			driver.Navigate().GoToUrl(baseURL + "/addressbook/");
		}

		public void DeleteContact()
		{
			driver.FindElement(By.CssSelector("input[value = Delete]")).Click();
			driver.SwitchTo().Alert().Accept();
		}

		public void Login(AccountData account)
		{
			driver.FindElement(By.Name("user")).Clear();
			driver.FindElement(By.Name("user")).SendKeys(account.Username);
			driver.FindElement(By.Name("pass")).Clear();
			driver.FindElement(By.Name("pass")).SendKeys(account.Password);
			driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
		}

		public void SubmitContactFields()
		{
			driver.FindElement(By.Name("submit")).Click();
		}

		public void OpenNewContact()
		{
			driver.FindElement(By.LinkText("add new")).Click();
		}

		public void SubmitGroupFields()
		{
			driver.FindElement(By.Name("submit")).Click();
		}

		public void FillGroupFields(GroupData group)
		{
			driver.FindElement(By.Name("group_name")).Clear();
			driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
			driver.FindElement(By.Name("group_header")).Clear();
			driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
			driver.FindElement(By.Name("group_footer")).Clear();
			driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
		}

		public void InitNewGroup()
		{
			driver.FindElement(By.Name("new")).Click();
		}
		public void SelectGroupItem(int index)
		{
			driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
		}

		public void InitEditionContact(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
		}

		public void SelectContactItem(int index)
		{
			driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + (index + 1) + "]")).Click();
		}

		public void Logout()
		{
			driver.FindElement(By.LinkText("Logout")).Click();
		}

		public void ReturnGroupPage()
		{
			driver.FindElement(By.LinkText("group page")).Click();
		}

		public void DeleteGroup()
		{
			driver.FindElement(By.Name("delete")).Click();
		}
	}
}

