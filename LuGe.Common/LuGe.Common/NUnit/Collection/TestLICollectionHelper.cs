/*
 * User: Ludovic Germain
 * Date: 19/07/2007
 * Time: 10:57
 */

using NUnit.Framework;
using System;
using System.Collections.Generic;
using LuGe.Common.Collection;

namespace LuGe.Common.Tests.Collection
{
	[TestFixture]
	public class TestLICollectionHelper
	{
		#region Fields
		
		MockLIObject _obj1;
		MockLIObject _obj2;
		
		private Dictionary<String, MockLIObject> _dic;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[SetUp]
		public void Init() {
			_obj1 = new MockLIObject("a", 123);
			_obj2 = new MockLIObject("b", 456);
			
			_dic = new Dictionary<String, MockLIObject>();
			
			_dic.Add(_obj1.Key, _obj1);
			_dic.Add(_obj2.Key, _obj2);
		}
		
		[Test]
		public void TestGenerateKeyMethod() {
			Assert.IsTrue(_dic.ContainsKey("a123"));
			
			MockLIObject obj3 = new MockLIObject("a", 123);
			
			string uniqueKey = 
				LICollectionHelper.GenerateKey(_dic.ContainsKey,
				                               "a123");
			
			Assert.AreEqual("a1231", uniqueKey);
		}

		[Test]
		public void TestDictionaryToArrayMethod() {
			MockLIObject[] list = LICollectionHelper.DictionaryToArray(_dic);
			
			Assert.IsNotNull(list);
			Assert.AreEqual(2, list.Length);
			Assert.AreEqual(_obj1, list[0]);
			Assert.AreEqual(_obj2, list[1]);
		}
		
		[Test]
		public void TestDictionaryToArrayMethod2() {
			Dictionary<String, Object> dic = new Dictionary<String, Object>();
			dic.Add("0", "first element");
			dic.Add("1", 2);
			dic.Add("2", "last element");
			
			Object[] list = LICollectionHelper.DictionaryToArray(dic);
			
			Assert.IsNotNull(list);
			Assert.AreEqual(3, list.Length);
			Assert.AreEqual("first element", list[0]);
			Assert.AreEqual(2, list[1]);
			Assert.AreEqual("last element", list[2]);
		}

		#endregion
	}
}
