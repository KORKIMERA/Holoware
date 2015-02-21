using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using MessageModule;
using ModuleModule.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

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
            PrepareLayerCommand = new DelegateCommand((obj) => { PrepareLayer(); });
            ExecuteCommand = new DelegateCommand((obj) => { Execute(Command); });
        }

        public void Initialize()
        {
            _subscription.Subscribe(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, obj =>
                {
                    var dependencies = obj as ArchitectureDependencies;
                    var services = dependencies.Services;
                });
        }

        #region Properties
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

        ObservableCollection<string> _commands = new ObservableCollection<string>();
        public ObservableCollection<string> Commands
        {
            get { return _commands; }
            set
            {
                if (_commands != value)
                {
                    _commands = value;
                    OnPropertyChanged();
                }
            }
        }

        string _command = null;
        public string Command
        {
            get { return _command; }
            set
            {
                if (_command != value)
                {
                    _command = value;
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

        public void PrepareLayer()
        {
            Command = string.Format("AddLayer {0}", "value?");
            Commands.Add(Command);

            SelectedLayer = new Layer() { Id = null, Modules = new ObservableCollection<Module>() };
            Layers.Add(SelectedLayer);
        }

        public void RemoveLayer(Layer layer)
        {
            _services.RemoveLayer(layer);
        }

        #region Helpers

        private void Execute(string command)
        {
            _services.AddLayer(SelectedLayer);
        }
        #endregion
    }
}
