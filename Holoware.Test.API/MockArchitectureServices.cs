using System;
using System.Collections.Generic;
using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using ModuleModule.Entities;

namespace Holoware.TestAPI
{
    public class MockArchitectureServices : IArchitectureServices
    {
        public void AddLayer(Layer layer)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Architecture LoadArchitecture()
        {
            return new Architecture();
        }

        public IEnumerable<Layer> LoadLayers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Module> LoadModuleOptions()
        {
            throw new NotImplementedException();
        }

        public void RemoveLayer(Layer layer)
        {
            throw new NotImplementedException();
        }
    }
}
