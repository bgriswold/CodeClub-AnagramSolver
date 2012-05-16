using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CodeGolf.AnagramSolver.Core;

namespace CodeGolf.AnagramSolver
{
    public partial class Form1 : Form
    {
        private Dictionary _dictionary;
        private Anagrams _anagrams;

        public Form1()
        {
            InitializeComponent();

            Cursor = Cursors.WaitCursor;

            LoadDictionary();

            Cursor = Cursors.Arrow;
        }

        private void LoadDictionary()
        {
            var rd = new RelativeDirectory();
            rd.UpTo("CodeClub-AnagramSolver");
            rd.Down("CodeGolf.AnagramSolver");

            string filename = Path.Combine(rd.Path, @"words");
            _dictionary = new Dictionary(filename);
            _dictionary.Load();

            _anagrams = new Anagrams(_dictionary);
            _anagrams.Generate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnagramListBox.Items.Clear();
            String word = WordTextbox.Text;
            
            IEnumerable<string> anagrams = _anagrams.GetAnagramsFor(word);

            foreach (String anagram in anagrams) 
            {
                AnagramListBox.Items.Add(anagram);
            }
        }
    }
}