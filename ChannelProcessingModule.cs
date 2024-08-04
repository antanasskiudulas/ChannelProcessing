using Autofac;
using ChannelProcessing.Readers;
using ChannelProcessing.Readers.FileReaders;

namespace ChannelProcessing
{
    /// <summary>
    /// Module defining dependency injection mappings for the application
    /// </summary>
    public class ChannelProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileReaderAsync>().As<IFileReaderAsync>();
            builder.RegisterType<FileParameterReader>().As<IParameterReader>();
            builder.RegisterType<FileChannelReader>().As<IChannelReader>();
        }
    }
}
