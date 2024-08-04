using Autofac;
using CommandLine;

namespace ChannelProcessing
{
    internal class Program
    {
        private static IContainer _container = CreateContainer();

        static void Main(string[] args)
        {
            _container = CreateContainer();

            Parser.Default.ParseArguments<CommandArguments>(args)
                .WithParsed(ProcessCommand)
                .WithNotParsed(HandleErrors);
        }

        private static void ProcessCommand(CommandArguments commandArgs)
        {
            using (ILifetimeScope scope = _container.BeginLifetimeScope())
            {

            }
        }

        private static void HandleErrors(IEnumerable<Error> errors)
        {
            foreach (Error error in errors)
            {
                Console.WriteLine(error);
            }
        }

        private static IContainer CreateContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<ChannelProcessingModule>();

            return builder.Build();
        }
    }
}
