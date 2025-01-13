/*
 * User: Ludovic Germain
 * Date: 24/07/2007
 * Time: 14:13
 */

using System;
using System.Text;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using LuGe.Common;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// Automatically generate DbCommand for the sql instructions : select,
	/// update, insert and delete from attributes specified in a source object.
	/// </summary>
	/// <remarks>
	/// The class expect for the TableInfo and ColumnInfo attributes.
	/// </remarks>
	internal partial class SqlGenerator
	{
		#region Fields
		
		private AttributeExtractor _extractor;
		private LIConnection _access;
		
		private DbCommand _cmdSelect;
		private DbCommand _cmdUpdate;
		private DbCommand _cmdInsert;
		private DbCommand _cmdDelete;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="SqlGenerator">SqlGenerator</see> class.
		/// </summary>
		/// <param name="source">Source object where the table structure
		/// is defined with specific attributes.</param>
		/// <param name="connection">Connection to used to connect to the database.</param>
		public SqlGenerator(object source, LIConnection connection) {
			if (connection == null) throw new ArgumentNullException("connection");
			if (LIActivator.IsBaseClassOf(source, typeof(LISqlObject)) == false) throw new ArgumentException(string.Empty, "source");
			
			this._extractor = new AttributeExtractor(source);
			this._access = connection;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the DbCommand for the SELECT instruction.
		/// </summary>
		public DbCommand CmdSelect {
			get { return _cmdSelect; }
		}

		/// <summary>
		/// Gets the DbCommand for the UPDATE instruction.
		/// </summary>
		public DbCommand CmdUpdate {
			get { return _cmdUpdate; }
		}

		/// <summary>
		/// Gets the DbCommand for the INSERT instruction.
		/// </summary>
		public DbCommand CmdInsert {
			get { return _cmdInsert; }
		}

		/// <summary>
		/// Gets the DbCommand for the DELETE instruction.
		/// </summary>
		public DbCommand CmdDelete {
			get { return _cmdDelete; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Log with the LILog class, the sql query and it's parameters
		/// names and values.
		/// </summary>
		/// <param name="cmd">Command to log.</param>
		public static void LogCmd(DbCommand cmd) {
			if (cmd == null) {
				throw new ArgumentNullException("cmd");
			}

			ComponentResourceManager resource =
				new ComponentResourceManager(typeof(SqlGenerator));

			LILog.Trace(TraceLevel.Verbose, string.Empty);
			LILog.Trace(TraceLevel.Verbose, cmd.CommandText);

			foreach (DbParameter param in cmd.Parameters) {
				LILog.Trace(TraceLevel.Verbose,
				            resource.GetString("ParameterName"),
				            param.ParameterName);

				string valeur;
				if (param.Value == null) {
					valeur = "* Equal to Nothing *";
				}
				else {
					valeur = param.Value.ToString();
				}

				LILog.Trace(TraceLevel.Verbose,
				            resource.GetString("ParameterValue"),
				            valeur);
			}

			LILog.Trace(TraceLevel.Verbose, string.Empty);
		}

		#region Source object

		/// <summary>
		/// Returns a value indicates if a row exists with the
		/// primary key specified, in the current fields.
		/// </summary>
		/// <returns>A value indicates if a row exists with the
		/// primary key specified in the current fields.</returns>
		public bool Exist() {
			if (this._cmdSelect == null) {
				this._cmdSelect = this.CreateUniqueSelectCmd();
			}

			this._extractor.ExtractValues();
			this.PopulateKeyFieldsParameters(this.CmdSelect);
			SqlGenerator.LogCmd(this.CmdSelect);

			using (DbDataReader reader = this.CmdSelect.ExecuteReader()) {
				return reader.HasRows;
			}
		}

		/// <summary>
		/// Load the row with the primary key specified in the current fields.
		/// </summary>
		/// <returns>A value indicates if the row is load correctly.</returns>
		public bool Load() {
			if (this._cmdSelect == null) {
				this._cmdSelect = this.CreateUniqueSelectCmd();
			}

			this._extractor.ExtractValues();
			this.PopulateKeyFieldsParameters(this.CmdSelect);

			SqlGenerator.LogCmd(this.CmdSelect);

			using (DbDataReader reader = this.CmdSelect.ExecuteReader()) {
				if (!reader.HasRows) {
					return false;
				}

				reader.Read();

				foreach (LIDataField field in this._extractor.Table.Fields) {
					field.Value = reader.GetValue(reader.GetOrdinal(field.Name));
				}
			}

			this._extractor.SetValues();

			return true;
		}

		/// <summary>
		/// Save the current row.
		/// </summary>
		/// <returns>A value indicates if the row is save correctly.</returns>
		public bool Save() {
			this._extractor.ExtractValues();

			DbCommand cmd;

			if (this.Exist()) {
				if (this._cmdUpdate == null) {
					this._cmdUpdate = this.CreateUpdateCmd();
				}

				cmd = this.CmdUpdate;
			}
			else {
				if (this._cmdInsert == null) {
					this._cmdInsert = this.CreateInsertCmd();
				}

				cmd = this.CmdInsert;
			}

			this.PopulateFieldsParameters(cmd);
			SqlGenerator.LogCmd(cmd);

			return cmd.ExecuteNonQuery() != 0;
		}

		/// <summary>
		/// Delete the current row.
		/// </summary>
		/// <returns>A value indicates if the row is delete correctly.</returns>
		public bool Delete() {
			if (this._cmdDelete == null) {
				this._cmdDelete = this.CreateDeleteCmd();
			}

			this._extractor.ExtractValues();
			this.PopulateKeyFieldsParameters(this.CmdDelete);

			SqlGenerator.LogCmd(this.CmdDelete);

			return this.CmdDelete.ExecuteNonQuery() != 0;
		}

		/// <summary>
		/// Populate the parameters values with the values in the source object
		/// fields.
		/// </summary>
		/// <param name="cmd">Command where the parameters is populate.</param>
		private void PopulateFieldsParameters(DbCommand cmd) {
			SqlGenerator.PopulateParameters(cmd,
			                                this._extractor.Table.Fields);
		}

		/// <summary>
		/// Populate the parameters values with the values in the source object
		/// key fields.
		/// </summary>
		/// <param name="cmd">Command where the parameters is populate.</param>
		private void PopulateKeyFieldsParameters(DbCommand cmd)	{
			SqlGenerator.PopulateParameters(cmd,
			                                this._extractor.Table.KeyFields);
		}

		/// <summary>
		/// Populate the parameters values with the fields specified.
		/// </summary>
		/// <param name="cmd">Command where the parameters is populate.</param>
		/// <param name="items">Source fields.</param>
		private static void PopulateParameters(DbCommand cmd,
		                                       IEnumerable<LIDataField> items) {
			foreach (LIDataField field in items) {
				int num = cmd.Parameters.IndexOf(string.Concat("@", field.Name));
				
				cmd.Parameters[num].Value = field.Value;
			}
		}

		#endregion

		#region Command Object

		/// <summary>
		/// Create a INSERT command specific for the source object.
		/// </summary>
		/// <returns>A INSERT command specific for the source object.</returns>
		private DbCommand CreateInsertCmd() {
			DbCommand cmd = this._access.CreateCommand(this.BuildSqlInsert());

			this.AddFieldParameters(cmd);

			return cmd;
		}

		/// <summary>
		/// Create a UPDATE command specific for the source object.
		/// </summary>
		/// <returns>A UPDATE command specific for the source object.</returns>
		private DbCommand CreateUpdateCmd() {
			DbCommand cmd = this._access.CreateCommand(this.BuildSqlUpdate());

			this.AddFieldParameters(cmd);

			return cmd;
		}

		/// <summary>
		/// Create a DELETE command specific for the source object.
		/// </summary>
		/// <returns>A DELETE command specific for the source object.</returns>
		private DbCommand CreateDeleteCmd() {
			DbCommand cmd = this._access.CreateCommand(this.BuildSqlDelete());

			this.AddKeyFieldParameters(cmd);

			return cmd;
		}

		/// <summary>
		/// Create a SELECT command specific for the source object that returns
		/// only one row.
		/// </summary>
		/// <returns>A SELECT command specific for the source object that returns
		/// only one row.</returns>
		private DbCommand CreateUniqueSelectCmd() {
			DbCommand cmd = this._access.CreateCommand(this.BuildSqlUniqueSelect());

			this.AddKeyFieldParameters(cmd);

			return cmd;
		}

		/// <summary>
		/// Add parameters extract from all the source object key fields.
		/// </summary>
		/// <param name="cmd">Command where the parameters is add.</param>
		private void AddKeyFieldParameters(DbCommand cmd) {
			this.AddParameters(cmd, this._extractor.Table.KeyFields);
		}

		/// <summary>
		/// Add parameters extract from all the source object fields.
		/// </summary>
		/// <param name="cmd">Command where the parameters is add.</param>
		private void AddFieldParameters(DbCommand cmd) {
			this.AddParameters(cmd, this._extractor.Table.Fields);
		}

		/// <summary>
		/// Add parameters extract from the fields specified.
		/// </summary>
		/// <param name="cmd">Command where the parameters is add.</param>
		/// <param name="items">Source fields.</param>
		private void AddParameters(DbCommand cmd,
		                           IEnumerable<LIDataField> items) {
			foreach (LIDataField champs in items) {
				cmd.Parameters.Add(this._access.CreateParameter(champs.Name));
			}
		}

		#endregion

		#region Sql query

		/// <summary>
		/// Build a sql string for the INSERT sql instruction.
		/// </summary>
		/// <returns>A sql string for the INSERT sql instruction.</returns>
		private string BuildSqlInsert() {
			StringBuilder sql = new StringBuilder();

			sql.Append("INSERT INTO ");
			sql.Append(this._extractor.Table.Name);
			sql.Append(" (");

			foreach (LIDataField field in _extractor.Table.Fields) {
				sql.Append(field.Name);
				sql.Append(", ");
			}
			sql.Remove(sql.Length - 2, 2);
			sql.Append(") ");

			sql.Append("VALUES (");

			foreach (LIDataField field in _extractor.Table.Fields) {
				sql.Append("@");
				sql.Append(field.Name);
				sql.Append(", ");
			}
			sql.Remove(sql.Length - 2, 2);
			sql.Append(");");

			return sql.ToString();
		}

		/// <summary>
		/// Build a sql string for the UPDATE sql instruction.
		/// </summary>
		/// <returns>A sql string for the UPDATE sql instruction.</returns>
		private string BuildSqlUpdate() {
			StringBuilder sql = new StringBuilder();

			sql.Append("UPDATE ");
			sql.Append(_extractor.Table.Name);
			sql.Append(" SET ");

			foreach (LIDataField field in _extractor.Table.Fields) {
				sql.Append(field.Name);
				sql.Append(" = @");
				sql.Append(field.Name);
				sql.Append(", ");
			}
			sql.Remove(sql.Length - 2, 2);

			sql.Append(this.GetSqlWhere());

			sql.Append(";");

			return sql.ToString();
		}

		/// <summary>
		/// Build a sql string for the basic SELECT sql instruction
		/// without WHERE clause and without the semicolon terminates character.
		/// </summary>
		/// <returns>A sql string for the basic SELECT sql instruction.</returns>
		private string BuildSqlBaseSelect() {
			StringBuilder sql = new StringBuilder();

			sql.Append("SELECT ");

			foreach (LIDataField field in _extractor.Table.Fields) {
				sql.Append(field.Name);
				sql.Append(", ");
			}
			sql.Remove(sql.Length - 2, 2);
			sql.Append(" ");

			sql.Append("FROM ");
			sql.Append(_extractor.Table.Name);

			return sql.ToString();
		}

		/// <summary>
		/// Build a sql string for selecting only one row that match the
		/// primary key.
		/// </summary>
		/// <returns>A sql string for selecting only one row that match the
		/// primary key.</returns>
		private string BuildSqlUniqueSelect() {
			StringBuilder sql = new StringBuilder();
			
			sql.Append(this.BuildSqlBaseSelect());
			sql.Append(this.GetSqlWhere());
			sql.Append(";");
			
			return sql.ToString();
		}

		/// <summary>
		/// Build a sql string for the DELETE sql instruction.
		/// </summary>
		/// <returns>A sql string for the DELETE sql instruction.</returns>
		private string BuildSqlDelete() {
			StringBuilder sql = new StringBuilder();

			sql.Append("DELETE ");

			sql.Append("FROM ");
			sql.Append(_extractor.Table.Name);

			sql.Append(this.GetSqlWhere());

			sql.Append(";");

			return sql.ToString();
		}

		/// <summary>
		/// Get the WHERE clause use to select the row that match
		/// specific primary key.
		/// </summary>
		/// <returns>The WHERE clause use to select the row that match
		/// specific primary key.</returns>
		private string GetSqlWhere() {
			StringBuilder sql = new StringBuilder();

			sql.Append(" WHERE ");

			bool isKeyPresent = false;

			foreach (LIDataField field in this._extractor.Table.KeyFields) {
				if (isKeyPresent) {
					sql.Append(" AND ");
				}

				sql.Append(field.Name);
				sql.Append(" = ");
				sql.Append("@");
				sql.Append(field.Name);

				isKeyPresent = true;
			}

			return sql.ToString();
		}

		#endregion
		
		#endregion
	}
}
