/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 09:05
 */

using System;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// This class contains event data for collection items;
	/// it is used by events that pass state information to an 
	/// event handler when an event is raised for collection items.
	/// </summary>
	public class LICollectionEventArgs<T> : EventArgs
	{
		#region Fields
		
		private T _changedItem;
		private EChangeType _changeType;
		private T _replacedWith;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of 
		/// <see cref="LICollectionEventArgs{T}">LICollectionEventArgs</see> class.
		/// </summary>
		/// <param name="change">Item change state.</param>
		/// <param name="item">Changed item.</param>
		/// <param name="replacement">Replaced item.</param>
		public LICollectionEventArgs(EChangeType change,
		                             T item,
		                             T replacement) {
			_changeType = change;
			_changedItem = item;
			_replacedWith = replacement;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the changed item.
		/// </summary>
		public T ChangedItem {
			get { return _changedItem; }
		}

		/// <summary>
		/// Gets the item change state.
		/// </summary>
		public EChangeType ChangeType {
			get { return _changeType; }
		}

		/// <summary>
		/// Get the replaced item.
		/// </summary>
		public T ReplacedWith {
			get { return _replacedWith; }
		}

		#endregion
		
		#region Methods
		
		#endregion
	}
}
