using System;
using System.Collections.Generic;
using ArchitectureModule.Entities;
using ModuleModule.Entities;

namespace ArchitectureModule.Infrastructure
{
    public class ArchitectureServices : IArchitectureServices
    {
        public void AddModule(Module module)
        {
            throw new NotImplementedException();
        }

        public Architecture LoadArchitecture()
        {
            return null;
        }

        public IEnumerable<Module> LoadModuleOptions()
        {
            throw new NotImplementedException();
        }

        public void RemoveModule(Module module)
        {
            throw new NotImplementedException();
        }
    }
}