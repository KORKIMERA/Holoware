using ArchitectureModule.Infrastructure;
using ModuleModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureModule.ViewModels
{
    public class CreateArchitectureViewModel
    {
        #region Members
        IArchitectureServices _services = null;
        #endregion

        public IEnumerable<Module> LoadLayerModules()
        {
            return _services.LoadModuleOptions();
        }

        public void AddModule(Module module)
        {
            _services.AddModule(module);
        }

        public void RemoveModule(Module module)
        {
            _services.RemoveModule(module);
        }
    }
}
