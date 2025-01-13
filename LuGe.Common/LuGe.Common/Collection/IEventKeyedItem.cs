/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 16:03
 */

using System;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// Interface that represents keyed item with events.
	/// </summary>
	public interface IEventKeyedItem: IKeyedItem
	{
		/// <summary>
		/// Event raised when the item state changed.
		/// </summary>
		event EventHandler<LIKeyedItemEventArgs> KeyChanged;		
	}
}
