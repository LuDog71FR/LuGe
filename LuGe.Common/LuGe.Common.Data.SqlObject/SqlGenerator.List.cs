/*
 * User: Ludovic Germain
 * Date: 30/08/2007
 * Time: 11:06
 */

using System;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using LuGe.Common;

namespace LuGe.Common.Data.SqlObject
{
	internal partial class SqlGenerator
	{
		#region Fields
		
		private List<object> _rows;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Returns all rows filtered with the filter expression specified.
		/// </summary>
		/// <param name="filter">
		/// <para>Expression used to filter 
		/// which rows are listed.</para><para>
		/// This expression must be write
		/// like the where clause of a sql instruction
		/// without the where word.</para>
		/// </param>
		/// <returns>All rows filtered with the 
		/// filter expression specified.</returns>
		public object[] List(string filter) {
			_rows = new List<object>();
			
			DbCommand cmd =
				this._access.CreateCommand(this.BuildSqlAllSelect(filter));
			
			SqlGenerator.LogCmd(cmd);
			
			using (DbDataReader reader = cmd.ExecuteReader()) {
				if (!reader.HasRows) {
					return _rows.ToArray();
				}
				
				while (reader.Read()) {
					this.AddRow(reader);
				}
			}
			
			return _rows.ToArray();
		}
		
		/// <summary>
		/// Add the current row from the reader specified.
		/// </summary>
		/// <param name="reader">Reader containing the row to add.</param>
		private void AddRow(DbDataReader reader) {
			Object[] parameters = {_access};
			Object row = LIActivator.GetInstance(
				this._extractor.ObjectType.Assembly, 
				this._extractor.ObjectType,
				parameters);
			
			AttributeExtractor extractor = new AttributeExtractor(row);
			
			foreach (LIDataField field in extractor.Table.Fields) {
				field.Value = reader.GetValue(reader.GetOrdinal(field.Name));
			}
			
			extractor.SetValues();
			
			_rows.Add(row);
		}
		
		/// <summary>
		/// Build a sql string for selecting all rows with
		/// a SELECT sql instruction.
		/// </summary>
		/// <param name="filter">Expression used to filter
		/// which rows are listed.</param>
		/// <returns>A sql string for the SELECT sql instruction.</returns>
		private string BuildSqlAllSelect(string filter) {
			StringBuilder sql = new StringBuilder();
			
			sql.Append(this.BuildSqlBaseSelect());
			
			if (!string.IsNullOrEmpty(filter)) {
				sql.Append(" WHERE ");
				sql.Append(filter);
			}
			
			sql.Append(";");
			
			return sql.ToString();
		}

		#endregion
	}
}
