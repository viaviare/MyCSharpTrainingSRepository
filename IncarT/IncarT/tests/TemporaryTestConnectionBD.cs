using System;
using System.Text.RegularExpressions;
using System.Linq;
using LinqToDB.Mapping;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
	[TestFixture]
	public class TemporaryTestConnectionBD 
	{
		[Test]
		public void TemporaryTest()
		{
			List<ContactData> contacts = ContactData.GetAll();
			foreach (ContactData item in contacts)
			{
				System.Console.Out.WriteLine(item.Id + "  " + item.LastName + "  " + item.Deprecated);
			}
		}

	}
}
