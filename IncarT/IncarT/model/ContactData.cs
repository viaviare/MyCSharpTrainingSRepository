using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
	{
	public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
	{
		private string bday = "1";
		private string bmonth = "March";
		private string byear = "2008";
		private string aday = "1";
		private string amonth = "March";
		private string ayear = "2008";

		public ContactData(string firstname, string lastname)
		{
			FirstName = firstname;
			LastName = lastname;
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Middlename { get; set; }

		public string Nickname { get; set; }

		public string Title { get; set; }

		public string Company { get; set; }

		public string Address { get; set; }

		public string Home { get; set; }

		public string Mobile { get; set; }

		public string Work { get; set; }

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
			return LastName + FirstName == other.LastName + other.FirstName;
		}

		public override int GetHashCode()
		{
			return LastName.GetHashCode();
		}

		public override string ToString()
		{
			return "LastName = " + LastName.ToString() + " FirstName = " + FirstName.ToString();
		}

		public int CompareTo(ContactData other)
		{
			if (Object.ReferenceEquals(other, null))
			{ return 1; }

			return LastName.CompareTo(other.LastName);
		}

	}
}
