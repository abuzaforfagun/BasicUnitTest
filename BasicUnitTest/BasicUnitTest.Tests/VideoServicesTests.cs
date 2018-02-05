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
        Mock<IVideoRepository> repository;
        VideoService service;
        [SetUp]
        public void Setup()
        {
            repository = new Mock<IVideoRepository>();
            service = new VideoService(repository.Object);
        }

        [Test]
        public void GetUnProcessedVideos_AllVideosAreProcessed_GetNoId()
        {
            repository.Setup(r => r.GetUnpublishedVideos())
                        .Returns(new List<Video>());
            var result = service.GetUnProcessedVideos();
            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void GetUnProcessedVideos_FewUnprocessedVideos_GetUnProcessedVideosId()
        {
            repository.Setup(r => r.GetUnpublishedVideos())
                        .Returns(new List<Video>()
                        {
                            new Video { Id = 1, Title = "v 1", IsProcessed = true },
                            new Video { Id = 2, Title = "v 2", IsProcessed = false },
                            new Video { Id = 3, Title = "v 3", IsProcessed = false }
                        });
            var result = service.GetUnProcessedVideos();
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
