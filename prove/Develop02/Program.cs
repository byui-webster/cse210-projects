using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Journal
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Journal journal = new Journal();

            while (true)
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal");
                Console.WriteLine("4. Load journal");
                Console.WriteLine("5. Quit");

                Console.Write("Enter your choice: ");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 1)
                {
                    string chosenPrompt = journal.GetRandomPrompt();
                    Console.WriteLine("Prompt: " + chosenPrompt);
                    Console.WriteLine("Write your response:");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        Date = DateTime.Now,
                        Prompt = chosenPrompt,
                        Response = response
                    };

                    journal.AddEntry(newEntry);
                }
                else if (userChoice == 2)
                {
                    journal.DisplayEntries();
                }
                else if (userChoice == 3)
                {
                    Console.WriteLine("Enter a filename to save journal:");
                    string filename = Console.ReadLine();
                    journal.SaveJournal(filename);
                }
                else if (userChoice == 4)
                {
                    Console.WriteLine("Enter a filename to load journal:");
                    string filename = Console.ReadLine();
                    journal.LoadJournal(filename);
                }
                else if (userChoice == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }

    class Entry
    {
        public DateTime Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
    }

    class Journal
    {
        private List<string> prompts = new List<string>
        {
            "What did you learn today?",
            "What are you grateful for?",
            "What did you accomplish today?",
            "What challenges did you face today?",
            "What are your goals for tomorrow?"
        };
        private List<Entry> entries = new List<Entry>();

        public string GetRandomPrompt()
        {
            Random rand = new Random();
            int index = rand.Next(prompts.Count);
            return prompts[index];
        }

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            Console.WriteLine("Journal Entries:");
            foreach (Entry entry in entries)
            {
                Console.WriteLine("Date: " + entry.Date);
                Console.WriteLine("Prompt: " + entry.Prompt);
                Console.WriteLine("Response: " + entry.Response);
                Console.WriteLine("----------------");
            }
        }

        public void SaveJournal(string filename)
        {
            using (Stream stream = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, entries);
            }
        }

        public void LoadJournal(string filename)
        {
            if (File.Exists(filename))
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    entries = (List<Entry>)binaryFormatter.Deserialize(stream);
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}