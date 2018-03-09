using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressBookTests
{
	public class TestBase
	{
		protected ApplicationManager app;

		[SetUp]
		public void SetupApplicationManager()
		{
			app = ApplicationManager.GetInstance();
		}
	}
}

