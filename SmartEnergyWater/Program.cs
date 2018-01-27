using System;
using System.Collections.Generic;

namespace SmartEnergyWater
{
    class Program
    {

        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"wordlist.txt");

            var words = new List<string>(lines);

            var wordsProcessor = new WordsProcessor();


            var combinedWords = wordsProcessor.findCombinedWords(words);

            var longestCombinedWords = wordsProcessor.findLongestWords(combinedWords);

            Console.WriteLine("Longest combined words:");
            longestCombinedWords.ForEach(x =>
            {
                Console.WriteLine(x);

            });

            var secondLongestWords = wordsProcessor.findSecondLongestWords(words);


            Console.WriteLine();

            Console.WriteLine("Second longest words:");

            secondLongestWords.ForEach(x =>
            {
                Console.WriteLine(x);
            });


            Console.WriteLine();

            Console.WriteLine("Total number of combined words:");

  
            Console.WriteLine(combinedWords.Count);


            Console.ReadLine();
        }
    }
}
