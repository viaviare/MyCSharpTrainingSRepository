﻿using LinqToDB;

namespace mantis_project_tests
{

	public class BugtrackerBD : LinqToDB.Data.DataConnection
	{
		public BugtrackerBD() : base("Bugtracker") { }

		public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }
	}
}
