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
    public class ByteHelperTest
    {
    	#region Fields
    	
    	#endregion
    	
    	#region Constructors
    	
    	#endregion
    	
    	#region Properties
    	
    	#endregion
    	
    	#region Methods
    	
        [Test]
        public void TestByteToHexString()
        {
            Assert.AreEqual("D3", ByteHelper.ByteToHexString(211));
        }
        
    	#endregion
    }
}
