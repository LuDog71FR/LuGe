/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 16:22
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// Provides an high-level class for a generic collection.
	/// </summary>
	/// <remarks>
	/// Elements in this collection can be accessed using an integer index
	/// or a string key.
	/// Indexes in this collection are zero-based.
	/// </remarks>
	[Serializable()]
	public class LIKeyedCollection<T> : KeyedCollection<string, T> 
		where T : IKeyedItem
	{
		#region Events

		/// <summary>
		/// Event raised when an item state
		/// in the list changed.
		/// </summary>
		public event EventHandler<LICollectionEventArgs<T>> Changed;

		#endregion

		#region Delegates

		/// <summary>
		/// Delegate to use with the <see cref="ForEach">
		/// ForEach</see> method.
		/// </summary>
		private delegate void Action(T item);

		#endregion

		#region Fields
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIKeyedCollection{T}">LIKeyedCollection</see> class.
		/// </summary>
		public LIKeyedCollection(): base() {}
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIKeyedCollection{T}">LIKeyedCollection</see> class.
		/// </summary>
		/// <param name="collection">Base list.</param>
		public LIKeyedCollection(IEnumerable<T> collection): base()
		{
			AddRange(collection);
		}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Converts the elements in the current LIKeyedCollection to another type, 
		/// and returns a list containing the converted elements.
		/// </summary>
		/// <param name="converter"
		/// >A Converter delegate that converts each element 
		/// from one type to another type.</param>
		/// <returns>A LIKeyedCollection of the target type containing 
		/// the converted elements from the current LIKeyedCollection.</returns>
		public LIKeyedCollection<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter) 
			where TOutput : IKeyedItem 
		{
			if (converter == null) throw new ArgumentNullException("converter");
			
			LIKeyedCollection<TOutput> list = new LIKeyedCollection<TOutput>();
			foreach (T i in Items) list.Add(converter(i));
			
			return list;
		}
     	
     	/// <summary>
		/// Returns a LIKeyedCollection which represents a subset of the elements 
		/// in the source LIKeyedCollection.
		/// </summary>
		/// <param name="index">The zero-based LIKeyedCollection index at which the range starts.</param>
		/// <param name="count">The number of elements in the range.</param>
		/// <returns>A LIKeyedCollection which represents a subset of the elements 
		/// in the source LIKeyedCollection.</returns>
		public LIKeyedCollection<T> GetRange(int index, int count) 
		{
			LIKeyedCollection<T> rangeList = new LIKeyedCollection<T>();
			
			for (int i=index; i < index+count; i++) rangeList.Add(Items[i]);
			
			return rangeList;
		}
				
		/// <summary>
		/// Returns this collection as generic read-only collection.
		/// </summary>
		/// <returns>This collection as generic
		/// read-only collection.</returns>
		public LIReadOnlyCollection<T> AsReadOnly() 
		{
			return new LIReadOnlyCollection<T>(this);
		}

		/// <summary>
		/// Gets the key for the specified item.
		/// </summary>
		/// <param name="item">Item search.</param>
		/// <returns>The key of the specified item.</returns>
		protected override string GetKeyForItem(T item) 
		{
			return item.Key;
		}

		/// <summary>
		/// Add at the end of the list, the items specified.
		/// </summary>
		/// <param name="items">Items to add to the list.</param>
		public void AddRange(IEnumerable<T> items) 
		{
			foreach (T item in items) {
				Add(item);
			}
		}

		/// <summary>
		/// Returns an array representing the items manage by the collection.
		/// </summary>
		/// <returns>A array representing the items
		/// manage by the collection.</returns>
		public T[] ToArray() 
		{
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
		public void ForEach(Action<T> action) 
		{
			foreach (T item in this.Items) {
				action.Invoke(item);
			}
		}

		/// <summary>
		/// Raised the <see cref="Changed">Changed</see>
		/// event.
		/// </summary>
		/// <param name="change">Item change state.</param>
		/// <param name="item">Changed item.</param>
		/// <param name="replacement">Replaced item.</param>
		protected virtual void OnChanged(EChangeType change,
		                                 T item,
		                                 T replacement) 
		{
			if (Changed != null) {
				Changed(this,
				        new LICollectionEventArgs<T>(change,
				                                     item,
				                                     replacement));
			}
		}
		
		/// <summary>
		/// Clear all items from the collection.
		/// </summary>
		protected override void ClearItems() 
		{
			base.ClearItems();
			
			OnChanged(EChangeType.Cleared, default(T), default(T));
		}

		/// <summary>
		/// Inserts an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which item
		/// should be inserted.</param>
		/// <param name="item">The object to insert.</param>
		protected override void InsertItem(int index, T item) 
		{
			base.InsertItem(index, item);
			
			OnChanged(EChangeType.Added, item, default(T));
		}

		/// <summary>
		/// Remove an element from the collection at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which item
		/// should be removed.</param>
		protected override void RemoveItem(int index) 
		{
			T item = Items[index];
			base.RemoveItem(index);
			
			OnChanged(EChangeType.Removed, item, default(T));
		}

		/// <summary>
		/// Replaces the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element
		/// to replace.</param>
		/// <param name="item">The new value for the element at
		/// the specified index. </param>
		protected override void SetItem(int index, T item) 
		{
			T replaced = Items[index];
			base.SetItem(index, item);
			
			OnChanged(EChangeType.Replaced, item, replaced);
		}
		
		/// <summary>
		/// Sort the items of the list with the default comparator of the item type.
		/// </summary>
		/// <remarks>The item type must implements the <c>IComparable</c>
		///  interface.</remarks>
		public void Sort() 
		{
			List<T> internalList = new List<T>(this);
			internalList.Sort();
			
			base.ClearItems();
			
			foreach(T item in internalList) base.Add(item);
		}

		/// <summary>
		/// Returns a string that contains all elements of the list.
		/// </summary>
		/// <returns>A string that contains all elements of the list.</returns>
		public override string ToString() 
		{
			string value = "";
			
			foreach (T item in this.Items) 
			{
				if (!string.IsNullOrEmpty(value)) value += ", ";
				value += item.Key + "=>" + item.ToString();
			}

			return value;
		}
		
		#endregion
	}
}
