namespace ChannelProcessing.Readers
{
    /// <summary>
    /// Defines methods for reading channel data
    /// </summary>
    public interface IChannelReader
    {
        /// <summary>
        /// Read channel information
        /// </summary>
        /// <param name="source">Channel source</param>
        /// <param name="cancellation">Async cancellation token</param>
        /// <returns>Sensor information</returns>
        public List<double> ReadChannel(string source);
    }
}
