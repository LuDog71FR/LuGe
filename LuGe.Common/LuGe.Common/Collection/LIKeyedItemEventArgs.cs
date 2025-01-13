/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 16:05
 */

using System;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// This class contains event data for keyed item;
	/// it is used by events that pass state information to an 
	/// event handler when an event is raised for keyed item.
	/// </summary>
	public class LIKeyedItemEventArgs : EventArgs
	{
		#region Fields
		
		private string _oldValue;
		private string _newValue;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of 
		/// <see cref="LIKeyedItemEventArgs">LIKeyedItemEventArgs</see> class.
		/// </summary>
		/// <param name="oldValue">The old value.</param>
		/// <param name="newValue">The new vakue.</param>
		public LIKeyedItemEventArgs(string oldValue, string newValue) {
			this._oldValue = oldValue;
			this._newValue = newValue;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the old value of key.
		/// </summary>
		public string OldValue {
			get { return _oldValue; }
		}

		/// <summary>
		/// Gets the new value of key.
		/// </summary>
		public string NewValue {
			get { return _newValue; }
		}
		
		#endregion
		
		#region Methods
		
		#endregion
	}
}
