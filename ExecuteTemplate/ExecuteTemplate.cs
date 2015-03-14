using System.Linq;

namespace ExecuteTemplate
{
    public abstract class ExecuteTemplate
    {
        private CommandStatus Execute(ConsoleLine line)
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

            var layerName = line.Content.Remove(line.Content.IndexOf(tokens[0]), tokens[0].Length).Trim();

            SelectedLayer = new Layer() { Id = layerName, Modules = new ObservableCollection<Module>() };
            Layers.Add(SelectedLayer);
            _services.AddLayer(SelectedLayer);

            return CommandStatus.Succeeded;
        }
    }
}
