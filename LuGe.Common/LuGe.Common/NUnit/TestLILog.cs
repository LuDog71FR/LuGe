/*
 * User: Ludovic Germain
 * Date: 12/07/2007
 * Time: 10:38
 */

using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System;
using LuGe.Common;
using System.Diagnostics;
using System.IO;

namespace LuGe.Common.Tests
{
	/// <summary>
	/// Test the LILog class.
	/// </summary>
	[TestFixture]
	public class TestLILog
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		[SetUp]
		public void init() 
		{
			Assert.That(LILog.Switch, Is.Not.Null);
		}
		
		#if DEBUG
		/// <summary>
		/// Test the Debug method.
		/// </summary>
		[Test]
		public void TestDebugMethod() 
		{
			LILog.Debug(TraceLevel.Error, "the debug message");
			LILog.Debug(TraceLevel.Warning, "Message part1", "Message part2");
			
			Assert.That(File.Exists("events.log"), Is.True);
		}
		#endif

		#if TRACE
		/// <summary>
		/// Test the Trace method.
		/// </summary>
		[Test]
		public void TestTraceMethod() 
		{
			LILog.Trace(TraceLevel.Verbose, "the trace message");
			LILog.Trace(TraceLevel.Info, "Message part1", "Message part2");

			Assert.That(File.Exists("events.log"), Is.True);
		}
		#endif
		
		/// <summary>
		/// Test the ConvertToString method.
		/// </summary>
		[Test]
		public void TestConvertToString() 
		{
			byte[] values = new byte[] {57, 3, 6};
			
			Assert.That(LILog.ConvertToString(values), Is.EqualTo("57 , 3 , 6"));
		}
		
		#endregion
	}
}
