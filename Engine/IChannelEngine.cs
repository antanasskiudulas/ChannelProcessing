namespace ChannelProcessing.Engine
{
    /// <summary>
    /// Provides methods for processing channel data end-to-end
    /// </summary>
    public interface IChannelEngine
    {
        public Task Start(string channelsPath, string parametersPath);
    }
}
