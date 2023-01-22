using NUnit.Framework;
using FileHelper;
using PocHelperLibrary.FileHelper;
using PocHelperLibraryTest.TestDataGenerator;

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

        [Test]
        public void TestLinePatternDetecFalse() 
        {
            
            DataGeneratorService dgs = new DataGeneratorService();
            
            PlaceholderLineChanger plc = new PlaceholderLineChanger(dgs.GetPlacehoderDictionary());

            Assert.AreEqual(false, plc.IsLineToProcess("abc"));
            Assert.AreEqual(false, plc.IsLineToProcess("{bcd}}"));
            Assert.AreEqual(false, plc.IsLineToProcess("{{a_d}}"));
        }

        [Test]
        public void TestLinePatternDetecTrue()
        {

            DataGeneratorService dgs = new DataGeneratorService();

            PlaceholderLineChanger plc = new PlaceholderLineChanger(dgs.GetPlacehoderDictionary());

            Assert.AreEqual(true, plc.IsLineToProcess("1234{{abc}}"));
            Assert.AreEqual(true, plc.IsLineToProcess("{{abc}}"));
            Assert.AreEqual(true, plc.IsLineToProcess("{{bcd}}"));
            Assert.AreEqual(true, plc.IsLineToProcess("   {{bcd}}   {{abc}} 1111"));
        }

    }
}