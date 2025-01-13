/*
 * User: Ludovic Germain
 * Date: 20/07/2007
 * Time: 14:12
 */

using NUnit.Framework;
using System;
using LuGe.Common.Data;
using System.Text;

namespace LuGe.Common.Data.Tests
{
	[TestFixture]
	public class TestLIParameterCollection
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[Test]
		public void TestExtractParametersMethod() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmWeight  LIKE @rmWeight1 ");
			sql.Append("And rmIndex = @rmIndex;");
			
			LIParameterCollection parameters =
				LIParameterCollection.ExtractParameters(sql.ToString());
			
			Assert.IsNotNull(parameters);
			Assert.AreEqual(2, parameters.Count);
			Assert.IsTrue(parameters.Contains("rmWeight1"));
			Assert.IsTrue(parameters.Contains("rmIndex"));
		}
		
		[Test]
		public void TestExtractParametersMethodWithEqualParameter() {
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmWeight  > @rmWeight ");
			sql.Append("Union ");
			sql.Append("Select * ");
			sql.Append("From RawMaterial ");
			sql.Append("Where rmWeight  = @rmWeight;");
			
			LIParameterCollection parameters =
				LIParameterCollection.ExtractParameters(sql.ToString());
			
			Assert.IsNotNull(parameters);
			Assert.AreEqual(1, parameters.Count);
			Assert.IsTrue(parameters.Contains("rmWeight"));
		}
		
		#endregion
	}
}
