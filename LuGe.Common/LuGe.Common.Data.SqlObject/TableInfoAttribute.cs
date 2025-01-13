/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 14:48
 */

using System;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// Attribute that represents the data table.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class TableInfoAttribute : Attribute
	{
		#region Fields
		
		private string _tableName;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="TableInfoAttribute">TableInfoAttribute</see> class.
		/// </summary>
		/// <param name="tableName">The physical name of the data table.</param>
		public TableInfoAttribute(string tableName) {
			_tableName = tableName;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the physical data table name.
		/// </summary>
		public string TableName {
			get { return _tableName; }
		}

		#endregion
		
		#region Methods
		
		#endregion
	}
}
