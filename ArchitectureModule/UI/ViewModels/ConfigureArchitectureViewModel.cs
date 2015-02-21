using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using ModuleModule.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureModule.ViewModels
{
    public class ConfigureArchitectureViewModel : ViewModelBase
    {
        #region Members
        IArchitectureServices _services = null;
        #endregion

        public ConfigureArchitectureViewModel()
        {
            PrepareLayerCommand = new DelegateCommand((obj) => { PrepareLayer(); });
            SubmitLayerCommand = new DelegateCommand((obj) => { _services.AddLayer(SelectedLayer); });
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

        #region Commands
        public DelegateCommand PrepareLayerCommand { get; private set; }
        public DelegateCommand SubmitLayerCommand { get; private set; }
        #endregion

        public IEnumerable<Layer> LoadLayers()
        {
            return _services.LoadLayers();
        }

        public void PrepareLayer()
        {
            SelectedLayer = new Layer() { Id = "1", Modules = new ObservableCollection<Module>() };
            Layers.Add(SelectedLayer);
        }

        public void RemoveLayer(Layer layer)
        {
            _services.RemoveLayer(layer);
        }
    }
}
