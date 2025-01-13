/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 14:51
 */

using System;
using System.Reflection;
using System.ComponentModel;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// Internal class that extract data attributes from an object.
	/// </summary>
	/// <remarks>
	/// The class expect for the TableInfo and ColumnInfo attributes.
	/// </remarks>
	internal class AttributeExtractor
	{
		#region Fields
		
		private ComponentResourceManager _resource;

		private LIDataTable _table;

		private object _objectData;
		private Type _objectType;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="AttributeExtractor">AttributeExtractor</see> class.
		/// </summary>
		/// <param name="source">The source object where the structure
		/// of a data table is describe with specific attributes.</param>
		public AttributeExtractor(object source) {
			if (source == null) {
				throw new ArgumentNullException("source");
			}

			this._resource = new ComponentResourceManager(this.GetType());

			this._objectType = source.GetType();

			if (!this._objectType.IsClass) {
				throw new ArgumentException(
					this._resource.GetString("SourceNotClass"));
			}

			this._objectData = source;
			this._table = new LIDataTable();

			this.ExtractTableName();
			this.ExtractFields();

			this.CheckTable();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the data table.
		/// </summary>
		public LIDataTable Table {
			get { return _table; }
		}

		/// <summary>
		/// Gets the source object.
		/// </summary>
		public object ObjectData {
			get { return this._objectData; }
		}

		/// <summary>
		/// Gets the source object type.
		/// </summary>
		public Type ObjectType {
			get { return this._objectType; }
		}

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Check if table is correctly define.
		/// </summary>
		/// <remarks>
		/// Raise exception if the table is malformed.
		/// </remarks>
		private void CheckTable() {
			if (string.IsNullOrEmpty(this.Table.Name)) {
				throw new InvalidOperationException(
					this._resource.GetString("TableNameEmpty"));
			}

			if (this.Table.Fields.Count == 0) {
				throw new InvalidOperationException(
					this._resource.GetString("FieldNotPresent"));
			}

			if (this.Table.KeyFields.Count == 0) {
				throw new InvalidOperationException(
					this._resource.GetString("PrimaryKeyNotPresent"));
			}
		}

		/// <summary>
		/// Extract the table name from the attribute.
		/// </summary>
		private void ExtractTableName() {
			Type attrType;
			Attribute[] attr;
			TableInfoAttribute tableInfo;

			attrType = typeof(TableInfoAttribute);
			attr = Attribute.GetCustomAttributes(ObjectType, attrType);

			if (attr.Length == 0) {
				throw new InvalidOperationException(
					this._resource.GetString("TableInfoNotFound"));
			}

			tableInfo = (TableInfoAttribute)attr[0];

			this.Table.Name = tableInfo.TableName;
		}

		/// <summary>
		/// Extract all fields from the attributes.
		/// </summary>
		private void ExtractFields() {
			FieldInfo[] vars;

			this.Table.Fields.Clear();

			vars = this._objectType.GetFields(BindingFlags.NonPublic |
			                                  BindingFlags.Public |
			                                  BindingFlags.Instance);

			Array.ForEach(vars, ExtractOneField);
		}

		/// <summary>
		/// Extract a field from the attributes variable specified.
		/// </summary>
		/// <param name="var">The attributes variable to parse.</param>
		private void ExtractOneField(FieldInfo var) {
			Attribute[] attr;

			attr = (Attribute[])var.GetCustomAttributes(
				typeof(ColumnInfoAttribute), false);

			if (attr.Length > 0) {
				this.AddField((ColumnInfoAttribute)attr[0], var.Name);
			}
		}

		/// <summary>
		/// Add field to the table structure.
		/// </summary>
		/// <param name="col">Column info attribute.</param>
		/// <param name="varName">Variable name.</param>
		private void AddField(ColumnInfoAttribute col,
		                      string varName) {
			LIDataField f = new LIDataField();

			f.Name = col.Name;
			f.Value = null;
			f.VariableName = varName;
			f.PrimaryKey = col.PrimaryKey;

			this.Table.Fields.Add(f);
		}

		/// <summary>
		/// Extract value from the object source
		/// into the data table.
		/// </summary>
		public void ExtractValues() {
			foreach (LIDataField f in this.Table.Fields) {
				FieldInfo var;
				var = this._objectType.GetField(f.VariableName,
				                                BindingFlags.NonPublic |
				                                BindingFlags.Public |
				                                BindingFlags.Instance);

				f.Value = var.GetValue(this.ObjectData);
			}
		}

		/// <summary>
		/// Copy the values from the data table 
		/// into the source object.
		/// </summary>
		public void SetValues() {
			foreach (LIDataField f in this.Table.Fields) {
				FieldInfo var;
				var = this._objectType.GetField(f.VariableName,
				                                BindingFlags.NonPublic |
				                                BindingFlags.Public |
				                                BindingFlags.Instance);

				var.SetValue(this.ObjectData, f.Value);
			}
		}

		#endregion
	}
}
