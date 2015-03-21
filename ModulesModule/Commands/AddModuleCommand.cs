using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using CommandModule.Infrastructure.Validation;
using ModuleModule.Entities;
using ModulesModule.Infrastructure;

namespace ModulesModule.Commands
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
            var isValidInstruction = BaseValidator.Validate(line, ADD_MODULE_COMMAND_FULL_TEXT, ADD_MODULE_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
            }
            else
            {
                var tokens = line.Split(' ');

                _services.AddModule(new ModuleModule.Entities.Module { Id = tokens[1] });
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Succeeded);
            }
        }
    }
}