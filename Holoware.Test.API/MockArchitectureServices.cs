using System;
using System.Collections.Generic;
using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using ModuleModule.Entities;

namespace Holoware.TestAPI
{
    public class MockArchitectureServices : IArchitectureServices
    {
        #region Members
        List<Layer> _layers = new List<Layer>();
        #endregion

        public void AddLayer(Layer layer)
        {
            _layers.Add(layer);
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
