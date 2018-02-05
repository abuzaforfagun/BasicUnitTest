using System.Collections.Generic;
using BasicUnitTest.Core;

namespace BasicUnitTest.Repository
{
    public interface IVideoRepository
    {
        Video AddVideo(Video video);
        List<Video> GetAllVideos();
        List<Video> GetUnpublishedVideos();
    }
}