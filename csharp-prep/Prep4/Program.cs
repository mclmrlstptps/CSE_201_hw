using System;

class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = new List<double>();

        while (true)
        {
            Console.Write("Enter number: ");
            double number = Convert.ToDouble(Console.ReadLine());
            if (number == 0)
                break;
            numbers.Add(number);
        }

        double total = 0;
        foreach(double number in numbers)
        {
            total += number;
        }

        double average = total / numbers.Count;
        
        double maximum = double.MinValue;
        foreach (double number in numbers)
        {
            if (number > maximum)
                maximum = number;
        }

        Console.WriteLine("The sum is: " + total);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + maximum);
    }
}