/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 15:20
 */

using NUnit.Framework;
using System;
using LuGe.Common;
using LuGe.Common.Data.SqlObject;

namespace LuGe.Common.Data.SqlObject.Tests
{
	[TestFixture]
	public class TestAttributeExtractor
	{
		#region Fields
		
		private LIConnection _connection;
		private MockRawMaterial _dataObject;
		private LIObjectAccessor _accessor;
		
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
			this._dataObject.RmIndex = "1";
			this._dataObject.RmText = "bread";
			this._dataObject.RmWeight = 12.4F;
			
			this._accessor = new LIObjectAccessor(
				"LuGe.Common.Data.SqlObject.AttributeExtractor, LuGe.Common.Data.SqlObject", 
				this._dataObject);
		}
		
		[Test]
		public void TestInitialize() {
			Assert.IsNotNull(this._accessor);
			Assert.AreEqual(this._accessor.GetProperty("ObjectData"), 
				                this._dataObject);
		}
		
		[Test]
		public void TestObjectTypeProperty() {
			Assert.AreEqual(Type.GetType("LuGe.Common.Data.SqlObject.Tests.MockRawMaterial"),
			                this._accessor.GetProperty("ObjectType"));
		}

		[Test]
		public void TestTableProperty() {
			Assert.IsNotNull(this._accessor.GetProperty("Table"));
			
			LIDataTable table = (LIDataTable)this._accessor.GetProperty("Table");
			
			Assert.IsNotNull(table);
			Assert.AreEqual("RawMaterial", table.Name);
			
			Assert.AreEqual(3, table.Fields.Count);
			Assert.IsTrue(table.Fields.Contains("rmIndex"));
			Assert.IsTrue(table.Fields.Contains("rmText"));
			Assert.IsTrue(table.Fields.Contains("rmWeight"));
			
			Assert.AreEqual(1, table.KeyFields.Count);
			Assert.IsTrue(table.KeyFields.Contains("rmIndex"));
		}

		[Test]
		public void TestFieldsInTable() {
			LIDataTable table = (LIDataTable)this._accessor.GetProperty("Table");
			Assert.IsNotNull(table);
			
			LIDataField field = table.Fields["rmIndex"];
			Assert.AreEqual("rmIndex", field.Name);
			LIObjectAccessor accessor = new LIObjectAccessor(field);
			Assert.AreEqual("_rmIndex", accessor.GetProperty("VariableName"));
			Assert.IsTrue(field.PrimaryKey);
			
			field = table.Fields["rmText"];
			Assert.AreEqual("rmText", field.Name);
			accessor = new LIObjectAccessor(field);
			Assert.AreEqual("_rmText", accessor.GetProperty("VariableName"));
			Assert.IsFalse(field.PrimaryKey);
			
			field = table.Fields["rmWeight"];
			Assert.AreEqual("rmWeight", field.Name);
			accessor = new LIObjectAccessor(field);
			Assert.AreEqual("_rmWeight", accessor.GetProperty("VariableName"));
			Assert.IsFalse(field.PrimaryKey);
		}

		[Test]
		public void TestExtractValuesMethod() {
			this._accessor.Invoke("ExtractValues");
			
			LIDataTable table = (LIDataTable)this._accessor.GetProperty("Table");
			Assert.IsNotNull(table);
			
			Assert.AreEqual("1", table.Fields["rmIndex"].Value);
			Assert.AreEqual("bread", table.Fields["rmText"].Value);
			Assert.AreEqual(12.4f, (float)table.Fields["rmWeight"].Value, 0.1f);
		}

		[Test]
		public void TestSetValuesMethod() {
			LIDataTable table = (LIDataTable)this._accessor.GetProperty("Table");
			Assert.IsNotNull(table);
			
			table.Fields["rmIndex"].Value = "2";
			table.Fields["rmText"].Value = "rod";
			table.Fields["rmWeight"].Value = 18.61F;
			
			this._accessor.Invoke("SetValues");
			
			Assert.AreEqual("2", this._dataObject.RmIndex);
			Assert.AreEqual("rod", this._dataObject.RmText);
			Assert.AreEqual(18.61F, this._dataObject.RmWeight);
		}

		#endregion
	}
}
