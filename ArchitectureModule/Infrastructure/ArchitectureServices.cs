using ArchitectureModule.Entities;
using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using MessageModule;
using System;
using System.Collections.Generic;

namespace ArchitectureModule.Infrastructure
{
    public class ArchitectureServices : IArchitectureServices
    {
        Subscription _subscription = new Subscription();

        #region Singleton
        static ArchitectureServices _ArchitectureServices = null;

        private ArchitectureServices()
        {
            _subscription.Subscribe(SystemMessage.REQUEST_BOOTSTRAP, (obj) =>
                {
                    MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, this);
                });
        }

        public static ArchitectureServices Instance
        {
            get
            {
                if (_ArchitectureServices == null)
                {
                    _ArchitectureServices = new ArchitectureServices();
                }

                return _ArchitectureServices;
            }
        }
        #endregion

        public void AddLayer(Layer layer)
        {
            throw new NotImplementedException();
        }

        public Layer GetLayer(string layerId)
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

        public void RemoveLayer(string layerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveLayer(Layer layer)
        {
            throw new NotImplementedException();
        }
    }
}