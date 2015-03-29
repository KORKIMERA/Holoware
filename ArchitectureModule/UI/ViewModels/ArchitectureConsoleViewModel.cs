using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using CommandModule.Infrastructure;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArchitectureModule.UI.ViewModels
{
    public class ArchitectureConsoleViewModel : ViewModelBase
    {
        #region Members
        Subscription _subscription = new Subscription();
        IArchitectureServices _services = null;
        #endregion

        public ArchitectureConsoleViewModel()
        {
            AddLayerCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("AddLayer {0}", "value?")); });
            RemoveLayerCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("RemoveLayer {0}", "value?")); });
            ViewLayerCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("ViewLayer {0}", "value?")); });

            ExecuteCommand = new DelegateCommand(obj =>
                {
                    ConsoleLine = ConsoleLines.Last();
                    ConsoleLine.Status = CommandStatus.None;

                    _subscription.SubscribeFirstPublication(Messages.COMMAND_PROCESSED, OnProcessed);

                    MessageBus.Instance.Publish(Messages.COMMAND_LINE_SUBMITTED, ConsoleLine.Content);
                });

            LayerDefinitionCommand = new DelegateCommand(obj =>
                {
                    MessageBus.Instance.Publish(Global.Messages.REQUEST_MODULES_VIEW, SelectedLayer);
                });

            _subscription.SubscribeFirstPublication(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, obj =>
                {
                    var dependencies = obj as ArchitectureDependencies;
                    _services = dependencies.Services;
                });

            _subscription.Subscribe(Global.Messages.REQUEST_ARCHITECTURE_VIEWMODEL, obj => MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_VIEWMODEL_COMPLETED, this));

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

        public void PrepareCommand(string commandText)
        {
            var consoleLine = new ConsoleLine() { Content = commandText };
            ConsoleLines[ConsoleLines.Count - 1] = consoleLine;
        }

        #region Helpers
        private void OnProcessed(object obj)
        {
            var commandContext = obj as CommandContext;
            ConsoleLine.Status = commandContext.Status;

            if (commandContext.Status == CommandStatus.Succeeded)
            {
                ConsoleLine = new ConsoleLine();
                ConsoleLines.Add(ConsoleLine);
            }
        }
        #endregion
    }
}