/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 09:07
 */

using System;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// Specifies enumerated constants used to
	/// represents the different item state.
	/// </summary>
	public enum EChangeType {
		///<summary>
		/// The item is added to the collection.
		/// </summary>
		Added,
		
		///<summary>
		/// The item is removed from the collection.
		/// </summary>
		Removed,
		
		///<summary>
		/// The item is replaced by another for the collection.
		/// </summary>
		Replaced,
		
		///<summary>
		/// The entire list of items is cleared from the collection.
		/// </summary>
		Cleared
	}
}
