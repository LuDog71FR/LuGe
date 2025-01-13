/*
 * User: Ludovic GERMAIN
 * Date: 01/10/2010
 * Time: 09:02
 */
 
namespace LuGe.Common.TypeHelper
{
    /// <summary>
    /// Extends the <c>byte</c> class.
    /// </summary>
    public static class ByteHelper
    {
        /// <summary>
        /// Converts a byte in his hexadimal string representation.
        /// </summary>
        /// <param name="number">The value to convert.</param>
        /// <returns>A string representating the hexadecimal value (ex: D3).</returns>
        /// <example>
        /// <code>
        /// Assert.That(((byte)211).ByteToHexString(), Is.EqualTo("D3"));
        /// </code>
        /// </example>
        public static string ByteToHexString(byte number)
        {
            return number.ToString("X2");
        }
    }
}
