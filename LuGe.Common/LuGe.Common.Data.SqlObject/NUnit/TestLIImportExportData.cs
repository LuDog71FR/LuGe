/*
 * User: lgermain
 * Date: 27/06/2008 10:09
 */

using System;
using System.IO;
using System.Data;
using System.Data.Common;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using LuGe.Common.Data.SqlObject;

namespace LuGe.Common.Data.SqlObject.Tests
{
	/// <summary>
	/// Test the LIImportExportData class.
	/// </summary>
	[TestFixture]
	public class TestLIImportExportData
	{
		#region Fields
		
		private const string FileName = "testingFiles/RowMaterial.csv";
		private const string ResultFileName = "testingFiles/RowMaterial_result.csv";
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		private DataTable _table;
		private LIImportExportData _importExport;
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Initialize the table and fill it with specific rows.
		/// </summary>
		private void InitTable()
		{
			_table = new DataTable("RowMaterial");
			
			_table.PrimaryKey = new DataColumn[] {
				_table.Columns.Add("rmIndex", typeof(string))};
			_table.Columns.Add("rmText", typeof(string));
			_table.Columns.Add("rmWeight", typeof(string));
			
			_table.Rows.Add(new object[] {"123", "test 123", 12.4});
			_table.Rows.Add(new object[] {"456", "test 456", 68.0});
		}
		
		/// <summary>
		/// Initialize the LIImportExportData object.
		/// </summary>
		[SetUp()]
		public void Init()
		{
			InitTable();

			_importExport = new LIImportExportData(_table);

			Assert.IsNotNull(this._importExport);
			Assert.IsNotNull(this._importExport.Table);
			Assert.AreEqual(this._table, this._importExport.Table);
		}

		/// <summary>
		/// Test the export method.
		/// </summary>
		[Test()]
		public void TestExport()
		{
			_importExport.Export(FileName);

			Assert.IsTrue(File.Exists(FileName));
			Assert.AreEqual(File.ReadAllText(ResultFileName), 
			                File.ReadAllText(FileName));

		}

		/// <summary>
		/// Test the import method.
		/// </summary>
		[Test()]
		public void TestImport()
		{
			_table.Rows.Clear();
			_importExport.Import(ResultFileName);

			Assert.AreEqual(2, _table.Rows.Count);

			DataRow row;
			
			row = _table.Rows.Find("123");
			Assert.IsNotNull(row);
			Assert.AreEqual("123", row["rmIndex"]);
			Assert.AreEqual("test 123", row["rmText"]);
			Assert.AreEqual("12,4", row["rmWeight"]);

			row = _table.Rows.Find("456");
			Assert.IsNotNull(row);
			Assert.AreEqual("456", row["rmIndex"]);
			Assert.AreEqual("test 456", row["rmText"]);
			Assert.AreEqual("68", row["rmWeight"]);
		}
		
		#endregion
	}
}
