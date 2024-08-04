namespace ChannelProcessing.Readers.FileReaders
{
    /// <summary>
    /// Defines methods for reading a file
    /// </summary>
    public interface IFileReader
    {
        public string ReadFile(string filePath);
    }
}
