using System;
using System.Runtime.CompilerServices;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public void StartActivity(string activityName, string description)
    {
        Console.WriteLine($"{activityName} Activity");
        Console.WriteLine(description);
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowPauseAnimation(3);
    }

    public void EndActivity(string activityName)
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {activityName} activity for {duration} seconds.");
        ShowPauseAnimation(3);
    }

    protected void ShowPauseAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void RunActivity();
}


class BreathingActivity : MindfulnessActivity
{
    public override void RunActivity()
    {
        StartActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        int remainingTime = duration;

        while(remainingTime > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowPauseAnimation(3);
            remainingTime -= 3;
            if (remainingTime <= 0)
                break;
            Console.WriteLine("Breathe out...");
            ShowPauseAnimation(3);
            remainingTime -= 3;
        }

        EndActivity("Breathing");
    }
}


class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts= {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private static Random random = new Random();

    public override void RunActivity()
    {
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        ShowPauseAnimation(5);

        int remainingTime = duration - 5;
        while (remainingTime > 0)
        {
            string question = Questions[random.Next(Questions.Length)];
            Console.WriteLine(question);
            ShowPauseAnimation(5);
            remainingTime -= 5;
        }

        EndActivity("Reflection");
    
    }
}


class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private static Random random = new Random();
    public override void RunActivity()
    {
        StartActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        ShowPauseAnimation(5);

        Console.WriteLine("Start listing items:");

        DateTime endTime = DateTime.Now.AddSeconds(duration - 5);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("Item: ");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity("Listing");
    }
}


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activty: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.RunActivity();
        }
    }
}