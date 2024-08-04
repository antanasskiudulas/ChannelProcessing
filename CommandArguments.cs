using CommandLine;

namespace ChannelProcessing
{
    /// <summary>
    /// Model representing arguments supported by the application
    /// </summary>
    public class CommandArguments
    {
        [Option('c', "channel", Required = false, HelpText = "Windows path to channel file to be processed")]
        public string channelPath { get; private set; } = string.Empty;

        [Option('p', "parameters", Required = false, HelpText = "Windows path to parameters file to be applied to channels")]
        public string parametersPath { get; private set; } = string.Empty;
    }
}
