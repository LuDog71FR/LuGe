/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 14:05
 */

using NUnit.Framework;
using System;
using LuGe.Common.Data;

namespace LuGe.Common.Data.Tests
{
	[TestFixture]
	public class TestLIParameter
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[Test]
		public void TestFirstConstructor() {
			string name = "adress";
			LIParameter parameter = new LIParameter(name);
			
			Assert.IsNotNull(parameter);
			Assert.AreEqual(name, parameter.Name);
			Assert.AreEqual(name, parameter.Key);
			Assert.IsNull(parameter.Value);
		}
		
		[Test]
		public void TestSecondConstructor() {
			string name = "adress";
			LIParameter parameter = new LIParameter(name, 18);
			
			Assert.IsNotNull(parameter);
			Assert.AreEqual(name, parameter.Name);
			Assert.AreEqual(name, parameter.Key);
			Assert.AreEqual(18, parameter.Value);
		}
		
		[ExpectedException("System.ArgumentNullException"), Test]
		public void TestRaiseException() {
			LIParameter parameter = new LIParameter(string.Empty);
		}

		#endregion
	}
}
