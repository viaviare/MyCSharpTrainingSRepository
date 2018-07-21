using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressBookTests
{
	[TestFixture]
	public class GroupCreationTests : GroupTestBase
	{
		[Test, TestCaseSource ("GroupDataFromJson")]
		public void GroupCreationTest(GroupData groupData)
		{

			List<GroupData> oldGroup = GroupData.GetAll();

			app.GroupH.Create(groupData);

			oldGroup.Add(groupData);

			List<GroupData> newGroup = GroupData.GetAll();
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

		public static IEnumerable<GroupData> GroupDataFromExcel()
		{
			System.Console.Out.WriteLine("RandomGroupData " + Directory.GetCurrentDirectory());
			List<GroupData> groups = new List<GroupData>();
			Excel.Application app = new Excel.Application();
			Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), "groups.xslx"));
			Excel.Worksheet sheet = wb.ActiveSheet;
			Excel.Range range = sheet.UsedRange;

			for (int i = 1; i <= range.Rows.Count; i++)
			{
				groups.Add(new GroupData(range.Cells[i, 1].Value)
				{
					Header = range.Cells[i, 2].Value,
					Footer = range.Cells[i, 3].Value
				});
			}
			wb.Close();
			app.Visible = false;
			app.Quit();
			return groups;
		}

	}
}
