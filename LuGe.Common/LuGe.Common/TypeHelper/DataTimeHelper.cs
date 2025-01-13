/*
 * User: Ludovic GERMAIN
 * Date: 01/10/2015
 * Time: 08:29
 */

using System;

namespace LuGe.Common.TypeHelper
{
	/// <summary>
	/// Extends the <c>DateTime</c> class.
	/// </summary>
	public static class DateTimeHelper
	{
		/// <summary>
		/// Truncate a datetime with the timespan specified.
		/// </summary>
		/// <param name="dateTime">The datetime to truncate.</param>
		/// <param name="timeSpan">The resolution.</param>
		/// <returns>Returns the truncated datetime.</returns>
		public static DateTime Truncate(DateTime dateTime, TimeSpan timeSpan)
		{
			return timeSpan == TimeSpan.Zero ? dateTime : dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));			
		}
	}
}
