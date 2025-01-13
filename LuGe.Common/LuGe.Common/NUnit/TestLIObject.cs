/*
 * User: Ludovic Germain
 * Date: 11/07/2007
 * Time: 13:45
 */

using NUnit.Framework;
using System;

namespace LuGe.Common.Tests
{
	/// <summary>
	/// Testing class for the LIObject class.
	/// </summary>
	[TestFixture]
	public class TestLIObject
	{
		#region Fields
		
		private MockLIObject _myObj;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Create a new instance of the mock object.
		/// </summary>
		[SetUp]
		public void Init() {
			this._myObj = new MockLIObject();
		}
		
		/// <summary>
		/// Testing the instance of the mock object.
		/// </summary>
		[Test]
		public void TestInstance() {			
			Assert.IsNotNull(this._myObj);
		}
		
		/// <summary>
		/// Testing the Resources property from the base class LIObject.
		/// </summary>
		[Test]
		public void TestResourcesProperty() {
			Assert.AreEqual("Phone number must be different from 0.",
			                this._myObj.MockResources.GetString("Error : Phone = 0"));
			
		}

		/// <summary>
		/// Testing SetError method from the base class LIObject.
		/// </summary>
		[Test]
		public void TestSetErrorMethod() {
			Assert.IsNotNull(this._myObj);
			
			Assert.IsFalse(this._myObj.IsError);
			Assert.IsEmpty(this._myObj.ErrorMsg);
			
			this._myObj.MockSetError();
			
			Assert.IsTrue(this._myObj.IsError);
			Assert.IsNotEmpty(this._myObj.ErrorMsg);
		}

		/// <summary>
		/// Testing ClearError method from the base class LIObject.
		/// </summary>
		[Test]
		public void TestClearErrorMethod() {
			Assert.IsNotNull(this._myObj);
			
			this._myObj.MockSetError();
			Assert.IsNotEmpty(this._myObj.ErrorMsg);

			this._myObj.MockClearError();
			
			Assert.IsFalse(this._myObj.IsError);
			Assert.IsEmpty(this._myObj.ErrorMsg);
		}

		#endregion
	}
}
