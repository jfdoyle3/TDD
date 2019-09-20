using System;
using System.Linq;
using NUnit.Framework;
  

 namespace ThirtyDaysOfTDD.UnitTests
 {
     [TestFixture]
     public class StringUtilsTests
     {
        [Test]
         public void ShouldBeAbleToCountNumberOfLettersInSimpleSentence()
         {
            var sentenceToScan = "TDD is awesome!";
            var characterToScanFor = "e";
            var expectedResult = 2;
            var stringUtils = new StringUtils();

            int result = stringUtils.FindNumberOfOccurences(sentenceToScan, characterToScanFor);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldBeAbleToCountNumberOfLettersInAComplexSentance()
        {
            var sentenceToScan = "Once is unique, twice is a coincidence, three times is a pattern.";
            var characterToScanFor = "n";
            var expectedResult = 5;
            var stringUtils = new StringUtils();

            int result = stringUtils.FindNumberOfOccurences(sentenceToScan, characterToScanFor);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        // [ExpectedException(typeof(ArgumentException))] <- Code was valid in NUnit 2 it's no loner valid.
        [TestCase("Error: Argument Exception", typeof(ArgumentException))]        // Same line for NUnit 3.
        public void ShouldGetAnArgumentExceptionWhenCharacterToScanForIsLargerThanOneCharacter()
        {
            var sentenceToScan = "This test should throw an exception";
            var characterToScanFor = "xx";
            var stringUtils = new StringUtils();

           stringUtils.FindNumberOfOccurences(sentenceToScan, characterToScanFor);
        }
    }

 }
