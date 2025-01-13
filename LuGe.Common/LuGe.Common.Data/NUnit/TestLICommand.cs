/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 09:18
 */

using NUnit.Framework;
using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using LuGe.Common.Data;

namespace LuGe.Common.Data.Tests
{
	[TestFixture]
	public class TestLICommand
	{
		#region Fields
		
		private LIConnection _connection;
		private LICommand _command;
		private int _lineIndex;

		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Release the connection.
		/// </summary>
		[TestFixtureTearDown()]
		public void TearDown() {
			if (_connection != null) _connection.Dispose();
		}
		
		[TestFixtureSetUp()]
		public void Init() {
			File.Delete("testingFiles/test.db3");

			_connection = new LIConnection("TestingDatabase");
			_connection.Connect();
			_command = _connection.Command;
			
			_command.ExecuteNonQuery(
				LICommand.ReadFile("testingFiles/CreateDatabase.sql"));
			
			Assert.IsTrue(File.Exists("testingFiles/test.db3"));
			
			_connection.Transaction.Commit();
		}
		
		[Test()]
		public void TestExecuteReaderMethodWithParamString() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmIndex = @rmIndex;");

			LIParameterCollection param = new LIParameterCollection();
			param.Add(new LIParameter("rmIndex", "123"));

			int linesCount=0;

			using (DbDataReader reader =
			       _command.ExecuteReader(sql.ToString(),
			                               param)) {

				Assert.IsTrue(reader.HasRows);

				while (reader.Read()) {
					linesCount += 1;
					Assert.AreEqual("123",
					                reader.GetString(reader.GetOrdinal("rmIndex")));
				}

			}

			Assert.AreEqual(1, linesCount);
		}

		[Test()]
		public void TestExecuteReaderMethodWithParamDouble() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmWeight LIKE @rmWeight;");

			LIParameterCollection param = new LIParameterCollection();
			param.Add(new LIParameter("rmWeight", 12.4));

			int linesCount=0;

			using (DbDataReader reader =
			       _command.ExecuteReader(sql.ToString(), param)) {

				Assert.IsTrue(reader.HasRows);

				while (reader.Read()) {
					linesCount += 1;
					Assert.AreEqual(12.4f,
					                reader.GetFloat(reader.GetOrdinal("rmWeight")),
					                0.1f);
				}

			}

			Assert.AreEqual(1, linesCount);
		}

		[Test()]
		public void TestExecuteReaderMethodWith2Param() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmWeight LIKE @rmWeight ");
			sql.Append("And rmIndex = @rmIndex;");

			LIParameterCollection param = new LIParameterCollection();
			param.Add(new LIParameter("rmWeight", 12.4));
			param.Add(new LIParameter("rmIndex", "123"));

			int linesCount=0;

			using (DbDataReader reader =
			       _command.ExecuteReader(sql.ToString(), param)) {

				Assert.IsTrue(reader.HasRows);

				while (reader.Read()) {
					linesCount += 1;
					Assert.AreEqual("123",
					                reader.GetString(reader.GetOrdinal("rmIndex")));
					Assert.AreEqual(12.4f,
					                reader.GetFloat(reader.GetOrdinal("rmWeight")),
					                0.1f);
				}

			}

			Assert.AreEqual(1, linesCount);
		}

		[Test()]
		public void TestExecuteReaderMethod() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");

			this._lineIndex = 0;

			using (DbDataReader reader =
			       _command.ExecuteReader(sql.ToString())) {

				Assert.IsTrue(reader.HasRows);

				while (reader.Read()) {
					Dictionary<string, object> values;
					values = LICommand.ReadAllValues(reader);
					this.CheckValues(values);
				}

			}
		}

		[Test()]
		public void TestExecuteActionMethod() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");

			this._lineIndex = 0;
			_command.ExecuteAction(CheckValues, sql.ToString());

		}

		private void CheckValues(Dictionary<string, object> values) {
			Assert.IsNotNull(values);

			this._lineIndex += 1;

			switch (this._lineIndex) {
				case 1:
					Assert.AreEqual(3, values.Count);
					Assert.AreEqual("123", values["rmIndex"].ToString());
					Assert.AreEqual("test 123", values["rmText"].ToString());
					Assert.AreEqual(12.4f, (float)values["rmWeight"], 0.1f);
					break;

				case 2:
					Assert.AreEqual(3, values.Count);
					Assert.AreEqual("456", values["rmIndex"].ToString());
					Assert.AreEqual("test 456", values["rmText"].ToString());
					Assert.AreEqual(68.0, values["rmWeight"]);
					break;
			}
		}

		[Test()]
		public void TestExecuteActionMethod2() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select *, rmIndex ");
			sql.Append("From RawMaterial ");

			this._lineIndex = 0;
			_command.ExecuteAction(CheckValues2, sql.ToString());
		}

		private void CheckValues2(Dictionary<string, object> values) {
			Assert.IsNotNull(values);

			this._lineIndex += 1;

			switch (this._lineIndex) {
				case 1:
					Assert.AreEqual(4, values.Count);
					Assert.AreEqual("123", values["rmIndex"].ToString());
					Assert.AreEqual("123", values["rmIndex1"].ToString());
					Assert.AreEqual("test 123", values["rmText"].ToString());
					Assert.AreEqual(12.4f, (float)values["rmWeight"], 0.1f);
					break;

				case 2:
					Assert.AreEqual(4, values.Count);
					Assert.AreEqual("456", values["rmIndex"].ToString());
					Assert.AreEqual("456", values["rmIndex1"].ToString());
					Assert.AreEqual("test 456", values["rmText"].ToString());
					Assert.AreEqual(68.0, values["rmWeight"]);
					break;
			}
		}

		[Test()]
		public void TestExecuteQueryWithEqualParameters() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmWeight > @rmWeight ");
			sql.Append("Union ");
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmWeight = @rmWeight;");

			LIParameterCollection param =
				LIParameterCollection.ExtractParameters(sql.ToString());

			Assert.AreEqual(1, param.Count);

			param["rmWeight"].Value = "12.4";

			using (DbDataReader reader =
			       _command.ExecuteReader(sql.ToString(), param)) {
				Assert.IsTrue(reader.HasRows);

				int linesCount=0;

				while (reader.Read()) {
					linesCount += 1;
				}

				Assert.AreEqual(2, linesCount);
			}
		}
		
		[Test]
		public void TestExecuteScalarMethod() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select count(*) ");
			sql.Append("From RawMaterial;");
			
			Assert.AreEqual(2, _command.ExecuteScalar(sql.ToString()));
		}

		[Test]
		public void TestReadFileMethod() {
			string sql = LICommand.ReadFile("testingFiles/CreateDatabase.sql");
			Assert.IsNotEmpty(sql);
		}

		[Test]
		public void TestExecuteDataTableMethod() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial;");

			DataTable table = _command.ExecuteDataTable(sql.ToString());
			
			Assert.IsNotNull(table);
			
			Assert.AreEqual(3, table.Columns.Count);
			Assert.AreEqual("rmIndex", table.Columns[0].ColumnName);
			Assert.AreEqual("rmText", table.Columns[1].ColumnName);
			Assert.AreEqual("rmWeight", table.Columns[2].ColumnName);

			Assert.AreEqual(2, table.Rows.Count);
			
			Assert.AreEqual("123", table.Rows[0]["rmIndex"]);
			Assert.AreEqual("test 123", table.Rows[0]["rmText"]);
			Assert.AreEqual(12.4f, (float)table.Rows[0]["rmWeight"], 0.1f);
			
			Assert.AreEqual("456", table.Rows[1]["rmIndex"]);
			Assert.AreEqual("test 456", table.Rows[1]["rmText"]);
			Assert.AreEqual(68.0, table.Rows[1]["rmWeight"]);
		}

		#endregion
	}
}
