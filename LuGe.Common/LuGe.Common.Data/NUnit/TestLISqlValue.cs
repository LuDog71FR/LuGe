/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 09:26
 */

using NUnit.Framework;
using System;
using LuGe.Common.Data;

namespace LuGe.Common.Data.Tests
{
	[TestFixture]
	public class TestLISqlValue
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[Test]
		public void TestConvertToSqlMethod() {
			string text = LISqlValue.ConvertToSql("l'enfant");
			
			Assert.AreEqual("l''enfant", text);
		}
		
		#endregion
	}
}
