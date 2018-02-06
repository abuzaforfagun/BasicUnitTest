using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BasicUnitTest.Services
{
    public class InstallerHelper
    {
        public InstallerHelper(IFileDownloaader fileDownloaader)
        {
            this.fileDownloaader = fileDownloaader;
            if (fileDownloaader == null)
                this.fileDownloaader = new FileDownloaader();
        }
        private string _setupDestinationFile;
        private readonly IFileDownloaader fileDownloaader;

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                fileDownloaader.DownloadFile(string.Format("http://example.com/{0}/{1}", customerName, installerName), _setupDestinationFile);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
