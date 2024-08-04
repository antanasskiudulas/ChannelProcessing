using ChannelProcessing.Models;

namespace ChannelProcessing.Processors
{
    /// <see cref="IChannelProcessor"/>
    public class ChannelProcessor : IChannelProcessor
    {
        /// <inheritdoc/>
        public double CalculateMetric(List<double> channel, ParameterModel parameters)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<double> ProcessChannelY(List<double> channel, double slope, double intercept)
        {
            return channel
                .Select(x => slope * x + intercept)
                .ToList();
        }

        /// <inheritdoc/>
        public List<double> ProcessChannelA(List<double> channel)
        {
            return channel
                .Where(x => x > 0d)
                .Select(x => 1.0d / x)
                .ToList();
        }

        /// <inheritdoc/>
        public List<double> ProcessChannelB(List<double> channelB, List<double> channelY)
        {
            ThrowIfChannelLengthsDoNotMatch(channelB, channelY);

            return channelB
                .Zip(channelY, (xData, yData) => xData + yData)
                .ToList();
        }

        /// <inheritdoc/>
        public List<double> ProcessChannelC(List<double> channel, double scalar)
        {
            return channel
                .Select(x => scalar + x)
                .ToList();
        }

        /// <inheritdoc/>
        public double CalculateChannelMean(List<double> channel)
        {
            if (channel.Count == 0)
            {
                string message = $"Cannot calculate mean for {nameof(channel)} when its length is {channel.Count}";
                Console.WriteLine(message);
                throw new DivideByZeroException($"Cannot calculate mean for {nameof(channel)} when its length is {channel.Count}");
            }

            return channel.Sum(x => x) / channel.Count;
        }

        private static void ThrowIfChannelLengthsDoNotMatch(List<double> channelB, List<double> channelY)
        {
            if (channelB.Count != channelY.Count)
            {
                string message = $"Error processing {nameof(ProcessChannelB)} because length of {nameof(channelB)} does not equal to {nameof(channelY)}";
                Console.WriteLine(message);

                throw new ArgumentException(nameof(channelB), message);
            }
        }
    }
}
