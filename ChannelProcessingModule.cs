using Autofac;
using ChannelProcessing.Engine;
using ChannelProcessing.Processors;
using ChannelProcessing.Readers;
using ChannelProcessing.Readers.FileReaders;
using ChannelProcessing.Writers;

namespace ChannelProcessing
{
    /// <summary>
    /// Module defining dependency injection mappings for the application
    /// </summary>
    public class ChannelProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileReader>().As<IFileReader>().SingleInstance();
            builder.RegisterType<FileParameterReader>().As<IParameterReader>().SingleInstance();
            builder.RegisterType<FileChannelReader>().As<IChannelReader>().SingleInstance();
            builder.RegisterType<ChannelProcessor>().As<IChannelProcessor>().SingleInstance();
            builder.RegisterType<ChannelOutputFormatter>().As<IChannelOutputFormatter>().SingleInstance();
            builder.RegisterType<FileChannelWriter>().As<IChannelWriter>().SingleInstance();
            builder.RegisterDecorator<ConsoleChannelWriter, IChannelWriter>();
            builder.RegisterType<ChannelEngine>().As<IChannelEngine>().SingleInstance();
        }
    }
}
