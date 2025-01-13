/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 09:30
 */

using System;
using System.Data.Common;

namespace LuGe.Common.Data
{
	/// <summary>
	/// Class representing a database transaction.
	/// </summary>
	/// <remarks>
	/// The transaction begins when the class is instanciate and
	/// ends when the connection is closed.
	/// </remarks>
	public class LITransaction : IDisposable
	{
		#region Fields
		
		private DbTransaction _transaction; // Real transaction.
		private DbConnection _connection; // Real connection to the database.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LITransaction">LITransaction</see> class.
		/// </summary>
		/// <param name="connection">Connection to used.</param>
		internal LITransaction(DbConnection connection) {
			if (connection == null) throw new ArgumentNullException("connection");
			
			_connection = connection;
			Begin();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the database transaction.
		/// </summary>
		internal DbTransaction Transaction {
			get { return _transaction; }
		}

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Begin the transaction.
		/// </summary>
		private void Begin() {
			_transaction =	_connection.BeginTransaction();
		}
		
		/// <summary>
		/// End the transaction when closing the database.
		/// </summary>
		internal void End() {
			_transaction.Rollback();
		}
		
		/// <summary>
		/// Saves in the database all changes made during the transaction
		/// and begin a new one.
		/// </summary>
		public void Commit() {
			_transaction.Commit();
			Begin();
		}
		
		/// <summary>
		/// Cancel all changes made during the transaction
		/// and begin a new one.
		/// </summary>
		public void Rollback() {
			_transaction.Rollback();
			Begin();
		}
		
		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
		/// <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources
				if (_transaction != null) _transaction.Dispose();
			}

			// free native resources
		}

		/// <summary>
		/// Releases unmanaged and managed resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		#endregion
	}
}
