namespace ChannelProcessing.Writers
{
    /// <summary>
    /// Methods for writing channel information
    /// </summary>
    public interface IChannelWriter
    {
        /// <summary>
        /// Write channel data
        /// </summary>
        /// <param name="channelName">Channel name</param>
        /// <param name="channel">Channel data</param>
        /// <param name="destination">Where to output channel data</param>
        public void Write(string channelName, List<double> channel, string? destination = default);
    }
}
