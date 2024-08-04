using ChannelProcessing.Models;
using ChannelProcessing.Processors;
using ChannelProcessing.Readers;
using ChannelProcessing.Writers;

namespace ChannelProcessing.Engine
{
    /// <inheritdoc cref="IChannelEngine"/>
    public class ChannelEngine : IChannelEngine
    {
        private readonly IChannelReader _channelReader;
        private readonly IParameterReader _parameterReader;
        private readonly IChannelProcessor _channelProcessor;
        private readonly IChannelWriter _channelWriter;

        public ChannelEngine(
            IChannelReader channelReader,
            IParameterReader parameterReader,
            IChannelProcessor channelProcessor,
            IChannelWriter channelWriter)
        {
            _channelReader = channelReader;
            _parameterReader = parameterReader;
            _channelProcessor = channelProcessor;
            _channelWriter = channelWriter;
        }

        /// <inheritdoc/>
        public void Start(string channelsPath, string parametersPath)
        {
            List<double> xChannelData = _channelReader.ReadChannel(channelsPath);

            ParameterModel model = _parameterReader.ReadParameters(parametersPath);

            List<double> aChannelData = _channelProcessor.ProcessChannelA(xChannelData);
            List<double> yChannelData = _channelProcessor.ProcessChannelY(xChannelData, model.Slope, model.Intercept);
            List<double> bChannelData = _channelProcessor.ProcessChannelB(aChannelData, yChannelData);
            double bChannelMean = _channelProcessor.CalculateChannelMean(bChannelData);
            List<double> cChannelData = _channelProcessor.ProcessChannelC(xChannelData, bChannelMean);

            _channelWriter.Write("A", aChannelData);
            _channelWriter.Write("B", bChannelData);
            _channelWriter.Write("C", cChannelData);
            _channelWriter.Write("Y", yChannelData);
            _channelWriter.Write("X", xChannelData);
            Console.WriteLine($"Channel B Mean: {bChannelMean}");
        }
    }
}
