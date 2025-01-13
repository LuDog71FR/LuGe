/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 16:14
 */

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace LuGe.Common.Data.Tests
{
	[TestFixture]
	public class TestLITransaction
	{
		#region Fields
		
		private LIConnection _connection;
		private LITransaction _transaction;

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
		
		[SetUp()]
		public void Init() {
			_connection = new LIConnection("TestingDatabase");
			_connection.Connect();
			this._transaction = _connection.Transaction;

			Assert.That(_transaction, Is.Not.Null);
		}

		[Test()]
		public void TestCommitMethod() {
			this._transaction.Commit();
		}

		[Test()]
		public void TestRollbackMethod() {
			this._transaction.Rollback();
		}

		#endregion
	}
}
