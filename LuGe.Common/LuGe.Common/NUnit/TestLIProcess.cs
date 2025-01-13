/*
 * User: Ludovic Germain
 * Date: 03/10/2007 15:54:10
 */

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using LuGe.Common;

namespace LuGe.Common.Tests
{
    [TestFixture]
    public class TestLIProcess
    {

        #region Fields

        private LIProcess _process;

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Initialize the object used for the test.
        /// </summary>
        [SetUp]
        public void Init()
        {
            _process = new LIProcess();

            Assert.That(_process, Is.Not.Null);
            Assert.That(_process.Delay, Is.EqualTo(10000));
            Assert.That(_process.MustWait, Is.True);
        }

        /// <summary>
        /// Test the Start method.
        /// </summary>
        [Test]
        public void TestStart()
        {
            _process.FileName = "testingFiles\\process.bat";
            _process.Start();

            Assert.That(_process.HasExited, Is.True);
            Assert.That(_process.ExitCode, Is.EqualTo(0));
            Assert.That(_process.Message, Is.EqualTo("my process is working !\r\n"));
        }

        /// <summary>
        /// Test the Stop method.
        /// </summary>
        [Test]
        public void TestStop()
        {
        	_process.MustWait = false;
            _process.FileName = "testingFiles\\processWait.bat";
            _process.Start();

            Assert.That(_process.HasExited, Is.False);
            
            _process.Stop();
            
            Assert.That(_process.HasExited, Is.True);
        }

        #endregion

    }
}
