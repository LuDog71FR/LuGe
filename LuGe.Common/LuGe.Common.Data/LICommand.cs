/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 11:35
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Reflection;
using System.Globalization;
using LuGe.Common.Collection;

namespace LuGe.Common.Data
{
	/// <summary>
	/// Represents a database command
	/// that allow execution of sql queries.
	/// </summary>
	public class LICommand
	{
		#region Delegates

		/// <summary>
		/// Delegate to use with the
		/// <see cref="ExecuteAction(ActionLine, string)">ExecuteAction</see>
		/// method.
		/// </summary>
		public delegate void ActionLine(Dictionary<string, object> values);

		#endregion

		#region Fields
		
		private LIConnection _connection; // Connection to the database.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LICommand">LICommand</see> class.
		/// </summary>
		/// <param name="connection">Connection to used.</param>
		internal LICommand(LIConnection connection) 
		{
			if (connection == null) throw new ArgumentNullException("connection");
			
			_connection = connection;
		}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Create the databse command from the sql query specified
		/// with the parameters specified.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <param name="parameters">Parameters for the sql query.</param>
		/// <returns>The new database command object.</returns>
		private DbCommand BuildCommand(string sql,
		                               LIParameterCollection parameters) 
		{
			if (string.IsNullOrEmpty(sql)) throw new ArgumentNullException("sql");
			if (parameters == null) throw new ArgumentNullException("parameters");

			DbCommand cmd = _connection.CreateCommand(sql);
			int i = 1;

			foreach (LIParameter valParam in parameters) 
			{
				DbParameter param = _connection.CreateParameter(valParam.Name);

				param.DbType = ConvertType(valParam.Value.GetType());
				param.Value = valParam.Value;

				cmd.Parameters.Add(param);

				i += 1;
			}

			return cmd;
		}

		/// <summary>
		/// Convert a system type into a more specific database type.
		/// </summary>
		/// <param name="myType">System type to convert.</param>
		/// <returns>Database type.</returns>
		public DbType ConvertType(System.Type myType) 
		{
			if (myType == null) throw new ArgumentNullException("myType");

			DbParameter param = _connection.CreateParameter("test");

			System.ComponentModel.TypeConverter tc;
			tc = System.ComponentModel.TypeDescriptor.GetConverter(param.DbType);

			if (myType == typeof(DBNull))
			{
			    return DbType.String;
			}
			
			if (tc.CanConvertFrom(myType)) 
			{
				param.DbType = (DbType)tc.ConvertFrom(myType.Name);
			}
			else 
			{
				try 
				{
					param.DbType = (DbType)tc.ConvertFrom(myType.Name);
				}
				catch (Exception) 
				{
					throw new InvalidOperationException(
				        "Can't convert the parameter type into a DbType.");
				}
			}

			return param.DbType;
		}

		/// <summary>
		/// Read a file and return the sql query contained in it.
		/// </summary>
		/// <remarks>The file must be encoded in UTF8 format.</remarks>
		/// <param name="sqlFile">Source file containing the sql query.</param>
		/// <returns>SQL query read in the source file.</returns>
		public static string ReadFile(string sqlFile) 
		{
			if (string.IsNullOrEmpty(sqlFile)) throw new ArgumentNullException("sqlFile");
			if (!File.Exists(sqlFile)) throw new FileNotFoundException(sqlFile);

			string sql;
			sql = File.ReadAllText(sqlFile, Encoding.UTF8);

			return sql;
		}

		/// <summary>
		/// Execute the sql query specified with the parameters specified
		/// and returns the first column of the first row in the
		/// result set returned by the query.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <param name="parameters">Parameters for the sql query.</param>
		/// <returns>The first column of the first row in the result set.</returns>
		public object ExecuteScalar(string sql,
		                            LIParameterCollection parameters) 
		{
			DbCommand cmd = BuildCommand(sql, parameters);

			return cmd.ExecuteScalar();
		}

		/// <summary>
		/// Execute the sql query specified
		/// and returns the first column of the first row in the
		/// result set returned by the query.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <returns>The first column of the first row in the result set.</returns>
		public object ExecuteScalar(string sql) 
		{
			return ExecuteScalar(sql, new LIParameterCollection());
		}

		/// <summary>
		/// Execute the sql query specified with the parameters specified
		/// and returns a DbDataReader.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <param name="parameters">Parameters for the sql query.</param>
		/// <returns>A DbDataReader object.</returns>
		public DbDataReader ExecuteReader(string sql,
		                                  LIParameterCollection parameters) 
		{
			DbCommand cmd = BuildCommand(sql, parameters);

			return cmd.ExecuteReader();
		}

		/// <summary>
		/// Execute the sql query specified
		/// and returns a DbDataReader.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <returns>A DbDataReader object.</returns>
		public DbDataReader ExecuteReader(string sql) 
		{
			return ExecuteReader(sql, new LIParameterCollection());
		}

		/// <summary>
		/// Execute the sql query specified with the parameters specified
		/// and returns a DataTable.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <param name="parameters">Parameters for the sql query.</param>
		/// <returns>A DataTable object.</returns>
		public DataTable ExecuteDataTable(string sql,
		                                  LIParameterCollection parameters) 
		{
			DbCommand cmd = BuildCommand(sql, parameters);

			return ConvertReaderToTable(cmd.ExecuteReader());
		}

		/// <summary>
		/// Execute the sql query specified
		/// and returns a DataTable.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <returns>A DataTable object.</returns>
		public DataTable ExecuteDataTable(string sql) 
		{
			return ExecuteDataTable(sql, new LIParameterCollection());
		}

		/// <summary>
		/// Execute the sql query specified with the parameters specified.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		/// <param name="parameters">Parameters for the sql query.</param>
		public void ExecuteNonQuery(string sql,
		                            LIParameterCollection parameters) 
		{
			DbCommand cmd = BuildCommand(sql, parameters);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Execute the sql query specified.
		/// </summary>
		/// <param name="sql">Sql query to execute.</param>
		public void ExecuteNonQuery(string sql) 
		{
			ExecuteNonQuery(sql, new LIParameterCollection());
		}

		/// <summary>
		/// Execute the sql query specified with the parameters specified
		/// and invoke the method specified on each row of the result
		/// set returned by the query.
		/// </summary>
		/// <param name="action">Method to execute on each row.</param>
		/// <param name="sql">Sql query to execute.</param>
		/// <param name="parameters">Parameters for the sql query.</param>
		public void ExecuteAction(ActionLine action,
		                          string sql,
		                          LIParameterCollection parameters) 
		{
			if (action == null) throw new ArgumentNullException("action");

			using (DbDataReader reader = ExecuteReader(sql, parameters)) {
				while (reader.Read()) {
					action.Invoke(ReadAllValues(reader));
				}
			}
		}

		/// <summary>
		/// Execute the sql query specified
		/// and invoke the method specified on each row of the result
		/// set returned by the query.
		/// </summary>
		/// <param name="action">Method to execute on each row.</param>
		/// <param name="sql">Sql query to execute.</param>
		public void ExecuteAction(ActionLine action,
		                          string sql) 
		{
			ExecuteAction(action, sql, new LIParameterCollection());
		}

		/// <summary>
		/// Read all values from a DbDataReader and returns all rows
		/// into a dictionary.
		/// </summary>
		/// <param name="reader">DbDataReader to read.</param>
		/// <returns>A dictionary object that contains all data
		/// from the DbDataReader.</returns>
		public static Dictionary<string, object> ReadAllValues(DbDataReader reader) 
		{
			if (reader == null) throw new ArgumentNullException("reader");

			Dictionary<string, object> values = new Dictionary<string, object>();

			for (int i = 0; i <= reader.FieldCount - 1; i++) {
				string fieldName;
				fieldName = LICollectionHelper.GenerateKey(values.ContainsKey,
				                                           reader.GetName(i));

				values.Add(fieldName, reader.GetValue(i));
			}

			return values;
		}

		/// <summary>
		/// Convert the DbDataReader specified into a DataTable.
		/// </summary>
		/// <param name="reader">DbDataReader to convert.</param>
		/// <returns>A DataTable object that contains all data
		/// from the DbDataReader.</returns>
		public static DataTable ConvertReaderToTable(DbDataReader reader) 
		{
			if (reader == null) throw new ArgumentNullException("reader");

			DataTable table = new DataTable();
			table.Locale = CultureInfo.CurrentCulture;

			while (reader.Read()) 
			{
				if (table.Columns.Count == 0) CreateTableSchema(table, reader);
				
				DataRow row = table.NewRow();
				row.ItemArray = LICollectionHelper.DictionaryToArray(
					ReadAllValues(reader));
				table.Rows.Add(row);
			}
			
			reader.Close();

			return table;
		}

		/// <summary>
		/// Create the table schema from the reader.
		/// </summary>
		/// <param name="table">Table to modify.</param>
		/// <param name="reader">Source reader.</param>
		private static void CreateTableSchema(DataTable table, DbDataReader reader)
		{
			for (int i = 0; i <= reader.FieldCount - 1; i++) {
				string fieldName;
				fieldName = LICollectionHelper.GenerateKey(table.Columns.Contains,
				                                           reader.GetName(i));

				table.Columns.Add(fieldName, reader.GetValue(i).GetType());
			}			
		}
		
		#endregion
	}
}
