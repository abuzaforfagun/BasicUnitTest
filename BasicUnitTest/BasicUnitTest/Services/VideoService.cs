using BasicUnitTest.Core;
using BasicUnitTest.Presistance;
using BasicUnitTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUnitTest.Services
{
    public class VideoService
    {
        private readonly IVideoRepository repository;

        public VideoService(IVideoRepository repository)
        {
            this.repository = repository;
        }
        public Video AddVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException();
            return repository.AddVideo(video);
        }

        public string GetUnProcessedVideos()
        {
            var videos = new List<int>();
            var videoList = repository.GetAllVideos();
            foreach(var v in videoList)
            {
                if (v.IsProcessed == false)
                    videos.Add(v.Id);
            }

            return String.Join(",", videos);
        }

        public List<Video> GetAllVideo()
        {
            return repository.GetAllVideos();
        }
    }
}
