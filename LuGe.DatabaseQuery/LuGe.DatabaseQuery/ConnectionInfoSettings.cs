/*
 * User: lgermain
 * Date: 25/11/2008 09:57
 */

using System;
using LuGe.Common.Collection;
using LuGe.Common;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Settings of all information connections.
	/// </summary>
	public class ConnectionInfoSettings: IConfigurationFile
	{
		
		#region Fields
		
		private LIKeyedCollection<ConnectionInfo> _connections; // all connections.
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ConnectionInfoSettings()
		{
			_connections = new LIKeyedCollection<ConnectionInfo>();
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets or sets all connections.
		/// </summary>
		public LIKeyedCollection<ConnectionInfo> Connections 
		{
			get { return _connections; }
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Load the default values of all settings.
		/// </summary>
		public void LoadDefault()
		{
			ConnectionInfo connection = new ConnectionInfo();
			connection.Name = "Sample database (SQLite)";
			connection.ProviderName = "System.Data.SQLite";
			connection.ConnectionString = "Data Source=sample_database.db3";
			this.Connections.Add(connection);
		}
		
		#endregion

	}
}
