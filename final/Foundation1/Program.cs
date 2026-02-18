using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to Cook Chicken Alfredo", "ChefNova", 420);
        v1.AddComment(new Comment("Mia", "This turned out amazing."));
        v1.AddComment(new Comment("Jordan", "I added extra garlic and it was perfect."));
        v1.AddComment(new Comment("Sam", "Clear instructions. Thank you."));
        videos.Add(v1);

        Video v2 = new Video("C# Classes Explained Fast", "CodeSprint", 610);
        v2.AddComment(new Comment("Ava", "This finally made it click."));
        v2.AddComment(new Comment("Ethan", "The examples were super helpful."));
        videos.Add(v2);

        Video v3 = new Video("Best Home Workout Routine", "FitDaily", 540);
        v3.AddComment(new Comment("Noah", "Doing this daily now."));
        v3.AddComment(new Comment("Lily", "I felt the burn, in a good way."));
        v3.AddComment(new Comment("Chris", "Can you make a beginner version too?"));
        v3.AddComment(new Comment("Zoe", "Love the pacing."));
        videos.Add(v3);

        Console.WriteLine("YouTube Videos\n");

        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplayText());
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetDisplayText()}");
            }
            Console.WriteLine();
        }
    }
}
