using System;
using System.Collections.Generic;
using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using ModuleModule.Entities;
using System.Linq;

namespace Holoware.TestAPI
{
    public class MockArchitectureServices : IArchitectureServices
    {
        #region Members
        List<Layer> _layers = new List<Layer>();
        #endregion

        #region Singleton
        static MockArchitectureServices _mockArchitectureServices = null;

        private MockArchitectureServices() { }

        public static MockArchitectureServices Instance
        {
            get
            {
                if (_mockArchitectureServices == null)
                {
                    _mockArchitectureServices = new MockArchitectureServices();
                }

                return _mockArchitectureServices;
            }
        }
        #endregion

        public void AddLayer(Layer layer)
        {
            _layers.Add(layer);
        }

        public Layer GetLayer(string layerId)
        {
            return _layers.Where(l => l.Id == layerId).SingleOrDefault();
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

        public void RemoveLayer(string layerId)
        {
            var layer = GetLayer(layerId);

            if (layer != null)
            {
                _layers.Remove(layer);
            }
        }
    }
}
