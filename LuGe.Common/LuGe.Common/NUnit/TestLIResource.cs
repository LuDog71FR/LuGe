/*
 * User: Ludovic Germain
 * Date: 09/01/2008 17:01:43
 */

using System;
using System.IO;
using System.Xml;
using System.Drawing;
using NUnit.Framework;
using LuGe.Common;

namespace LuGe.Common.Tests
{
    [TestFixture]
    public class TestLIResource
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
        /// Save an embedded file to a physical file.
        /// </summary>
        [TestAttribute]
        public void TestSaveEmbeddedFile()
        {
            if (File.Exists(OutputFileName)) File.Delete(OutputFileName);
            
            LIResource.SaveEmbeddedFile("Resources.myTextFile.txt", OutputFileName);

            Assert.AreEqual(
                File.ReadAllText(FileName),
                File.ReadAllText(OutputFileName));
        }

        /// <summary>
        /// Extract a stream from an embedded text file.
        /// </summary>
        [Test]
        public void TestExtractStream()
        {
            Stream fs = LIResource.GetEmbeddedFile("Resources.myTextFile.txt");

            Assert.IsNotNull(fs);
            // TODO : Make more assertions !
        }

        /// <summary>
        /// Extract a string from an embedded text file.
        /// </summary>
        [Test]
        public void TestExtractText()
        {
            Assert.AreEqual(
                File.ReadAllText("Resources/myTextFile.txt"),
                LIResource.GetEmbeddedString("Resources.myTextFile.txt"));
        }

        /// <summary>
        /// Extract a xmlDocument from an embedded xml file.
        /// </summary>
        [Test]
        public void TestExtractXml()
        {
            XmlDocument doc = LIResource.GetEmbeddedXml("Resources.myXmlFile.xml");

            Assert.IsNotNull(doc);
            // TODO : Make more assertions !
        }

        /// <summary>
        /// Extract a bitmap from an embedded image file.
        /// </summary>
        [Test]
        public void TestExtractImage()
        {
            Bitmap img = LIResource.GetEmbeddedImage("Resources.myImage.bmp");

            Assert.IsNotNull(img);
            // TODO : Make more assertions !
        }

        #endregion

    }
}
