using BasicUnitTest.Core;
using BasicUnitTest.Repository;
using BasicUnitTest.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicUnitTest.Tests
{
    [TestFixture]
    public class VideoServicesTests
    {
        [Test]
        public void GetUnProcessedVideos_WhenCalled_GetUnProcessedVideosId()
        {
            var repository = new Mock<IVideoRepository>();
            repository.Setup(r => r.GetAllVideos())
                        .Returns(new List<Video>()
                        {
                            new Video { Id = 1, Title = "v 1", IsProcessed = true },
                            new Video { Id = 2, Title = "v 2", IsProcessed = false },
                            new Video { Id = 3, Title = "v 3", IsProcessed = false }
                        });

            var service = new VideoService(repository.Object);
            var result = service.GetUnProcessedVideos();
            Assert.That(result, Is.EqualTo("2,3"));

        }
    }
}
