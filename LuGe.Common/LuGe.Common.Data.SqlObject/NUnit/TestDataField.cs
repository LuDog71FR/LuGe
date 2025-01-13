/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 13:40
 */

using NUnit.Framework;
using System;
using LuGe.Common.Data.SqlObject;

namespace LuGe.Common.Data.SqlObject.Tests
{
	[TestFixture]
	public class TestDataField
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[Test]
		public void TestInstanciateField() {
			string name = "rmIndex";
			LIDataField field = new LIDataField(name);
			
			Assert.IsNotNull(field);
			Assert.AreEqual(name, field.Key);
			Assert.AreEqual(name, field.Name);
			Assert.AreEqual(name, field.ToString());
		}
		
		#endregion
	}
}
