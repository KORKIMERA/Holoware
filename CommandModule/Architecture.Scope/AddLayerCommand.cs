using CommandModule.Infrastructure;

namespace CommandModule.Architecture.Scope
{
    public class AddLayerCommand : CommandTemplate
    {
        public override bool ValidateParameter(string v)
        {
            if (!string.IsNullOrWhiteSpace(v))
            {
                return true;
            }

            return false;
        }

        public override bool ValidateInstruction(string text)
        {
            if (text.ToLower() == "addlayer" || text.ToLower() == "al")
            {
                return true;
            }

            if (text.ToLower() == "viewlayer" || text.ToLower() == "vl")
            {
                return true;
            }

            return false;
        }
    }
}