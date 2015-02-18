using ArchitectureModule.Entities;
using ModuleModule.Entities;
using System.Collections.Generic;

namespace ArchitectureModule.Infrastructure
{
    public interface IArchitectureServices
    {
        Architecture LoadArchitecture();
        IEnumerable<Module> LoadModuleOptions();
        void AddModule(Module module);
        void RemoveModule(Module module);
    }
}
