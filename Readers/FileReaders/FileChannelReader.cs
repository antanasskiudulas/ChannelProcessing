namespace ChannelProcessing.Readers.FileReaders
{
    /// <inheritdoc cref="IChannelReader"/>
    public class FileChannelReader : IChannelReader
    {
        private readonly IFileReaderAsync _reader;

        public FileChannelReader(IFileReaderAsync fileReader)
        {
            _reader = fileReader;
        }

        /// <inheritdoc/>
        public async Task<List<double>> ReadChannel(string source, CancellationToken cancellation)
        {
            string content = await _reader.ReadFile(source);

            return ExtractData(content);

        }

        private List<double> ExtractData(string content)
        {
            string[] dataEntry = content.Split(SeperatorConsts.COMMA, StringSplitOptions.TrimEntries);
            List<double> result = new List<double>();

            foreach (string entry in dataEntry)
            {
                if (double.TryParse(entry, out double sensorEntry))
                {
                    result.Add(sensorEntry);
                }
            }

            return result;
        }
    }
}
