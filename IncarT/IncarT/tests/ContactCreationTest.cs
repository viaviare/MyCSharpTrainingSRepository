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
	public class ContactCreationTests : TestBaseAuth
	{

		[Test]
		public void ContactCreationTest()
		{
			ContactData contData = new ContactData("uu", "yy");

			app.ContactH.Create(contData);

		}
	}
}

