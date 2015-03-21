using Bizmonger.Patterns;
using System.Linq;

namespace CommandModule.Infrastructure
{
    public class CommandLinePreprossor
    {
        static CommandLinePreprossor()
        {
            MessageBus.Instance.Subscribe(Messages.COMMAND_LINE_SUBMITTED, obj =>
                {
                    var commandLine = obj as string;

                    if (string.IsNullOrWhiteSpace(commandLine))
                    {
                        MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
                    }

                    var rootCommand = commandLine.Split(' ').First().ToLower();
                    var handled = false;

                    MessageBus.Instance.SubscribeFirstPublication(Messages.COMMAND_LINE_HANDLER_FOUND, o =>
                        {
                            handled = true;
                        });

                    MessageBus.Instance.Publish(rootCommand, commandLine);

                    if (!handled)
                    {
                        MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
                    }
                });
            }
    }
}
