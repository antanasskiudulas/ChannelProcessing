namespace ChannelProcessing.Writers
{
    /// <inheritdoc cref="IChannelWriter"/>
    public class ConsoleChannelWriter : IChannelWriter
    {
        private readonly IChannelOutputFormatter _formatter;
        private readonly IChannelWriter _decorated;

        public ConsoleChannelWriter(IChannelWriter writer, IChannelOutputFormatter channelOutputFormatter)
        {
            _decorated = writer;
            _formatter = channelOutputFormatter;
        }

        /// <inheritdoc/>
        public void Write(string channelName, List<double> channel, string? destination = default)
        {
            _decorated.Write(channelName, channel);

            Console.WriteLine(_formatter.FormatChannel(channelName, channel));
        }
    }
}
