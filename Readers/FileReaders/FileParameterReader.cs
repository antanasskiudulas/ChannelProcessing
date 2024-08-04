using ChannelProcessing.Models;

namespace ChannelProcessing.Readers.FileReaders
{
    /// <inheritdoc cref="IParameterReader"/>
    public class FileParameterReader : IParameterReader
    {
        private readonly IFileReaderAsync _reader;

        public FileParameterReader(IFileReaderAsync readerAsync) 
        {
            _reader = readerAsync;
        }

        /// <inheritdoc/>
        public async Task<List<ParameterModel>> ReadParameters(string source)
        {
            string content = await _reader.ReadFile(source);

            string[] entries = content.Split(SeperatorConsts.COMMA);

            ThrowIfUnevenParameterEntries(entries);

            List<ParameterModel> parameters = new List<ParameterModel>();

            foreach (string entry in entries)
            {
                parameters.Add(TryCreateParameterModel(entry));
            }

            return parameters;
        }

        private static ParameterModel TryCreateParameterModel(string entry)
        {
            ParameterModel model = new ParameterModel();

            if (char.TryParse(entry, out char parameterName))
            {
                model.Parameter = parameterName;
            }
            else if (double.TryParse(entry, out double parameterValue))
            {
                model.Value = parameterValue;
            }
            else
            {
                ThrowIfNotExpectedParameterTypes();
            }

            return model;
        }

        private static void ThrowIfNotExpectedParameterTypes()
        {
            string message = "Error parsing parameters: expected parameters to follow char : double parseable pair";
            Console.WriteLine(message);
            throw new ArgumentException(message);
        }

        private static void ThrowIfUnevenParameterEntries(string[] entries)
        {
            if (entries.Length % 2 > 0)
            {
                string messsage = "Error parsing parameters: expected even amount of corresponding parameters e.g 'c, 0.5, y, 3.1'";
                Console.WriteLine(messsage);
                throw new ArgumentOutOfRangeException(nameof(entries), messsage);
            }
        }
    }
}
