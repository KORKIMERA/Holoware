using Bizmonger.Patterns;
using System.Linq;

namespace CommandModule.Infrastructure
{
    public class CommandPreprossor
    {
        static CommandPreprossor()
        {
            MessageBus.Instance.Subscribe(Messages.COMMAND_LINE_SUBMITTED, obj =>
            {
                var commandLine = obj as string;

                if (string.IsNullOrWhiteSpace(commandLine))
                {
                    return;
                }

                var rootCommand = commandLine.Split(' ').First().ToLower();

                MessageBus.Instance.Publish(rootCommand, commandLine);
            });
        }
    }
}
