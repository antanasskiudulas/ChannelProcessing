namespace ChannelProcessing.Readers.FileReaders
{
    /// <summary>
    /// Defines methods for reading a file
    /// </summary>
    public interface IFileReaderAsync
    {
        public Task<string> ReadFile(string filePath);
    }
}
