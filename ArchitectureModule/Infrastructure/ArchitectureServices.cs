using ArchitectureModule.Entities;
using System;
using System.Collections.Generic;

namespace ArchitectureModule.Infrastructure
{
    public class ArchitectureServices : IArchitectureServices
    {
        public void AddLayer(Layer layer)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Entities.Architecture LoadArchitecture()
        {
            return null;
        }

        public IEnumerable<Layer> LoadLayers()
        {
            throw new NotImplementedException();
        }

        public void RemoveLayer(Layer layer)
        {
            throw new NotImplementedException();
        }
    }
}