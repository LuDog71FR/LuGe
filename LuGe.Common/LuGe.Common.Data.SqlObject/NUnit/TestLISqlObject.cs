/*
 * User: Ludovic Germain
 * Date: 24/07/2007
 * Time: 15:08
 */

using NUnit.Framework;
using System;
using LuGe.Common;
using LuGe.Common.Data.SqlObject;

namespace LuGe.Common.Data.SqlObject.Tests
{
	[TestFixture]
	public class TestLISqlObject
	{
		#region Fields
		
		private LIConnection _connection;
		private MockRawMaterial _dataObject;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[TearDown]
		public void TearDown() {
			if (_connection != null) {
				_connection.Disconnect();
				_connection.Dispose();
			}
		}
		
		[SetUp]
		public void Init() {
			_connection = new LIConnection("TestingDatabase");
			_connection.Connect();
			
			this._dataObject = new MockRawMaterial(_connection);
		}
		
		[Test]
		public void TestExistMethod() {
			this._dataObject.RmIndex = "123";
			Assert.IsTrue(this._dataObject.Exist());
			
			this._dataObject.RmIndex = "999";
			Assert.IsFalse(this._dataObject.Exist());
		}
		
		[Test]
		public void TestLoadMethod() {
			this._dataObject.RmIndex = "123";
			Assert.IsTrue(this._dataObject.Load());
			
			Assert.AreEqual("123", this._dataObject.RmIndex);
			Assert.AreEqual("test 123", this._dataObject.RmText);
			Assert.AreEqual(12.4f, this._dataObject.RmWeight, 0.1f);
			
			this._dataObject.RmIndex = "999";
			Assert.IsFalse(this._dataObject.Load());
		}

		[Test]
		public void TestSaveMethodInsertSql() {
			this._dataObject.RmIndex = "789";
			this._dataObject.RmText = "my new row";
			this._dataObject.RmWeight = 6.9F;
			
			Assert.IsTrue(this._dataObject.Save());
			
			this._dataObject.RmIndex = "789";
			Assert.IsTrue(this._dataObject.Load());
			
			Assert.AreEqual("789", this._dataObject.RmIndex);
			Assert.AreEqual("my new row", this._dataObject.RmText);
			Assert.AreEqual(6.9F, this._dataObject.RmWeight);
		}

		[Test]
		public void TestSaveMethodUpdateSql() {
			this.TestSaveMethodInsertSql();
			
			this._dataObject.RmText = "Update row";
			this._dataObject.RmWeight = 20.1F;
			
			Assert.IsTrue(this._dataObject.Save());
			
			this._dataObject.RmIndex = "789";
			Assert.IsTrue(this._dataObject.Load());
			
			Assert.AreEqual("789", this._dataObject.RmIndex);
			Assert.AreEqual("Update row", this._dataObject.RmText);
			Assert.AreEqual(20.1F, this._dataObject.RmWeight);
		}

		[Test]
		public void TestDeleteMethod() {
			this.TestSaveMethodInsertSql();
			
			Assert.IsTrue(this._dataObject.Delete());
			
			this._dataObject.RmIndex = "789";
			Assert.IsFalse(this._dataObject.Load());
		}

		[Test]
		public void TestListMethod() {
			object[] rows = this._dataObject.List();
			
			Assert.IsNotNull(rows);
			Assert.AreEqual(2, rows.Length);
			
			Assert.IsInstanceOfType(typeof(MockRawMaterial), rows[0]);
			
			MockRawMaterial item = (MockRawMaterial)rows[0];
			Assert.AreEqual("123", item.RmIndex);
			Assert.AreEqual("test 123", item.RmText);
			Assert.AreEqual(12.4f, item.RmWeight, 0.1f);
			
			Assert.IsInstanceOfType(typeof(MockRawMaterial), rows[1]);
			
			item = (MockRawMaterial)rows[1];
			Assert.AreEqual("456", item.RmIndex);
			Assert.AreEqual("test 456", item.RmText);
			Assert.AreEqual(68.0, item.RmWeight);
		}

		[Test]
		public void TestListMethodWithFilter() {
			object[] rows = this._dataObject.List("rmIndex = '123'");
			
			Assert.IsNotNull(rows);
			Assert.AreEqual(1, rows.Length);
			
			Assert.IsInstanceOfType(typeof(MockRawMaterial), rows[0]);
			
			MockRawMaterial item = (MockRawMaterial)rows[0];
			Assert.AreEqual("123", item.RmIndex);
			Assert.AreEqual("test 123", item.RmText);
			Assert.AreEqual(12.4f, item.RmWeight, 0.1f);	
		}
		
		#endregion
	}
}
