/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 14:03
 */

using NUnit.Framework;
using System;
using LuGe.Common.Data.SqlObject;

namespace LuGe.Common.Data.SqlObject.Tests
{
	[TestFixture]
	public class TestLIDataTable
	{
		#region Fields
		
		private LIDataTable _table;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[SetUp]
		public void Init() {
			this._table = new LIDataTable("RowMaterial");
		}
		
		[Test]
		public void TestInstanciate() {
			Assert.IsNotNull(this._table);
			Assert.AreEqual("RowMaterial", this._table.Key);
			Assert.AreEqual("RowMaterial", this._table.Name);
			Assert.IsNotNull(this._table.Fields);
		}
		
		[Test]
		public void TestAddField() {
			LIDataField field = new LIDataField("rmIndex");
			
			this._table.Fields.Add(field);
			
			Assert.AreEqual(1, this._table.Fields.Count);
			Assert.IsTrue(this._table.Fields.Contains(field));
		}

		[Test]
		public void TestAddPrimaryKeyField() {
			LIDataField field = new LIDataField("rmIndex");
			field.PrimaryKey = true;
			
			this._table.Fields.Add(field);
			
			Assert.AreEqual(1, this._table.KeyFields.Count);
			Assert.IsTrue(this._table.KeyFields.Contains(field));
		}

		[Test]
		public void TestCopyMethod() {
			LIDataField field = new LIDataField("rmIndex");
			
			this._table.Fields.Add(field);
			
			LIDataTable table = new LIDataTable();
			table.Copy(this._table);
			
			Assert.AreEqual(this._table.Name, table.Name);
			Assert.AreEqual(1, table.Fields.Count);
			Assert.IsTrue(table.Fields.Contains(field));
		}

		[Test]
		public void TestCloneMethod() {
			LIDataField field = new LIDataField("rmIndex");
			
			this._table.Fields.Add(field);
			
			LIDataTable table = (LIDataTable)this._table.Clone();
			
			Assert.AreEqual(this._table.Name, table.Name);
			Assert.AreEqual(1, table.Fields.Count);
			Assert.IsTrue(table.Fields.Contains(field));
		}

		#endregion
	}
}
