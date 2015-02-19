using System;
using System.Collections.Generic;
using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using ModuleModule.Entities;

namespace Holoware.TestAPI
{
    public class MockArchitectureServices : IArchitectureServices
    {
        public Architecture LoadArchitecture()
        {
            return new Architecture()
            {
                 UserInterface = new Module(),
                 Services = new Module(),
                 Model = new Module(),
                 Repository = new Module()
            };
        }

        public IEnumerable<Module> LoadModuleOptions()
        {
            throw new NotImplementedException();
        }

        public void AddModule(Module module)
        {
            throw new NotImplementedException();
        }

        public void RemoveModule(Module module)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
