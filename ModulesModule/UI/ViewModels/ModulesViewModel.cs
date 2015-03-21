using ModuleModule.Entities;
using ModulesModule.Infrastructure;
using System.Collections.Generic;

namespace ModulesModule.ViewModels
{
    public class ModulesViewModel
    {
        #region Members
        IModulesServices _services = null;
        #endregion

        public IEnumerable<Module> LoadModules()
        {
            return _services.LoadModules();
        }

        public void Initialize(ModulesDependencies dependencies)
        {
            _services = dependencies.Services;
        }
    }
}
