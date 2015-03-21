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

        public ArchitectureServices()
        {
            _subscription.Subscribe(SystemMessage.REQUEST_BOOTSTRAP, (obj) =>
                {
                    MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, this);
                });
        }

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