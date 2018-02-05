using BasicUnitTest.Core;
using BasicUnitTest.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUnitTest.Repository
{
    public class VideoRepository : IVideoRepository
    {
        VideoDbContext context;
        public VideoRepository()
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

        public List<Video> GetUnpublishedVideos()
        {
            return context.Videos.Where(v => v.IsProcessed == false).ToList();
        }

        public List<Video> GetAllVideos()
        {
            return context.Videos.ToList();
        }
    }
}
