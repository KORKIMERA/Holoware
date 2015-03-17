using CommandModule.Infrastructure;
using Bizmonger.Patterns;
using ArchitectureModule.Commands.Validation;

namespace ArchitectureModule.Commands
{
    public class ViewLayerCommand
    {
        static ViewLayerCommand()
        {
            MessageBus.Instance.Subscribe("viewlayer", obj => Execute(obj as string));
            MessageBus.Instance.Subscribe("vl", obj => Execute(obj as string));
        }

        public static void Initialize() { }

        public static void Execute(string line)
        {
            var isValidInstruction = BaseValidator.Validate(line, "viewlayer", "vl" );

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_LINE_PROCESSED, CommandStatus.Failed);
            }
            else
            {
                MessageBus.Instance.Publish(Messages.COMMAND_LINE_PROCESSED, CommandStatus.Succeeded);
            }
        }
    }
}