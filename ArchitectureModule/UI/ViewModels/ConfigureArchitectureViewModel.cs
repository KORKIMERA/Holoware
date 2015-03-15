﻿using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using CommandModule.Infrastructure;
using MessageModule;
using ModuleModule.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            PrepareLayerCommand = new DelegateCommand(obj => { PrepareLayer(string.Format("AddLayer {0}", "value?")); });

            ExecuteCommand = new DelegateCommand(obj =>
                {
                    ConsoleLine = ConsoleLines.Last();
                    ConsoleLine.Status = CommandStatus.None;

                    _subscription.SubscribeFirstPublication(Messages.COMMAND_LINE_PROCESSED, status =>
                        {
                            ConsoleLine.Status = (CommandStatus)status;

                            if (ConsoleLine.Status == CommandStatus.Succeeded)
                            {
                                var tokens = ConsoleLine.Content.Split(' ');

                                var line = ConsoleLine.Content;
                                var layerName = line.Remove(line.IndexOf(tokens[0]), tokens[0].Length).Trim();

                                SelectedLayer = new Layer() { Id = layerName, Modules = new ObservableCollection<Module>() };
                                Layers.Add(SelectedLayer);
                                _services.AddLayer(SelectedLayer);

                                ConsoleLine = new ConsoleLine();
                                ConsoleLines.Add(ConsoleLine);
                            }
                        });

                    MessageBus.Instance.Publish(Messages.COMMAND_LINE_SUBMITTED, ConsoleLine.Content);
                });

            UndoCommand = new DelegateCommand(obj =>
                {
                    Undo();
                });

            LayerDefinitionCommand = new DelegateCommand(obj =>
                {
                    MessageBus.Instance.Publish(MessageModule.Messaging.UXMessage.REQUEST_LAYER_MODULES, SelectedLayer);
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

        public DelegateCommand LayerDefinitionCommand { get; private set; }

        public DelegateCommand UndoCommand { get; private set; }
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

        //private CommandStatus Execute(ConsoleLine line)
        //{
        //    if (line?.Content == null)
        //    {
        //        return CommandStatus.Failed;
        //    }

        //    var tokens = line.Content.Split(' ');

        //    if (!(tokens.Count() > 1))
        //    {
        //        return CommandStatus.Failed;
        //    }

        //    var isValidInstruction = ValidateInstruction(tokens[0]);

        //    if (!isValidInstruction)
        //    {
        //        return CommandStatus.Failed;
        //    }

        //    var isValidParameter = ValidateParameter(tokens[1]);

        //    if (!isValidParameter)
        //    {
        //        return CommandStatus.Failed;
        //    }

        //    var layerName = line.Content.Remove(line.Content.IndexOf(tokens[0]), tokens[0].Length).Trim();

        //    SelectedLayer = new Layer() { Id = layerName, Modules = new ObservableCollection<Module>() };
        //    Layers.Add(SelectedLayer);
        //    _services.AddLayer(SelectedLayer);

        //    return CommandStatus.Succeeded;
        //}

        private void Undo()
        {
            throw new NotImplementedException();
        }

        private bool ValidateParameter(string v)
        {
            if (!string.IsNullOrWhiteSpace(v))
            {
                return true;
            }

            return false;
        }

        private bool ValidateInstruction(string text)
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
        #endregion
    }
}