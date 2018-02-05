using BasicUnitTest.Core;
using BasicUnitTest.Services;
using System;

namespace BasicUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video { Title = "Video 1" };
            Video video2 = new Video { Title = "Video 2" };

            VideoService service = new VideoService();
            /*
            video1 =service.AddVideo(video1);
            video2= service.AddVideo(video2);
            */
            var videos = service.GetAllVideo();
            foreach(var v in videos)
            {
                Console.WriteLine($"{v.Id} - {v.Title} - {v.IsProcessed}");
            }

            var unProcessed = service.GetUnProcessedVideos();
            
            Console.Read();
        }
    }
}
