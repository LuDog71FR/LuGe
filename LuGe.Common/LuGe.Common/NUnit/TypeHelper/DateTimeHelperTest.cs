/*
 * User: Ludovic GERMAIN
 * Date: 01/10/2015
 * Time: 08:29
 */

using System;
using LuGe.Common.TypeHelper;
using NUnit.Framework;

namespace LuGe.Common.Tests.TypeHelper
{
	[TestFixture]
	public class DateTimeHelperTest
	{
		[Test]
		public void TestTruncate()
		{
			DateTime date1 = new DateTime(2015, 10, 1, 8, 1, 3);
			DateTime date2 = new DateTime(2015, 10, 1, 8, 1, 48);
			
			DateTime truncDate1 = DateTimeHelper.Truncate(date1, TimeSpan.FromMinutes(1));
			DateTime truncDate2 = DateTimeHelper.Truncate(date2, TimeSpan.FromMinutes(1));
			
			Assert.AreNotEqual(date1, date2);
			Assert.AreEqual(truncDate1, truncDate2);
		}
	}
}
