using ModuleModule.Infrastructure;
using System;
using System.Collections.Generic;
using ModuleModule.Entities;

namespace Holoware.TestAPI
{
    public class MockModuleServices : IModuleServices
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
