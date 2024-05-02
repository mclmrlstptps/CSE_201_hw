class JournalApp
{
    private Journal journal;

    public JournalApp()
    {
        journal = new Journal();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            int choice = GetChoice(1, 5);

            switch (choice)
            {
                case 1:
                    WriteNewEntry();
                    break;

                case 2:
                    DisplayJournal();
                    break;

                case 3:
                    SaveJournal();
                    break;

                case 4:
                    LoadJournal();
                    break;

                case 5:
                    exit = true;
                    break;
            }
        }
    }

    private int GetChoice(int min, int max)
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            else
            {
                Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
        }
    }

    private void WriteNewEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        journal.AddEntry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd"));
        Console.WriteLine("Entry added successfully!");
    }

    private string GetRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random rand = new Random();
        return prompts[rand.Next(prompts.Length)];
    }

    private void DisplayJournal()
    {
        journal.Display();
    }

    private void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine($"Journal saved to {filename}.");
    }

    private void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine($"Journal loaded from {filename}.");
    }
}