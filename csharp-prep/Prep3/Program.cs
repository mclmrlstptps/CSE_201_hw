using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number");
        int magicNumber = Convert.ToInt32(Console.ReadLine());
        

        //ask user for guess 
        Console.Write("What is your guess? ");
        int guess = Convert.ToInt32(Console.ReadLine());
        
        if (guess < magicNumber)
            Console.WriteLine("Higher");
        else if (guess > magicNumber)
            Console.WriteLine("Lower");
        else 
            Console.WriteLine("You guessed it!");

        // Add loop to keep guessing
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());

                
            if (guess < magicNumber)
                Console.WriteLine("Higher");
            else if (guess > magicNumber)
                Console.WriteLine("Lower");
            else 
                Console.WriteLine("You guessed it!");
        }

    }
}