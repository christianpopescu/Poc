using NUnit.Framework;
using FileHelper;
using PocHelperLibrary.FileHelper;

namespace PocHelperLibraryTest
{
    [TestFixture]
    public class PlaceholderLineChangerTest
    {
        [Test]
        public void TestDefaultConstruction()
        {
            PlaceholderLineChanger plc = new PlaceholderLineChanger(new Dictionary<string, string>());

            Assert.AreEqual(@"\{\{", plc.regexBeginPattern);
            Assert.AreEqual(@"\}\}", plc.regexEndPattern);
            Assert.AreEqual(@"(?<=\{\{)(.*?)(?=\}\})", plc.regexPattern);
        }
    }
}