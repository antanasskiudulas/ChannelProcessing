using ChannelProcessing.Models;
using static System.Formats.Asn1.AsnWriter;

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
        public List<double> Process(List<double> channelData, ParameterModel parameters)
        {
            List<double> result = new List<double>();

            foreach (double reading in channelData) 
            {
                result.Add(parameters.Slope * reading + parameters.Intercept);
            }

            return result;
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
