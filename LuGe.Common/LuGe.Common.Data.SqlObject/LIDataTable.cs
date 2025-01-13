/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 13:45
 */

using System;
using LuGe.Common.Collection;
using System.Xml.Serialization;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// Represents a data table.
	/// </summary>
	[Serializable()]
	public class LIDataTable : IKeyedItem, ICloneable
	{
		#region Fields
		
		private string _name;
		private string _description;
		private LIKeyedCollection<LIDataField> _fields;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIDataTable">LIDataTable</see> class.
		/// </summary>
		public LIDataTable() : this(string.Empty) {}

		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIDataTable">LIDataTable</see> class with
		/// the name specified for the data table.
		/// </summary>
		/// <param name="name">Unique name for the data table.</param>
		public LIDataTable(string name) {
			_name = name;
			_fields = new LIKeyedCollection<LIDataField>();
		}

		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the unique key string to access the data table
		/// in a LIKeyedCollection.
		/// </summary>
		public string Key {
			get { return _name; }
		}

		/// <summary>
		/// Gets or sets the physical data table name.
		/// </summary>
		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the data table description.
		/// </summary>
		public string Description {
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets an array of fields that represents the structure
		/// of the data table.
		/// </summary>
		public LIKeyedCollection<LIDataField> Fields {
			get { return _fields; }
		}

		/// <summary>
		/// Gets an array of fields that function 
		/// as primary keys for the data table. 
		/// </summary>
		[XmlIgnore()]
		public LIReadOnlyCollection<LIDataField> KeyFields {
			get {
				LIKeyedCollection<LIDataField> keys =
					new LIKeyedCollection<LIDataField>();

				foreach (LIDataField f in this.Fields) {
					if (f.PrimaryKey) {
						keys.Add(f);
					}
				}

				return keys.AsReadOnly();
			}
		}

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Copy the table specified into the current instance.
		/// </summary>
		/// <param name="tableSource">Table source copied from.</param>
		public void Copy(LIDataTable tableSource) {
			if (tableSource == null) {
				throw new ArgumentNullException("tableSource");
			}

			this.Name = tableSource.Name;
			this.Description = tableSource.Description;

			this.Fields.Clear();
			this.Fields.AddRange(tableSource.Fields);
		}
		
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone() {
			LIDataTable table  = new LIDataTable(this.Name);
			table.Description = this.Description;
			
			table.Fields.AddRange(this.Fields);
			
			return table;
		}

		/// <summary>
		/// Returns the physical name of the data table.
		/// </summary>
		/// <returns>The physical name of the data table.</returns>
		public override string ToString() {
			return this.Name;
		}
		
		#endregion
		
	}
}
