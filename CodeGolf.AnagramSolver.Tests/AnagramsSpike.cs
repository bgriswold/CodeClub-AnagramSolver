using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeGolf.AnagramSolver.Tests
{
    [TestClass]
    public class AnagramsSpike
    {
        [TestMethod]
        public void AnagramsCanBeMadeFromEast()
        {
            const String word = "east";
            List<String> anagrams = GetAnagramsFor(word).ToList();
            Assert.AreEqual(anagrams.Count(), 7);
            Assert.IsTrue(anagrams.Contains(word));

            WriteResults(word, anagrams);
        }
        
        [TestMethod]
        public void AnagramsCanNotBeMadeFromBullshit()
        {
            const String word = "bullshit";
            List<String> anagrams = GetAnagramsFor(word).ToList();
            
            Assert.AreEqual(anagrams.Count(), 0);
            Assert.IsFalse(anagrams.Contains(word));

            WriteResults(word, anagrams);
        }
        
        private IEnumerable<String> GetAnagramsFor(String word)
        {
            var results = BuildDictionaryFromFile()
                .ToLookup(SortLetters)
                .FirstOrDefault(x => HasAnagram(x) && HasMatch(x, word));

            // I really wanted to return an empty collection rather than null.
            // This is ugly but it accomplishes what I wanted from the Api.
            return (IEnumerable<string>) results ?? new List<String>();
        }

        public IList<String> BuildDictionaryFromFile()
        {
            var rd = new RelativeDirectory();
            rd.UpTo("CodeClub-AnagramSolver");
            rd.Down("CodeGolf.AnagramSolver");
            
            string filename = Path.Combine(rd.Path, @"words");
            
            var words = new List<String>();

            using (var sr = new StreamReader(filename))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    words.Add(line.ToLower());
                }
            }
            
            return words.Distinct().ToList();
        }

        private static String SortLetters(String word)
        {
            char[] letters = word.ToCharArray();
            Array.Sort(letters);
            return new String(letters);
        }

        private static bool HasMatch(IEnumerable<String> group, String word)
        {
            return group.Contains(word);
        }

        private static bool HasAnagram(IEnumerable<String> group)
        {
            return group.Count() > 1;
        }

        private static void WriteResults(String word, List<String> anagrams)
        {
            if (anagrams != null && anagrams.Any())
            {
                Console.WriteLine("{0} anagrams found for '{1}'", anagrams.Count() - 1, word);
                Console.WriteLine();
                anagrams.ForEach(Console.WriteLine);
            }
            else
            {
                Console.Write("No anagrams found for {0}", word);
            }
        }
    }
}