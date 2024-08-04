using ChannelProcessing.Models;

namespace ChannelProcessing.Readers
{
    /// <summary>
    /// Defines methods for accessing parameters for channel processing
    /// </summary>
    public interface IParameterReader
    {
        /// <summary>
        /// Read parameters
        /// </summary>
        /// <param name="source">Parameter source</param>
        Task<ParameterModel> ReadParameters(string source);
    }
}
