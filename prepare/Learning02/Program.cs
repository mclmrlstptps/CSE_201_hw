using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Software Engineer", "Microsoft", "Redmond, WA", "2019", "2022", "Worked on various projects as a software engineer.");
        Job job2 = new Job("Manager", "Apple", "Cupertino, CA", "2022", "2023", "Managed a team of developers.");

        Console.WriteLine(job1.CompanyName);
        Console.WriteLine(job2.CompanyName);

        job1.Display();
        job2.Display();

        Resume myResume = new Resume("Allison Rose");

        myResume.AddJob(job1);
        myResume.AddJob(job2);
        
        myResume.Display();
    }
}