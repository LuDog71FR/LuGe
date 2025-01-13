/*
 * User: Ludovic Germain
 * Date: 13/07/2007
 * Time: 15:21
 */

using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System;
using System.IO;
using LuGe.Common;

namespace LuGe.Common.Tests
{
	/// <summary>
	/// Test the LIXmlHelper class.
	/// </summary>
	[TestFixture]
	public class TestLIXmlHelper
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Test the FormatString method.
		/// </summary>
		[Test]
		public void TestFormatString() 
		{
			string xmlText = "<?xml version=\"1.0\"?><sourceTest></sourceTest>";
			string xmlTextFormatted = "<?xml version=\"1.0\"?>\r\n<sourceTest>\r\n</sourceTest>";
			string outText = LIXmlHelper.FormatString(xmlText);
			
			Assert.That(outText, Is.EqualTo(xmlTextFormatted));
			
		}
		
		/// <summary>
		/// Test the ValidateString method.
		/// </summary>
		[Test]
		public void TestValidateString() 
		{
			Assert.That(LIXmlHelper.ValidateString(
				File.ReadAllText("testingFiles/sourceTest.xml")), Is.True);
			Assert.That(LIXmlHelper.Errors, Is.Empty);
		}
		
		/// <summary>
		/// Test the ValidateString method.
		/// </summary>
		[Test]
		public void TestValidateStringFalse() 
		{
			Assert.That(LIXmlHelper.ValidateString(
				File.ReadAllText("testingFiles/sourceTestWrong.xml")), Is.False);
			Assert.That(LIXmlHelper.Errors, Is.Not.Empty);
		}
		
		/// <summary>
		/// Test the Validate method.
		/// </summary>
		[Test]
		public void TestValidate() 
		{
			Assert.That(LIXmlHelper.Validate("testingFiles/sourceTest.xml"), Is.True);			
			Assert.That(LIXmlHelper.Errors, Is.Empty);
		}
		
		/// <summary>
		/// Test the Validate method.
		/// </summary>
		[Test]
		public void TestValidateFalse() 
		{
			Assert.That(LIXmlHelper.Validate("testingFiles/sourceTestWrong.xml"), Is.False);			
			Assert.That(LIXmlHelper.Errors, Is.Not.Empty);
		}
		
		/// <summary>
		/// Test the Validate method with schema.
		/// </summary>
		[Test]
		public void TestValidateWithSchema() 
		{
			Assert.That(LIXmlHelper.Validate("testingFiles/sourceTest.xml",
			                                   "testingFiles/sourceTest.xsd"), Is.True);			
			Assert.That(LIXmlHelper.Errors, Is.Empty);
		}
		
		/// <summary>
		/// Test the Validate method with schema.. Error against the schema.
		/// </summary>
		[Test]
		public void TestValidateWithSchemaFalse() 
		{
			Assert.That(LIXmlHelper.Validate("testingFiles/sourceTest.xml",
			                                   "testingFiles/sourceTestFalse.xsd"),Is.False);
			Assert.That(LIXmlHelper.Errors, Is.Not.Empty);
		}
		
		/// <summary>
		/// Test the Validate method with schema. Error against XML syntax.
		/// </summary>
		[Test]
		public void TestValidateWithSchemaFalseSyntax() 
		{
			Assert.That(LIXmlHelper.Validate("testingFiles/sourceTestWrong.xml",
			                                   "testingFiles/sourceTest.xsd"),Is.False);
			Assert.That(LIXmlHelper.Errors, Is.Not.Empty);
		}
		
		/// <summary>
		/// Test the Infer method.
		/// </summary>
		[Test]
		public void TestInfer() 
		{
			File.Delete("testingFiles/sourceTest_NEW.xsd");
			
			LIXmlHelper.Infer("testingFiles/sourceTest.xml",
			                  "testingFiles/sourceTest_NEW.xsd");
			
			Assert.That(File.Exists("testingFiles/sourceTest_NEW.xsd"), Is.True);
		}
		
		/// <summary>
		/// Test the Transform method.
		/// </summary>
		[Test]
		public void TestTransform() 
		{
			File.Delete("testingFiles/sourceTest_NEW.xml");
			
			LIXmlHelper.Transform("testingFiles/sourceTest.xml",
			                      "testingFiles/sourceTest_NEW.xml",
			                      "testingFiles/sourceTest.xsl");
			
			Assert.That(File.Exists("testingFiles/sourceTest_NEW.xml"), Is.True);
		}

		#endregion
	}
}
