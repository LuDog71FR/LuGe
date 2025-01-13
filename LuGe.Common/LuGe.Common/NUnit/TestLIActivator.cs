/*
 * User: Ludovic Germain
 * Date: 13/07/2007
 * Time: 11:28
 */

using System;
using System.Collections;
using System.Reflection;

using LuGe.Common.Collection;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace LuGe.Common.Tests
{
	[TestFixture]
	public class TestLIActivator
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[Test]
		public void TestGetInstance() {
			int[] myArray = {1, 2, 3};
			Object[] parameters = {myArray};
			
			Object obj = LIActivator.GetInstance(
				Assembly.GetAssembly(Type.GetType("System.Collections.ArrayList")),
				"System.Collections.ArrayList",
				parameters);
			
			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.GetType().Name, "ArrayList");
			
			ArrayList list = (ArrayList)obj;
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual(1, list[0]);
			Assert.AreEqual(2, list[1]);
			Assert.AreEqual(3, list[2]);
		}
		
		[Test]
		public void TestGetInstanceFromAssembly() {
			Object obj = LIActivator.GetInstance(Assembly.GetExecutingAssembly(),
			                                     "LuGe.Common.Tests.MockLIObject");
			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.GetType().Name, "MockLIObject");
		}
		
		[Test]
		public void TestGetInstanceFromAssemblyName() {
			Object obj = LIActivator.GetInstance("LuGe.Common.Tests.dll",
			                                     "LuGe.Common.Tests.MockLIObject");
			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.GetType().Name, "MockLIObject");
		}
		
		[Test]
		public void TestGetInstanceFromAssemblyWithParams() {
			Object[] parameters = {"My address", 2345};
			Object obj = LIActivator.GetInstance(Assembly.GetExecutingAssembly(),
			                                     "LuGe.Common.Tests.MockLIObject",
			                                     parameters);
			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.GetType().Name, "MockLIObject");
			
			MockLIObject mockObj = (MockLIObject)obj;
			Assert.IsNotNull(mockObj);
			Assert.AreEqual("My address", mockObj.Adress);
			Assert.AreEqual(2345, mockObj.Phone);
		}
		
		[Test]
		public void TestGetInstanceFromAssemblyNameWithParams() {
			Object[] parameters = {"My address", 2345};
			Object obj = LIActivator.GetInstance("LuGe.Common.Tests.dll",
			                                     "LuGe.Common.Tests.MockLIObject",
			                                     parameters);
			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.GetType().Name, "MockLIObject");
			
			MockLIObject mockObj = (MockLIObject)obj;
			Assert.IsNotNull(mockObj);
			Assert.AreEqual("My address", mockObj.Adress);
			Assert.AreEqual(2345, mockObj.Phone);
		}
		
		[Test]
		public void TestGetInstanceFromAssemblyAndType() {
			Object obj = LIActivator.GetInstance(
				Assembly.GetExecutingAssembly(),
				Type.GetType("LuGe.Common.Tests.MockLIObject"));
			
			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.GetType().Name, "MockLIObject");
		}
		
		[Test]
		public void TestGetInstanceFromAssemblyAndTypeWithParams() {
			Object[] parameters = {"My address", 2345};
			Object obj = LIActivator.GetInstance(
				Assembly.GetExecutingAssembly(),
				Type.GetType("LuGe.Common.Tests.MockLIObject"),
				parameters);
			
			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.GetType().Name, "MockLIObject");
			
			MockLIObject mockObj = (MockLIObject)obj;
			Assert.IsNotNull(mockObj);
			Assert.AreEqual("My address", mockObj.Adress);
			Assert.AreEqual(2345, mockObj.Phone);
		}
		
		/// <summary>
		/// Test the IsBaseClassOf method.
		/// </summary>
		[Test]
		public void TestMethodIsBaseClassOf() 
		{
			MockLIObject obj = new MockLIObject();
			Assert.That(obj, Is.Not.Null);
			
			bool result = LIActivator.IsBaseClassOf(obj, typeof(LIObject));
			Assert.That(result, Is.True);
		}
		
		/// <summary>
		/// Test the IsImplementing method.
		/// </summary>
		[Test]
		public void TestMethodIsImplementing()
		{
			MockLIObject obj = new MockLIObject();
			Assert.That(obj, Is.Not.Null);
			
			bool result = LIActivator.IsImplementing(obj, typeof(IKeyedItem).Name);
			Assert.That(result, Is.True);			
			
			result = LIActivator.IsImplementing(obj, "IUnknown");
			Assert.That(result, Is.False);			
		}
		
		#endregion
		
	}
}
