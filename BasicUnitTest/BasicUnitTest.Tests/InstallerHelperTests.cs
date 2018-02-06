using BasicUnitTest.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicUnitTest.Tests
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloaader> fileDownloader;
        private InstallerHelper installerHelper;

        [SetUp]

        public void Setup()
        {
            fileDownloader = new Mock<IFileDownloaader>();
            installerHelper = new InstallerHelper(fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_RightArguments_ReturnTrue()
        {
            var result =installerHelper.DownloadInstaller("Customer", "sample.txt");
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DownloadInstaller_WrongArguments_ReturnFalse()
        {
            fileDownloader.Setup(fd => 
                    fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                    .Throws(new Exception());
            var result = installerHelper.DownloadInstaller("hi", "sample.txt");
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
