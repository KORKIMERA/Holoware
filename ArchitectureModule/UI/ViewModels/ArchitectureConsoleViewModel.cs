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
            AddModuleCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("AddModule {0}", "value?")); });
            RemoveModuleCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("RemoveModule {0}", "value?")); });
            ViewModuleCommand = new DelegateCommand(obj => { PrepareCommand(string.Format("ViewModule {0}", "value?")); });

            ExecuteCommand = new DelegateCommand(obj =>
                {
                    ConsoleLine = ConsoleLines.Last();
                    ConsoleLine.Status = CommandStatus.None;

                    _subscription.SubscribeFirstPublication(Messages.COMMAND_PROCESSED, OnProcessed);

                    MessageBus.Instance.Publish(Messages.COMMAND_LINE_SUBMITTED, ConsoleLine.Content);
                });

            ModuleDefinitionCommand = new DelegateCommand(obj =>
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
        public DelegateCommand AddModuleCommand { get; private set; }
        public DelegateCommand RemoveModuleCommand { get; private set; }
        public DelegateCommand ViewModuleCommand { get; private set; }

        public DelegateCommand ExecuteCommand { get; private set; }

        public DelegateCommand ModuleDefinitionCommand { get; private set; }

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
            
            if (commandContext.Status == CommandStatus.Succeeded)
            {
                var currentConsoleLine = ConsoleLine;
                currentConsoleLine.Status = commandContext.Status;

                ConsoleLine = new ConsoleLine();
                ConsoleLines.Add(ConsoleLine);
            }
            else
            {
                ConsoleLines.Last().Status = CommandStatus.Failed;
            }
        }
        #endregion
    }
}