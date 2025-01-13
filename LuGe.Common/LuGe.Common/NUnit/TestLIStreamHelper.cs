/*
 * User: Ludovic Germain
 * Date: 21/01/2008 15:31:26
 */

using System;
using System.IO;
using NUnit.Framework;
using LuGe.Common;

namespace LuGe.Common.Tests
{
    [TestFixture]
    public class TestLIStreamHelper
    {

        #region Constants

        private const string FileName = "Resources/myTextFile.txt";
        private const string OutputFileName = "Resources/myNewTextFile.txt";

        #endregion

        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Save a stream to a file.
        /// </summary>
        [Test]
        public void TestSaveStreamToFile()
        {
            Assert.IsTrue(File.Exists(FileName));
            if (File.Exists(OutputFileName)) File.Delete(OutputFileName);

            StreamReader str = new StreamReader(FileName);
            Assert.IsNotNull(str);

            LIStreamHelper.SaveStreamToFile(str.BaseStream, OutputFileName, FileMode.CreateNew);

            Assert.IsTrue(File.Exists(OutputFileName));
            Assert.AreEqual(
                File.ReadAllText(FileName),
                File.ReadAllText(OutputFileName));
        }

        #endregion

    }
}
