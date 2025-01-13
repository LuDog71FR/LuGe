/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 16:40
 */

using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace LuGe.Common.Collection
{
	/// <summary>
	/// <para>
	/// Provides a set of methods that help the use of collections.
	/// </para><para>
	/// This class cannot be inherited.
	/// </para>
	/// </summary>
	public sealed class LICollectionHelper
	{
		#region Delegates

		/// <summary>
		/// Delegate to use with the <see cref="GenerateKey">
		/// GenerateKey</see> method.
		/// </summary>
		public delegate bool ActionOnKey(string baseKey);

		#endregion

		#region Fields
		
		static int _generateKey_i;

		#endregion
		
		#region Constructors
		
		private LICollectionHelper() {}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Generate a unique key for a keyed collection.
		/// </summary>
		/// <param name="action">Delegate that determines if a key
		/// is present or not in the collection.</param>
		/// <param name="baseKey">Base key to generate.</param>
		/// <returns>A unique key for a keyed collection.</returns>
		public static string GenerateKey(ActionOnKey action, 
		                                 string baseKey) {
			if (action == null) {
				throw new ArgumentNullException("action");
			}

			StringBuilder validName = new StringBuilder();
			validName.Append(baseKey);

			if (_generateKey_i > 0) {
				validName.Append(_generateKey_i.ToString(
					CultureInfo.InvariantCulture));
			}

			if (action.Invoke(validName.ToString())) {
				_generateKey_i += 1;
				return GenerateKey(action, baseKey);
			}

			_generateKey_i = 0;

			return validName.ToString();
		}

		/// <summary>
		/// Returns an array representing the items manage by the dictionary
		/// specified.
		/// </summary>
		/// <param name="source">Source dictionary.</param>
		/// <returns>An array representing the items
		/// manage by the dictionary.</returns>
		public static T[] DictionaryToArray<T>(Dictionary<string, T> source) {
			List<T> a = new List<T>();

			foreach (T item in source.Values) {
				a.Add(item);
			}

			return a.ToArray();
		}
		
		#endregion
	}
}
