using BaseModule;
using ModuleModule.Entities;
using System.Collections.Generic;

namespace ModulesModule.Infrastructure
{
    public interface IModulesServices : IModule
    {
        IEnumerable<Module> LoadModules();
    }
}
