using System.Text;

namespace ChannelProcessing.Writers
{
    /// <inheritdoc cref="IChannelOutputFormatter"/>
    public class ChannelOutputFormatter : IChannelOutputFormatter
    {
        /// <inheritdoc/>
        public string FormatChannel(string channelName, List<double> channel)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{channelName}");

            foreach (double channelValue in channel)
            {
                stringBuilder.Append($", {channelValue}");
            }

            return stringBuilder.ToString();
        }
    }
}
