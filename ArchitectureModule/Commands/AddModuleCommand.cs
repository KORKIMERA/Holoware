using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using CommandModule.Infrastructure.Validation;

namespace ArchitectureModule.Commands
{
    public class AddModuleCommand : CommandBase
    {
        #region Constants
        const string ADD_MODULE_COMMAND_FULL_TEXT = "addmodule";
        const string ADD_MODULE_COMMAND_SHORT_TEXT = "am";
        #endregion

        public override void Initialize()
        {
            MessageBus.Instance.Subscribe(ADD_MODULE_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(ADD_MODULE_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }

        public void Execute(string line)
        {
            MessageBus.Instance.Publish(Messages.COMMAND_LINE_HANDLER_FOUND);

            var isValidInstruction = BaseValidator.Validate(line, ADD_MODULE_COMMAND_FULL_TEXT, ADD_MODULE_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, new CommandContext() { Line = line, Status = CommandStatus.Failed });
            }
            else
            {
                var tokens = line.Split(' ');

                _services.AddModule(new Entities.Layer() { Id = tokens[1] });
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, new CommandContext() { Line = line, Status = CommandStatus.Succeeded });
            }
        }
    }
}