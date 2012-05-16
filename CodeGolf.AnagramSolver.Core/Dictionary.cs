using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeGolf.AnagramSolver.Core
{
    public class Dictionary : List<String>
    {
        private readonly String _filename;

        public Dictionary(String filename)
        {
            _filename = filename;
        }

        public void Load()
        {
            if (String.IsNullOrEmpty(_filename))
                throw new Exception("Dictionary file was not provided.");

            Clear();

            var dictionary = new List<String>();
            using (var sr = new StreamReader(_filename))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    dictionary.Add(line.ToLower());
                }
            }

            // Remove all duplicates (east & East => east & east) 
            // This approach is a heck of a lot faster than checking 
            // existence of a word before adding directly from stream.
            foreach (var word in dictionary.Distinct())
            {
                Add(word);
            }
        }
    }
}