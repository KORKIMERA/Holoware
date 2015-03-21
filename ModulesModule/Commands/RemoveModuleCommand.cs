using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using CommandModule.Infrastructure.Validation;
using ModulesModule.Infrastructure;

namespace ArchitectureModule.Commands
{
    public class RemoveModuleCommand : CommandBase
    {
        #region Constants
        const string REMOVE_MODULE_COMMAND_FULL_TEXT = "removemodule";
        const string REMOVE_MODULE_COMMAND_SHORT_TEXT = "rm";
        #endregion

        public void Execute(string line)
        {
            var isValidInstruction = BaseValidator.Validate(line, REMOVE_MODULE_COMMAND_FULL_TEXT, REMOVE_MODULE_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
            }
            else
            {
                var tokens = line.Split(' ');

                var layerId = tokens[1];
                var module = _services.GetModule(layerId);

                if (module == null)
                {
                    MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
                }
                else
                {
                    _services.RemoveModule(module.Id);
                    MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Succeeded);
                }
            }
        }

        public override void Initialize()
        {
            MessageBus.Instance.Subscribe(REMOVE_MODULE_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(REMOVE_MODULE_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }
    }
}