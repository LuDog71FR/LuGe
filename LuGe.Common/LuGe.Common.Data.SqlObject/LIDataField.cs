/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 11:52
 */

using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// <para>
	/// Represents a data field. Each field of a data table is 
	/// representing by a data field.
	/// </para><para>
	/// A data field contains also the structure 
	/// and the value of a field.
	/// </para>
	/// </summary>
	[Serializable()]
	public class LIDataField: IKeyedItem
	{
		#region Fields
		
		private string _name;
		private string _description;
		private bool _primaryKey;
		private string _variableName;
		private object _value;
		private string _sqlType;
		private bool _isNullable;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the 
		/// <see cref="LIDataField">LIDataField</see> class.
		/// </summary>
		public LIDataField() {
			_name = string.Empty;
		}

		/// <summary>
		/// Create a new instance of the 
		/// <see cref="LIDataField">LIDataField</see> class with
		/// the name specified for the data field.
		/// </summary>
		public LIDataField(string name) {
			_name = name;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the unique key string to access the data field
		/// in a LIKeyedCollection.
		/// </summary>
		public string Key {
			get { return _name; }
		}

		/// <summary>
		/// Gets or sets the physical data field name.
		/// </summary>
		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the data field description.
		/// </summary>
		public string Description {
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates if the data field is part
		/// of the primary key.
		/// </summary>
		public bool PrimaryKey {
			get { return _primaryKey; }
			set { _primaryKey = value; }
		}

		/// <summary>
		/// Gets or sets the variable name associated with
		/// the physical data field name.
		/// </summary>
		internal string VariableName {
			get { return _variableName; }
			set { _variableName = value; }
		}

		/// <summary>
		/// Gets or sets the data field value.
		/// </summary>
		public object Value {
			get { return _value; }
			set { _value = value; }
		}

		/// <summary>
		/// Get or sets the real sql type.
		/// </summary>
		public string SqlType {
			get { return _sqlType; }
			set { _sqlType = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates if the value of the data field
		/// is nullable.
		/// </summary>
		public bool IsNullable {
			get { return _isNullable; }
			set { _isNullable = value; }
		}

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Returns the physical name of the data field.
		/// </summary>
		/// <returns>The physical name of the data field.</returns>
		public override string ToString() {
			return this.Name;
		}

		#endregion
	}
}
