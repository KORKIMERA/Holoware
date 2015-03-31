using CommandModule.Infrastructure;
using Bizmonger.Patterns;
using CommandModule.Infrastructure.Validation;
using ArchitectureModule.Infrastructure;
using System.Linq;

namespace ArchitectureModule.Commands
{
    public class ViewModuleCommand : CommandBase
    {
        #region Constants
        const string VIEW_MODULE_COMMAND_FULL_TEXT = "viewmodule";
        const string VIEW_MODULE_COMMAND_SHORT_TEXT = "vm";
        #endregion

        public ViewModuleCommand()
        {
            MessageBus.Instance.Subscribe(VIEW_MODULE_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(VIEW_MODULE_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }

        public void Execute(string line)
        {
            MessageBus.Instance.Publish(Messages.COMMAND_LINE_HANDLER_FOUND);

            var isValidInstruction = BaseValidator.Validate(line, VIEW_MODULE_COMMAND_FULL_TEXT, VIEW_MODULE_COMMAND_SHORT_TEXT);

            if (!isValidInstruction)
            {
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
            }
            else
            {
                var module = line.Split(' ').Last();
                MessageBus.Instance.Publish(Global.Messages.REQUEST_MODULES_VIEW, module);
                MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Succeeded);
            }
        }

        public override void Initialize()
        {
            MessageBus.Instance.Subscribe(VIEW_MODULE_COMMAND_FULL_TEXT, obj => Execute(obj as string));
            MessageBus.Instance.Subscribe(VIEW_MODULE_COMMAND_SHORT_TEXT, obj => Execute(obj as string));
        }
    }
}