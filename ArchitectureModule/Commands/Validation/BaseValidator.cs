using System.Linq;

namespace ArchitectureModule.Commands.Validation
{
    public class BaseValidator
    {
        public static bool Validate(string line, params string[] rootCommandFilter)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            var tokens = line.Split(' ');

            if (!(tokens.Count() > 1))
            {
                return false;
            }

            var isValidInstruction = rootCommandFilter.Contains(tokens.First().ToLower());

            if (!isValidInstruction)
            {
                return false;
            }

            var isValidParameter = tokens[1].Count() > 1 && ValidateParameter(tokens[1]);

            if (!isValidParameter)
            {
                return false;
            }

            return true;
        }

        #region Helpers
        private static bool ValidateParameter(string parameter)
        {
            if (!string.IsNullOrWhiteSpace(parameter))
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
