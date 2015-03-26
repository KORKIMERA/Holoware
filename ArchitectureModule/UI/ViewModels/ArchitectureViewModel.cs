using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using CommandModule.Infrastructure;
using ModuleModule.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArchitectureModule.ViewModels
{
    public class ArchitectureViewModel : ViewModelBase
    {
        //#region Members
        //Subscription _subscription = new Subscription();
        //IArchitectureServices _services = null;
        //#endregion

        public ArchitectureViewModel()
        {
            //AddLayerCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("AddLayer {0}", "value?")); });
            //RemoveLayerCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("RemoveLayer {0}", "value?")); });
            //ViewLayerCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("ViewLayer {0}", "value?")); });

        //    ExecuteCommand = new DelegateCommand(obj =>
        //        {
        //            ConsoleLine = ConsoleLines.Last();
        //            ConsoleLine.Status = CommandStatus.None;

        //            _subscription.SubscribeFirstPublication(Messages.COMMAND_PROCESSED, OnProcessed);

        //            MessageBus.Instance.Publish(Messages.COMMAND_LINE_SUBMITTED, ConsoleLine.Content);
        //        });

        //    UndoCommand = new DelegateCommand(obj =>
        //        {
        //            Undo();
        //        });

        //    LayerDefinitionCommand = new DelegateCommand(obj =>
        //        {
        //            MessageBus.Instance.Publish(Global.Messages.REQUEST_MODULES_VIEW, SelectedLayer);
        //        });

        //    _subscription.SubscribeFirstPublication(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, obj =>
        //        {
        //            var dependencies = obj as ArchitectureDependencies;
        //            _services = dependencies.Services;
        //        });

        //    _subscription.Subscribe(Global.Messages.REQUEST_ARCHITECTURE_VIEWMODEL, obj => MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_VIEWMODEL_COMPLETED, this));

        //    ConsoleLine = new ConsoleLine();
        //    ConsoleLines.Add(ConsoleLine);
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

        //public IEnumerable<Layer> LoadLayers()
        //{
        //    return _services.LoadLayers();
        //}

        //public void PrepareCommand(string commandText)
        //{
        //    var consoleLine = new ConsoleLine() { Content = commandText };
        //    ConsoleLines[ConsoleLines.Count - 1] = consoleLine;
        //}

        //public void RemoveLayer(string layerId)
        //{
        //    _services.RemoveLayer(layerId);
        //}

        #region Helpers
        //private void OnProcessed(object obj)
        //{
        //    ConsoleLine.Status = (CommandStatus)obj;

        //    if (ConsoleLine.Status == CommandStatus.Succeeded)
        //    {
        //        UpdateUI();

        //        ConsoleLine = new ConsoleLine();
        //        ConsoleLines.Add(ConsoleLine);
        //    }
        //}

        //private void UpdateUI()
        //{
        //    var tokens = ConsoleLine.Content.Split(' ');

        //    var line = ConsoleLine.Content;
        //    var layerName = line.Remove(line.IndexOf(tokens.First()), tokens.First().Length).Trim();
        //    var rootCommand = tokens.First().ToLower();

        //    switch (rootCommand)
        //    {
        //        case "al":
        //        case "addlayer":
        //            {
        //                SelectedLayer = new Layer() { Id = layerName, Modules = new ObservableCollection<Module>() };
        //                Layers.Add(SelectedLayer);
        //                break;
        //            }

        //        case "rl":
        //        case "removelayer":
        //            {
        //                SelectedLayer = Layers.Where(l => l.Id == layerName).SingleOrDefault();

        //                if (SelectedLayer == null)
        //                {
        //                    MessageBus.Instance.Publish(Messages.COMMAND_PROCESSED, CommandStatus.Failed);
        //                }

        //                Layers.Remove(SelectedLayer);
        //                break;
        //            }
        //    }
        //}

        private void Undo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}