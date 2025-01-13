/*
 * User: Ludovic GERMAIN
 * Date: 01/10/2010
 * Time: 09:02
 */

using System.Globalization;
using System.Text.RegularExpressions;

namespace LuGe.Common.TypeHelper
{
    /// <summary>
    /// Extends the <c>String</c> class.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Converts a string representing an hexadicimal number in a byte.
        /// </summary>
        /// <example>
        /// <code>
        /// Assert.That("D3".HexStringToByte(), Is.EqualTo(211));
        /// </code>
        /// </example>
        /// <param name="hex">A string representing an hexadicimal number.</param>
        /// <returns>The converting value in byte of the hexadecimal number.</returns>
        public static byte HexStringToByte(string hex)
        {
            return byte.Parse(hex, NumberStyles.HexNumber);
        }
		
        /// <summary>
        /// Indicates if a string matching with wilcards
        /// </summary>
        /// <param name="s">Source string</param>
        /// <param name="wildcard">Wilcard</param>
        /// <param name="case_sensitive">A value that indicates if it's case sensitive.</param>
        /// <returns>Returns True if the string matching; otherwise False.</returns>
		public static bool WildcardMatch(string s, string wildcard, bool case_sensitive)
		{
			// Replace the * with an .* and the ? with a dot. Put ^ at the
			// beginning and a $ at the end
			string pattern = "^" + Regex.Escape(wildcard).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";
			
			Regex regex = case_sensitive ? new Regex(pattern) : new Regex(pattern, RegexOptions.IgnoreCase);
			
			return regex.IsMatch(s);
		}
    }
}
