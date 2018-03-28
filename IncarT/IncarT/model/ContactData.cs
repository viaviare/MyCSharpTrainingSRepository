﻿using System;
using System.Text.RegularExpressions;
using System.Linq;
using LinqToDB.Mapping;
using System.Collections.Generic;


namespace WebAddressBookTests
	{
	[Table(Name = "addressbook")]
	public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
	{
		private string bday = "1";
		private string bmonth = "March";
		private string byear = "2008";
		private string aday = "1";
		private string amonth = "March";
		private string ayear = "2008";
		private string allphones;
		private string allinfo;


		public ContactData()
		{}

		public ContactData(string firstname, string lastname)
		{
			FirstName = firstname;
			LastName = lastname;
		}
		[Column(Name = "firstname")]
		public string FirstName { get; set; }

		[Column(Name = "lastname")]
		public string LastName { get; set; }

		[Column(Name = "home")]
		public string Home { get; set; }

		[Column(Name = "mobile")]
		public string Mobile { get; set; }

		[Column(Name = "work")]
		public string Work { get; set; }

		[Column(Name = "address")]
		public string Address { get; set; }

		[Column(Name = "id"), PrimaryKey, Identity]
		public string Id { get; set; }

		[Column(Name = "deprecated")]
		public string Deprecated { get; set; }

		public string AllPhones
		{
			get
			{
				if (allphones != null)
				{
					return allphones;
				}
				else
				{
					return (ClearUp(Home) + ClearUp(Mobile) + ClearUp(Work)).Trim();
				}
			}
			set { allphones = value; }
		}

		private string ClearUp(string phone)
		{
			if (phone == null || phone == "")
			{
				return phone = "";
			}
			return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
		}

		public string AllInfo
		{
			get
			{
				if (allinfo != null)
				{
					return allinfo;
				}
				return (FirstName + Convert.ToChar(32) + LastName + "\r\n"
					+  Address + "\r\n" + Home + Mobile + Work).Trim();

			}
			set
			{
				allinfo = value;
			}
		}

		public string Middlename { get; set; }
		public string Nickname { get; set; }
		public string Title { get; set; }
		public string Company { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public string Email2 { get; set; }
		public string Email3 { get; set; }
		public string Homepage { get; set; }
		public string Address2 { get; set; }
		public string Phone2 { get; set; }
		public string Notes { get; set; }

		public string Bday
		{
			get { return bday; }
			set { bday = value; }
		}
		public string Bmonth
		{
			get { return bmonth; }
			set { bmonth = value; }
		}
		public string Byear
		{
			get { return byear; }
			set { byear = value; }
		}
		public string Aday
		{
			get { return aday; }
			set { aday = value; }
		}
		public string Amonth
		{
			get { return amonth; }
			set { amonth = value; }
		}
		public string Ayear
		{
			get { return ayear; }
			set { ayear = value; }
		}

		public bool Equals(ContactData other)
		{
			if (Object.ReferenceEquals(other, null))
			{ return false; }
			if (Object.ReferenceEquals(this, other))
			{ return true; }
			return LastName == other.LastName && FirstName == other.FirstName;
		}

		public override int GetHashCode()
		{
			return (LastName + FirstName).GetHashCode();
		}

		public override string ToString()
		{
			return "LastName = " + LastName.ToString() + " FirstName = " + FirstName.ToString();
		}

		public int CompareTo(ContactData other)
		{
			if (Object.ReferenceEquals(other, null))
			{ return 1; }

			return (LastName + FirstName).CompareTo(other.LastName + other.FirstName);
		}

		public static List<ContactData> GetAll()
		{
			using (AddressbookDB db = new AddressbookDB())
			{
				return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
			}
		}

		public List<GroupData> GetGroups()
		{
			using (AddressbookDB db = new AddressbookDB())
			{
				return (from q in db.Groups
						from g in db.GCR.Where(
					p => p.ContactId == Id && p.GroupId == q.Id)
						select q).ToList();
			}
		}

	}
}
