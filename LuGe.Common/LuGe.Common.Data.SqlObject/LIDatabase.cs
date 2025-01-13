/*
 * User: Ludovic Germain
 * Date: 24/07/2007
 * Time: 14:03
 */

using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// Represents a database structure with a unique name and a collection
	/// of tables.
	/// </summary>
	[Serializable()]
	public class LIDatabase : IKeyedItem
	{
		#region Fields
		
		private string _name;
		private LIKeyedCollection<LIDataTable> _tables;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIDatabase">LIDatabase</see> class with
		/// the name specified for the database.
		/// </summary>
		/// <param name="title">Unique name for the data table.</param>
		public LIDatabase(string title) : this() {
			this._name = title;
		}
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIDatabase">LIDatabase</see> class.
		/// </summary>
		public LIDatabase() {
			_tables = new LIKeyedCollection<LIDataTable>();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the unique key string to access the database
		/// in a LIKeyedCollection.
		/// </summary>
		public string Key {
			get { return _name; }
		}
		
		/// <summary>
		/// Gets or sets the database name.
		/// </summary>
		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets the tables associates with the database.
		/// </summary>
		public LIKeyedCollection<LIDataTable> Tables {
			get { return _tables; }
		}
		
		#endregion
		
		#region Methods
		
		#endregion
		
	}
}
