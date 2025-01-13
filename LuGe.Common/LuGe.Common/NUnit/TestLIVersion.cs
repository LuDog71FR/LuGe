/*
 * User: lgermain
 * Date: 07/07/2008 11:49
 */

using System;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace LuGe.Common.Tests
{
	/// <summary>
	/// Tests the LIVersion class.
	/// </summary>
	[TestFixture]
	public class TestLIVersion
	{
	
		#region Fields
		
		private LIVersion _version;
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Initialize the LIVersion object to test.
		/// </summary>
		[SetUp]
		public void Init() {
			Assembly assembly = Assembly.GetExecutingAssembly();
			_version = new LIVersion(assembly);
			
			Assert.That(_version, Is.Not.Null);
			Assert.That(_version.Assembly, Is.SameAs(assembly));
		}
		
		/// <summary>
		/// Test all version number properties.
		/// </summary>
		[Test]
		public void TestVersionNumber()
		{
			Assert.That(_version.FullVersion, Is.EqualTo("2.0.0.0"));
			Assert.That(_version.Major, Is.EqualTo(2));
			Assert.That(_version.Minor, Is.EqualTo(0));
			Assert.That(_version.Build, Is.EqualTo(0));
			Assert.That(_version.Revision, Is.EqualTo(0));
		}
		
		#endregion
		
	}
}
