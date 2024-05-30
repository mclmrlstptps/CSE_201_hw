using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {CommentText}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        int minutes = Length / 60;
        int seconds = Length % 60;
        return $"Title: {Title}, Author: {Author}, Length: {minutes}m {seconds}s, Comments: {GetNumberOfComments()}";
    }

    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Videos
        var video1 = new Video("Learning Python", "John Doe", 300);
        var video2 = new Video("Advanced Python Techniques", "Jane Smith", 450);
        var video3 = new Video("Python Data Science", "Emily Johnson", 600);

        // Comments
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Could you do one on OOP next?"));

        video2.AddComment(new Comment("Dave", "Awesome content!"));
        video2.AddComment(new Comment("Eve", "Loved the advanced tips."));
        video2.AddComment(new Comment("Frank", "Can't wait for the next video."));

        video3.AddComment(new Comment("Grace", "This was really informative."));
        video3.AddComment(new Comment("Heidi", "Learned a lot, thanks!"));
        video3.AddComment(new Comment("Ivan", "Please make more data science videos."));

        // Video list
        var videos = new List<Video> { video1, video2, video3 };

        // Display
        foreach (var video in videos)
        {
            Console.WriteLine(video);
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}