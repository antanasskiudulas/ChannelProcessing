using ChannelProcessing.Models;

namespace ChannelProcessing.Readers.FileReaders
{
    /// <inheritdoc cref="IParameterReader"/>
    public class FileParameterReader : IParameterReader
    {
        private const char SLOPE_KEY = 'm';
        private const char INTERCEPT_KEY = 'c';
        private const int MAX_ARGUMENTS = 2;

        private readonly IFileReaderAsync _reader;

        public FileParameterReader(IFileReaderAsync readerAsync)
        {
            _reader = readerAsync;
        }

        /// <inheritdoc/>
        public async Task<ParameterModel> ReadParameters(string source)
        {
            string content = await _reader.ReadFile(source);

            Dictionary<char, double> parameters = ExtractParameters(content);

            return TryCreateParameterModel(parameters);
        }

        private Dictionary<char, double> ExtractParameters(string content)
        {
            string[] parameterLines = content.Split(Environment.NewLine);

            Dictionary<char, double> parameters = new Dictionary<char, double>();

            foreach (string entry in parameterLines)
            {
                (string parameterKeyRaw, string parameterValueRaw) = GetParameterPair(entry);

                if (char.TryParse(parameterKeyRaw, out char parameterKey)
                    && double.TryParse(parameterValueRaw, out double parameterValue))
                {
                    parameters.Add(parameterKey, parameterValue);
                }
            }

            return parameters;
        }

        private static ParameterModel TryCreateParameterModel(Dictionary<char, double> parameters)
        {
            bool isSlopePresent = parameters.TryGetValue(SLOPE_KEY, out double slopeValue);
            bool isInterceptPresent = parameters.TryGetValue(INTERCEPT_KEY, out double interceptValue);

            if (!isSlopePresent || !isInterceptPresent)
            {
                ThrowParametersNotFound();
            }

            return new ParameterModel
            {
                Slope = slopeValue,
                Intercept = interceptValue
            };
        }

        private static (string parameterKey, string parameterValue) GetParameterPair(string parameterLine)
        {
            string[] parameterPair = parameterLine.Split(SeperatorConsts.COMMA, StringSplitOptions.TrimEntries);

            return (parameterPair.First(), parameterPair.Last());
        }

        private static void ThrowParametersNotFound()
        {
            string message = $"Error parsing parameters. Could not find parameters with key {SLOPE_KEY} and {INTERCEPT_KEY}";
            Console.WriteLine(message);
            throw new ArgumentException(message);
        }
    }
}
