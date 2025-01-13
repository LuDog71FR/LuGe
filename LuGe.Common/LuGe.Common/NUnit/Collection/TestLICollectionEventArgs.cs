/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 10:46
 */

using NUnit.Framework;
using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Tests.Collection
{
	[TestFixture]
	public class TestLICollectionEventArgs
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[Test]
		public void TestItemReplacedState() {
			MockLIObject newObj = new MockLIObject("123", 123);
			MockLIObject oldObj = new MockLIObject("456", 456);
			
			LICollectionEventArgs<MockLIObject> args =
				new LICollectionEventArgs<MockLIObject>(EChangeType.Replaced,
				                                        newObj,
				                                        oldObj);
			
			Assert.IsNotNull(args);
			Assert.AreEqual(EChangeType.Replaced, args.ChangeType);
			Assert.AreEqual(newObj, args.ChangedItem);
			Assert.AreEqual(oldObj, args.ReplacedWith);
		}
		
		#endregion
	}
}
