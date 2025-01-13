/*
 * User: lgermain
 * Date: 03/07/2008 10:20
 */

using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace LuGe.Common.Data.Tests
{
	/// <summary>
	/// Test the LIProvider class.
	/// </summary>
	[TestFixture]
	public class TestLIProvider
	{
	
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Test the List method.
		/// </summary>
		[Test]
		public void TestList() 
		{
			List<string> providers = new List<string>(LIProvider.List());
			
			Assert.That(providers, Is.Not.Null);
			Assert.That(providers.Count, Is.GreaterThan(0));
			Assert.That(providers, Has.Member("System.Data.SQLite"));
		}
		
		/// <summary>
		/// Test the Exists method.
		/// </summary>
		[Test]
		public void TestExists() 
		{
			bool exists;
			
			exists = LIProvider.Exists("unknow provider");
			Assert.That(exists, Is.False);
			
			exists = LIProvider.Exists("System.Data.SQLite");
			Assert.That(exists, Is.True);
		}
		
		#endregion
		
	}
}
