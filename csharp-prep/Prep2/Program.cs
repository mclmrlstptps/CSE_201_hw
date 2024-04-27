using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        char letter;
        if (gradePercentage >= 90)
            letter = 'A';
        else if (gradePercentage >= 80)
            letter = 'B';
        else if (gradePercentage >= 70)
            letter = 'C';
        else if (gradePercentage >= 60)
            letter = 'D';
        else
            letter = 'F';

        Console.WriteLine("Your letter grade is: " + letter);

        if (gradePercentage >= 70)
            Console.WriteLine("Congratulations! You Passed the course.");
        else
            Console.WriteLine("Keep working hard for next time!");

    }

}