using System;
using System.Linq;
using LinqToDB.Mapping;
using System.Collections.Generic;

namespace mantis_projects_tests
{
	[Table(Name = "mantis_project_table")]
	public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
	{

		[Column(Name = "name")]
		public string ProjectName { get; set; }

		[Column(Name = "id"), PrimaryKey, Identity]
		public string Id { get; set; }


		

		public bool Equals(ProjectData other)
		{
			if (Object.ReferenceEquals(other, null))
			{ return false; }
			if (Object.ReferenceEquals(this, other))
			{ return true; }
			return ProjectName == other.ProjectName;
		}

		public override int GetHashCode()
		{
			return ProjectName.GetHashCode();
		}

		public int CompareTo(ProjectData other)
		{
			if (Object.ReferenceEquals(other, null))
			{ return 1; }

			return ProjectName.CompareTo(other.ProjectName);
		}


		

		public static List<ProjectData> GetProjectListFromBD()
		{
			using (BugtrackerBD db = new BugtrackerBD())
			{
				return (from p in db.Projects select p).ToList();
			}
		}
	}
}
