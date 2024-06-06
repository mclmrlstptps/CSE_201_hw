using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    public string Text { get; }
    public bool Hidden { get; set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
}

class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split().Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public List<Word> GetWords()
    {
        return _words;
    }

    public void Display()
    {
        Console.WriteLine($"{_reference.Book} {_reference.Chapter}:{_reference.StartVerse}");
        Console.WriteLine(string.Join(" ", _words.Select(word => word.Hidden ? "****" : word.Text)));
    }

    public bool HideRandomWord()
    {
        var hiddenWord = _words.FirstOrDefault(word => !word.Hidden);
        if (hiddenWord != null)
        {
            hiddenWord.Hidden = true;
            return true;
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life");

        // Display the scripture
        scripture.Display();

        bool continueLoop = true;
        while (continueLoop)
        {
            // Prompt the user to either continue or quit
            Console.WriteLine("Press Enter to continue, Type QUIT to exit");
            string input = Console.ReadLine();
            if (input.ToUpper() == "QUIT")
            {
                break; // Exit the loop and the program
            }

            // Hide a random word
            bool wordHidden = scripture.HideRandomWord();
            if (wordHidden)
            {
                // Display the scripture again with one word hidden
                scripture.Display();
            }
            else
            {
                Console.WriteLine("All words are already hidden.");
                continueLoop = false; // Exit the loop if all words are hidden
            }
        }
    }
}
