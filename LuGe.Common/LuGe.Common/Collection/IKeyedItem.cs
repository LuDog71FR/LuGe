/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 16:00
 */

using System;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// Interface that represents keyed item.
	/// </summary>
	public interface IKeyedItem
	{
		/// <summary>
		/// Gets the key for the item.
		/// </summary>
		string Key {
			get;
		}
		
	}
}
