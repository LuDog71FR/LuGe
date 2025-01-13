/*
 * User: lgermain
 * Date: 08/10/2008 15:28
 */

using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using LuGe.Common;

namespace LuGe.Common.Tests
{
	/// <summary>
	/// Test the LIZip class.
	/// </summary>
	[TestFixture]
	public class TestLIZip
	{
		
		#region Fields
		
		private LIZip _ziper;
		
		#endregion

		#region Constructors
		
		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Test the BZip method.
		/// </summary>
		[Test]
		public void TestBZipMethod()
		{
			string zipFileName = "testingFiles\\testingFiles2.bz2";
			
			File.Delete(zipFileName);
			
			_ziper = new LIZip(zipFileName);
			
			Assert.That(_ziper, Is.Not.Null);
			Assert.That(_ziper.CompressionLevel, Is.EqualTo(9));
			Assert.That(_ziper.ZipFileName, Is.EqualTo(zipFileName));
			
			_ziper.BZip("testingFiles\\FileA.txt");
			
			Assert.That(File.Exists(zipFileName), Is.True);
		}
		
		
		/// <summary>
		/// Test the Zip method.
		/// </summary>
		[Test]
		public void TestZipMethod()
		{
			string zipFileName = "testingFiles\\testingFiles2.zip";
			
			File.Delete(zipFileName);
			
			_ziper = new LIZip(zipFileName);
			
			Assert.That(_ziper, Is.Not.Null);
			Assert.That(_ziper.CompressionLevel, Is.EqualTo(9));
			Assert.That(_ziper.ZipFileName, Is.EqualTo(zipFileName));
			
			_ziper.Zip(new string[] {
			           	"testingFiles\\FileA.txt",
			           	"testingFiles\\FileB.txt",
			           	"testingFiles\\FileC.txt"});
			
			Assert.That(File.Exists(zipFileName), Is.True);
		}
		
		/// <summary>
		/// Test the UnZip method.
		/// </summary>
		[Test]
		public void TestUnZipMethod()
		{
			_ziper = new LIZip("testingFiles\\testingFiles.zip");
			
			Assert.That(_ziper, Is.Not.Null);
			Assert.That(_ziper.CompressionLevel, Is.EqualTo(9));
			Assert.That(_ziper.ZipFileName, Is.EqualTo("testingFiles\\testingFiles.zip"));
			
			string path = "testingFiles\\unzipedFiles";
			if (Directory.Exists(path)) Directory.Delete(path, true);
			
			Directory.CreateDirectory(path);
			
			_ziper.UnZip(path);
			
			Assert.That(File.Exists(Path.Combine(path, "FileA.txt")), Is.True);
			Assert.That(File.Exists(Path.Combine(path, "FileB.txt")), Is.True);
			Assert.That(File.Exists(Path.Combine(path, "FileC.txt")), Is.True);
		}
		
		/// <summary>
		/// Test the UnZipByteArray method.
		/// </summary>
		[Test]
		public void TestUnZipByteArrayMethod()
		{
			byte[] zippedData = File.ReadAllBytes("testingFiles\\testingFiles.zip");
			Assert.That(zippedData, Is.Not.Null);
			
			byte[] unzippedData = LIZip.UnZipByteArray(zippedData);
			Assert.That(unzippedData, Is.Not.Null);
			
			string textData = Encoding.ASCII.GetString(unzippedData);
			Assert.That(textData, Is.Not.Empty);
			
			StringBuilder expectedText = new StringBuilder();
			expectedText.Append(File.ReadAllText("testingFiles\\FileA.txt"));
			expectedText.Append(File.ReadAllText("testingFiles\\FileB.txt"));
			expectedText.Append(File.ReadAllText("testingFiles\\FileC.txt"));
			
			Assert.That(textData, Is.EqualTo(expectedText.ToString()));
		}
		
		/// <summary>
		/// Test the ZipByteArray method.
		/// </summary>
		[Test]
		public void TestZipByteArrayMethod()
		{
			byte[] zippedData = File.ReadAllBytes("testingFiles\\testingFiles.zip");
			Assert.That(zippedData, Is.Not.Null);
			
			byte[] unzippedData = LIZip.UnZipByteArray(zippedData);
			Assert.That(unzippedData, Is.Not.Null);
			
			byte[] newZippedData = LIZip.ZipByteArray(unzippedData);
			Assert.That(newZippedData, Is.Not.Null);
			
			byte[] newUnzippedData = LIZip.UnZipByteArray(newZippedData);
			Assert.That(newUnzippedData, Is.EqualTo(unzippedData));
		}
		
		#endregion

	}
}
