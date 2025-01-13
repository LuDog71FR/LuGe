/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 10:42
 */

using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Data
{
	/// <summary>
	/// Represents a command parameter.
	/// </summary>
	public class LIParameter: IKeyedItem
	{
		#region Fields
		
		private string _name;
		private object _value;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIParameter">LIParameter</see> class.
		/// </summary>
		/// <param name="name">Parameter name.</param>
		public LIParameter(string name) : this(name, null) {}

		/// <summary>
		/// Create a new instance of the
		/// <see cref="LIParameter">LIParameter</see> class.
		/// </summary>
		/// <param name="name">Parameter name.</param>
		/// <param name="value">Parameter value.</param>
		public LIParameter(string name, object value) {
			if (string.IsNullOrEmpty(name)) {
				throw new ArgumentNullException("name");
			}

			this._name = name;
			this._value = value;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the key item.
		/// </summary>
		/// <remarks>
		/// This property is equivalent to 
		/// the <see cref="Name">Name</see> property.
		/// </remarks>
		public string Key {
			get { return this.Name; }
		}
		
		/// <summary>
		/// Gets the parameter name.
		/// </summary>
		public string Name {
			get { return _name; }
		}

		/// <summary>
		/// Gets or sets the value of the parameter.
		/// </summary>
		public object Value {
			get { return _value; }
			set { _value = value; }
		}
		
		#endregion
		
		#region Methods
		
		#endregion
	}
}
