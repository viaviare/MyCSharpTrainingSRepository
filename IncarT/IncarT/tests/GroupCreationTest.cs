using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : TestBaseAuth
	{
		[Test, TestCaseSource ("ContactDataFromJson")]
		public void GroupCreationTest(GroupData groupData)
		{

			List<GroupData> oldGroup = app.GroupH.GetGroupList();

			app.GroupH.Create(groupData);

			oldGroup.Add(groupData);

			List<GroupData> newGroup = app.GroupH.GetGroupList();
			oldGroup.Sort();
			newGroup.Sort();
			Assert.AreEqual(oldGroup, newGroup);
		}


		public static IEnumerable<GroupData> RandomGroupDataProvider()
		{
			List<GroupData> group = new List<GroupData>();
			for (int j = 0; j < 3; j++)
			{
				group.Add(new GroupData(GenerateRandomString(10))
				{
					Header = GenerateRandomString(20),
					Footer = GenerateRandomString(20)
				});
			}
			return group;
		}

		public static IEnumerable<GroupData> GroupDataFromXml()
		{
			return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
				.Deserialize(new StreamReader(@"groups.xml"));
		}

		public static IEnumerable<GroupData> GroupDataFromJson()
		{
			return JsonConvert.DeserializeObject<List<GroupData>>(
				File.ReadAllText(@"groups.json"));
		}

		public static IEnumerable<ContactData> ContactDataFromXml()
		{
			return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
				.Deserialize(new StreamReader(@"contacts.xml"));
		}

		public static IEnumerable<ContactData> ContactDataFromJson()
		{
			return JsonConvert.DeserializeObject<List<ContactData>>(
				File.ReadAllText(@"contacts.json"));
		}
	}
}
