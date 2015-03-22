using CommandModule.Infrastructure;
using Bizmonger.Patterns;
using CommandModule.Infrastructure.Validation;
using ArchitectureModule.Infrastructure;
using ModulesModule.UI.Views;
using UXModule;

namespace ArchitectureModule.Commands
{
    public class ViewLayerCommand : CommandBase
    {
        #region Constants
        const string VIEW_LAYER_COMMAND_FULL_TEXT = "viewlayer";
        const string VIEW_LAYER_COMMAND_SHORT_TEXT = "vl";
        #endregion

        public ViewLayerCommand()
        {
            MessageBus.Instance.Subscribe(VIEW_LAYER_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(VIEW_LAYER_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }

        public void Execute(string line)
        {
            var isValidInstruction = BaseValidator.Validate(line, VIEW_LAYER_COMMAND_FULL_TEXT, VIEW_LAYER_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
            }
            else
            {
                UXServices.Instance.LoadView(typeof(ModulesView), UXModule.RegionId.MAIN);
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Succeeded);
            }
        }

        public override void Initialize()
        {
            MessageBus.Instance.Subscribe(VIEW_LAYER_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(VIEW_LAYER_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }
    }
}