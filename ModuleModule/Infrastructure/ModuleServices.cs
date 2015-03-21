using ModuleModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleModule.Infrastructure
{
    public class ModuleServices : IModuleServices
    {
        public void AddModule(Module module)
        {
            throw new NotImplementedException();
        }

        public Module GetModule(string layerId)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Module> LoadModules()
        {
            throw new NotImplementedException();
        }

        public void RemoveModule(string moduleId)
        {
            throw new NotImplementedException();
        }
    }
}
