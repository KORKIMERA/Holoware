using BaseModule;
using ModuleModule.Entities;
using System.Collections.Generic;

namespace ModuleModule.Infrastructure
{
    public interface IModuleServices : IModule
    {
        void AddModule(Module module);
        void RemoveModule(string moduleId);
        IEnumerable<Module> LoadModules();
        Module GetModule(string layerId);
    }
}
