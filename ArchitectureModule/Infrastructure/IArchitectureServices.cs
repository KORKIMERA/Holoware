using ArchitectureModule.Entities;
using BaseModule;
using ModuleModule.Entities;
using System.Collections.Generic;

namespace ArchitectureModule.Infrastructure
{
    public interface IArchitectureServices : IModule
    {
        Architecture LoadArchitecture();
        IEnumerable<Module> LoadModuleOptions();
        void AddModule(Module module);
        void RemoveModule(Module module);
    }
}
