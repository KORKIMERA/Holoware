using ModulesModule.Entities;
using ModulesModule.Infrastructure;
using System;

namespace ModulesModule.ViewModels
{
    public class ModulesViewModel
    {
        #region Members
        IModulesServices _services = null;
        #endregion

        public Modules LoadModules()
        {
            return _services.LoadModules();
        }

        public void Initialize(ModulesDependencies dependencies)
        {
            _services = dependencies.Services;
        }
    }
}
