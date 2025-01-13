/*
 * User: Ludovic Germain
 * Date: 19/07/2007
 * Time: 10:46
 */

using NUnit.Framework;
using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Tests.Collection
{
	[TestFixture]
	public class TestLIReadOnlyCollection
	{
		#region Fields
		
		private LIReadOnlyCollection<MockLIObject> _list;
		
		private MockLIObject _obj1;
		private MockLIObject _obj2;
		
		private int _nb;

		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Initialize the collection with 2 items.
		/// </summary>
		[SetUp]
		public void Init() {
			this._nb = 0;
			
			LIKeyedCollection<MockLIObject> list = 
				new LIKeyedCollection<MockLIObject>();
			
			_obj1 = new MockLIObject("a", 123);
			_obj2 = new MockLIObject("b", 456);
			
			list.Add(_obj1);
			list.Add(_obj2);
			
			this._list = list.AsReadOnly();
		}
		
		[Test]
		public void TestInitialize() {
			Assert.IsNotNull(this._list);
			Assert.AreEqual(2, this._list.Count);
		}

		[Test]
		public void TestAsArrayMethod() {
			MockLIObject[] list = this._list.ToArray();
			
			Assert.IsNotNull(list);
			Assert.AreEqual(2, list.Length);
			Assert.AreEqual(_obj1, list[0]);
			Assert.AreEqual(_obj2, list[1]);
		}

		private void CalculateItem(MockLIObject obj) {
			_nb += 1;
		}

		[Test]
		public void TestForEachMethod() {
			this._list.ForEach(CalculateItem);
			
			Assert.AreEqual(2, this._nb);
		}
		
		[Test]
		public void TestToString() {
			Assert.AreEqual("a, b", this._list.ToString());
		}
		
		[Test]
		public void TestGetRange() {
			LIKeyedCollection<MockLIObject> list = new LIKeyedCollection<MockLIObject>();
			list.Add(new MockLIObject("a", 1));
			list.Add(new MockLIObject("b", 2));
			list.Add(new MockLIObject("c", 3));
			list.Add(new MockLIObject("d", 4));
			list.Add(new MockLIObject("e", 5));
			
			this._list = list.AsReadOnly();
			Assert.IsNotNull(this._list);
			
			LIReadOnlyCollection<MockLIObject> subList = this._list.GetRange(1, 3);
			Assert.IsNotNull(subList);
			Assert.AreEqual(3, subList.Count);
			Assert.AreEqual("b", subList[0].Adress);
			Assert.AreEqual("c", subList[1].Adress);
			Assert.AreEqual("d", subList[2].Adress);
		}
		
		#endregion
	}
}
