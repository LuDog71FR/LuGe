/*
 * User: Ludovic Germain
 * Date: 24/07/2007
 * Time: 14:08
 */

using NUnit.Framework;
using System;
using LuGe.Common.Data.SqlObject;

namespace LuGe.Common.Data.SqlObject.Tests
{
	[TestFixture]
	public class TestLIDatabase
	{
		#region Fields
		
		private LIDatabase _database;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[SetUp]
		public void init() {
			_database = new LIDatabase("test");			
		}
		
		[Test]
		public void TestInitialize() {
			Assert.IsNotNull(_database);
			Assert.AreEqual("test", _database.Name);
			Assert.AreEqual("test", _database.Key);
			Assert.IsNotNull(_database.Tables);
			Assert.AreEqual(0, _database.Tables.Count);
		}
		
		[Test]
		public void TestAddTables() {
			LIDataTable table = new LIDataTable();
			_database.Tables.Add(table);
			Assert.AreEqual(1, _database.Tables.Count);
			Assert.IsTrue(_database.Tables.Contains(table));
		}

		#endregion
	}
}
