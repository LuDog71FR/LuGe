/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 16:15
 */

using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// Provides an high-level class for a generic read-only collection.
	/// </summary>
	/// <remarks>
	/// Elements in this collection can be accessed using an integer index
	/// or a string key.
	/// Indexes in this collection are zero-based.
	/// </remarks>
	public class LIReadOnlyCollection<T> : ReadOnlyCollection<T> 
		where T : IKeyedItem
	{
		#region Delegates

		/// <summary>
		/// Delegate to use with the <see cref="ForEach">
		/// ForEach</see> method.
		/// </summary>
		private delegate void Action(T item);

		#endregion
		
		#region Fields
		
		private LIKeyedCollection<T> _baseList;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIReadOnlyCollection{T}">LIReadOnlyCollection</see> class.
		/// </summary>
		/// <param name="list">Base list.</param>
		public LIReadOnlyCollection(LIKeyedCollection<T> list) : base(list) {
			if (list == null) {
				throw new ArgumentNullException("list");
			}

			_baseList = list;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the item.
		/// </summary>
		public T this[string key] {
			get { return this._baseList[key]; }
		}

		#endregion
		
		#region Methods

     	/// <summary>
		/// Returns a LIReadOnlyCollection which represents a subset of the elements 
		/// in the source LIReadOnlyCollection.
		/// </summary>
		/// <param name="index">The zero-based LIReadOnlyCollection index at which the range starts.</param>
		/// <param name="count">The number of elements in the range.</param>
		/// <returns>A LIReadOnlyCollection which represents a subset of the elements 
		/// in the source LIReadOnlyCollection.</returns>
		public LIReadOnlyCollection<T> GetRange(int index, int count) {
			LIKeyedCollection<T> rangeList = new LIKeyedCollection<T>();
			
			for (int i=index; i < index+count; i++) rangeList.Add(Items[i]);
			
			return rangeList.AsReadOnly();
		}
		
		/// <summary>
		/// Determines whether the collection contains 
		/// an element with the specified key.
		/// </summary>
		/// <param name="key">The key to locate in the collection.</param>
		/// <returns>True if the collection contains an element 
		/// with the specified key; otherwise, false.</returns>
		public bool Contains(string key) {
			return this._baseList.Contains(key);
		}

		/// <summary>
		/// Returns an array representing the items manage by the collection.
		/// </summary>
		/// <returns>An array representing the items
		/// manage by the collection.</returns>
		public T[] ToArray() {
			T[] a = new T[this.Count];

			for (int i = 0; i <= this.Count - 1; i++) {
				a[i] = this.Items[i];
			}

			return a;
		}

		/// <summary>
		/// Invoke a delegate on each item of the collection.
		/// </summary>
		/// <param name="action">Delegate to invoke.</param>
		public void ForEach(Action<T> action) {
			foreach (T item in this.Items) {
				action.Invoke(item);
			}
		}
		
		/// <summary>
		/// Returns a string that contains all elements of the list.
		/// </summary>
		/// <returns>A string that contains all elements of the list.</returns>
		public override string ToString() {
			string value = "";
			
			foreach (T item in this.Items) 
			{
				if (!string.IsNullOrEmpty(value)) value += ", ";
				value += item.ToString();
			}

			return value;
		}
		
		#endregion
	}
}
