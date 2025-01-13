/*
 * User: Ludovic Germain
 * Date: 23/01/2008 14:43:09
 */

using System;
using System.IO;
using NUnit.Framework;
using LuGe.Common;

namespace LuGe.Common.Tests
{
    [TestFixture]
    public class TestLIFile
    {

        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods

        [Test]
        public void TestIsfileLocked()
        {
        	var fileInfo = new FileInfo("testingFiles/FileA.txt");
        	Assert.IsFalse(LIFile.IsFileLocked(fileInfo));
        	
        	using (var stream = fileInfo.OpenRead())
        	{
        		Assert.IsTrue(LIFile.IsFileLocked(fileInfo));
        	}
        	
        	File.Copy("testingFiles/FileA.txt", @"\\mcn-files\Transit\Marketing\FileA.txt");
        	
        	fileInfo = new FileInfo(@"\\mcn-files\Transit\Marketing\FileA.txt");
        	Assert.IsTrue(fileInfo.Exists);
        	Assert.IsFalse(LIFile.IsFileLocked(fileInfo));
        	
        	using (var stream = fileInfo.OpenRead())
        	{
        		Assert.IsTrue(LIFile.IsFileLocked(fileInfo));
        	}
        }
        
        /// <summary>
        /// Test the Equals method : files specified are equals.
        /// </summary>
        [Test]
        public void TestFileAreEquals()
        {
            Assert.IsTrue(LIFile.Equals("testingFiles/FileA.txt", "testingFiles/FileB.txt"));
        }

        /// <summary>
        /// Test the Equals method : files specified are not equals.
        /// </summary>
        [Test]
        public void TestFileAreNotEquals()
        {
            Assert.IsFalse(LIFile.Equals("testingFiles/FileA.txt", "testingFiles/FileC.txt"));
        }
        
        /// <summary>
        /// Test the NumberOfLines method.
        /// </summary>
        [Test]
        public void TestNumberOfLines()
        {
            Assert.AreEqual(4, LIFile.NumberOfLines("testingFiles/FileA.txt"));
            Assert.AreEqual(3, LIFile.NumberOfLines("testingFiles/FileC.txt"));
        }

        #endregion
    }
}
