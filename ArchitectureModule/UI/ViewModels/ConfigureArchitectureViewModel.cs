using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using MessageModule;
using ModuleModule.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ArchitectureModule.ViewModels
{
    public class ConfigureArchitectureViewModel : ViewModelBase
    {
        #region Members
        Subscription _subscription = new Subscription();
        IArchitectureServices _services = null;
        #endregion

        public ConfigureArchitectureViewModel()
        {
            PrepareLayerCommand = new DelegateCommand((obj) => { PrepareLayer(string.Format("AddLayer {0}", "value?")); });
            ExecuteCommand = new DelegateCommand((obj) =>
                {
                    ConsoleLine.Success = Execute(ConsoleLine);
                });

            _subscription.Subscribe(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, obj =>
                {
                    var dependencies = obj as ArchitectureDependencies;
                    _services = dependencies.Services;
                });

            ConsoleLine = new ConsoleLine();
            ConsoleLines.Add(ConsoleLine);
        }

        #region Properties
        ObservableCollection<ConsoleLine> _consoleLines = new ObservableCollection<ConsoleLine>();
        public ObservableCollection<ConsoleLine> ConsoleLines
        {
            get { return _consoleLines; }
            set
            {
                if (_consoleLines != value)
                {
                    _consoleLines = value;
                    OnPropertyChanged();
                }
            }
        }

        ConsoleLine _consoleLine = null;
        public ConsoleLine ConsoleLine
        {
            get { return _consoleLine; }
            set
            {
                if (_consoleLine != value)
                {
                    _consoleLine = value;
                    OnPropertyChanged();
                }
            }
        }

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
        public DelegateCommand PrepareLayerCommand { get; private set; }
        public DelegateCommand ExecuteCommand { get; private set; }
        #endregion

        public IEnumerable<Layer> LoadLayers()
        {
            return _services.LoadLayers();
        }

        public void PrepareLayer(string commandText)
        {
            var consoleLine = new ConsoleLine() { Content = commandText };
            ConsoleLines[ConsoleLines.Count - 1] = consoleLine;
        }

        public void RemoveLayer(Layer layer)
        {
            _services.RemoveLayer(layer);
        }

        #region Helpers

        private bool Execute(ConsoleLine line)
        {
            if (line?.Content == null)
            {
                return false;
            }

            var tokens = line.Content.Split(' ');
            SelectedLayer = new Layer() { Id = tokens.Last(), Modules = new ObservableCollection<Module>() };
            Layers.Add(SelectedLayer);
            _services.AddLayer(SelectedLayer);

            ConsoleLine = new ConsoleLine();
            ConsoleLines.Add(ConsoleLine);
            return true;
        }
        #endregion
    }

    public class ConsoleLine : ViewModelBase
    {
        public string Content { get; set; }

        bool _success = false;
        public bool Success
        {
            get { return _success; }

            set
            {
                if (_success != value)
                {
                    _success = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}