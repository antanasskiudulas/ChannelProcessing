
namespace ChannelProcessing.Writers
{
    /// <inheritdoc cref="IChannelWriter"/>
    public class FileChannelWriter : IChannelWriter
    {
        private const string FILE_EXTENSION = ".txt";

        private readonly IChannelOutputFormatter _formatter;

        public FileChannelWriter(IChannelOutputFormatter formatter)
        {
            _formatter = formatter;
        }

        /// <inheritdoc/>
        public void Write(string channelName, List<double> channel, string? destination = default)
        {
            string? destinationPath = destination ?? Environment.ProcessPath;

            if (destinationPath == null)
            {
                throw new Exception("Error resolving destination path when writing channel information to file");
            }

            File.WriteAllText(Path.Combine(destinationPath, channelName, FILE_EXTENSION), _formatter.FormatChannel(channelName, channel));
        }
    }
}
