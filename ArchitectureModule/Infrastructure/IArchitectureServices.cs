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
        void AddLayer(Layer layer);
        void RemoveLayer(string layerId);
        Layer GetLayer(string layerId);
    }
}
