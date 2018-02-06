namespace BasicUnitTest.Services
{
    public interface IFileDownloaader
    {
        void DownloadFile(string url, string path);
    }
}