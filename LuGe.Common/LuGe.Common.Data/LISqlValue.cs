/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 09:18
 */

using System;
using System.Text.RegularExpressions;

namespace LuGe.Common.Data
{
	/// <summary>
	/// <para>
	/// This class provides methods and properties that 
	/// manage sql values.
	/// </para><para>
	/// This class cannot be inherited.
	/// </para>
	/// </summary>
	public sealed class LISqlValue
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Private constructor for the LISqlValue class, 
		/// because the type only declares static members.
		/// </summary>
		private LISqlValue() {}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Returns the string value specified converted to be
		/// sql valid.
		/// </summary>
		/// <param name="text">Sql string value to convert.</param>
		/// <returns>The sql string value converted.</returns>
		public static string ConvertToSql(string text) {
			return Regex.Replace(text, "'+", "''");
		}
		
		#endregion
	}
}
