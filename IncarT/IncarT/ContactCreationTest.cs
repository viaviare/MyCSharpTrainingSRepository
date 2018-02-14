using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
	[TestFixture]
	public class ContactCreationTests : TestBase
	{

		[Test]
		public void ContactCreationTest()
		{
			OpenStartPage();
			Login(new AccountData("admin", "secret"));
			OpenMainPage();
			OpenNewContact();
			FillContactFields(new ContactData ("uu", "yy"));
			SubmitContactFields();
			ReturnHomePage();
			Logout();

		}
	}
}

