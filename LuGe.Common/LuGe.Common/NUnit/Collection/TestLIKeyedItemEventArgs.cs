/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 16:12
 */

using NUnit.Framework;
using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Tests.Collection
{
	[TestFixture]
	public class TestLIKeyedItemEventArgs
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[Test]
		public void TestMethod() {
			LIKeyedItemEventArgs args = new LIKeyedItemEventArgs("old", "new");

            Assert.IsNotNull(args);
			Assert.AreEqual("old", args.OldValue);
			Assert.AreEqual("new", args.NewValue);
		}
		
		#endregion
	}
}
