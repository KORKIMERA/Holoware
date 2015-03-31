using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using CommandModule.Infrastructure.Validation;

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
            MessageBus.Instance.Publish(Messages.COMMAND_LINE_HANDLER_FOUND);

            var isValidInstruction = BaseValidator.Validate(line, REMOVE_MODULE_COMMAND_FULL_TEXT, REMOVE_MODULE_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, new CommandContext() { Line = line, Status = CommandStatus.Failed });
            }
            else
            {
                var tokens = line.Split(' ');

                var moduleId = tokens[1];
                var module = _services.GetLayer(moduleId);

                if (module == null)
                {
                    MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, new CommandContext() { Line = line, Status = CommandStatus.Failed });
                }
                else
                {
                    _services.RemoveModule(module.Id);
                    MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, new CommandContext() { Line = line, Status = CommandStatus.Succeeded });
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