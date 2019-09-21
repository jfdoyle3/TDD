using System;
using System.Collections.Generic;
using System.Text;

namespace ThirtyDaysOfTDD.UnitTests
{
    class StringUtils
    {
        public int FindNumberOfOccurences(string sentenceToScan, string characterToScanFor)
        {

        

            var stringToCheckAsCharacterArray = sentenceToScan.ToCharArray();
                var characterToCheckFor = Char.Parse(characterToScanFor);

                var numberOfOccurences = 0;

                for (var charIdx = 0; charIdx < stringToCheckAsCharacterArray.GetUpperBound(0); charIdx++)
                {
                    if (stringToCheckAsCharacterArray[charIdx] == characterToCheckFor)
                    {
                        numberOfOccurences++;
                    }
                }
                return numberOfOccurences;

        }
    }
}
