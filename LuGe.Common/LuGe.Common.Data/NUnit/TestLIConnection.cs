/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 14:22
 */

using System;
using System.Data;
using System.Data.Common;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using LuGe.Common;

namespace LuGe.Common.Data.Tests
{
	[TestFixture]
	public class TestLIConnection
	{
		#region Fields
		
		private LIConnection _connection;
		private LIObjectAccessor _accessor;

		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Release the connection.
		/// </summary>
		[TearDown()]
		public void TearDown() {
			if (_connection != null) _connection.Dispose();
		}
		
		/// <summary>
		/// Initialize the connection.
		/// </summary>
		[SetUp]
		public void Init() {
			_connection = new LIConnection("TestingDatabase");

			Assert.That(_connection, Is.Not.Null);
			Assert.That(_connection.Command, Is.Not.Null);
			Assert.That(_connection.UseTransaction, Is.True);
			Assert.That(_connection.IsConnected, Is.False);
			
			_accessor = new LIObjectAccessor(_connection);
		}
		
		/// <summary>
		/// Test the Constructor of the class.
		/// </summary>
		[Test]
		public void TestConstructor()
		{
			_connection.Dispose();
			
			_connection = new LIConnection(
				"System.Data.SQLite", 
				"Data Source=testingFiles/test.db3");
			_accessor = new LIObjectAccessor(_connection);
			
			Assert.That(_connection, Is.Not.Null);
			Assert.That(_connection.Command, Is.Not.Null);
			Assert.That(_connection.UseTransaction, Is.True);
			
			TestConnectMethod();
		}
		
		/// <summary>
		/// Test the Constructor of the class without transaction.
		/// </summary>
		[Test]
		public void TestConstructorNoTransaction()
		{
			_connection.Dispose();
			
			_connection = new LIConnection(
				"System.Data.SQLite", 
				"Data Source=testingFiles/test.db3",
				false);
			_accessor = new LIObjectAccessor(_connection);
			
			Assert.That(_connection, Is.Not.Null);
			Assert.That(_connection.Command, Is.Not.Null);
			Assert.That(_connection.UseTransaction, Is.False);
			
			bool result = _connection.Connect();
			Assert.That(result, Is.True);
			
			DbConnection db = (DbConnection)_accessor.GetProperty("Connection");
			Assert.That(db, Is.Not.Null);
			Assert.That(db.State, Is.EqualTo(ConnectionState.Open));
		}
		
		/// <summary>
		/// Test the Connect method.
		/// </summary>
		[Test]
		public void TestConnectMethod() {
			bool result = _connection.Connect();
			
			Assert.That(result, Is.True);
			Assert.That(_connection.Transaction, Is.Not.Null);
			Assert.That(_connection.IsConnected, Is.True);
			
			DbConnection db = (DbConnection)_accessor.GetProperty("Connection");
			Assert.That(db, Is.Not.Null);
			Assert.That(db.State, Is.EqualTo(ConnectionState.Open));
		}
		
		/// <summary>
		/// Test the Disconnect method.
		/// </summary>
		[Test]
		public void TestDisconnectMethod() {
			_connection.Connect();
			_connection.Disconnect();
			
			Assert.That(_connection.IsConnected, Is.False);
			
			DbConnection db = (DbConnection)_accessor.GetProperty("Connection");
			Assert.That(db.State, Is.EqualTo(ConnectionState.Closed));
		}
		
		/// <summary>
		/// Test the CreateParameter method.
		/// </summary>
		[Test]
		public void TestCreateParameterMethod() {
			DbParameter param = _connection.CreateParameter("MyParam");
			
			Assert.That(param, Is.Not.Null);
			Assert.That(param.ParameterName, Is.EqualTo("@MyParam"));
		}
		
		/// <summary>
		/// Test the CreateCommand method.
		/// </summary>
		[Test]
		public void TestCreateCommandMethod() {
			_connection.Connect();
			
			string sql = "Select * From RawMaterial";
			DbCommand query = _connection.CreateCommand(sql);
			
			Assert.IsNotNull(query);
			
			DbDataReader reader = query.ExecuteReader();
			Assert.IsNotNull(reader);
			reader.Close();
		}
		
		/// <summary>
		/// Test the ListAllConnections method.
		/// </summary>
		[Test]
		public void TestListAllConnections()
		{
			string[] names = LIConnection.ListAllConnections();
			
			Assert.IsNotNull(names);
			Assert.AreEqual(1, names.Length);
			Assert.AreEqual("TestingDatabase", names[0]);
		}
		
		/// <summary>
		/// Test the ListAllTables method.
		/// </summary>
		[Test]
		public void TestListAllTables()
		{
			bool result = _connection.Connect();
			Assert.IsTrue(result);
			
			string[] names = _connection.ListAllTables();
			
			Assert.IsNotNull(names);
			Assert.AreEqual(1, names.Length);
			Assert.AreEqual("RawMaterial", names[0]);
		}

		/// <summary>
		/// Test the CreateDataAdapter method.
		/// </summary>
		[Test]
		public void TestCreateDataAdapter()
		{
			DbDataAdapter dataAdapter = _connection.CreateDataAdapter();
			
			Assert.IsNotNull(dataAdapter);
		}

		/// <summary>
		/// Test the CreateCommandBuilder method.
		/// </summary>
		[Test]
		public void TestCreateCommandBuilder()
		{
			DbCommandBuilder commandBuilder = _connection.CreateCommandBuilder();
			
			Assert.IsNotNull(commandBuilder);
		}
		
		#endregion
	}
}
