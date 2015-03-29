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
        //ObservableCollection<ConsoleLine> _consoleLines = new ObservableCollection<ConsoleLine>();
        //public ObservableCollection<ConsoleLine> ConsoleLines
        //{
        //    get { return _consoleLines; }
        //    set
        //    {
        //        if (_consoleLines != value)
        //        {
        //            _consoleLines = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //ConsoleLine _consoleLine = null;
        //public ConsoleLine ConsoleLine
        //{
        //    get { return _consoleLine; }
        //    set
        //    {
        //        if (_consoleLine != value)
        //        {
        //            _consoleLine = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        ObservableCollection<Layer> _layers = new ObservableCollection<Layer>();
        public ObservableCollection<Layer> Layers
        {
            get { return _layers; }
            set
            {
                if (_layers != value)
                {
                    _layers = value;
                    OnPropertyChanged();
                }
            }
        }

        Layer _selectedLayer = null;
        public Layer SelectedLayer
        {
            get { return _selectedLayer; }
            set
            {
                if (_selectedLayer != value)
                {
                    _selectedLayer = value;
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
                case "al":
                case "addlayer":
                    {
                        SelectedLayer = new Layer() { Id = layerName, Modules = new ObservableCollection<Module>() };
                        Layers.Add(SelectedLayer);
                        break;
                    }

                case "rl":
                case "removelayer":
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