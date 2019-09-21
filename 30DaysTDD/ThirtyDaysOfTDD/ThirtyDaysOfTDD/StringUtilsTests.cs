using System;
using System.Linq;
using NUnit.Framework;

namespace ThirtyDaysOfTDD.UnitTests
 {
     [TestFixture]
     public class StringUtilsTests
     {

        private StringUtils _stringUtils;

        [SetUp]
        public void SetupStringUtilTests()
        {
            _stringUtils = new StringUtils();
        }

        [Test]
         public void ShouldBeAbleToCountNumberOfLettersInSimpleSentence()
         {
            var sentenceToScan = "TDD is awesome!";
            var characterToScanFor = "e";
            var expectedResult = 2;
           

            int result = _stringUtils.FindNumberOfOccurences(sentenceToScan, characterToScanFor);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldBeAbleToCountNumberOfLettersInAComplexSentance()
        {
            var sentenceToScan = "Once is unique, twice is a coincidence, three times is a pattern.";
            var characterToScanFor = "n";
            var expectedResult = 5;
           

            int result = _stringUtils.FindNumberOfOccurences(sentenceToScan, characterToScanFor);

            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]        
        public void ShouldGetAnArgumentExceptionWhenCharacterToScanForIsLargerThanOneCharacter()
        {
            var sentenceToScan = "This test should throw an exception";
            var characterToScanFor = "xx";


            Assert.That(() => _stringUtils.FindNumberOfOccurences(sentenceToScan, characterToScanFor), Throws.TypeOf<ArgumentException>());
        }
     }
 }
