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
        public void TestLinePatternDetectFalse() 
        {
            
            DataGeneratorService dgs = new DataGeneratorService();
            
            PlaceholderLineChanger plc = new PlaceholderLineChanger(dgs.GetPlacehoderDictionary());

            Assert.AreEqual(false, plc.IsLineToProcess("abc"));
            Assert.AreEqual(false, plc.IsLineToProcess("{bcd}}"));
            Assert.AreEqual(false, plc.IsLineToProcess("{{a_d}}"));
        }

        [Test]
        public void TestLinePatternDetectTrue()
        {

            DataGeneratorService dgs = new DataGeneratorService();

            PlaceholderLineChanger plc = new PlaceholderLineChanger(dgs.GetPlacehoderDictionary());

            Assert.AreEqual(true, plc.IsLineToProcess("1234{{abc}}"));
            Assert.AreEqual(true, plc.IsLineToProcess("{{abc}}"));
            Assert.AreEqual(true, plc.IsLineToProcess("{{bcd}}"));
            Assert.AreEqual(true, plc.IsLineToProcess("   {{bcd}}   {{abc}} 1111"));
        }

        [Test]
        public void TestLineTransform()
        {
            DataGeneratorService dgs = new DataGeneratorService();

            PlaceholderLineChanger plc = new PlaceholderLineChanger(dgs.GetPlacehoderDictionary());

            string result = "";
            plc.ProcessLine("{{abc}}", ref result);
            Assert.AreEqual("123", result);
            plc.ProcessLine("{{bcd}}", ref result);
            Assert.AreEqual("345", result);
            plc.ProcessLine("A{{abc}}", ref result);
            Assert.AreEqual("A123", result);
            plc.ProcessLine("{{abc}}B", ref result);
            Assert.AreEqual("123B", result);
            plc.ProcessLine("A{{abc}}B{{bcd}}XX", ref result);
            Assert.AreEqual("A123B345XX", result);
        }
    }
}