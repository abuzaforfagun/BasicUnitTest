using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BasicUnitTest.Services
{
    public class FileDownloaader : IFileDownloaader
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
