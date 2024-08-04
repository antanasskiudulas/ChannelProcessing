namespace ChannelProcessing.Writers
{
    /// <summary>
    /// Methods for formatting output of channel data
    /// </summary>
    public interface IChannelOutputFormatter
    {
        /// <summary>
        /// Format
        /// </summary>
        /// <param name="channelName">Channel name</param>
        /// <param name="channel">Channel data</param>
        public string FormatChannel(string channelName, List<double> channel);
    }
}
