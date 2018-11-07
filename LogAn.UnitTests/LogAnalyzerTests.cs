using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        [Test]
        public void IsValidLogFileName_GoodExtensionUpperCase_ReturnTrue()
        {
            FakeExtensionManager myFakerManager = new FakeExtensionManager();
            myFakerManager.WillBeValid = true;

            var log = MakerAnalyser(myFakerManager);

            var result = log.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowerCase_ReturnTrue()
        {

            FakeExtensionManager myFakerManager = new FakeExtensionManager();
            myFakerManager.WillBeValid = true;

            var log = MakerAnalyser(myFakerManager);
            var result = log.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnFalse()
        {

            FakeExtensionManager myFakerManager = new FakeExtensionManager();
            myFakerManager.WillBeValid = false;

            var log = MakerAnalyser(myFakerManager);
            var result = log.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_ReturnException()
        {

            FakeExtensionManager myFakerManager = new FakeExtensionManager();
            myFakerManager.WillBeValid = false;

            var log = MakerAnalyser(myFakerManager);
            var ex = Assert.Catch<Exception>(() => log.IsValidLogFileName(string.Empty));

            Assert.That(ex.Message, Does.Contain("file has to be provide"));
        }

        //[TestCase("filenamewitbadextension.foo", false)]
        //[TestCase("filenamewithgoodextension.slf", true)]
        //public void IsValidLogFileName_WhenCalled_ChangeWasLastFileNameValid(string fileName, bool expected)
        //{
        //    var log = MakerAnalyser();

        //    log.IsValidLogFileName(fileName);

        //    Assert.AreEqual(expected, log.WasLastFileNameValid);
        //}

        public LogAnalyzer MakerAnalyser(IExtensionManager extensionManager)
        {
            return new LogAnalyzer(extensionManager);
        }
    }
}