﻿using System;
using NUnit.Framework;
using System.Text;

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

		public static Random rnd = new Random();

		public static string GenerateRandomString(int max)
		{

			int l = Convert.ToInt32(rnd.NextDouble() * max);
			StringBuilder builder = new StringBuilder();
			for (int j = 0; j < l; j++)
			{
				builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
			}
			return builder.ToString();
		}
	}


}

