using ChannelProcessing.Models;

namespace ChannelProcessing.Processors
{
    /// <summary>
    /// Defines methods for processing channel information
    /// </summary>
    public interface IChannelProcessor
    {
        /// <summary>
        /// Apply linear transformation to a channel
        /// </summary>
        /// <param name="channel">Channel data to be transformed</param>
        /// <param name="slope">Slope of the data</param>
        /// <param name="intercept">Intercept of the data</param>
        List<double> ProcessChannelY(List<double> channel, double slope, double intercept);

        /// <summary>
        /// Calculate channel's reciprocal
        /// </summary>
        /// <param name="channel">Multiple channel data</param>
        List<double> ProcessChannelA(List<double> channel);

        /// <summary>
        /// Combine multiple channel data
        /// </summary>
        /// <param name="channel">Channel data to be transformed</param>
        /// <param name="scalar">Scalar to be applied to data</param>
        List<double> ProcessChannelB(List<double> channelB, List<double> channelY);

        /// <summary>
        /// Apply scalar transformation to a channel
        /// </summary>
        /// <param name="channel">Channel data to be transformed</param>
        /// <param name="scalar">Scalar to be applied to data</param>
        List<double> ProcessChannelC(List<double> channel, double scalar);

        /// <summary>
        /// Calculate metrics
        /// </summary>
        /// <param name="channel">Channel for which metrics will be calculated</param>
        /// <param name="parameters">Parameters applied to metric calculation</param>
        /// <returns>Metric</returns>
        double CalculateMetric(List<double> channel, ParameterModel parameters);
    }
}
