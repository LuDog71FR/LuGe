/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 14:17
 */

using System;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// Attribute that represents the data field structure.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ColumnInfoAttribute : Attribute
	{
		#region Fields
		
		private string _name;
		private bool _primaryKey;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="ColumnInfoAttribute">ColumnInfoAttribute</see> class.
		/// </summary>
		/// <param name="name">The physical name of the data field.</param>
		public ColumnInfoAttribute(string name) : this(name, false) {}

		/// <summary>
		/// Create a new instance of the
		/// <see cref="ColumnInfoAttribute">ColumnInfoAttribute</see> class.
		/// </summary>
		/// <param name="name">The physical name of the data field.</param>
		/// <param name="primaryKey">A value that indicates if the field
		/// is part of the primary key.</param>
		public ColumnInfoAttribute(string name, bool primaryKey) {
			_name = name;
			_primaryKey = primaryKey;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the physical data field name.
		/// </summary>
		public string Name {
			get { return _name; }
		}

		/// <summary>
		/// Gets the value that indicates if the field is part
		/// of the primary key.
		/// </summary>
		public bool PrimaryKey {
			get { return _primaryKey; }
		}

		#endregion
		
		#region Methods
		
		#endregion
	}
}
