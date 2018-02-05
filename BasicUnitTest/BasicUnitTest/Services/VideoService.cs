using BasicUnitTest.Core;
using BasicUnitTest.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUnitTest.Services
{
    public class VideoService
    {
        VideoDbContext context;
        public VideoService()
        {
            context = new VideoDbContext();
        }
        public Video AddVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException();
            context.Videos.Add(video);
            context.SaveChanges();
            return video;
        }

        public string GetUnProcessedVideos()
        {
            var videos = new List<int>();
            videos = context.Videos.Where(v => v.IsProcessed == false).Select(v => v.Id).ToList();

            return String.Join(",", videos);
        }

        public List<Video> GetAllVideo()
        {
            return context.Videos.ToList();
        }
    }
}
