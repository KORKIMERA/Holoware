using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModule.Infrastructure
{
    public abstract class CommandTemplate
    {
        public CommandStatus Execute(ConsoleLine line)
        {
            if (line?.Content == null)
            {
                return CommandStatus.Failed;
            }

            var tokens = line.Content.Split(' ');

            if (!(tokens.Count() > 1))
            {
                return CommandStatus.Failed;
            }

            var isValidInstruction = ValidateInstruction(tokens[0]);

            if (!isValidInstruction)
            {
                return CommandStatus.Failed;
            }

            var isValidParameter = ValidateParameter(tokens[1]);

            if (!isValidParameter)
            {
                return CommandStatus.Failed;
            }

            return CommandStatus.Succeeded;
        }

        public abstract bool ValidateParameter(string parameter);

        public abstract bool ValidateInstruction(string text);
    }
}
