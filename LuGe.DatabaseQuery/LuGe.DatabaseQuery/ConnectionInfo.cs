/*
 * User: lgermain
 * Date: 25/11/2008 09:57
 */

using System;
using LuGe.Common.Collection;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// All informations needed for a database connection.
	/// </summary>
	public class ConnectionInfo : IKeyedItem
	{
		
		#region Fields
		
		private string _name; // name of the connection.
		private string _providerName; // name of the provider.
		private string _connectionString; // connection string.
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ConnectionInfo()
		{
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets the key that identify the connection in a keyed collection.
		/// </summary>
		/// <remarks>The key is the name of the connection.</remarks>
		public string Key
		{
			get { return Name; }
		}
		
		/// <summary>
		/// Gets or sets the name of the connection.
		/// </summary>
		public string Name 
		{
			get { return _name; }
			set { _name = value; }
		}
		
		/// <summary>
		/// Get or sets the name of the provider.
		/// </summary>
		public string ProviderName 
		{
			get { return _providerName; }
			set { _providerName = value; }
		}
		
		/// <summary>
		/// Get or sets the connection string.
		/// </summary>
		public string ConnectionString 
		{
			get { return _connectionString; }
			set { _connectionString = value; }
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Returns the name of the connection.
		/// </summary>
		/// <returns>The name of the connection.</returns>
		public override string ToString()
		{
			return this.Name;
		}
		
		#endregion

	}
}
