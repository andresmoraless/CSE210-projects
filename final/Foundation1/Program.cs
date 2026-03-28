using System;
using System.Collections.Generic;

/* 
I exceeded requirements by adding a method to get the longest comment for each video. 
I thought it would be fun to see which comment was the longest for each video, 
and it also gave me a chance to practice working with lists and finding specific items 
based on criteria.
*/

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Make Perfect Pancakes", "KitchenWithMia", 420);
        video1.AddComment(new Comment("Jake23", "This actually worked so well."));
        video1.AddComment(new Comment("Lena", "Tried this this morning, 10/10."));
        video1.AddComment(new Comment("FoodMax", "Best pancake recipe I've found."));
        videos.Add(video1);

        Video video2 = new Video("Beginner Full Body Workout", "FitCore", 615);
        video2.AddComment(new Comment("Andy22", "Simple and easy to follow."));
        video2.AddComment(new Comment("MayaLift", "Perfect for starting out."));
        video2.AddComment(new Comment("ChrisT", "That burn was crazy."));
        videos.Add(video2);

        Video video3 = new Video("Top 5 Productivity Apps for Students", "StudySmarter", 510);
        video3.AddComment(new Comment("Sofia", "I downloaded two of these already."));
        video3.AddComment(new Comment("DanielR", "Super useful for college."));
        video3.AddComment(new Comment("Emma", "Duolingo should've been on this list."));
        videos.Add(video3);

        Video video4 = new Video("Why Cats Act So Weird", "PetScience", 355);
        video4.AddComment(new Comment("Nico", "This explains my cat."));
        video4.AddComment(new Comment("Tara", "I laughed the whole time."));
        video4.AddComment(new Comment("Benji48", "Now I understand my pet."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("________________________________________");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Comment longestComment = video.GetLongestComment();
            Console.WriteLine($"Longest Comment by: {longestComment.GetCommenterName()}");
            Console.WriteLine($"Longest Comment Text: {longestComment.GetText()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}