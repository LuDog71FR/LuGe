/*
 * User: Ludovic Germain
 * Date: 03/10/2007
 * Time: 08:38
 */

using NUnit.Framework;
using System;
using LuGe.Common;

namespace LuGe.Common.Tests
{
    class TestLIMessageEventArgs
    {
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods

        [Test]
        public void TestMethod()
        {
            LIMessageEventArgs args = new LIMessageEventArgs("my text");

            Assert.IsNotNull(args);
            Assert.AreEqual("my text", args.Message);
        }

        #endregion
    }
}
