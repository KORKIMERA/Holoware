using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using CommandModule.Infrastructure.Validation;

namespace ArchitectureModule.Commands
{
    public class RemoveLayerCommand : CommandBase
    {
        #region Constants
        const string REMOVE_LAYER_COMMAND_FULL_TEXT = "removelayer";
        const string REMOVE_LAYER_COMMAND_SHORT_TEXT = "rl";
        #endregion

        public void Execute(string line)
        {
            MessageBus.Instance.Publish(Messages.COMMAND_LINE_HANDLER_FOUND);

            var isValidInstruction = BaseValidator.Validate(line, REMOVE_LAYER_COMMAND_FULL_TEXT, REMOVE_LAYER_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
            }
            else
            {
                var tokens = line.Split(' ');

                var layerId = tokens[1];
                var layer = _services.GetLayer(layerId);

                if (layer == null)
                {
                    MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
                }
                else
                {
                    _services.RemoveLayer(layer.Id);
                    MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Succeeded);
                }
            }
        }

        public override void Initialize()
        {
            MessageBus.Instance.Subscribe(REMOVE_LAYER_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(REMOVE_LAYER_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }
    }
}