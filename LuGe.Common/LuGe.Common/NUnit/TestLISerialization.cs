/*
 * User: Ludovic Germain
 * Date: 01/10/2007
 * Time: 11:53
 */

using NUnit.Framework;
using System;
using System.IO;
using LuGe.Common;

namespace LuGe.Common.Tests
{
    [TestFixture]
    public class TestLISerialization
    {
        #region Constants

        public const string OUTPUT_FILENAME = "output.xml";

        #endregion

        #region Fields

        MockLIObject _object;
        LISerialization<MockLIObject> _serializer;

		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods

        [SetUp]       
        public void Init()
        {
            _object = new MockLIObject("my address", 385);
            _serializer = new LISerialization<MockLIObject>(_object);

            Assert.IsNotNull(_object);
            Assert.IsNotNull(_serializer);
        }

        [Test]
        public void TestSerialize()
        {
            _serializer.Serialize(OUTPUT_FILENAME);

            Assert.IsTrue(File.Exists(OUTPUT_FILENAME));
        }

        [Test]
        public void TestDeserialize()
        {
        	TestSerialize();
        	
            _serializer.Deserialize(OUTPUT_FILENAME);

            Assert.IsNotNull(_serializer.Value);
            Assert.IsInstanceOfType(typeof(MockLIObject), _serializer.Value);
            
            _object = (MockLIObject)_serializer.Value;
            
            Assert.AreEqual("my address", _object.Adress);
            Assert.AreEqual(385, _object.Phone);
        }

		#endregion	
    }
}
