using ModuleModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleModule.Infrastructure;

namespace ModuleModule.ViewModels
{
    public class ModuleViewModel
    {
        #region Members
        IModuleServices _services = null;
        #endregion

        public IEnumerable<Module> LoadModule()
        {
            return _services.LoadModules();
        }

        public void Initialize(ModuleDependencies dependencies)
        {
            _services = dependencies.Services;
        }
    }
}
