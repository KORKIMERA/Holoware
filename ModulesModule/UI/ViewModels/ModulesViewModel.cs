using Bizmonger.UILogic;
using CommandModule.Infrastructure;
using ModuleModule.Entities;
using ModulesModule.Infrastructure;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModulesModule.ViewModels
{
    public class ModulesViewModel : ViewModelBase
    {
        #region Members
        IModulesServices _services = null;
        #endregion

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

        public IEnumerable<Module> LoadModules()
        {
            return null; // _services.LoadModules();
        }

        public void Initialize(ModulesDependencies dependencies)
        {
            //_services = dependencies.Services;
        }
    }
}
