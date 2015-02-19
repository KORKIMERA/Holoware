using BaseModule;
using ModulesModule.Entities;

namespace ModulesModule.Infrastructure
{
    public interface IModulesServices : IModuleDelegate
    {
        Modules LoadModules();
    }
}
