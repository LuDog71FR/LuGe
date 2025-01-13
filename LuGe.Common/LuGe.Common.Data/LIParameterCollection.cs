/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 11:29
 */

using System;
using LuGe.Common.Collection;
using System.Text.RegularExpressions;

namespace LuGe.Common.Data
{
	/// <summary>
	/// Represents a collection of 
	/// <see cref="LIParameter">Parameter</see> objects.
	/// </summary>
	public class LIParameterCollection: LIKeyedCollection<LIParameter>
	{
		#region Fields
		
		private static LIParameterCollection _parameters;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the 
		/// <see cref="LIParameterCollection">LIParameterCollection</see> class.
		/// </summary>
		public LIParameterCollection(): base() {}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Extract a collection of parameters from
		/// the sql query string specified.
		/// </summary>
		/// <param name="sql">Sql query source.</param>
		/// <returns>A collection of parameters.</returns>
		public static LIParameterCollection ExtractParameters(string sql) {
			if (string.IsNullOrEmpty(sql)) {
				throw new ArgumentNullException("sql");
			}

			_parameters = new LIParameterCollection();

			MatchCollection results = Regex.Matches(sql, "@(\\w+)");

			foreach (Match oneResult in results) {
				AddParameter(oneResult.Groups[1].Value);
			}

			return _parameters;
		}

		/// <summary>
		/// Add parameter to the collection.
		/// </summary>
		/// <param name="name">Parameter name.</param>
		private static void AddParameter(string name) {
			if (string.IsNullOrEmpty(name)) {
				throw new ArgumentNullException("name");
			}

			if (_parameters.Contains(name)) {
				return;
			}

			_parameters.Add(new LIParameter(name));
		}

		#endregion
	}
}
