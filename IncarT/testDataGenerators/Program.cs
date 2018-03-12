using System;
using System.IO;
using System.Collections.Generic;
using WebAddressBookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace testDataGenerators
{
	class Program
	{
		static void Main(string[] args)
		{
			string typeFile = args[0];
			int count = Convert.ToInt32(args[1]);
			StreamWriter writer = new StreamWriter(args[2]);
			string format = args[3];

			List<GroupData> groups = new List<GroupData>();
			List<ContactData> contacts = new List<ContactData>();

			if (typeFile == "groups")
			{
				for (int j = 0; j<count; j++)
				{
					groups.Add(new GroupData(TestBase.GenerateRandomString(10))
					{
						Header = TestBase.GenerateRandomString(30),
						Footer = TestBase.GenerateRandomString(30)
					});
				}
			}
			else if (typeFile == "contacts")
			{			
				for (int j = 0; j<count; j++)
				{
					contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(30))
					{
						Address = TestBase.GenerateRandomString(30)
					});
				}
			}

			if (format == "xml" && typeFile == "groups")
			{
				WriteGroupsToXml(groups, writer);
			}
			else if (format == "json" && typeFile == "groups")
			{
				WriteGroupsToJson(groups, writer);
			}
			else if (format == "xml" && typeFile == "contacts")
			{
				WriteContactsToXml(contacts, writer);
			}
			else if (format == "json" && typeFile == "contacts")
			{
				WriteContactsToJson(contacts, writer);
			}
			else
			{
				Console.Out.Write("Unrecognized format: " + format);
			}

			writer.Close();

		}

		static void WriteGroupsToXml(List<GroupData> groups, StreamWriter writer)
		{
			new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
		}

		static void WriteGroupsToJson(List<GroupData> groups, StreamWriter writer)
		{
			writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
		}

		static void WriteContactsToXml(List<ContactData> contacts, StreamWriter writer)
		{
			new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
		}

		static void WriteContactsToJson(List<ContactData> contacts, StreamWriter writer)
		{
			writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
		}


	}
}

