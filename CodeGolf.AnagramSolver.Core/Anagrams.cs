using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGolf.AnagramSolver.Core
{
    public class Anagrams
    {
        private readonly Dictionary _dictionary;
        private IEnumerable<IGrouping<string, string>> _anagrams;

        public Anagrams(Dictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public void Generate()
        {
            if (_dictionary == null || _dictionary.Count == 0)
                throw new Exception("Dictionary was not provided.");

            // .ToLookup(key, elements) groups all words by provided key. 
            
            // In this case, groups are keyed by alphabetizing the letters of each word. 
            // The result is a list of keyed anagram groups.

            // For example:
            //      key = abt
            //          elements = bat, tab
            //      key = act
            //          elements = act, cat

            _anagrams = _dictionary
                .ToLookup(SortLetters) //.ToLookup(x => SortLetters(x), x => x) 
                .Where(GroupHasAnagrams);
        }

        private static String SortLetters(String word)
        {
            char[] letters = word.ToCharArray();
            Array.Sort(letters);
            return new String(letters);
        }

        private static bool GroupHasAnagrams(IEnumerable<String> group)
        {
            return group.Count() > 1;
        }

        public IEnumerable<String> GetAnagramsFor(String word)
        {
            string key = SortLetters(word);

            // Contains single group if key is found
            IGrouping<string, string> results = _anagrams
                .Where(AnagramsExistsFor(key))
                .FirstOrDefault();

            if (results != null)
                return results.Where(x => x != word);

            // I really wanted to return an empty collection rather than null.
            // This is ugly but it accomplishes what I wanted from the Api.
            return new List<String>();
        }

        private static Func<IGrouping<string, string>, bool> AnagramsExistsFor(string key)
        {
            return x => x.Key == key;
        }
    }
}