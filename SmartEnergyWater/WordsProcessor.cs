using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartEnergyWater
{

    public class WordsProcessor
    {




        public List<String> findSecondLongestWords(List<string> words)
        {

            if (words == null || words.Count() < 1)
                return words;

            var sortedList = words.OrderByDescending(x => x.Count());

            int maxSize = sortedList.First().Length;


            int secondLongestSize = 0;

            foreach (var word in sortedList)
            {
                if (word.Count() != maxSize)
                {
                    secondLongestSize = word.Count();
                    break;
                }
            }

            var secondLongest = words.Where(x => x.Count() == secondLongestSize);

            return secondLongest.ToList();
        }
        public List<string> findLongestWords(List<string> words)
        {
            if (words == null || words.Count() < 1)
                return words;


            int count =  words.OrderByDescending(s => s.Length).First().Length;


            return words.Where(x => x.Count() == count).ToList();
        }
        public List<string> findCombinedWords(List<string> words)
        {
            var results = new List<string>();

            words.Sort();

            foreach (var word in words)
            {

                if (canDerive(word, words))
                {
                    results.Add(word);
                }
            }

            return results;

        }


        public bool canDerive(string word, List<string> words)
        {
            if (word.Count() == 0)
                return false;

            for (int i = 1; i < word.Length; i++)
            {
                var firstPart = word.Substring(0, i);
                var secondPart = word.Substring(i);

                if (words.BinarySearch(firstPart) >= 0 && words.BinarySearch(secondPart) >= 0)
                {
                    return true;
                }
                else if (words.BinarySearch(firstPart) >= 0)
                {
                    return canDerive(secondPart, words);
                }

            }

            return false;

        }
    }
}
