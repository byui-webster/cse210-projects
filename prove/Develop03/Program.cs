using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureProgram
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Initialize library of scriptures
            ScriptureLibrary library = new ScriptureLibrary();
            library.AddScripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
            library.AddScripture("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
            library.AddScripture("Philippians 4:13", "I can do all things through Christ who gives me strength.");

            // Choose a random scripture from the library
            Scripture scripture = library.GetRandomScripture();

            Console.WriteLine(scripture.Reference + ": " + scripture.Text);

            // Hide words in scripture until all words are hidden
            while (scripture.Text.Contains(' '))
            {
                Console.WriteLine("Press enter to hide more words or type quit to exit:");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }

                scripture.HideWords();
                Console.Clear();
                Console.WriteLine(scripture.Reference + ": " + scripture.Text);
            }
        }
    }

    class Scripture
    {
        private string reference;
        private string text;
        private string[] words;
        private HashSet<int> hiddenWords = new HashSet<int>();

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            words = text.Split(' ');
        }

        public string Reference
        {
            get { return reference; }
        }

        public string Text
        {
            get { return text; }
        }

        public void HideWords()
        {
            Random rand = new Random();
            int numWordsToHide = Math.Min(rand.Next(1, words.Length), words.Length - hiddenWords.Count);

            while (numWordsToHide > 0)
            {
                int wordIndex = rand.Next(0, words.Length);
                if (!hiddenWords.Contains(wordIndex))
                {
                    hiddenWords.Add(wordIndex);
                    numWordsToHide--;
                }
            }

            text = string.Join(" ", words.Select((word, index) => hiddenWords.Contains(index) ? "---" : word));
        }
    }

    class ScriptureLibrary
    {
        private List<Scripture> scriptures = new List<Scripture>();
        private Random rand = new Random();

        public void AddScripture(string reference, string text)
        {
            scriptures.Add(new Scripture(reference, text));
        }

        public Scripture GetRandomScripture()
        {
            return scriptures[rand.Next(0, scriptures.Count)];
        }
    }
}
