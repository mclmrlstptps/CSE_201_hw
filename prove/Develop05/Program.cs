using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent()
    {
        // Logic to record event
        Console.WriteLine($"Event recorded for goal '{_shortName}'.");
    }

    public virtual bool IsComplete()
    {
        // Logic to determine if the goal is complete
        // For demonstration, let's assume a goal is complete if it has reached its points
        return _points <= 0;
    }

    public virtual string GetDetailsString()
    {
        return $"Name: {_shortName}, Description: {_description}, Points: {_points}";
    }

    public virtual string GetStringRepresentation()
    {
        return $"Goal: {_shortName}, Points: {_points}";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public override bool IsComplete()
    {
        // Logic specific to SimpleGoal completion
        return _points <= 0;
    }

    public override string GetStringRepresentation()
    {
        return $"Simple Goal: {_shortName}, Points: {_points}";
    }
}

public class EternalGoal : Goal
{
    private const int DefaultPoints = 0;
    public EternalGoal(string shortName, string description) : base(shortName, description, DefaultPoints) { }
}

public class ChecklistGoal : Goal
{
     private int _target;
    private int _currentProgress;

    public ChecklistGoal(string shortName, string description, int points, int target, int currentProgress) 
        : base(shortName, description, points)
    {
        _target = target;
        _currentProgress = currentProgress;
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist Goal: {_shortName}, Points: {_points}";
    }

    public override string GetDetailsString()
    {
        return $"Name: {_shortName}, Description: {_description}, Points: {_points}, Target: {_target}";
    }
}
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();

    public void Start()
    {
        Console.WriteLine("Starting Goal Manager...");
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the name of the goal:");
                string simpleShortName = Console.ReadLine();

                Console.WriteLine("Enter a short description of the goal:");
                string simpleDescription = Console.ReadLine();

                Console.WriteLine("Enter the points assigned to this goal:");
                int simplePoints = int.Parse(Console.ReadLine());

                SimpleGoal simpleGoal = new SimpleGoal(simpleShortName, simpleDescription, simplePoints);
                _goals.Add(simpleGoal);
                break;

            case 2:
                Console.WriteLine("Enter the name of the eternal goal:");
                string eternalShortName = Console.ReadLine();

                Console.WriteLine("Enter a short description of the eternal goal:");
                string eternalDescription = Console.ReadLine();

                EternalGoal eternalGoal = new EternalGoal(eternalShortName, eternalDescription);
                _goals.Add(eternalGoal);
                break;

            case 3:
                Console.WriteLine("Enter the name of the checklist goal:");
                string checklistShortName = Console.ReadLine();

                Console.WriteLine("Enter a short description of the checklist goal:");
                string checklistDescription = Console.ReadLine();

                Console.WriteLine("Enter the points assigned to this checklist goal:");
                int checklistPoints = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the target for this checklist goal:");
                int target = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the current progress for this checklist goal:");
                int currentProgress = int.Parse(Console.ReadLine());

                ChecklistGoal checklistGoal = new ChecklistGoal(checklistShortName, checklistDescription, checklistPoints, target, currentProgress);
                _goals.Add(checklistGoal);
                break;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        int choice;

        do
        {
            goalManager.Start();
            goalManager.CreateGoal();

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create Simple Goal");
            Console.WriteLine("2. Create Eternal Goal");
            Console.WriteLine("3. Create Checklist Goal");
            Console.WriteLine("4. Exit");

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 4))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

        } while (choice != 4);
    }
}
