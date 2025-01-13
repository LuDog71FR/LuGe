/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 09:34
 */

using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;

namespace LuGe.Common.Data
{
	/// <summary>
	/// Class representing a database access.
	/// </summary>
	public class LIConnection : IDisposable
	{
		#region Fields
		
		private string _providerInvariantName; // Invariant name of the provider used for the connection.
		private string _connectionString; // Connection string used to connect to the database.
		
		private DbProviderFactory _providerFactory; // Provider used to connect to the database.
		private DbConnection _connection; // Real connection to the database.
		
		private LITransaction _transaction; // Transaction used by the connection.
		private LICommand _command; // Command used to execute query.
		
		private bool _useTransaction; // A value indicating if a transaction must be used.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIConnection">LIConnection</see> class.
		/// </summary>
		/// <param name="providerInvariantName">Invariant name of the provider.</param>
		/// <param name="connectionString">Connection string.</param>
		/// <param name="useTransaction">A value indicating if a transaction 
		/// must be used.</param>
		public LIConnection(
			string providerInvariantName,
			string connectionString,
			bool useTransaction)
		{
			if (string.IsNullOrEmpty(providerInvariantName)) throw new ArgumentNullException("providerInvariantName");
			if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException("connectionString");
			if (LIProvider.Exists(providerInvariantName) == false) throw new ArgumentException("Unknown provider");
			
			_connectionString = connectionString;
			_providerInvariantName = providerInvariantName;
			_useTransaction = useTransaction;
			
			Initialize();
		}
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIConnection">LIConnection</see> class.
		/// </summary>
		/// <param name="providerInvariantName">Invariant name of the provider.</param>
		/// <param name="connectionString">Connection string.</param>
		public LIConnection(
			string providerInvariantName,
			string connectionString) : this(providerInvariantName, connectionString, true)
		{
		}
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIConnection">LIConnection</see> class.
		/// </summary>
		/// <param name="connectionName">Name of the connection define
		/// in the configuration file of the application.</param>
		/// <param name="useTransaction">A value indicating if a transaction 
		/// must be used.</param>
		public LIConnection(
			string connectionName,
			bool useTransaction)
		{
			if (string.IsNullOrEmpty(connectionName)) throw new ArgumentNullException("connectionName");
			
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionName];
			
			if (LIProvider.Exists(settings.ProviderName) == false) throw new ArgumentException("Unknown provider");
			
			_connectionString = settings.ConnectionString;
			_providerInvariantName = settings.ProviderName;
			_useTransaction = useTransaction;
			
			Initialize();
		}
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIConnection">LIConnection</see> class.
		/// </summary>
		/// <param name="connectionName">Name of the connection define
		/// in the configuration file of the application.</param>
		public LIConnection(string connectionName) : this(connectionName, true)
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the transaction used by the connection.
		/// </summary>
		public LITransaction Transaction 
		{
			get { return _transaction; }
		}
		
		/// <summary>
		/// Gets a value indicating if a transaction must be used.
		/// </summary>
		public bool UseTransaction 
		{
			get { return _useTransaction; }
		}
		
		/// <summary>
		/// Gets the command used to execute query.
		/// </summary>
		public LICommand Command 
		{
			get { return _command; }
		}
		
		/// <summary>
		/// Gets a value indicating if the connection is opened.
		/// </summary>
		public bool IsConnected
		{
		    get 
		    {
		        if (_connection == null) return false;
		        return (_connection.State == ConnectionState.Open);
		    }
		}
		
		/// <summary>
		/// Gets the connection.
		/// </summary>
		internal DbConnection Connection 
		{
			get { return _connection; }
		}
				
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Initialize data objects used for the connection.
		/// </summary>
		private void Initialize()
		{
			_providerFactory = DbProviderFactories.GetFactory(_providerInvariantName);
			_command = new LICommand(this);
		}
		
		/// <summary>
		/// List all connections available
		/// in the app.config file of the application.
		/// </summary>
		/// <returns>An array of string containing
		/// all connection names.</returns>
		public static string[] ListAllConnections()
		{
			List<string> names = new List<string>();
			Configuration config = ConfigurationManager.OpenExeConfiguration(
				ConfigurationUserLevel.None);
			
			for(int i=0; i < config.ConnectionStrings.ConnectionStrings.Count ;i++)
			{
				ConnectionStringSettings setting = config.ConnectionStrings.ConnectionStrings[i];
				
				if (setting.ElementInformation.IsPresent == true)
				{
					names.Add(setting.Name);
				}
			}
			
			return names.ToArray();
		}
		
		/// <summary>
		/// List all the tables available
		/// in the database.
		/// </summary>
		/// <returns>An array of string containing
		/// all tables names.</returns>
		/// <remarks>
		/// If the connection is associated with a transaction,
		/// executing ListAllTables calls may cause some providers
		/// to throw an InvalidOperationException. The method then
		/// returns an empty array.
		/// </remarks>
		public string[] ListAllTables()
		{
			string[] restrictions = new string[] {_connection.Database, null, null};
			List<string> tables = new List<string>();
			DataTable tableSchema;
			
			try
			{
				tableSchema = _connection.GetSchema("Tables", restrictions);
			}
			catch (InvalidOperationException)
			{
				return tables.ToArray();
			}
			
			foreach(DataRow ligne in tableSchema.Rows)
			{
				tables.Add(ligne["TABLE_NAME"].ToString());
			}
			
			return tables.ToArray();
		}
		
		/// <summary>
		/// Connect to the database.
		/// </summary>
		/// <returns>True if the connection is done; otherwise false.</returns>
		/// <remarks>
		/// If the connection is already made then nothing is done and it returns true.
		/// </remarks>
		public bool Connect()
		{
			if ((_connection != null) &&
			    (_connection.State == ConnectionState.Open)) return true;
			
			_connection = _providerFactory.CreateConnection();
			_connection.ConnectionString = _connectionString;
			_connection.Open();
			
			if (_connection.State != ConnectionState.Open) return false;
			
			if (UseTransaction)	_transaction = new LITransaction(Connection);
			
			return true;
		}
		
		/// <summary>
		/// Disconnect from the database.
		/// </summary>
		/// <param name="mustCommit">Indicates if a commit must be perform
		/// before disconnecting from the database.</param>
		public void Disconnect(bool mustCommit)
		{
			if (_connection == null) return;
			if (_connection.State != ConnectionState.Open) return;
			
			if (UseTransaction)
			{
				if (mustCommit) _transaction.Commit();
				_transaction.End();
			}
			
			_connection.Close();
		}
		
		/// <summary>
		/// Disconnect the database and rollback the transaction.
		/// </summary>
		public void Disconnect()
		{
			Disconnect(false);
		}
		
		/// <summary>
		/// Creates command to execute against a data source.
		/// </summary>
		/// <param name="sql">SQL query to execute.</param>
		/// <returns>The new database command object.</returns>
		public DbCommand CreateCommand(string sql)
		{
			DbCommand cmd = _providerFactory.CreateCommand();

			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			cmd.Connection = _connection;
			if (UseTransaction) cmd.Transaction = _transaction.Transaction;
			
			return cmd;
		}
		
		/// <summary>
		/// Creates a command parameter.
		/// </summary>
		/// <param name="name">Command parameter name.</param>
		/// <returns>The new command parameter object.</returns>
		public DbParameter CreateParameter(string name)
		{
			DbParameter param = _providerFactory.CreateParameter();
			param.ParameterName = string.Concat("@", name);

			return param;
		}
		
		/// <summary>
		/// Create a command builder.
		/// </summary>
		/// <returns>The new command builder object.</returns>
		public DbCommandBuilder CreateCommandBuilder()
		{
			DbCommandBuilder commandBuilder = _providerFactory.CreateCommandBuilder();
			
			return commandBuilder;
		}
		
		/// <summary>
		/// Create a data adapter.
		/// </summary>
		/// <returns>The new data adapter object.</returns>
		public DbDataAdapter CreateDataAdapter()
		{
			DbDataAdapter adapter = _providerFactory.CreateDataAdapter();
			
			return adapter;
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
				if (_connection != null) _connection.Dispose();
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
