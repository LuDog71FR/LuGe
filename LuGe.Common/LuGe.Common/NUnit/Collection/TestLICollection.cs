/*
 * User: Ludovic Germain
 * Date: 17/07/2007
 * Time: 10:52
 */

using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System;
using LuGe.Common.Collection;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LuGe.Common.Tests.Collection
{
	[TestFixture]
	public class TestLICollection
	{
		#region Fields
		
		private LICollection<MockLIObject> _list;
		
		private MockLIObject _obj1;
		private MockLIObject _obj2;
		
		private bool _eventRaised;
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
			this._eventRaised = false;
			
			this._list = new LICollection<MockLIObject>();
			
			_obj1 = new MockLIObject();
			_obj2 = new MockLIObject();
			
			this._list.Add(_obj1);
			this._list.Add(_obj2);
		}
		
		[Test]
		public void TestAddMethod() {
			Assert.AreEqual(2, this._list.Count);
			Assert.AreEqual(_obj1, this._list[0]);
			Assert.AreEqual(_obj2, this._list[1]);
		}
		
		[Test]
		public void TestAsReadOnlyMethod() {
			ReadOnlyCollection<MockLIObject> readList =
				this._list.AsReadOnly();
			
			Assert.IsNotNull(readList);
			Assert.AreEqual(2, readList.Count);
			Assert.AreEqual(_obj1, readList[0]);
			Assert.AreEqual(_obj2, readList[1]);
		}

		[Test]
		public void TestAddRangeMethod() {
			MockLIObject obj3 = new MockLIObject();
			MockLIObject obj4 = new MockLIObject();
			
			this._list.AddRange(new MockLIObject[] {obj3, obj4});
			Assert.AreEqual(4, this._list.Count);
			Assert.AreEqual(obj3, this._list[2]);
			Assert.AreEqual(obj4, this._list[3]);
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
		
		private void ListOnChanged(object obj,
		                           LICollectionEventArgs<MockLIObject> args) {
			Assert.IsNotNull(obj);
			Assert.IsNotNull(args);
			Assert.AreEqual(EChangeType.Added, args.ChangeType);
			Assert.AreEqual(this._obj1, args.ChangedItem);
			Assert.IsNull(args.ReplacedWith);
			
			this._eventRaised = true;
		}
		
		[Test]
		public void TestChangedEvent() {
			this._list.Changed +=
				new EventHandler<LICollectionEventArgs<MockLIObject>>(ListOnChanged);
			
			Assert.IsFalse(this._eventRaised);

			this._list.Add(this._obj1);
			
			Assert.IsTrue(this._eventRaised);
			Assert.AreEqual(3, this._list.Count);
		}

		[Test]
		public void TestToString() {
			this._list = new LICollection<MockLIObject>();
			
			_obj1 = new MockLIObject("obj 1", 3);
			_obj2 = new MockLIObject("obj 2", 5);
			
			this._list.Add(_obj1);
			this._list.Add(_obj2);
			
			Assert.AreEqual("obj 1, obj 2", this._list.ToString());
		}
		
		[Test]
		public void TestConstructor() {
			LICollection<MockLIObject> copyList = new LICollection<MockLIObject>(this._list);
			Assert.IsNotNull(copyList);
			Assert.AreEqual(2, copyList.Count);
			Assert.AreEqual(_obj1, copyList[0]);
			Assert.AreEqual(_obj2, copyList[1]);
		}
		
		[Test]
		public void TestGetRange() {
			this._list = new LICollection<MockLIObject>();
			this._list.Add(new MockLIObject("a", 1));
			this._list.Add(new MockLIObject("b", 2));
			this._list.Add(new MockLIObject("c", 3));
			this._list.Add(new MockLIObject("d", 4));
			this._list.Add(new MockLIObject("e", 5));
			
			LICollection<MockLIObject> subList = this._list.GetRange(1, 3);
			Assert.IsNotNull(subList);
			Assert.AreEqual(3, subList.Count);
			Assert.AreEqual("b", subList[0].Adress);
			Assert.AreEqual("c", subList[1].Adress);
			Assert.AreEqual("d", subList[2].Adress);
		}
		
		[Test]
		public void TestConvertAll() {
			LICollection<byte> list = new LICollection<byte>();
			list.Add(1);
			list.Add(2);
			list.Add(3);
			
			LICollection<int> convertList = list.ConvertAll(new Converter<byte, int>(Convert.ToInt32));
			Assert.IsNotNull(convertList);
			Assert.AreEqual(3, convertList.Count);
			Assert.AreEqual(1, convertList[0]);
			Assert.AreEqual(2, convertList[1]);
			Assert.AreEqual(3, convertList[2]);
		}
		
		/// <summary>
		/// Test the Sort method.
		/// </summary>
		[Test]
		public void TestMethodSort()
		{
			Assert.That(_list.IndexOf(_obj1), Is.EqualTo(0));
			Assert.That(_list.IndexOf(_obj2), Is.EqualTo(1));
			
			_obj1.Phone = 15;
			_obj2.Phone = 2;
			
			_list.Sort();
			
			Assert.That(_list.IndexOf(_obj1), Is.EqualTo(1));
			Assert.That(_list.IndexOf(_obj2), Is.EqualTo(0));
		}
		
		#endregion
	}
}
