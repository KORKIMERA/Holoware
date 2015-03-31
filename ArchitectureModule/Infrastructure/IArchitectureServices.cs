using ArchitectureModule.Entities;
using BaseModule;
using ModuleModule.Entities;
using System.Collections.Generic;

namespace ArchitectureModule.Infrastructure
{
    public interface IArchitectureServices : IModule
    {
        Architecture LoadArchitecture();
        IEnumerable<Layer> LoadLayers();
        void AddModule(Layer module);
        void RemoveModule(string moduleId);
        Layer GetLayer(string moduleId);
    }
}
