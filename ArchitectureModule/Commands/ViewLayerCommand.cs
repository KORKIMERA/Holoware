using CommandModule.Infrastructure;
using Bizmonger.Patterns;
using ArchitectureModule.Commands.Validation;

namespace ArchitectureModule.Commands
{
    public class ViewLayerCommand
    {
        #region Constants
        const string VIEW_LAYER_COMMAND_FULL_TEXT = "viewlayer";
        const string VIEW_LAYER_COMMAND_SHORT_TEXT = "vl";
        #endregion

        static ViewLayerCommand()
        {
            MessageBus.Instance.Subscribe(VIEW_LAYER_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(VIEW_LAYER_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
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