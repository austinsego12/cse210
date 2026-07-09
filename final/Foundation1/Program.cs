using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Arduino Motion Sensor LED Build",
            "Austin Sego",
            482
        );

        video1.AddComment(new Comment(
            "Mason",
            "This helped me understand how the PIR sensor works."
        ));

        video1.AddComment(new Comment(
            "Lily",
            "The wiring explanation was very clear."
        ));

        video1.AddComment(new Comment(
            "Jordan",
            "I like how the LED only turns on when motion is detected."
        ));

        // Video 2
        Video video2 = new Video(
            "Beginner Guide to Computer Hardware",
            "Tech Learning Lab",
            735
        );

        video2.AddComment(new Comment(
            "Sarah",
            "Great explanation of the motherboard parts."
        ));

        video2.AddComment(new Comment(
            "Ethan",
            "This made computer components easier to remember."
        ));

        video2.AddComment(new Comment(
            "Noah",
            "The examples were simple and helpful."
        ));

        video2.AddComment(new Comment(
            "Ava",
            "Please make another video about power supplies."
        ));

        // Video 3
        Video video3 = new Video(
            "How to Organize a Study Planner",
            "Study Buddy Team",
            390
        );

        video3.AddComment(new Comment(
            "Emma",
            "The task list idea is really useful."
        ));

        video3.AddComment(new Comment(
            "Caleb",
            "I like the local storage feature."
        ));

        video3.AddComment(new Comment(
            "Grace",
            "This would help me keep track of homework deadlines."
        ));

        // Video 4
        Video video4 = new Video(
            "Basic C# Classes Explained",
            "Code Practice Channel",
            620
        );

        video4.AddComment(new Comment(
            "Olivia",
            "The class examples were easy to follow."
        ));

        video4.AddComment(new Comment(
            "Daniel",
            "This helped me understand methods better."
        ));

        video4.AddComment(new Comment(
            "Sophia",
            "I finally understand why classes are useful."
        ));

        video4.AddComment(new Comment(
            "James",
            "The explanation of private member variables was helpful."
        ));

        // Add all videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine();
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"- {comment.GetCommenterName()}: {comment.GetText()}"
                );
            }

            Console.WriteLine();
        }
    }
}