namespace ChannelProcessing.Readers.FileReaders
{
    /// <inheritdoc cref="IChannelReader"/>
    public class FileChannelReader : IChannelReader
    {
        private readonly IFileReader _reader;

        public FileChannelReader(IFileReader fileReader)
        {
            _reader = fileReader;
        }

        /// <inheritdoc/>
        public List<double> ReadChannel(string source)
        {
            string content = _reader.ReadFile(source);

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
