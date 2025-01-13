/*
 * User: Ludovic GERMAIN
 * Date: 01/10/2010
 * Time: 09:02
 */

using LuGe.Common.TypeHelper;
using NUnit.Framework;

namespace LuGe.Common.Tests.TypeHelper
{
    [TestFixture]
    public class StringHelperTest
    {
    	#region Fields
    	
    	#endregion
    	
    	#region Constructors
    	
    	#endregion
    	
    	#region Properties
    	
    	#endregion
    	
    	#region Methods

        [Test]
        public void TestHexStringToByte()
        {
            Assert.AreEqual(211, StringHelper.HexStringToByte("D3"));
        }
        
        [Test]
        public void TestWildcardMatch()
        {
        	Assert.IsTrue(StringHelper.WildcardMatch("testfile.txt", "*.txt", false));
        	Assert.IsFalse(StringHelper.WildcardMatch("testfile.tx", "*.txt", false));
        	
        	Assert.IsTrue(StringHelper.WildcardMatch("route 20150930_1643249422.xml", "route *.xml", false));
        	Assert.IsFalse(StringHelper.WildcardMatch("route.xml", "route *.xml", false));
        }
        
    	#endregion
    }
}
