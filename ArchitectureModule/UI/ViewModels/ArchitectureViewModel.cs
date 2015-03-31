using ArchitectureModule.Entities;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using CommandModule.Infrastructure;
using ModuleModule.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArchitectureModule.ViewModels
{
    public class ArchitectureViewModel : ViewModelBase
    {
        #region Members
        Subscription _subscription = new Subscription();
        #endregion

        public ArchitectureViewModel()
        {
            _subscription.Subscribe(Messages.COMMAND_PROCESSED, OnProcessed);
        }

        #region Properties
        ObservableCollection<Layer> _modules = new ObservableCollection<Layer>();
        public ObservableCollection<Layer> Layers
        {
            get { return _modules; }
            set
            {
                if (_modules != value)
                {
                    _modules = value;
                    OnPropertyChanged();
                }
            }
        }

        Layer _selectedModule = null;
        public Layer SelectedLayer
        {
            get { return _selectedModule; }
            set
            {
                if (_selectedModule != value)
                {
                    _selectedModule = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Commands
        public DelegateCommand AddLayerCommand { get; private set; }
        public DelegateCommand RemoveLayerCommand { get; private set; }
        public DelegateCommand ViewLayerCommand { get; private set; }

        public DelegateCommand ExecuteCommand { get; private set; }

        public DelegateCommand LayerDefinitionCommand { get; private set; }

        public DelegateCommand UndoCommand { get; private set; }
        #endregion

        #region Helpers
        private void OnProcessed(object obj)
        {
            var commandContext = obj as CommandContext;

            if (commandContext.Status == CommandStatus.Succeeded)
            {
                UpdateUI(commandContext.Line);
            }
        }

        private void UpdateUI(string consoleLine)
        {
            var tokens = consoleLine.Split(' ');
            var rootCommand = tokens.First().ToLower();
            var line = consoleLine;

            var layerName = line.Remove(line.IndexOf(tokens.First()), tokens.First().Length).Trim();

            switch (rootCommand)
            {
                case "am":
                case "addmodule":
                    {
                        SelectedLayer = new Layer() { Id = layerName, Modules = new ObservableCollection<Module>() };
                        Layers.Add(SelectedLayer);
                        break;
                    }

                case "rm":
                case "removemodule":
                    {
                        SelectedLayer = Layers.Where(l => l.Id == layerName).SingleOrDefault();

                        if (SelectedLayer == null)
                        {
                            MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
                        }

                        Layers.Remove(SelectedLayer);
                        break;
                    }
            }
        }
        #endregion
    }
}