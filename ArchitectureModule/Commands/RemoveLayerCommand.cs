using ArchitectureModule.Commands.Validation;
using Bizmonger.Patterns;
using CommandModule.Infrastructure;

namespace ArchitectureModule.Commands
{
    public class RemoveLayerCommand : CommandBase
    {
        #region Constants
        const string REMOVE_LAYER_COMMAND_FULL_TEXT = "removelayer";
        const string REMOVE_LAYER_COMMAND_SHORT_TEXT = "rl";
        #endregion

        public static void Execute(string line)
        {
            var isValidInstruction = BaseValidator.Validate(line, REMOVE_LAYER_COMMAND_FULL_TEXT, REMOVE_LAYER_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_LINE_PROCESSED, CommandStatus.Failed);
            }
            else
            {
                MessageBus.Instance.Publish(Messages.COMMAND_LINE_PROCESSED, CommandStatus.Succeeded);
            }
        }

        public override void Initialize()
        {
            MessageBus.Instance.Subscribe(REMOVE_LAYER_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(REMOVE_LAYER_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }
    }
}