using System;
using System.Linq.Expressions;

public class Assignment
{
    protected string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}

public class MathAssignment : Assignment
{
    private string _homeworkList;

    public MathAssignment(string studentName, string topic, string homeworkList) : base(studentName, topic)
    {
        _homeworkList = homeworkList;
    }

    public string GetHomeworkList()
    {
        return _homeworkList;
    }
}

public class WritingAssignment : Assignment
{
    private string _writingInformation;

    public WritingAssignment(string studentName, string topic, string writingInformation) : base(studentName, topic)
    {
        _writingInformation = writingInformation;
    }

    public string GetWritingInformation()
    {
        return $"{GetStudentName()} - {_writingInformation}";
    }

    // Public method to access the private _studentName variable
    public string GetStudentName()
    {
        return _studentName;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Test Assignment class
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        // Test MathAssignment class
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3 Problems 8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Test WritingAssignment class
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II by Mary Waters");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}