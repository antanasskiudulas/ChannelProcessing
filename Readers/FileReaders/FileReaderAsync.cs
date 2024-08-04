namespace ChannelProcessing.Readers.FileReaders
{
    /// <inheritdoc cref="IFileReaderAsync"/>
    public class FileReaderAsync : IFileReaderAsync
    {
        public async Task<string> ReadFile(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        return await streamReader.ReadToEndAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
