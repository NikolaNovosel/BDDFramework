
namespace EpamPageTests.Support
{
    /// <summary>
    /// Class for validating file download functionality on the About page.
    /// </summary>
    internal static class AboutPageValidation
    {
        // Timestamp marking the start of the file download wait period
        private static readonly DateTime _startTime = DateTime.Now;

        // Checks if the specified time (5 seconds) has elapsed since the start time
        private static bool HasTimeElapsed => DateTime.Now < _startTime.AddSeconds(5);

        // Path to the downloaded file
        private static string GetFilePath(string fileName) =>
        Path.Combine(Location.Download, fileName);

        // Checks if the file exists at the specified path
        internal static bool FileExist(string fileName) => File.Exists(GetFilePath(fileName));

        // Waits for the file to download within the specified time frame
        internal static bool WaitForFileDownload(string fileName)
        {
            while (HasTimeElapsed)
            {
                if (FileExist(fileName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
