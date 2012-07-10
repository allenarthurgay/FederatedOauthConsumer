using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
	[TestClass]
	public abstract class TestBase
	{
		[TestInitialize]
		public void SetUp()
		{
			new Registration().CreateTablesForTypes();
		}
	}
}
