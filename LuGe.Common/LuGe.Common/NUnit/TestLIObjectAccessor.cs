/*
 * User: Ludovic Germain
 * Date: 19/07/2007
 * Time: 14:59
 */

using NUnit.Framework;
using System;
using LuGe.Common;
using LuGe.Common.Collection;

namespace LuGe.Common.Tests
{
	[TestFixture]
	public class TestLIObjectAccessor
	{
		#region Fields
		
		private LIObjectAccessor _accessor;
		private MockLIObject _object;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[SetUp]
		public void Init() {
			_object = new MockLIObject("a", 123);
			_accessor = new LIObjectAccessor(_object);
		}
		
		[Test]
		public void TestInstanceProperty() {
			Assert.IsNotNull(this._object);
			Assert.IsNotNull(this._accessor);
			
			Assert.AreEqual(this._object, this._accessor.Instance);
		}
		
		[Test]
		public void TestGetFieldMethod() {
			string adress = (string)this._accessor.GetField("_adress");
			Assert.AreEqual("a", adress);
			
			int phone = (int)this._accessor.GetField("_phone");
			Assert.AreEqual(123, phone);
		}

		[Test]
		public void TestGetPropertyMethod() {
			string internalField =
				(string)this._accessor.GetProperty("InternalField");
			Assert.AreEqual("internal", internalField);
		}

		[Test]
		public void TestInvokeMethod() {
			object returnObject =
				this._accessor.Invoke("ChangeInternalField");
			
			Assert.IsNull(returnObject);
			Assert.AreEqual("changed", this._object.PublicInternalField);
		}

		[Test]
		public void TestInvokeMethodWithParams() {
			bool returnObject =
				(bool)this._accessor.Invoke("ChangeAdressAndPhone",
				                            "b", 456);
			
			Assert.IsTrue(returnObject);
			Assert.AreEqual("b", this._object.Adress);
			Assert.AreEqual(456, this._object.Phone);
		}

		[Test]
		public void TestSetFieldMethod() {
			this._accessor.SetField("_phone", 987);
			Assert.AreEqual(987, this._object.Phone);
		}

		[Test]
		public void TestSetPropertyMethod() {
			this._accessor.SetProperty("InternalField", "changed");
			Assert.AreEqual("changed", this._object.PublicInternalField);
		}

		[Test]
		public void TestConstructorWithType() {
			LIObjectAccessor accessor = new LIObjectAccessor(
				typeof(MockLIObject),
				"c", 678);
			
			Assert.IsNotNull(accessor);
			Assert.IsNotNull(accessor.Instance);
			Assert.AreEqual(Type.GetType("LuGe.Common.Tests.MockLIObject"),
			                accessor.Instance.GetType());
			
			MockLIObject mockObject = (MockLIObject)accessor.Instance;
			
			Assert.AreEqual("c", mockObject.Adress);
			Assert.AreEqual(678, mockObject.Phone);
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void TestConstructorWithTypeNameEmpty() {
			LIObjectAccessor accessor = new LIObjectAccessor(
				String.Empty,
				"c", 678);
		}
		
		[Test]
		public void TestConstructorWithTypeName() {
			LIObjectAccessor accessor = new LIObjectAccessor(
				"LuGe.Common.Tests.MockLIObject, LuGe.Common.Tests",
				"c", 678);
			
			Assert.IsNotNull(accessor);
			Assert.IsNotNull(accessor.Instance);
			Assert.AreEqual(Type.GetType("LuGe.Common.Tests.MockLIObject"),
			                accessor.Instance.GetType());
			
			MockLIObject mockObject = (MockLIObject)accessor.Instance;
			
			Assert.AreEqual("c", mockObject.Adress);
			Assert.AreEqual(678, mockObject.Phone);
		}

		[Test]
		public void TestInvokeMethodWithRefParams()
		{
			string[] types = new String[] { "System.String&" };
			Object[] args = new Object[] { "My adress" };

			bool returnObject = (bool)this._accessor.Invoke(
				"GetAdressByRef",
				types,
				ref args);

			Assert.IsTrue(returnObject);
			Assert.AreEqual(this._object.Adress, (string)args[0]);
		}

		[Test]
		public void TestInvokeMethodWithOutParams()
		{
			Object[] args = new Object[] { null };

			bool returnObject =
				(bool)this._accessor.Invoke("GetAdressByOut",
				                            new String[] { "System.String&" },
				                            ref args);

			Assert.IsTrue(returnObject);
			Assert.AreEqual(this._object.Adress, (string)args[0]);
		}

		[Test]
		public void TestInvokeStatic()
		{
			object result = LIObjectAccessor.Invoke(typeof(MockLIObject), "IsTrue");
			
			Assert.IsNotNull(result);
			Assert.IsTrue((bool)result);
		}
		
		[Test]
		public void TestInvokeMethodWithString() {
			object result = LIObjectAccessor.Invoke(typeof(MockLIObject), "GetAdress");
			
			Assert.IsNotNull(result);
			Assert.AreEqual(result, "My adress");
		}
		
		#endregion
	}
}
